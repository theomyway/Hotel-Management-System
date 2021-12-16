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

namespace Hotelmanagementsystem
{
    public partial class Form14 : Form
    {
        SqlConnection con = Form2.connectionstring;
        public Form14()
        {
            InitializeComponent();
        }
        int HotelID = Form2.HotelID;
        string username = Form2.username;
        string hotelname = Form2.Hotelname;
        int Employee_ID = Form13.Employee_ID;
        int Customer_ID = Form12.CustomerID;
        public static int Room_number;
        public static int Rates;

        //SqlConnection con = new SqlConnection(@"Data Source=OMARSPC;Initial Catalog=HMS;Integrated Security=True");
        private bool IsValid()   //ENCAPSULATION

        {

            return true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {

                string sql = "update ROOM SET Customer_ID = @CusID, Employee_ID = @EmpID WHERE Room_number = @Roomnumbr and Hotel_ID = @HtlID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@CusID", Customer_ID);
                cmd.Parameters.AddWithValue("@EmpID", Employee_ID);
                cmd.Parameters.AddWithValue("@Roomnumbr", Room_number);
                cmd.Parameters.AddWithValue("@HtlID", HotelID);

                con.Open();
                cmd.ExecuteScalar();
                cmd.ExecuteNonQuery();

                //select Reservation_number from Reservations where Customer_ID= '" + Customer_ID + "' AND Employee_ID = '" + Employee_ID + "'"
                SqlCommand GetRate = new SqlCommand("select Rates from Room where Customer_ID= '" + Customer_ID + "' AND Employee_ID = '" + Employee_ID + "' and Hotel_ID = '" + HotelID + "'", con);

                var GettingRate = GetRate.ExecuteScalar();

                GetRate.ExecuteNonQuery();

                Rates = Convert.ToInt32(GettingRate);


                con.Close();
                Generatetable();
                this.Hide();
                Form15 f12 = new Form15();
                f12.ShowDialog();
                this.Close();



                //GetAvailableClient();
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Generatetable()
        {
            try
            {
                dataGridView1.Update();
                dataGridView1.Refresh();
                con.Open();
                string query = "select * from Room where Hotel_ID = @HtlID and Customer_ID IS NULL";
                /*"/*select distinct * from Room RM inner join Reservations RS on RM.Room_number != RS.Room_number inner join Room  on RM.Room_Number != RM.Employee_ID*/
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HtlID", HotelID);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt.Rows.Clear();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
                dataGridView1.Update();
                dataGridView1.Refresh();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Form14_Load(object sender, EventArgs e)
        {
            roundPictureBox3.BackColor = Color.RosyBrown;
            label12.BackColor = Color.RosyBrown;
            label1.Text = hotelname;
            label11.Text = username;
            Generatetable();

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Room_number = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            textBox7.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();

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

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Room ID")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Room ID";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // select * from Room where Hotel_ID = @HtlID and Customer_ID IS NULL
            string sql = "select * from Room where Room_number LIKE @Name and Hotel_ID = @HtlID and Customer_ID IS NULL ";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Name", "%" + Convert.ToInt32(textBox2.Text) + "%");
                    cmd.Parameters.AddWithValue("@HtlID", HotelID);
                    //rest of the code
                    //dataGridView.DataSource = your DataSource;
                    con.Open();
                    cmd.ExecuteScalar();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dt.Rows.Clear();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }



            dataGridView1.Update();
            dataGridView1.Refresh();
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

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


