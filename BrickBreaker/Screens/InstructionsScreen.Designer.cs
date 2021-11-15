
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
            this.engeryTankBox = new System.Windows.Forms.PictureBox();
            this.metroidBox = new System.Windows.Forms.PictureBox();
            this.questionBox = new System.Windows.Forms.PictureBox();
            this.triforceBox = new System.Windows.Forms.PictureBox();
            this.powerupsInstruct2Box = new System.Windows.Forms.PictureBox();
            this.powerupsInstructBox = new System.Windows.Forms.PictureBox();
            this.moveInstruct2 = new System.Windows.Forms.PictureBox();
            this.moveInstructBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.engeryTankBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroidBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.triforceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerupsInstruct2Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerupsInstructBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveInstruct2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveInstructBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Enabled = true;
            this.gameLoop.Interval = 20;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // engeryTankBox
            // 
            this.engeryTankBox.Image = global::BrickBreaker.Properties.Resources.EnergyTank;
            this.engeryTankBox.Location = new System.Drawing.Point(734, 427);
            this.engeryTankBox.Name = "engeryTankBox";
            this.engeryTankBox.Size = new System.Drawing.Size(100, 101);
            this.engeryTankBox.TabIndex = 7;
            this.engeryTankBox.TabStop = false;
            // 
            // metroidBox
            // 
            this.metroidBox.Image = global::BrickBreaker.Properties.Resources.Metroid;
            this.metroidBox.Location = new System.Drawing.Point(17, 432);
            this.metroidBox.Name = "metroidBox";
            this.metroidBox.Size = new System.Drawing.Size(100, 96);
            this.metroidBox.TabIndex = 6;
            this.metroidBox.TabStop = false;
            // 
            // questionBox
            // 
            this.questionBox.Image = global::BrickBreaker.Properties.Resources.QuestionBlock;
            this.questionBox.Location = new System.Drawing.Point(734, 18);
            this.questionBox.Name = "questionBox";
            this.questionBox.Size = new System.Drawing.Size(100, 98);
            this.questionBox.TabIndex = 5;
            this.questionBox.TabStop = false;
            // 
            // triforceBox
            // 
            this.triforceBox.Image = global::BrickBreaker.Properties.Resources.Triforce;
            this.triforceBox.Location = new System.Drawing.Point(17, 15);
            this.triforceBox.Name = "triforceBox";
            this.triforceBox.Size = new System.Drawing.Size(101, 101);
            this.triforceBox.TabIndex = 4;
            this.triforceBox.TabStop = false;
            // 
            // powerupsInstruct2Box
            // 
            this.powerupsInstruct2Box.Image = global::BrickBreaker.Properties.Resources.powerupsInstruct2;
            this.powerupsInstruct2Box.Location = new System.Drawing.Point(65, 322);
            this.powerupsInstruct2Box.Name = "powerupsInstruct2Box";
            this.powerupsInstruct2Box.Size = new System.Drawing.Size(731, 38);
            this.powerupsInstruct2Box.TabIndex = 3;
            this.powerupsInstruct2Box.TabStop = false;
            // 
            // powerupsInstructBox
            // 
            this.powerupsInstructBox.Image = global::BrickBreaker.Properties.Resources.powerupsInstruct;
            this.powerupsInstructBox.Location = new System.Drawing.Point(112, 285);
            this.powerupsInstructBox.Name = "powerupsInstructBox";
            this.powerupsInstructBox.Size = new System.Drawing.Size(638, 31);
            this.powerupsInstructBox.TabIndex = 2;
            this.powerupsInstructBox.TabStop = false;
            // 
            // moveInstruct2
            // 
            this.moveInstruct2.Image = global::BrickBreaker.Properties.Resources.moveInstruct2;
            this.moveInstruct2.Location = new System.Drawing.Point(187, 222);
            this.moveInstruct2.Name = "moveInstruct2";
            this.moveInstruct2.Size = new System.Drawing.Size(481, 35);
            this.moveInstruct2.TabIndex = 1;
            this.moveInstruct2.TabStop = false;
            // 
            // moveInstructBox
            // 
            this.moveInstructBox.Image = global::BrickBreaker.Properties.Resources.moveInstruct;
            this.moveInstructBox.Location = new System.Drawing.Point(44, 186);
            this.moveInstructBox.Name = "moveInstructBox";
            this.moveInstructBox.Size = new System.Drawing.Size(775, 30);
            this.moveInstructBox.TabIndex = 0;
            this.moveInstructBox.TabStop = false;
            // 
            // InstructionsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.engeryTankBox);
            this.Controls.Add(this.metroidBox);
            this.Controls.Add(this.questionBox);
            this.Controls.Add(this.triforceBox);
            this.Controls.Add(this.powerupsInstruct2Box);
            this.Controls.Add(this.powerupsInstructBox);
            this.Controls.Add(this.moveInstruct2);
            this.Controls.Add(this.moveInstructBox);
            this.Name = "InstructionsScreen";
            this.Size = new System.Drawing.Size(854, 542);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.InstructionsScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.InstructionsScreen_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.engeryTankBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroidBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.triforceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerupsInstruct2Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerupsInstructBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveInstruct2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveInstructBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.PictureBox moveInstructBox;
        private System.Windows.Forms.PictureBox moveInstruct2;
        private System.Windows.Forms.PictureBox powerupsInstructBox;
        private System.Windows.Forms.PictureBox powerupsInstruct2Box;
        private System.Windows.Forms.PictureBox triforceBox;
        private System.Windows.Forms.PictureBox questionBox;
        private System.Windows.Forms.PictureBox metroidBox;
        private System.Windows.Forms.PictureBox engeryTankBox;
    }
}
