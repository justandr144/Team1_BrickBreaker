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
    public partial class InstructionsScreen : UserControl
    {
        bool mDown = false;

        public InstructionsScreen()
        {
            InitializeComponent();
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
            if (mDown)
            {
                Form f = this.FindForm();
                f.Controls.Remove(this);

                MenuScreen ms = new MenuScreen();
                f.Controls.Add(ms);
                mDown = false;
            }
        }
    }
}
