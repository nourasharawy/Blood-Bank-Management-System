using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _1
{
    
    public partial class Edit : Form
    {

        string type = "REG";
        public Edit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {



            Donor f7 = new Donor();
            f7.Show();            
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Fn f10 = new Admin_Fn();
            f10.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Res_login f10 = new Res_login();
            f10.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = true;
            button6.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Blood_ADD DD = new Blood_ADD();
            DD.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            delete l = new delete("BLOOD");
            l.Show();
            this.Hide();
        }
    }
}
