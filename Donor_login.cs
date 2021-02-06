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
    public partial class Donor : Form
    {
        public Donor()
        {
            string type;
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 100;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection com = new SqlConnection(@"Data Source=FATMA-TOTA\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            string Quary = "Select * From Donor_inf Where mail = '" + textBox1.Text.Trim() + "' and password = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Quary, com);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            if (tb.Rows.Count == 1)
            {
                doonoor f5 = new doonoor("LOGIN", textBox1.Text);
                this.Hide();
                f5.Show();

            }
            else
                MessageBox.Show("Error");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
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
