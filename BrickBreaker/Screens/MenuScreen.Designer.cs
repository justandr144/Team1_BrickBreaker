namespace BrickBreaker
{
    partial class MenuScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameLoop = new System.Windows.Forms.Timer(this.components);
            this.exitBarrelBox = new System.Windows.Forms.PictureBox();
            this.exitBox = new System.Windows.Forms.PictureBox();
            this.howToBox = new System.Windows.Forms.PictureBox();
            this.titleBox = new System.Windows.Forms.PictureBox();
            this.playBox = new System.Windows.Forms.PictureBox();
            this.ladder3Box = new System.Windows.Forms.PictureBox();
            this.ladder2Box = new System.Windows.Forms.PictureBox();
            this.ladder1Box = new System.Windows.Forms.PictureBox();
            this.bottomBarBox = new System.Windows.Forms.PictureBox();
            this.barBox2 = new System.Windows.Forms.PictureBox();
            this.barBox1 = new System.Windows.Forms.PictureBox();
            this.topMenuBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.exitBarrelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.howToBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ladder3Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ladder2Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ladder1Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomBarBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenuBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Enabled = true;
            this.gameLoop.Interval = 20;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // exitBarrelBox
            // 
            this.exitBarrelBox.Location = new System.Drawing.Point(200, 168);
            this.exitBarrelBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.exitBarrelBox.Name = "exitBarrelBox";
            this.exitBarrelBox.Size = new System.Drawing.Size(26, 20);
            this.exitBarrelBox.TabIndex = 13;
            this.exitBarrelBox.TabStop = false;
            // 
            // exitBox
            // 
            this.exitBox.Image = global::BrickBreaker.Properties.Resources.exit;
            this.exitBox.Location = new System.Drawing.Point(134, 168);
            this.exitBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.exitBox.Name = "exitBox";
            this.exitBox.Size = new System.Drawing.Size(63, 20);
            this.exitBox.TabIndex = 12;
            this.exitBox.TabStop = false;
            // 
            // howToBox
            // 
            this.howToBox.Image = global::BrickBreaker.Properties.Resources.howToPlay;
            this.howToBox.Location = new System.Drawing.Point(126, 113);
            this.howToBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.howToBox.Name = "howToBox";
            this.howToBox.Size = new System.Drawing.Size(79, 30);
            this.howToBox.TabIndex = 11;
            this.howToBox.TabStop = false;
            // 
            // titleBox
            // 
            this.titleBox.Image = global::BrickBreaker.Properties.Resources.BrickBreaker;
            this.titleBox.Location = new System.Drawing.Point(134, 22);
            this.titleBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(187, 14);
            this.titleBox.TabIndex = 10;
            this.titleBox.TabStop = false;
            // 
            // playBox
            // 
            this.playBox.Image = global::BrickBreaker.Properties.Resources.play;
            this.playBox.Location = new System.Drawing.Point(134, 72);
            this.playBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.playBox.Name = "playBox";
            this.playBox.Size = new System.Drawing.Size(65, 20);
            this.playBox.TabIndex = 9;
            this.playBox.TabStop = false;
            // 
            // ladder3Box
            // 
            this.ladder3Box.Image = global::BrickBreaker.Properties.Resources.ladderImage;
            this.ladder3Box.Location = new System.Drawing.Point(270, 160);
            this.ladder3Box.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ladder3Box.Name = "ladder3Box";
            this.ladder3Box.Size = new System.Drawing.Size(13, 20);
            this.ladder3Box.TabIndex = 8;
            this.ladder3Box.TabStop = false;
            // 
            // ladder2Box
            // 
            this.ladder2Box.BackColor = System.Drawing.Color.Transparent;
            this.ladder2Box.Image = global::BrickBreaker.Properties.Resources.ladderImage;
            this.ladder2Box.Location = new System.Drawing.Point(57, 110);
            this.ladder2Box.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ladder2Box.Name = "ladder2Box";
            this.ladder2Box.Size = new System.Drawing.Size(13, 22);
            this.ladder2Box.TabIndex = 7;
            this.ladder2Box.TabStop = false;
            // 
            // ladder1Box
            // 
            this.ladder1Box.BackColor = System.Drawing.Color.Transparent;
            this.ladder1Box.Image = global::BrickBreaker.Properties.Resources.ladderImage;
            this.ladder1Box.Location = new System.Drawing.Point(282, 64);
            this.ladder1Box.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ladder1Box.Name = "ladder1Box";
            this.ladder1Box.Size = new System.Drawing.Size(13, 22);
            this.ladder1Box.TabIndex = 6;
            this.ladder1Box.TabStop = false;
            // 
            // bottomBarBox
            // 
            this.bottomBarBox.Image = global::BrickBreaker.Properties.Resources.BottomBar;
            this.bottomBarBox.Location = new System.Drawing.Point(-7, 174);
            this.bottomBarBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.bottomBarBox.Name = "bottomBarBox";
            this.bottomBarBox.Size = new System.Drawing.Size(344, 38);
            this.bottomBarBox.TabIndex = 5;
            this.bottomBarBox.TabStop = false;
            // 
            // barBox2
            // 
            this.barBox2.Image = global::BrickBreaker.Properties.Resources.RightDownBar;
            this.barBox2.Location = new System.Drawing.Point(-7, 140);
            this.barBox2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.barBox2.Name = "barBox2";
            this.barBox2.Size = new System.Drawing.Size(311, 31);
            this.barBox2.TabIndex = 4;
            this.barBox2.TabStop = false;
            // 
            // barBox1
            // 
            this.barBox1.Image = global::BrickBreaker.Properties.Resources.LeftDownBar;
            this.barBox1.Location = new System.Drawing.Point(5, 89);
            this.barBox1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.barBox1.Name = "barBox1";
            this.barBox1.Size = new System.Drawing.Size(332, 22);
            this.barBox1.TabIndex = 3;
            this.barBox1.TabStop = false;
            // 
            // topMenuBox
            // 
            this.topMenuBox.Image = global::BrickBreaker.Properties.Resources.TopMenuImage;
            this.topMenuBox.Location = new System.Drawing.Point(5, -12);
            this.topMenuBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.topMenuBox.Name = "topMenuBox";
            this.topMenuBox.Size = new System.Drawing.Size(322, 76);
            this.topMenuBox.TabIndex = 2;
            this.topMenuBox.TabStop = false;
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.exitBarrelBox);
            this.Controls.Add(this.ladder3Box);
            this.Controls.Add(this.ladder2Box);
            this.Controls.Add(this.ladder1Box);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.topMenuBox);
            this.Controls.Add(this.playBox);
            this.Controls.Add(this.howToBox);
            this.Controls.Add(this.exitBox);
            this.Controls.Add(this.bottomBarBox);
            this.Controls.Add(this.barBox2);
            this.Controls.Add(this.barBox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(854, 550);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MenuScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MenuScreen_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.exitBarrelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.howToBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ladder3Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ladder2Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ladder1Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomBarBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topMenuBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox topMenuBox;
        private System.Windows.Forms.PictureBox barBox1;
        private System.Windows.Forms.PictureBox barBox2;
        private System.Windows.Forms.PictureBox bottomBarBox;
        private System.Windows.Forms.PictureBox ladder1Box;
        private System.Windows.Forms.PictureBox ladder2Box;
        private System.Windows.Forms.PictureBox ladder3Box;
        private System.Windows.Forms.PictureBox playBox;
        private System.Windows.Forms.PictureBox titleBox;
        private System.Windows.Forms.PictureBox howToBox;
        private System.Windows.Forms.PictureBox exitBox;
        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.PictureBox exitBarrelBox;
    }
}
