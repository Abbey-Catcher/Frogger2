using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Frogger2
{
    public partial class GameScreen : UserControl
    {
        Player hero;

        //Cars carObstacle;
        List<Cars> cars = new List<Cars>();
        List<Logs> logs = new List<Logs>();

        int Ccounter, L1counter, L2counter = 0;

        //control keys
        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;
        bool downDown = false;

        Pen frogPen = new Pen(Color.DarkGreen, 10);
        Brush blueBrush = new SolidBrush(Color.DarkBlue);
        Brush grayBrush = new SolidBrush(Color.DarkGray);
        Brush TestBrush = new SolidBrush(Color.Red);
        Brush LogBrush = new SolidBrush(Color.Brown);


        Rectangle waterway = new Rectangle(0, 30, 610, 30);
        Rectangle waterway2 = new Rectangle(0, 120, 610, 30);
        Rectangle roadway = new Rectangle(0, 200, 610, 30);

        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {
            hero = new Player(300, 300);
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
            if (upDown == true && hero.y > 0)
            {
                hero.Move("up");
            }
            if (downDown == true && hero.y < this.Height - hero.height)
            {
                hero.Move("down");
            }
            if (leftDown == true && hero.x > 0)
            {
                hero.Move("left");
            }
            if (rightDown == true && hero.x < this.Width - hero.width)
            {
                hero.Move("right");
            }

            //create obstacles
            Ccounter++;
            if (Ccounter > 50 && Ccounter < 100)
            {
                Cars newCar = new Cars(0, 205, 5, 5);
                //newCar.carImage = Properties.Resources.car_Frogger;
                cars.Add(newCar);
                Ccounter = 0;
            }
            L1counter++;
            if (L1counter > 25 && L1counter <  100) 
            { 
                Logs newLog = new Logs(0, 125, 5, 5);
                logs.Add(newLog);
                L1counter = 0;
            }
            L2counter++;
            if (L2counter > 25 && L2counter < 100)
            {
                Logs newLog = new Logs(0, 35, 5, 5);
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
                if (cars[i].x >= 600)
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
                    hero.x = 300;
                    hero.y = 300;
                }
            }
            foreach (Logs l in logs)
            {
                if (l.Collision(hero))
                {
                    hero.lives -= 1;
                    hero.x = 300;
                    hero.y = 300;
                }
            }
            
            //Player dies
            if (hero.lives == 0)
            {
                gameTimer.Stop();
            }

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(frogPen, hero.x, hero.y, 10, 10);
            e.Graphics.FillRectangle(blueBrush, waterway);
            e.Graphics.FillRectangle(blueBrush, waterway2);
            e.Graphics.FillRectangle(grayBrush, roadway);
            foreach (Cars c in cars)
            {
                //e.Graphics.FillRectangle(TestBrush, c.x, c.y, c.sizeL, c.sizeW);
                e.Graphics.DrawImage(Properties.Resources.car_Frogger, c.x, c.y);
            }
            foreach (Logs l in logs)
            {
                e.Graphics.FillRectangle(TestBrush, l.x, l.y, l.sizeL, l.sizeL);
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
