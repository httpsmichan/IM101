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
            supply_supplierID.Text = "";
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
                // Ensure the connection is open before starting any SQL commands
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }

                // Check if product exists in Product table
                using (SqlCommand checkCommand = new SqlCommand(checkProductQuery, connect))
                {
                    checkCommand.Parameters.AddWithValue("@ProductID", supply_prodID.Text);
                    int productExists = (int)checkCommand.ExecuteScalar();

                    if (productExists == 0)
                    {
                        MessageBox.Show("The ProductID does not exist in the Product table. Please add the product first.");
                        return;
                    }
                }

                // Retrieve ProductName and UnitCost (Price) from Supply table
                string getProductDetailsQuery = "SELECT ProductName, UnitCost FROM Supply WHERE ProductID = @ProductID";
                string productName = string.Empty;
                double unitCost = 0;

                using (SqlCommand getProductDetailsCommand = new SqlCommand(getProductDetailsQuery, connect))
                {
                    getProductDetailsCommand.Parameters.AddWithValue("@ProductID", supply_prodID.Text);
                    using (SqlDataReader reader = getProductDetailsCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            productName = reader["ProductName"].ToString();
                            unitCost = Convert.ToDouble(reader["UnitCost"]);
                        }
                    }
                }

                // Handle the status and logging logic
                string status = supply_status.SelectedItem == null ? "Order Placed" : supply_status.SelectedItem.ToString();

                if (status == "Received")
                {
                    // Log the inventory update for "Received"
                    InsertLogEntry(connect, supply_prodID.Text, supply_qtys.Text, "Supply Received");
                }
                else
                {
                    // Insert the order with "Order Placed" status if not "Received"
                    status = "Order Placed"; // Set status to "Order Placed"
                }

                // Insert supply data into the Supply table with the correct status
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
                    command.Parameters.AddWithValue("@Status", status); // Insert the correct status ("Order Placed" or "Received")
                    command.Parameters.AddWithValue("@Date", DateTime.Today);

                    command.ExecuteNonQuery(); // Execute the insert query for Supply
                }

                // Ensure connection is open for Inventory insert
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();  // Explicitly open the connection for Inventory insert
                }

                // Call the InsertInventory method to insert into Inventory table
                InsertInventory(connect, supply_prodID.Text, productName, unitCost, supply_qtys.Text);
                clearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure that the connection is closed at the end of the process.
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }

                DisplayAllSupplies(); // Refresh UI or data view
            }
        }

        private void InsertInventory(SqlConnection connection, string productID, string productName, double unitCost, string quantitySupplied)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                // Query to get the price from the Product table using productID
                string getPriceQuery = "SELECT Price FROM Product WHERE ProductID = @ProductID";

                double price = unitCost; // Use the provided unit cost (or get from Product table if needed)

                using (SqlCommand priceCommand = new SqlCommand(getPriceQuery, connection))
                {
                    priceCommand.Parameters.AddWithValue("@ProductID", productID);

                    // Execute the query and get the price
                    var result = priceCommand.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        price = Convert.ToDouble(result); // Convert the result to double
                    }
                    else
                    {
                        MessageBox.Show("Product not found or price is unavailable.");
                        return; // Exit if no price found
                    }
                }

                // Now insert into the Inventory table with the fetched price
                string insertInventoryQuery = "INSERT INTO Inventory (ProductID, ProductName, Price, Stocks, Amount, Date) " +
                                              "VALUES (@ProductID, @ProductName, @Price, @Stocks, @Amount, @Date)";

                using (SqlCommand inventoryCommand = new SqlCommand(insertInventoryQuery, connection))
                {
                    inventoryCommand.Parameters.AddWithValue("@ProductID", productID);
                    inventoryCommand.Parameters.AddWithValue("@ProductName", productName);
                    inventoryCommand.Parameters.AddWithValue("@Price", price); // Use the fetched price here
                    inventoryCommand.Parameters.AddWithValue("@Stocks", quantitySupplied);
                    inventoryCommand.Parameters.AddWithValue("@Amount", "pcs");
                    inventoryCommand.Parameters.AddWithValue("@Date", DateTime.Today);

                    inventoryCommand.ExecuteNonQuery();
                }

                Console.WriteLine("Inventory data inserted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting inventory: " + ex.Message);
            }
        }


        private void InsertLogEntry(SqlConnection connection, string productID, string quantitySupplied, string actionType)
        {
            try
            {
                // Ensure the connection is open before starting any query
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open(); // Explicitly open the connection if it's not already open
                }

                // Get current stock for the product (PrevStock)
                int prevStock = GetCurrentStock(connection, Convert.ToInt32(productID));

                // Calculate the new stock after the supply is added (NewStock)
                int newStock = prevStock + Convert.ToInt32(quantitySupplied);


                // Insert the log with correct values for PrevStock and NewStock
                string insertLogQuery = "INSERT INTO Logs (ActionType, ProductID, QuantityChange, PrevStock, NewStock, Staff, Date) " +
                                        "VALUES (@actionType, @prodID, @quantityChange, @prevStock, @newStock, @staff, @date)";

                using (var cmdLog = new SqlCommand(insertLogQuery, connection))
                {
                    string username = Form1.username.Substring(0, 1).ToUpper() + Form1.username.Substring(1).ToLower();

                    // Set the log parameters
                    cmdLog.Parameters.AddWithValue("@actionType", actionType); // Action type (e.g., "Supply Received")
                    cmdLog.Parameters.AddWithValue("@prodID", productID); // Product ID
                    cmdLog.Parameters.AddWithValue("@quantityChange", quantitySupplied); // Quantity supplied (change in stock)
                    cmdLog.Parameters.AddWithValue("@prevStock", prevStock); // Stock before the supply (PrevStock)
                    cmdLog.Parameters.AddWithValue("@newStock", newStock); // Stock after the supply (NewStock)
                    cmdLog.Parameters.AddWithValue("@staff", "@" + username); 
                    cmdLog.Parameters.AddWithValue("@date", DateTime.Now); 

                    cmdLog.ExecuteNonQuery(); // Execute the command to insert the log
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting log: " + ex.Message);
            }
        }

        private int GetCurrentStock(SqlConnection connection, int productID)
        {
            string query = "SELECT SUM(Stocks) FROM Inventory WHERE ProductID = @prodID GROUP BY ProductID";
            using (var cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@prodID", productID);
                var result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
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

            if (string.IsNullOrWhiteSpace(supply_search.Text) || supply_search.Text == "Search Product")
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

        private void supply_totalcost_TextChanged(object sender, EventArgs e)
        {
            supply_totalcost.ReadOnly = true;
        }

        private void supply_unitcost_KeyDown(object sender, KeyEventArgs e)
        {
            
            double supply_qty = 0;
            TextBox supply_qtyTextBox = supply_qtys; 
            if (double.TryParse(supply_qtyTextBox.Text, out supply_qty)) 
            {
                
                double supply_unitcost1 = 0;
                TextBox supply_unitcostTextBox = supply_unitcost; 
                if (double.TryParse(supply_unitcostTextBox.Text, out supply_unitcost1)) 
                {
                    double total_cost = supply_qty * supply_unitcost1;

                    TextBox total_costTextBox = supply_totalcost; 
                    total_costTextBox.Text = total_cost.ToString("F2"); 
                }
                else
                {
                    TextBox total_costTextBox = supply_totalcost; 
                    total_costTextBox.Text = "Invalid input";
                }
            }
            else
            {
                TextBox total_costTextBox = supply_totalcost; 
                total_costTextBox.Text = "Invalid input";
            }
        }
    }
}
