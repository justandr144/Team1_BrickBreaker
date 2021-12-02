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
        bool nDown;

        // Game values
        int score;
        int currentLevel;
        public static int lives;
        int musicCounter = 10000;

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

        System.Windows.Media.MediaPlayer music;
        System.Windows.Media.MediaPlayer paddleBeep;
        System.Windows.Media.MediaPlayer wallBounce;


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
            powerUps = new PowerUp(100,200, "star");

            music = new System.Windows.Media.MediaPlayer();
            music.Open(new Uri(Application.StartupPath + "/Resources/ZeldaTheme.mp3"));
            paddleBeep = new System.Windows.Media.MediaPlayer();
            paddleBeep.Open(new Uri(Application.StartupPath + "/Resources/PaddleBeep.mp3"));
            wallBounce = new System.Windows.Media.MediaPlayer();
            wallBounce.Open(new Uri(Application.StartupPath + "/Resources/WallBounce.mp3"));

            LoadLevel();

            // start the game engine loop
            gameTimer.Enabled = true;
        }

        public void LoadLevel()
        {
            blocks.Clear();
            int x = 0;
            #region Creates blocks for generic level. Need to replace with code that loads levels.
            while (blocks.Count < 12)
            {
                x += 57;
                Block b1 = new Block(x, 78, 1, 50, 25, Color.White);
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
                case Keys.N:
                    nDown = true;
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
                case Keys.N:
                    nDown = false;
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

            JustinMusicPlayMethod();
            PauseMethod();

            //redraw the screen
            Refresh();
        }

        private void pauseTimer_Tick(object sender, EventArgs e)
        {
            if (nDown)
            {
                nDown = false;
                pauseTimer.Enabled = false;
                gameTimer.Enabled = true;
                music.Play();
            }
            Refresh();
        }

        public void OnEnd()
        {
            // Goes to the game over screen
            JustinEndMethod();

            Form form = this.FindForm();
            GameoverScreen gos = new GameoverScreen();
            
            gos.Location = new Point((form.Width - gos.Width) / 2, (form.Height - gos.Height) / 2);
            gos.Focus();

            form.Controls.Add(gos);
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

            JustinLivesMethod(lives, e);
            
            // Draws powerup
            if (powerUps.state != "wait")
            {
                e.Graphics.FillRectangle(ballBrush, powerUps.x, powerUps.y, powerUps.size, powerUps.size);
            }

            if (pauseTimer.Enabled)
            {
                e.Graphics.DrawImage(Properties.Resources.Pause, 467, 310);
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
        }
        
        public void JustinLivesMethod(int lives, PaintEventArgs g) //Lives Counter Method
        {
            g.Graphics.FillRectangle(blackBrush, 0, 0, this.Width, 68);
            g.Graphics.FillRectangle(pBrush, 0, 65, this.Width, 4);
            int livesAdd = 58;

            for (int i = 0; i < 6; i++)
            {
                if (lives > i)
                {
                    g.Graphics.DrawImage(Properties.Resources.LozHeart, 10 + (i * livesAdd), 8);
                }
            }
            
        }

        public void JustinMusicPlayMethod() //Zelda 2500, DK 53, Kirby 2250, Mario 270, Metroid 4375, PacMan 164, Tetris 1125 (Late start)
        {
            musicCounter++;

            if (musicCounter > 2500)
            {
                music.Stop();
                music.Play();
                musicCounter = 0;
            }
        }
        public void JustinMusicChangeMethod()
        {
            switch (currentLevel)
            {
                case 0:

                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
            }
        }

        public void JustinEndMethod()
        {
            music.Stop();
        }

        public void PauseMethod()
        {
            if (nDown)
            {
                nDown = false;
                gameTimer.Enabled = false;
                pauseTimer.Enabled = true;
                music.Pause();
            }
        }
}
}
