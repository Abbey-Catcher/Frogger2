﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger2
{
    internal class Player
    {
        public int x, y;
        public int speed = 6;
        public int width = 30;
        public int height = 10;

        public Player(int_x, int_y)
        {
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
        }
    }
}