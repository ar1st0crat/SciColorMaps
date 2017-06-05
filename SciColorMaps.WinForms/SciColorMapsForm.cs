using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SciColorMaps.WinForms
{
    public partial class SciColorMapsForm : Form
    {
        private int _colorCount = Palettes.Resolution;

        private ColorMap _cmap;

        public SciColorMapsForm()
        {
            InitializeComponent();
        }

        #region rotation functions

        private float[] RotateX(float x, float y, float z, float theta)
        {
            float sinTheta = (float)Math.Sin(Math.PI * theta / 180);
            float cosTheta = (float)Math.Cos(Math.PI * theta / 180);

            float[] coord = new float[3];
            coord[0] = x;
            coord[1] = y * cosTheta - z * sinTheta;
            coord[2] = z * cosTheta + y * sinTheta;

            return coord;
        }

        private float[] RotateY(float x, float y, float z, float theta)
        {
            float sinTheta = (float)Math.Sin(Math.PI * theta / 180);
            float cosTheta = (float)Math.Cos(Math.PI * theta / 180);

            float[] coord = new float[3];
            coord[0] = x * cosTheta - z * sinTheta;
            coord[1] = y;
            coord[2] = z * cosTheta + x * sinTheta;

            return coord;
        }

        private float[] RotateZ(float x, float y, float z, float theta)
        {
            float sinTheta = (float)Math.Sin(Math.PI * theta / 180);
            float cosTheta = (float)Math.Cos(Math.PI * theta / 180);

            float[] coord = new float[3];
            coord[0] = x * cosTheta - y * sinTheta;
            coord[1] = y * cosTheta + x * sinTheta;
            coord[2] = z;

            return coord;
        }

        #endregion

        private void CreateColorMap(Func<double, double, double> function)
        {
            float min = float.MaxValue;
            float max = float.MinValue;
            
            for (int x = -100; x < 100; x++)
            {
                for (int y = -70; y < 70; y++)
                {
                    float z = (float)function(x, y);

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

            _cmap = new ColorMap(_colorMapsList.Text, min, max, _colorCount);
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
            var bmp = new Bitmap(200, 140);
            
            for (int x = -100; x < 100; x++)
            {
                for (int y = -70; y < 70; y++)
                {
                    float z = (float)function(x, y);
                    bmp.SetPixel(x + 100, y + 70, _cmap.GetColor(z));
                }
            }

            _surfacePanel.BackgroundImage = bmp;
        }

        private void ShowSurface3D(Func<double, double, double> function)
        {
            var bmp3d = new Bitmap(300, 300);

            for (float i = -80; i < 80; i += 0.5f)
            {
                float[] coords = RotateY(i + 80, 0, 0, 45);
                coords = RotateX(coords[0], coords[1], coords[2], 45);
                coords = RotateZ(coords[0], coords[1], coords[2], 55);

                bmp3d.SetPixel((int)coords[0] + 150,
                               (int)coords[1] + 150,
                               Color.DarkGray);

                coords = RotateY(0, i + 80, 0, 45);
                coords = RotateX(coords[0], coords[1], coords[2], 45);
                coords = RotateZ(coords[0], coords[1], coords[2], 55);

                bmp3d.SetPixel((int)coords[0] + 150,
                               (int)coords[1] + 150,
                               Color.DarkGray);

                coords = RotateY(0, 0, i + 80, 45);
                coords = RotateX(coords[0], coords[1], coords[2], 45);
                coords = RotateZ(coords[0], coords[1], coords[2], 55);

                bmp3d.SetPixel((int)coords[0] + 150,
                               (int)coords[1] + 150,
                               Color.DarkGray);
            }

            for (float x = -100; x < 100; x += 0.25f)
            {
                for (float y = -70; y < 70; y += 0.25f)
                {
                    float z = (float)function(x, y);

                    float[] coords = RotateY(x, y, z, 45);
                    coords = RotateX(coords[0], coords[1], coords[2], 45);
                    coords = RotateZ(coords[0], coords[1], coords[2], 55);

                    bmp3d.SetPixel((int)coords[0] + 150,
                                   (int)coords[1] + 150,
                                   _cmap.GetColor(z));
                }
            }

            _surface3dPanel.BackgroundImage = bmp3d;
        }

        private void _buttonShow_Click(object sender, EventArgs e)
        {
            Func<double, double, double> surface;
            switch (_surfacesList.SelectedIndex)
            {
                case 0:
                    surface = Surface.HyperbolicParaboloid;
                    break;
                case 1:
                    surface = Surface.EllipticParaboloid;
                    break;
                case 2:
                default:
                    surface = Surface.FancySurface;
                    break;
            }

            _colorCount = (int)_colorCountUpDown.Value;

            CreateColorMap(surface);
            ShowColormap();
            ShowSurface2D(surface);
            ShowSurface3D(surface);
        }
    }
}
