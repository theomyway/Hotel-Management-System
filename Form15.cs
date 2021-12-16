using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotelmanagementsystem
{
    public partial class Form15 : Form
    {
        int HotelID = Form2.HotelID;
        string username = Form2.username;
        string hotelname = Form2.Hotelname;
        int Employee_ID = Form13.Employee_ID;
        int Customer_ID = Form12.CustomerID;
        int Room_No = Form14.Room_number;
        public static DateTime Checkin, Checkout,BookingDate;
        int Serviceid = Form11.ServiceID;
        public static int Resv_ID;
        public static int TotalDays;
        public static int Plan_rates;
        int RoomRates = Form14.Rates;
        SqlConnection con = new SqlConnection(@"Data Source=OMARSPC;Initial Catalog=HMS;Integrated Security=True");


        public Form15()
        {
            InitializeComponent();
        }
        public void GetPlans()
        {
            con.Open();
            
            string User = "select Servicename from Plans where Hotel_ID = @HtlID";


            SqlCommand cmd = new SqlCommand(User, con);
            cmd.Parameters.AddWithValue("@HtlID", HotelID);
            using (SqlDataReader dr = cmd.ExecuteReader())
           {
                while (dr.Read())
               {
                   
                    combobox1.Items.Add(dr[0]).ToString();
                }
                con.Close();

            }
            con.Close();
            
            
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            
            
            GetPlans();
            BookingDate = DateTime.Now;
            textBox5.Text = BookingDate.ToString();
            combobox1.Items.Add("");
            
            
            roundPictureBox2.BackColor = Color.RosyBrown;
            label5.BackColor = Color.RosyBrown;
            label1.Text = hotelname;
            label11.Text = username;
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
        private bool IsValid()   //ENCAPSULATION

        {

            return true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Checkin = dateTimePicker1.Value;
                Checkout = booking_DateDateTimePicker.Value;
                TotalDays = (Checkout - Checkin).Days;
                
               
                SqlCommand cmd = new SqlCommand("insert into Reservations values (@CusID,@checkin,@checkout,@Stats,@NoGuests,@Resdate,@Roomno,@HotelID ,@EmpID)",con);
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("@CusID", Customer_ID);
                cmd.Parameters.AddWithValue("@checkin",Checkin);
                cmd.Parameters.AddWithValue("@checkout", Checkout);
                cmd.Parameters.AddWithValue("@Stats",textBox1.Text);
                cmd.Parameters.AddWithValue("@NoGuests", Convert.ToInt32( textBox3.Text));
                cmd.Parameters.AddWithValue("@Resdate",BookingDate );
                cmd.Parameters.AddWithValue("@Roomno",Room_No );
                cmd.Parameters.AddWithValue("@HotelID",HotelID);
                cmd.Parameters.AddWithValue("@EmpID", Employee_ID);

                //Checkin = Convert.ToDateTime(dateTimePicker1.Value);
                //Checkout = Convert.ToDateTime(booking_DateDateTimePicker.Value);


                con.Open();
                
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlCommand GetResvID = new SqlCommand("select Reservation_number from Reservations where Customer_ID= '" + Customer_ID + "' and Employee_ID = '" + Employee_ID + "' and Hotel_ID = '"+ HotelID + "'", con);

                var GettingCustomerID = GetResvID.ExecuteScalar();

                GetResvID.ExecuteNonQuery();

                Resv_ID = Convert.ToInt32(GettingCustomerID);
                con.Close();
                SqlCommand fgg = new SqlCommand("Update Plans set Reservation_number=@Resnumbr where Servicename=@Servname and Hotel_ID = @HtlID", con);
                cmd.CommandType = CommandType.Text;


                fgg.Parameters.AddWithValue("@Resnumbr", Resv_ID);
                fgg.Parameters.AddWithValue("@Servname", combobox1.SelectedItem);
                fgg.Parameters.AddWithValue("@HtlID", HotelID);


                con.Open();
                fgg.ExecuteNonQuery();
                con.Close();

                con.Open();

                SqlCommand GetRate = new SqlCommand("select Servicecost from Plans where Reservation_number= '" + Resv_ID + "' and Hotel_ID = '" + HotelID + "'", con);

                var GettingRate = GetRate.ExecuteScalar();

                GetRate.ExecuteNonQuery();

                Plan_rates = Convert.ToInt32(GettingRate);
              
               
                
                con.Close();
                
                this.Hide();
                Form16 f16 = new Form16();
                f16.ShowDialog();
                this.Close();


                //GetAvailableClient();
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            toolTip1.SetToolTip(pictureBox8, "Proceed to Billing");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form18 f18 = new Form18();
            f18.ShowDialog();
            this.Close();
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
    }
}




