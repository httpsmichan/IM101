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
    public partial class inventory : UserControl
    {
        SqlConnection
          connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        private int getID = 0;
        public inventory()
        {
            InitializeComponent();
            DisplayAllProducts();
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

        public bool checkConnection()
        {
            if (connect.State != ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool EmptyFields()
        {
            if (inventory_prodID.Text == "" || inventory_prodname.Text == ""
                || inventory_price.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void DisplayAllProducts()
        {
            try
            {
                inventorydata inventoryData = new inventorydata();
                List<inventorydata> dataList = inventoryData.AllInventoryData();

                inventory_grid.DataSource = null;
                inventory_grid.DataSource = dataList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void inventory_addbtn_Click(object sender, EventArgs e)
        {
        }

        public void clearFields()
        {
            inventory_prodID.Text = "";
            inventory_prodname.Text = "";
            inventory_price.Text = "";
            inventory_stock.Text = "";
            inventory_am.Text = "";
        }

        private void inventory_clearbtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void inventory_removebtn_Click(object sender, EventArgs e)
        {
            
        }

        private void inventory_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = inventory_grid.Rows[e.RowIndex];

                if (row.Cells[1].Value != DBNull.Value)
                {
                    getID = (int)row.Cells[1].Value;

                    inventory_prodID.Text = row.Cells[1].Value.ToString();
                    inventory_prodname.Text = row.Cells[2].Value.ToString();
                    inventory_price.Text = row.Cells[3].Value.ToString();
                    inventory_stock.Text = row.Cells[4].Value.ToString();
                    inventory_am.Text = row.Cells[5].Value.ToString();
                }
            }
        }

        private void inventory_upbtn_Click(object sender, EventArgs e)
        {
            if (EmptyFields())
            {
                MessageBox.Show("Empty Fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string amount = inventory_am.Text.Trim();
                if (string.IsNullOrEmpty(amount))
                {
                    MessageBox.Show("Please enter a valid amount.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                if (MessageBox.Show("Are you sure you want to Update Product ID: " + getID.ToString() + "?",
                                    "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();

                            string storedProcedure = "UpdateProductInventory";

                            using (SqlCommand cmd = new SqlCommand(storedProcedure, connect))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@ProductID", getID); 
                                cmd.Parameters.AddWithValue("@Amount", amount);

                                cmd.ExecuteNonQuery();

                                clearFields();
                                DisplayAllProducts();
                                
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to update the product: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }
            }
        }

        private void inventory_Load(object sender, EventArgs e)
        {
            inventory_search.Text = "Search Product";
            inventory_search.ForeColor = Color.Gray;

            DisplayAllProducts();
        }

        private void inventory_search_TextChanged(object sender, EventArgs e)
        {
            inventorydata iData = new inventorydata();
            List<inventorydata> filteredData;


            if (string.IsNullOrWhiteSpace(inventory_search.Text) || inventory_search.Text == "Search Product")
            {
                filteredData = iData.AllInventoryData(); 
            }
            else
            {
                filteredData = iData.SearchInventory(inventory_search.Text.Trim()); 
            }

            inventory_grid.DataSource = filteredData; 
        }

        private void inventory_search_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(inventory_search.Text))
            {
                inventory_search.Text = "Search Product";
                inventory_search.ForeColor = Color.Gray; 
            }
            else
            {
                inventory_search.ForeColor = Color.Black; 
            }
        }

        private void inventory_search_Enter(object sender, EventArgs e)
        {


            if (inventory_search.Text == "Search Product")
            {
                inventory_search.Text = "";
                inventory_search.ForeColor = Color.Black; 
            }
        }

        private void inventory_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            inventory_grid.ReadOnly = true;
        }
    }
}
