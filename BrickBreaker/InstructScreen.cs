using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class InstructScreen : UserControl
    {
        bool mDown = false;
        int musicCounter = 10000;

        System.Windows.Media.MediaPlayer instructionsMusic;

        public InstructScreen()
        {
            InitializeComponent();

            gameTimer.Enabled = true;
            instructionsMusic = new System.Windows.Media.MediaPlayer();
            instructionsMusic.Open(new Uri(Application.StartupPath + "/Resources/instructionsTheme.mp3"));
        }

        private void InstructionsScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.M):
                    mDown = true;
                    break;
                case Keys.Down:
                    this.BackgroundImage = Properties.Resources.InstructionScreen2;
                    break;
                case Keys.Up:
                    this.BackgroundImage = Properties.Resources.instructionScreen;
                    break;
            }
        }

        private void InstructionsScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.M):
                    mDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (musicCounter >= 590)
            {
                instructionsMusic.Stop();
                instructionsMusic.Play();
                musicCounter = 0;
            }

            if (mDown)
            {
                instructionsMusic.Stop();
                gameTimer.Enabled = false;

                Form f = this.FindForm();
                f.Controls.Remove(this);

                MenuScreen ms = new MenuScreen();
                ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);
                f.Controls.Add(ms);

                mDown = false;

                ms.Focus();
                return;
            }

            musicCounter++;
        }
    }
}
