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
    public partial class Removes : Form
    {

        public Removes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Fn d7 = new Admin_Fn();
            d7.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            delete form_del = new delete(button2.Text);
            form_del.Show();
            this.Close();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete form_del = new delete(button3.Text);
            form_del.Show();
            this.Close();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            delete form_del = new delete(button4.Text);
            form_del.Show();
            this.Close();
            this.Hide();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}