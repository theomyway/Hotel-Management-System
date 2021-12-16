using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;


namespace Hotelmanagementsystem
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            panelLeft.Height = btnHome.Height;
            panelLeft.Top = btnHome.Top;
        }
        //SqlConnection con = new SqlConnection(@"Data Source=OMARSPC;Initial Catalog=HMS;Integrated Security=True");
        DataTable dt;
        //Data Source=DESKTOP-7MALSR5\OMAR;Initial Catalog=HotelManagementSystem;Integrated Security=True
        public int infinite;
        public static int Reservation_No;
        public static int CusID;
        public static int EmpID;
        int HotelID = Form2.HotelID;
        SqlConnection con = Form2.connectionstring;
        DateTime now = DateTime.Now;
        
       


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void btnHome_Click(object sender, EventArgs e)
        {
           

            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to exit", "Baglioni Hotel London", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void btnAddRec_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 f12 = new Form12();
            f12.ShowDialog();
            this.Close();

            panelLeft.Height = btnAddRec.Height;
            panelLeft.Top = btnAddRec.Top;           
            this.Hide();
            
            
            this.Close();

        }

        private void btnViewFromDatabase_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form11 f11= new Form11();
            f11.ShowDialog();
            this.Close();
         

            Thread.Sleep(5000);
           
            panelLeft.Height = btnViewFromDatabase.Height;
            panelLeft.Top = btnViewFromDatabase.Top;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 f10 = new Form10();
            f10.ShowDialog();
            this.Close();
            panelLeft.Height = btnFind.Height;
            panelLeft.Top = btnFind.Top;
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();

        }
        Form2 f2;
        private void Form4_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            GenerateDeparturedStats();

            label1.Text = Form2.Hotelname;
            label5.Text = Form2.username;

            try
            {
                dataGridView1.Update();
                dataGridView1.Refresh();
                con.Open();
                string query = "select * From Reservations where Hotel_ID = @HtlID";
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

            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7MALSR5\OMAR;Initial Catalog=HotelManagementSystem;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand("Select * from HMS", con);
            //dt = new DataTable();
            //con.Open();
            //SqlDataReader sdr = cmd.ExecuteReader();
            //dt.Load(sdr);
            //con.Close();
            //dataGridViewCustomerRecord.DataSource = dt;

            GenerateStats();





        }

        //private void F2_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    f2 = null;
        //}//MDI

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void showResv()
        {
            try
            {
                dataGridView1.Update();
                dataGridView1.Refresh();
                con.Open();
                string query = "select * From Reservations  where Hotel_ID = @HtlID ";
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
           

            GenerateStats();


        }


        private void panel3_Paint(object sender, PaintEventArgs e)
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
            panelLeft.Top =btnSecurity.Top;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            panelLeft.Height = button1.Height;
            panelLeft.Top = button1.Top;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_MouseHover(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.Silver;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.Transparent;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public void GenerateStats()
        {
            
            con.Open();
            SqlCommand check_User_Pass = new SqlCommand("SELECT COUNT(Room_number) FROM [Room]  where Hotel_ID = @HtlID", con);
            check_User_Pass.Parameters.AddWithValue("@HtlID", HotelID);
            int RoomNoCount = (int)check_User_Pass.ExecuteScalar();

            check_User_Pass.ExecuteNonQuery();
            con.Close();
            circularProgressBar1.Value = 0;

            circularProgressBar1.Maximum = 100;

            for (int i = 0; i <= RoomNoCount; i++)
            {
                Thread.Sleep(30);
                circularProgressBar1.Value = i;
                circularProgressBar1.Update();
            }
            con.Open();
            SqlCommand checkoccrooms = new SqlCommand("SELECT count(*) FROM Room WHERE Hotel_ID = @HtlID AND Customer_ID IS NOT NULL", con);
            checkoccrooms.Parameters.AddWithValue("@HtlID", HotelID);
            int OccRoomNoCount = (int)checkoccrooms.ExecuteScalar();

            checkoccrooms.ExecuteNonQuery();
            con.Close();
            circularProgressBar2.Value = 0;

            circularProgressBar2.Maximum = 100;

            for (int i = 0; i <= OccRoomNoCount; i++)
            {
                Thread.Sleep(30);
                circularProgressBar2.Value = i;
                circularProgressBar2.Update();
            }
            con.Open();

            SqlCommand check_DirtyRooms = new SqlCommand("SELECT COUNT(Room_condition) FROM Room where Room_condition='Dirty' and Hotel_ID = @HtlID", con);

            check_DirtyRooms.Parameters.AddWithValue("@HtlID", HotelID);

            int DirtyRoomCount = (int)check_DirtyRooms.ExecuteScalar();

            check_DirtyRooms.ExecuteNonQuery();
            con.Close();
            circularProgressBar3.Value = 0;

            circularProgressBar3.Maximum = 100;

            for (int i = 0; i <= DirtyRoomCount; i++)
            {
                Thread.Sleep(30);
                circularProgressBar3.Value = i;
                circularProgressBar3.Update();
            }
            con.Open();
            SqlCommand countttstaff = new SqlCommand("select Count(Employee_ID) from Employee where Hotel_ID = @HtlID ", con);
            countttstaff.Parameters.AddWithValue("@HtlID", HotelID);
            int CTS = (int)countttstaff.ExecuteScalar();

            countttstaff.ExecuteNonQuery();


            con.Close();
            circularProgressBar4.Value = 0;

            circularProgressBar4.Maximum = 100;

            for (int i = 0; i <= CTS; i++)
            {
                Thread.Sleep(30);
                circularProgressBar4.Value = i;
                circularProgressBar4.Update();
            }
            con.Open();

            SqlCommand check_CleanRooms = new SqlCommand("select count(NumberOFguests) from Reservations where Hotel_ID = @HtlID", con);

            check_CleanRooms.Parameters.AddWithValue("@HtlID", HotelID);

            int cleanRoomCount = (int)check_CleanRooms.ExecuteScalar();

            check_CleanRooms.ExecuteNonQuery();
            con.Close();
            circularProgressBar5.Value = 0;
            
            circularProgressBar5.Maximum =100;
           

            for (int i = 0; i <= cleanRoomCount; i++)
            {
                Thread.Sleep(30);
                circularProgressBar5.Value = i;
                circularProgressBar5.Update();
                circularProgressBar5.Text = cleanRoomCount.ToString();                
            }
            //con.Open();
            //SqlCommand check_No_Guests = new SqlCommand("select Count(Employee_ID) from Employee", con);

            //int GuestsCount = (int)check_No_Guests.ExecuteScalar();

            //check_User_Pass.ExecuteNonQuery();
            //con.Close();
            //circularProgressBar5.Value = 0;

            //circularProgressBar5.Maximum = 100;

            //for (int i = 0; i <= GuestsCount; i++)
            //{
            //    Thread.Sleep(30);
            //    circularProgressBar5.Value = i;
            //    circularProgressBar5.Update();
            //}
            con.Open();
            SqlCommand countworkingemp = new SqlCommand("select Count(Employee_ID) from Reservations where Hotel_ID = @HtlID ", con);
            countworkingemp.Parameters.AddWithValue("@HtlID", HotelID);
            int CNE = (int)countworkingemp.ExecuteScalar();
          

            countworkingemp.ExecuteNonQuery();


            con.Close();
            circularProgressBar6.Value = 0;

            circularProgressBar6.Maximum = 100;

            for (int i = 0; i <= CNE; i++)
            {
                Thread.Sleep(30);
                circularProgressBar6.Value = i;
                circularProgressBar6.Update();
            }
            

        }

        private void pictureBox12_Click(object sender, EventArgs e)

        {
            GenerateStats();
            this.Update();
            this.Refresh();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void circularProgressBar3_Click(object sender, EventArgs e)
        {

        }

        private void btnexitform2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void circularProgressBar4_Click(object sender, EventArgs e)
        {

        }
        public void GenerateDeparturedStats()
        {
            try
            {
                dataGridView2.Update();
                dataGridView2.Refresh();
                con.Open();
                string query = "select * from Departured where Hotel_ID = @HtlID";
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
        private bool IsValid()   //ENCAPSULATION

        {

            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {

                //SqlCommand cmd = new SqlCommand (" update ROOM SET Room_type = @Roomtype,Rates = @Rate,Room_location = @Roomlocation,NumberOFbeds = @Numberbeds,Room_condition = @Condition WHERE Room_number=@Roomnumbr", con);
                //cmd.CommandType = CommandType.Text;
                string sql = "update Plans set Reservation_number = Null where Reservation_number = @Resno and Hotel_ID = @HtlID";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Resno", Reservation_No);
                cmd.Parameters.AddWithValue("@HtlID", HotelID);






                // " update ROOM SET Room_type = @Roomtype,Rates = @Rate,Room_location = @Roomlocation,NumberOFbeds = @Numberbeds,Room_condition = @Condition WHERE Room_number=@Roomnumbr"

                con.Open();
                cmd.ExecuteNonQuery();
                
                con.Close();


            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (IsValid())
            {
                //DELETE FROM Reservations WHERE Reservation_number = @Resnoo and Hotel_ID = @HtlID
                //string sql = "CREATE PROCEDURE DelResv @Resvno int, @Hotelid bigint AS BEGIN DELETE FROM Reservations WHERE Reservation_number = @Resvno AND Hotel_ID = @Hotelid END";

                SqlCommand cmd = new SqlCommand("DelResv", con);
                cmd.CommandType = CommandType.StoredProcedure;  //Stored Procedure DelResv
                cmd.Parameters.AddWithValue("@Resvno", Reservation_No);
                cmd.Parameters.AddWithValue("@Hotelid", HotelID);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
                


            }
            if (IsValid())
            {

                //string sql = "DELETE FROM Billing WHERE Customer_ID = @CussID and Hotel_ID = @HtlID";

                //SqlCommand cmd = new SqlCommand(sql, con);

                //cmd.Parameters.AddWithValue("@CussID", CusID);
                //cmd.Parameters.AddWithValue("@HtlID", HotelID);

                //con.Open();
                //cmd.ExecuteScalar();

                //con.Close();
                SqlCommand cmd = new SqlCommand("DelBillinginfo", con);
                cmd.CommandType = CommandType.StoredProcedure;  //Stored Procedure DelBillInfo
                cmd.Parameters.AddWithValue("@CussID", CusID);
                cmd.Parameters.AddWithValue("@HtlID", HotelID);

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();


            }
            if (IsValid())
            {

                //SqlCommand cmd = new SqlCommand (" update ROOM SET Room_type = @Roomtype,Rates = @Rate,Room_location = @Roomlocation,NumberOFbeds = @Numberbeds,Room_condition = @Condition WHERE Room_number=@Roomnumbr", con);
                //cmd.CommandType = CommandType.Text;
                string sql = "update Room set Customer_ID = Null where Customer_ID = @CussID and Hotel_ID = @HtlID";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@CussID", CusID);
                cmd.Parameters.AddWithValue("@HtlID", HotelID);




                // " update ROOM SET Room_type = @Roomtype,Rates = @Rate,Room_location = @Roomlocation,NumberOFbeds = @Numberbeds,Room_condition = @Condition WHERE Room_number=@Roomnumbr"

                con.Open();
                cmd.ExecuteScalar();
                
                
                con.Close();


            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (IsValid())
            {

                //SqlCommand cmd = new SqlCommand (" update ROOM SET Room_type = @Roomtype,Rates = @Rate,Room_location = @Roomlocation,NumberOFbeds = @Numberbeds,Room_condition = @Condition WHERE Room_number=@Roomnumbr", con);
                //cmd.CommandType = CommandType.Text;
                string sql = "update Room set Employee_ID = Null where Employee_ID = @EmpppID and Hotel_ID = @HtlID";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@EmpppID", EmpID);
                cmd.Parameters.AddWithValue("@HtlID", HotelID);




                // " update ROOM SET Room_type = @Roomtype,Rates = @Rate,Room_location = @Roomlocation,NumberOFbeds = @Numberbeds,Room_condition = @Condition WHERE Room_number=@Roomnumbr"

                con.Open();
                cmd.ExecuteNonQuery();
               
                con.Close();


            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (IsValid())
            {

                //SqlCommand cmd = new SqlCommand (" update ROOM SET Room_type = @Roomtype,Rates = @Rate,Room_location = @Roomlocation,NumberOFbeds = @Numberbeds,Room_condition = @Condition WHERE Room_number=@Roomnumbr", con);
                //cmd.CommandType = CommandType.Text;
                string sql = "Delete from Customer where Customer_ID=@CusID";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@CusID", CusID);
                cmd.Parameters.AddWithValue("@HtlID", HotelID);




                // " update ROOM SET Room_type = @Roomtype,Rates = @Rate,Room_location = @Roomlocation,NumberOFbeds = @Numberbeds,Room_condition = @Condition WHERE Room_number=@Roomnumbr"

                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();


            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            showResv();
           
            
            //InsertToDeparture();
            
            GenerateDeparturedStats();

        }
        //public void InsertToDeparture()
        //{
        //        //string MNJ = "SET IDENTITY_INSERT Departured ON";
        //        //string DFR = "SET IDENTITY_INSERT Departured OFF";

        //        //SqlCommand DFC = new SqlCommand(DFR, con);


        //        //SqlCommand DXC = new SqlCommand(MNJ, con);

        //        string DEF = "INSERT INTO Departured (First_name,Last_name,Phone_number,City,Country_state,Zip_code,Hotel_ID) select Customer.First_name,Customer.Last_name,Customer.Phone_number,Customer.City,Customer.Country_state,Customer.Zip_code,Customer.Hotel_ID from Customer FULL OUTER JOIN Departured on Customer.Customer_ID = Departured.Customer_ID WHERE Departured.Customer_ID is null and Customer.Customer_ID = @CusID";

        //        SqlCommand SED = new SqlCommand(DEF, con);

        //      SED.Parameters.AddWithValue("@CusID", CusID);
        //      SED.Parameters.AddWithValue("@HtlID", HotelID);


        //        con.Open();
        //        //DXC.ExecuteNonQuery();
        //        SED.ExecuteNonQuery();
        //        //DFC.ExecuteNonQuery();
        //        con.Close();

            
            
           
        //}
        //public void InsertToDeparturedBillingInfo()
        //{
        //    if (IsValid())
        //    {
        //        string MNJ = "SET IDENTITY_INSERT DeparturedBillingInfo ON";
        //        string DFR = "SET IDENTITY_INSERT DeparturedBillingInfo OFF";

        //        SqlCommand DFC = new SqlCommand(DFR, con);


        //        SqlCommand DXC = new SqlCommand(MNJ, con);

        //        string DEF = "INSERT INTO DeparturedBillingInfo (Billing_ID,Room_charge,Misc_charges,Total_charge,CreditCard_No,Payment_Date,Customer_ID,Hotel_ID) select Billing_ID,Room_charge,Misc_charges,Total_charge,CreditCard_No,Payment_Date,Customer_ID,Hotel_ID from Billing ";

        //        SqlCommand SED = new SqlCommand(DEF, con);

        //        SED.Parameters.AddWithValue("@Custm_ID", CusID);
        //        SED.Parameters.AddWithValue("@HtlID", HotelID);


        //        con.Open();
        //        DXC.ExecuteNonQuery();
        //        SED.ExecuteNonQuery();
        //        DFC.ExecuteNonQuery();
        //        con.Close();

        //    }

        //    else
        //    {
        //        MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Reservation_No = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            CusID = Int32.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            EmpID = Int32.Parse(dataGridView1.SelectedRows[0].Cells[9].Value.ToString());
        }

        private void btnSalesSummary_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form17 f17 = new Form17();
            f17.ShowDialog();
            this.Close();
        }

        private void btnSecurity_Click(object sender, EventArgs e)
        {
            
            Form6 f6 = new Form6();
            f6.ShowDialog();
            
            
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 f12 = new Form12();
            f12.ShowDialog();
            this.Close();
        }

        private void circularProgressBar2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int pp = DateTime.Now.Hour;
            label13.Text = pp.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Reservations WHERE Reservation_number LIKE @Name and Hotel_ID = @HtlID";
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

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Reservation ID")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Reservation ID";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Departured WHERE Customer_ID LIKE @Name and Hotel_ID = @HtlID";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Name", "%" + Convert.ToInt32(textBox1.Text) + "%");
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

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Customer ID")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Customer ID";
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
           label13.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnDelete, "Delete Reservations");
        }

        private void pictureBox12_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox12, "Refresh Records");
        }

        private void pictureBox13_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox13, "New Reservation");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form18 f18 = new Form18();
            f18.ShowDialog();
            this.Close();

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();
        }
    }
}
