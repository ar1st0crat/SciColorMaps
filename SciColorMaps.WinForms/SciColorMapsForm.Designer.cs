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
            this.SuspendLayout();
            // 
            // _colorMapPanel
            // 
            this._colorMapPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this._colorMapPanel.Location = new System.Drawing.Point(13, 156);
            this._colorMapPanel.Name = "_colorMapPanel";
            this._colorMapPanel.Size = new System.Drawing.Size(534, 179);
            this._colorMapPanel.TabIndex = 0;
            // 
            // _colorMapsList
            // 
            this._colorMapsList.FormattingEnabled = true;
            this._colorMapsList.Items.AddRange(new object[] {
            "Afmhot",
            "Inferno",
            "Terrain",
            "Viridis"});
            this._colorMapsList.Location = new System.Drawing.Point(13, 42);
            this._colorMapsList.Name = "_colorMapsList";
            this._colorMapsList.Size = new System.Drawing.Size(241, 24);
            this._colorMapsList.TabIndex = 1;
            // 
            // _labelColorMapsList
            // 
            this._labelColorMapsList.AutoSize = true;
            this._labelColorMapsList.Location = new System.Drawing.Point(13, 19);
            this._labelColorMapsList.Name = "_labelColorMapsList";
            this._labelColorMapsList.Size = new System.Drawing.Size(83, 17);
            this._labelColorMapsList.TabIndex = 2;
            this._labelColorMapsList.Text = "Color maps:";
            // 
            // _buttonShow
            // 
            this._buttonShow.Location = new System.Drawing.Point(13, 87);
            this._buttonShow.Name = "_buttonShow";
            this._buttonShow.Size = new System.Drawing.Size(534, 47);
            this._buttonShow.TabIndex = 3;
            this._buttonShow.Text = "Show";
            this._buttonShow.UseVisualStyleBackColor = true;
            this._buttonShow.Click += new System.EventHandler(this._buttonShow_Click);
            // 
            // SciColorMapsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 347);
            this.Controls.Add(this._buttonShow);
            this.Controls.Add(this._labelColorMapsList);
            this.Controls.Add(this._colorMapsList);
            this.Controls.Add(this._colorMapPanel);
            this.Name = "SciColorMapsForm";
            this.Text = "SciColorMaps demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _colorMapPanel;
        private System.Windows.Forms.ComboBox _colorMapsList;
        private System.Windows.Forms.Label _labelColorMapsList;
        private System.Windows.Forms.Button _buttonShow;
    }
}

