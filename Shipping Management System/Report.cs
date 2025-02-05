using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Shipping_Management_System
{
    public partial class Report : Form
    {

        //BlackFields of the class
        string connectionString = "Data Source=DESKTOP-LK1SELP;Database=Shipping;Integrated Security=true;";
        public Report()
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
                

                comboChoose.SelectedIndex = 1;
                // Show Admin-specific features
                btnAdminRole.Visible = false;
                btnStaffRole.Visible = true;
                // Additional admin-specific UI elements can be displayed here

            }


            this.Load += Report_Load;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            btnReportMngmt.IconColor = System.Drawing.Color.FromArgb(110, 102, 255);
            btnReportMngmt.ForeColor = System.Drawing.Color.FromArgb(110, 102, 255);

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        //-------------------------------------------------------------------------------------------------------------------------------------------------


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




        private void GetReportCustomer(string filterValue = "")
        {
            
            string query;

            // Construct the query based on the filter value
            if (string.IsNullOrWhiteSpace(filterValue))
            {
                query = "SELECT * FROM Customers";
            }
            else
            {
                query = "SELECT * FROM Customers WHERE CustomerName LIKE @FilterValue";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(filterValue))
                        {
                            command.Parameters.AddWithValue("@FilterValue", "%" + filterValue + "%");
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet, "Customers");

                            ReportDataSource source = new ReportDataSource("DataSet1", dataSet.Tables[0]);

                            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                              "C:\\Users\\RAQIIS COMPUTER\\Documents\\GitHub\\Coding-Zone\\cSharp_Advanced\\Shipping Management System\\Shipping Management System\\Report1.rdlc");
                            reportViewer1.LocalReport.ReportPath = reportPath;
                            reportViewer1.LocalReport.DataSources.Clear();
                            reportViewer1.LocalReport.DataSources.Add(source);
                            reportViewer1.RefreshReport();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void GetReportPort(string filterValue = "")
        {

            string query;

            // Construct the query based on the filter value
            if (string.IsNullOrWhiteSpace(filterValue))
            {
                query = "SELECT * FROM Ports";
            }
            else
            {
                query = "SELECT * FROM Ports WHERE PortName LIKE @FilterValue";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(filterValue))
                        {
                            command.Parameters.AddWithValue("@FilterValue", "%" + filterValue + "%");
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet, "Ports");

                            ReportDataSource source = new ReportDataSource("DataSet1", dataSet.Tables[0]);

                            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                              "C:\\Users\\RAQIIS COMPUTER\\Documents\\GitHub\\Coding-Zone\\cSharp_Advanced\\Shipping Management System\\Shipping Management System\\Report2.rdlc");
                            reportViewer1.LocalReport.ReportPath = reportPath;
                            reportViewer1.LocalReport.DataSources.Clear();
                            reportViewer1.LocalReport.DataSources.Add(source);
                            reportViewer1.RefreshReport();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetReportShips(string filterValue = "")
        {

            string query;

            // Construct the query based on the filter value
            if (string.IsNullOrWhiteSpace(filterValue))
            {
                query = "SELECT * FROM Ships";
            }
            else
            {
                query = "SELECT * FROM Ships WHERE ShipName LIKE @FilterValue";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(filterValue))
                        {
                            command.Parameters.AddWithValue("@FilterValue", "%" + filterValue + "%");
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet, "Ships");

                            ReportDataSource source = new ReportDataSource("DataSet1", dataSet.Tables[0]);

                            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                              "C:\\Users\\RAQIIS COMPUTER\\Documents\\GitHub\\Coding-Zone\\cSharp_Advanced\\Shipping Management System\\Shipping Management System\\Report3.rdlc");
                            reportViewer1.LocalReport.ReportPath = reportPath;
                            reportViewer1.LocalReport.DataSources.Clear();
                            reportViewer1.LocalReport.DataSources.Add(source);
                            reportViewer1.RefreshReport();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GetReportContainers(string filterValue = "")
        {

            string query;

            // Construct the query based on the filter value
            if (string.IsNullOrWhiteSpace(filterValue))
            {
                query = "SELECT * FROM Containers";
            }
            else
            {
                query = "SELECT * FROM Containers WHERE ContainerID LIKE @FilterValue";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(filterValue))
                        {
                            command.Parameters.AddWithValue("@FilterValue", "%" + filterValue + "%");
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet, "Containers");

                            ReportDataSource source = new ReportDataSource("DataSet1", dataSet.Tables[0]);

                            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                              "C:\\Users\\RAQIIS COMPUTER\\Documents\\GitHub\\Coding-Zone\\cSharp_Advanced\\Shipping Management System\\Shipping Management System\\Report4.rdlc");
                            reportViewer1.LocalReport.ReportPath = reportPath;
                            reportViewer1.LocalReport.DataSources.Clear();
                            reportViewer1.LocalReport.DataSources.Add(source);
                            reportViewer1.RefreshReport();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetReportShippingOrder(string filterValue = "")
        {

            string query;

            // Construct the query based on the filter value
            if (string.IsNullOrWhiteSpace(filterValue))
            {
                query = "SELECT * FROM ShippingOrders";
            }
            else
            {
                query = "SELECT * FROM ShippingOrders WHERE OrderID LIKE @FilterValue";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(filterValue))
                        {
                            command.Parameters.AddWithValue("@FilterValue", "%" + filterValue + "%");
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet, "ShippingOrders");

                            ReportDataSource source = new ReportDataSource("DataSet1", dataSet.Tables[0]);

                            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                              "C:\\Users\\RAQIIS COMPUTER\\Documents\\GitHub\\Coding-Zone\\cSharp_Advanced\\Shipping Management System\\Shipping Management System\\Report5.rdlc");
                            reportViewer1.LocalReport.ReportPath = reportPath;
                            reportViewer1.LocalReport.DataSources.Clear();
                            reportViewer1.LocalReport.DataSources.Add(source);
                            reportViewer1.RefreshReport();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------

        private void comboChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboChoose.SelectedIndex == 0) {
                txtSearch.Text = "";
                txtSearch.Focus();
                GetReportCustomer(txtSearch.Text);
            }

            if (comboChoose.SelectedIndex == 1)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
                GetReportPort(txtSearch.Text);
            }

            if (comboChoose.SelectedIndex == 2)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
                GetReportShips(txtSearch.Text);
            }

            if (comboChoose.SelectedIndex == 3)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
                GetReportContainers(txtSearch.Text);
            }

            if (comboChoose.SelectedIndex == 4)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
                GetReportShippingOrder(txtSearch.Text);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (comboChoose.SelectedIndex == 0)
            {

                GetReportCustomer(txtSearch.Text);
            }

            if (comboChoose.SelectedIndex == 1)
            {
                GetReportPort(txtSearch.Text);
            }

            if (comboChoose.SelectedIndex == 2)
            {
                GetReportShips(txtSearch.Text);
            }

            if (comboChoose.SelectedIndex == 3)
            {
                GetReportContainers(txtSearch.Text);
            }

            if (comboChoose.SelectedIndex == 4)
            {
                GetReportShippingOrder(txtSearch.Text);
            }
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
    }
}
