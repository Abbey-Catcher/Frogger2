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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            MainScreen ms = new MainScreen();
            this.Controls.Add(ms);
        }
        
        public static void ChangeScreen(UserControl current, UserControl next)
        {
            Form f = current.FindForm();
            f.Controls.Remove(current);

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);

            //make form1 the same size as new screens
            f.Controls.Add(next);
            next.Focus();
        }
    }
}
