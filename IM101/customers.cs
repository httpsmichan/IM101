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

            if (string.IsNullOrWhiteSpace(customer_search.Text))
            {
                filteredData = cData.allCustomers();
            }
            else
            {
                filteredData = cData.SearchCustomers(customer_search.Text.Trim());
            }

            dataGridView_Customers.DataSource = filteredData;
        }

        private void customer_search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(customer_search.Text))
            {
                customer_search.Text = "Search CustomerID";
                customer_search.ForeColor = Color.Gray;
            }
        }

        private void customer_search_Enter(object sender, EventArgs e)
        {
            if (customer_search.Text == "Search CustomerID")
            {
                customer_search.Text = "";
                customer_search.ForeColor = Color.Black;
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
