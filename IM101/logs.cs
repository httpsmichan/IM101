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

            // Check if the search text is empty or contains the placeholder text
            if (string.IsNullOrWhiteSpace(log_search.Text) || log_search.Text == "Search ActionType or ProductID")
            {
                filteredData = logData.GetAllLogs(); // Show all logs if search is empty or placeholder
            }
            else
            {
                filteredData = logData.SearchLogs(log_search.Text.Trim()); // Filter logs based on search term
            }

            logs_datagrid.DataSource = filteredData; // Update the DataGrid with filtered data
        }

        private void log_search_Leave(object sender, EventArgs e)
        {
            // Restore placeholder text if the search box is empty
            if (string.IsNullOrWhiteSpace(log_search.Text))
            {
                log_search.Text = "Search ActionType or ProductID";
                log_search.ForeColor = Color.Gray; // Set the color to gray for placeholder
            }
            else
            {
                log_search.ForeColor = Color.Black; // Set text color to black if there's input
            }
        }

        private void log_search_Enter(object sender, EventArgs e)
        {
            // Clear the placeholder text when focusing on the search field
            if (log_search.Text == "Search ActionType or ProductID")
            {
                log_search.Text = "";
                log_search.ForeColor = Color.Black; // Set the text color to black while typing
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
