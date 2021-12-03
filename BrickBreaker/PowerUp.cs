using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BrickBreaker
{
    class PowerUp
    {
        /* sort the diffrent types of powerups
         * (Breaking cetain blocks) or (Random blocks give random powerups)
         * powerups fall and either collide with the player or fall out of the screen (Move behavoir)
         * if the player coides with the power ups give the player the power up (colide behavoir with player and bottom of screen)
         * use space to activate the power up (use behavoir)
         */

        /// Types of power ups and sorting powerups
        /// "mushroom", "cherry", "fireFlower"
            //Star(one shot everything for short amount of time, doesn't bounce off blocks)    
            //1-up (genaric) (1 life increase)                        
            //Pac man cherry(score increase)                        
            //Balloon (balloon fight)(slows the ball speed)       
            //Mushroom(increases paddle size)                         
            //Megaman buzzsaw (increases the strenth of ball to 2)    
            //Fire flower(Shoot projectile on an angle, break block and self on contact)           
            //Zelda  bow and arrow(Shoot projectile, break block and break self on contact)               
            //Koopa shell(shells that act like ball but won't count towards lives)          
            //Metroid bomb (explodes in an area if doesn't hit any bricks falls back down)     
            //Boomerang (from castlevania)      
            //condor evil paddle            
            //launch a fire ball up that explodes or falls to the ground.       
        

        /// method is call three places
        /// 1. in ball colistion, create a powerup in "wait" state
        /// 2. in game tick, either move down in "fall" state. Or use power in "power" state
        /// 3. in spacebar press, activate the power in "activate" state


        /// States: wait, fall, activate, power.
        /// wait is waiting to create the powerUp
        /// fall is to move down and check for a colision with player
        /// activate is waiting for the powerup to get activated
        /// power is what the powerup does
        public string type;
        public int speedY = 7;
        public int speedX = 0;
        public string state = "wait";
        public int x, y;
        public int size = 20;
        public int timer = 250;
        //a variable that will know what type of projetile that the powerup need to turn into
        public string projectile = "";
        //check variable will check for the creation of a powerUp.
        public Boolean created = false;


        public PowerUp(int _x, int _y, string _type)
        {
            x = _x;
            y = _y;
            type = _type;
        }

        public void Move()
        {
            y += speedY;
            x += speedX;
        }

        public void Active()
        {
            state = "power";
            x = -size;
            y = -size;
        }

        public void Collision(int _paddleX, int _paddleY, int _paddleH, int _PaddleW)
        {
            Rectangle paddleRec = new Rectangle(_paddleX, _paddleY, _PaddleW, _paddleH);
            Rectangle powerUpRec = new Rectangle(x, y, size, size);

            if (paddleRec.IntersectsWith(powerUpRec))
            {
                //prepare for new state
                x = 1200-2*size;
                y = 0;
                state = "activate";
            }

        }

        public void UsingPowerUp()
        {
            //determine what type of power up it is and then give that power
            switch (type)
            {
                case "1-up":
                    GameScreen.lives++;
                    state = "wait";
                    GameScreen.ready = true;
                    break;
                case "cherry":
                    GameScreen.score += 25;
                    state = "wait";
                    GameScreen.ready = true;
                    break;
                case "mushroom":
                    timer--;
                    if (timer > 0)
                    {
                        GameScreen.p.width = 160;                      
                    }
                    else
                    {
                        GameScreen.p.width = 80;
                        state = "wait";
                        GameScreen.ready = true;
                        timer = 250;
                    }
                    break;
                case "balloon":
                    timer--;
                    if (timer >= 0)
                    {
                        if (GameScreen.ball.xSpeed < 0)
                        {
                            GameScreen.ball.xSpeed = -6;
                        }
                        else GameScreen.ball.xSpeed = 6;
                        if (GameScreen.ball.ySpeed < 0)
                        {
                            GameScreen.ball.ySpeed = -6;
                        }
                        else GameScreen.ball.ySpeed = 6;

                    }
                    else
                    {
                        if (GameScreen.ball.xSpeed < 0)
                        {
                            GameScreen.ball.xSpeed = -13;
                        }
                        else GameScreen.ball.xSpeed = 13;
                        if (GameScreen.ball.ySpeed < 0)
                        {
                            GameScreen.ball.ySpeed = -13;
                        }
                        else GameScreen.ball.ySpeed = 13;
                        state = "wait";
                        GameScreen.ready = true;
                        timer = 250;
                    }
                    break;
                case "buzzsaw":
                    timer--;
                    if (timer > 0)
                    {
                        GameScreen.ball.strength = 2;
                    }
                    else
                    {
                        GameScreen.ball.strength = 1;
                        state = "wait";
                        GameScreen.ready = true;
                        timer = 250;
                    }
                    break;
                case "star":
                    timer--;
                    if (timer > 0)
                    {
                        if (GameScreen.ball.xSpeed < 0)
                        {
                            GameScreen.ball.xSpeed = -16;
                        }
                        else GameScreen.ball.xSpeed = 16;
                        if (GameScreen.ball.ySpeed < 0)
                        {
                            GameScreen.ball.ySpeed = -16;
                        }
                        else GameScreen.ball.ySpeed = 16;
                        GameScreen.ball.strength = 999;
                        GameScreen.ball.bounce = true;

                    }
                    else
                    {
                        if (GameScreen.ball.xSpeed < 0)
                        {
                            GameScreen.ball.xSpeed = -13;
                        }
                        else GameScreen.ball.xSpeed = 13;
                        if (GameScreen.ball.ySpeed < 0)
                        {
                            GameScreen.ball.ySpeed = -13;
                        }
                        else GameScreen.ball.ySpeed = 13;
                        GameScreen.ball.strength = 1;
                        GameScreen.ball.bounce = true;
                        state = "wait";
                        GameScreen.ready = true;
                        timer = 250;
                    }
                    break;
                case "koopa":
                    GameScreen.koopaLive = true;
                    GameScreen.koopa.xSpeed = -13;
                    GameScreen.koopa.ySpeed = -13;
                    GameScreen.koopa.x = ((GameScreen.p.x - (GameScreen.koopa.size / 2)) + (GameScreen.p.width / 2));
                    GameScreen.koopa.y = GameScreen.p.y - 70;
                    state = "wait";
                    GameScreen.ready = true;
                    break;
                case "arrow":
                    if (projectile == "")
                    {
                        x = ((GameScreen.p.x - (size / 2)) + (GameScreen.p.width / 2));
                        y = GameScreen.p.y - 70;
                        speedX = 0;
                        speedY = -15;
                        projectile = "arrow";
                    }
                    if (projectile == "done")
                    {
                        state = "wait";
                        GameScreen.ready = true;
                        speedX = 0;
                        speedY = 6;
                        projectile = "";
                    }
                    break;
                case "fireFlower":
                    if (projectile == "")
                    {
                        x = ((GameScreen.p.x - (size / 2)) + (GameScreen.p.width / 2));
                        y = GameScreen.p.y - 70;
                        speedX = -10;
                        speedY = -10;
                        projectile = "fireFlower";
                    }

                    if (projectile == "done")
                    {
                        state = "wait";
                        GameScreen.ready = true;
                        speedX = 0;
                        speedY = 6;
                        projectile = "";
                    }
                    break;
                case "missile":
                    if (projectile == "")
                    {
                        x = ((GameScreen.p.x - (size / 2)) + (GameScreen.p.width / 2));
                        y = GameScreen.p.y - 70;
                        speedX = 0;
                        speedY = -26;
                        projectile = "missile";

                    }
                    if (projectile == "done")
                    {
                        state = "wait";
                        GameScreen.ready = true;
                        speedX = 0;
                        speedY = 6;
                        projectile = "";
                    }
                    break;
                case "boomerang":
                    if (projectile == "")
                    {
                        x = ((GameScreen.p.x - (size / 2)) + (GameScreen.p.width / 2));
                        y = GameScreen.p.y - 70;
                        speedX = 0;
                        speedY = -18;
                        projectile = "boomerang";
                    }
                    if (projectile == "done")
                    {
                        state = "wait";
                        GameScreen.ready = true;
                        speedX = 0;
                        speedY = 6;
                        projectile = "";
                    }
                    break;
                case "fireBall":
                    if (projectile == "")
                    {
                        x = ((GameScreen.p.x - (size / 2)) + (GameScreen.p.width / 2));
                        y = GameScreen.p.y - 70;
                        speedX = 0;
                        speedY = -10;
                        projectile = "fireBall";
                    }
                    if (projectile == "done")
                    {
                        state = "wait";
                        GameScreen.ready = true;
                        speedX = 0;
                        speedY = 6;
                        projectile = "";
                    }
                    break;
                case "condor":
                    GameScreen.condorLive = true;
                    GameScreen.condor.speed = -15;
                    GameScreen.condor.x = 1200;
                    GameScreen.condor.y = 200;
                    state = "wait";
                    GameScreen.ready = true;
                    break;
            }
        }

        public void WallCollision(UserControl UC)
        {
            // Collision with left wall
            if (x <= 0)
            {
                speedX *= -1;
            }
            // Collision with right wall
            if (x >= (UC.Width - size))
            {
                speedX *= -1;
            }
            // Collision with top wall
            if (y <= 2)
            {
                if (projectile == "missile") explode(1);
                if (projectile == "turn") speedY = 15;
                if (projectile != "turn") projectile = "done";
            }
        }

        public bool BlockCollision(Block b)
        {
            Rectangle blockRec = new Rectangle(b.x, b.y, b.width, b.height);
            Rectangle PowerUpRec = new Rectangle(x, y, size, size);

            if (PowerUpRec.IntersectsWith(blockRec))
            {
                if (projectile != "boomerang" ) projectile = "done";
            }

            return blockRec.IntersectsWith(PowerUpRec);


        }

        public void BottomCollision(UserControl UC)
        {

            if (y >= UC.Height)
            {
                state = "wait";
                GameScreen.ready = true;
            }

            
        }

        public void explode( int _power)
        {
            projectile = "explotion";
            size = 100;
            y = y - 50;
            x = x - 50;
            for (int i = 1; i <= 20; i++)
            {
                foreach (Block d in GameScreen.blocks)
                {
                    if (BlockCollision(d))
                    {
                        d.hp -= _power;
                        if (d.hp <= 0)
                        {
                            GameScreen.blocks.Remove(d);
                        }
                        break;
                    }
                }
            }
            size = 20;
            y = -size;
            x = -size;
        }

        public void TimerEnd()
        {
            //an indicator to show when a powerUp is close to ending the timer
        }

        public void Stun()
        {
            //stop the paddle from moving for a breif period of time
        }
        public void Create(string _type, int _x, int _y)
        {
            type = _type;
            x = _x;
            y = _y;
            state = "fall";
        }

    }
}
