namespace Pac_Man
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            pictureBox2 = new PictureBox();
            btnGameInstructions = new Button();
            btnLeaderBoard = new Button();
            btnPlay = new Button();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            lblHighScore = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.ErrorImage = (Image)resources.GetObject("pictureBox2.ErrorImage");
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(137, 134);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(406, 84);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // btnGameInstructions
            // 
            btnGameInstructions.BackColor = Color.Black;
            btnGameInstructions.FlatStyle = FlatStyle.Flat;
            btnGameInstructions.Font = new Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnGameInstructions.ForeColor = Color.White;
            btnGameInstructions.Location = new Point(269, 377);
            btnGameInstructions.Name = "btnGameInstructions";
            btnGameInstructions.Size = new Size(130, 30);
            btnGameInstructions.TabIndex = 8;
            btnGameInstructions.Text = "instructions";
            btnGameInstructions.UseVisualStyleBackColor = false;
            btnGameInstructions.Click += btnGameInstructions_Click;
            // 
            // btnLeaderBoard
            // 
            btnLeaderBoard.BackColor = Color.Black;
            btnLeaderBoard.FlatStyle = FlatStyle.Flat;
            btnLeaderBoard.Font = new Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnLeaderBoard.ForeColor = Color.White;
            btnLeaderBoard.Location = new Point(269, 329);
            btnLeaderBoard.Name = "btnLeaderBoard";
            btnLeaderBoard.Size = new Size(130, 30);
            btnLeaderBoard.TabIndex = 7;
            btnLeaderBoard.Text = "leader board";
            btnLeaderBoard.UseVisualStyleBackColor = false;
            btnLeaderBoard.Click += btnLeaderBoard_Click;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.Black;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Font = new Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnPlay.ForeColor = Color.White;
            btnPlay.Location = new Point(269, 282);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(130, 30);
            btnPlay.TabIndex = 6;
            btnPlay.Text = "play ";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.img_pacman_02;
            pictureBox3.Location = new Point(518, 455);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(143, 141);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-37, 473);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(284, 135);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // lblHighScore
            // 
            lblHighScore.AutoSize = true;
            lblHighScore.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblHighScore.ForeColor = Color.White;
            lblHighScore.Location = new Point(24, 21);
            lblHighScore.Name = "lblHighScore";
            lblHighScore.Size = new Size(126, 19);
            lblHighScore.TabIndex = 11;
            lblHighScore.Text = "High score: 0";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(693, 629);
            Controls.Add(lblHighScore);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
            Controls.Add(btnGameInstructions);
            Controls.Add(btnLeaderBoard);
            Controls.Add(btnPlay);
            Controls.Add(pictureBox2);
            MaximumSize = new Size(709, 668);
            MinimumSize = new Size(709, 668);
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainMenu";
            Load += MainMenu_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private Button btnGameInstructions;
        private Button btnLeaderBoard;
        private Button btnPlay;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private Label lblHighScore;
    }
}