using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shipping_Management_System
{
    public partial class Shipping : Form
    {

        //BlackFields of the class
        string connectionString = "Data Source=DESKTOP-LK1SELP;Database=Shipping;Integrated Security=true;";

        public Shipping()
        {
            InitializeComponent();




            // Check if the logged-in user is an Admin
            if (Login.CurrentUserRole == "Admin")
            {
                //Choose Combo
                comboChoose.Items.Clear();
                comboChoose.Items.Add("Choose Down");
                comboChoose.Items.Add("Add Shipping Order");
                comboChoose.Items.Add("Update Shipping Order");
                comboChoose.Items.Add("Delete Shipping Order");
                comboChoose.SelectedIndex = 1;

               
                // Show Admin-specific features
                btnAdminRole.Visible = true;
                btnStaffRole.Visible = false;
                // Additional admin-specific UI elements can be displayed here
            }

            // Check if the logged-in user is an Staff
            if (Login.CurrentUserRole == "Staff")
            {

                //Choose Combo
                comboChoose.Items.Clear();
                comboChoose.Items.Add("Choose Down");
                comboChoose.Items.Add("Add Shipping Order");

                comboChoose.SelectedIndex = 1;
                ClearData();


                // Show Admin-specific features
                btnAdminRole.Visible = false;
                btnStaffRole.Visible = true;
                // Additional admin-specific UI elements can be displayed here

            }


            this.Load += Shipping_Load;
        }

        private void Shipping_Load(object sender, EventArgs e)
        {
            btnSalesMngmt.IconColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnSalesMngmt.ForeColor = System.Drawing.Color.FromArgb(110, 102, 255);


            RefreshShippingGrid();


        }








        //---------------------------------------------------------------------------------------------------------------------------------------------
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





        //AddingShipping Order
        private void AddShippingOrder(string customerIDText, string shipIDText, string departurePortIDText, string arrivalPortIDText, string status, string deliveryDurationText)
        {
            // Validate that the IDs are integers and not empty or whitespace
            if (!int.TryParse(customerIDText, out int customerID) || customerID <= 0)
            {
                MessageBox.Show("Please provide a valid Customer ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(shipIDText, out int shipID) || shipID <= 0)
            {
                MessageBox.Show("Please provide a valid Ship ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(departurePortIDText, out int departurePortID) || departurePortID <= 0)
            {
                MessageBox.Show("Please provide a valid Departure Port ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(arrivalPortIDText, out int arrivalPortID) || arrivalPortID <= 0)
            {
                MessageBox.Show("Please provide a valid Arrival Port ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check that the status is not empty or whitespace
            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Status cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate the delivery duration is a valid integer and positive
            if (!int.TryParse(deliveryDurationText, out int deliveryDuration) || deliveryDuration <= 0)
            {
                MessageBox.Show("Please provide a valid Delivery Duration.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ShippingOrders (CustomerID, ShipID, DeparturePortID, ArrivalPortID, Status, DeliveryDuration) " +
                               "VALUES (@CustomerID, @ShipID, @DeparturePortID, @ArrivalPortID, @Status, @DeliveryDuration)";

                SqlCommand command = new SqlCommand(query, connection);

                // Set parameters
                command.Parameters.AddWithValue("@CustomerID", customerID);
                command.Parameters.AddWithValue("@ShipID", shipID);
                command.Parameters.AddWithValue("@DeparturePortID", departurePortID);
                command.Parameters.AddWithValue("@ArrivalPortID", arrivalPortID);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@DeliveryDuration", deliveryDuration);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Shipping order added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }



        //Update
        private void UpdateShippingOrder(string orderIDText, string customerIDText, string shipIDText, string departurePortIDText, string arrivalPortIDText, string status, string deliveryDurationText)
        {
            // Validate that the Order ID and other IDs are integers and not empty or whitespace
            if (!int.TryParse(orderIDText, out int orderID) || orderID <= 0)
            {
                MessageBox.Show("Please provide a valid Order ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(customerIDText, out int customerID) || customerID <= 0)
            {
                MessageBox.Show("Please provide a valid Customer ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(shipIDText, out int shipID) || shipID <= 0)
            {
                MessageBox.Show("Please provide a valid Ship ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(departurePortIDText, out int departurePortID) || departurePortID <= 0)
            {
                MessageBox.Show("Please provide a valid Departure Port ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(arrivalPortIDText, out int arrivalPortID) || arrivalPortID <= 0)
            {
                MessageBox.Show("Please provide a valid Arrival Port ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check that the status is not empty or whitespace
            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Status cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate the delivery duration is a valid integer and positive
            if (!int.TryParse(deliveryDurationText, out int deliveryDuration) || deliveryDuration <= 0)
            {
                MessageBox.Show("Please provide a valid Delivery Duration.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ShippingOrders " +
                               "SET CustomerID = @CustomerID, " +
                               "ShipID = @ShipID, " +
                               "DeparturePortID = @DeparturePortID, " +
                               "ArrivalPortID = @ArrivalPortID, " +
                               "Status = @Status, " +
                               "DeliveryDuration = @DeliveryDuration " +
                               "WHERE OrderID = @OrderID";

                SqlCommand command = new SqlCommand(query, connection);

                // Set parameters
                command.Parameters.AddWithValue("@OrderID", orderID);
                command.Parameters.AddWithValue("@CustomerID", customerID);
                command.Parameters.AddWithValue("@ShipID", shipID);
                command.Parameters.AddWithValue("@DeparturePortID", departurePortID);
                command.Parameters.AddWithValue("@ArrivalPortID", arrivalPortID);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@DeliveryDuration", deliveryDuration);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Shipping order updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        //Delete 
        private void DeleteShippingOrder(string orderIDText)
        {
            // Validate input for Order ID
            if (!int.TryParse(orderIDText, out int orderID) || orderID <= 0)
            {
                MessageBox.Show("Please provide a valid Order ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ShippingOrders WHERE OrderID = @OrderID";

                SqlCommand command = new SqlCommand(query, connection);

                // Set parameters
                command.Parameters.AddWithValue("@OrderID", orderID);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Shipping order deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Shipping order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        // getby Id
        private void GetShippingOrderByID(string orderIDText)
        {
            // Validate input for Order ID
            if (!int.TryParse(orderIDText, out int orderID) || orderID <= 0)
            {
                MessageBox.Show("Please provide a valid Order ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ShippingOrders WHERE OrderID = @OrderID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Populate form fields with the retrieved data
                        txtOrderId.Text = reader["OrderID"].ToString();
                        txtCustomerID.Text = reader["CustomerID"].ToString();
                        txtShipId.Text = reader["ShipID"].ToString();
                        txtDeparturePortId.Text = reader["DeparturePortID"].ToString();
                        txtArrivalPortId.Text = reader["ArrivalPortID"].ToString();
                        comboShipStatus.SelectedItem = reader["Status"].ToString();
                        txtDeliveryDuration.Text = reader["DeliveryDuration"].ToString();

                        // Convert OrderDate from database (which is DateTime) to DateTime and set it in DtOrderDate
                        // Handle DateOfBirth (DateTimePicker)
                        if (reader["OrderDate"] != DBNull.Value)
                        {
                            DateTime dateOfBirth = (DateTime)reader["OrderDate"];
                            DtOrderDate.Value = dateOfBirth; // Set DateTimePicker value
                        }
                        else
                        {
                            DtOrderDate.Value = DateTime.Today; // Set to a default value (e.g., today's date) if NULL
                        }
                    }
                    else
                    {
                        MessageBox.Show("Shipping order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }



        private DataTable GetShipping()
        {
            DataTable customersTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                                        o.OrderID, 
                                        o.CustomerID, 
                                        c.CustomerName, 
                                        o.ShipID, 
                                        s.ShipName, 
                                        o.DeparturePortID, 
                                        dp.PortName AS DeparturePortName, 
                                        o.ArrivalPortID, 
                                        ap.PortName AS ArrivalPortName, 
                                        o.Status, 
                                        o.DeliveryDuration
                                    FROM 
                                        ShippingOrders o
                                    JOIN 
                                        Customers c ON o.CustomerID = c.CustomerID
                                    JOIN 
                                        Ships s ON o.ShipID = s.ShipID
                                    JOIN 
                                        Ports dp ON o.DeparturePortID = dp.PortID
                                    JOIN 
                                        Ports ap ON o.ArrivalPortID = ap.PortID;
";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(customersTable);
            }

            return customersTable;
        }

        //REfresh Customer GridView
        private void RefreshShippingGrid()
        {
            DataGridView1.DataSource = GetShipping();
        }


        void ClearData()
        {
            txtOrderId.Text = string.Empty;
            txtShipId.Text = string.Empty;
            txtDeparturePortId.Text = string.Empty;
            txtCustomerID.Text = string.Empty;
            txtDeliveryDuration.Text = string.Empty;
            txtArrivalPortId.Text = string.Empty;
            //comboChoose.SelectedIndex   = 1;
            comboShipStatus.SelectedIndex = -1;
            DtOrderDate.Value = DateTime.Now;
        }





        //---------------------------------------------------------------------------------------------------------------------------------------------



        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCargoMngmt_Click(object sender, EventArgs e)
        {
            cargoBtn();
        }

        private void btnLogoutMngmt_Click(object sender, EventArgs e)
        {
           logOutBtn();
        }

        private void comboShipStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that a valid row is clicked (not the header)
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = DataGridView1.Rows[e.RowIndex];

                // Populate the textboxes with the selected row's values
                //txtCustomerID.Text = selectedRow.Cells["CustomerID"].Value.ToString();
                //txtShipId.Text = selectedRow.Cells["ShipID"].Value.ToString();
                //txtDeparturePortId.Text = selectedRow.Cells["DeparturePortID"].Value.ToString();
                //txtArrivalPortId.Text = selectedRow.Cells["ArrivalPortID"].Value.ToString();

                // Get the selected OrderID from the DataGridView row
                int orderID = (int)selectedRow.Cells["OrderID"].Value;

                // Call the GetShippingOrderByID method to fetch the details from the database
                GetShippingOrderByID(orderID.ToString());

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // AddShippingOrder(string customerIDText, string shipIDText, string departurePortIDText, string arrivalPortIDText, string status, string deliveryDurationText

            AddShippingOrder(txtCustomerID.Text, txtShipId.Text, txtDeparturePortId.Text, txtArrivalPortId.Text, comboShipStatus.Text, txtDeliveryDuration.Text);
            RefreshShippingGrid();
            ClearData();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //private void UpdateShippingOrder(string orderIDText, string customerIDText, string shipIDText, string departurePortIDText, string arrivalPortIDText, string status, string deliveryDurationText)

            UpdateShippingOrder(txtOrderId.Text, txtCustomerID.Text, txtShipId.Text, txtDeparturePortId.Text, txtArrivalPortId.Text, comboShipStatus.Text, txtDeliveryDuration.Text);
            RefreshShippingGrid();
            ClearData();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteShippingOrder(txtOrderId.Text);
            RefreshShippingGrid();
            ClearData();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            
            GetShippingOrderByID(txtOrderId.Text);
            
        }

        private void comboChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the logged-in user is an Admin
            if (Login.CurrentUserRole == "Admin")

            {




                if (comboChoose.SelectedIndex == 0)
                {


                    //Choose Combo
                    comboChoose.Items.Clear();
                    comboChoose.Items.Add("Choose Down");
                    comboChoose.Items.Add("Add Shipping Order");
                    comboChoose.Items.Add("Update Shipping Order");
                    comboChoose.Items.Add("Delete Shipping Order");
                    comboChoose.SelectedIndex = 1;
                    ClearData();





                    // Additional admin-specific UI elements can be displayed here
                }
                if (comboChoose.SelectedIndex == 1)
                {
                    ClearData();


                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    txtOrderId.Visible = false;
                    btnLoad.Enabled = false;
                    txtCustomerID.Focus();


                    txtCustomerID.Enabled = true;
                    txtArrivalPortId.Enabled = true;
                    txtDeliveryDuration.Enabled = true;
                    txtShipId.Enabled = true;
                    txtDeliveryDuration.Enabled = true;
                    comboShipStatus.Enabled = true;
                    DtOrderDate.Enabled = false;

                }
                if (comboChoose.SelectedIndex == 2)
                {
                    ClearData();

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = false;
                    txtOrderId.Visible = true;
                    btnLoad.Enabled = true;
                    txtOrderId.Focus();
                    DtOrderDate.Enabled = false;



                    txtCustomerID.Enabled = true;
                    txtArrivalPortId.Enabled = true;
                    txtDeliveryDuration.Enabled = true;
                    txtShipId.Enabled = true;
                    txtDeliveryDuration.Enabled = true;
                    comboShipStatus.Enabled = true;
                    DtOrderDate.Enabled = true;

                }
                if (comboChoose.SelectedIndex == 3)
                {
                    ClearData();
                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = true;
                    txtOrderId.Visible = true;
                    btnLoad.Enabled = true;
                    txtOrderId.Focus();

                    txtCustomerID.Enabled = false;
                    txtArrivalPortId.Enabled = false;
                    txtDeliveryDuration.Enabled = false;
                    txtShipId.Enabled = false;
                    txtDeliveryDuration.Enabled = false;
                    comboShipStatus.Enabled = false;
                    DtOrderDate.Enabled = false;

                }




            }



            // Check if the logged-in user is an Staff
            if (Login.CurrentUserRole == "Staff")
            {


                if (comboChoose.SelectedIndex == 0)
                {


                    //Choose Combo
                    comboChoose.Items.Clear();
                    comboChoose.Items.Add("Choose Down");
                    comboChoose.Items.Add("Add Shipping Order");
                   
                    comboChoose.SelectedIndex = 1;
                    ClearData();





                    // Additional staff-specific UI elements can be displayed here
                }
                if (comboChoose.SelectedIndex == 1)
                {
                    ClearData();


                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    txtOrderId.Visible = false;
                    btnLoad.Enabled = false;
                    txtCustomerID.Focus();


                    txtCustomerID.Enabled = true;
                    txtArrivalPortId.Enabled = true;
                    txtDeliveryDuration.Enabled = true;
                    txtShipId.Enabled = true;
                    txtDeliveryDuration.Enabled = true;
                    comboShipStatus.Enabled = true;
                    DtOrderDate.Enabled = true;

                }



                // Additional admin-specific UI elements can be displayed here

            }
        }

        private void btnDashboardMngmt_Click(object sender, EventArgs e)
        {
            dashboardBtn();
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

        private void btnSettingsMngmt_Click(object sender, EventArgs e)
        {
            userManagerBtn();
        }
    }
}
