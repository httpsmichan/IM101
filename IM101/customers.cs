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
    public partial class customers : UserControl
    {
        public customers()
        {
            InitializeComponent();
            displayCustomers();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayCustomers();
        }

        public void displayCustomers()
        {
            customersdata cData = new customersdata();

            List<customersdata> listData = cData.allCustomers();

            dataGridView_Customers.DataSource = listData;
        }

        private void dataGridView_Customers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_Customers.ReadOnly = true;
        }

        private void customer_search_TextChanged(object sender, EventArgs e)
        {
            customersdata cData = new customersdata();
            List<customersdata> filteredData;

            // Check if the search text is empty or contains the placeholder text
            if (string.IsNullOrWhiteSpace(customer_search.Text) || customer_search.Text == "Search CustomerID")
            {
                filteredData = cData.allCustomers(); // Show all customers if search is empty or placeholder
            }
            else
            {
                filteredData = cData.SearchCustomers(customer_search.Text.Trim()); // Filter customers based on search term
            }

            dataGridView_Customers.DataSource = filteredData; // Update the DataGrid with filtered data
        }

        private void customer_search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(customer_search.Text))
            {
                customer_search.Text = "Search CustomerID";
                customer_search.ForeColor = Color.Gray; // Set the color to gray for placeholder
            }
            else
            {
                customer_search.ForeColor = Color.Black; // Set text color to black if there's input
            }
        }

        private void customer_search_Enter(object sender, EventArgs e)
        {
            // Clear the placeholder text when focusing on the search field
            if (customer_search.Text == "Search CustomerID")
            {
                customer_search.Text = "";
                customer_search.ForeColor = Color.Black; // Set the text color to black while typing
            }
        }

        private void customers_Load(object sender, EventArgs e)
        {
            customer_search.Text = "Search CustomerID";
            customer_search.ForeColor = Color.Gray;

            displayCustomers();
        }
    }
}
