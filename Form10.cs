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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=OMARSPC;Initial Catalog=HMS;Integrated Security=True");
        int Employee_ID;
        DataTable dt;
        string username = Form2.username;
        string hotelname = Form2.Hotelname;
        int HotelID = Form2.HotelID;


        private void Form10_Load(object sender, EventArgs e)

        {
            GetAvailableClient();
            GetNotAvailableClient();
            label11.Text = username;
            label1.Text = hotelname;
            // this.employeeTableAdapter1.Fill(this.hotelManagementSystemDataSet1.Employee);
            this.employeeTableAdapter1.Fill(this.dataSet21.Employee);
            //GetAvailableClient();
            //GetNotAvailableClient();
            //GetcountofavailableandnotavailableEmp();
        }

        private void GetcountofavailableandnotavailableEmp()
        {

            con.Open();
            SqlCommand countNOTworkingemp = new SqlCommand("select Count(First_name) from Employee inner join Room on Employee.Employee_ID!=Room.Employee_ID inner join Reservations on Employee.Employee_ID!=Reservations.Employee_ID where Hotel_ID = @HtlID ", con);
            countNOTworkingemp.Parameters.AddWithValue("@HtlID", HotelID);
            int COE = (int)countNOTworkingemp.ExecuteScalar();

            countNOTworkingemp.ExecuteNonQuery();


            con.Close();

            label12.Text = COE.ToString();
            con.Open();
            SqlCommand countworkingemp = new SqlCommand("select Count(First_name)from Employee inner join Reservations on Employee.Employee_ID = Reservations.Employee_ID where Hotel_ID = @HtlID ", con);
            countworkingemp.Parameters.AddWithValue("@HtlID", HotelID);
            int CNE = (int)countworkingemp.ExecuteScalar();

            countworkingemp.ExecuteNonQuery();


            con.Close();
            label13.Text = CNE.ToString();
        }
        private void GetAvailableClient()
        {
            try
            {
                dataGridView1.Update();
                dataGridView1.Refresh();
                con.Open();
                string query = "select * from Employee where Hotel_ID = @HtlID";
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
        private void GetNotAvailableClient()
        {

            try
            {
                dataGridView2.Update();
                dataGridView2.Refresh();
                con.Open();
                string query = "select distinct Employee.Employee_ID,Employee.First_name,Employee.last_name,Employee.Phone_number,Employee.City from Employee inner join Reservations on Employee.Employee_ID = Reservations.Employee_ID inner join Room on  Employee.Employee_ID = Room.Employee_ID where Employee.Hotel_ID = @HtlID ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HtlID", HotelID);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt.Rows.Clear();
                da.Fill(dt);
                dataGridView2.DataSource = dt;

                con.Close();
                dataGridView2.Update();
                dataGridView2.Refresh();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ResetFormControls()
        {
            Employee_ID = 0;
            textBox1.Clear();
            
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

            textBox1.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Employee_ID = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

        }
        private bool IsValid()   //ENCAPSULATION

        {
            
            return true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Employee values (@Firstname,@Lastname,@Phone,@City,@Country,@Zipcode,@Hotel_ID)", con);
                cmd.CommandType = CommandType.Text;

               
                cmd.Parameters.AddWithValue("@Firstname", textBox7.Text);
                cmd.Parameters.AddWithValue("@Lastname", textBox6.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox5.Text);
                cmd.Parameters.AddWithValue("@City", textBox4.Text);
                cmd.Parameters.AddWithValue("@Country", textBox3.Text);
                cmd.Parameters.AddWithValue("@Zipcode", textBox1.Text);
                cmd.Parameters.AddWithValue("@Hotel_ID", HotelID);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                //GetAvailableClient();
                GetAvailableClient();
                ResetFormControls();

            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Employee WHERE Employee_ID = @EmployyeID and Hotel_ID = @HtlID ", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@EmployyeID", Employee_ID);
                cmd.Parameters.AddWithValue("@HtlID", HotelID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetAvailableClient();
               
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Update();
            this.Refresh();
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Employee SET Employee_ID =@EmployyeID,First_name=@Firstname,Last_name=@Lastname,Phone_number=@Phone,City=@City,Country_state=@Country,Zip_code=@Zipcode WHERE Employee_ID=@EmployyeID and Hotel_ID = @HtlID", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@EmployyeID", Employee_ID);
                cmd.Parameters.AddWithValue("@Firstname", textBox7.Text);
                cmd.Parameters.AddWithValue("@Lastname", textBox6.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox5.Text);
                cmd.Parameters.AddWithValue("@City", textBox4.Text);
                cmd.Parameters.AddWithValue("@Country", textBox3.Text);
                cmd.Parameters.AddWithValue("@Zipcode", textBox1.Text);
                cmd.Parameters.AddWithValue("@HtlID", HotelID);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                GetAvailableClient();
                ResetFormControls();

            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
           
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Employee WHERE Employee_ID LIKE @Name and Employee.Hotel_ID = @HtlID";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Name", "%" + Convert.ToInt32(textBox8.Text) + "%");
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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            string sql = "select distinct Employee.Employee_ID,Employee.First_name,Employee.last_name,Employee.Phone_number,Employee.City from Employee inner join Reservations on Employee.Employee_ID = Reservations.Employee_ID inner join Room on  Employee.Employee_ID = Room.Employee_ID where Employee.Hotel_ID = @HtlID and Employee.Employee_ID LIKE @Name";
           
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Name", "%" + Convert.ToInt32(textBox9.Text) + "%");
                    cmd.Parameters.AddWithValue("@HtlID", HotelID);
                    //rest of the code
                    //dataGridView.DataSource = your DataSource;
                    con.Open();
                    cmd.ExecuteScalar();

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dt.Rows.Clear();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;

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
            if (textBox8.Text == "Employee ID")
            {
                textBox8.Text = "";
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "Employee ID";
            }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (textBox9.Text == "Employee ID")
            {
                textBox9.Text = "";
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                textBox9.Text = "Employee ID";
            }
        }

        private void btnInsert_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnInsert, "Add Employee");
        }

        private void btnUpdate_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnUpdate, "Update Employee Details");
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnDelete, "Delete Employee Details");
        }

        private void btnReset_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnReset, "Clear Fields");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form18 f18 = new Form18();
            f18.ShowDialog();
            this.Close();
        }
    }
}

