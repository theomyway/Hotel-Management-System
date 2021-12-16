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
    public partial class Form13 : Form
    {
        SqlConnection con = Form2.connectionstring;
        public Form13()
        {
            InitializeComponent();
        }
        int HotelID = Form2.HotelID;
        string username = Form2.username;
        string hotelname = Form2.Hotelname;
        public static int Employee_ID;
       // SqlConnection con = new SqlConnection(@"Data Source=OMARSPC;Initial Catalog=HMS;Integrated Security=True");
        private void btnAddRec_Click(object sender, EventArgs e)
        {

        }
        private bool IsValid()   //ENCAPSULATION

        {

            return true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {

                //SqlCommand cmd = new SqlCommand("INSERT INTO Employee values (@Fname,@Lname,@Phone,@City,@Country,@Zip,@HotelID)", con);
                //cmd.CommandType = CommandType.Text;


                //cmd.Parameters.AddWithValue("@Fname", textBox6.Text);
                //cmd.Parameters.AddWithValue("@Lname", textBox5.Text);
                //cmd.Parameters.AddWithValue("@Phone", textBox7.Text);
                //cmd.Parameters.AddWithValue("@City", textBox1.Text);
                //cmd.Parameters.AddWithValue("@Country", textBox3.Text);
                //cmd.Parameters.AddWithValue("@Zip", textBox10.Text);
                //cmd.Parameters.AddWithValue("@HotelID", HotelID);



                //con.Open();
                //cmd.ExecuteNonQuery();
                //con.Close();

               
                
                this.Hide();
                Form14 f12 = new Form14();
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
                string query = "select * from Employee full outer join Reservations on Employee.Employee_ID = Reservations.Employee_ID where Employee.Hotel_ID = @HtlID AND Reservations.Reservation_number is null ";
               
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
                MessageBox.Show(ex.Message); //add error here
            }
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            roundPictureBox4.BackColor = Color.RosyBrown;
            label13.BackColor = Color.RosyBrown;
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

        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form18 f18 = new Form18();
            f18.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Employee_ID = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox10.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
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

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Employee ID")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Employee ID";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string sql = " select * from Employee full outer join Reservations on Employee.Employee_ID = Reservations.Employee_ID where Employee.Hotel_ID = @HtlID AND Employee.Employee_ID LIKE @Name AND Reservations.Reservation_number is null ";
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
    }
}





