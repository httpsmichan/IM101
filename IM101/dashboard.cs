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

namespace IM101
{
    public partial class dashboard : UserControl
    {
        SqlConnection
        connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        private Timer refreshTimer;
        public dashboard()
        {
            InitializeComponent();
            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            displayTodayCustomer();
            displayAllusers();
            displayAllCustomers();
            displayTodaysIncome();
            overallTotalIncome();
            refreshData();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            refreshTimer = new Timer
            {
                Interval = 5000
            };
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            refreshData();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            displayAllusers();
            displayAllCustomers();
            displayTodaysIncome();
            overallTotalIncome();
        }


        public void displayTodayCustomer()
        {
            var cData = new customersdata();
            List<customersdata> listData = cData.allTodayCustomers();
            dataGridView_todayc.DataSource = listData;
            dataGridView_todayc.Refresh();

        }

        public bool checkConnection()
        {
            return connect.State == ConnectionState.Closed;
        }

        public void displayAllusers()
        {
            if (!checkConnection()) return;

            try
            {
                connect.Open();
                string query = "SELECT Role, StaffCount FROM dbo.GetStaffCount()"; 

                using (var cmd = new SqlCommand(query, connect))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        int adminCount = 0;
                        int cashierCount = 0;

                        while (reader.Read())
                        {
                            string role = reader["Role"].ToString();
                            int staffCount = Convert.ToInt32(reader["StaffCount"]);

                            if (role == "Admin")
                            {
                                adminCount = staffCount;  
                            }
                            else if (role == "Cashier")
                            {
                                cashierCount = staffCount;  
                            }
                        }

                        int totalCount = adminCount + cashierCount;

                        allusers.Text = totalCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowConnectionError(ex);
            }
            finally
            {
                connect.Close();
            }
        }

        public void displayAllCustomers()
        {
            if (!checkConnection()) return;

            try
            {
                connect.Open();
                string query = "SELECT dbo.GetTotalCustomers()";  

                using (var cmd = new SqlCommand(query, connect))
                {

                    var result = cmd.ExecuteScalar();


                    allcustomers.Text = result != DBNull.Value ? Convert.ToInt32(result).ToString() : "0";
                }
            }
            catch (Exception ex)
            {
                ShowConnectionError(ex);
            }
            finally
            {
                connect.Close();
            }
        }


        public void displayTodaysIncome()
        {
            if (!checkConnection()) return;

            try
            {
                connect.Open();
                string query = "SELECT dbo.GetTodaysIncome()";  

                using (var cmd = new SqlCommand(query, connect))
                {
                    var result = cmd.ExecuteScalar();

                    todayincome.Text = result != DBNull.Value
                        ? Convert.ToDecimal(result).ToString("0.00")
                        : "0.00";
                }
            }
            catch (Exception ex)
            {
                ShowConnectionError(ex);
            }
            finally
            {
                connect.Close();
            }
        }


        public void overallTotalIncome()
        {
            if (!checkConnection()) return;

            try
            {
                connect.Open();
                string query = "SELECT dbo.GetOverallTotalIncome()";  

                using (var cmd = new SqlCommand(query, connect))
                {

                    var result = cmd.ExecuteScalar();


                    totalincome.Text = result != DBNull.Value ? Convert.ToDecimal(result).ToString("0.00") : "0.00";
                }
            }
            catch (Exception ex)
            {
                ShowConnectionError(ex);
            }
            finally
            {
                connect.Close();
            }
        }


        private void ShowConnectionError(Exception ex)
        {
            MessageBox.Show($"Connection Failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridView_todayc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_todayc.ReadOnly = true;
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            displayTodayCustomer();
        }
    }
}
