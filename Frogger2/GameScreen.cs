﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogger2
{
    //TO DO:

    //Proper end point

    public partial class GameScreen : UserControl
    {
        //Obstacles
        List<Cars> cars = new List<Cars>();
        List<Logs> logs = new List<Logs>();
        List<Trees> trees = new List<Trees>();

        Player hero;

        //control keys
        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;
        bool downDown = false;

        bool canMove = true;

        int playCounter, Ccounter, L1counter, L2counter;

        Pen frogPen = new Pen(Color.DarkGreen, 10);
        Brush blueBrush = new SolidBrush(Color.DarkBlue);
        Brush grayBrush = new SolidBrush(Color.DarkGray);
        Brush TestBrush = new SolidBrush(Color.Red);

        Rectangle waterway = new Rectangle(0, 60, 610, 30);
        Rectangle waterway2 = new Rectangle(0, 150, 610, 30);
        Rectangle roadway = new Rectangle(0, 240, 610, 30);
        Rectangle endPoint = new Rectangle(285, 5, 40, 15);

        Image log = Properties.Resources.FroggerLog;
        Image tree = Properties.Resources.Tree_Frogger;
        Image car = Properties.Resources.car_Frogger;
        Image frog = Properties.Resources.Frog;

        string Finish = "finish!";


        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {
            hero = new Player(300, 310);
            livesLabel.Text = "Lives: " + hero.lives;

            Trees newTree = new Trees(60, 280);
            trees.Add(newTree);

            Trees newTree2 = new Trees(this.Width - 60, 190);
            trees.Add(newTree2);

            Trees newTree3 = new Trees(140, 100);
            trees.Add(newTree3);
        }

        private void keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                upDown = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                downDown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                leftDown = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                rightDown = false;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            playCounter++;
            if (playCounter == 15)
            {
                canMove = true;
            }

            if (upDown && hero.y > 0 && canMove)
            {
                hero.Move("up");
                canMove = false;
                playCounter = 0;
                frog.RotateFlip(RotateFlipType.RotateNoneFlipNone);
            }
            if (downDown && hero.y < this.Height - hero.height && canMove)
            {
                hero.Move("down");
                canMove = false;
                playCounter = 0;
                frog.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            if (leftDown && hero.x > 0 && canMove)
            {
                hero.Move("left");
                canMove = false;
                playCounter = 0;
                frog.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            if (rightDown && hero.x < this.Width - hero.width && canMove)
            {
                hero.Move("right");
                canMove = false;
                playCounter = 0;
                frog.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            frog.RotateFlip(RotateFlipType.RotateNoneFlipNone);

            //create obstacles
            Ccounter++;
            if (Ccounter > 50 && Ccounter < 100)
            {
                Cars newCar = new Cars(this.Width, 245, 5, 5);
                cars.Add(newCar);
                Ccounter = 0;
            }
            L1counter++;
            if (L1counter > 35 && L1counter <  100) 
            { 
                Logs newLog = new Logs(0, 155, 5, 5);
                logs.Add(newLog);
                L1counter = 0;
            }
            L2counter++;
            if (L2counter > 30 && L2counter < 75)
            {
                Logs newLog = new Logs(0, 65, 5, 5);
                logs.Add(newLog);
                L2counter = 0;
            }


            //move obstacles
            foreach (Cars c in cars)
            {
                c.Move(this.Width, this.Height);
            }
            foreach (Logs l in logs)
            {
                l.Move(this.Width, this.Height);
            }

            //remove off screen
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].x >= 600 || cars[i].x < 0)
                {
                    cars.RemoveAt(i);
                }
            }
            for (int i = 0; i < logs.Count; i++)
            {
                if (logs[i].x >= 600)
                {
                    logs.RemoveAt(i);
                }
            }

            //collision
            foreach (Cars c in cars)
            {
                if (c.Collision(hero))
                {
                    hero.lives -= 1;
                    livesLabel.Text = "Lives: " + hero.lives;
                }
            }
            foreach (Logs l in logs)
            {
                if (l.Collision(hero))
                {
                    hero.lives -= 1;
                    livesLabel.Text = "Lives: " + hero.lives;
                }
            }
            
            //Player dies
            if (hero.lives == 0)
            {
                gameTimer.Stop();
                Form1.ChangeScreen(this, new LoseScreen());
            }
            //Player wins
            if (hero.y <= endPoint.Bottom)
            {
                gameTimer.Stop();
                Form1.ChangeScreen(this, new WinScreen());
            }

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, waterway);
            e.Graphics.FillRectangle(blueBrush, waterway2);
            e.Graphics.FillRectangle(grayBrush, roadway);
            e.Graphics.DrawString(Finish, DefaultFont, TestBrush, endPoint);
            foreach (Cars c in cars)
            {
                e.Graphics.DrawImage(car, c.x, c.y, -40, 20);
            }
            foreach (Logs l in logs)
            {
                e.Graphics.DrawImage(log, l.x, l.y, 40, 20);
            }
            foreach (Trees t in trees)
            {
                e.Graphics.DrawImage(tree, t.x, t.y, 45, 40);
            }
            e.Graphics.DrawImage(frog, hero.x, hero.y);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                upDown = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                downDown = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                leftDown = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                rightDown = true;
            }

        }
    }
}
