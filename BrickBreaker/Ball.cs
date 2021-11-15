using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public int tempX, tempY, x, y, xSpeed, ySpeed, size;
        public Color colour;

        public static Random rand = new Random();

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed, int _ballSize)
        {
            x = _x;
            y = _y;
            tempX = x + xSpeed;
            tempY = y + ySpeed;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            size = _ballSize;

        }

        public void Move()
        {
            x = x + xSpeed;
            y = y + ySpeed;
        }

        public bool BlockCollision(Block b)
        {
            Rectangle blockRec = new Rectangle(b.x, b.y, b.width, b.height);
            Rectangle ballRec = new Rectangle(x, y, size, size);

            if (ballRec.IntersectsWith(blockRec))
            {
                ySpeed *= -1;
            }

            return blockRec.IntersectsWith(ballRec);
        }

        public void PaddleCollision(Paddle p)
        {
            Rectangle ballRec = new Rectangle(x + xSpeed, y + ySpeed, size, size);
            Rectangle topPaddleRec = new Rectangle(p.x + 1, p.y, 78, 1);
            Rectangle leftPaddleRec = new Rectangle(p.x -1, p.y, 1, p.height);
            Rectangle rightPaddleRec = new Rectangle(p.x + 80, p.y, 1, p.height);
            Rectangle bottomPaddleRec = new Rectangle(p.x + 1, p.y + 19, 78, 1);

            if (ballRec.IntersectsWith(leftPaddleRec) || ballRec.IntersectsWith(rightPaddleRec))
            {
                xSpeed *= -1;
            }
            else if (ballRec.IntersectsWith(topPaddleRec))
            {
                ySpeed *= -1;
            }
            else if (ballRec.IntersectsWith(bottomPaddleRec))
            {
                ySpeed *= -1;
            }
        }

        public void WallCollision(UserControl UC)
        {
            // Collision with left wall
            if (x <= 0)
            {
                xSpeed *= -1;
            }
            // Collision with right wall
            if (x >= (UC.Width - size))
            {
                xSpeed *= -1;
            }
            // Collision with top wall
            if (y <= 2)
            {
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

    }
}
