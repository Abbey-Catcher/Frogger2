using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger2
{
    internal class Cars
    {
        public int x, y, xSpeed, ySpeed;
        public int size = 20;
        //public Image carImage;

        public Cars (int _x, int _y, int _xSpeed, int _ySpeed)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
        }


        public void Move(int width, int height)
        {
            x += xSpeed;
            //Rectangle car1 = new Rectangle(x, y, height, width);
        }

        //public void Collision(Ball b)
        //{
        //    Rectangle ballRec = new Rectangle(x, y, size, size);
        //    Rectangle ball2Rec = new Rectangle(b.x, b.y, b.size, b.size);

        //    if (ballRec.IntersectsWith(ball2Rec))
        //    {
        //        ySpeed *= -1;
        //    }
        //}

        public bool Collision(Player p)
        {
            Rectangle carRec = new Rectangle(x, y, size, size);
            Rectangle playerRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (carRec.IntersectsWith(playerRec))
            {
                if (ySpeed > 0)
                {
                    p.y = 300;
                    p.x = 300;
                }

                ySpeed *= -1;
                return true;
            }

            return false;
        }
    }
}
