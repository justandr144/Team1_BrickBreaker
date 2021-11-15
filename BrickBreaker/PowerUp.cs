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
            //1-up mushroom(1 life increase)                        
        //Pac man cherry(score increase)                        
            //Tanooki suit(mario tail) (slows the ball speed)       
            //Mushroom(increases paddle size)
            //Megaman buzzsaw (increases the strenth of ball to 2)
        //
        //Fire flower(Shoot projectile on an angle, break block and self on contact)          
        //Zelda  bow and arrow(Shoot projectile, break block and break self onb contact)               
        //Koopa shell(shells that act like ball but won't count towards lives)   
        //Metroid bomb (explodes in an area if doesn't hit any bricks falls back down)  
        //Dk barrel (??) 

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
        public int Speed = 1;
        public string state = "fall";
        public int x, y;
        public int size = 10;
        public int timer = 500;
        //check variable will check for the creation of a powerUp.
        public Boolean check;
        
        public PowerUp(int _x, int _y, string _type)
        {
            x = _x;
            y = _y;
            type = _type;
        }

        public void Move()
        {
            y += Speed;
        }

        public void Active()
        {
            state = "power";
        }

        public void Collision(int _paddleX, int _paddleY, int _paddleH, int _PaddleW)
        {
            Rectangle paddleRec = new Rectangle(_paddleX, _paddleY, _PaddleW, _paddleH);
            Rectangle powerUpRec = new Rectangle(x, y, size, size);

            if (paddleRec.IntersectsWith(powerUpRec))
            {
                //prepare for new state
                x = 0;
                y = 0;
                state = "activate";
            }

        }

        public void UsingPowerUp()
        {
            switch (type)
            {
                case "1-up":
                    x = -size;
                    y = -size;
                    GameScreen.lives++;
                    state = "wait";
                    break;
                case "mushroom":
                    //add an indicator to show when it is over (standard for all power ups)
                    x = -size;
                    y = -size;
                    timer--;
                    if (timer > 0)
                    {
                        GameScreen.paddle.width = 160;
                    }
                    else
                    {
                        GameScreen.paddle.width = 80;
                        state = "wait";
                        timer = 500;
                    }
                    break;
                case "tanooki":
                    x = -size;
                    y = -size;
                    timer--;
                    if (timer > 0)
                    {
                        if (GameScreen.ball.xSpeed < 0)
                        {
                            GameScreen.ball.xSpeed = -3;
                        }
                        else GameScreen.ball.xSpeed = 3;
                        if (GameScreen.ball.ySpeed < 0)
                        {
                            GameScreen.ball.ySpeed = -3;
                        }
                        else GameScreen.ball.ySpeed = 3;
                        
                    }
                    else
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
                        state = "wait";
                        timer = 500;
                    }
                    break;
                case "buzzsaw":
                    x = -size;
                    y = -size;
                    timer--;
                    if (timer > 0)
                    {
                        GameScreen.ball.strength = 2;
                    }
                    else
                    {
                        GameScreen.ball.strength = 1;
                        state = "wait";
                        timer = 500;
                    }
                    break;
                case "star":
                    //add an indicator to show when it is over (standard for all power ups)
                    x = -size;
                    y = -size;
                    timer--;
                    if (timer > 0)
                    {
                        if (GameScreen.ball.xSpeed < 0)
                        {
                            GameScreen.ball.xSpeed = -9;
                        }
                        else GameScreen.ball.xSpeed = 9;
                        if (GameScreen.ball.ySpeed < 0)
                        {
                            GameScreen.ball.ySpeed = -9;
                        }
                        else GameScreen.ball.ySpeed = 9;
                        GameScreen.ball.strength = 999;

                    }
                    else
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
                        GameScreen.ball.strength = 1;
                        state = "wait";
                        timer = 500;
                    }
                    break;

            }
        }

        public void TimerEnd()
        {
            //an indicator to show when a powerUp is close to ending the timer
        }
    }
}
