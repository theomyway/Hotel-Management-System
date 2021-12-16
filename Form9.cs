using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient ;
using System.Threading;
namespace Hotelmanagementsystem
{
    public partial class Form9 : Form
    {
        SqlConnection con = Form2.connectionstring;
        public Form9()
        {
            InitializeComponent();
        }
        //SqlConnection con = new SqlConnection(@"Data Source=OMARSPC;Initial Catalog=HMS;Integrated Security=True");

        private void Form9_Load(object sender, EventArgs e)
        {

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

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBoxusername_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"^(?=[a-zA-Z])[-\w.]{0,23}([a-zA-Z\d]|(?<![-.])_)$", textBoxusername, pictureBox4);
          

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"^([A-Za-z]{3,9})([0-9]{0})$", textBoxPassword, pictureBox3);
        }

        private void textBoxusername_Enter(object sender, EventArgs e)
        {
            if (textBoxusername.Text == "enter new username")
            {
                textBoxusername.Text = "";
            }
            

            

        }

        private void textBoxusername_Leave(object sender, EventArgs e)
        {
            if (textBoxusername.Text == "")
            {
                textBoxusername.Text = "enter new username";
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Enter new password")
            {
                textBoxPassword.Text = "";
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {

            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Enter new password";
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [Admin] WHERE ([Username] = @user)", con);
            check_User_Name.Parameters.AddWithValue("@user", textBoxusername.Text);
            int UserExist = (int)check_User_Name.ExecuteScalar();

            check_User_Name.ExecuteNonQuery();


            con.Close();
            con.Open();
            SqlCommand check_User_Pass = new SqlCommand("SELECT COUNT(*) FROM [Admin] WHERE ([Hotel_Name] = @HotelName)", con);
            check_User_Pass.Parameters.AddWithValue("@HotelName", textBox1.Text);
            int HotelNameExists = (int)check_User_Pass.ExecuteScalar();

            check_User_Pass.ExecuteNonQuery();
            if (textBoxusername.Text == "")              
            {
                MessageBox.Show("User name cannot be left empty!");
            }
            if(textBoxPassword.Text=="")
            {
                MessageBox.Show("Password cannot be left empty!");
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Hotel name cannot be left empty!");
            }
            else if (textBoxusername.Text != "" && textBoxPassword.Text != "" && textBox1.Text != "")
            {

                if (UserExist > 0)
                {
                    //Username exist

                    MessageBox.Show("Sorry! User name already taken.");



                }
                if (HotelNameExists > 0)
                {
                    MessageBox.Show("Sorry! Hotel name already taken.");

                }
                else if (UserExist==0 && HotelNameExists==0)
                {


                    SqlCommand cmd = new SqlCommand("Insert into Admin values (@Username,@Password,@Hotel_Name)", con);
                    cmd.CommandType = CommandType.Text;


                    cmd.Parameters.AddWithValue("@Username", textBoxusername.Text);
                    cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text);
                    cmd.Parameters.AddWithValue("@Hotel_Name", textBox1.Text);


                    cmd.ExecuteNonQuery();

                    MessageBox.Show("You are now registered as a new vendor!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetFormControls();
                    
                    con.Close();
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Kindly provide valid data!");
                    con.Close();
                    
                }
                con.Close();


            }
            con.Close();
        }
        
        private void ResetFormControls()
        {
            
            textBox1.Clear();
            textBoxPassword.Clear();
            textBoxusername.Clear();


            
        }
        private bool IsValid()   //ENCAPSULATION

        {
            if (textBoxusername.Text == string.Empty)
            {
                MessageBox.Show("Client's First name cannot be empty", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "enter hotel name")
            {
                textBox1.Text = "";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnlogin, "Register As Hotel Admin");
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "enter hotel name";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"^([A-Za-z]{3,9})([0-9]{0})$", textBox1, pictureBox6);
        }
    }
}
