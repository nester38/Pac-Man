namespace Pac_Man
{
    partial class GameBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBoard));
            PbBackgroundMaze = new PictureBox();
            PbPinky = new PictureBox();
            PbBlinky = new PictureBox();
            PbCylde = new PictureBox();
            PbInky = new PictureBox();
            PbPacManLeft = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PbBackgroundMaze).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbPinky).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbBlinky).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbCylde).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbInky).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbPacManLeft).BeginInit();
            SuspendLayout();
            // 
            // PbBackgroundMaze
            // 
            PbBackgroundMaze.Image = Properties.Resources.background_pacman;
            PbBackgroundMaze.Location = new Point(55, 39);
            PbBackgroundMaze.Name = "PbBackgroundMaze";
            PbBackgroundMaze.Size = new Size(564, 536);
            PbBackgroundMaze.SizeMode = PictureBoxSizeMode.Zoom;
            PbBackgroundMaze.TabIndex = 0;
            PbBackgroundMaze.TabStop = false;
            // 
            // PbPinky
            // 
            PbPinky.Image = (Image)resources.GetObject("PbPinky.Image");
            PbPinky.Location = new Point(323, 275);
            PbPinky.Name = "PbPinky";
            PbPinky.Size = new Size(29, 32);
            PbPinky.SizeMode = PictureBoxSizeMode.Zoom;
            PbPinky.TabIndex = 3;
            PbPinky.TabStop = false;
            // 
            // PbBlinky
            // 
            PbBlinky.Image = Properties.Resources.enemy_3;
            PbBlinky.Location = new Point(288, 276);
            PbBlinky.Name = "PbBlinky";
            PbBlinky.Size = new Size(29, 32);
            PbBlinky.SizeMode = PictureBoxSizeMode.Zoom;
            PbBlinky.TabIndex = 4;
            PbBlinky.TabStop = false;
            // 
            // PbCylde
            // 
            PbCylde.Image = (Image)resources.GetObject("PbCylde.Image");
            PbCylde.Location = new Point(358, 275);
            PbCylde.Name = "PbCylde";
            PbCylde.Size = new Size(29, 32);
            PbCylde.SizeMode = PictureBoxSizeMode.Zoom;
            PbCylde.TabIndex = 5;
            PbCylde.TabStop = false;
            // 
            // PbInky
            // 
            PbInky.Image = (Image)resources.GetObject("PbInky.Image");
            PbInky.Location = new Point(297, 113);
            PbInky.Name = "PbInky";
            PbInky.Size = new Size(29, 32);
            PbInky.SizeMode = PictureBoxSizeMode.Zoom;
            PbInky.TabIndex = 6;
            PbInky.TabStop = false;
            // 
            // PbPacManLeft
            // 
            PbPacManLeft.Image = (Image)resources.GetObject("PbPacManLeft.Image");
            PbPacManLeft.Location = new Point(323, 428);
            PbPacManLeft.Name = "PbPacManLeft";
            PbPacManLeft.Size = new Size(29, 32);
            PbPacManLeft.SizeMode = PictureBoxSizeMode.Zoom;
            PbPacManLeft.TabIndex = 7;
            PbPacManLeft.TabStop = false;
            // 
            // GameBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(693, 587);
            Controls.Add(PbPacManLeft);
            Controls.Add(PbInky);
            Controls.Add(PbCylde);
            Controls.Add(PbBlinky);
            Controls.Add(PbPinky);
            Controls.Add(PbBackgroundMaze);
            MaximumSize = new Size(709, 626);
            MinimumSize = new Size(709, 626);
            Name = "GameBoard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            Load += GameBoard_Load;
            ((System.ComponentModel.ISupportInitialize)PbBackgroundMaze).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbPinky).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbBlinky).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbCylde).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbInky).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbPacManLeft).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PbBackgroundMaze;
        private PictureBox PbPinky;
        private PictureBox PbBlinky;
        private PictureBox PbCylde;
        private PictureBox PbInky;
        private PictureBox PbPacManLeft;
    }
}