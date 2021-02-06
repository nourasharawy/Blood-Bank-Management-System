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
    public partial class Dispaly : Form
    {
        public Dispaly()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisData f14 = new DisData(button2.Text);
            f14.Show();
            this.Close();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisData f14 = new DisData(button3.Text);
            f14.Show();
            this.Close();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DisData f14 = new DisData(button4.Text);
            f14.Show();
            this.Close();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Fn f12 = new Admin_Fn();
            f12.Show();
            this.Hide();
        }
    }
}
