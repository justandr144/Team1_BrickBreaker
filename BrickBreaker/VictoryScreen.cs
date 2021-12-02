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
    public partial class VictoryScreen : UserControl
    {
        bool bDown, upArrowDown, downArrowDown = false;
        int state = 0;

        System.Windows.Media.MediaPlayer menuBeep;
        System.Windows.Media.MediaPlayer victorySound;

        public VictoryScreen()
        {
            InitializeComponent();

            menuBeep = new System.Windows.Media.MediaPlayer();
            menuBeep.Open(new Uri(Application.StartupPath + "/Resources/MenuBeep.mp3"));
            victorySound = new System.Windows.Media.MediaPlayer();
            victorySound.Open(new Uri(Application.StartupPath + "/Resources/VictorySound.mp3"));

            victorySound.Play();
        }

        private void VictoryScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.B:
                    bDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }
        }

        private void VictoryScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.B:
                    bDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            switch (state)
            {
                case 0:
                    if (bDown)
                    {
                        Form f = this.FindForm();
                        f.Controls.Remove(this);

                        MenuScreen ms = new MenuScreen();
                        f.Controls.Add(ms);

                        ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);
                        bDown = false;

                        ms.Focus();
                    }
                    else if (downArrowDown)
                    {
                        menuBeep.Stop();
                        state = 1;
                        menuBeep.Play();
                    }
                    break;
                case 1:
                    if (bDown)
                    {
                        Application.Exit();
                    }
                    else if (upArrowDown)
                    {
                        menuBeep.Stop();
                        state = 0;
                        menuBeep.Play();
                    }
                    break;
            }

            Refresh();
        }

        private void VictoryScreen_Paint(object sender, PaintEventArgs e)
        {
            switch (state)
            {
                case 0:
                    e.Graphics.DrawImage(Properties.Resources.PlayAgainSelect, 265, 347);
                    break;
                case 1:
                    e.Graphics.DrawImage(Properties.Resources.ExitSelect, 430, 420);
                    break;
            }
        }
    }
}
