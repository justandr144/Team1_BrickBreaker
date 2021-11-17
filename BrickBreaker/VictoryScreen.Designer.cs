
namespace BrickBreaker
{
    partial class VictoryScreen
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
            this.congratsBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.congratsBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Enabled = true;
            this.gameLoop.Interval = 20;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // congratsBox
            // 
            this.congratsBox.Image = global::BrickBreaker.Properties.Resources.Congratulations;
            this.congratsBox.Location = new System.Drawing.Point(65, 200);
            this.congratsBox.Name = "congratsBox";
            this.congratsBox.Size = new System.Drawing.Size(1071, 50);
            this.congratsBox.TabIndex = 0;
            this.congratsBox.TabStop = false;
            // 
            // VictoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.congratsBox);
            this.Name = "VictoryScreen";
            this.Size = new System.Drawing.Size(1200, 700);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VictoryScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.VictoryScreen_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.congratsBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.PictureBox congratsBox;
    }
}
