using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
namespace _1
{
    public partial class Requests : Form
    {
        public Requests()
        {
            InitializeComponent();
            textBox3.PasswordChar = '*';
            textBox3.MaxLength = 100;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Blood_Data_show D = new Blood_Data_show();
            D.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=FATMA-TOTA\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SmtpClient client = new SmtpClient("smtp.gmail.com",587);
            client.Credentials = new NetworkCredential(textBox2.Text,textBox3.Text);
            client.EnableSsl = true;
            MailMessage mesaage = new MailMessage(textBox2.Text, textBox5.Text,textBox4.Text,textBox6.Text);
            mesaage.IsBodyHtml = false;
            client.Send(mesaage);
            MessageBox.Show("sended");


            SqlCommand cmd1 = new SqlCommand("requestblood", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter1_1 = new SqlParameter("@typeofblood", comboBox1.Text);

            cmd1.Parameters.Add(parameter1_1);

            cmd1.ExecuteNonQuery();

            int blood_id = (int)cmd1.ExecuteScalar();

            
            SqlCommand cmd3 = new SqlCommand("requestbloodform_reci", con);
            cmd3.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter3_1 = new SqlParameter("@email_res", textBox2.Text);
            cmd3.Parameters.Add(parameter3_1);
            cmd3.ExecuteNonQuery();

            int res_id = (int)cmd3.ExecuteScalar();
            SqlCommand cmd4 = new SqlCommand("res_ID_res__date_blood", con);
            cmd4.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter4_1 = new SqlParameter("@ID_res", res_id);
            cmd4.Parameters.Add(parameter4_1);
            SqlParameter parameter4_2 = new SqlParameter("@ID_blood", blood_id);
            cmd4.Parameters.Add(parameter4_2);
            SqlParameter parameter4_3 = new SqlParameter("@hospital", textBox4.Text);
            cmd4.Parameters.Add(parameter4_3);
            
            cmd4.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Done Sir");
        }
    }
}
