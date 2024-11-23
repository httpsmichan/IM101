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


            if (string.IsNullOrWhiteSpace(viewinv_search.Text) || viewinv_search.Text == "Search Product")
            {
                filteredData = iData.AllInventoryData(); 
            }
            else
            {
                filteredData = iData.SearchInventory(viewinv_search.Text.Trim()); 
            }

            view_inventory.DataSource = filteredData; 
        }

        private void viewinv_search_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(viewinv_search.Text))
            {
                viewinv_search.Text = "Search Product";
                viewinv_search.ForeColor = Color.Gray; 
            }
            else
            {
                viewinv_search.ForeColor = Color.Black; 
            }
        }

        private void viewinv_search_Enter(object sender, EventArgs e)
        {

            if (viewinv_search.Text == "Search Product")
            {
                viewinv_search.Text = "";
                viewinv_search.ForeColor = Color.Black; 
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
