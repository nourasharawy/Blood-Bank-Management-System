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
using System.IO;
using System.Text.RegularExpressions;
namespace _1
{
    public partial class Reci : Form
    {
        string imgloc = "";
        
        TextBox txt;
        string typee;
        public  Reci(string type,string maill)
        {
            InitializeComponent();
            //request.Visible = false;
            txt = textBox3;
            typee = type;
            if (typee == "REG")
            {
                button5.Visible = false;
                user.Visible = false;
                age.Visible = false;
                gender.Visible = false;
                mail.Visible = false;
                password.Visible = false;
                phone.Visible = false;
                linkLabel1.Visible = false;
                linkLabel2.Visible = false;
                linkLabel3.Visible = false;
                linkLabel4.Visible = false;
                linkLabel5.Visible = false;
                linkLabel6.Visible = false;
                request.Visible = false;
                
            }
            else if (type == "LOGIN")
            {
                request.Visible = true;
                button3.Visible = false;
                button2.Visible = false;
                button1.Visible = false;
                name_res.Visible = false;
                age_res.Visible = false;
                comboBox1.Visible = false;
                textBox3.Visible = false;
                textBox2.Visible = false;
                textBox1.Visible = false;
                user.Visible = true;
                age.Visible = true;
                gender.Visible = true;
                mail.Visible = true;
                password.Visible = true;
                phone.Visible = true;


                SqlConnection con = new SqlConnection(@"Data Source=FATMA-TOTA\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from recipient  ", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                cmd.CommandType = CommandType.Text;
                DataTable rd = new DataTable();
                
                DataRow row;
                while (rdr.Read())
                {
                    row = rd.NewRow();
                    if (rdr["mail"].ToString() == maill)
                    {
                        user.Text = rdr["user_name"].ToString();
                        age.Text = rdr["age"].ToString();
                        gender.Text = rdr["gender"].ToString();
                        mail.Text = rdr["mail"].ToString();
                        password.Text = rdr["password"].ToString();
                        phone.Text = rdr["phone_number"].ToString();
                        byte[] img = (byte[])(rdr["picture"]);
                        if(img==null)
                        {
                            pictureBox1.Image = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            pictureBox1.Image = Image.FromStream(ms);

                        }
                    }
                }

                rdr.Close();


                con.Close();
                
            }

            typee = type;
            
        }

        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void id_res_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int age, phone;
            if (name_res.Text != "" && age_res.Text != "" && comboBox1.Text != "" && textBox3.Text != "" && textBox2.Text != "" && textBox1.Text != "")
            {
                age = int.Parse(age_res.Text); phone = int.Parse(textBox1.Text);
                MessageBox.Show(functions.inset_recipient_donor(txt, name_res.Text, age, comboBox1.Text, textBox3.Text, textBox2.Text, phone,"",imgloc));
                
            }
            else if (name_res.Text == "" || age_res.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox2.Text == "" || textBox1.Text == "")


                MessageBox.Show("please enter your data");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            register d6 = new register(typee);
            d6.Show();
            this.Hide();
        }

        private void mail_res_TextChanged(object sender, EventArgs e)
        {
            txt = textBox3;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string oldmail;
            if (name_res.Text == "")
            {
                name_res.Text = user.Text;
            }
            if (age_res.Text == "")
            {
                age_res.Text = age.Text;
            }
            if (comboBox1.Text == "")
            {
                comboBox1.Text = gender.Text;
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = mail.Text;
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = password.Text;
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = phone.Text;
            }
            
            
            SqlConnection con = new SqlConnection("Data Source=FATMA-TOTA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();



            oldmail = mail.Text;


            SqlCommand cmd1 = new SqlCommand("username_updated", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter1_1 = new SqlParameter("@username", name_res.Text);
            cmd1.Parameters.Add(parameter1_1);
            SqlParameter parameter1_2 = new SqlParameter("@old_mail", oldmail);
            cmd1.Parameters.Add(parameter1_2);
            cmd1.ExecuteNonQuery();



            SqlCommand cmd2 = new SqlCommand("age_res_updated", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter2_1 = new SqlParameter("@age", age_res.Text);
            cmd2.Parameters.Add(parameter2_1);
            SqlParameter parameter2_2 = new SqlParameter("@old_mail", oldmail);
            cmd2.Parameters.Add(parameter2_2);
            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand("gender_res_updated", con);
            cmd3.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter3_1 = new SqlParameter("@gender", comboBox1.Text);
            cmd3.Parameters.Add(parameter3_1);
            SqlParameter parameter3_2 = new SqlParameter("@old_mail", oldmail);
            cmd3.Parameters.Add(parameter3_2);
            cmd3.ExecuteNonQuery();


            SqlCommand cmd4 = new SqlCommand("password_res_updated", con);
            cmd4.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter4_1 = new SqlParameter("@password", textBox2.Text);
            cmd4.Parameters.Add(parameter4_1);
            SqlParameter parameter4_2 = new SqlParameter("@old_mail", oldmail);
            cmd4.Parameters.Add(parameter4_2);
            cmd4.ExecuteNonQuery();

            SqlCommand cmd5 = new SqlCommand("phone_res_updated", con);
            cmd5.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter5_1 = new SqlParameter("@phone_number", textBox1.Text);
            cmd5.Parameters.Add(parameter5_1);
            SqlParameter parameter5_2 = new SqlParameter("@old_mail", oldmail);
            cmd5.Parameters.Add(parameter5_2);
            cmd5.ExecuteNonQuery();

            SqlCommand cmd7 = new SqlCommand("mail_res_updateddd", con);
            cmd7.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter7_1 = new SqlParameter("@mail", textBox3.Text);
            cmd7.Parameters.Add(parameter7_1);
            SqlParameter parameter7_2 = new SqlParameter("@old_mail", oldmail);
            cmd7.Parameters.Add(parameter7_2);
            cmd7.ExecuteNonQuery();

            con.Close();
            if (name_res.Text != "" || age_res.Text != ""||comboBox1.Text !=""|| textBox3.Text != "" || textBox2.Text != "" || textBox1.Text != "")
            {
                MessageBox.Show("done updated");
            } 
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            first_page d7 = new first_page();
            d7.Show();
            this.Hide();
        }

        private void user_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void age_res_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            name_res.Text = user.Text;
            name_res.Visible = true;
            user.Visible = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            age_res.Text = age.Text;
            age_res.Visible = true;
            age.Visible = false;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            comboBox1.Text = gender.Text;
            comboBox1.Visible = true;
            gender.Visible = false;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox3.Text = mail.Text;
            textBox3.Visible = true;
            mail.Visible = false;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox2.Text = password.Text;
            textBox2.Visible = true;
            password.Visible = false;
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Text = phone.Text;
            textBox1.Visible = true;
            phone.Visible = false;
        }
         
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Flies (*.jpg)|*.jpg|GIF Files (*.gif)|*gif |ALL Files (*.*)|*.*";
                dlg.Title = "Select Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgloc = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = imgloc;

                }
            }
            catch (Exception es)
            { MessageBox.Show(es.Message); }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            string pattern = @"^([0-9a-zA-Z]" + //Start with a digit or alphabetical
   @"([\+\-_\.][0-9a-zA-Z]+)*" + // No continuous or ending +-_. chars in email
   @")+" +
   @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";

            if (Regex.IsMatch(textBox3.Text, pattern))
            {
                errorProvider1.Clear();
            }

            else
            {

                errorProvider1.SetError(this.textBox3, "Please Enter Correct Email");
                return;
            }
        }

        private void request_Click(object sender, EventArgs e)
        {
            Blood_Data_show b = new Blood_Data_show();
            b.Show();
            this.Hide();
            this.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}