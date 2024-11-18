using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IM101
{
    public partial class logs : UserControl
    {
        public logs()
        {
            InitializeComponent();
            displayLogs();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayLogs();
        }

        public void displayLogs()
        {
            logdata logData = new logdata();
            List<logdata> listData = logData.GetAllLogs();

            logs_datagrid.DataSource = listData; // Bind the logs to the DataGridView
        }

        private void logs_datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            logs_datagrid.ReadOnly = true;
        }

        private void log_search_TextChanged(object sender, EventArgs e)
        {
            logdata logData = new logdata();
            List<logdata> filteredData;

            if (string.IsNullOrWhiteSpace(log_search.Text))
            {
                filteredData = logData.GetAllLogs(); 
            }
            else
            {
                //filteredData = logData.GetAllLogs(log_search.Text.Trim()); 
            }

           // logs_datagrid.DataSource = filteredData;
        }

        private void log_search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(log_search.Text))
            {
                log_search.Text = "Search ActionType or ProductID";
                log_search.ForeColor = Color.Gray;
            }
        }

        private void log_search_Enter(object sender, EventArgs e)
        {
            if (log_search.Text == "Search ActionType or ProductID")
            {
                log_search.Text = "";
                log_search.ForeColor = Color.Black;
            }
        }

        private void logs_Load(object sender, EventArgs e)
        {
            log_search.Text = "Search ActionType or ProductID";
            log_search.ForeColor = Color.Gray;

            displayLogs();
        }

        private void logs_datagrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            logs_datagrid.ReadOnly = true;
        }
    }
}
