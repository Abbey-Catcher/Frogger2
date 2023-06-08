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


        public Cars (int _x, int _y, int _xSpeed, int _ySpeed)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;

            //return Form1.GameScreen(GameScreen.Width, GameScreen.Height);
        }


        public void Move(int width, int height)
        {
            //x = GameScreen.Width;
            x -= xSpeed;        
        }

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
