namespace Pac_Man
{
    partial class NewHighScore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewHighScore));
            lbl = new Label();
            pictureBox4 = new PictureBox();
            label2 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl.ForeColor = Color.White;
            lbl.Location = new Point(318, 202);
            lbl.Name = "lbl";
            lbl.Size = new Size(58, 24);
            lbl.TabIndex = 23;
            lbl.Text = "0000";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.cherry;
            pictureBox4.Location = new Point(309, 269);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(78, 59);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 22;
            pictureBox4.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(196, 343);
            label2.Name = "label2";
            label2.Size = new Size(315, 15);
            label2.TabIndex = 21;
            label2.Text = "enter your name to save to the leaderboard  ";
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.Yellow;
            button1.FlatAppearance.BorderSize = 0;
            button1.Location = new Point(312, 400);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 20;
            button1.Text = "submit";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(276, 371);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 16);
            textBox1.TabIndex = 19;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.img_pacman_021;
            pictureBox3.Location = new Point(521, 431);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(143, 141);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 18;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(29, 466);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(147, 106);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(248, 169);
            label1.Name = "label1";
            label1.Size = new Size(190, 24);
            label1.TabIndex = 16;
            label1.Text = "NEW HIGH SCORE!";
            // 
            // pictureBox2
            // 
            pictureBox2.ErrorImage = (Image)resources.GetObject("pictureBox2.ErrorImage");
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(146, 63);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(406, 84);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            // 
            // NewHighScore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(693, 629);
            Controls.Add(lbl);
            Controls.Add(pictureBox4);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Name = "NewHighScore";
            Text = "NewHighScore";
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl;
        private PictureBox pictureBox4;
        private Label label2;
        private Button button1;
        private TextBox textBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
    }
}