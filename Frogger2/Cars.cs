using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger2
{
    internal class Cars
    {
        public int x, y, xSpeed, ySpeed;
        public int size = 20;

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
            y += ySpeed;

            if (x > width - size || x < 0)
            {
                xSpeed *= -1;
            }

            if (y > height - size || y < 0)
            {
                ySpeed *= -1;
            }
        }
    }
}
