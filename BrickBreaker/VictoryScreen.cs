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
    public partial class VictoryScreen : UserControl
    {
        bool bDown, mDown = false;

        public VictoryScreen()
        {
            InitializeComponent();
        }

        private void VictoryScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.B:
                    bDown = true;
                    break;
                case Keys.M:
                    mDown = true;
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
                case Keys.M:
                    mDown = false;
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
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
