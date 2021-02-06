using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Login : Form
    {
        string typee;
        public Login( string type)
        {
            InitializeComponent();
            typee = type;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_login d6 = new admin_login();
            d6.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Res_login f10 = new Res_login();
            this.Hide();
            f10.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Donor f10 = new Donor();
            this.Hide();
            f10.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            first_page d7 = new first_page();
            d7.Show();
            this.Hide();
        }
    }
}
