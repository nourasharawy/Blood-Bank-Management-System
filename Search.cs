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
    public partial class Blood : Form
    {
        public Blood()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            button1.Visible = false;
           
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
            MessageBox.Show("If you want request blood, you must register *_^");
            //Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            first_page f = new first_page();
            f.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
