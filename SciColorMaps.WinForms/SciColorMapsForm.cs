using System;
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
            
            for (int x = SurfaceRect.Left; x < SurfaceRect.Right; x++)
            {
                for (int y = SurfaceRect.Top; y < SurfaceRect.Bottom; y++)
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

            _cmap = new ColorMap(_colorMapsList.Text, min, max, _colorCount);

            // if you wanna play around with gayscale colormaps uncomment this:

            //_cmap = new GrayColorMap(new ColorMap(_colorMapsList.Text, min, max, _colorCount));
            //_cmap = new GrayColorMap(new ColorMap("gnuplot2", min, max));
        }

        private void ShowColormap()
        {
            LinearGradientBrush brush = new LinearGradientBrush(
                _colorMapPanel.ClientRectangle, Color.White, Color.White, 0, false);

            var blend = new ColorBlend();

            blend.Positions = Enumerable.Range(0, _colorCount + 1)
                                        .Select(pos => (float)pos / _colorCount)
                                        .ToArray();

            blend.Colors = Enumerable.Range(0, _colorCount + 1)
                                     .Select(i => _cmap.GetColorByNumber(i))
                                     .ToArray();

            brush.InterpolationColors = blend;

            _colorMapPanel.CreateGraphics()
                          .FillRectangle(brush, _colorMapPanel.ClientRectangle);
        }
        
        private void ShowSurface2D(Func<double, double, double> function)
        {
            var bmp = new Bitmap(SurfaceRect.Width, SurfaceRect.Height);

            for (int x = SurfaceRect.Left; x < SurfaceRect.Right; x++)
            {
                for (int y = SurfaceRect.Top; y < SurfaceRect.Bottom; y++)
                {
                    var z = function(x, y);
                    bmp.SetPixel(x - SurfaceRect.Left, y - SurfaceRect.Top, _cmap.GetColor(z));
                }
            }

            _surfacePanel.BackgroundImage = bmp;
        }

        private void ShowSurface3D(Func<double, double, double> function)
        {
            var bmp3d = new Bitmap(2 * CenterX, 2 * CenterY);

            // draw axis

            var axisRangeBegin = -80;
            var axisRangeEnd = 80;

            for (double i = axisRangeBegin; i < axisRangeEnd; i += Stride)
            {
                var coords = RotateY(i - axisRangeBegin, 0, 0, AngleY);
                coords = RotateX(coords[0], coords[1], coords[2], AngleX);
                coords = RotateZ(coords[0], coords[1], coords[2], AngleZ);

                bmp3d.SetPixel((int)coords[0] + CenterX,
                               (int)coords[1] + CenterY,
                               Color.DarkGray);

                coords = RotateY(0, i - axisRangeBegin, 0, AngleY);
                coords = RotateX(coords[0], coords[1], coords[2], AngleX);
                coords = RotateZ(coords[0], coords[1], coords[2], AngleZ);

                bmp3d.SetPixel((int)coords[0] + CenterX,
                               (int)coords[1] + CenterY,
                               Color.DarkGray);

                coords = RotateY(0, 0, i - axisRangeBegin, AngleY);
                coords = RotateX(coords[0], coords[1], coords[2], AngleX);
                coords = RotateZ(coords[0], coords[1], coords[2], AngleZ);

                bmp3d.SetPixel((int)coords[0] + CenterX,
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

                    bmp3d.SetPixel((int)coords[0] + CenterX,
                                   (int)coords[1] + CenterY,
                                   _cmap.GetColor(z));
                }
            }

            _surface3dPanel.BackgroundImage = bmp3d;
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

            if (e.Button == MouseButtons.Left)
            {
                CreateColorMap(surface);

                _cmap = new MirrorColorMap(_cmap);      // decoratin'

                UpdatePanels(surface);
            }
            else if (e.Button == MouseButtons.Right)
            {
                CreateColorMap(surface);

                _cmap = new GrayColorMap(_cmap);        // decoratin'

                UpdatePanels(surface);
            }
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
                case 2:
                default:
                    return Surface.FancySurface;
            }
        }
    }
}
