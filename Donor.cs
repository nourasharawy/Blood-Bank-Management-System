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
    public partial class doonoor : Form
    {
        string imgloc = "";
       
        TextBox txt;
        string typee;
        public doonoor(string type, string maill)
        {
            InitializeComponent();
            txt = mail;
            if (type == "REG")
            {
                button4.Visible = false;
                Update.Visible = false;
                lname.Visible = false;
                lage.Visible = false;
                lgender.Visible = false;
                lmail.Visible = false;
                lpassword.Visible = false;
                lphone.Visible = false;
                ldis.Visible = false;
                linkLabel1.Visible = false;
                linkLabel2.Visible = false;
                linkLabel3.Visible = false;
                linkLabel4.Visible = false;
                linkLabel5.Visible = false;
                linkLabel6.Visible = false;
                linkLabel7.Visible = false;

            }
            else if (type == "LOGIN")
            {
                button4.Visible = true;
                Update.Visible = true;
                button1.Visible = false;
                name.Visible = false;
                age.Visible = false;
                mail.Visible = false;
                password.Visible = false;
                phone.Visible = false;
                dis.Visible = false;
                gender.Visible = false;
               
                lname.Visible = true;
                lage.Visible = true;
                lgender.Visible = true;
                lmail.Visible = true;
                lpassword.Visible = true;
                lphone.Visible = true;
                ldis.Visible = true;

                linkLabel1.Visible = true;
                linkLabel2.Visible = true;
                linkLabel3.Visible = true;
                linkLabel4.Visible = true;
                linkLabel5.Visible = true;
                linkLabel6.Visible = true;
                linkLabel7.Visible = true;
                

                SqlConnection con = new SqlConnection(@"Data Source=FATMA-TOTA\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Donor_inf", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                cmd.CommandType = CommandType.Text;
                DataTable rd = new DataTable();
                

                DataRow row;
                while (rdr.Read())
                {
                    row = rd.NewRow();
                    if (rdr["mail"].ToString() == maill)
                    {
                        lname.Text = rdr["user_name"].ToString();
                        lage.Text = rdr["age"].ToString();
                        lgender.Text = rdr["gender"].ToString();
                        lmail.Text = rdr["mail"].ToString();
                        lpassword.Text = rdr["password"].ToString();
                        lphone.Text = rdr["phone_number"].ToString();
                        ldis.Text = rdr["disease_history"].ToString();

                        byte[] img = (byte[])(rdr["picture"]);
                        if (img == null)
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

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (name.Text != "" && age.Text != "" && gender.Text != "" && mail.Text != "" && password.Text != "" && phone.Text != "")
            {
                int agee, phonee;
                agee = int.Parse(age.Text); phonee = int.Parse(phone.Text);
               MessageBox.Show(functions.inset_recipient_donor(txt,name.Text, agee, gender.Text, mail.Text, password.Text, phonee, dis.Text,imgloc));

            }
            else if (name.Text != "" || age.Text != "" || gender.Text != "" || mail.Text != "" || password.Text != "" || phone.Text != "")
                MessageBox.Show("please enter your data");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            register d6 = new register(typee);
            d6.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            txt = mail;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
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

        private void mail_Leave(object sender, EventArgs e)
        {
            string pattern = @"^([0-9a-zA-Z]" + //Start with a digit or alphabetical
   @"([\+\-_\.][0-9a-zA-Z]+)*" + // No continuous or ending +-_. chars in email
   @")+" +
   @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";

            if (Regex.IsMatch(mail.Text, pattern))
            {
                errorProvider1.Clear();
            }

            else
            {

                errorProvider1.SetError(this.mail, "Please Enter Correct Email");
                return;
            }
        }
      

        private void Update_Click(object sender, EventArgs e)
        {
            string oldmail;
            if (name.Text == "")
            {
                name.Text = lname.Text;
            }
            if (age.Text == "")
            {
                age.Text = lage.Text;
            }
            if (gender.Text == "")
            {
                gender.Text = lgender.Text;
            }
            if (mail.Text == "")
            {
                mail.Text = lmail.Text;
            }
            if (password.Text == "")
            {
                password.Text = lpassword.Text;
            }
            if (phone.Text == "")
            {
                phone.Text = lphone.Text;
            }
            if (dis.Text == "")
            {
                dis.Text = ldis.Text;
            }
            

            SqlConnection con = new SqlConnection("Data Source=FATMA-TOTA\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();


            oldmail = lmail.Text;


                SqlCommand cmd1 = new SqlCommand("user_don_updated3", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter1_1 = new SqlParameter("@username", name.Text);
               
                cmd1.Parameters.Add(parameter1_1);
              
                SqlParameter parameter1_2 = new SqlParameter("@old_mail", oldmail);
                cmd1.Parameters.Add(parameter1_2);
                cmd1.ExecuteNonQuery();


                SqlCommand cmd2 = new SqlCommand("age_don_updated", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter2_1 = new SqlParameter("@age", age.Text);
               cmd2.Parameters.Add(parameter2_1);
               SqlParameter parameter2_2 = new SqlParameter("@old_mail", lmail.Text);
                cmd2.Parameters.Add(parameter2_2);
                cmd2.ExecuteNonQuery();


                SqlCommand cmd3 = new SqlCommand("gender_don_updated3", con);
                cmd3.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter3_1 = new SqlParameter("@gender", gender.Text);
                cmd3.Parameters.Add(parameter3_1);
               

                SqlParameter parameter3_2 = new SqlParameter("@old_mail", lmail.Text);
                cmd3.Parameters.Add(parameter3_2);
                cmd3.ExecuteNonQuery();


                SqlCommand cmd4 = new SqlCommand("password_don_updated4", con);
                cmd4.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter4_1 = new SqlParameter("@password", password.Text);
                  
                    cmd4.Parameters.Add(parameter4_1);
                    SqlParameter parameter4_2 = new SqlParameter("@old_mail", lmail.Text);
                cmd4.Parameters.Add(parameter4_2);
                cmd4.ExecuteNonQuery();

                SqlCommand cmd5 = new SqlCommand("phone_number_updated", con);
                cmd5.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter5_1 = new SqlParameter("@phone_number", phone.Text);
                
                cmd5.Parameters.Add(parameter5_1);
                SqlParameter parameter5_2 = new SqlParameter("@old_mail", lmail.Text);
                cmd5.Parameters.Add(parameter5_2);
                cmd5.ExecuteNonQuery();


                SqlCommand cmd6 = new SqlCommand("disease_don_updated", con);
                cmd6.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter6_1 = new SqlParameter("@diseace", dis.Text);
               
                cmd6.Parameters.Add(parameter6_1);
                SqlParameter parameter6_2 = new SqlParameter("@old_mail", lmail.Text);
                cmd6.Parameters.Add(parameter6_2);
                cmd6.ExecuteNonQuery();



                SqlCommand cmd7 = new SqlCommand("mail_don_updated3", con);
                cmd7.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter7_1 = new SqlParameter("@mail", mail.Text);
                
                cmd7.Parameters.Add(parameter7_1);
                SqlParameter parameter7_2 = new SqlParameter("@old_mail", lmail.Text);
                cmd7.Parameters.Add(parameter7_2);
               

                cmd7.ExecuteNonQuery();

                

                con.Close();
                 if (name.Text != "" || age.Text != "" || gender.Text != "" || password.Text != "" || phone.Text != ""|| dis.Text!=""|| mail.Text!="")
                {
                    MessageBox.Show("done updated");
                }
            }
        

        private void lname_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            password.Text = lpassword.Text;
            password.Visible = true;
            lpassword.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            name.Text = lname.Text;
            name.Visible = true;
            lname.Visible = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            age.Text = lage.Text;
            age.Visible = true;
            lage.Visible = false;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gender.Text = lgender.Text;
            gender.Visible = true;
            lgender.Visible = false;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mail.Text = lmail.Text;
            mail.Visible = true;
            lmail.Visible = false;
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            phone.Text = lphone.Text;
            phone.Visible = true;
            lphone.Visible = false;
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dis.Text = ldis.Text;
            dis.Visible = true;
            ldis.Visible = false;
        }

        private void lmail_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            donate d = new donate(lmail.Text);
            d.Show();
            this.Hide();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}