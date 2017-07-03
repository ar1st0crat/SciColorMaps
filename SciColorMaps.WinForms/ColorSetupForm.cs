using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SciColorMaps.WinForms
{
    public partial class ColorSetupForm : Form
    {
        public List<Color> Colors { get; set; }
        public List<float> Positions { get; set; }

        private List<Panel> _panels = new List<Panel>();
        

        public ColorSetupForm()
        {
            InitializeComponent();
        }

        private void ColorSetupForm_Load(object sender, System.EventArgs e)
        {
            _color1.BackColor = Colors[0];
            _panels.Add(_color1);

            for (var i = 1; i < Colors.Count - 1; i++)
            {
                var panel = new Panel()
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Colors[i],
                    Width = _color1.Width,
                    Height = _color1.Height,
                    Left = (int)(Positions[i] * _colorPanel.Width + _colorPanel.Left),
                    Top = _color1.Top,
                    Tag = i
                };
                panel.MouseClick += _color_MouseClick;

                Controls.Add(panel);
                _panels.Add(panel);
            }

            _color2.BackColor = Colors.Last();
            _color2.Tag = Colors.Count - 1;
            _panels.Add(_color2);
        }

        private void _colorPanel_MouseClick(object sender, MouseEventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            var position = (float)e.X / _colorPanel.Width;
            
            var idx = ~Positions.BinarySearch(position);
            
            // wow, can it really happen?! ))
            if (idx < 0)
            {
                idx = ~idx;
            }

            Positions.Insert(idx, position);
            Colors.Insert(idx, colorDialog.Color);

            var panel = new Panel()
            {
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = colorDialog.Color,
                Left = e.X + _colorPanel.Left,
                Top = _color1.Top,
                Width = _color1.Width,
                Height = _color1.Height,
                Tag = 1
            };
            panel.MouseClick += _color_MouseClick;
            Controls.Add(panel);

            _panels.Insert(idx, panel);

            for (var i = 0; i < _panels.Count; i++)
            {
                _panels[i].Tag = i;
            }

            Invalidate();
        }

        private void ColorSetupForm_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush brush = new LinearGradientBrush(
                _colorPanel.ClientRectangle, Color.White, Color.White, 0, false);

            var blend = new ColorBlend();
            blend.Positions = Positions.ToArray();
            blend.Colors = Colors.ToArray();

            brush.InterpolationColors = blend;

            _colorPanel.CreateGraphics().FillRectangle(brush, _colorPanel.ClientRectangle);
        }

        private void _color_MouseClick(object sender, MouseEventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var panel = sender as Panel;
            Colors[(int)panel.Tag] = colorDialog.Color;
            panel.BackColor = colorDialog.Color;
            Invalidate();
        }

        private void _okButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
