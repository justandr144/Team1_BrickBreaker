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
        bool upArrowDown, downArrowDown, bDown, mDown = false;
        bool firstRun = true;
        bool pointer = false;
        int state = 0;

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
                case (Keys.M):
                    mDown = true;
                    break;
                default:
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
                case Keys.M:
                    mDown = false;
                    break;
                default:
                    break;
            }
        }
        private void gameLoop_Tick(object sender, EventArgs e)
        {
            if (firstRun)
            {
                this.Refresh();
                Thread.Sleep(3200);
                this.BackgroundImage = Properties.Resources.GOSelect;
                firstRun = false;
                pointer = true;
            }

            switch (state)
            {
                case (0):
                    if (downArrowDown)
                    {
                        menuBeep.Stop();
                        state = 1;
                        downArrowDown = false;

                        menuBeep.Play();
                    }
                    else if (bDown)
                    {
                        Form f = this.FindForm();
                        f.Controls.Remove(this);

                        MenuScreen ms = new MenuScreen();
                        ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);
                        f.Controls.Add(ms);

                        bDown = false;

                        ms.Focus();
                    }
                    break;
                case (1):
                    if (upArrowDown)
                    {
                        menuBeep.Stop();
                        state = 0;
                        upArrowDown = false;

                        menuBeep.Play();
                    }
                    else if (bDown)
                    {
                        Application.Exit();
                    }
                    break;

            }

            Refresh();
        }

        private void GameoverScreen_Paint(object sender, PaintEventArgs e)
        {
            if (pointer)
            {
                switch (state)
                {
                    case (0):
                        e.Graphics.DrawImage(Properties.Resources.Pointer, 380, 160);
                        break;
                    case (1):
                        e.Graphics.DrawImage(Properties.Resources.Pointer, 380, 260);
                        break;
                }
            }

            if (bDown)
            {
                gameLoop.Enabled = false;

                Form f = this.FindForm();
                f.Controls.Remove(this);

                MenuScreen ms = new MenuScreen();
                f.Controls.Add(ms);

                ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);
                bDown = false;

                ms.Focus();
            }
            else if (mDown)
            {
                Application.Exit();
            }
        }
    }
}
