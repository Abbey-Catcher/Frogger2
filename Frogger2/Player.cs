﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Frogger2
{
    publi   {
            x = _x;
            y = _y;
        }

        public void Move(string direction)
        {
            if (direction == "up")
            {
                y -= speed;
            }
            if (direction == "down")
            {
                y += speed;
            }
            if (direction == "left")
            {
                x -= speed;
            }
            if (direction == "right")
            {
                x += speed;
            }
        }c class Player
    {
        public int x, y;
        public int speed = 32;
        public int width = 10;
        public int height = 10;
        public int lives = 3;

        public Player(int _x, int _y)
     
    }
}
