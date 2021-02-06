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
    public partial class ADD : Form
    {
        public ADD()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           doonoor d7 = new doonoor("REG","");
            d7.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reci d7 = new Reci("REG","");
            d7.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Fn d7 = new Admin_Fn();
            d7.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Blood_ADD d7 = new Blood_ADD();
            d7.Show();
            this.Hide();
        }
    }
}
