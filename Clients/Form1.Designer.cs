namespace Clients
{
    partial class Form1
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
            this.gameTimer = new System.Timers.Timer();
            this.Score = new System.Windows.Forms.Label();
            this.man = new System.Windows.Forms.PictureBox();
            this.BgMap = new System.Windows.Forms.PictureBox();
            this.man2 = new System.Windows.Forms.PictureBox();
            this.Chefrang_1 = new System.Windows.Forms.PictureBox();
            this.Chefrang_2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.man)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BgMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.man2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chefrang_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chefrang_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20D;
            this.gameTimer.SynchronizingObject = this;
            this.gameTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.mainGameTimer);
            // 
            // Score
            // 
            this.Score.Location = new System.Drawing.Point(21, 15);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(87, 43);
            this.Score.TabIndex = 0;
            this.Score.Text = "label1";
            // 
            // man
            // 
            this.man.BackColor = System.Drawing.SystemColors.ControlDark;
            this.man.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.man.Location = new System.Drawing.Point(117, 142);
            this.man.Name = "man";
            this.man.Size = new System.Drawing.Size(41, 46);
            this.man.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.man.TabIndex = 1;
            this.man.TabStop = false;
            // 
            // BgMap
            // 
            this.BgMap.BackgroundImage = global::Clients.Properties.Resources.plan3;
            this.BgMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BgMap.Location = new System.Drawing.Point(0, 0);
            this.BgMap.Name = "BgMap";
            this.BgMap.Size = new System.Drawing.Size(970, 695);
            this.BgMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BgMap.TabIndex = 2;
            this.BgMap.TabStop = false;
            // 
            // man2
            // 
            this.man2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.man2.BackgroundImage = global::Clients.Properties.Resources.down1;
            this.man2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.man2.Image = global::Clients.Properties.Resources.down1;
            this.man2.Location = new System.Drawing.Point(59, 142);
            this.man2.Name = "man2";
            this.man2.Size = new System.Drawing.Size(27, 27);
            this.man2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.man2.TabIndex = 3;
            this.man2.TabStop = false;
            // 
            // Chefrang_1
            // 
            this.Chefrang_1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Chefrang_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Chefrang_1.Location = new System.Drawing.Point(60, 451);
            this.Chefrang_1.Name = "Chefrang_1";
            this.Chefrang_1.Size = new System.Drawing.Size(26, 26);
            this.Chefrang_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Chefrang_1.TabIndex = 4;
            this.Chefrang_1.TabStop = false;
            // 
            // Chefrang_2
            // 
            this.Chefrang_2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Chefrang_2.BackgroundImage = global::Clients.Properties.Resources.droit1;
            this.Chefrang_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Chefrang_2.Image = global::Clients.Properties.Resources.droit1;
            this.Chefrang_2.Location = new System.Drawing.Point(760, 579);
            this.Chefrang_2.Name = "Chefrang_2";
            this.Chefrang_2.Size = new System.Drawing.Size(26, 26);
            this.Chefrang_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Chefrang_2.TabIndex = 5;
            this.Chefrang_2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Clients.Properties.Resources.droit1;
            this.pictureBox1.Location = new System.Drawing.Point(812, 622);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(536, 591);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(970, 692);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Chefrang_2);
            this.Controls.Add(this.Chefrang_1);
            this.Controls.Add(this.man2);
            this.Controls.Add(this.BgMap);
            this.Controls.Add(this.man);
            this.Controls.Add(this.Score);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.gameTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.man)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BgMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.man2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chefrang_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chefrang_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pictureBox2;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.PictureBox Chefrang_1;
        private System.Windows.Forms.PictureBox Chefrang_2;

        private System.Windows.Forms.PictureBox man2;

        private System.Windows.Forms.PictureBox BgMap;
        private System.Windows.Forms.Label Score;

        private System.Timers.Timer gameTimer;

        private System.Windows.Forms.PictureBox man;

        #endregion
    }
}