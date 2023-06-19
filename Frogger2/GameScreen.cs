using System;
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
        bool imageU = false;
        bool imageD = false;
        bool imageR = false;
        bool imageL = false;

        int playCounter, Ccounter, L1counter, L2counter, orientation;

        Pen pointPen = new Pen(Color.Red, 10);
        Brush blueBrush = new SolidBrush(Color.DarkBlue);
        Brush grayBrush = new SolidBrush(Color.DarkGray);
        Brush TestBrush = new SolidBrush(Color.Red);

        Font Font = new Font("TimesNewRoman", 16);

        Rectangle waterway = new Rectangle(0, 90, 610, 30);
        Rectangle waterway2 = new Rectangle(0, 180, 610, 30);
        Rectangle roadway = new Rectangle(0, 270, 610, 30);
        Rectangle endPoint = new Rectangle(285, 5, 70, 20);

        Image log = Properties.Resources.FroggerLog;
        Image tree = Properties.Resources.Tree_Frogger;
        Image car = Properties.Resources.car_Frogger;

        Image frogU = Properties.Resources.Frog;
        Image frogR = Properties.Resources.FrogRight;
        Image frogL = Properties.Resources.FrogLeft;
        Image frogD = Properties.Resources.FrogDown;

        string Finish = "finish!";


        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {
            imageU = true;
            hero = new Player(120, 310);
            livesLabel.Text = "Lives: " + hero.lives;

            Trees newTree = new Trees(60, 310);
            trees.Add(newTree);

            Trees newTree2 = new Trees(this.Width - 60, 220);
            trees.Add(newTree2);

            Trees newTree3 = new Trees(140, 130);
            trees.Add(newTree3);
        }

        private void keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                upDown = false;
                imageU = true;
                imageD = false;
                imageR = false;
                imageL = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                downDown = false;
                imageD = true;
                imageU = false;
                imageR = false;
                imageL = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                leftDown = false;
                imageL = true;
                imageD = false;
                imageR = false;
                imageU = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                rightDown = false;
                imageR = true;
                imageD = false;
                imageU = false;
                imageL = false;
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
            }
            if (downDown && hero.y < this.Height - hero.height && canMove)
            {
                hero.Move("down");
                canMove = false;
                playCounter = 0;
            }
            if (leftDown && hero.x > 0 && canMove)
            {
                hero.Move("left");
                canMove = false;
                playCounter = 0;
            }
            if (rightDown && hero.x < this.Width - hero.width && canMove)
            {
                hero.Move("right");
                canMove = false;
                playCounter = 0;
            }

            //create obstacles
            Ccounter++;
            if (Ccounter > 50 && Ccounter < 100)
            {
                Cars newCar = new Cars(this.Width, 275, 5, 5);
                cars.Add(newCar);
                Ccounter = 0;
            }
            L1counter++;
            if (L1counter > 35 && L1counter <  100) 
            { 
                Logs newLog = new Logs(0, 185, 5, 5);
                logs.Add(newLog);
                L1counter = 0;
            }
            L2counter++;
            if (L2counter > 30 && L2counter < 75)
            {
                Logs newLog = new Logs(0, 95, 5, 5);
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
            e.Graphics.DrawString(Finish, Font, TestBrush, endPoint);
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

            if (imageU)
            {
                e.Graphics.DrawImage(frogU, hero.x, hero.y);
            }
            if (imageD)
            {
                e.Graphics.DrawImage(frogD, hero.x, hero.y);
            }
            if (imageL)
            {
                e.Graphics.DrawImage(frogL, hero.x, hero.y);
            }
            if (imageR)
            {
                e.Graphics.DrawImage(frogR, hero.x, hero.y);
            }
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
