/*  Created by: 
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

namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown, spaceBarDown;

        // Game values
        public static int lives;

        // p and Ball objects
        public static Paddle p;
        public static Ball ball;

        // list of all blocks for current level
        List<Block> blocks = new List<Block>();

        // powerup object
        PowerUp powerUps;

        // Brushes
        SolidBrush pBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);
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
            int xSpeed = 13;
            int ySpeed = 13;
            int ballSize = 15;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);

            //set up powerups (temperary)
            powerUps = new PowerUp(100,200, "star");

            #region Creates blocks for generic level. Need to replace with code that loads levels.
            
            //TODO - replace all the code in this region eventually with code that loads levels from xml files
            
            blocks.Clear();
            int x = 10;

            while (blocks.Count < 12)
            {
                x += 57;
                Block b1 = new Block(x, 10, 1, Color.White);
                blocks.Add(b1);
            }

            #endregion

            // start the game engine loop
            gameTimer.Enabled = true;
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
                    spaceBarDown = false;
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
            ball.Move();

            // PowerUps
            SamMethod();

            // Check for collision with top and side walls
            ball.WallCollision(this);

            // Check for ball hitting bottom of screen
            if (ball.BottomCollision(this))
            {
                lives--;

                // Moves the ball back to origin
                ball.x = ((p.x - (ball.size / 2)) + (p.width / 2));
                ball.y = (this.Height - p.height) - 85;

                if (lives == 0)
                {
                    gameTimer.Enabled = false;
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

                    if (blocks.Count == 0)
                    {
                        gameTimer.Enabled = false;
                        OnEnd();
                    }

                    break;
                }
            }

            //redraw the screen
            Refresh();
        }

        public void OnEnd()
        {
            // Goes to the game over screen
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();
            
            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);

            form.Controls.Add(ps);
            form.Controls.Remove(this);
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws p
            pBrush.Color = p.colour;
            e.Graphics.FillRectangle(pBrush, p.x, p.y, p.width, p.height);

            //hut booxes
            e.Graphics.FillRectangle(blockBrush, p.x - 2, p.y - 2, 85, 1);
            e.Graphics.FillRectangle(blockBrush, p.x - 4, p.y - 2, 1, p.height + 4);
            e.Graphics.FillRectangle(blockBrush, p.x + 84, p.y - 2, 1, p.height + 4);
            e.Graphics.FillRectangle(blockBrush, p.x - 2, p.y + 22, 85, 1);

            // Draws blocks
            foreach (Block b in blocks)
            {
                e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
            }

            // Draws ball
            e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);
            
            // Draws powerup
            if (powerUps.state != "wait")
            {
                e.Graphics.FillRectangle(ballBrush, powerUps.x, powerUps.y, powerUps.size, powerUps.size);
            }
            
        }

        public void SamMethod()
        {
            switch (powerUps.state)
            {
                case "wait":
                    if (powerUps.check == true)
                    {


                        powerUps.check = false;
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
        }
    }
}
