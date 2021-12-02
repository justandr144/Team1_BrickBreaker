/*  Created by: Maeve, Justin, Hunter, Sam, Cait
 *  Project: Brick Breaker
 *  Date: December 3rd, 2021
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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

        private void MenuScreen_KeyUp(object sender, KeyEventArgs e)    //Keys being unpressed
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

        private void MenuScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)    //Keys being pressed
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

        private void MenuScreen_Load(object sender, EventArgs e)
        {
            gameLoop.Enabled = true;
        }

        private void gameLoop_Tick(object sender, EventArgs e)  //Loop to check for key presses
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
                        menuBeep.Stop();
                        state = 1;
                        downArrowDown = false;

                        menuBeep.Play();
                    }
                    else if (bDown)
                    {
                        music.Stop();
                        gameLoop.Enabled = false;

                        Form f = this.FindForm();
                        f.Controls.Remove(this);

                        GameScreen gs = new GameScreen();
                        gs.Location = new Point((f.Width - gs.Width) / 2, (f.Height - gs.Height) / 2);
                        f.Controls.Add(gs);

                        bDown = false;

                        gs.Focus();
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
                    else if (downArrowDown)
                    {
                        menuBeep.Stop();
                        state = 2;
                        downArrowDown = false;

                        menuBeep.Play();
                    }
                    else if (bDown)
                    {
                        music.Stop();
                        gameLoop.Enabled = false;

                        Form f = this.FindForm();
                        f.Controls.Remove(this);

                        InstructScreen ins = new InstructScreen();
                        ins.Location = new Point((f.Width - ins.Width) / 2, (f.Height - ins.Height) / 2);
                        f.Controls.Add(ins);

                        bDown = false;

                        ins.Focus();
                        return;
                    }
                    break;
                case (2):
                    if (upArrowDown)
                    {
                        menuBeep.Stop();
                        state = 1;
                        upArrowDown = false;

                        menuBeep.Play();
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

        private void MenuScreen_Paint(object sender, PaintEventArgs e)      //Painting and placing the barrel on selection
        {
            switch (state)
            {
                case (0):
                    e.Graphics.DrawImage(Properties.Resources.barrel, 720, 217);
                    break;
                case (1):
                    exitBarrelBox.Image = null;
                    e.Graphics.DrawImage(Properties.Resources.barrel, 390, 390);
                    break;
                case (2):
                    exitBarrelBox.Image = Properties.Resources.barrel;
                    break;
            }
        }
    }
}
