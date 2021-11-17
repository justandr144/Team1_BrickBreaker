
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
            this.mBox = new System.Windows.Forms.PictureBox();
            this.energyTankBox = new System.Windows.Forms.PictureBox();
            this.metroidBox = new System.Windows.Forms.PictureBox();
            this.questionBox = new System.Windows.Forms.PictureBox();
            this.triforceBox = new System.Windows.Forms.PictureBox();
            this.powerupsInstruct2Box = new System.Windows.Forms.PictureBox();
            this.powerupsInstructBox = new System.Windows.Forms.PictureBox();
            this.moveInstruct2 = new System.Windows.Forms.PictureBox();
            this.moveInstructBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.energyTankBox)).BeginInit();
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
            this.gameLoop.Interval = 20;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // mBox
            // 
            this.mBox.Image = global::BrickBreaker.Properties.Resources.pressM;
            this.mBox.Location = new System.Drawing.Point(254, 462);
            this.mBox.Name = "mBox";
            this.mBox.Size = new System.Drawing.Size(676, 45);
            this.mBox.TabIndex = 0;
            this.mBox.TabStop = false;
            // 
            // energyTankBox
            // 
            this.energyTankBox.Image = global::BrickBreaker.Properties.Resources.EnergyTank;
            this.energyTankBox.Location = new System.Drawing.Point(1036, 542);
            this.energyTankBox.Name = "energyTankBox";
            this.energyTankBox.Size = new System.Drawing.Size(147, 146);
            this.energyTankBox.TabIndex = 1;
            this.energyTankBox.TabStop = false;
            // 
            // metroidBox
            // 
            this.metroidBox.Image = global::BrickBreaker.Properties.Resources.Metroid;
            this.metroidBox.Location = new System.Drawing.Point(17, 555);
            this.metroidBox.Name = "metroidBox";
            this.metroidBox.Size = new System.Drawing.Size(139, 133);
            this.metroidBox.TabIndex = 2;
            this.metroidBox.TabStop = false;
            // 
            // questionBox
            // 
            this.questionBox.Image = global::BrickBreaker.Properties.Resources.QuestionBlock;
            this.questionBox.Location = new System.Drawing.Point(1050, 15);
            this.questionBox.Name = "questionBox";
            this.questionBox.Size = new System.Drawing.Size(133, 136);
            this.questionBox.TabIndex = 3;
            this.questionBox.TabStop = false;
            // 
            // triforceBox
            // 
            this.triforceBox.Image = global::BrickBreaker.Properties.Resources.Triforce;
            this.triforceBox.Location = new System.Drawing.Point(17, 15);
            this.triforceBox.Name = "triforceBox";
            this.triforceBox.Size = new System.Drawing.Size(144, 146);
            this.triforceBox.TabIndex = 4;
            this.triforceBox.TabStop = false;
            // 
            // powerupsInstruct2Box
            // 
            this.powerupsInstruct2Box.Image = global::BrickBreaker.Properties.Resources.powerupsInstruct2;
            this.powerupsInstruct2Box.Location = new System.Drawing.Point(87, 385);
            this.powerupsInstruct2Box.Name = "powerupsInstruct2Box";
            this.powerupsInstruct2Box.Size = new System.Drawing.Size(1012, 43);
            this.powerupsInstruct2Box.TabIndex = 5;
            this.powerupsInstruct2Box.TabStop = false;
            // 
            // powerupsInstructBox
            // 
            this.powerupsInstructBox.Image = global::BrickBreaker.Properties.Resources.powerupsInstruct;
            this.powerupsInstructBox.Location = new System.Drawing.Point(143, 338);
            this.powerupsInstructBox.Name = "powerupsInstructBox";
            this.powerupsInstructBox.Size = new System.Drawing.Size(899, 41);
            this.powerupsInstructBox.TabIndex = 6;
            this.powerupsInstructBox.TabStop = false;
            // 
            // moveInstruct2
            // 
            this.moveInstruct2.Image = global::BrickBreaker.Properties.Resources.moveInstruct2;
            this.moveInstruct2.Location = new System.Drawing.Point(254, 252);
            this.moveInstruct2.Name = "moveInstruct2";
            this.moveInstruct2.Size = new System.Drawing.Size(677, 50);
            this.moveInstruct2.TabIndex = 7;
            this.moveInstruct2.TabStop = false;
            // 
            // moveInstructBox
            // 
            this.moveInstructBox.Image = global::BrickBreaker.Properties.Resources.moveInstruct;
            this.moveInstructBox.Location = new System.Drawing.Point(58, 205);
            this.moveInstructBox.Name = "moveInstructBox";
            this.moveInstructBox.Size = new System.Drawing.Size(1089, 41);
            this.moveInstructBox.TabIndex = 8;
            this.moveInstructBox.TabStop = false;
            // 
            // InstructionsScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.moveInstructBox);
            this.Controls.Add(this.moveInstruct2);
            this.Controls.Add(this.powerupsInstructBox);
            this.Controls.Add(this.powerupsInstruct2Box);
            this.Controls.Add(this.triforceBox);
            this.Controls.Add(this.questionBox);
            this.Controls.Add(this.metroidBox);
            this.Controls.Add(this.energyTankBox);
            this.Controls.Add(this.mBox);
            this.Name = "InstructionsScreen";
            this.Size = new System.Drawing.Size(1200, 700);
            this.Load += new System.EventHandler(this.InstructionsScreen_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.InstructionsScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.InstructionsScreen_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.mBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.energyTankBox)).EndInit();
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
        private System.Windows.Forms.PictureBox mBox;
        private System.Windows.Forms.PictureBox energyTankBox;
        private System.Windows.Forms.PictureBox metroidBox;
        private System.Windows.Forms.PictureBox questionBox;
        private System.Windows.Forms.PictureBox triforceBox;
        private System.Windows.Forms.PictureBox powerupsInstruct2Box;
        private System.Windows.Forms.PictureBox powerupsInstructBox;
        private System.Windows.Forms.PictureBox moveInstruct2;
        private System.Windows.Forms.PictureBox moveInstructBox;
    }
}
