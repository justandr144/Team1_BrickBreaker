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
        public static int score;
        int currentLevel;
        public static int lives;
        int musicCounter = 10000;

        // p and Ball objects
        public static Paddle p;
        public static Ball ball;
        public static bool ballStart = false;
        public static int ballBlockBouceTimer = 2;

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
        public static Random randGen = new Random();
        public static int random;
        public static string temp;
        public static Boolean ready = false;

        // Brushes
        SolidBrush pBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);
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
            powerUps = new PowerUp(100, 200, "boomerang");

            //create koopa
            koopa = new Ball(-20, -20, 0, 0, 20, 13, 2, true);
            // create condor
            condor = new Paddle(-80, -20, 80, 20, 2, Color.Orange);

            music = new System.Windows.Media.MediaPlayer();
            music.Open(new Uri(Application.StartupPath + "/Resources/ZeldaTheme.mp3"));
            paddleBeep = new System.Windows.Media.MediaPlayer();
            paddleBeep.Open(new Uri(Application.StartupPath + "/Resources/PaddleBeep.mp3"));
            wallBounce = new System.Windows.Media.MediaPlayer();
            wallBounce.Open(new Uri(Application.StartupPath + "/Resources/WallBounce.mp3"));

            //load level
            LoadLevel();

            //start the game engine loop
            gameTimer.Enabled = true;
        }

        public void LoadLevel()
        {
            blocks.Clear();

            string level = $"level0{5}.xml";

            try
            {
                XmlReader reader = XmlReader.Create(level);

                int newX, newY, newHp, newWidth, newHeight;
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

                        reader.ReadToNextSibling("width");
                        newWidth = Convert.ToInt32(reader.ReadString());

                        reader.ReadToNextSibling("height");
                        newHeight = Convert.ToInt32(reader.ReadString());

                        reader.ReadToNextSibling("colour");
                        newColour = Color.FromName(reader.ReadString());

                        Block b = new Block(newX, newY, newHp, newWidth, newHeight, newColour);
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
                case Keys.N:
                    nDown = true;
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
                    spaceBarDown = false;
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
                    score++;

                    random = randGen.Next(1, 3);
                    if (random == 1)
                    {
                        SamCreate(b.x, b.y);
                    }

                    if (blocks.Count == 0)
                    {
                        currentLevel++;
                        LoadLevel();
                    }

                    break;
                }
            }

            JustinMusicPlayMethod();
            PauseMethod();
            ballBlockBouceTimer--;

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
            //halt game engine
            gameTimer.Enabled = false;

            // add score to scorelist and refresh scorelist
            Form1.scoreList.Add(score);
            Form1.scoreList.Sort();
            Form1.scoreList.Reverse();

            // Goes to the game over screen
            music.Stop();

            Form form = this.FindForm();
            GameoverScreen gos = new GameoverScreen();

            gos.Location = new Point((form.Width - gos.Width) / 2, (form.Height - gos.Height) / 2);
            gos.Focus();

            form.Controls.Add(gos);
            form.Controls.Remove(this);

            ballStart = false;
        }

        public void OnVictory() //Replaces game screen with victory screen and adds score to scorelist. 
        {
            //halt game engine
            gameTimer.Enabled = false;

            //add score to scorelist and refresh scorelist
            Form1.scoreList.Add(score);
            Form1.scoreList.Sort();
            Form1.scoreList.Reverse();

            //goes to victory screen
            Form form = this.FindForm();
            VictoryScreen vs = new VictoryScreen();

            vs.Location = new Point((form.Width - vs.Width) / 2, (form.Height - vs.Height) / 2);

            form.Controls.Add(vs);
            form.Controls.Remove(this);
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws p
            pBrush.Color = p.colour;
            e.Graphics.FillRectangle(pBrush, p.x, p.y, p.width, p.height);

            // Draws blocks
            foreach (Block b in blocks)
            {
                e.Graphics.FillRectangle(new SolidBrush(b.colour), b.x, b.y, b.width, b.height);

                switch (b.crackCount)
                {
                    case 1:
                        e.Graphics.DrawImage(Properties.Resources.Crack1, b.x, b.y);
                        break;
                    case 2:
                        e.Graphics.DrawImage(Properties.Resources.Crack2, b.x, b.y);
                        break;
                    case 3:
                        e.Graphics.DrawImage(Properties.Resources.Crack3, b.x, b.y);
                        break;
                    default:
                        break;
                }
            }

            // Draws ball or certian power up
            if (powerUps.state == "power")
            {
                if (powerUps.type == "star")
                {
                    random = randGen.Next(1, 8);
                    switch (random)
                    {
                        case 1:
                            ballBrush.Color = Color.Red;
                            break;
                        case 2:
                            ballBrush.Color = Color.Orange;
                            break;
                        case 3:
                            ballBrush.Color = Color.Yellow;
                            break;
                        case 4:
                            ballBrush.Color = Color.Green;
                            break;
                        case 5:
                            ballBrush.Color = Color.Blue;
                            break;
                        case 6:
                            ballBrush.Color = Color.Violet;
                            break;
                        case 7:
                            ballBrush.Color = Color.Magenta;
                            break;
                    }
                    e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);
                    ballBrush.Color = Color.White;
                }
                else if (powerUps.type == "buzzsaw")
                {
                    e.Graphics.DrawImage(Properties.Resources.BuzzsawSprite, ball.x, ball.y);
                }
                else e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);
            }
            else e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);



            // Draws lives
            JustinLivesMethod(lives, e);

            // Draws powerup
            if (powerUps.state == "fall") e.Graphics.DrawImage(Properties.Resources.QuestionBlockSprite, powerUps.x, powerUps.y);
            if (powerUps.state == "activate")
            {
                switch (powerUps.type)
                {
                    case "1-up":
                        e.Graphics.DrawImage(Properties.Resources._1UpIcon, powerUps.x - 40, powerUps.y);
                        break;
                    case "cherry":
                        e.Graphics.DrawImage(Properties.Resources.CherryIcon, powerUps.x - 12, powerUps.y);
                        break;
                    case "mushroom":
                        e.Graphics.DrawImage(Properties.Resources.MushroomIcon, powerUps.x - 12, powerUps.y + 5);
                        break;
                    case "balloon":
                        e.Graphics.DrawImage(Properties.Resources.BalloonIcon, powerUps.x, powerUps.y);
                        break;
                    case "buzzsaw":
                        e.Graphics.DrawImage(Properties.Resources.BuzzsawIcon, powerUps.x - 10, powerUps.y + 5);
                        break;
                    case "star":
                        e.Graphics.DrawImage(Properties.Resources.SuperStarIcon, powerUps.x - 7, powerUps.y + 7);
                        break;
                    case "koopa":
                        e.Graphics.DrawImage(Properties.Resources.KoopaIcon, powerUps.x - 27, powerUps.y + 7);
                        break;
                    case "arrow":
                        e.Graphics.DrawImage(Properties.Resources.BowIcon, powerUps.x + 7, powerUps.y + 7);
                        break;
                    case "fireFlower":
                        e.Graphics.DrawImage(Properties.Resources.FireFlowerIcon, powerUps.x - 10, powerUps.y + 5);
                        break;
                    case "missile":
                        e.Graphics.DrawImage(Properties.Resources.MissileIcon, powerUps.x + 5, powerUps.y + 5);
                        break;
                    case "boomerang":
                        e.Graphics.DrawImage(Properties.Resources.CrossIcon, powerUps.x - 17, powerUps.y + 7);
                        break;
                    case "fireBall":
                        e.Graphics.DrawImage(Properties.Resources.BowserFireIcon, powerUps.x - 30, powerUps.y + 5);
                        break;
                    case "condor":
                        e.Graphics.DrawImage(Properties.Resources.CondorIcon, powerUps.x - 60, powerUps.y + 8);
                        break;
                }
            }
            if (powerUps.projectile != "")
            {
                switch (powerUps.projectile)
                {
                    case "arrow":
                        e.Graphics.DrawImage(Properties.Resources.ArrowSprite, powerUps.x, powerUps.y);
                        break;
                    case "fireFlower":
                        e.Graphics.DrawImage(Properties.Resources.FireBallSprite, powerUps.x, powerUps.y);
                        break;
                    case "missile":
                        e.Graphics.DrawImage(Properties.Resources.MissileSprite, powerUps.x, powerUps.y);
                        break;
                    case "boomerang":
                        e.Graphics.DrawImage(Properties.Resources.CrossSprite, powerUps.x, powerUps.y);
                        break;
                    case "fireBall":
                        e.Graphics.DrawImage(Properties.Resources.BowserFireSprite, powerUps.x, powerUps.y);
                        break;
                    case "explotion":
                        e.Graphics.DrawImage(Properties.Resources.BowserFireSprite, powerUps.x, powerUps.y);
                        break;
                }
            }

            if (pauseTimer.Enabled)
            {
                e.Graphics.DrawImage(Properties.Resources.Pause, 467, 310);
            }

            // draw koopa
            if (koopaLive)
            {
                e.Graphics.DrawImage(Properties.Resources.KoopaSprite, koopa.x, koopa.y);
            }
            // draw condor
            if (condorLive)
            {
                e.Graphics.DrawImage(Properties.Resources.CondorSprite, condor.x, condor.y);
            }

            // Draws score
            e.Graphics.DrawString("SCORE: " + Convert.ToString(score), DefaultFont, pBrush, 900, 20);
        }

        public void SamMethod()
        {
            switch (powerUps.state)
            {
                case "wait":
                    ready = true;
                    break;
                case "fall":
                    powerUps.Move();
                    powerUps.Collision(p.x, p.y, p.height, p.width);

                    break;
                case "activate":
                    if (spaceBarDown == true)
                    {
                        powerUps.Active();
                        spaceBarDown = false;
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
                condor.Move("left");
                ball.PaddleCollision(condor, ball);
                if (koopaLive)
                {
                    koopa.PaddleCollision(condor, koopa);
                }
                if (condor.x <= 0 - condor.width)
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
                        powerUps.explode(1);
                        powerUps.projectile = "done";
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
                        powerUps.explode(3);
                        powerUps.projectile = "done";
                        break;
                    }
                }

            }
        }

        public void SamCreate(int _x, int _y)
        {
            if (ready)
            {
                ready = false;
                random = randGen.Next(1, 14);
                switch (random)
                {
                    case 1:
                        temp = "1-up";
                        break;
                    case 2:
                        temp = "cherry";
                        break;
                    case 3:
                        temp = "mushroom";
                        break;
                    case 4:
                        temp = "balloon";
                        break;
                    case 5:
                        temp = "buzzsaw";
                        break;
                    case 6:
                        temp = "star";
                        break;
                    case 7:
                        temp = "koopa";
                        break;
                    case 8:
                        temp = "arrow";
                        break;
                    case 9:
                        temp = "fireFlower";
                        break;
                    case 10:
                        temp = "missile";
                        break;
                    case 11:
                        temp = "boomerang";
                        break;
                    case 12:
                        temp = "fireBall";
                        break;
                    case 13:
                        temp = "condor";
                        break;
                }
                powerUps.Create(temp, _x, _y);
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

