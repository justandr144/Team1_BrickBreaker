/*  Created by: Maeve, Justin, Sam, Hunter
 *  Project: Brick Breaker
 *  Date: 
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
using System.Media;
using System.Xml;

namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown, spaceBarDown;

        // Game values
        int score;
        int currentLevel;
        public static int lives;

        // p and Ball objects
        public static Paddle p;
        public static Ball ball;
        public static bool ballStart = false;

        //koopa 
        public static Ball koopa;
        public static Boolean koopaLive = false;
        //condor 
        public static Paddle condor;
        public static Boolean condorLive = false;

        // list of all blocks for current level
        public static List<Block> blocks = new List<Block>();

        // powerup object
        PowerUp powerUps;

        // Brushes
        SolidBrush pBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);
        SolidBrush koopaBrush = new SolidBrush(Color.Green);
        SolidBrush condorBrush = new SolidBrush(Color.Orange);
        SolidBrush blackBrush = new SolidBrush(Color.Black);

        #endregion

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }


        public void OnStart()
        {
            //set life counter
            lives = 3;

            //reset score
            score = 0;

            //reset level counter
            currentLevel = 1;

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            // setup starting p values and create p object
            int pWidth = 80;
            int pHeight = 20;
            int pX = ((this.Width / 2) - (pWidth / 2));
            int pY = (this.Height - pHeight) - 60;
            int pSpeed = 15;
            p = new Paddle(pX, pY, pWidth, pHeight, pSpeed, Color.White);

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballY = this.Height - p.height - 85;

            // Creates a new ball
            int xSpeed = 10;
            int ySpeed = -10;
            int defaultSpeed = 10;
            int ballStrength = 1;
            int ballSize = 15;
            bool ballBounce = true;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize, defaultSpeed, ballStrength, ballBounce);

            //set up powerups (temperary)
            powerUps = new PowerUp(100,200, "condor");
            //create koopa
            koopa = new Ball(-20, -20, 0, 0, 20, 0, 0, false);
            // create condor
            condor = new Paddle(-80,-20,80,20,2,Color.Orange);

            #region Creates blocks for generic level. No longer in use. 

            ////TODO - replace all the code in this region eventually with code that loads levels from xml file

            blocks.Clear();
            int x = 10;

            while (blocks.Count < 12)
            {
                x += 57;
                Block b1 = new Block(x, 78, 1, Color.White);
                blocks.Add(b1);
            }

            #endregion

            //LoadLevel();

            // start the game engine loop
            gameTimer.Enabled = true;
        }

        public void LoadLevel()
        {
            blocks.Clear();

            string level = $"level0{currentLevel}.xml";

            try
            {
                XmlReader reader = XmlReader.Create(level);

                int newX, newY, newHp;
                Color newColour;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        newX = Convert.ToInt32(reader.ReadString());

                        reader.ReadToNextSibling("y");
                        newY = Convert.ToInt32(reader.ReadString());

                        reader.ReadToNextSibling("hp");
                        newHp = Convert.ToInt32(reader.ReadString());

                        reader.ReadToNextSibling("colour");
                        newColour = Color.FromName(reader.ReadString());

                        Block b = new Block(newX, newY, newHp, newColour);
                        blocks.Add(b);
                    }
                }

                reader.Close();
            }
            catch //if requested level doesn't exist, quit menu
            {
                OnEnd();
                return;
            }
        }
        
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Space:
                    spaceBarDown = true;
                    break;
                case Keys.X:
                    ballStart = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Space:
                    spaceBarDown = true;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {


            // Move the p
            if (leftArrowDown && p.x > 0)
            {
                p.Move("left");
            }
            if (rightArrowDown && p.x < (this.Width - p.width))
            {
                p.Move("right");
            }

            // Move ball
            if (ballStart)
            {
                ball.Move();
            }
            else
            {
                ball.x = p.x + 30;
                ball.y = p.y - 25;
            }

            // PowerUps
            SamMethod();

            // Check for collision with top and side walls
            ball.WallCollision(this);

            // Check for ball hitting bottom of screen
            if (ball.BottomCollision(this))
            {
                lives--;
                ballStart = false;
                // Moves the ball back to origin
                ball.x = p.x + 30;
                ball.y = p.y - 25;

                if (lives == 0)
                {
                    OnEnd();
                }
            }

            // Check for collision of ball with p, (incl. p movement)
            ball.PaddleCollision(p, ball);

            // Check if ball has collided with any blocks
            foreach (Block b in blocks)
            {
                if (ball.BlockCollision(b))
                {
                    blocks.Remove(b);
                    
                    score++;
                    
                    if (blocks.Count == 0)
                    {
                        currentLevel++;
                        LoadLevel();
                    }

                    break;
                }
            }

            //redraw the screen
            Refresh();
        }

        public void OnEnd()
        {
            //halt game engine
            gameTimer.Enabled = false;

            // add score to scorelist and refresh scorelist
            Form1.scoreList.Add(score);
            Form1.scoreList.Sort();
            
            // Goes to the game over screen
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();

            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);

            form.Controls.Add(ps);
            form.Controls.Remove(this);

            ballStart = false;
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws p
            pBrush.Color = p.colour;
            e.Graphics.FillRectangle(pBrush, p.x, p.y, p.width, p.height);

            //hut booxes
            //e.Graphics.FillRectangle(blockBrush, p.x - 2, p.y - 2, 85, 1);
            //e.Graphics.FillRectangle(blockBrush, p.x - 4, p.y - 2, 1, p.height + 4);
            //e.Graphics.FillRectangle(blockBrush, p.x + 84, p.y - 2, 1, p.height + 4);
            //e.Graphics.FillRectangle(blockBrush, p.x - 2, p.y + 22, 85, 1);

            // Draws blocks
            foreach (Block b in blocks)
            {
                e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
            }

            // Draws ball
            e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);

            JustinMethod(lives, e);
           
            // Draws powerup
            if (powerUps.state != "wait")
            {
                e.Graphics.FillRectangle(ballBrush, powerUps.x, powerUps.y, powerUps.size, powerUps.size);
            }

            // draw koopa
            if (koopaLive)
            {
                e.Graphics.FillRectangle(koopaBrush, koopa.x, koopa.y, koopa.size, koopa.size);
            }
            // draw condor
            if (condorLive)
            {
                e.Graphics.FillRectangle(condorBrush, condor.x, condor.y, condor.width, condor.height);
            }
           
        }

        public void SamMethod()
        {
            switch (powerUps.state)
            {
                case "wait":
                    if (powerUps.created == true)
                    {
                        powerUps.created = false;
                    }
                    break;
                case "fall":
                    powerUps.Move();
                    powerUps.Collision(p.x, p.y, p.height, p.width);

                    break;
                case "activate":
                    if (spaceBarDown == true)
                    {
                        powerUps.Active();
                    }
                    break;
                case "power":
                    powerUps.UsingPowerUp();
                    break;
            }

            //koopa logic
            if (koopaLive)
            {
                // Move koopa
                koopa.Move();

                // Check for collision with top and side walls
                koopa.WallCollision(this);

                // Check for koopa hitting bottom of screen
                if (koopa.BottomCollision(this))
                {
                    koopaLive = false;
                    koopa.xSpeed = 0;
                    koopa.ySpeed = 0;
                    koopa.x = -koopa.size;
                    koopa.y = -koopa.size;

                }

                // Check for collision of koopa with p, (incl. p movement)
                koopa.PaddleCollision(p, koopa);

                // Check if koopa has collided with any blocks
                foreach (Block b in blocks)
                {
                    if (koopa.BlockCollision(b))
                    {
                        blocks.Remove(b);

                        if (blocks.Count == 0)
                        {
                            gameTimer.Enabled = false;
                            OnEnd();
                        }

                        break;
                    }
                }
            }

            //condor logic
            if (condorLive)
            {
                condor.speed = 2;
                condor.Move("right");
                ball.PaddleCollision(condor, ball);
                if (koopaLive)
                {
                    koopa.PaddleCollision(condor, koopa);
                }
                if (condor.x >= this.Width)
                {
                    condorLive = false;
                    condor.x = -80;
                    condor.y = -20;
                }
            }

            //arrow logic
            if (powerUps.projectile == "arrow")
            {
                powerUps.Move();
                powerUps.WallCollision(this);
                foreach (Block b in blocks)
                {

                    if (powerUps.BlockCollision(b))
                    {
                        powerUps.projectile = "done";
                        blocks.Remove(b);

                        break;
                    }
                }
            }

            //fire flower logic
            if (powerUps.projectile == "fireFlower")
            {
                powerUps.Move();
                powerUps.WallCollision(this);
                foreach (Block b in blocks)
                {

                    if (powerUps.BlockCollision(b))
                    {
                        powerUps.projectile = "done";
                        blocks.Remove(b);

                        break;
                    }
                }
            }

            //missile logic
            if (powerUps.projectile == "missile")
            {
                powerUps.Move();
                powerUps.WallCollision(this);

                foreach (Block b in blocks)
                {
                    if (powerUps.BlockCollision(b))
                    {
                        powerUps.projectile = "done";
                        powerUps.explode();
                        break;
                    }
                }

            }

            //boomerang logic
            if (powerUps.projectile == "boomerang")
            {
                powerUps.Move();
                powerUps.projectile = "turn";
                powerUps.WallCollision(this);
                powerUps.projectile = "boomerang";

                foreach (Block b in blocks)
                {
                    if (powerUps.BlockCollision(b))
                    {
                        
                        b.hp--;
                        if (b.hp <= 0)
                        {
                            GameScreen.blocks.Remove(b);
                        }

                        break;
                    }
                }
            }

            //fire ball logic
            if (powerUps.projectile == "fireBall")
            {
                powerUps.Move();
                powerUps.projectile = "turn";
                powerUps.WallCollision(this);
                powerUps.projectile = "fireBall";

                foreach (Block b in blocks)
                {
                    if (powerUps.BlockCollision(b))
                    {
                        powerUps.projectile = "done";
                        powerUps.explode();
                        break;
                    }
                }

            }
        }
        
        public void JustinMethod(int lives, PaintEventArgs g) //Lives Counter Method
        {
            g.Graphics.FillRectangle(blackBrush, 0, 0, this.Width, 78);

            if (lives > 0)
            {
                g.Graphics.DrawImage(Properties.Resources.LozHeart, 10, 10);

                if (lives > 1)
                {
                    g.Graphics.DrawImage(Properties.Resources.LozHeart, 68, 10);

                    if (lives > 2)
                    {
                        g.Graphics.DrawImage(Properties.Resources.LozHeart, 126, 10);

                        if (lives > 3)
                        {
                            g.Graphics.DrawImage(Properties.Resources.LozHeart, 184, 10);

                            if (lives > 4)
                            {
                                g.Graphics.DrawImage(Properties.Resources.LozHeart, 242, 10);

                                if (lives > 5)
                                {
                                    g.Graphics.DrawImage(Properties.Resources.LozHeart, 300, 10);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
