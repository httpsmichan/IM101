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
                string query = "SELECT COUNT(*) FROM Staff";

                using (var cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@role", "Cashier");
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            allusers.Text = count.ToString();
                        }
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
                string query = "SELECT COUNT(*) FROM Billing";

                using (var cmd = new SqlCommand(query, connect))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            allcustomers.Text = count.ToString();
                        }
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

        public void displayTodaysIncome()
        {
            if (!checkConnection()) return;

            try
            {
                connect.Open();
                string query = "SELECT SUM(TotalPrice) FROM Billing WHERE OrderDate = @date";

                using (var cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@date", DateTime.Today.ToString("yyyy-MM-dd"));

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            object value = reader[0];
                            todayincome.Text = (value != DBNull.Value && value != null)
                                ? Convert.ToDecimal(value).ToString("0.00")
                                : "0.00";
                        }
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

        public void overallTotalIncome()
        {
            if (!checkConnection()) return;

            try
            {
                connect.Open();
                string query = "SELECT SUM(TotalPrice) FROM Billing";

                using (var cmd = new SqlCommand(query, connect))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal total = Convert.ToDecimal(reader[0]);
                            totalincome.Text = total.ToString("0.00");
                        }
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
