using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace BrickBreaker
{
    public partial class GameoverScreen : UserControl
    {
        bool upArrowDown, downArrowDown, bDown = false;
        bool firstRun = true;

        System.Windows.Media.MediaPlayer gameOverSound;
        System.Windows.Media.MediaPlayer menuBeep;

        public GameoverScreen()
        {
            InitializeComponent();

            gameOverSound = new System.Windows.Media.MediaPlayer();
            gameOverSound.Open(new Uri(Application.StartupPath + "/Resources/GameOverSound.mp3"));
            menuBeep = new System.Windows.Media.MediaPlayer();
            menuBeep.Open(new Uri(Application.StartupPath + "/Resources/MenuBeep.mp3"));
        }

        private void GameoverScreen_Load(object sender, EventArgs e)
        {
            gameOverSound.Play();
        }

        private void GameoverScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Up):
                    upArrowDown = true;
                    break;
                case (Keys.Down):
                    downArrowDown = true;
                    break;
                case (Keys.B):
                    bDown = true;
                    break;
            }
        }

        private void GameoverScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Up):
                    upArrowDown = false;
                    break;
                case (Keys.Down):
                    downArrowDown = false;
                    break;
                case (Keys.B):
                    bDown = false;
                    break;
            }
        }
        private void gameLoop_Tick(object sender, EventArgs e)
        {
            if (firstRun)
            {
                Refresh();
                Thread.Sleep(3100);
                this.BackgroundImage = Properties.Resources.GOSelect;
                firstRun = false;
            }
        }
    }
}
