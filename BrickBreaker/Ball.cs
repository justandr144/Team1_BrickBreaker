using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public int tempX, tempY, x, y, xSpeed, ySpeed, size, strength, defaultSpeed;
        public Color colour;
        public bool bounce = true;
        public static Random rand = new Random();
        int temp;

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed, int _ballSize, int _defaultSpeed, int _strength, bool _bounce)
        {
            x = _x;
            y = _y;
            tempX = x + xSpeed;
            tempY = y + ySpeed;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            size = _ballSize;
            defaultSpeed = _defaultSpeed;
            bounce = _bounce;
            strength = _strength;
        }

        public void Move()
        {
            x += xSpeed;
            y += ySpeed;
        }

        public bool BlockCollision(Block b)
        {
            Rectangle blockRec = new Rectangle(b.x, b.y, b.width, b.height);
            Rectangle topBlockRec = new Rectangle(b.x, b.y, b.width, 1);
            Rectangle leftBlockRec = new Rectangle(b.x, b.y, 1, b.height);
            Rectangle rightBlockRec = new Rectangle(b.x, b.y, 1, b.height);
            Rectangle bottomBlockRec = new Rectangle(b.x, b.y + 22, b.width, 1);
            Rectangle ballRec = new Rectangle(x, y, size, size);

            if (ballRec.IntersectsWith(topBlockRec) && bounce || ballRec.IntersectsWith(bottomBlockRec) && bounce)
            {
                ySpeed *= -1;
            }

            if (ballRec.IntersectsWith(leftBlockRec) && bounce || ballRec.IntersectsWith(rightBlockRec) && bounce)
            {
                xSpeed *= -1;
            }

            if (ballRec.IntersectsWith(blockRec) && bounce && GameScreen.ballBlockBouceTimer <= 0)
            {
                b.hp -= strength;
                b.crackCount++;

                if (b.hp <= 0)
                {                   
                    GameScreen.blocks.Remove(b);
                    GameScreen.score++;
                }
                GameScreen.ballBlockBouceTimer = 2;
            }

            return blockRec.IntersectsWith(ballRec);
        }

        public void PaddleCollision(Paddle p, Ball ball)
        {
            Rectangle ballRec = new Rectangle(x + xSpeed, y + ySpeed, size, size);
            Rectangle topPaddleRec = new Rectangle(p.x - 2, p.y - 2, p.width, 1);
            Rectangle leftPaddleRec = new Rectangle(p.x - 4, p.y - 2, 1, p.height + 4);
            Rectangle rightPaddleRec = new Rectangle(p.x + 84, p.y - 2, 1, p.height + 4);
            Rectangle bottomPaddleRec = new Rectangle(p.x - 2, p.y + 22, p.width, 1);

            if (ballRec.IntersectsWith(topPaddleRec) && ballRec.IntersectsWith(leftPaddleRec) ||
                ballRec.IntersectsWith(topPaddleRec) && ballRec.IntersectsWith(rightPaddleRec))
            {
                if (x > p.x && ySpeed > 0)
                {
                    DifferentAngles();
                    ySpeed *= -1;
                }
                else if (x < p.x && ySpeed > 0)
                {
                    DifferentAngles();
                    xSpeed *= -1;
                }
            }
            if (ballRec.IntersectsWith(topPaddleRec) || ballRec.IntersectsWith(bottomPaddleRec))
            {
                DifferentAngles();
                ySpeed *= -1;
            }
            if (ballRec.IntersectsWith(leftPaddleRec) || ballRec.IntersectsWith(rightPaddleRec))
            {
                DifferentAngles();
                xSpeed *= -1;
            }
        }

        public void WallCollision(UserControl UC)
        {
            int xOld = x;
            int yOld = y;
            //Collision with left wall
            if (x <= 0)
            {
                x = xOld + 5;
                DifferentAngles();
                xSpeed *= -1;

            }

            //Collision with right wall
            if (x >= (UC.Width - size - 1))
            {
                x = xOld - 5;
                DifferentAngles();
                xSpeed *= -1;
            }
            // Collision with top wall
            if (y <= 70 + 5)
            {
                y = yOld + 5;
                DifferentAngles();
                ySpeed *= -1;
            }
        }

        public bool BottomCollision(UserControl UC)
        {
            Boolean didCollide = false;

            if (y >= UC.Height)
            {
                didCollide = true;
            }

            return didCollide;
        }

        public void DifferentAngles()
        {
            int xDifAngle = rand.Next(0, 2);
            int yDifAngle = rand.Next(0, 2);

            if (xSpeed > 0)
            {
                xSpeed = defaultSpeed;
                xSpeed += xDifAngle;
            }
            else
            {
                xSpeed = -defaultSpeed;
                xSpeed -= xDifAngle;
            }

            if (ySpeed > 0)
            {
                ySpeed = defaultSpeed;
                ySpeed += yDifAngle;
            }
            else
            {
                ySpeed = -defaultSpeed;
                ySpeed -= yDifAngle;
            }
        }
    }
}