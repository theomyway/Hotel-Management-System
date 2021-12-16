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
using System.Threading;

namespace Hotelmanagementsystem
{
    public partial class Form16 : Form
    {
        int HotelID = Form2.HotelID;
        string username = Form2.username;
        string hotelname = Form2.Hotelname;
        int Employee_ID = Form13.Employee_ID;
        int Customer_ID = Form12.CustomerID;
        int Room_No = Form14.Room_number;
        DateTime BookingDate = Form15.BookingDate;
        int Serviceid = Form11.ServiceID;
        public static int Billing_ID;
        public static int TotalCost;
        int RoomRates = Form14.Rates;
        int PlanRates = Form15.Plan_rates;
        int TotalDays = Form15.TotalDays;
        int MicsCharges;
        SqlConnection con = new SqlConnection(@"Data Source=OMARSPC;Initial Catalog=HMS;Integrated Security=True");

        private void btnHome_MouseHover(object sender, EventArgs e)
        {
            panelLeft.Height = btnHome.Height;
            panelLeft.Top = btnHome.Top;
            
        }
     
        

        private void btnAddRec_MouseHover_1(object sender, EventArgs e)
        {
            panelLeft.Height = btnAddRec.Height;
            panelLeft.Top = btnAddRec.Top;
        }

        private void btnViewFromDatabase_MouseHover_1(object sender, EventArgs e)
        {
            panelLeft.Height = btnViewFromDatabase.Height;
            panelLeft.Top = btnViewFromDatabase.Top;
        }

        private void btnFind_MouseHover_1(object sender, EventArgs e)
        {
            panelLeft.Height = btnFind.Height;
            panelLeft.Top = btnFind.Top;
        }

        private void btnSalesSummary_MouseHover_1(object sender, EventArgs e)
        {
            panelLeft.Height = btnSalesSummary.Height;
            panelLeft.Top = btnSalesSummary.Top;
        }

        private void btnSecurity_MouseHover_1(object sender, EventArgs e)
        {
            panelLeft.Height = btnSecurity.Height;
            panelLeft.Top = btnSecurity.Top;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            panelLeft.Height = button1.Height;
            panelLeft.Top = button1.Top;
        }
        private bool IsValid()   //ENCAPSULATION

        {

            return true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                int Roomcash= RoomRates * TotalDays;    //Totaldays; out-in = 10*2000=ans
                int Plancash= PlanRates * TotalDays;
                
                MicsCharges = Convert.ToInt32(textBox5.Text);
                TotalCost = Roomcash + Plancash + MicsCharges;  //Main formula for billing
                textBox4.Text = TotalCost.ToString();
               

                SqlCommand cmd = new SqlCommand("Insert into Billing values (@Roomcrg,@Micschrg,@TtlCost,@Creditcrdno,@Paydate,@CusID,@HotelID)", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Roomcrg", RoomRates);               
                cmd.Parameters.AddWithValue("@Micschrg", Convert.ToInt32(textBox5.Text));
                cmd.Parameters.AddWithValue("@TtlCost", TotalCost);
                cmd.Parameters.AddWithValue("@Creditcrdno",textBox3.Text);
                cmd.Parameters.AddWithValue("@Paydate", BookingDate);
                cmd.Parameters.AddWithValue("@CusID", Customer_ID);
                cmd.Parameters.AddWithValue("@HotelID", HotelID);


                //Checkin = Convert.ToDateTime(dateTimePicker1.Value);
                //Checkout = Convert.ToDateTime(booking_DateDateTimePicker.Value);
                

                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlCommand GetBillinID = new SqlCommand("select Billing_ID from Billing where Customer_ID= '" + Customer_ID + "' and Hotel_ID = '" + HotelID + "'", con);

                var GettingBillingID = GetBillinID.ExecuteScalar();

                GetBillinID.ExecuteNonQuery();

                Billing_ID = Convert.ToInt32(GettingBillingID);
                con.Close();
                Form8 f8 = new Form8();
                f8.ShowDialog();
                Thread.Sleep(1000);

                

                
                Form7 f7 = new Form7();
                f7.Size = new Size(286, 524);
                f7.ShowDialog();

                this.Hide();
                Form4 f4 = new Form4();
                f4.ShowDialog();
                this.Close();




            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            textBox4.Text = TotalCost.ToString();

            textBox1.Text = RoomRates.ToString();
            textBox2.Text = BookingDate.ToString();
            roundPictureBox1.BackColor = Color.RosyBrown;
            label25.BackColor = Color.RosyBrown;
            label1.Text = hotelname;
            label11.Text = username;
        }

        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

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
            toolTip1.SetToolTip(pictureBox8, "Register");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form18 f18 = new Form18();
            f18.ShowDialog();
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
