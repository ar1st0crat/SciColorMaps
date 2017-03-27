using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SciColorMaps.WinForms
{
    public partial class SciColorMapsForm : Form
    {
        public SciColorMapsForm()
        {
            InitializeComponent();
        }

        private void _buttonShow_Click(object sender, EventArgs e)
        {
            int colorCount = 256;

            var cmap = new ColorMap(_colorMapsList.Text, 0, colorCount+1);

            LinearGradientBrush brush = new LinearGradientBrush(
                _colorMapPanel.ClientRectangle, Color.White, Color.White, 0, false);
            
            var blend = new ColorBlend();
            //
            blend.Positions = Enumerable.Range(0, colorCount + 1)
                                        .Select(p => (float)p / colorCount)
                                        .ToArray();
            //
            blend.Colors = Enumerable.Range(0, colorCount + 1)
                                     .Select(i => cmap.GetColor(i))
                                     .ToArray();
            //
            brush.InterpolationColors = blend;

            _colorMapPanel.CreateGraphics()
                          .FillRectangle(brush, _colorMapPanel.ClientRectangle);
        }
    }
}
