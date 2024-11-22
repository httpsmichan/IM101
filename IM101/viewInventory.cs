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
    public partial class viewInventory : UserControl
    {
        public viewInventory()
        {
            InitializeComponent();
            DisplayAllProducts();
        }

        public void DisplayAllProducts()
        {
            try
            {
                inventorydata inventoryData = new inventorydata();
                List<inventorydata> dataList = inventoryData.AllInventoryData();

                view_inventory.DataSource = null;
                view_inventory.DataSource = dataList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            DisplayAllProducts();
        }

        private void viewinv_search_TextChanged(object sender, EventArgs e)
        {
            inventorydata iData = new inventorydata();
            List<inventorydata> filteredData;

            // Check if the search text is empty or contains the placeholder text
            if (string.IsNullOrWhiteSpace(viewinv_search.Text) || viewinv_search.Text == "Search Product")
            {
                filteredData = iData.AllInventoryData(); // Show all inventory items if search is empty or placeholder
            }
            else
            {
                filteredData = iData.SearchInventory(viewinv_search.Text.Trim()); // Filter inventory based on search term
            }

            view_inventory.DataSource = filteredData; // Update the DataGrid with filtered data
        }

        private void viewinv_search_Leave(object sender, EventArgs e)
        {
            // Restore placeholder text if the search box is empty
            if (string.IsNullOrWhiteSpace(viewinv_search.Text))
            {
                viewinv_search.Text = "Search Product";
                viewinv_search.ForeColor = Color.Gray; // Set the color to gray for placeholder
            }
            else
            {
                viewinv_search.ForeColor = Color.Black; // Set text color to black if there's input
            }
        }

        private void viewinv_search_Enter(object sender, EventArgs e)
        {
            // Clear the placeholder text when focusing on the search field
            if (viewinv_search.Text == "Search Product")
            {
                viewinv_search.Text = "";
                viewinv_search.ForeColor = Color.Black; // Set the text color to black while typing
            }
        }

        private void viewInventory_Load(object sender, EventArgs e)
        {
            viewinv_search.Text = "Search Product";
            viewinv_search.ForeColor = Color.Gray;

            DisplayAllProducts();
        }
    }
}
