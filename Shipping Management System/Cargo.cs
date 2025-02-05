using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic.Devices;

namespace Shipping_Management_System
{
    public partial class Cargo : Form
    {

        //BlackFields of the class
        string connectionString = "Data Source=DESKTOP-LK1SELP;Database=Shipping;Integrated Security=true;";
        public Cargo()
        {
            InitializeComponent();

            //Choose Combo
            comboChoose.Items.Clear();
            comboChoose.Items.Add("Choose Down");
            comboChoose.Items.Add("Container");
            comboChoose.Items.Add("Ports");
            comboChoose.Items.Add("Ships");
            comboChoose.SelectedIndex = 1;


            // Check if the logged-in user is an Admin
            if (Login.CurrentUserRole == "Admin")
            {
                //Choose Combo
                comboChoose.Items.Clear();
                comboChoose.Items.Add("Choose Down");
                comboChoose.Items.Add("Container");
                comboChoose.Items.Add("Ports");
                comboChoose.Items.Add("Ships");
                comboChoose.SelectedIndex = 1;

                //ComboContainerChoose
                comboContainerChoose.Items.Clear();
                comboContainerChoose.Items.Add("Choose Down");
                comboContainerChoose.Items.Add("Add Container");
                comboContainerChoose.Items.Add("Update Container");
                comboContainerChoose.Items.Add("Delete Container");
                comboContainerChoose.SelectedIndex = 1;


                //ComboContainerStatus
                comboContainerStatus.Items.Clear();
                comboContainerStatus.Items.Add("Loaded");
                comboContainerStatus.Items.Add("In Transit");
                comboContainerStatus.Items.Add("Unloaded");
                comboContainerStatus.SelectedIndex  = 1;


                // Ports Combos

                //ComboPortChoose
                comboPortChoose.Items.Clear();
                comboPortChoose.Items.Add("Choose Down");
                comboPortChoose.Items.Add("Add Port");
                comboPortChoose.Items.Add("Update Port");
                comboPortChoose.Items.Add("Delete Port");
                comboPortChoose.SelectedIndex = 1;


                // Ships COmbos

                // Combo Ship Choose
                comboShipChoose.Items.Clear();
                comboShipChoose.Items.Add("Choose Down");
                comboShipChoose.Items.Add("Add Ship");
                comboShipChoose.Items.Add("Update Ship");
                comboShipChoose.Items.Add("Delete Ship");
                comboShipChoose.SelectedIndex = 1;

                // Show Admin-specific features
                btnAdminRole.Visible = true;
                btnStaffRole.Visible = false;
                // Additional admin-specific UI elements can be displayed here
            }

            // Check if the logged-in user is an Staff
            if (Login.CurrentUserRole == "Staff")
            {
                comboChoose.Items.Clear();
                comboChoose.Items.Add("Choose Down");
                comboChoose.Items.Add("Container");
                comboChoose.Items.Add("Ports");
                comboChoose.Items.Add("Ships");
                comboChoose.SelectedIndex = 1;

                //ComboContainerChoose
                comboContainerChoose.Items.Clear();
                comboContainerChoose.Items.Add("Choose Down");
                comboContainerChoose.Items.Add("Add Container");
                comboContainerChoose.SelectedIndex = 1;

                //ComboContainerStatus
                comboContainerStatus.Items.Clear();
                comboContainerStatus.Items.Add("Loaded");
                comboContainerStatus.Items.Add("In Transit");
                comboContainerStatus.Items.Add("Unloaded");



                // Ports Combos

                //ComboPortChoose
                comboPortChoose.Items.Clear();
                comboPortChoose.Items.Add("Choose Down");
                comboPortChoose.Items.Add("Add Port");


                // Ships COmbos

                // Combo Ship Choose
                comboShipChoose.Items.Clear();
                comboShipChoose.Items.Add("Choose Down");
                comboShipChoose.Items.Add("Add Ship");


                // Show Admin-specific features
                btnAdminRole.Visible = false;
                btnStaffRole.Visible = true;
                // Additional admin-specific UI elements can be displayed here

            }


            this.Load += Cargo_Load;

        }

        private void Cargo_Load(object sender, EventArgs e)
        {

            RefreshContainerGrid();


            comboPortChoose.SelectedIndex = 1;
            comboShipChoose.SelectedIndex = 1;
            comboContainerChoose.SelectedIndex = 1;

            btnCargoMngmt.IconColor = System.Drawing.Color.FromArgb(110,102,255);
            btnCargoMngmt.ForeColor = System.Drawing.Color.FromArgb(110, 102, 255);


            //PopulateShipNames();
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

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }




        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------

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


            System.Windows.MessageBox.Show("You Are Logged Out!!");
            Login.CurrentUserRole = string.Empty;
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }



        // Popluate Ship Names  in Combo Box
        //private void PopulateShipNames()
        //{


        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            con.Open();
        //            string query = "SELECT ShipName FROM Ships order by ShipName asc";
        //            SqlCommand cmd = new SqlCommand(query, con);


        //            SqlDataReader reader = cmd.ExecuteReader();
        //            comboContainerShip.Items.Clear();
        //            while (reader.Read())
        //            {
        //                comboContainerShip.Items.Add(reader["ShipName"].ToString());
        //            }
        //            reader.Close();
        //        }
        //        catch (SqlException ex)
        //        {
        //            MessageBox.Show("Error: " + ex.Message);
        //        }
        //    }
        //}


        //Populate Port Names
        private void PopulatePortNames()
        {


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT PortName FROM Ports order by PortName asc";
                    SqlCommand cmd = new SqlCommand(query, con);


                    SqlDataReader reader = cmd.ExecuteReader();
                    comboContainerLastPort.Items.Clear();
                    while (reader.Read())
                    {
                        comboContainerLastPort.Items.Add(reader["PortName"].ToString());
                    }
                    reader.Close();
                }
                catch (SqlException ex)
                {
                 
                    System.Windows.MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        //Populate Status
        private void PopulateContainerStatus()
        {
            comboContainerStatus.Items.Clear();
            comboContainerStatus.Items.Add("Loaded");
            comboContainerStatus.Items.Add("In Transit");
            comboContainerStatus.Items.Add("Unloaded");
        }


        //private void PopulateContainerId()
        //{


        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            con.Open();
        //            string query = "SELECT ContainerID FROM Containers order by ContainerID asc";
        //            SqlCommand cmd = new SqlCommand(query, con);


        //            SqlDataReader reader = cmd.ExecuteReader();
        //            comboContainerId.Items.Clear();
        //            while (reader.Read())
        //            {
        //                comboContainerId.Items.Add(reader["ContainerID"].ToString());
        //            }
        //            reader.Close();
        //        }
        //        catch (SqlException ex)
        //        {
        //            MessageBox.Show("Error: " + ex.Message);
        //        }
        //    }
        //}



        //Get Container
        private DataTable GetContainers()
        {
            DataTable customersTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT c.ContainerNumericID, c.ContainerID, c.ShipID,sh.ShipName, c.Status,c.LastKnownPort, c.Description FROM Containers c, Ships sh Where c.ShipID = sh.ShipID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(customersTable);
            }

            return customersTable;
        }

        //REfresh Customer GridView
        private void RefreshContainerGrid()
        {
            DataGridView1.DataSource = GetContainers();
        }





        // Get Ship Id using Ship name
        private int GetShipIdUsingShipName(string shipName)
        {
            // Define the connection string
            string conString = "Data Source=DESKTOP-LK1SELP;Database=Shipping;Integrated Security=true;";

            // Declare a variable to store the ShipID
            int shipID = -1; // Default to -1 to indicate not found

            // SQL query to fetch the ShipID based on ShipName
            string query = "SELECT ShipID FROM Ships WHERE ShipName = @ShipName";

            // Establish a connection to the database
            using (SqlConnection conn = new SqlConnection(conString))
            {
                try
                {
                    // Open the connection
                    conn.Open();

                    // Create the SQL command
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add the parameter to the query
                        cmd.Parameters.AddWithValue("@ShipName", shipName);

                        // Execute the query and read the result
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check if any rows were returned
                            if (reader.Read())
                            {
                                // Retrieve the ShipID from the query result
                                shipID = Convert.ToInt32(reader["ShipID"]);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Windows.MessageBox.Show($"Database error: {ex.Message}", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
            }

            // Return the ShipID, or -1 if not found
            return shipID;
        }



        //Get Customer By ID
        private void GetContainerByID(int containerID)
        {
            //clearData(); // Clear existing data in the form
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Containers where ContainerNumericID = @ContainerNumericID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ContainerNumericID", containerID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Set combo boxes
                    txtShipId.Text = reader["ShipID"].ToString();
                    comboContainerStatus.Text = reader["Status"]?.ToString(); 
                    comboContainerLastPort.Text = reader["LastKnownPort"]?.ToString(); 
                    txtDescription.Text = reader["Description"]?.ToString();
                   

                   
                }
                else
                {
                    System.Windows.MessageBox.Show("Container not found. Please check the ID.",
                                    "Error",
                                    (MessageBoxButton)MessageBoxButtons.OK,
                                    (MessageBoxImage)MessageBoxIcon.Error);
                }

                connection.Close();
            }
        }


        // Delete Container
        private void DeleteContainer(int containerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Containers WHERE ContainerNumericID = @ContainerNumericID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ContainerNumericID", containerId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }



        // Update Container 
        private void UpdateContainer(int containerNumericID, int shipID, string status, string lastKnownPort, string description)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Containers " +
                               "SET ShipID = @ShipID, " +
                               "Status = @Status, " +
                               "LastKnownPort = @LastKnownPort, " +
                               "Description = @Description " +
                               "WHERE ContainerNumericID = @ContainerNumericID";

                SqlCommand command = new SqlCommand(query, connection);

                // Set parameters
                command.Parameters.AddWithValue("@ContainerNumericID", containerNumericID);
                command.Parameters.AddWithValue("@ShipID", shipID);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@LastKnownPort", lastKnownPort ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Description", description ?? (object)DBNull.Value);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    System.Windows.MessageBox.Show("Error: " + ex.Message, "Database Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }




        //Add Container
        private void AddContainer(int shipID, string status, string lastKnownPort, string description)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to insert a new container
                string query = "INSERT INTO Containers (ShipID, Status, LastKnownPort, Description) " +
                               "VALUES (@ShipID, @Status, @LastKnownPort, @Description)";

                SqlCommand command = new SqlCommand(query, connection);

                // Set parameters
                command.Parameters.AddWithValue("@ShipID", shipID);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@LastKnownPort", lastKnownPort ?? (object)DBNull.Value);  // Nullable
                command.Parameters.AddWithValue("@Description", description ?? (object)DBNull.Value);  // Nullable

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    System.Windows.MessageBox.Show("Container added successfully.", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    System.Windows.MessageBox.Show("Error: " + ex.Message, "Database Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        //---------------------- Ports ------------------

        //addport
        private void AddPort(string portName, string country)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(portName))
                throw new ArgumentException("Portname cannot be empty.");
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Contry Name cannot be empty.");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Ports (PortName, Country) VALUES (@PortName, @Country)";

                SqlCommand command = new SqlCommand(query, connection);

                // Set parameters
                command.Parameters.AddWithValue("@PortName", portName);
                command.Parameters.AddWithValue("@Country", country);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    System.Windows.MessageBox.Show("Port added successfully.", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    System.Windows.MessageBox.Show("Error: " + ex.Message, "Database Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }





        // Update Port
        private void UpdatePort(int portID, string portName, string country)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(portName))
                throw new ArgumentException("Portname cannot be empty.");
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Contry Name cannot be empty.");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Ports " +
                               "SET PortName = @PortName, " +
                               "Country = @Country " +
                               "WHERE PortID = @PortID";

                SqlCommand command = new SqlCommand(query, connection);

                // Set parameters
                command.Parameters.AddWithValue("@PortID", portID);
                command.Parameters.AddWithValue("@PortName", portName);
                command.Parameters.AddWithValue("@Country", country);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    System.Windows.MessageBox.Show("Port updated successfully.", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    System.Windows.MessageBox.Show("Error: " + ex.Message, "Database Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }



        // delete Port
        private void DeletePort(int portID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Ports WHERE PortID = @PortID";

                SqlCommand command = new SqlCommand(query, connection);

                // Set parameters
                command.Parameters.AddWithValue("@PortID", portID);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        System.Windows.MessageBox.Show("Port deleted successfully.", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Port not found.", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    System.Windows.MessageBox.Show("Error: " + ex.Message, "Database Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }




        private DataTable Getport()
        {
            DataTable customersTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Ports";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(customersTable);
            }

            return customersTable;
        }

        //REfresh Customer GridView
        private void RefreshPortGrid()
        {
            DataGridView1.DataSource = Getport();
        }






        // Get Port by Id
        private void GetPortByID(int portID)
        {
            // Clear any existing data in the form (optional)
            // ClearData(); // Uncomment if you have a method to clear existing data

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Ports WHERE PortID = @PortID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PortID", portID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Set text fields or combo boxes
                        txtPortName.Text = reader["PortName"].ToString();
                        txtPortCountry.Text = reader["Country"].ToString();
                    }
                    else
                    {
                        // Show an error message if the port ID is not found
                        System.Windows.MessageBox.Show("Port not found. Please check the ID.", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
                catch (SqlException ex)
                {
                    System.Windows.MessageBox.Show("Database error: " + ex.Message, "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }



        //------------------------- SHips -------------------------------------------------

        // Add Ship
        private void AddShip(string shipName, string currentLocation, string status)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(shipName))
                throw new ArgumentException("ShipName cannot be empty.");
            if (string.IsNullOrWhiteSpace(currentLocation))
                throw new ArgumentException("Current Location cannot be empty.");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Ships (ShipName, CurrentLocation, Status) " +
                               "VALUES (@ShipName, @CurrentLocation, @Status)";

                SqlCommand command = new SqlCommand(query, connection);

                // Set parameters
                command.Parameters.AddWithValue("@ShipName", shipName);
                command.Parameters.AddWithValue("@CurrentLocation", currentLocation ?? (object)DBNull.Value);  // Nullable
                command.Parameters.AddWithValue("@Status", status);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    System.Windows.MessageBox.Show("Ship added successfully.", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    System.Windows.MessageBox.Show("Error: " + ex.Message, "Database Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //Update Ship
        private void UpdateShip(int shipID, string shipName, string currentLocation, string status)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(shipName))
                throw new ArgumentException("ShipName cannot be empty.");
            if (string.IsNullOrWhiteSpace(currentLocation))
                throw new ArgumentException("Current Location cannot be empty.");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Ships " +
                               "SET ShipName = @ShipName, " +
                               "CurrentLocation = @CurrentLocation, " +
                               "Status = @Status " +
                               "WHERE ShipID = @ShipID";

                SqlCommand command = new SqlCommand(query, connection);

                // Set parameters
                command.Parameters.AddWithValue("@ShipID", shipID);
                command.Parameters.AddWithValue("@ShipName", shipName);
                command.Parameters.AddWithValue("@CurrentLocation", currentLocation ?? (object)DBNull.Value);  // Nullable
                command.Parameters.AddWithValue("@Status", status);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    System.Windows.MessageBox.Show("Ship updated successfully.", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    System.Windows.MessageBox.Show("Error: " + ex.Message, "Database Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        // Delete Ship 
        private void DeleteShip(int shipID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Ships WHERE ShipID = @ShipID";

                SqlCommand command = new SqlCommand(query, connection);

                // Set parameters
                command.Parameters.AddWithValue("@ShipID", shipID);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        System.Windows.MessageBox.Show("Ship deleted successfully.", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Ship not found.", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    System.Windows.MessageBox.Show("Error: " + "You Cannot Delete This Because Its Still in Use", "Database Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        //get Ship by Id
        private void GetShipByID(int shipID)
        {
            // Clear any existing data in the form (optional)
            // ClearData(); // Uncomment if you have a method to clear existing data

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Ships WHERE ShipID = @ShipID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ShipID", shipID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Set text fields or combo boxes
                        txtShipName.Text = reader["ShipName"].ToString();
                        txtShipLocation.Text = reader["CurrentLocation"].ToString();
                        comboShipStatus.Text = reader["Status"].ToString();
                    }
                    else
                    {
                        // Show an error message if the ship ID is not found
                        System.Windows.MessageBox.Show("Ship not found. Please check the ID.", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
                catch (SqlException ex)
                {
                    System.Windows.MessageBox.Show("Database error: " + ex.Message, "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }




        private DataTable GetShip()
        {
            DataTable customersTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * from Ships";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(customersTable);
            }

            return customersTable;
        }

        //REfresh Ship GridView
        private void RefreshShipGrid()
        {
            DataGridView1.DataSource = GetShip();
        }






        void ClearDataContainer() {
            comboContainerLastPort.Items.Clear();
            txtShipId.Clear();
            comboContainerStatus.Items.Clear();
            txtDescription.Clear();
            //txtContainerID.Focus();
        }

        void ClearDataPort() {
            txtPortName.Clear();
            txtPortCountry.Clear();   
        }

        void ClearDataShip() {
            txtShipName.Clear();
            txtShipLocation.Clear();
            comboShipStatus.SelectedIndex = -1;
        }






        //----------------------------------------------------------------------------------------------------------------------





        private void comboContainerChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the logged-in user is an Admin
            if (Login.CurrentUserRole == "Admin")

            {

              


                if (comboContainerChoose.SelectedIndex == 0)
                {
                   

                    //ComboContainerChoose
                    comboContainerChoose.Items.Clear();
                    comboContainerChoose.Items.Add("Choose Down");
                    comboContainerChoose.Items.Add("Add Container");
                    comboContainerChoose.Items.Add("Update Container");
                    comboContainerChoose.Items.Add("Delete Container");
                    comboContainerChoose.SelectedIndex = 1;


                    //ComboContainerStatus
                    comboContainerStatus.Items.Clear();
                    comboContainerStatus.Items.Add("Loaded");
                    comboContainerStatus.Items.Add("In Transit");
                    comboContainerStatus.Items.Add("Unloaded");



                    // Additional admin-specific UI elements can be displayed here
                }
                if (comboContainerChoose.SelectedIndex == 1) {
                    //PopulateShipNames();
                    PopulatePortNames();
                    btnRetrieveContainer.Visible = false;
                    txtShipId.Visible = true;
                    lblId.Visible = false;
                    txtContainerID.Visible = false;

                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;

                    txtShipId.ReadOnly = false;
                    txtDescription.ReadOnly = false;
                    comboContainerStatus.Enabled = true;
                    comboContainerLastPort.Enabled = true;


                    txtShipId.Enabled = true;
                    txtDescription.Enabled = true;

                }
                if (comboContainerChoose.SelectedIndex == 2)
                {
                   // PopulateShipNames();
                    PopulatePortNames();
                    //PopulateContainerId();
                    btnRetrieveContainer.Visible = true;
                    txtShipId.Visible = true;
                    lblId.Visible = true;

                    btnDelete.Visible = false;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    txtContainerID.Visible = true;

                    txtShipId.ReadOnly = false;
                    txtDescription.ReadOnly = false;
                    comboContainerStatus.Enabled = true;
                    comboContainerLastPort.Enabled = true;

                    txtShipId.Enabled = true;
                    txtDescription.Enabled = true;
                }
                if (comboContainerChoose.SelectedIndex == 3)
                {
                    //PopulateShipNames();
                   // PopulateContainerId();
                    btnRetrieveContainer.Visible = true;
                    txtShipId.Visible = true;
                    lblId.Visible = true;
                    comboContainerLastPort.Enabled = false;
                    txtShipId.Enabled = false;
                    comboContainerStatus.Enabled = false;


                    btnDelete.Visible = true;
                    btnUpdate.Visible = false;
                    btnSave.Visible = false;
                    txtContainerID.Visible = true;
                    txtShipId.ReadOnly = true;
                    txtDescription.ReadOnly = true;
                    comboContainerStatus.Enabled = false;
                    comboContainerLastPort.Enabled = false;
                    txtDescription.Enabled = false;
                }




            }

            

            // Check if the logged-in user is an Staff
            if (Login.CurrentUserRole == "Staff")
            {
                if (comboContainerChoose.SelectedIndex == 0) {
                    comboChoose.Items.Clear();
                    comboChoose.Items.Add("Choose Down");
                    comboChoose.Items.Add("Container");
                    comboChoose.Items.Add("Ports");
                    comboChoose.Items.Add("Ships");
                    comboChoose.SelectedIndex = 1;

                    //ComboContainerChoose
                    comboContainerChoose.Items.Clear();
                    comboContainerChoose.Items.Add("Choose Down");
                    comboContainerChoose.Items.Add("Add Container");
                    comboContainerChoose.SelectedIndex = 1;


                    //ComboContainerStatus
                    comboContainerStatus.Items.Clear();
                    comboContainerStatus.Items.Add("Loaded");
                    comboContainerStatus.Items.Add("In Transit");
                    comboContainerStatus.Items.Add("Unloaded");
                }


                // Additional admin-specific UI elements can be displayed here

            }

        }

        private void btnRetrieveContainer_Click(object sender, EventArgs e)
        {
            ClearDataContainer();
            PopulatePortNames();
            PopulateContainerStatus();
           


            if (!int.TryParse(txtContainerID.Text, out int containerId))
            {
                System.Windows.MessageBox.Show("Please enter a valid Container ID.",
                                "Input Error",
                                (MessageBoxButton)MessageBoxButtons.OK,
                                (MessageBoxImage)MessageBoxIcon.Error);
                return;
            }

            GetContainerByID(containerId);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtContainerID.Text, out int containerId))
            {
                System.Windows.MessageBox.Show("Please enter a valid Container ID.",
                                "Input Error",
                                (MessageBoxButton)MessageBoxButtons.OK,
                                (MessageBoxImage)MessageBoxIcon.Error);
                return;
            }


            DialogResult result = (DialogResult)System.Windows.MessageBox.Show("Are you sure you want to delete this customer?",
                                                  "Confirm Delete",
                                                  (MessageBoxButton)MessageBoxButtons.YesNo,
                                                  (MessageBoxImage)MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeleteContainer(containerId);
                    System.Windows.MessageBox.Show("Customer deleted successfully!", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                    RefreshContainerGrid();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
            }
            ClearDataContainer();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate all input fields 
            if (!int.TryParse(txtContainerID.Text, out int containerId) ||
                string.IsNullOrWhiteSpace(txtShipId.Text) ||
                !int.TryParse(txtShipId.Text, out int shipId))



            {
                System.Windows.MessageBox.Show("Please ensure all fields are entered correctly.\n" ,
                                "Input Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                return;
            }


            // If validation passes, call the UpdateContainer method
            try
            {
                
                UpdateContainer(
                    containerId,
                    shipId,
                    comboContainerStatus.Text,
                    comboContainerLastPort.Text,
                    txtDescription.Text);

                System.Windows.MessageBox.Show("Container updated successfully!", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                RefreshContainerGrid();  // Assuming you have a method to refresh the grid
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
            }

            // Clear data fields after update
            ClearDataContainer();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            // Validate all input fields 
            if (string.IsNullOrWhiteSpace(txtShipId.Text) ||
                !int.TryParse(txtShipId.Text, out int shipId))



            {
                System.Windows.MessageBox.Show("Please ensure all fields are entered correctly.\n",
                                "Input Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                return;
            }


            // If validation passes, call the UpdateContainer method
            try
            {

                AddContainer(
                    shipId,
                    comboContainerStatus.Text,
                    comboContainerLastPort.Text,
                    txtDescription.Text);

                RefreshContainerGrid();  // Assuming you have a method to refresh the grid
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
            }

            // Clear data fields after update
            ClearDataContainer();
        }

        private void comboChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboChoose.SelectedIndex == 0)
            {
                comboChoose.SelectedIndex = 1;
            }

            if (comboChoose.SelectedIndex == 1)
            {
                panelContainer.Visible = true;
                panelPort.Visible = false;
                panelShip.Visible = false;

               
                RefreshContainerGrid();
            }
            if (comboChoose.SelectedIndex == 2)
            {
                panelContainer.Visible = false;
                panelPort.Visible = true;
                panelShip.Visible = false;


                RefreshPortGrid();
            }
            if (comboChoose.SelectedIndex == 3)
            {
                panelContainer.Visible = false;
                panelPort.Visible = false;
                panelShip.Visible = true;
                panelShip.Visible = true;

                comboShipChoose.SelectedIndex = 1;


                RefreshShipGrid();
            }
        }

        private void comboPortChoose_SelectedIndexChanged(object sender, EventArgs e)
        {


           if(Login.CurrentUserRole == "Admin")
            {
                if (comboPortChoose.SelectedIndex == 0)
                {


                    //ComboPortChoose
                    comboPortChoose.Items.Clear();
                    comboPortChoose.Items.Add("Choose Down");
                    comboPortChoose.Items.Add("Add Port");
                    comboPortChoose.Items.Add("Update Port");
                    comboPortChoose.Items.Add("Delete Port");
                    comboPortChoose.SelectedIndex = 1;
                }

                if (comboPortChoose.SelectedIndex == 1)
                {
                    txtPortName.Enabled = true;
                    txtPortCountry.Enabled = true;
                    txtPortId.Visible = false;
                    lblPortId.Visible = false;
                    btnRetrievePort.Visible = false;
                    btnSavePort.Visible = true;
                    btnUpdatePort.Visible = false;
                    btnDeletePort.Visible = false;
                }
                if (comboPortChoose.SelectedIndex == 2)
                {
                    txtPortName.Enabled = true;
                    txtPortCountry.Enabled = true;
                    txtPortId.Visible = true;
                    lblPortId.Visible = true;
                    btnRetrievePort.Visible = true;
                    btnSavePort.Visible = false;
                    btnUpdatePort.Visible = true;
                    btnDeletePort.Visible = false;
                }
                if (comboPortChoose.SelectedIndex == 3)
                {

                    txtPortName.Enabled = false;
                    txtPortCountry.Enabled = false;
                    txtPortId.Visible = true;
                    lblPortId.Visible = true;
                    btnRetrievePort.Visible = true;
                    btnSavePort.Visible = false;
                    btnUpdatePort.Visible = false;
                    btnDeletePort.Visible = true;
                }

                if(Login.CurrentUserRole == "Staff")
                {
                    if (comboPortChoose.SelectedIndex == 0)
                    {


                        //ComboPortChoose
                        comboPortChoose.Items.Clear();
                        comboPortChoose.Items.Add("Choose Down");
                        comboPortChoose.Items.Add("Add Port");
                        
                        comboPortChoose.SelectedIndex = 1;
                    }

                    if (comboPortChoose.SelectedIndex == 1)
                    {
                        txtPortName.Enabled = true;
                        txtPortCountry.Enabled = true;
                        txtPortId.Visible = false;
                        lblPortId.Visible = false;
                        btnRetrievePort.Visible = false;
                        btnSavePort.Visible = true;
                        btnUpdatePort.Visible = false;
                        btnDeletePort.Visible = false;
                    }
                   
                }
            }

        }

        private void btnSavePort_Click(object sender, EventArgs e)
        {
            AddPort(txtPortName.Text, txtPortCountry.Text);
            RefreshPortGrid();
            ClearDataPort();
        }

        private void btnUpdatePort_Click(object sender, EventArgs e)
        {
           

            // Validate all input fields 
            if (!int.TryParse(txtPortId.Text, out int portId))

            {
                System.Windows.MessageBox.Show("Please ensure all fields are entered correctly.\n",
                                "Input Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                return;
            }


            // If validation passes, call the UpdateContainer method
            try
            {

                UpdatePort(portId, txtPortName.Text, txtPortCountry.Text);

                System.Windows.MessageBox.Show("Port updated successfully!", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                RefreshPortGrid();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
            }

            // Clear data fields after update
            ClearDataPort();
        }

        private void btnDeletePort_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPortId.Text, out int portId))
            {
                System.Windows.MessageBox.Show("Please enter a valid Port ID.",
                                "Input Error",
                                (MessageBoxButton)MessageBoxButtons.OK,
                                (MessageBoxImage)MessageBoxIcon.Error);
                return;
            }


            DialogResult result = (DialogResult)System.Windows.MessageBox.Show("Are you sure you want to delete this Port?",
                                                  "Confirm Delete",
                                                  (MessageBoxButton)MessageBoxButtons.YesNo,
                                                  (MessageBoxImage)MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeletePort(portId);

                    RefreshPortGrid();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
            }
            ClearDataPort() ;
        }

        private void btnRetrievePort_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPortId.Text, out int portId))
            {
                System.Windows.MessageBox.Show("Please enter a valid Port ID.",
                                "Input Error",
                                (MessageBoxButton)MessageBoxButtons.OK,
                                (MessageBoxImage)MessageBoxIcon.Error);
                return;
            }

            GetPortByID(portId);
        }

        private void comboShipChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Login.CurrentUserRole == "Admin")
            {
              comboShipStatus.Items.Clear();
                comboShipStatus.Items.Add("Docked");
                comboShipStatus.Items.Add("At Sea");
                comboShipStatus.Items.Add("Maintenance");

                if (comboShipChoose.SelectedIndex == 0)
                {
                    // Combo Ship Choose
                    comboShipChoose.Items.Clear();
                    comboShipChoose.Items.Add("Choose Down");
                    comboShipChoose.Items.Add("Add Ship");
                    comboShipChoose.Items.Add("Update Ship");
                    comboShipChoose.Items.Add("Delete Ship");
                    comboShipChoose.SelectedIndex = 1;
                }
                if (comboShipChoose.SelectedIndex == 1) { 
                    btnRetreiveShip.Visible = false;
                    lblShipId.Visible = false;
                    txtShip1Id.Visible = false;

                    btnUpdateShip.Visible = false;
                    btnDeleteShip.Visible = false;
                    btnSaveShip.Visible = true;

                    txtShipName.Enabled = true;
                    txtShipLocation.Enabled = true;
                    comboShipStatus.Enabled = true;
                }

                if (comboShipChoose.SelectedIndex == 2) {
                    btnRetreiveShip.Visible = true;
                    lblShipId.Visible = true;
                    txtShip1Id.Visible = true;

                    btnUpdateShip.Visible = true;
                    btnDeleteShip.Visible = false;
                    btnSaveShip.Visible = false;

                    txtShipName.Enabled = true;
                    txtShipLocation.Enabled = true;
                    comboShipStatus.Enabled = true;
                }

                if (comboShipChoose.SelectedIndex == 3) {
                    btnRetreiveShip.Visible = true;
                    lblShipId.Visible = true;
                    txtShip1Id.Visible = true;

                    btnUpdateShip.Visible = false;
                    btnDeleteShip.Visible = true;
                    btnSaveShip.Visible = false;

                    txtShipName.Enabled = false;
                    txtShipLocation.Enabled = false;
                    comboShipStatus.Enabled = false;
                }
            }

            if(Login.CurrentUserRole == "Staff")
            {
                // Combo Ship Choose
                comboShipChoose.Items.Clear();
                comboShipChoose.Items.Add("Choose Down");
                comboShipChoose.Items.Add("Add Ship");
              

                if (comboShipChoose.SelectedIndex == 0)
                {
                    comboShipChoose.SelectedIndex = 1;
                }
                if (comboShipChoose.SelectedIndex == 1)
                {
                    btnRetreiveShip.Visible = false;
                    lblShipId.Visible = false;
                    txtShip1Id.Visible = false;

                    btnUpdateShip.Visible = false;
                    btnDeleteShip.Visible = false;
                    btnSaveShip.Visible = false;
                    txtShipName.Enabled = true;
                    txtShipLocation.Enabled = true;
                    comboShipStatus.Enabled = true;
                }
            }
        }

        private void btnSaveShip_Click(object sender, EventArgs e)
        {
            AddShip(txtShipName.Text, txtShipLocation.Text, comboShipStatus.Text);
            RefreshShipGrid();
            ClearDataShip();
        }

        private void btnUpdateShip_Click(object sender, EventArgs e)
        {
            // Validate all input fields 
            if (!int.TryParse(txtShip1Id.Text, out int shipId))

            {
                System.Windows.MessageBox.Show("Please ensure all fields are entered correctly.\n",
                                "Input Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                return;
            }

            // If validation passes, call the UpdateContainer method
            try
            {

                UpdateShip(shipId, txtShipName.Text, txtShipLocation.Text, comboShipStatus.Text);

               // System.Windows.MessageBox.Show("Ship updated successfully!", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                RefreshShipGrid();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
            }

            // Clear data fields after update
            ClearDataShip();
        }

        private void btnDeleteShip_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtShip1Id.Text, out int shipId))
            {
                System.Windows.MessageBox.Show("Please enter a valid Ship ID.",
                                "Input Error",
                                (MessageBoxButton)MessageBoxButtons.OK,
                                (MessageBoxImage)MessageBoxIcon.Error);
                return;
            }


            DialogResult result = (DialogResult)System.Windows.MessageBox.Show("Are you sure you want to delete this Ship?",
                                                  "Confirm Delete",
                                                  (MessageBoxButton)MessageBoxButtons.YesNo,
                                                  (MessageBoxImage)MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeleteShip(shipId);

                    RefreshShipGrid();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                }
            }

            ClearDataShip();
        }

        private void btnRetreiveShip_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtShip1Id.Text, out int shipId))
            {
                System.Windows.MessageBox.Show("Please enter a valid Ship ID.",
                                "Input Error",
                                (MessageBoxButton)MessageBoxButtons.OK,
                                (MessageBoxImage)MessageBoxIcon.Error);
                return;
            }

            GetShipByID(shipId);
        }

        private void btnCustomerMngmt_Click(object sender, EventArgs e)
        {
            customerBtn();
        }

        private void btnSalesMngmt_Click(object sender, EventArgs e)
        {
            ShippingBtn();
        }

        private void btnDashboardMngmt_Click(object sender, EventArgs e)
        {
            dashboardBtn();
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

        private void btnLogoutMngmt_Click(object sender, EventArgs e)
        {
            logOutBtn();
        }

        private void btnCargoMngmt_Click(object sender, EventArgs e)
        {
           cargoBtn();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
