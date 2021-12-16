using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;


namespace Hotelmanagementsystem
{
    public partial class Form3 : Form
    {

        
        public Form3()
        {
            InitializeComponent();
            

           
            
            panel4.Height = btnInsert.Height;
            panel4.Top = btnInsert.Top;
        }
        DataTable dt;
        DateTime DateIn, DateOut, BookingDate;
        int TotalDays;
        int Singleroom, Doubleroom, Familyroom, Totalcost;
       


        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7MALSR5\OMAR;Initial Catalog=HotelManagementSystem;Integrated Security=True");
        public int ClientID;
        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label12.Text = Form2.username;
            label13.Text = Form2.Hotelname;

            // TODO: This line of code loads data into the 'hotelManagementSystemDataSet.HMS' table. You can move, or remove it, as needed.
            
            GetCustomerInfo();
            combobox1.Items.Add("");
            combobox1.Items.Add("Single");
            combobox1.Items.Add("Double");
            combobox1.Items.Add("Family");
            comboBox10.Items.Add("");
            comboBox10.Items.Add("Male");
            comboBox10.Items.Add("Female");
            comboBox3.Items.Add("");
            comboBox3.Items.Add("A la carte");
            comboBox3.Items.Add("All-Inclusive (AI)");
            comboBox3.Items.Add("American Plan (AP)");
            comboBox3.Items.Add("Bed & Breakfast (BB)");
            comboBox3.Items.Add("Continental Plan (CP) ");
            comboBox3.Items.Add("European Plan (EP)");
            comboBox3.Items.Add("Family American Plan (FA)");
            comboBox3.Items.Add("Family Plan  (FP)");
            comboBox3.Items.Add("Half Board (or Half Pension)");
            comboBox3.Items.Add("Modified American Plan (MAP) ");

        }

        private void GetCustomerInfo()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7MALSR5\OMAR;Initial Catalog=HotelManagementSystem;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from HMS", con);
            dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridViewCustomerRecord.DataSource = dt;


        }
       
        public void btnInsert_Click(object sender, EventArgs e)
        {
            panel4.Height = btnInsert.Height;
            panel4.Top = btnInsert.Top;

            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("Insert into HMS values (@FirstName,@LastName,@Address,@PostCode,@TelNo,@Meal,@Gender,@BookingDate,@CheckIn,@CheckOut)",con);
                cmd.CommandType = CommandType.Text;
                
                BookingDate = Convert.ToDateTime(booking_DateDateTimePicker.Value);
                DateIn = Convert.ToDateTime(check_InDateTimePicker.Value);
                DateOut = Convert.ToDateTime(check_OutDateTimePicker.Value);
                cmd.Parameters.AddWithValue("@Firstname", textBoxFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", textBoxLastName.Text);
                cmd.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                cmd.Parameters.AddWithValue("@PostCode", textBoxPostCode.Text);
                cmd.Parameters.AddWithValue("@Telno", textBoxTelNo.Text);
                cmd.Parameters.AddWithValue("@Meal", textBoxMeal.Text);
                cmd.Parameters.AddWithValue("@Gender", textBoxGender.Text);
                cmd.Parameters.AddWithValue("@BookingDate", BookingDate);
                cmd.Parameters.AddWithValue("@CheckIn", DateIn);
                cmd.Parameters.AddWithValue("@CheckOut", DateOut);
               

                

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("The Rec has been saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetCustomerInfo();
                ResetFormControls();
             
            }
        }

        private bool IsValid()   //ENCAPSULATION

        {
            if (textBoxFirstName.Text == string.Empty)
            {
                MessageBox.Show("Client's First name cannot be empty", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            panel4.Height = btnReset.Height;
            panel4.Top = btnReset.Top;
            ResetFormControls();
        }

        private void ResetFormControls()
        {
            ClientID = 0;
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxAddress.Clear();
            textBoxPostCode.Clear();
            textBoxTelNo.Clear();
            textBoxMeal.Clear();
            textBoxGender.Clear();
            textBox1.Clear();
            textBox2.Clear();
            
            
           
            textBoxFirstName.Focus();
        }

        public void dataGridViewCustomerRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            ClientID = Convert.ToInt32(dataGridViewCustomerRecord.SelectedRows[0].Cells[0].Value);
            textBoxFirstName.Text = dataGridViewCustomerRecord.SelectedRows[0].Cells[1].Value.ToString();
            textBoxLastName.Text = dataGridViewCustomerRecord.SelectedRows[0].Cells[2].Value.ToString();
            textBoxAddress.Text = dataGridViewCustomerRecord.SelectedRows[0].Cells[3].Value.ToString();
            textBoxPostCode.Text = dataGridViewCustomerRecord.SelectedRows[0].Cells[4].Value.ToString();
            textBoxTelNo.Text = dataGridViewCustomerRecord.SelectedRows[0].Cells[5].Value.ToString();
            textBoxMeal.Text = dataGridViewCustomerRecord.SelectedRows[0].Cells[6].Value.ToString();
            textBoxGender.Text = dataGridViewCustomerRecord.SelectedRows[0].Cells[7].Value.ToString();
            booking_DateDateTimePicker.Value = Convert.ToDateTime(dataGridViewCustomerRecord.Rows[e.RowIndex].Cells[8].Value.ToString());
            check_InDateTimePicker.Value = Convert.ToDateTime(dataGridViewCustomerRecord.Rows[e.RowIndex].Cells[9].Value.ToString());
            check_OutDateTimePicker.Value = Convert.ToDateTime(dataGridViewCustomerRecord.Rows[e.RowIndex].Cells[10].Value.ToString());

        }

        private void hMSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.hMSBindingSource.EndEdit();
            

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            panel4.Height = btnUpdate.Height;
            panel4.Top = btnUpdate.Top;
            if(ClientID>0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE HMS SET [First Name]= @Name,[Last Name]= @Last,Address= @Add,[Post Code]= @Post,TelNo= @Tel,Meal = @Me,Gender= @Gen,[Booking Date]= @Booking,[Check In] = @In,[Check Out]= @Out WHERE ClientID= @ID", con);
                cmd.CommandType = CommandType.Text;
                DateTime DateIn, DateOut, BookingDate;
                BookingDate = Convert.ToDateTime(booking_DateDateTimePicker.Value);
                DateIn = Convert.ToDateTime(check_InDateTimePicker.Value);
                DateOut = Convert.ToDateTime(check_OutDateTimePicker.Value);
                cmd.Parameters.AddWithValue("@name", textBoxFirstName.Text);
                cmd.Parameters.AddWithValue("@Last", textBoxLastName.Text);
                cmd.Parameters.AddWithValue("@Add", textBoxAddress.Text);
                cmd.Parameters.AddWithValue("@Post", textBoxPostCode.Text);
                cmd.Parameters.AddWithValue("@Tel", textBoxTelNo.Text);
                cmd.Parameters.AddWithValue("@Me", textBoxMeal.Text);
                cmd.Parameters.AddWithValue("@Gen", textBoxGender.Text);
                cmd.Parameters.AddWithValue("@Booking", BookingDate);
                cmd.Parameters.AddWithValue("@In", DateIn);
                cmd.Parameters.AddWithValue("@Out", DateOut);
                cmd.Parameters.AddWithValue("@ID", this.ClientID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetCustomerInfo();
                ResetFormControls();

            }
            else
            {
                MessageBox.Show("Please select a client to update his information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            panel4.Height = btnDelete.Height;
            panel4.Top = btnDelete.Top;
            if(ClientID>0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM HMS WHERE ClientID= @ID", con);
                cmd.CommandType = CommandType.Text;
               
                cmd.Parameters.AddWithValue("@ID", this.ClientID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetCustomerInfo();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please select a client info to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void dataGridViewCustomerRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBoxTelNo_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"^([0-9]{2})([0-9]{2})([0-9]{7})$", textBoxTelNo, pictureBox1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Height = button2.Height;
            panel4.Top = button2.Top;
            DataView Dv = new DataView(dt);
            Dv.RowFilter = string.Format("convert(ClientID, 'System.String') Like '%{0}%' ",
                             textBox3.Text);
  
            dataGridViewCustomerRecord.DataSource = Dv;
          
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataView Dv = new DataView(dt);
            Dv.RowFilter = string.Format("[First Name] LIKE '%{0}%'", textBox4.Text);
            dataGridViewCustomerRecord.DataSource = Dv;
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"^([A-Za-z]{2,8})$", textBoxFirstName, pictureBox3);
        }

        private void textBoxGender_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {

            Regexp(@"^([A-Za-z]{2,8})$", textBoxLastName, pictureBox2);
        }

        private void textBoxPostCode_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"^([A-Za-z]{1,5})([0-9]{6})$", textBoxPostCode, pictureBox6);
        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {

            Regexp(@"^([A-Za-z]{1})-([0-9]{1,4})$", textBoxAddress, pictureBox7);
        }

        private void textBoxMeal_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form4 f4 = new Form4();
            f4.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {

                textBoxMeal.Text = "Choose a Meal Plan";
            }
            if (comboBox3.Text == "A la carte")
            {

                textBoxMeal.Text = string.Format("{0:c}", (0));
            }
            if (comboBox3.Text == "All-Inclusive (AI)")
            {

                textBoxMeal.Text = string.Format("{0:c}", (8000));
            }
         
            if (comboBox3.Text == "American Plan (AP)")
            {

                textBoxMeal.Text = string.Format("{0:c}", (5000));
            }
            if (comboBox3.Text == "Bed & Breakfast (BB)")
            {

                textBoxMeal.Text = string.Format("{0:c}", (2500));
            }
            if (comboBox3.Text == "Continental Plan (CP)")
            {

                textBoxMeal.Text = string.Format("{0:c}", (1400));
            }
            if (comboBox3.Text == "European Plan (EP)")
            {

                textBoxMeal.Text = string.Format("{0:c}", (200));
            }
            if (comboBox3.Text == "Family American Plan (FA)")
            {

                textBoxMeal.Text = string.Format("{0:c}", (6500));
            }
            if (comboBox3.Text == "Family Plan  (FP)")
            {

                textBoxMeal.Text = string.Format("{0:c}", (6200));
            }
            if (comboBox3.Text == "Half Board (or Half Pension)")
            {

                textBoxMeal.Text = string.Format("{0:c}", (4000));
            }
            if (comboBox3.Text == "Modified American Plan (MAP)")
            {

                textBoxMeal.Text = string.Format("{0:c}", (5500));
            }
           

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox10.Text == "")
            {

                textBoxGender.Text = "Choose Your Gender";
            }
            if (comboBox10.Text == "Male")
            {

                textBoxGender.Text = "Male";
            }
            if (comboBox10.Text == "Female")
            {

                textBoxGender.Text = "Female";
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)

        {

            Singleroom = 18000;
            Doubleroom = 30000;
            Familyroom = 50000;
            if (combobox1.Text == "")
            {

                textBox1.Text = "";
            }
            if (combobox1.Text == "Single")
            {
                
                textBox1.Text = string.Format("{0:c}", (Singleroom));
            }
            if (combobox1.Text == "Double")
            {
               
                textBox1.Text = string.Format("{0:c}", (Doubleroom));
            }
            if (combobox1.Text == "Family")
            {
               
                textBox1.Text = string.Format("{0:c}", (Familyroom));
            }

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //  mail@mail.com                        => ^([\w]+)@([\w]+)\.([\w]+)$
            //  http://www.google.com                => ^(http://www\.)([\w]+)\.([\w]+)$
            //  Phone Number like : 0011 XXX XXX XXX => ^(0011)(([ ][0-9]{3}){3})$
            //  Date XX/XX/XXXX                      => ^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$
        
          
                
            int Singleroom, Doubleroom, Familyroom, Totalcost;
            Singleroom = 18000;
            Doubleroom = 30000;
            Familyroom = 50000;
            int ALC, AI, AP, BB, CP, EP, FA, FP, HB, MAP;
            ALC = 0;
            AI = 8000;
            AP = 5000;
            BB = 2500;
            CP = 1400;
            EP = 200;
            FA = 6500;
            FP = 6200;
            HB = 4000;
            MAP = 5500;


            DateIn = Convert.ToDateTime(check_InDateTimePicker.Value);
            DateOut = Convert.ToDateTime(check_OutDateTimePicker.Value);
            TotalDays = (DateOut - DateIn).Days;

            //SINGLE ROOM
            if (combobox1.Text == "Single" && comboBox3.Text== "A la carte" )
            {
                Totalcost = (Singleroom * TotalDays) + (TotalDays*ALC);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Single" && comboBox3.Text == "All-Inclusive (AI)")
            {
                Totalcost = (Singleroom * TotalDays) + (TotalDays * AI);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Single" && comboBox3.Text == "American Plan (AP)")
            {
                Totalcost = (Singleroom * TotalDays) + (TotalDays * AP);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Single" && comboBox3.Text == "Bed & Breakfast (BB)")
            {
                Totalcost = (Singleroom * TotalDays) + (TotalDays * BB);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Single" && comboBox3.Text == "Continental Plan (CP)")
            {
                Totalcost = (Singleroom * TotalDays) + (TotalDays * CP);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Single" && comboBox3.Text == "European Plan (EP)")
            {
                Totalcost = (Singleroom * TotalDays) + (TotalDays * EP);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Single" && comboBox3.Text == "Family American Plan (FA)")
            {
                Totalcost = (Singleroom * TotalDays) + (TotalDays * FA);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }

            if (combobox1.Text == "Single" && comboBox3.Text == "Family Plan  (FP)")
            {
                Totalcost = (Singleroom * TotalDays) + (TotalDays * FP);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Single" && comboBox3.Text == "Half Board (or Half Pension)")
            {
                Totalcost = (Singleroom * TotalDays) + (TotalDays * HB);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Single" && comboBox3.Text == "Modified American Plan (MAP)")
            {
                Totalcost = (Singleroom * TotalDays) + (TotalDays * MAP);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            //SINGLE ROOM
            //-----x-----
            //DOUBLE ROOM
            if (combobox1.Text == "Double" && comboBox3.Text == "A la carte")
            {
                Totalcost = (Doubleroom * TotalDays) + (TotalDays * ALC);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Double" && comboBox3.Text == "All-Inclusive (AI)")
            {
                Totalcost = (Doubleroom * TotalDays) + (TotalDays * AI);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Double" && comboBox3.Text == "American Plan (AP)")
            {
                Totalcost = (Doubleroom * TotalDays) + (TotalDays * AP);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Double" && comboBox3.Text == "Bed & Breakfast (BB)")
            {
                Totalcost = (Doubleroom * TotalDays) + (TotalDays * BB);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Double" && comboBox3.Text == "Continental Plan (CP)")
            {
                Totalcost = (Doubleroom * TotalDays) + (TotalDays * CP);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Double" && comboBox3.Text == "European Plan (EP)")
            {
                Totalcost = (Doubleroom * TotalDays) + (TotalDays * EP);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Double" && comboBox3.Text == "Family American Plan (FA)")
            {
                Totalcost = (Doubleroom * TotalDays) + (TotalDays * FA);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }

            if (combobox1.Text == "Double" && comboBox3.Text == "Family Plan  (FP)")
            {
                Totalcost = (Doubleroom * TotalDays) + (TotalDays * FP);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Double" && comboBox3.Text == "Half Board (or Half Pension)")
            {
                Totalcost = (Doubleroom * TotalDays) + (TotalDays * HB);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Double" && comboBox3.Text == "Modified American Plan (MAP)")
            {
                Totalcost = (Doubleroom * TotalDays) + (TotalDays * MAP);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }

            //DOUBLE ROOM
            //------x----
            //FAMILY 
            if (combobox1.Text == "Family" && comboBox3.Text == "A la carte")
            {
                Totalcost = (Familyroom * TotalDays) + (TotalDays * ALC);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Family" && comboBox3.Text == "All-Inclusive (AI)")
            {
                Totalcost = (Familyroom * TotalDays) + (TotalDays * AI);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Family" && comboBox3.Text == "American Plan (AP)")
            {
                Totalcost = (Familyroom * TotalDays) + (TotalDays * AP);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Family" && comboBox3.Text == "Bed & Breakfast (BB)")
            {
                Totalcost = (Familyroom * TotalDays) + (TotalDays * BB);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Family" && comboBox3.Text == "Continental Plan (CP)")
            {
                Totalcost = (Familyroom * TotalDays) + (TotalDays * CP);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Family" && comboBox3.Text == "European Plan (EP)")
            {
                Totalcost = (Familyroom * TotalDays) + (TotalDays * EP);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Family" && comboBox3.Text == "Family American Plan (FA)")
            {
                Totalcost = (Familyroom * TotalDays) + (TotalDays * FA);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }

            if (combobox1.Text == "Family" && comboBox3.Text == "Family Plan  (FP)")
            {
                Totalcost = (Familyroom * TotalDays) + (TotalDays * FP);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Family" && comboBox3.Text == "Half Board (or Half Pension)")
            {
                Totalcost = (Familyroom * TotalDays) + (TotalDays * HB);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }
            if (combobox1.Text == "Family" && comboBox3.Text == "Modified American Plan (MAP)")
            {
                Totalcost = (Familyroom * TotalDays) + (TotalDays * MAP);
                textBox2.Text = string.Format("{0:c}", (Totalcost));
            }

            //FAMILY 
            Form8 f8 = new Form8();
            f8.ShowDialog();
            Thread.Sleep(2000);
        }
        private void Regexp(string re, TextBox tb, PictureBox pc)    //ENCAPSULATION
        {
            Regex regex = new Regex(re);

            if (regex.IsMatch(tb.Text))
            {
                pc.Image = Properties.Resources.verified_account_24px;
              
               
            }
            else
            {
                pc.Image = Properties.Resources.delete_16px;
                
              
            }
        }

    }
    


    }



