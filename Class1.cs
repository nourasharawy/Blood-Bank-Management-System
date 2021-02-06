using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace _1
{
    
    static class functions
    {
       
       /* public static DataTable Edit(string type)
        {
            SqlConnection con = new SqlConnection(@"Data Source=FATMA-TOTA\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();


            con.Close();
        }*/
        public static DataTable Display_data(string type)
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=FATMA-TOTA\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            

            DataTable Donorss = new DataTable();
            

            if (type == "DONOR")
            {
                SqlCommand smd = new SqlCommand("Select * from Donor_inf",con);
                cmd = smd;
               }
            else if (type == "RECIPIENT")
            {
                SqlCommand smd = new SqlCommand("Select * from recipient", con);
                cmd = smd;
            }
            else if (type == "BLOOD")
            {
                SqlCommand smd = new SqlCommand("Select * from hospitall", con);
                cmd = smd;
            }
              SqlDataReader rdr = cmd.ExecuteReader();

              Donorss.Columns.Add("id");
              if (type == "DONOR" || type == "RECIPIENT")
              {

                  Donorss.Columns.Add("user_name");
                  Donorss.Columns.Add("age");
                  Donorss.Columns.Add("gender");
                  Donorss.Columns.Add("mail");
                  Donorss.Columns.Add("password");
                  Donorss.Columns.Add("phone_number");
               ////   Donorss.Columns.Add("phone_number");
              }
            if (type == "BLOOD")
                Donorss.Columns.Add("type");
            if (type == "Donor")
                Donorss.Columns.Add("disease_history");

                DataRow Rowss;
                while (rdr.Read())
                {
                    Rowss = Donorss.NewRow();
                    Rowss["id"] = rdr["id"];
                    if (type == "DONOR" || type == "RECIPIENT")
                    {
                        
                        Rowss["user_name"] = rdr["user_name"];
                        Rowss["age"] = rdr["age"];
                        Rowss["gender"] = rdr["gender"];
                        Rowss["mail"] = rdr["mail"];
                        Rowss["password"] = rdr["password"];
                        Rowss["phone_number"] = rdr["phone_number"];
                    }
                    if (type == "BLOOD")
                        Rowss["type"] = rdr["type"];
                if (type == "Donor")
                   Rowss["disease_history"] = rdr["disease_history"];

                    Donorss.Rows.Add(Rowss);
                }
                rdr.Close();
                
               
            
            return (Donorss);
            con.Close();

            
        }


        public static string delete(TextBox text, int id, string type)
        {
            SqlConnection con = new SqlConnection(@"Data Source=FATMA-TOTA\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd5 = new SqlCommand();
            SqlCommand smd = new SqlCommand();
            

            if (type == "DONOR")
            {
                SqlCommand cmd4 = new SqlCommand("Select id from Donor_inf",con);
                cmd5 = cmd4; 
            }
            else if (type == "RECIPIENT")
            {
                SqlCommand cmd4 = new SqlCommand("Select id from recipient",con);
                cmd5 = cmd4; 
            } 
            else if (type == "BLOOD")
            {
                SqlCommand cmd4 = new SqlCommand("Select id from blood",con);
                cmd5 = cmd4; 
            }

            int x = 0; 
                SqlDataReader read1 = cmd5.ExecuteReader();
                DataTable ss = new DataTable();
                ss.Columns.Add("id");
                DataRow row;
                while (read1.Read())
                {
                    row = ss.NewRow();
                    row["id"] = read1["id"];
                    if (text.Text == (read1["id"].ToString()))
                    {
                        x++;
                        break;
                    }

                }
                
                read1.Close();
                if (x > 0)
                {
                    if (type == "DONOR")
                    {

                        SqlCommand cmd1 = new SqlCommand("delete_from_donor1", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        SqlParameter param1 = new SqlParameter("@id_donor", id);
                        cmd1.Parameters.Add(param1); 
                            SqlCommand cmd1_2 = new SqlCommand("delete_donor_donate", con);
                            cmd1_2.CommandType = CommandType.StoredProcedure;
                            SqlParameter param1_2 = new SqlParameter("@id_donor", id);
                            cmd1_2.Parameters.Add(param1_2);
                            cmd1_2.ExecuteNonQuery();                               
                        smd = cmd1;
                    }


                    else if (type == "RECIPIENT")
                    {
                        SqlCommand cmd1 = new SqlCommand("delete_from_recip", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramdocname = new SqlParameter("@id_recipient", id);
                        cmd1.Parameters.Add(paramdocname);
                        SqlCommand cmd1_2 = new SqlCommand("delete_res_request", con);
                        cmd1_2.CommandType = CommandType.StoredProcedure;
                        SqlParameter param1_2 = new SqlParameter("@id_res", id);
                        cmd1_2.Parameters.Add(param1_2);
                        cmd1_2.ExecuteNonQuery();
                        smd = cmd1;
                    }
                    else
                    {
                        SqlCommand cmd1 = new SqlCommand("delete_from_blood", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramdocname = new SqlParameter("@id_blood", id);
                        cmd1.Parameters.Add(paramdocname);
                        smd = cmd1;
                    }

             SqlDataReader rdr = smd.ExecuteReader();
                    return ("done delete sir !");
             } 
                else
                    return ("No One has this ID !");
            con.Close();
        }

        public static string inset_recipient_donor(TextBox text,string name, int age, string gender, string mail, string password,
            int phone, string disease ,string pic)

        {
            string insertd;
            SqlConnection con = new SqlConnection(@"Data Source=FATMA-TOTA\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd5 = new SqlCommand();


            if (disease == "")
            {
                insertd = @"insert into recipient (user_name,age,gender,mail,password,phone_number,picture)
                   values (@NAME,@AGE,@GENDER,@MAIL,@PASSWORD,@PHONENUM,@PICTURE)";

                SqlCommand smd = new SqlCommand("Select mail from recipient", con);
                cmd5 = smd;
            }

            else
            {
                insertd = @"insert into Donor_inf (user_name,age,gender,mail,password,phone_number,disease_history,picture)
                                            values(@NAME,@AGE,@GENDER,@MAIL,@PASSWORD,@PHONENUM,@DISEASES,@PICTURE)";
                SqlCommand smd = new SqlCommand("Select mail from Donor_inf", con);
                cmd5 = smd;
            }

            
            SqlCommand cmd = new SqlCommand(insertd, con);

            int x = 0;
                SqlDataReader read1 = cmd5.ExecuteReader();
                DataTable ss = new DataTable();
                ss.Columns.Add("mail");
                DataRow row;
                while (read1.Read())
                { row = ss.NewRow();
                  row["mail"] = read1["mail"];
                   if (text.Text == (read1["mail"].ToString()))
                    {
                        x=x+1;
                        break;
                    }

                } read1.Close();
             if (x == 0)
             {
                 SqlParameter param1 = new SqlParameter("@NAME", name);
                 cmd.Parameters.Add(param1);
                 SqlParameter param2 = new SqlParameter("@AGE", age);
                 cmd.Parameters.Add(param2);
                 SqlParameter param3 = new SqlParameter("@GENDER", gender);
                 if (gender == "Female" || gender == "Male")
                     cmd.Parameters.Add(param3);
                 else
                     return ("This gender don't correct ");
                  
                 SqlParameter param4 = new SqlParameter("@MAIL", mail);

                 cmd.Parameters.Add(param4);
                 SqlParameter param5 = new SqlParameter("@PASSWORD", password);
                 cmd.Parameters.Add(param5);
                 SqlParameter param6 = new SqlParameter("@PHONENUM", phone);
                 cmd.Parameters.Add(param6);
                 byte[] img = null;
                 FileStream fs = new FileStream(pic, FileMode.Open, FileAccess.Read);
                 BinaryReader br = new BinaryReader(fs);
                 img = br.ReadBytes((int)fs.Length);
                 SqlParameter param8 = new SqlParameter("@PICTURE", img);
                 cmd.Parameters.Add(param8);
                if (disease != "")
                   {
                      SqlParameter param7 = new SqlParameter("@DISEASES", disease);
                      cmd.Parameters.Add(param7);
                   }
                cmd.ExecuteNonQuery();
             }
             else
             {
                 return ("This mail entered previous ");
                 //MessageBox.Show("This mail entered previous ");
             }
            
            con.Close();
            return ("done enter data");
        }
    }
}