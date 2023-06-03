using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger2
{
    public class Logs
    {
        public int x, y, xSpeed, ySpeed;
        public int sizeL = 20;
        public int sizeW = 12;

        public Logs(int _x, int _y, int _xSpeed, int _ySpeed)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
        }

        public void Move(int width, int height)
        {
            x += xSpeed;
        }

        public bool Collision(Player p)
        {
            Rectangle logRec = new Rectangle(x, y, sizeL, sizeW);
            Rectangle playerRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (logRec.IntersectsWith(playerRec))
            {
                if (ySpeed > 0)
                {
                    y = p.y - sizeW;
                }
                else
                {
                    y = p.y + p.height;
                }

                ySpeed *= -1;
                return true;
            }

            return false;
        }
    }
}
