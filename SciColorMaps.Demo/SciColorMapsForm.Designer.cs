using System.Linq;

namespace SciColorMaps.WinForms
{
    partial class SciColorMapsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._colorMapPanel = new System.Windows.Forms.Panel();
            this._colorMapsList = new System.Windows.Forms.ComboBox();
            this._labelColorMapsList = new System.Windows.Forms.Label();
            this._buttonShow = new System.Windows.Forms.Button();
            this._surfacesList = new System.Windows.Forms.ComboBox();
            this._surfacePanel = new System.Windows.Forms.Panel();
            this._labelSurfacesList = new System.Windows.Forms.Label();
            this._surface3dPanel = new System.Windows.Forms.Panel();
            this._colorCountUpDown = new System.Windows.Forms.NumericUpDown();
            this._labelColorCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._colorCountUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // _colorMapPanel
            // 
            this._colorMapPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this._colorMapPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._colorMapPanel.Location = new System.Drawing.Point(13, 156);
            this._colorMapPanel.Name = "_colorMapPanel";
            this._colorMapPanel.Size = new System.Drawing.Size(434, 27);
            this._colorMapPanel.TabIndex = 0;
            this._colorMapPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this._colorMapPanel_MouseClick);
            // 
            // _colorMapsList
            // 
            this._colorMapsList.FormattingEnabled = true;
            this._colorMapsList.Items.Add("user");
            this._colorMapsList.Items.AddRange(ColorMap.Palettes.ToArray());
            this._colorMapsList.Location = new System.Drawing.Point(13, 42);
            this._colorMapsList.Name = "_colorMapsList";
            this._colorMapsList.Size = new System.Drawing.Size(150, 24);
            this._colorMapsList.Sorted = false;
            this._colorMapsList.TabIndex = 1;
            this._colorMapsList.Text = ColorMap.Palettes.FirstOrDefault();
            // 
            // _labelColorMapsList
            // 
            this._labelColorMapsList.AutoSize = true;
            this._labelColorMapsList.Location = new System.Drawing.Point(13, 19);
            this._labelColorMapsList.Name = "_labelColorMapsList";
            this._labelColorMapsList.Size = new System.Drawing.Size(76, 17);
            this._labelColorMapsList.TabIndex = 2;
            this._labelColorMapsList.Text = "Color map:";
            // 
            // _buttonShow
            // 
            this._buttonShow.Location = new System.Drawing.Point(13, 87);
            this._buttonShow.Name = "_buttonShow";
            this._buttonShow.Size = new System.Drawing.Size(434, 47);
            this._buttonShow.TabIndex = 3;
            this._buttonShow.Text = "Show";
            this._buttonShow.UseVisualStyleBackColor = true;
            this._buttonShow.Click += new System.EventHandler(this._buttonShow_Click);
            // 
            // _surfacesList
            // 
            this._surfacesList.FormattingEnabled = true;
            this._surfacesList.Items.AddRange(new object[] {
            "Hyperbolic paraboloid",
            "Elliptic paraboloid",
            "Fancy surface"});
            this._surfacesList.Location = new System.Drawing.Point(249, 42);
            this._surfacesList.Name = "_surfacesList";
            this._surfacesList.Size = new System.Drawing.Size(198, 24);
            this._surfacesList.TabIndex = 4;
            this._surfacesList.Text = "Hyperbolic paraboloid";
            // 
            // _surfacePanel
            // 
            this._surfacePanel.BackColor = System.Drawing.Color.White;
            this._surfacePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._surfacePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._surfacePanel.Location = new System.Drawing.Point(13, 201);
            this._surfacePanel.Name = "_surfacePanel";
            this._surfacePanel.Size = new System.Drawing.Size(434, 267);
            this._surfacePanel.TabIndex = 1;
            this._surfacePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this._surfacePanel_MouseClick);
            // 
            // _labelSurfacesList
            // 
            this._labelSurfacesList.AutoSize = true;
            this._labelSurfacesList.Location = new System.Drawing.Point(246, 19);
            this._labelSurfacesList.Name = "_labelSurfacesList";
            this._labelSurfacesList.Size = new System.Drawing.Size(61, 17);
            this._labelSurfacesList.TabIndex = 5;
            this._labelSurfacesList.Text = "Surface:";
            // 
            // _surface3dPanel
            // 
            this._surface3dPanel.BackColor = System.Drawing.Color.White;
            this._surface3dPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._surface3dPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._surface3dPanel.Location = new System.Drawing.Point(464, 42);
            this._surface3dPanel.Name = "_surface3dPanel";
            this._surface3dPanel.Size = new System.Drawing.Size(415, 426);
            this._surface3dPanel.TabIndex = 2;
            // 
            // _colorCountUpDown
            // 
            this._colorCountUpDown.Location = new System.Drawing.Point(170, 43);
            this._colorCountUpDown.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this._colorCountUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this._colorCountUpDown.Name = "_colorCountUpDown";
            this._colorCountUpDown.Size = new System.Drawing.Size(73, 22);
            this._colorCountUpDown.TabIndex = 6;
            this._colorCountUpDown.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // _labelColorCount
            // 
            this._labelColorCount.AutoSize = true;
            this._labelColorCount.Location = new System.Drawing.Point(167, 19);
            this._labelColorCount.Name = "_labelColorCount";
            this._labelColorCount.Size = new System.Drawing.Size(52, 17);
            this._labelColorCount.TabIndex = 7;
            this._labelColorCount.Text = "Colors:";
            // 
            // SciColorMapsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 480);
            this.Controls.Add(this._labelColorCount);
            this.Controls.Add(this._colorCountUpDown);
            this.Controls.Add(this._surface3dPanel);
            this.Controls.Add(this._labelSurfacesList);
            this.Controls.Add(this._surfacePanel);
            this.Controls.Add(this._surfacesList);
            this.Controls.Add(this._buttonShow);
            this.Controls.Add(this._labelColorMapsList);
            this.Controls.Add(this._colorMapsList);
            this.Controls.Add(this._colorMapPanel);
            this.Name = "SciColorMapsForm";
            this.Text = "SciColorMaps demo";
            ((System.ComponentModel.ISupportInitialize)(this._colorCountUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _colorMapPanel;
        private System.Windows.Forms.ComboBox _colorMapsList;
        private System.Windows.Forms.Label _labelColorMapsList;
        private System.Windows.Forms.Button _buttonShow;
        private System.Windows.Forms.ComboBox _surfacesList;
        private System.Windows.Forms.Panel _surfacePanel;
        private System.Windows.Forms.Label _labelSurfacesList;
        private System.Windows.Forms.Panel _surface3dPanel;
        private System.Windows.Forms.NumericUpDown _colorCountUpDown;
        private System.Windows.Forms.Label _labelColorCount;
    }
}

