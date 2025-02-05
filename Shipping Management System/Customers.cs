using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shipping_Management_System.Properties;

namespace Shipping_Management_System
{
    public partial class Customers : Form
    {



        //BlackFields of the class
        string connectionString = "Data Source=DESKTOP-LK1SELP;Database=Shipping;Integrated Security=true;";
        public Customers()
        {
            InitializeComponent();




            comboChoose.Items.Clear();
            comboChoose.Items.Add("Choose");
            comboChoose.Items.Add("New Customer");
            comboChoose.Items.Add("Update Customer");
            comboChoose.Items.Add("Delete Customer");
            comboChoose.SelectedIndex = 1;

            // Check if the logged-in user is an Admin
            if (Login.CurrentUserRole == "Admin")
            {
                comboChoose.Items.Clear();
                comboChoose.Items.Add("Choose");
                comboChoose.Items.Add("New Customer");
                comboChoose.Items.Add("Update Customer");
                comboChoose.Items.Add("Delete Customer");
                comboChoose.SelectedIndex = 1;
                // Show Admin-specific features
                btnAdminRole.Visible = true;
                btnStaffRole.Visible = false;
                // Additional admin-specific UI elements can be displayed here
            }

            // Check if the logged-in user is an Staff
            if (Login.CurrentUserRole == "Staff")
            {
                comboChoose.Items.Clear();
                comboChoose.Items.Add("Choose");
                comboChoose.Items.Add("New Customer");

                comboChoose.SelectedIndex = 1;
                // Show Admin-specific features
                btnAdminRole.Visible = false;
                btnStaffRole.Visible = true;
                // Additional admin-specific UI elements can be displayed here

            }


            this.Load += Customers_Load;
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            RefreshCustomerGrid();



            btnCustomerMngmt.IconColor = System.Drawing.Color.FromArgb(110,102,255);
            btnCustomerMngmt.ForeColor = System.Drawing.Color.FromArgb(110, 102, 255);


            //----------------------------------------------------------

            // Start with 0 opacity
            this.Opacity = 0;

            Timer timer = new Timer();
            timer.Interval = 5; // Adjust interval for transition speed
            timer.Tick += (s, args) =>
            {
                this.Opacity += 0.01; // Gradually increase opacity

                if (this.Opacity >= 1)
                {
                    timer.Stop();
                    timer.Dispose();
                }
            };
            timer.Start();

            //---------------------------------------------------
        }






        //-------------------------------------------------------------------------------------------------------------------------------

        //Navigation Methods
        // Extra Mehods 
        public void dashboardBtn()
        {


            Dashboard dashboard = new Dashboard();


            this.Hide();
            dashboard.ShowDialog();
            //this.Show();

            btnDashboardMngmt.IconColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnDashboardMngmt.ForeColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnCustomerMngmt.IconColor = System.Drawing.Color.White;
            btnCustomerMngmt.ForeColor = System.Drawing.Color.White;
            btnLogoutMngmt.IconColor = System.Drawing.Color.White;
            btnLogoutMngmt.ForeColor = System.Drawing.Color.White;
            btnCargoMngmt.IconColor = System.Drawing.Color.White;
            btnCargoMngmt.ForeColor = System.Drawing.Color.White;
            btnReportMngmt.IconColor = System.Drawing.Color.White;
            btnReportMngmt.ForeColor = System.Drawing.Color.White;
            btnSalesMngmt.IconColor = System.Drawing.Color.White;
            btnSalesMngmt.ForeColor = System.Drawing.Color.White;
            btnSearchMngmt.IconColor = System.Drawing.Color.White;
            btnSearchMngmt.ForeColor = System.Drawing.Color.White;
            btnSettingsMngmt.IconColor = System.Drawing.Color.White;
            btnSettingsMngmt.ForeColor = System.Drawing.Color.White;
        }

        public void customerBtn()
        {


            Customers customer = new Customers();


            this.Hide();
            customer.ShowDialog();
            //this.Show();

            btnDashboardMngmt.IconColor = System.Drawing.Color.White;
            btnDashboardMngmt.ForeColor = System.Drawing.Color.White;
            btnCustomerMngmt.IconColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnCustomerMngmt.ForeColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnLogoutMngmt.IconColor = System.Drawing.Color.White;
            btnLogoutMngmt.ForeColor = System.Drawing.Color.White;
            btnCargoMngmt.IconColor = System.Drawing.Color.White;
            btnCargoMngmt.ForeColor = System.Drawing.Color.White;
            btnReportMngmt.IconColor = System.Drawing.Color.White;
            btnReportMngmt.ForeColor = System.Drawing.Color.White;
            btnSalesMngmt.IconColor = System.Drawing.Color.White;
            btnSalesMngmt.ForeColor = System.Drawing.Color.White;
            btnSearchMngmt.IconColor = System.Drawing.Color.White;
            btnSearchMngmt.ForeColor = System.Drawing.Color.White;
            btnSettingsMngmt.IconColor = System.Drawing.Color.White;
            btnSettingsMngmt.ForeColor = System.Drawing.Color.White;
        }

        public void cargoBtn()
        {


            Cargo cargo = new Cargo();

            this.Hide();
            cargo.ShowDialog();
            //this.Show();





            btnDashboardMngmt.IconColor = System.Drawing.Color.White;
            btnDashboardMngmt.ForeColor = System.Drawing.Color.White;
            btnCustomerMngmt.IconColor = System.Drawing.Color.White;
            btnCustomerMngmt.ForeColor = System.Drawing.Color.White;
            btnLogoutMngmt.IconColor = System.Drawing.Color.White;
            btnLogoutMngmt.ForeColor = System.Drawing.Color.White;
            btnCargoMngmt.IconColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnCargoMngmt.ForeColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnReportMngmt.IconColor = System.Drawing.Color.White;
            btnReportMngmt.ForeColor = System.Drawing.Color.White;
            btnSalesMngmt.IconColor = System.Drawing.Color.White;
            btnSalesMngmt.ForeColor = System.Drawing.Color.White;
            btnSearchMngmt.IconColor = System.Drawing.Color.White;
            btnSearchMngmt.ForeColor = System.Drawing.Color.White;
            btnSettingsMngmt.IconColor = System.Drawing.Color.White;
            btnSettingsMngmt.ForeColor = System.Drawing.Color.White;
        }

        public void ShippingBtn()
        {


            Shipping ShippingMngmnt = new Shipping();

            this.Hide();
            ShippingMngmnt.ShowDialog();
            //this.Show();

            btnDashboardMngmt.IconColor = System.Drawing.Color.White;
            btnDashboardMngmt.ForeColor = System.Drawing.Color.White;
            btnCustomerMngmt.IconColor = System.Drawing.Color.White;
            btnCustomerMngmt.ForeColor = System.Drawing.Color.White;
            btnLogoutMngmt.IconColor = System.Drawing.Color.White;
            btnLogoutMngmt.ForeColor = System.Drawing.Color.White;
            btnCargoMngmt.IconColor = System.Drawing.Color.White;
            btnCargoMngmt.ForeColor = System.Drawing.Color.White;
            btnReportMngmt.IconColor = System.Drawing.Color.White;
            btnReportMngmt.ForeColor = System.Drawing.Color.White;
            btnSalesMngmt.IconColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnSalesMngmt.ForeColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnSearchMngmt.IconColor = System.Drawing.Color.White;
            btnSearchMngmt.ForeColor = System.Drawing.Color.White;
            btnSettingsMngmt.IconColor = System.Drawing.Color.White;
            btnSettingsMngmt.ForeColor = System.Drawing.Color.White;


        }

        public void reportBtn()
        {
            lblTitle.Text = "Report";

            Report report = new Report();

            this.Hide();
            report.ShowDialog();
            //this.Show();

            btnDashboardMngmt.IconColor = System.Drawing.Color.White;
            btnDashboardMngmt.ForeColor = System.Drawing.Color.White;
            btnCustomerMngmt.IconColor = System.Drawing.Color.White;
            btnCustomerMngmt.ForeColor = System.Drawing.Color.White;
            btnLogoutMngmt.IconColor = System.Drawing.Color.White;
            btnLogoutMngmt.ForeColor = System.Drawing.Color.White;
            btnCargoMngmt.IconColor = System.Drawing.Color.White;
            btnCargoMngmt.ForeColor = System.Drawing.Color.White;
            btnReportMngmt.IconColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnReportMngmt.ForeColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnSalesMngmt.IconColor = System.Drawing.Color.White;
            btnSalesMngmt.ForeColor = System.Drawing.Color.White;
            btnSearchMngmt.IconColor = System.Drawing.Color.White;
            btnSearchMngmt.ForeColor = System.Drawing.Color.White;
            btnSettingsMngmt.IconColor = System.Drawing.Color.White;
            btnSettingsMngmt.ForeColor = System.Drawing.Color.White;

        }

        public void Aboutbtn()
        {
            lblTitle.Text = "Search";

            About about = new About();

            this.Hide();
            about.ShowDialog();
            //this.Show();


            btnDashboardMngmt.IconColor = System.Drawing.Color.White;
            btnDashboardMngmt.ForeColor = System.Drawing.Color.White;
            btnCustomerMngmt.IconColor = System.Drawing.Color.White;
            btnCustomerMngmt.ForeColor = System.Drawing.Color.White;
            btnLogoutMngmt.IconColor = System.Drawing.Color.White;
            btnLogoutMngmt.ForeColor = System.Drawing.Color.White;
            btnCargoMngmt.IconColor = System.Drawing.Color.White;
            btnCargoMngmt.ForeColor = System.Drawing.Color.White;
            btnReportMngmt.IconColor = System.Drawing.Color.White;
            btnReportMngmt.ForeColor = System.Drawing.Color.White;
            btnSalesMngmt.IconColor = System.Drawing.Color.White;
            btnSalesMngmt.ForeColor = System.Drawing.Color.White;
            btnSearchMngmt.IconColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnSearchMngmt.ForeColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnSettingsMngmt.IconColor = System.Drawing.Color.White;
            btnSettingsMngmt.ForeColor = System.Drawing.Color.White;

        }

        public void userManagerBtn()
        {
            UserManager usermanager = new UserManager();

            this.Hide();
            usermanager.Show();
            //this.Show();

            btnDashboardMngmt.IconColor = System.Drawing.Color.White;
            btnDashboardMngmt.ForeColor = System.Drawing.Color.White;
            btnCustomerMngmt.IconColor = System.Drawing.Color.White;
            btnCustomerMngmt.ForeColor = System.Drawing.Color.White;
            btnLogoutMngmt.IconColor = System.Drawing.Color.White;
            btnLogoutMngmt.ForeColor = System.Drawing.Color.White;
            btnCargoMngmt.IconColor = System.Drawing.Color.White;
            btnCargoMngmt.ForeColor = System.Drawing.Color.White;
            btnReportMngmt.IconColor = System.Drawing.Color.White;
            btnReportMngmt.ForeColor = System.Drawing.Color.White;
            btnSalesMngmt.IconColor = System.Drawing.Color.White;
            btnSalesMngmt.ForeColor = System.Drawing.Color.White;
            btnSearchMngmt.IconColor = System.Drawing.Color.White;
            btnSearchMngmt.ForeColor = System.Drawing.Color.White;
            btnSettingsMngmt.IconColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnSettingsMngmt.ForeColor = System.Drawing.Color.FromArgb(110, 102, 255);
        }

        public void logOutBtn()
        {




            btnDashboardMngmt.IconColor = System.Drawing.Color.White;
            btnDashboardMngmt.ForeColor = System.Drawing.Color.White;
            btnCustomerMngmt.IconColor = System.Drawing.Color.White;
            btnCustomerMngmt.ForeColor = System.Drawing.Color.White;
            btnLogoutMngmt.IconColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnLogoutMngmt.ForeColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnCargoMngmt.IconColor = System.Drawing.Color.White;
            btnCargoMngmt.ForeColor = System.Drawing.Color.White;
            btnReportMngmt.IconColor = System.Drawing.Color.White;
            btnReportMngmt.ForeColor = System.Drawing.Color.White;
            btnSalesMngmt.IconColor = System.Drawing.Color.White;
            btnSalesMngmt.ForeColor = System.Drawing.Color.White;
            btnSearchMngmt.IconColor = System.Drawing.Color.White;
            btnSearchMngmt.ForeColor = System.Drawing.Color.White;
            btnSettingsMngmt.IconColor = System.Drawing.Color.White;
            btnSettingsMngmt.ForeColor = System.Drawing.Color.White;


            MessageBox.Show("You Are Logged Out!!");
            Login.CurrentUserRole = string.Empty;
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }



        //--------------------------------------------------------------------------------------------------------




        // Crud Opeartion Methods 


        // Add New Customer
        private void AddCustomer(string name, string contactPhone, string contactEmail = null, DateTime? dateOfBirth = null, string address = null)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Customer name cannot be empty.");
            if (string.IsNullOrWhiteSpace(contactPhone))
                throw new ArgumentException("Contact phone cannot be empty.");

            // Validate phone number (must contain only digits)
            if (!contactPhone.All(char.IsDigit))
                throw new ArgumentException("Contact phone must contain only numbers.");

            // Validate email format (if provided)
            if (!string.IsNullOrWhiteSpace(contactEmail) && !contactEmail.Contains("@"))
                throw new ArgumentException("Invalid email format.");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO Customers (CustomerName, ContactPhone, ContactEmail, DateOfBirth, Address) 
            VALUES (@Name, @ContactPhone, @ContactEmail, @DateOfBirth, @Address)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@ContactPhone", contactPhone);
                command.Parameters.AddWithValue("@ContactEmail", contactEmail ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Address", address ?? (object)DBNull.Value);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle the exception (e.g., log it, rethrow it, etc.)
                    Console.WriteLine("An error occurred: " + ex.Message);
                    throw; // Re-throw the exception to propagate it
                }
                finally
                {
                    connection.Close();
                }
            }
        }



        //Get Customer
        private DataTable GetCustomers()
        {
            DataTable customersTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(customersTable);
            }

            return customersTable;
        }



        // Update Customer Info
        private void UpdateCustomer(int customerID, string name, string contactPhone, string contactEmail, DateTime? dateOfBirth = null, string address = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Customers " +
                               "SET CustomerName = @CustomerName, " +
                               "ContactPhone = @ContactPhone, " +
                               "ContactEmail = @ContactEmail, " +
                               "DateOfBirth = @DateOfBirth, " +
                               "Address = @Address " +
                               "WHERE CustomerID = @CustomerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerID);
                command.Parameters.AddWithValue("@CustomerName", name);
                command.Parameters.AddWithValue("@ContactPhone", contactPhone);
                command.Parameters.AddWithValue("@ContactEmail", contactEmail ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Address", address ?? (object)DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }




        // Delete Customer
        private void DeleteCustomer(int customerID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerID);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }



        //REfresh Customer GridView
        private void RefreshCustomerGrid()
        {
            customersDataGridView.DataSource = GetCustomers();
        }





        //Clear Boxes
        private void clearData()
        {
            txtName.Text = "";
            //txtId.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            comboChoose.Focus();
            //comboChoose.SelectedIndex = 0;

        }

        //Get Customer By ID
        private void GetCustomerByID(int customerID)
        {
            clearData(); // Clear existing data in the form

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Set text boxes
                    txtName.Text = reader["CustomerName"].ToString();
                    txtPhone.Text = reader["ContactPhone"]?.ToString(); // Handle NULL for ContactPhone
                    txtEmail.Text = reader["ContactEmail"]?.ToString(); // Handle NULL for ContactEmail
                    txtAddress.Text = reader["Address"]?.ToString(); // Handle NULL for Address

                    // Handle DateOfBirth (DateTimePicker)
                    if (reader["DateOfBirth"] != DBNull.Value)
                    {
                        DateTime dateOfBirth = (DateTime)reader["DateOfBirth"];
                        txtDob.Value = dateOfBirth; // Set DateTimePicker value
                    }
                    else
                    {
                        txtDob.Value = DateTime.Today; // Set to a default value (e.g., today's date) if NULL
                    }
                }
                else
                {
                    MessageBox.Show("Customer not found. Please check the ID.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

                connection.Close();
            }
        }





        //----------------------------------------------------------------------------------------------------------------------

        private void btnSettingsMngmt_Click(object sender, EventArgs e)
        {
            userManagerBtn();
        }

        private void btnLogoutMngmt_Click(object sender, EventArgs e)
        {
            logOutBtn();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            try
            {
                //txtPhone.PasswordChar = '*';
                AddCustomer(txtName.Text, txtPhone.Text, txtEmail.Text, txtDob.Value, txtAddress.Text);
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshCustomerGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clearData();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            clearData();

            if (!int.TryParse(txtId.Text, out int customerID))
            {
                MessageBox.Show("Please enter a valid Customer ID.",
                                "Input Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // Step 1: Fetch details if textboxes are empty
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                GetCustomerByID(customerID); // Fetch and display medicine details
                //MessageBox.Show("Medicine details retrieved. You can now edit them.",
                //                "Info",
                //                MessageBoxButtons.OK,
                //                MessageBoxIcon.Information);
                return;
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate all input fields (Customer ID, Name, Phone, Email, Date of Birth, and Address)
            if (!int.TryParse(txtId.Text, out int customerID) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                txtDob.Value == DateTime.MinValue || // Ensure a valid Date of Birth is selected
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please ensure all fields are entered correctly.\n" +
                                "Customer ID, Name, Phone, Email, Date of Birth, and Address are required.",
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Regular expression for phone number validation (optional '+' and digits)
            string phonePattern = @"^\+?[0-9]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, phonePattern))
            {
                MessageBox.Show("Invalid phone number. Only numbers and an optional '+' sign at the beginning are allowed.",
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If validation passes, call the UpdateCustomer method
            try
            {
                // Pass all fields, including DateTime from DateTimePicker
                UpdateCustomer(
                    customerID,
                    txtName.Text,
                    txtPhone.Text,
                    txtEmail.Text,
                    txtDob.Value,  // DateTimePicker value
                    txtAddress.Text);

                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshCustomerGrid();  // Assuming you have a method to refresh the grid
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Clear data fields after update
            clearData();
        }

        private void comboChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the logged-in user is an Admin
            if (Login.CurrentUserRole == "Admin")
            {

                // Additional admin-specific UI elements can be displayed here
                if (comboChoose.SelectedIndex == 0)
                {
                    comboChoose.Items.Clear();
                    comboChoose.Items.Add("Choose");
                    comboChoose.Items.Add("New Customer");
                    comboChoose.Items.Add("Update Customer");
                    comboChoose.Items.Add("Delete Customer");
                    comboChoose.SelectedIndex = 1;
                    clearData();
                    txtId.Visible = false;
                    lblId.Visible = false;
                    btnRetrieve.Visible = false;
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    txtName.Focus();

                }
                if (comboChoose.SelectedIndex == 1)
                {

                    clearData();
                    txtId.Visible = false;
                    lblId.Visible = false;
                    btnRetrieve.Visible = false;
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    txtName.Focus();

                }


                if (comboChoose.SelectedIndex == 2)
                {
                    clearData();
                    txtId.Visible = true;
                    lblId.Visible = true;
                    btnRetrieve.Visible = true;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = false;

                    txtId.Focus();


                }
                if (comboChoose.SelectedIndex == 3)
                {
                    clearData();
                    txtId.Visible = true;
                    lblId.Visible = true;
                    btnRetrieve.Visible = true;
                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = true;
                    //------------------
                    txtName.ReadOnly = true;
                    txtPhone.ReadOnly = true;
                    txtAddress.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtDob.Enabled = false;


                    txtId.Focus();



                }
            }

            // Check if the logged-in user is an Staff
            if (Login.CurrentUserRole == "Staff")
            {

                // Additional admin-specific UI elements can be displayed here
                if (comboChoose.SelectedIndex == 0)
                {
                    comboChoose.Items.Clear();
                    comboChoose.Items.Add("Choose");
                    comboChoose.Items.Add("New Customer");

                    comboChoose.SelectedIndex = 1;
                    clearData();
                    txtId.Visible = false;
                    lblId.Visible = false;
                    btnRetrieve.Visible = false;
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    txtName.Focus();
                    

                }
                


            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(txtId.Text, out int customerID))
            {
                MessageBox.Show("Please enter a valid Customer ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?",
                                                  "Confirm Delete",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeleteCustomer(customerID);
                    MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshCustomerGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            clearData();
        }

        private void btnDashboardMngmt_Click(object sender, EventArgs e)
        {
            dashboardBtn();
        }

        private void btnCargoMngmt_Click(object sender, EventArgs e)
        {
            cargoBtn();
        }

        private void btnCustomerMngmt_Click(object sender, EventArgs e)
        {
            customerBtn();
        }

        private void btnSalesMngmt_Click(object sender, EventArgs e)
        {
            ShippingBtn();
        }

        private void btnReportMngmt_Click(object sender, EventArgs e)
        {
            reportBtn();
        }

        private void btnSearchMngmt_Click(object sender, EventArgs e)
        {
            Aboutbtn();
        }
    }
    }

