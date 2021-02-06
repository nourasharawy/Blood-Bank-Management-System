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
   
    public partial class first_page : Form
    {
        string type;
        public first_page()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            type = "REG";
            register d6 = new register(type);
            d6.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            type = "LOGIN";
            Login d6 = new Login(type);
            d6.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Blood B = new Blood();
            B.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            donate f7 = new donate("");
            f7.Show();
            this.Hide();
        }
    }
}
