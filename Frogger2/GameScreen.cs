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
        Player hero;

        Cars carObstacle;
        List<Cars> balls = new List<Cars>();

        //control keys
        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;
        bool downDown = false;

        Pen frogPen = new Pen(Color.DarkGreen, 10);

        public GameScreen()
        {
            InitializeComponent();

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (upDown && hero.y > 0)
            {
                hero.Move("up");
            }
            if (downDown && hero.y < this.Height - hero.height)
            {
                hero.Move("down");
            }
            if (leftDown && hero.x > 0)
            {
                hero.Move("left");
            }
            if (rightDown && hero.x < this.Width - hero.width)
            {
                hero.Move("right");
            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(frogPen, 20, 20, 20, 20);

            //if frog moves up, water row moves down
        }
    }
}
