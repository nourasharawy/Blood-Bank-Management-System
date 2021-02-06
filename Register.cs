using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class register : Form
    {
        string typee;
        public register(string type)
        {
            InitializeComponent();
            typee = type;
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            first_page d7 = new first_page();
            d7.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* Form9 d6=new Form9 ();
            d6.Show ();
            this.Hide ();
            */
            
        }

        private void Form8_Load(object sender, EventArgs e)
        {
           /* doonoor d6 = new doonoor();
            d6.Show();
            this.Hide();
        */}

        private void button2_Click(object sender, EventArgs e)
        {
            doonoor d6 = new doonoor(typee,"");
            d6.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Reci d5 = new Reci(typee,"");
            d5.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            donate d6 = new donate("");
            d6.Show();
            this.Hide();
        }
    }
}
