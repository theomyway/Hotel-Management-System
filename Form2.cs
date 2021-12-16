using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;

using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Text.RegularExpressions;

namespace Hotelmanagementsystem
{
    public partial class Form2 : Form
    {

        public static string username;
        public static string Hotelname;
        public static string Userlogin;
        public static string Passlogin;
        public static int HotelID;
        public static SqlConnection connectionstring;
        DataTable dt;
        SqlConnection con = new SqlConnection(@"Data Source=OMARSPC;Initial Catalog=HMS;Integrated Security=True");
        
        public Form2()
        {
            InitializeComponent();
            connectionstring = con;

        }

       
        
        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }



        private void textBoxusername_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"^(?=[a-zA-Z])[-\w.]{0,23}([a-zA-Z\d]|(?<![-.])_)$", textBoxusername, pictureBox4);
        }


        private void textBoxusername_Enter(object sender, EventArgs e)
        {
            if (textBoxusername.Text == "Username")
            {
                textBoxusername.Text = "";
            }

        }
        //public void GetHotelID()
        //{
        //    con.Open();
        //    SqlCommand GetHotelID = new SqlCommand("select Hotel_ID from Admin where Hotel_Name=@HotelName", con);
        //    GetHotelID.Parameters.AddWithValue("@HotelName", Hotelname);
        //    int GettingHotelID = (int)GetHotelID.ExecuteScalar();

        //    GetHotelID.ExecuteNonQuery();
            
            
        //    con.Close();
        //    HotelID = GettingHotelID;

        //}

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Password")
            {
                textBoxPassword.Text = "";
            }

        }

        private void textBoxusername_Leave(object sender, EventArgs e)
        {
            if (textBoxusername.Text == "")
            {
                textBoxusername.Text = "Username";
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Password";
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            
            username = textBoxusername.Text;


            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [Admin] WHERE ([Username] = @user)", con);
            check_User_Name.Parameters.AddWithValue("@user", textBoxusername.Text);
            int UserExist = (int)check_User_Name.ExecuteScalar();

            check_User_Name.ExecuteNonQuery();


            con.Close();
            con.Open();
            SqlCommand check_User_Pass = new SqlCommand("SELECT COUNT(*) FROM [Admin] WHERE ([Password] = @pass)", con);
            check_User_Pass.Parameters.AddWithValue("@pass", textBoxPassword.Text);
            int PassExist = (int)check_User_Pass.ExecuteScalar();

            check_User_Pass.ExecuteNonQuery();
            con.Close();
            con.Open();
            if (UserExist==1)
            {
                
                //Username exist

                string sql = "select Hotel_Name from Admin where Username='" + textBoxusername.Text + "'";
                

                SqlCommand cmd = new SqlCommand(sql,con);
                using(SqlDataReader dr=cmd.ExecuteReader())
                {
                    if(dr.Read())
                    {
                        Hotelname = dr["Hotel_Name"].ToString();
                    }
                    con.Close();
                    

                    
                }




                con.Open();
                SqlCommand GetHotelID = new SqlCommand("select Hotel_ID from Admin where Hotel_Name=@HotelName", con);
                GetHotelID.Parameters.AddWithValue("@HotelName", Hotelname);
                var GettingHotelID = GetHotelID.ExecuteScalar();

                GetHotelID.ExecuteNonQuery();

                HotelID = Convert.ToInt32(GettingHotelID);
                con.Close();




                con.Open();
                UserPass();
                con.Close();
               


            }
            
            

            else
            {
                MessageBox.Show("User is not registered in HMS! Kindly get registered please :)");
                con.Close();
            }
            
           
            

        }
       
        
        private void UserPass()
        {
            
            string User = "select Username from Admin where Hotel_Name='" + Hotelname + "'";


            SqlCommand cmd = new SqlCommand(User, con);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    Userlogin = dr["Username"].ToString();
                }
                con.Close();
                
            }
            con.Close();

            con.Open();
            string Pass = "select Password from Admin where Username='" + Userlogin + "'";


            SqlCommand ctb = new SqlCommand(Pass, con);
            using (SqlDataReader dr = ctb.ExecuteReader())
            {
                if (dr.Read())
                {
                    Passlogin = dr["Password"].ToString();
                }
                con.Close();
            }
           
            con.Close();
            if (Userlogin==textBoxusername.Text && Passlogin==textBoxPassword.Text)
            {
                
                Form7 f7 = new Form7();
                f7.Size = new Size(286, 510);
                f7.ShowDialog();

                this.Hide();
                Form4 f4 = new Form4();
                f4.ShowDialog();
                this.Close();
                


            }
            else
            {
                MessageBox.Show("Wrong Username or Password entered! ");
            }

            con.Close();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {

        }
        private bool IsValid()   //ENCAPSULATION

        {
           
            return true;
        }

        private void GetHotelNameDB()
        {
           




        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }
        public void Regexp(string re, TextBox tb, PictureBox pc)
        {

            Regex regex = new Regex(re);
            if (regex.IsMatch(tb.Text))
            {
                pc.Image = Properties.Resources.verified_account_24px;


            }
            else
            {
                pc.Image = Properties.Resources.delete_16px;


            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"^([A-Za-z]{3,9})([0-9]{0})$", textBoxPassword, pictureBox3);
        }

        private void Form2_Load(object sender, EventArgs e)
        {


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.ShowDialog();
            this.Close();
        }

        private void btnlogin_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnlogin, "Sign In");
        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(linkLabel1, "Get Registered As New Vendor");
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "Change Login Info");
        }
    }
}
