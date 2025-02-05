using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shipping_Management_System.Properties;

namespace Shipping_Management_System
{
    public partial class Dashboard : Form
    {


        //BlackFields of the class
        string connectionString = "Data Source=DESKTOP-LK1SELP;Database=Shipping;Integrated Security=true;";
        public Dashboard()
        {
            InitializeComponent();

            if (Login.CurrentUserRole == "Admin")
            {

                // Show Admin-specific features
                btnAdminRole.Visible = true;
                btnStaffRole.Visible = false;
                // Additional admin-specific UI elements can be displayed here
            }

            // Check if the logged-in user is an Staff
            if (Login.CurrentUserRole == "Staff")
            {


                
                // Show Admin-specific features
                btnAdminRole.Visible = false;
                btnStaffRole.Visible = true;
                // Additional admin-specific UI elements can be displayed here

            }


            this.Load += Dashboard_Load;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

            btnDashboardMngmt.IconColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnDashboardMngmt.ForeColor = System.Drawing.Color.FromArgb(110, 102, 255);




            lblCustomerCount.Text = GetTotalCustomerCount().ToString();
            lblordersCount.Text = GetTotalShippingOrderCount().ToString();
            lblPortCount.Text = GetTotalPortCount().ToString();
            lblShipsCount.Text = GetTotalShipsCount().ToString();
            lblContainersCount.Text = GetTotalContainerCount().ToString();
        }




        //--------------------------------------------------------------------------------------------------------------------------------

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



        private int GetTotalCustomerCount()
        {
            string query = "SELECT COUNT(*) AS TotalCustomers FROM Customers";
            int totalCount = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    totalCount = (int)command.ExecuteScalar(); // ExecuteScalar returns the first column of the first row
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return totalCount;
        }

        private int GetTotalPortCount()
        {
            string query = "SELECT COUNT(*) AS TotalPorts FROM Ports";
            int totalCount = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    totalCount = (int)command.ExecuteScalar(); // ExecuteScalar returns the first column of the first row
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return totalCount;
        }

        private int GetTotalShipsCount()
        {
            string query = "SELECT COUNT(*) AS TotalSHips FROM Ships";
            int totalCount = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    totalCount = (int)command.ExecuteScalar(); // ExecuteScalar returns the first column of the first row
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return totalCount;
        }

        private int GetTotalShippingOrderCount()
        {
            string query = @"SELECT COUNT(*) AS 'Total SHipping Order' FROM ShippingOrders";
            int totalCount = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    totalCount = (int)command.ExecuteScalar(); // ExecuteScalar returns the first column of the first row
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return totalCount;
        }


        private int GetTotalContainerCount()
        {
            string query = "SELECT COUNT(*) AS TotalContainers FROM Containers";
            int totalCount = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    totalCount = (int)command.ExecuteScalar(); // ExecuteScalar returns the first column of the first row
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return totalCount;
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

        private void btnSettingsMngmt_Click(object sender, EventArgs e)
        {
            userManagerBtn();
        }

        private void btnLogoutMngmt_Click(object sender, EventArgs e)
        {
            logOutBtn();
        }


        //--------------------------------------------------------------------------------------------------------------------------------

    }
}
