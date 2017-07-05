using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using SciColorMaps.Portable;

namespace SciColorMaps.DemoWpf
{
    public static class ColorUtils
    {
        public static Color ToMediaColor(this byte[] rgb)
        {
            return Color.FromRgb(rgb[0], rgb[1], rgb[2]);
        }
    }

    class MainViewModel : INotifyPropertyChanged
    {
        private const int ColorCountDefault = 32;

        public static List<string> Palettes { get; } = ColorMap.Palettes.ToList();

        public LinearGradientBrush PaletteBrush1 { get; set; }
        public LinearGradientBrush PaletteBrush2 { get; set; }
        public LinearGradientBrush PaletteBrush3 { get; set; }

        private string _selectedPalette = Palettes.FirstOrDefault();
        public string SelectedPalette
        {
            get { return _selectedPalette; }
            set
            {
                _selectedPalette = value;
                UpdatePanels();
            }
        }
        

        public MainViewModel()
        {
            UpdatePanels();
        }

        private void UpdatePanels()
        {
            var colors = new[]
            {
                new byte[] {0, 0, 0},
                new byte[] {255, 255, 0},
                new byte[] {255, 0, 0},
                new byte[] {255, 255, 255}
            };
            var positions = new[] { 0, 0.3f, 0.7f, 1 };

            var cmap1 = ColorMap.CreateFromColors(colors, positions, colorCount: ColorCountDefault);
            var cmap2 = new ColorMap(SelectedPalette, colorCount: ColorCountDefault);
            var cmap3 = new MirrorColorMap(cmap2);

            PaletteBrush1 = CreatePaletteBrush(cmap1);
            PaletteBrush2 = CreatePaletteBrush(cmap2);
            PaletteBrush3 = CreatePaletteBrush(cmap3);

            OnPropertyChanged("PaletteBrush1");
            OnPropertyChanged("PaletteBrush2");
            OnPropertyChanged("PaletteBrush3");
        }

        private LinearGradientBrush CreatePaletteBrush(ColorMap cmap)
        {
            return new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 0),
                GradientStops = new GradientStopCollection(
                    cmap.Colors()
                         .Select((color, i) => new GradientStop()
                         {
                             Color = color.ToMediaColor(),
                             Offset = (float)i / ColorCountDefault
                         })
                         .ToList())
            };
        }

        #region INPC-related code

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
