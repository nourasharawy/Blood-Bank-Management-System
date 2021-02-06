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
    public partial class delete : Form
    {
        TextBox txt;
        int id;
        string name_table;
        public delete(string choose)
        {
            InitializeComponent();
            name_table = choose;
            txt = textBox1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            id = int.Parse(textBox1.Text);
            MessageBox.Show(functions.delete(txt,id, name_table));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Removes f15 = new Removes();
            f15.Show();
            this.Hide();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            txt = textBox1;
        }
    }
}