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
    public partial class viewLogs : UserControl
    {
        public viewLogs()
        {
            InitializeComponent();
            displayLogs();
        }

        public void displayLogs()
        {
            logdata logData = new logdata();
            List<logdata> listData = logData.GetAllLogs();

            view_logs.DataSource = listData; 
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void viewlog_search_TextChanged(object sender, EventArgs e)
        {
            logdata logData = new logdata();
            List<logdata> filteredData;

            // Check if the search text is empty or contains the placeholder text
            if (string.IsNullOrWhiteSpace(viewlog_search.Text) || viewlog_search.Text == "Search ActionType or ProductID")
            {
                filteredData = logData.GetAllLogs(); // Show all logs if search is empty or placeholder
            }
            else
            {
                filteredData = logData.SearchLogs(viewlog_search.Text.Trim()); // Filter logs based on search term
            }

            view_logs.DataSource = filteredData; // Update the DataGrid with filtered data
        }

        private void viewlog_search_Leave(object sender, EventArgs e)
        {
            // Restore placeholder text if the search box is empty
            if (string.IsNullOrWhiteSpace(viewlog_search.Text))
            {
                viewlog_search.Text = "Search ActionType or ProductID";
                viewlog_search.ForeColor = Color.Gray; // Set the color to gray for placeholder
            }
            else
            {
                viewlog_search.ForeColor = Color.Black; // Set text color to black if there's input
            }
        }

        private void viewlog_search_Enter(object sender, EventArgs e)
        {
            // Clear the placeholder text when focusing on the search field
            if (viewlog_search.Text == "Search ActionType or ProductID")
            {
                viewlog_search.Text = "";
                viewlog_search.ForeColor = Color.Black; // Set the text color to black while typing
            }
        }

        private void viewLogs_Load(object sender, EventArgs e)
        {
            viewlog_search.Text = "Search ActionType or ProductID";
            viewlog_search.ForeColor = Color.Gray;

            displayLogs();
        }
    }
}
