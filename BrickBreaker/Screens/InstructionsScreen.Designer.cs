
namespace BrickBreaker
{
    partial class InstructionsScreen
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
            this.powerupsInstructBox = new System.Windows.Forms.PictureBox();
            this.moveInstruct2 = new System.Windows.Forms.PictureBox();
            this.moveInstructBox = new System.Windows.Forms.PictureBox();
            this.powerupsInstruct2Box = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.powerupsInstructBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveInstruct2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveInstructBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerupsInstruct2Box)).BeginInit();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Enabled = true;
            this.gameLoop.Interval = 20;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // powerupsInstructBox
            // 
            this.powerupsInstructBox.Image = global::BrickBreaker.Properties.Resources.powerupsInstruct;
            this.powerupsInstructBox.Location = new System.Drawing.Point(110, 168);
            this.powerupsInstructBox.Name = "powerupsInstructBox";
            this.powerupsInstructBox.Size = new System.Drawing.Size(638, 31);
            this.powerupsInstructBox.TabIndex = 2;
            this.powerupsInstructBox.TabStop = false;
            // 
            // moveInstruct2
            // 
            this.moveInstruct2.Image = global::BrickBreaker.Properties.Resources.moveInstruct2;
            this.moveInstruct2.Location = new System.Drawing.Point(185, 105);
            this.moveInstruct2.Name = "moveInstruct2";
            this.moveInstruct2.Size = new System.Drawing.Size(481, 35);
            this.moveInstruct2.TabIndex = 1;
            this.moveInstruct2.TabStop = false;
            // 
            // moveInstructBox
            // 
            this.moveInstructBox.Image = global::BrickBreaker.Properties.Resources.moveInstruct;
            this.moveInstructBox.Location = new System.Drawing.Point(42, 69);
            this.moveInstructBox.Name = "moveInstructBox";
            this.moveInstructBox.Size = new System.Drawing.Size(775, 30);
            this.moveInstructBox.TabIndex = 0;
            this.moveInstructBox.TabStop = false;
            // 
            // powerupsInstruct2Box
            // 
            this.powerupsInstruct2Box.Image = global::BrickBreaker.Properties.Resources.powerupsInstruct2;
            this.powerupsInstruct2Box.Location = new System.Drawing.Point(123, 205);
            this.powerupsInstruct2Box.Name = "powerupsInstruct2Box";
            this.powerupsInstruct2Box.Size = new System.Drawing.Size(616, 31);
            this.powerupsInstruct2Box.TabIndex = 3;
            this.powerupsInstruct2Box.TabStop = false;
            // 
            // InstructionsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.powerupsInstruct2Box);
            this.Controls.Add(this.powerupsInstructBox);
            this.Controls.Add(this.moveInstruct2);
            this.Controls.Add(this.moveInstructBox);
            this.Name = "InstructionsScreen";
            this.Size = new System.Drawing.Size(854, 542);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.InstructionsScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.InstructionsScreen_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.powerupsInstructBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveInstruct2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveInstructBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerupsInstruct2Box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.PictureBox moveInstructBox;
        private System.Windows.Forms.PictureBox moveInstruct2;
        private System.Windows.Forms.PictureBox powerupsInstructBox;
        private System.Windows.Forms.PictureBox powerupsInstruct2Box;
    }
}
