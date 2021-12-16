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
using System.Data.SqlClient;
using System.Threading;

namespace Hotelmanagementsystem
{
    public partial class Form6 : Form
    {
        SqlConnection con = Form2.connectionstring;
        public Form6()
        {
            InitializeComponent();
           
        }
        //SqlConnection con = new SqlConnection(@"Data Source=OMARSPC;Initial Catalog=HMS;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [Admin] WHERE ([Username] = @user)", con);
            check_User_Name.Parameters.AddWithValue("@user", textBox1.Text);
            int UserExist = (int)check_User_Name.ExecuteScalar();

            check_User_Name.ExecuteNonQuery();


            con.Close();
            con.Open();
            SqlCommand check_User_Pass = new SqlCommand("SELECT COUNT(*) FROM [Admin] WHERE ([Password] = @pass)", con);
            check_User_Pass.Parameters.AddWithValue("@pass", textBox2.Text);
            int PassExist = (int)check_User_Pass.ExecuteScalar();

            check_User_Pass.ExecuteNonQuery();
            con.Close();
            if (PassExist > 0 && UserExist > 0)
            {
                //Username exist
               
                SqlCommand cmd = new SqlCommand("UPDATE Admin SET [Username]= @User", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@User", textBox3.Text);
                

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                SqlCommand cmdg = new SqlCommand("UPDATE Admin SET [Password]= @Pass", con);
                cmdg.CommandType = CommandType.Text;
                cmdg.Parameters.AddWithValue("@Pass", textBox4.Text);


                con.Open();
                cmdg.ExecuteNonQuery();
                
                Form8 f8 = new Form8();
                f8.ShowDialog();
                Thread.Sleep(2000);
             
                this.Hide();
                
                this.Close();

            }
            else
            {

                MessageBox.Show("Wrong Old ID and PASSWORD entered!!");
            }
            con.Close();
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [Admin] WHERE ([Username] = @user)", con);
            check_User_Name.Parameters.AddWithValue("@user", textBox1.Text);
            int UserExist = (int)check_User_Name.ExecuteScalar();

            check_User_Name.ExecuteNonQuery();


            con.Close();
            con.Open();
            SqlCommand check_User_Pass = new SqlCommand("SELECT COUNT(*) FROM [Admin] WHERE ([Password] = @pass)", con);
            check_User_Pass.Parameters.AddWithValue("@pass", textBox2.Text);
            int PassExist = (int)check_User_Pass.ExecuteScalar();

            check_User_Pass.ExecuteNonQuery();
            con.Close();
            if (PassExist > 0 && UserExist > 0)
            {
                //Username exist
                MessageBox.Show("Correct! Now enter new ID and PASSWORD!");

            }
            else
            {

                MessageBox.Show("Wrong ID or PASSWORD entered!!");
            }
            con.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"^([\w]+)@([\w]+)\.([\w]+)$", textBox1, pictureBox3);
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"^([A-Za-z]{4,9})([0-9]{3})$", textBox2, pictureBox2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"^([\w]+)@([\w]+)\.([\w]+)$", textBox3, pictureBox1);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"^([A-Za-z]{4,9})([0-9]{3})$", textBox4, pictureBox4);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
