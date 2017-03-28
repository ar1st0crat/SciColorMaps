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
            double z = x * x + y * y;
            double theta = Math.Atan2(y, x);
            return Math.Exp(-z) * Math.Sin(2 * Math.PI * Math.Sqrt(z)) * Math.Cos(3 * theta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private double HyperbolicParaboloid(double x, double y)
        {
            float a = 3, b = 4, p = 2;  

            return ((x * x) / (a * a) - (y * y) / (b * b)) / (2 * p);
        }

        private void CreateColorMap(Func<double, double, double> function)
        {
            float min = float.MaxValue;
            float max = float.MinValue;
            
            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 100; y++)
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
            var bmp = new Bitmap(100, 100);
            
            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    float z = (float)function(x, y);
                    bmp.SetPixel(x, y, _cmap.GetColor(z));
                }
            }

            _surfacePanel.BackgroundImage = bmp;
            
            var g = _surfacePanel.CreateGraphics();
        }

        private void _buttonShow_Click(object sender, EventArgs e)
        {
            CreateColorMap(HyperbolicParaboloid);
            ShowColormap();
            ShowSurface(HyperbolicParaboloid);
        }
    }
}
