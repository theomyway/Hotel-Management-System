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
using System.Data;

namespace Hotelmanagementsystem
{
    public partial class Form18 : Form
    {
        SqlConnection con = Form2.connectionstring;
        public Form18()
        {
            InitializeComponent();
        }
        int HotelID = Form2.HotelID;
        //SqlConnection con = new SqlConnection(@"Data Source=OMARSPC;Initial Catalog=HMS;Integrated Security=True");
        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void resetformcontrols()
        {
            textBox1.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox7.Clear();
            pictureBox9.Visible = false;
            pictureBox11.Visible = true;
        }
        private bool IsValid()   //ENCAPSULATION

        {

            return true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Hotel values (@HotelID,@Zipcode,@City,@Countrystate,@Phon)", con);
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("@Zipcode", textBox6.Text);
                cmd.Parameters.AddWithValue("@City", textBox5.Text);
                cmd.Parameters.AddWithValue("@Countrystate", textBox7.Text);
                cmd.Parameters.AddWithValue("@Phon", textBox1.Text);
                cmd.Parameters.AddWithValue("@HotelID", HotelID);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                resetformcontrols();

            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("Update Hotel SET Zipcode = @Zipcde,City = @Cit,Country_state = @Countrystate,Phone = @Phne where Hotel_ID = @HotlID)", con);
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("@Zipcde", textBox6.Text);
                cmd.Parameters.AddWithValue("@Cit", textBox5.Text);
                cmd.Parameters.AddWithValue("@Countrystate", textBox7.Text);
                cmd.Parameters.AddWithValue("@Phne", textBox1.Text);
                cmd.Parameters.AddWithValue("@HotlID", HotelID);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                

            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            label1.Text = Form2.Hotelname;
            label11.Text = Form2.username;
            panelLeft.Height = button1.Height;
            panelLeft.Top = button1.Top;
            pictureBox11.Visible = false;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.ShowDialog();
            this.Close();
        }

        private void btnAddRec_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 f12 = new Form12();
            f12.ShowDialog();
            this.Close();
        }

        private void btnViewFromDatabase_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form11 f4 = new Form11();
            f4.ShowDialog();
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 f4 = new Form10();
            f4.ShowDialog();
            this.Close();
        }

        private void btnSalesSummary_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form17 f4 = new Form17();
            f4.ShowDialog();
            this.Close();
        }

        private void btnSecurity_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f4 = new Form6();
            f4.ShowDialog();
            this.Close();
        }

        private void btnHome_MouseHover(object sender, EventArgs e)
        {
            panelLeft.Height = btnHome.Height;
            panelLeft.Top = btnHome.Top;
        }

        private void btnAddRec_MouseHover(object sender, EventArgs e)
        {
            panelLeft.Height = btnAddRec.Height;
            panelLeft.Top = btnAddRec.Top;
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
    }
}



