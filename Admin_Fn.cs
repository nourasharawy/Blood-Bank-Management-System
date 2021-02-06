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
    public partial class Admin_Fn : Form
    {
        public Admin_Fn()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Edit f10 = new Edit();
            f10.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ADD d7 = new ADD();
            d7.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Removes f15 = new Removes();
            this.Hide();
            f15.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dispaly f10 = new Dispaly();
            this.Hide();
            f10.Show();
        }
    }
}
