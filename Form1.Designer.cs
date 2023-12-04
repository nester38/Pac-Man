namespace Pac_Man
{
    partial class Loading
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            lblStatus = new Label();
            progressBar1 = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Pac_Man_1980_29;
            pictureBox2.Location = new Point(137, 134);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(406, 84);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.pac_man_loading_1;
            pictureBox1.Location = new Point(263, 212);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(201, 155);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.Black;
            lblStatus.Location = new Point(293, 389);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(91, 15);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Loading...0%";
            // 
            // progressBar1
            // 
            progressBar1.BackColor = Color.IndianRed;
            progressBar1.ForeColor = Color.IndianRed;
            progressBar1.Location = new Point(247, 418);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(179, 16);
            progressBar1.TabIndex = 5;
            // 
            // Loading
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Khaki;
            ClientSize = new Size(693, 587);
            Controls.Add(progressBar1);
            Controls.Add(lblStatus);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            MaximizeBox = false;
            MaximumSize = new Size(709, 626);
            MinimizeBox = false;
            MinimumSize = new Size(709, 626);
            Name = "Loading";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loading Game";
            Load += Loading_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label lblStatus;
        private ProgressBar progressBar1;
    }
}