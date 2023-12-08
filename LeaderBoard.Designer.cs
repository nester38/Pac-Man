namespace Pac_Man
{
    partial class LeaderBoard
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
            this.PbBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // PbBackground
            // 
            this.PbBackground.Image = global::Pac_Man.Properties.Resources.background_pacman;
            this.PbBackground.Location = new System.Drawing.Point(93, 37);
            this.PbBackground.Name = "PbBackground";
            this.PbBackground.Size = new System.Drawing.Size(615, 539);
            this.PbBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbBackground.TabIndex = 9;
            this.PbBackground.TabStop = false;
            // 
            // LeaderBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 613);
            this.Controls.Add(this.PbBackground);
            this.Name = "LeaderBoard";
            this.Text = "LeaderBoard";
            ((System.ComponentModel.ISupportInitialize)(this.PbBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox PbBackground;
    }
}