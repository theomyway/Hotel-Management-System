using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotelmanagementsystem
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=OMARSPC;Initial Catalog=HMS;Integrated Security=True");
        int HotelID = Form2.HotelID;
        
        string username = Form2.username;
        string hotelname = Form2.Hotelname;
        public static int Room_number;
        public static int ServiceID;
        [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.StringConverter))]
        public object NullValue { get; set; }

        private void Form11_Load(object sender, EventArgs e)
        {
            showRates();
            ShowRooms();
            //this.roomTableAdapter2.Fill(this.hotelManagementSystemDataSet2.Room);
            this.roomTableAdapter2.Fill(this.dataSet22.Room);
            label1.Text = hotelname;
            label11.Text = username;

        }
        private bool IsValid()   //ENCAPSULATION

        {

            return true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO Room values (@Roomtype,@Rate,@Roomlocation,@Numberbeds,@EmployeeID,@CustomerID,@HotelID,@Condition)", con);
                cmd.CommandType = CommandType.Text;
                
                
                cmd.Parameters.AddWithValue("@Roomtype", textBox7.Text);
                cmd.Parameters.AddWithValue("@Rate", textBox6.Text);
                cmd.Parameters.AddWithValue("@Roomlocation", textBox3.Text);
                cmd.Parameters.AddWithValue("@Numberbeds", textBox1.Text);
                cmd.Parameters.AddWithValue("@CustomerID", DBNull.Value);
                cmd.Parameters.AddWithValue("@EmployeeID", DBNull.Value);
                cmd.Parameters.AddWithValue("@HotelID", HotelID);
                cmd.Parameters.AddWithValue("@Condition", textBox4.Text);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

              
                ResetFormControls();
                ShowRooms();
                showRates();

                //GetAvailableClient();
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
            

       
        private void btnReset_Click(object sender, EventArgs e)
        {
            

            textBox3.Clear();           
            textBox1.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox4.Clear();
            textBox2.Clear();
            textBox5.Clear();
        }
       public void ResetFormControls()
        {
            textBox3.Clear();
            textBox1.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox4.Clear();
            textBox2.Clear();
            textBox5.Clear();
        }

        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Update();
            this.Refresh();
            if (IsValid())
            {
                
                //SqlCommand cmd = new SqlCommand (" update ROOM SET Room_type = @Roomtype,Rates = @Rate,Room_location = @Roomlocation,NumberOFbeds = @Numberbeds,Room_condition = @Condition WHERE Room_number=@Roomnumbr", con);
                //cmd.CommandType = CommandType.Text;
                string sql = "update ROOM SET Room_type = @Roomtype,Rates = @Rate,Room_location = @Roomlocation,NumberOFbeds = @Numberbeds,Room_condition = @Condition WHERE Room_number=@Roomnumbr and Hotel_ID = @HtlID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@HtlID", HotelID);

                cmd.Parameters.AddWithValue("@Roomnum", Room_number);
                cmd.Parameters.AddWithValue("@Roomtype", textBox7.Text);
                cmd.Parameters.AddWithValue("@Rate", textBox6.Text);
                cmd.Parameters.AddWithValue("@Roomlocation", textBox3.Text);
                cmd.Parameters.AddWithValue("@Numberbeds", textBox1.Text);
                cmd.Parameters.AddWithValue("@Roomnumbr", Room_number);
                cmd.Parameters.AddWithValue("@Condition", textBox4.Text);


               // " update ROOM SET Room_type = @Roomtype,Rates = @Rate,Room_location = @Roomlocation,NumberOFbeds = @Numberbeds,Room_condition = @Condition WHERE Room_number=@Roomnumbr"

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.ExecuteScalar();
                con.Close();
               
                ShowRooms();
                showRates();

                //GetAvailableClient();
                ResetFormControls();

            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        public void showRates()
        {
            try
            {
                dataGridView2.Update();
                dataGridView2.Refresh();
                con.Open();
                string query = "select * from Plans where Hotel_ID = @HtlID";
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
        public void ShowRooms()
        {
            try
            {
                dataGridView1.Update();
                dataGridView1.Refresh();
                con.Open();
                string query = "select * from Room where Hotel_ID = @HtlID";
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

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
               
                string sql = "DELETE FROM Room WHERE Room_number = @Roomno and Hotel_ID = @HtlID";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Roomno", Room_number);
                cmd.Parameters.AddWithValue("@HtlID", HotelID);

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.ExecuteScalar();
                con.Close();
               
                ResetFormControls();
                ShowRooms();
            }

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            String value = e.Value as string;
            if ((value != null) && value.Equals(e.CellStyle.DataSourceNullValue))
            {
                e.Value = e.CellStyle.NullValue;
                e.FormattingApplied = true;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error happened " + e.Context.ToString());

            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (e.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (e.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((e.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "an error";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }

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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ServiceID = Int32.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());

            textBox2.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            textBox5.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
         

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand fgg = new SqlCommand("INSERT INTO Plans values (@Servicename,@Cost,@Res_number,@HotelID)", con);
            fgg.CommandType = CommandType.Text;


            fgg.Parameters.AddWithValue("@Servicename", textBox2.Text);
            fgg.Parameters.AddWithValue("@Cost", Convert.ToInt32(textBox5.Text));
            fgg.Parameters.AddWithValue("@Res_number", DBNull.Value);
            fgg.Parameters.AddWithValue("@HotelID", HotelID);
            con.Open();
            fgg.ExecuteNonQuery();
            con.Close();
            showRates();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            SqlCommand fgg = new SqlCommand("Update Plans set Servicename=@Servicename,Servicecost=@Cost where Service_ID=@Serviceid and Hotel_ID = @HtlID", con);
            fgg.CommandType = CommandType.Text;


            fgg.Parameters.AddWithValue("@Servicename", textBox2.Text);
            fgg.Parameters.AddWithValue("@Cost", Convert.ToInt32(textBox5.Text));
            fgg.Parameters.AddWithValue("@Serviceid", ServiceID);
            fgg.Parameters.AddWithValue("@HtlID", HotelID);
            con.Open();
            fgg.ExecuteNonQuery();
            con.Close();
            showRates();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (IsValid())
            {

                string sql = "DELETE FROM Plans WHERE Service_ID = @Servid and Hotel_ID = @HtlID";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Servid", ServiceID);
                cmd.Parameters.AddWithValue("@HtlID", HotelID);

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.ExecuteScalar();
                con.Close();
                showRates();
                ResetFormControls();
               
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

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textBox8.Text == "Room ID")
            {
                textBox8.Text = "";
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "Room ID";
            }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (textBox9.Text == "Service ID")
            {
                textBox9.Text = "";
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                textBox9.Text = "Service ID";
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Room WHERE Room_number LIKE @Name and Hotel_ID = @HtlID";
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
            string sql = "SELECT * FROM Plans WHERE Service_ID LIKE @Name and Hotel_ID = @HtlID";
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



            dataGridView2.Update();
            dataGridView2.Refresh();
        }

        private void btnInsert_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnInsert, "Add A Room");
        }

        private void btnUpdate_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnUpdate, "Update Room Info");
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnDelete, "Delete A Room");
        }

        private void btnReset_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnReset, "Clear Fields");
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button2, "Add Plans & Services");
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button3, "Update Plan Info");
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button4, "Delete A Plan");
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
