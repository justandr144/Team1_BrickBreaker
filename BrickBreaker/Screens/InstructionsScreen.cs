using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BrickBreaker
{
    public partial class InstructionsScreen : UserControl
    {
        bool mDown = false;
        int musicCounter = 10000;

        System.Windows.Media.MediaPlayer instructionsMusic;

        public InstructionsScreen()
        {
            InitializeComponent();
            this.Focus();

            instructionsMusic = new System.Windows.Media.MediaPlayer();
            instructionsMusic.Open(new Uri(Application.StartupPath + "/Resources/InstructionsTheme.mp3"));
        }
        private void InstructionsScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.M):
                    mDown = true;
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

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            if (musicCounter >= 500)
            {
                instructionsMusic.Stop();
                instructionsMusic.Play();
                musicCounter = 0;
            }

            if (mDown)
            {
                instructionsMusic.Stop();
                gameLoop.Enabled = false;

                Form f = this.FindForm();
                f.Controls.Remove(this);

                MenuScreen ms = new MenuScreen();
                ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);
                f.Controls.Add(ms);

                mDown = false;

                ms.Focus();
            }

            musicCounter++;
        }

        private void InstructionsScreen_Load(object sender, EventArgs e)
        {
            gameLoop.Enabled = true;
        }
    }
}
