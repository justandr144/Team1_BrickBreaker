using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {
        bool upArrowDown, downArrowDown, bDown;
        int state = 0;
        int musicCounter = 10000;

        System.Windows.Media.MediaPlayer music;
        System.Windows.Media.MediaPlayer menuBeep;

        public MenuScreen()
        {
            InitializeComponent();
            this.Focus();

            music = new System.Windows.Media.MediaPlayer();
            music.Open(new Uri(Application.StartupPath + "/Resources/MenuTheme.mp3"));

            menuBeep = new System.Windows.Media.MediaPlayer();
            menuBeep.Open(new Uri(Application.StartupPath + "/Resources/MenuBeep.mp3"));
        }

        private void MenuScreen_KeyUp(object sender, KeyEventArgs e)
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

        private void MenuScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            if (musicCounter >= 405)
            {
                music.Stop();
                music.Play();
                musicCounter = 0;
            }

            switch (state)
            {
                case (0):
                    if (downArrowDown)
                    {
                        state = 1;
                        downArrowDown = false;
                    }
                    else if (bDown)
                    {
                        Form f = this.FindForm();
                        f.Controls.Remove(this);

                        GameScreen gs = new GameScreen();
                        f.Controls.Add(gs);
                        bDown = false;
                    }
                    break;
                case (1):
                    if (upArrowDown)
                    {
                        state = 0;
                        upArrowDown = false;
                    }
                    else if (downArrowDown)
                    {
                        state = 2;
                        downArrowDown = false;
                    }
                    else if (bDown)
                    {
                        Form f = this.FindForm();
                        f.Controls.Remove(this);

                        InstructionsScreen ins = new InstructionsScreen();
                        f.Controls.Add(ins);
                        bDown = false;
                    }
                    break;
                case (2):
                    if (upArrowDown)
                    {
                        state = 1;
                        upArrowDown = false;
                    }
                    else if (bDown)
                    {
                        Application.Exit();
                    }
                    break;
            }

            musicCounter++;
            Refresh();
        }

        private void MenuScreen_Paint(object sender, PaintEventArgs e)
        {
            switch (state)
            {
                case (0):
                    e.Graphics.DrawImage(Properties.Resources.barrel, 500, 182);
                    break;
                case (1):
                    exitBarrelBox.Image = null;
                    e.Graphics.DrawImage(Properties.Resources.barrel, 270, 295);
                    break;
                case (2):
                    exitBarrelBox.Image = Properties.Resources.barrel;
                    break;
            }
        }
    }
}
