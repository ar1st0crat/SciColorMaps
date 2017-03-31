using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SciColorMaps.WinForms
{
    public partial class SciColorMapsForm : Form
    {
        private const int ColorCount = 256;

        private ColorMap _cmap;

        public SciColorMapsForm()
        {
            InitializeComponent();
        }

        private double FancySurface(double x, double y)
        {
            x /= 60;
            y /= 90;

            double z = x * x + y * y;
            return 70 * Math.Exp(-z) * Math.Sin(2 * Math.PI * x * y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private double HyperbolicParaboloid(double x, double y)
        {
            float a = 6, b = 5, p = 2;

            return ((x * x) / (a * a) - (y * y) / (b * b)) / (2 * p);
        }

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

            _cmap = new ColorMap(_colorMapsList.Text, min, max, ColorCount);
        }

        private void ShowColormap()
        {
            LinearGradientBrush brush = new LinearGradientBrush(
                _colorMapPanel.ClientRectangle, Color.White, Color.White, 0, false);

            var blend = new ColorBlend();
            //
            blend.Positions = Enumerable.Range(0, ColorCount + 1)
                                        .Select(pos => (float)pos / ColorCount)
                                        .ToArray();
            //
            blend.Colors = Enumerable.Range(0, ColorCount + 1)
                                     .Select(i => _cmap.GetColorByNumber(i))
                                     .ToArray();
            //
            brush.InterpolationColors = blend;

            _colorMapPanel.CreateGraphics()
                          .FillRectangle(brush, _colorMapPanel.ClientRectangle);
        }
        
        private void ShowSurface(Func<double, double, double> function)
        {
            var bmp = new Bitmap(200, 140);
            
            for (int x = -100; x < 100; x++)
            {
                for (int y = -70; y < 70; y++)
                {
                    float z = (float)function(x, y);
                    bmp.SetPixel(x+100, y+70, _cmap.GetColor(z));
                }
            }

            _surfacePanel.BackgroundImage = bmp;
        }

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
            Func<double, double, double> surface = FancySurface;

            CreateColorMap(surface);
            ShowColormap();

            ShowSurface(surface);
            ShowSurface3D(surface);
        }
    }
}
