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
    public partial class Blood_Data_show : Form
    {
        public Blood_Data_show()
        {
            InitializeComponent();
            button2.Visible = false;
            dataGridView1.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            button1.Visible = false;
            button2.Visible = true;
            SqlConnection con = new SqlConnection(@"Data Source=FATMA-TOTA\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from hospitalll where name ='" + comboBox1.Text + "'", con);
            cmd.CommandType = CommandType.Text;
            DataTable types = new DataTable();
            SqlDataReader rdr = cmd.ExecuteReader();
            types.Columns.Add("name");
            types.Columns.Add("O+");
            types.Columns.Add("O-");
            types.Columns.Add("A+");
            types.Columns.Add("A-");
            types.Columns.Add("B+");
            types.Columns.Add("B-");
            types.Columns.Add("AB+");
            types.Columns.Add("AB-");
            types.Columns.Add("mail");
            DataRow Rowss;

            while (rdr.Read())
            {
                Rowss = types.NewRow();
                Rowss["name"] = rdr["name"];
                Rowss["O+"] = rdr["O+"];
                Rowss["O-"] = rdr["O-"];
                Rowss["A+"] = rdr["A+"];
                Rowss["A-"] = rdr["A-"];
                Rowss["B+"] = rdr["B+"];
                Rowss["B-"] = rdr["B-"];
                Rowss["AB+"] = rdr["AB+"];
                Rowss["AB-"] = rdr["AB-"];
                Rowss["mail"] = rdr["mail"];

                types.Rows.Add(Rowss);
            }
            rdr.Close();


            
            
            
            con.Close();
            label1.Visible = false;
            comboBox1.Visible = false;

            dataGridView1.DataSource = types;
            //Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Requests R = new Requests();
            R.Show();
            this.Hide();
        }

        private void Blood_Data_show_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
