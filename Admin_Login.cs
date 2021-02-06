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
    public partial class admin_login : Form
    {
        public admin_login()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 100;
        }

        string[] UserName = { "Admin" };
        string[] Password = { "Admin" };
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserName.Contains(textBox1.Text) && Password.Contains(textBox2.Text))
            {
                Admin_Fn f10 = new Admin_Fn();
                this.Hide();
                f10.Show();
            }
            else
                MessageBox.Show("Error");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login d7 = new Login("LOGIN");
            d7.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
