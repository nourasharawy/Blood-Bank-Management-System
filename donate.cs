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
    public partial class donate : Form
    {
        string email;
        public donate(string mail)
        {
            InitializeComponent();
            email = mail;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            register d6 = new register("REG");
            d6.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=FATMA-TOTA\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();


            SqlCommand cmd1 = new SqlCommand("donateblood", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter1_1 = new SqlParameter("@typeofblood", comboBox1.Text);

            cmd1.Parameters.Add(parameter1_1);

            cmd1.ExecuteNonQuery();

            int blood_id = (int)cmd1.ExecuteScalar();
            SqlCommand cmd3 = new SqlCommand("donatebloodform_doner", con);
            cmd3.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter3_1 = new SqlParameter("@email_doner", email);

            cmd3.Parameters.Add(parameter3_1);
            cmd3.ExecuteNonQuery();

            int donor_id = (int)cmd3.ExecuteScalar();
            SqlCommand cmd4 = new SqlCommand("donate_ID_doner__date_blood", con);
            cmd4.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter4_1 = new SqlParameter("@ID_donor", donor_id);
            cmd4.Parameters.Add(parameter4_1);
            SqlParameter parameter4_2 = new SqlParameter("@ID_blood", blood_id);
            cmd4.Parameters.Add(parameter4_2);
            SqlParameter parameter4_3 = new SqlParameter("@Expire_date", dateTimePicker2.Text);
            cmd4.Parameters.Add(parameter4_3);
            SqlParameter parameter4_4 = new SqlParameter("@recieve_date", dateTimePicker1.Text);
            cmd4.Parameters.Add(parameter4_4);
            cmd4.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Done Sir");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void donate_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            dt = dt.AddDays(7);
            dateTimePicker2.Text = dt.ToShortDateString();
        }
    }
}
