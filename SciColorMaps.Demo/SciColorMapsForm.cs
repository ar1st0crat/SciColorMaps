using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SciColorMaps.WinForms
{
    public partial class SciColorMapsForm : Form
    {
        private int _colorCount = ColorMap.PaletteColors;

        private ColorMap _cmap;

        /// <summary>
        /// Data for user-defined colormaps
        /// </summary>
        private List<Color> _colors = new List<Color>();
        private List<float> _positions = new List<float>();

        private static readonly Rectangle SurfaceRect = new Rectangle(-100, -70, 200, 140);

        private const int AngleX = 45;//deg
        private const int AngleY = 45;//deg
        private const int AngleZ = 55;//deg

        /// <summary>
        /// Interpolation stride used for plotting 3d surface
        /// </summary>
        private const double Stride = 0.25;

        /// <summary>
        /// Relative coordinates of the center (3d plot)
        /// </summary>
        private const int CenterX = 150;
        private const int CenterY = 150;


        public SciColorMapsForm()
        {
            InitializeComponent();

            _colors.Add(Color.Black);
            _colors.Add(Color.White);
            _positions.Add(0.0f);
            _positions.Add(1.0f);
        }

        #region rotation functions

        private double[] RotateX(double x, double y, double z, double theta)
        {
            var sinTheta = Math.Sin(Math.PI * theta / 180);
            var cosTheta = Math.Cos(Math.PI * theta / 180);

            var coord = new double[3];
            coord[0] = x;
            coord[1] = y * cosTheta - z * sinTheta;
            coord[2] = z * cosTheta + y * sinTheta;

            return coord;
        }

        private double[] RotateY(double x, double y, double z, double theta)
        {
            var sinTheta = Math.Sin(Math.PI * theta / 180);
            var cosTheta = Math.Cos(Math.PI * theta / 180);

            var coord = new double[3];
            coord[0] = x * cosTheta - z * sinTheta;
            coord[1] = y;
            coord[2] = z * cosTheta + x * sinTheta;

            return coord;
        }

        private double[] RotateZ(double x, double y, double z, double theta)
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

        private void CreateColorMap(Func<double, double, double> function)
        {
            var min = double.MaxValue;
            var max = double.MinValue;
            
            for (var x = SurfaceRect.Left; x < SurfaceRect.Right; x++)
            {
                for (var y = SurfaceRect.Top; y < SurfaceRect.Bottom; y++)
                {
                    var z = function(x, y);

                    if (z > max)
                    {
                        max = z;
                    }
                    if (z < min)
                    {
                        min = z;
                    }
                }
            }

            _colorCount = (int)_colorCountUpDown.Value;

            if (_colorMapsList.Text == "user")
            {
                _cmap = ColorMap.CreateFromColors(_colors, _positions, min, max, _colorCount);
            }
            else
            {
                _cmap = new ColorMap(_colorMapsList.Text, min, max, _colorCount);
            }
        }

        private void ShowColormap()
        {
            var brush = new LinearGradientBrush(
                _colorMapPanel.ClientRectangle, Color.White, Color.White, 0, false);

            var blend = new ColorBlend
            {
                Colors = _cmap.Colors().ToArray(),
                Positions = Enumerable.Range(0, _colorCount)
                                      .Select(pos => (float)pos / (_colorCount - 1))
                                      .ToArray()
            };

            brush.InterpolationColors = blend;

            _colorMapPanel.CreateGraphics()
                          .FillRectangle(brush, _colorMapPanel.ClientRectangle);
        }
        
        private void ShowSurface2D(Func<double, double, double> function)
        {
            var bmp = new Bitmap(SurfaceRect.Width, SurfaceRect.Height);

            for (var x = SurfaceRect.Left; x < SurfaceRect.Right; x++)
            {
                for (var y = SurfaceRect.Top; y < SurfaceRect.Bottom; y++)
                {
                    var z = function(x, y);
                    bmp.SetPixel(x - SurfaceRect.Left, y - SurfaceRect.Top, _cmap.GetColor(z));
                }
            }

            _surfacePanel.BackgroundImage = bmp;
        }

        private void ShowSurface3D(Func<double, double, double> function)
        {
            var bmp3D = new Bitmap(2 * CenterX, 2 * CenterY);

            // draw axis

            const int axisRangeBegin = -80;
            const int axisRangeEnd = 80;

            for (double i = axisRangeBegin; i < axisRangeEnd; i += Stride)
            {
                var coords = RotateY(i - axisRangeBegin, 0, 0, AngleY);
                coords = RotateX(coords[0], coords[1], coords[2], AngleX);
                coords = RotateZ(coords[0], coords[1], coords[2], AngleZ);

                bmp3D.SetPixel((int)coords[0] + CenterX,
                               (int)coords[1] + CenterY,
                               Color.DarkGray);

                coords = RotateY(0, i - axisRangeBegin, 0, AngleY);
                coords = RotateX(coords[0], coords[1], coords[2], AngleX);
                coords = RotateZ(coords[0], coords[1], coords[2], AngleZ);

                bmp3D.SetPixel((int)coords[0] + CenterX,
                               (int)coords[1] + CenterY,
                               Color.DarkGray);

                coords = RotateY(0, 0, i - axisRangeBegin, AngleY);
                coords = RotateX(coords[0], coords[1], coords[2], AngleX);
                coords = RotateZ(coords[0], coords[1], coords[2], AngleZ);

                bmp3D.SetPixel((int)coords[0] + CenterX,
                               (int)coords[1] + CenterY,
                               Color.DarkGray);
            }

            // draw surface

            for (double x = SurfaceRect.Left; x < SurfaceRect.Right; x += Stride)
            {
                for (double y = SurfaceRect.Top; y < SurfaceRect.Bottom; y += Stride)
                {
                    var z = function(x, y);

                    var coords = RotateY(x, y, z, AngleY);
                    coords = RotateX(coords[0], coords[1], coords[2], AngleX);
                    coords = RotateZ(coords[0], coords[1], coords[2], AngleZ);

                    bmp3D.SetPixel((int)coords[0] + CenterX,
                                   (int)coords[1] + CenterY,
                                   _cmap.GetColor(z));
                }
            }

            _surface3dPanel.BackgroundImage = bmp3D;
        }

        private void _buttonShow_Click(object sender, EventArgs e)
        {
            var surface = GetSurface();
            CreateColorMap(surface);
            UpdatePanels(surface);
        }

        /// <summary>
        /// 
        /// Left button click: color map changes to mirrored 
        /// 
        /// Right button click: color map becomes grayscale
        /// 
        /// </summary>
        private void _surfacePanel_MouseClick(object sender, MouseEventArgs e)
        {
            var surface = GetSurface();

            switch (e.Button)
            {
                case MouseButtons.Left:
                    _cmap = new MirrorColorMap(_cmap);      // decoratin'
                    UpdatePanels(surface);
                    break;
                case MouseButtons.Right:
                    _cmap = new GrayColorMap(_cmap);        // decoratin'
                    UpdatePanels(surface);
                    break;
            }
        }

        private void _colorMapPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (_colorMapsList.Text != "user")
            {
                MessageBox.Show("Please choose the 'user' colormap in combobox");
                return;
            }

            var colorSetupForm = new ColorSetupForm
            {
                Colors = _colors,
                Positions = _positions
            };
            
            if (colorSetupForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            _colors = colorSetupForm.Colors;
            _positions = colorSetupForm.Positions;

            var surface = GetSurface();
            CreateColorMap(surface);
            UpdatePanels(surface);
        }

        private void UpdatePanels(Func<double, double, double> surface)
        {
            ShowColormap();
            ShowSurface2D(surface);
            ShowSurface3D(surface);
        }

        private Func<double, double, double> GetSurface()
        {
            switch (_surfacesList.SelectedIndex)
            {
                case 0:
                    return Surface.HyperbolicParaboloid;
                case 1:
                    return Surface.EllipticParaboloid;
                default:
                    return Surface.FancySurface;
            }
        }
    }
}
