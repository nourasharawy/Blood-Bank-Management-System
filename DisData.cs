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
    
    public partial class DisData : Form
    {
      
        public DisData(string choose)
        {
            InitializeComponent();
           Display.DataSource = functions.Display_data(choose);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Form14_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispaly f9 = new Dispaly();
            f9.Show();
            this.Hide();
        }
    }
}
