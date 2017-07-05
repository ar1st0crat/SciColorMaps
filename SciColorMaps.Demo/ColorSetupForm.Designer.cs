namespace SciColorMaps.WinForms
{
    partial class ColorSetupForm
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
            this._colorPanel = new System.Windows.Forms.Panel();
            this._color1 = new System.Windows.Forms.Panel();
            this._color2 = new System.Windows.Forms.Panel();
            this._okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _colorPanel
            // 
            this._colorPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._colorPanel.Location = new System.Drawing.Point(37, 22);
            this._colorPanel.Name = "_colorPanel";
            this._colorPanel.Size = new System.Drawing.Size(699, 99);
            this._colorPanel.TabIndex = 0;
            this._colorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this._colorPanel_MouseClick);
            // 
            // _color1
            // 
            this._color1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._color1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._color1.Location = new System.Drawing.Point(37, 127);
            this._color1.Name = "_color1";
            this._color1.Size = new System.Drawing.Size(37, 40);
            this._color1.TabIndex = 1;
            this._color1.Tag = 0;
            this._color1.MouseClick += new System.Windows.Forms.MouseEventHandler(this._color_MouseClick);
            // 
            // _color2
            // 
            this._color2.BackColor = System.Drawing.Color.White;
            this._color2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._color2.Location = new System.Drawing.Point(698, 127);
            this._color2.Name = "_color2";
            this._color2.Size = new System.Drawing.Size(38, 40);
            this._color2.TabIndex = 2;
            this._color2.Tag = 1;
            this._color2.MouseClick += new System.Windows.Forms.MouseEventHandler(this._color_MouseClick);
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(324, 184);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(126, 53);
            this._okButton.TabIndex = 3;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // ColorSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 249);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._color2);
            this.Controls.Add(this._color1);
            this.Controls.Add(this._colorPanel);
            this.Name = "ColorSetupForm";
            this.Text = "ColorSetupForm";
            this.Load += new System.EventHandler(this.ColorSetupForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ColorSetupForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _colorPanel;
        private System.Windows.Forms.Panel _color1;
        private System.Windows.Forms.Panel _color2;
        private System.Windows.Forms.Button _okButton;
    }
}