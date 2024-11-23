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


            if (string.IsNullOrWhiteSpace(viewlog_search.Text) || viewlog_search.Text == "Search ActionType or ProductID")
            {
                filteredData = logData.GetAllLogs(); 
            }
            else
            {
                filteredData = logData.SearchLogs(viewlog_search.Text.Trim()); 
            }

            view_logs.DataSource = filteredData; 
        }

        private void viewlog_search_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(viewlog_search.Text))
            {
                viewlog_search.Text = "Search ActionType or ProductID";
                viewlog_search.ForeColor = Color.Gray; 
            }
            else
            {
                viewlog_search.ForeColor = Color.Black; 
            }
        }

        private void viewlog_search_Enter(object sender, EventArgs e)
        {

            if (viewlog_search.Text == "Search ActionType or ProductID")
            {
                viewlog_search.Text = "";
                viewlog_search.ForeColor = Color.Black; 
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
