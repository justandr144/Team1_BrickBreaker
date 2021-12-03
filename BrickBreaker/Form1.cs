/*  Created by: Maeve, Justin, Hunter, Sam, Cait
 *  Project: Brick Breaker
 *  Date: December 3rd, 2021
 */

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

        public static List<int> scoreList = new List<int>();

        private void Form1_Load(object sender, EventArgs e)
        {
            // Start the program centred on the Menu Screen
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }

        public void LoadScore()
        {
            // read score.xml and copy data into scoreList
            XmlReader xmlReader = XmlReader.Create("HighScores.xml");
            
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
            // put scoreList data into score.xml
            XmlWriter xmlWriter = XmlWriter.Create("HighScores.xml");

            xmlWriter.WriteStartElement("HighScores");
            
            foreach (int s in scoreList)
            {
                xmlWriter.WriteStartElement("highScore");

                xmlWriter.WriteAttributeString("score", Convert.ToString(s));

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            
            xmlWriter.Close();
        }
    }
}
