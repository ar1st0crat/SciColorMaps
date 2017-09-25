using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.Foundation;
using Windows.Storage.Pickers;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.UI.Popups;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using SciColorMaps.Portable;

namespace SciColorMaps.DemoUwp
{
    /// <summary>
    /// Class providing the main extension method that converts rgb array to Windows.UI.Color
    /// </summary>
    public static class ColorUtils
    {
        public static Color ToUwpColor(this byte[] rgb)
        {
            return Color.FromArgb(255, rgb[0], rgb[1], rgb[2]);
        }
    }

    /// <summary>
    /// Helper class for binding colormap thumbnails in the left panel of the page
    /// </summary>
    public class ColorMapInfo
    {
        public string Title { get; set; }
        public LinearGradientBrush PaletteBrush { get; set; }
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Default number of base colors in each colormap
        /// </summary>
        private const int ColorCountDefault = 128;

        /// <summary>
        /// All colormaps imported from SciColorMaps
        /// </summary>
        public ObservableCollection<ColorMapInfo> ColorMaps { get; set; }

        /// <summary>
        /// The colormap currently selected by user
        /// </summary>
        private string _currentColorMap;
        private ColorMap _cmap;

        /// <summary>
        /// Audio signal (loaded from mediafile or recorded)
        /// </summary>
        private Signal _signal;

        /// <summary>
        /// Spectrogram values
        /// </summary>
        private List<double[]> _spectrogram; 

        /// <summary>
        /// Bitmaps with 2d and 3d spectrograms of the signal
        /// </summary>
        private CanvasBitmap _spectrogram2D;
        private CanvasBitmap _spectrogram3D;

        /// <summary>
        /// Rotation angles (in 3d spectrogram)
        /// </summary>
        private const int AngleX =  45;//deg
        private const int AngleY =  45;//deg
        private const int AngleZ = -25;//deg

        /// <summary>
        /// Interpolation stride used for plotting 3d spectrogram
        /// </summary>
        private const double Stride = 0.75;

        /// <summary>
        /// Relative coordinates of the center (in 3d spectrogram)
        /// </summary>
        private const int CenterX = 600;
        private const int CenterY = 50;

        /// <summary>
        /// See AudioService.cs source file
        /// </summary>
        private readonly AudioService _audioService = new AudioService();


        #region working with colormaps

        public MainPage()
        {
            InitializeComponent();

            ColorMaps = new ObservableCollection<ColorMapInfo>();

            foreach (var palette in ColorMap.Palettes)
            {
                var cmap = new ColorMap(palette, colorCount: ColorCountDefault);

                ColorMaps.Add(new ColorMapInfo
                {
                    Title = palette,
                    PaletteBrush = CreatePaletteBrush(cmap)
                });
            }

            _currentColorMap = ColorMap.Palettes.First();
        }

        private static LinearGradientBrush CreatePaletteBrush(ColorMap cmap)
        {
            var stops = new GradientStopCollection();

            var pos = 0.0f;

            foreach (var rgb in cmap.Colors())
            {
                stops.Add(new GradientStop
                {
                    Color = rgb.ToUwpColor(),
                    Offset = pos++ / ColorCountDefault
                });
            }

            return new LinearGradientBrush
            {
                GradientStops = stops,
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1)
            };
        }
        
        private void MirrorClick(object sender, RoutedEventArgs e)
        {
            if (_cmap == null)
            {
                return;
            }

            _cmap = new MirrorColorMap(_cmap);

            UpdateSpectrogramBitmaps();
        }

        private void SelectedColorMapChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = e.AddedItems.FirstOrDefault() as ColorMapInfo;

            if (item == null || _signal == null)
            {
                return;
            }

            _currentColorMap = item.Title;

            CalculateSpectrogram();
            UpdateSpectrogramBitmaps();
        }

        #endregion


        #region calculations and drawing

        private void CalculateSpectrogram()
        {
            const int fftSize = 512;
            const int spectrumSize = fftSize / 2;
            const int hopSize = fftSize / 4;

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // from the huge amount of samples take some first ones (let's say, 400 samples)
            var samples = _signal.Samples.Take(400 * spectrumSize).ToArray();

            // the central part of the code:
            _spectrogram = Transform.Spectrogram(samples, fftSize, hopSize);

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            var spectraCount = _spectrogram.Count;

            var minValue = _spectrogram.SelectMany(s => s).Min();
            var maxValue = _spectrogram.SelectMany(s => s).Max();

            // post-process spectrogram for better visualization
            for (var i = 0; i < spectraCount; i++)
            {
                // amplify insignificant values and attenuate big outliers a little bit
                // (yes, the magic numbers are guests today in our studio )))
                _spectrogram[i] = _spectrogram[i].Select(s => (s * 3 < maxValue) ? s * 3 : s / 1.5)
                                                 .ToArray();
            }
            maxValue /= 2;
            // ...

            _cmap = new ColorMap(_currentColorMap, minValue, maxValue);
        }

        private void UpdateSpectrogramBitmaps()
        {
            var spectraCount = _spectrogram.Count;
            var spectrumSize = _spectrogram.First().Length;
            
            // ============ create 2D spectrogram bitmap ============

            var colors2D = new Color[spectraCount * spectrumSize];

            for (var i = 0; i < spectraCount; i++)
            {
                // ...flip rows bottom-to-top...
                var pos = (spectrumSize - 1) * spectraCount + i;

                for (var j = 0; j < spectrumSize; j++)
                {
                    colors2D[pos] = _cmap[_spectrogram[i][j]].ToUwpColor();

                    // ...flip rows bottom-to-top...
                    pos -= spectraCount;
                }
            }

            _spectrogram2D = CanvasBitmap.CreateFromColors(SpectrumView,
                                                           colors2D,
                                                           spectraCount,
                                                           spectrumSize);

            // ============ create 3D spectrogram bitmap ============

            const int width3D = 700;
            const int height3D = 700;
            const int size3D = width3D * height3D;

            var colors3D = Enumerable.Range(0, size3D)
                                     .Select(i => _cmap.Colors().First().ToUwpColor())
                                     .ToArray();

            for (var x = 0; x < spectraCount; x++)
            {
                for (var y = 0; y < spectrumSize; y++)
                {
                    var z = _spectrogram[x][y];
                    
                    while (z > 0)
                    {
                        var coords = RotateY(x, y, z, AngleY);
                        coords = RotateX(coords[0], coords[1], coords[2], AngleX);
                        coords = RotateZ(coords[0], coords[1], coords[2], AngleZ);
                        
                        if (coords[0] + CenterY < height3D && coords[1] + CenterX < width3D)
                        {
                            var pos = ((int)coords[0] + CenterY) * width3D + 
                                       (int)coords[1] + CenterX;

                            colors3D[pos] = _cmap[z].ToUwpColor();
                        }

                        z -= Stride;
                    }
                }
            }

            _spectrogram3D = CanvasBitmap.CreateFromColors(SpectrumView3D,
                                                           colors3D,
                                                           height3D,
                                                           width3D);
            // redraw panels:

            SpectrumView.Invalidate();
            SpectrumView3D.Invalidate();
        }

        public void CanvasControlDraw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            if (_signal == null)
            {
                return;
            }

            args.DrawingSession.DrawImage(_spectrogram2D, 10, 10);
        }

        public void CanvasControlDraw3D(CanvasControl sender, CanvasDrawEventArgs args)
        {
            if (_signal == null)
            {
                return;
            }

            args.DrawingSession.DrawImage(_spectrogram3D, 10, 10);
        }

        #endregion


        #region rotation functions

        private static double[] RotateX(double x, double y, double z, double theta)
        {
            var sinTheta = Math.Sin(Math.PI * theta / 180);
            var cosTheta = Math.Cos(Math.PI * theta / 180);

            var coord = new double[3];
            coord[0] = x;
            coord[1] = y * cosTheta - z * sinTheta;
            coord[2] = z * cosTheta + y * sinTheta;

            return coord;
        }

        private static double[] RotateY(double x, double y, double z, double theta)
        {
            var sinTheta = Math.Sin(Math.PI * theta / 180);
            var cosTheta = Math.Cos(Math.PI * theta / 180);

            var coord = new double[3];
            coord[0] = x * cosTheta - z * sinTheta;
            coord[1] = y;
            coord[2] = z * cosTheta + x * sinTheta;

            return coord;
        }

        private static double[] RotateZ(double x, double y, double z, double theta)
        {
            var sinTheta = Math.Sin(Math.PI * theta / 180);
            var cosTheta = Math.Cos(Math.PI * theta / 180);

            var coord = new double[3];
            coord[0] = x * cosTheta - y * sinTheta;
            coord[1] = y * cosTheta + x * sinTheta;
            coord[2] = z;

            return coord;
        }

        #endregion


        #region working with sound

        /// <summary>
        /// Load signal from a WAV file or any other media file selected by user:
        /// 
        ///  - if the file has 'wav' extension, then load sound signal using Signal.Load() method
        ///  - otherwise, transcode the file to temporary WAV file and then use Signal.Load() method
        /// 
        /// </summary>
        private async void LoadClick(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            picker.FileTypeFilter.Add(".wav");
            picker.FileTypeFilter.Add(".mp3");
            picker.FileTypeFilter.Add(".mp4");

            try
            {
                StorageFile file = await picker.PickSingleFileAsync();

                if (file == null)
                {
                    return;
                }

                _signal = await _audioService.LoadSignalAsync(file);

                CalculateSpectrogram();
                UpdateSpectrogramBitmaps();
            }
            catch (FormatException fex)
            {
                await new MessageDialog(fex.Message).ShowAsync();

                _signal = null;
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();

                _signal = null;
            }
        }

        private async void RecordClick(object sender, RoutedEventArgs e)
        {
            var recordButton = sender as AppBarButton;

            try
            {
                if (recordButton.Label.Equals("record"))
                {
                    await _audioService.StartRecording();

                    recordButton.Label = "stop";
                    recordButton.Icon = new SymbolIcon(Symbol.Stop);
                }
                else
                {
                    recordButton.Label = "record";
                    recordButton.Icon = new SymbolIcon(Symbol.Microphone);

                    await _audioService.StopRecording();

                    _signal = await _audioService.LoadRecordedSignalAsync();

                    CalculateSpectrogram();
                    UpdateSpectrogramBitmaps();
                }
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
            }
        }
        
        #endregion
    }
}
