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
            ChangeScreen(this, new MainScreen());
        }

        public static void ChangeScreen(Form f, UserControl next)
        {
            MainScreen ms = new MainScreen();

            ms.Location = new Point((f.ClientSize.Width - ms.Width) / 2,
                (f.ClientSize.Height - ms.Height) / 2);

            f.Controls.Add(ms);
            next.Focus();
        }
        
        public static void ChangeScreen2(UserControl current, UserControl next)
        {
            Form f = current.FindForm();
            f.Controls.Remove(current);

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);

            next.Focus();
            f.Controls.Add(next);
        }
    }
}
