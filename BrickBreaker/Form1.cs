using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BrickBreaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> scoreList = new List<int>();

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the program centred on the Menu Screen
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }

        public void LoadScore()
        {
            //TODO read score.xml and copy data into scoreList
            XmlReader xmlReader = XmlReader.Create("Resources/HighScores.xml");
            
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    scoreList.Add(int.Parse(xmlReader.Value));
                }
            }
            xmlReader.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO put scoreList data into score.xml
        }
    }
}
