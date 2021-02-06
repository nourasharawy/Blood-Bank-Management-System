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
using System.Text.RegularExpressions;
namespace _1
{
    public partial class Res_login : Form
    {
        public Res_login()
        {
            InitializeComponent();
            
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 100;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection com = new SqlConnection(@"Data Source=FATMA-TOTA\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            string Quary = "Select * From recipient Where mail = '" + textBox1.Text.Trim() + "' and password = '" + textBox2.Text.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(Quary,com);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            if (tb.Rows.Count == 1)
            {
                Reci f6 = new Reci("LOGIN",textBox1.Text);
                f6.Show();
                this.Hide();

            }
            else
                MessageBox.Show("Enter your right data OR registe ");


            
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login d7 = new Login("LOGIN");
            d7.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
             string pattern = @"^([0-9a-zA-Z]" + //Start with a digit or alphabetical
   @"([\+\-_\.][0-9a-zA-Z]+)*" + // No continuous or ending +-_. chars in email
   @")+" +
   @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";

            if (Regex.IsMatch(textBox1.Text, pattern))
            {
                errorProvider1.Clear();
            }

            else
            {

                errorProvider1.SetError(this.textBox1, "Please Enter Correct Email");
                return;
            }
        
        }
    }
}
