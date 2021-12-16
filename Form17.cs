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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=OMARSPC;Initial Catalog=HMS;Integrated Security=True");
        int Employee_ID;
        DataTable dt;
        string username = Form2.username;
        string hotelname = Form2.Hotelname;
        int HotelID = Form2.HotelID;
      
        int todayearned;
        
        private void Form17_Load(object sender, EventArgs e)
        {
            label11.Text = username;
            label1.Text = hotelname;
            var currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            //select SUM(Total_charge) from Billing where Payment_Date = '"+ BookingDate + "'"  where Payment_Date = '" + BookingDate + "'"
            con.Open();
            SqlCommand GetBillinID = new SqlCommand("select SUM (Total_cost) from Billing where Hotel_ID = @HtlID and Payment_Date = '" + currentDate + "'",con);
            GetBillinID.Parameters.AddWithValue("@HtlID", HotelID);
            var GettingBillingID = GetBillinID.ExecuteScalar();
            
         
            GetBillinID.ExecuteNonQuery();
            
            todayearned= Convert.ToInt32(GettingBillingID);
            con.Close();
            label5.Text = todayearned.ToString();

            try
            {
                dataGridView1.Update();
                dataGridView1.Refresh();
                con.Open();
                string query = "select * from Billing where Hotel_ID = @HtlID";
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
               
            }
        }

        private void btnHome_MouseMove(object sender, MouseEventArgs e)
        {

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

        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.Update();
                dataGridView1.Refresh();
                con.Open();
                string query = "select * from DeparturedBillingInfo where Hotel_ID = @HtlID and Payment_Date Between '" + dateTimePicker1.Value.ToString(("yyyy-MM-dd")) + "' AND '" + dateTimePicker2.Value.ToString(("yyyy-MM-dd")) + "'";
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Update();
                dataGridView1.Refresh();
                con.Open();
                string query = "select * from DeparturedBillingInfo where Hotel_ID = @HtlID";
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
               
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Update();
            this.Refresh();
            try
            {
                dataGridView1.Update();
                dataGridView1.Refresh();
                con.Open();
                string query = "select * from Billing where Hotel_ID = @HtlID";
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
               
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Update();
                dataGridView1.Refresh();
                con.Open();
                string query = "select * from Billing where Hotel_ID = @HtlID and Payment_Date Between '" + dateTimePicker1.Value.ToString(("yyyy-MM-dd")) + "' AND '" + dateTimePicker2.Value.ToString(("yyyy-MM-dd")) + "'";
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form18 f18 = new Form18();
            f18.ShowDialog();
            this.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Billing WHERE Billing_ID LIKE @BillID and Hotel_ID = @HtlID";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@BillID", "%" + Convert.ToInt32(textBox8.Text) + "%");
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

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textBox8.Text=="Billing ID")
            {
                textBox8.Text = "";
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "Billing ID";
            }
        }
    }
}




