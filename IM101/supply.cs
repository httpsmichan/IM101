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
    public partial class supply : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        private int getID = 0;
        public supply()
        {
            InitializeComponent();
            DisplayAllSupplies();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            DisplayAllSupplies();
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
            return string.IsNullOrWhiteSpace(supply_prodID.Text) ||
                   string.IsNullOrWhiteSpace(supply_prodname.Text) ||
                   string.IsNullOrWhiteSpace(supply_qtys.Text) ||
                   string.IsNullOrWhiteSpace(supply_unitcost.Text);
        }

        public void DisplayAllSupplies()
        {
            try
            {
                supplydatas supplyData = new supplydatas();
                List<supplydatas> dataList = supplyData.AllSupplyData();

                supply_grid.DataSource = null;
                supply_grid.DataSource = dataList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public void clearFields()
        {
            supply_prodID.Text = "";
            supply_prodname.Text = "";
            supply_qtys.Text = "";
            supply_unitcost.Text = "";
            supply_totalcost.Text = "";
            supply_status.Text = "";
        }

        private void supply_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            supply_grid.ReadOnly = true;
        }

        public bool emptyFields()
        {
            if (supply_prodID.Text == "" || supply_status.SelectedIndex == -1
                || supply_prodname.Text == "" || supply_qtys.Text == "" || supply_unitcost.Text == "" || supply_totalcost.Text == ""
                || supply_supplierID.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void supply_addbtn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Please fill out all the fields.");
                return;
            }

            string checkProductQuery = "SELECT COUNT(1) FROM Product WHERE ProductID = @ProductID";

            try
            {
                using (SqlCommand checkCommand = new SqlCommand(checkProductQuery, connect))
                {
                    if (checkConnection())
                    {
                        connect.Open();
                    }

                    checkCommand.Parameters.AddWithValue("@ProductID", supply_prodID.Text);
                    int productExists = (int)checkCommand.ExecuteScalar();

                    if (productExists == 0)
                    {
                        MessageBox.Show("The ProductID does not exist in the Product table. Please add the product first.");
                        return;
                    }
                }

                string insertQuery = "INSERT INTO Supply (ProductID, ProductName, QtySupplied, UnitCost, TotalCost, SupplierID, Status, SupplyDate) " +
                                     "VALUES (@ProductID, @ProductName, @Quantity, @UnitCost, @TotalCost, @SupplierID, @Status, @Date)";

                using (SqlCommand command = new SqlCommand(insertQuery, connect))
                {
                    command.Parameters.AddWithValue("@ProductID", supply_prodID.Text);
                    command.Parameters.AddWithValue("@ProductName", supply_prodname.Text);
                    command.Parameters.AddWithValue("@Quantity", supply_qtys.Text);
                    command.Parameters.AddWithValue("@UnitCost", supply_unitcost.Text);
                    command.Parameters.AddWithValue("@TotalCost", supply_totalcost.Text);
                    command.Parameters.AddWithValue("@SupplierID", supply_supplierID.Text);
                    command.Parameters.AddWithValue("@Status", supply_status.SelectedItem == null ? (object)DBNull.Value : supply_status.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Date", DateTime.Today);

                    command.ExecuteNonQuery();
                }

                if (supply_status.SelectedItem.ToString() == "Received")
                {
                    string updateInventoryQuery = "UPDATE Inventory SET Stocks = Stocks + @Quantity WHERE ProductID = @ProductID";

                    using (SqlCommand inventoryCommand = new SqlCommand(updateInventoryQuery, connect))
                    {
                        inventoryCommand.Parameters.AddWithValue("@Quantity", supply_qtys.Text);
                        inventoryCommand.Parameters.AddWithValue("@ProductID", supply_prodID.Text);

                        inventoryCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Supply data added successfully!");
                clearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }

                DisplayAllSupplies();
            }
        }

        private void supply_clearbtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void supply_upbtn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Please fill out all the fields.");
                return;
            }

            string checkProductQuery = "SELECT COUNT(1) FROM Supply WHERE ProductID = @ProductID";

            try
            {
                using (SqlCommand checkCommand = new SqlCommand(checkProductQuery, connect))
                {
                    if (checkConnection())
                    {
                        connect.Open();
                    }

                    checkCommand.Parameters.AddWithValue("@ProductID", supply_prodID.Text);
                    int productExists = (int)checkCommand.ExecuteScalar();

                    if (productExists == 0)
                    {
                        MessageBox.Show("The ProductID does not exist in the Supply table. Please add the supply data first.");
                        return;
                    }
                }

                string updateQuery = "UPDATE Supply SET ProductName = @ProductName, QtySupplied = @Quantity, UnitCost = @UnitCost, " +
                                     "TotalCost = @TotalCost, SupplierID = @SupplierID, Status = @Status, SupplyDate = @Date " +
                                     "WHERE ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(updateQuery, connect))
                {
                    command.Parameters.AddWithValue("@ProductID", supply_prodID.Text);
                    command.Parameters.AddWithValue("@ProductName", supply_prodname.Text);
                    command.Parameters.AddWithValue("@Quantity", supply_qtys.Text);
                    command.Parameters.AddWithValue("@UnitCost", supply_unitcost.Text);
                    command.Parameters.AddWithValue("@TotalCost", supply_totalcost.Text);
                    command.Parameters.AddWithValue("@SupplierID", supply_supplierID.Text);
                    command.Parameters.AddWithValue("@Status", supply_status.SelectedItem == null ? (object)DBNull.Value : supply_status.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Date", DateTime.Today);

                    command.ExecuteNonQuery();
                }

                // If status is "Received", update the inventory
                if (supply_status.SelectedItem.ToString() == "Received")
                {
                    string updateInventoryQuery = "UPDATE Inventory SET Quantity = Quantity + @Quantity WHERE ProductID = @ProductID";

                    using (SqlCommand inventoryCommand = new SqlCommand(updateInventoryQuery, connect))
                    {
                        inventoryCommand.Parameters.AddWithValue("@Quantity", supply_qtys.Text);
                        inventoryCommand.Parameters.AddWithValue("@ProductID", supply_prodID.Text);

                        inventoryCommand.ExecuteNonQuery();
                    }
                }

                clearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }

                DisplayAllSupplies();
            }
        }

        private void remove_removebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(supply_prodID.Text))
            {
                MessageBox.Show("Please provide a ProductID to remove.");
                return;
            }

            string checkProductQuery = "SELECT COUNT(1) FROM Supply WHERE ProductID = @ProductID";

            try
            {
                using (SqlCommand checkCommand = new SqlCommand(checkProductQuery, connect))
                {
                    if (checkConnection())
                    {
                        connect.Open();
                    }

                    checkCommand.Parameters.AddWithValue("@ProductID", supply_prodID.Text);
                    int productExists = (int)checkCommand.ExecuteScalar();

                    if (productExists == 0)
                    {
                        MessageBox.Show("The ProductID does not exist in the Supply table.");
                        return;
                    }
                }

                // Get QtySupplied to adjust inventory
                string qtyQuery = "SELECT QtySupplied FROM Supply WHERE ProductID = @ProductID";
                int qtySupplied = 0;
                using (SqlCommand qtyCommand = new SqlCommand(qtyQuery, connect))
                {
                    qtyCommand.Parameters.AddWithValue("@ProductID", supply_prodID.Text);
                    qtySupplied = (int)qtyCommand.ExecuteScalar();
                }

                string deleteQuery = "DELETE FROM Supply WHERE ProductID = @ProductID";

                using (SqlCommand command = new SqlCommand(deleteQuery, connect))
                {
                    command.Parameters.AddWithValue("@ProductID", supply_prodID.Text);

                    command.ExecuteNonQuery();
                }

                // Update Inventory by subtracting the qtySupplied
                string updateInventoryQuery = "UPDATE Inventory SET Quantity = Quantity - @Quantity WHERE ProductID = @ProductID";

                using (SqlCommand inventoryCommand = new SqlCommand(updateInventoryQuery, connect))
                {
                    inventoryCommand.Parameters.AddWithValue("@Quantity", qtySupplied);
                    inventoryCommand.Parameters.AddWithValue("@ProductID", supply_prodID.Text);

                    inventoryCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Supply data removed successfully!");
                clearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }

                DisplayAllSupplies();
            }
        }

        private void supply_Load(object sender, EventArgs e)
        {
            supply_search.Text = "Search Product";
            supply_search.ForeColor = Color.Gray;

            DisplayAllSupplies();
        }

        private void supply_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = supply_grid.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value;

                supply_supplierID.Text = row.Cells[1].Value.ToString();
                supply_prodID.Text = row.Cells[2].Value.ToString();
                supply_prodname.Text = row.Cells[3].Value.ToString();
                supply_qtys.Text = row.Cells[4].Value.ToString();
                supply_unitcost.Text = row.Cells[5].Value.ToString();
                supply_totalcost.Text = row.Cells[6].Value.ToString();
                supply_status.Text = row.Cells[7].Value.ToString();

            }
        }

        private void supply_search_TextChanged(object sender, EventArgs e)
        {
            supplydatas iData = new supplydatas();
            List<supplydatas> filteredData;

            if (string.IsNullOrWhiteSpace(supply_search.Text))
            {
                filteredData = iData.AllSupplyData();
            }
            else
            {
                filteredData = iData.SearchSupply(supply_search.Text.Trim());
            }

            supply_grid.DataSource = filteredData;
        }

        private void supply_search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(supply_search.Text))
            {
                supply_search.Text = "Search Product";
                supply_search.ForeColor = Color.Gray;
            }
        }

        private void supply_search_Enter(object sender, EventArgs e)
        {
            if (supply_search.Text == "Search Product")
            {
                supply_search.Text = "";
                supply_search.ForeColor = Color.Black;
            }
        }
    }
}
