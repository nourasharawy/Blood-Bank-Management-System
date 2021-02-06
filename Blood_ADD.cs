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
    public partial class Blood_ADD : Form
    {
        public Blood_ADD()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboBox1.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=FATMA-TOTA\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
                con.Open();
                if (comboBox1.Text == "O+")
                {
                    SqlCommand co = new SqlCommand("Select O+ ,count(*) from hospital where name ='"+"Helal"+"'",con);
                    string insertd = @"insert into hospital (O+)
                   values (@type)";
                    string counter = co.ToString();
                    int coun = int.Parse(counter);
                    coun = coun+1;
                    string cc = coun.ToString();
                    SqlCommand cmd = new SqlCommand(insertd, con);

                SqlParameter param1 = new SqlParameter("@type", cc);
                cmd.Parameters.Add(param1);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("done enter data");
                }
                /*string insertd = @"insert into blood (type)
                   values (@type)";*/
                
            }
            else if (comboBox1.Text == "")
                MessageBox.Show("please enter your data");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {




            if (comboBox1.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=FATMA-TOTA\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
                con.Open();
                string insertd = @"insert into hospitall (type)
                   values (@type)";
                SqlCommand cmd = new SqlCommand(insertd, con);

                SqlParameter param1 = new SqlParameter("@type", comboBox1.Text);
                cmd.Parameters.Add(param1);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("done enter data");
            }
            else if (comboBox1.Text == "")
                MessageBox.Show("please enter your data");

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Blood_ADD_Load(object sender, EventArgs e)
        {

        }
        }
    }

