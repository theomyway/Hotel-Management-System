using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotelmanagementsystem
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        int HotelID = Form2.HotelID;
        string username = Form2.username;
        string hotelname = Form2.Hotelname;
        public static int CustomerID; //Value in in there (CustomerID is)
       

        SqlConnection con = new SqlConnection(@"Data Source=OMARSPC;Initial Catalog=HMS;Integrated Security=True");
        private void pictureBox8_Click(object sender, EventArgs e)
        {

            if (IsValid())
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO Customer values (@Fname,@Lname,@Phone,@City,@Country,@Zip,@HotelID)", con);
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("@Fname", textBox6.Text);
                cmd.Parameters.AddWithValue("@Lname", textBox5.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox7.Text);
                cmd.Parameters.AddWithValue("@City", textBox1.Text);
                cmd.Parameters.AddWithValue("@Country", textBox3.Text);
                cmd.Parameters.AddWithValue("@Zip", textBox10.Text);
                cmd.Parameters.AddWithValue("@HotelID", HotelID);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                SqlCommand GetHotelID = new SqlCommand("select Customer_ID from Customer where First_name = '" + textBox6.Text + "' AND Last_name = '" + textBox5.Text + "' AND Phone_number = '" + textBox7.Text + "' AND City = '" + textBox1.Text + "' AND Country_state = '" + textBox3.Text + "' AND Zip_code = '" + textBox10.Text + "' and Hotel_ID = '" + HotelID + "'" , con);
                
                var GettingCustomerID = GetHotelID.ExecuteScalar();

                GetHotelID.ExecuteNonQuery();

                CustomerID = Convert.ToInt32(GettingCustomerID);
                con.Close();

                this.Hide();
                Form13 f12 = new Form13();
                f12.ShowDialog();
                this.Close();


                //GetAvailableClient();
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValid()   //ENCAPSULATION

        {

            return true;
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            roundPictureBox5.BackColor = Color.RosyBrown;
            label15.BackColor = Color.RosyBrown;
            label1.Text = hotelname;
            label11.Text = username;
        }

        private void btnAddRec_MouseHover(object sender, EventArgs e)
        {
            panelLeft.Height = btnAddRec.Height;
               panelLeft.Top = btnAddRec.Top;
        }

        private void btnHome_MouseHover(object sender, EventArgs e)
        {
            panelLeft.Height = btnHome.Height;
               panelLeft.Top = btnHome.Top;
        }

        private void btnViewFromDatabase_MouseHover(object sender, EventArgs e)
        {
            panelLeft.Height = btnViewFromDatabase.Height;
           panelLeft.Top = btnViewFromDatabase.Top;
        }

        private void btnFind_MouseHover(object sender, EventArgs e)
        {
            panelLeft.Height = btnFind.Height;
           panelLeft.Top = btnFind.Top;
        }

        private void btnSalesSummary_MouseHover(object sender, EventArgs e)
        {
            panelLeft.Height = btnSalesSummary.Height;
           panelLeft.Top = btnSalesSummary.Top;
        }

        private void btnSecurity_MouseHover(object sender, EventArgs e)
        {
            panelLeft.Height = btnSecurity.Height;
             panelLeft.Top = btnSecurity.Top;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            panelLeft.Height = button1.Height;
           panelLeft.Top = button1.Top;
        }

        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSecurity_Click(object sender, EventArgs e)
        {

            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.ShowDialog();
            this.Close();
        }

        private void btnViewFromDatabase_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form11 f11 = new Form11();
            f11.ShowDialog();
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 f10 = new Form10();
            f10.ShowDialog();
            this.Close();
        }

        private void btnSalesSummary_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form17 f17 = new Form17();
            f17.ShowDialog();
            this.Close();
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox8, "Proceed to next step");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form18 f18 = new Form18();
            f18.ShowDialog();
            this.Close();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}





