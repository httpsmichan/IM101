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
            if (EmptyFields())
            {
                MessageBox.Show("Empty Fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    string selectProductQuery = "SELECT ProductID FROM Product WHERE ProductName = @prodName";
                    int productID;
                    int prevStock = 0;
                    int newStock = 0;

                    using (SqlCommand cmd = new SqlCommand(selectProductQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@prodName", inventory_prodname.Text.Trim());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                productID = Convert.ToInt32(reader["ProductID"]);
                            }
                            else
                            {
                                // Insert into Product table
                                string insertProductQuery = @"
                        INSERT INTO Product (ProductName, Price)
                        OUTPUT INSERTED.ProductID
                        VALUES (@prodName, @price)";

                                reader.Close();

                                using (SqlCommand insertProductCmd = new SqlCommand(insertProductQuery, connect))
                                {
                                    insertProductCmd.Parameters.AddWithValue("@prodName", inventory_prodname.Text.Trim());
                                    insertProductCmd.Parameters.AddWithValue("@price", inventory_price.Text.Trim());
                                    productID = (int)insertProductCmd.ExecuteScalar();
                                }
                            }
                        }
                    }

                    connect.Close();
                    connect.Open();

                    // Fetch the latest NewStock from Logs
                    string getLastNewStockQuery = @"
                SELECT TOP 1 NewStock 
                FROM Logs 
                WHERE ProductID = @prodID 
                ORDER BY Date DESC";

                    using (SqlCommand getLastNewStockCmd = new SqlCommand(getLastNewStockQuery, connect))
                    {
                        getLastNewStockCmd.Parameters.AddWithValue("@prodID", productID);
                        object lastNewStockResult = getLastNewStockCmd.ExecuteScalar();

                        prevStock = lastNewStockResult != null ? Convert.ToInt32(lastNewStockResult) : 0;
                    }

                    int quantityChange = string.IsNullOrEmpty(inventory_stock.Text.Trim())
                        ? 0
                        : Convert.ToInt32(inventory_stock.Text.Trim());
                    newStock = prevStock + quantityChange;

                    // Insert a new row into the Inventory table
                    string insertInventoryQuery = @"
                INSERT INTO Inventory (ProductID, Price, Stocks, Amount, Date)
                VALUES (@prodID, @price, @stocks, @amount, @date)";

                    using (SqlCommand insertInventoryCmd = new SqlCommand(insertInventoryQuery, connect))
                    {
                        insertInventoryCmd.Parameters.AddWithValue("@prodID", productID);
                        insertInventoryCmd.Parameters.AddWithValue("@price", inventory_price.Text.Trim());
                        insertInventoryCmd.Parameters.AddWithValue("@stocks", quantityChange);
                        insertInventoryCmd.Parameters.AddWithValue("@amount", string.IsNullOrEmpty(inventory_am.Text.Trim()) ? (object)DBNull.Value : inventory_am.Text.Trim());
                        insertInventoryCmd.Parameters.AddWithValue("@date", DateTime.Today);

                        insertInventoryCmd.ExecuteNonQuery();
                    }

                    // Insert into Logs table
                    string insertLogQuery = @"
                INSERT INTO Logs (ActionType, ProductID, QuantityChange, PrevStock, NewStock, Staff, Price, Date)
                VALUES (@actionType, @prodID, @quantityChange, @prevStock, @newStock, @staff, @price, @date)";

                    using (SqlCommand insertLogCmd = new SqlCommand(insertLogQuery, connect))
                    {
                        string username = Form1.username.Substring(0, 1).ToUpper() + Form1.username.Substring(1).ToLower();
                        string formattedStaffName = "@" + username;

                        insertLogCmd.Parameters.AddWithValue("@actionType", "Inventory Adjustment");
                        insertLogCmd.Parameters.AddWithValue("@prodID", productID);
                        insertLogCmd.Parameters.AddWithValue("@quantityChange", quantityChange);
                        insertLogCmd.Parameters.AddWithValue("@prevStock", prevStock);
                        insertLogCmd.Parameters.AddWithValue("@newStock", newStock);
                        insertLogCmd.Parameters.AddWithValue("@staff", formattedStaffName);
                        insertLogCmd.Parameters.AddWithValue("@price", Convert.ToDouble(inventory_price.Text.Trim()));
                        insertLogCmd.Parameters.AddWithValue("@date", DateTime.Now);

                        insertLogCmd.ExecuteNonQuery();
                    }

                    clearFields();
                    DisplayAllProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed connection: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
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
            if (EmptyFields())
            {
                MessageBox.Show("Empty Fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    string selectProductQuery = "SELECT ProductID FROM Product WHERE ProductName = @prodName";
                    int productID;
                    int prevStock = 0;
                    int newStock = 0;

                    // Get the ProductID based on the ProductName
                    using (SqlCommand cmd = new SqlCommand(selectProductQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@prodName", inventory_prodname.Text.Trim());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                productID = Convert.ToInt32(reader["ProductID"]);
                            }
                            else
                            {
                                MessageBox.Show("Product not found!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // Fetch the current stock from the Inventory table
                    string getCurrentStockQuery = @"
            SELECT SUM(Stocks) 
            FROM Inventory 
            WHERE ProductID = @prodID";

                    using (SqlCommand getCurrentStockCmd = new SqlCommand(getCurrentStockQuery, connect))
                    {
                        getCurrentStockCmd.Parameters.AddWithValue("@prodID", productID);
                        object currentStockResult = getCurrentStockCmd.ExecuteScalar();
                        prevStock = currentStockResult != null ? Convert.ToInt32(currentStockResult) : 0;
                    }

                    // Fetch the quantity to remove
                    int quantityChange = string.IsNullOrEmpty(inventory_stock.Text.Trim()) ? 0 : Convert.ToInt32(inventory_stock.Text.Trim());

                    // Update the Inventory table (remove quantity)
                    string updateInventoryQuery = @"
            DELETE FROM Inventory 
            WHERE ProductID = @prodID AND Stocks = @quantityChange";

                    using (SqlCommand updateInventoryCmd = new SqlCommand(updateInventoryQuery, connect))
                    {
                        updateInventoryCmd.Parameters.AddWithValue("@prodID", productID);
                        updateInventoryCmd.Parameters.AddWithValue("@quantityChange", quantityChange);
                        updateInventoryCmd.ExecuteNonQuery();
                    }

                    // Calculate new stock after removal
                    newStock = prevStock - quantityChange;

                    // Insert into Logs table with correct stock values
                    string insertLogQuery = @"
            INSERT INTO Logs (ActionType, ProductID, QuantityChange, PrevStock, NewStock, Staff, Price, Date)
            VALUES (@actionType, @prodID, @quantityChange, @prevStock, @newStock, @staff, @price, @date)";

                    using (SqlCommand insertLogCmd = new SqlCommand(insertLogQuery, connect))
                    {
                        string username = Form1.username.Substring(0, 1).ToUpper() + Form1.username.Substring(1).ToLower();
                        string formattedStaffName = "@" + username;

                        insertLogCmd.Parameters.AddWithValue("@actionType", "Inventory Removal");
                        insertLogCmd.Parameters.AddWithValue("@prodID", productID);
                        insertLogCmd.Parameters.AddWithValue("@quantityChange", -quantityChange); // Negative for removal
                        insertLogCmd.Parameters.AddWithValue("@prevStock", prevStock);
                        insertLogCmd.Parameters.AddWithValue("@newStock", newStock);
                        insertLogCmd.Parameters.AddWithValue("@staff", formattedStaffName);
                        insertLogCmd.Parameters.AddWithValue("@price", Convert.ToDouble(inventory_price.Text.Trim()));
                        insertLogCmd.Parameters.AddWithValue("@date", DateTime.Now);

                        insertLogCmd.ExecuteNonQuery();
                    }

                    clearFields();
                    DisplayAllProducts();
                    MessageBox.Show("Inventory item removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to remove inventory: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }

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
                return;
            }

            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    string selectProductQuery = @"
                SELECT ProductID FROM Product 
                WHERE ProductName = @prodName";

                    int productID;

                    using (SqlCommand cmd = new SqlCommand(selectProductQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@prodName", inventory_prodname.Text.Trim());
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            productID = (int)result;
                        }
                        else
                        {
                            string insertProductQuery = @"
                        INSERT INTO Product (ProductName, Price)
                        OUTPUT INSERTED.ProductID
                        VALUES (@prodName, @price)";

                            using (SqlCommand insertProductCmd = new SqlCommand(insertProductQuery, connect))
                            {
                                insertProductCmd.Parameters.AddWithValue("@prodName", inventory_prodname.Text.Trim());
                                insertProductCmd.Parameters.AddWithValue("@price", inventory_price.Text.Trim());

                                productID = (int)insertProductCmd.ExecuteScalar();
                            }
                        }
                    }

                    string inventoryCheckQuery = @"
                SELECT COUNT(*) FROM Inventory 
                WHERE ProductID = @prodID";

                    using (SqlCommand checkCmd = new SqlCommand(inventoryCheckQuery, connect))
                    {
                        checkCmd.Parameters.AddWithValue("@prodID", productID);
                        int inventoryCount = (int)checkCmd.ExecuteScalar();

                        string inventoryQuery;

                        if (inventoryCount > 0)
                        {
                            inventoryQuery = @"
                        UPDATE Inventory
                        SET Price = @price, 
                            Stocks = @stocks, 
                            Amount = @amount,
                            Date = @date
                        WHERE ProductID = @prodID";
                        }
                        else
                        {
                            inventoryQuery = @"
                        INSERT INTO Inventory (ProductID, Price, Stocks, Amount, Date)
                        VALUES (@prodID, @price, @stocks, @amount, @date)";
                        }

                        using (SqlCommand inventoryCmd = new SqlCommand(inventoryQuery, connect))
                        {
                            inventoryCmd.Parameters.AddWithValue("@prodID", productID);
                            inventoryCmd.Parameters.AddWithValue("@price", inventory_price.Text.Trim());
                            inventoryCmd.Parameters.AddWithValue("@stocks", string.IsNullOrEmpty(inventory_stock.Text.Trim()) ? (object)DBNull.Value : inventory_stock.Text.Trim());
                            inventoryCmd.Parameters.AddWithValue("@amount", string.IsNullOrEmpty(inventory_am.Text.Trim()) ? (object)DBNull.Value : inventory_am.Text.Trim());
                            DateTime today = DateTime.Today;
                            inventoryCmd.Parameters.AddWithValue("@date", today);

                            inventoryCmd.ExecuteNonQuery();
                        }
                    }


                    clearFields();
                    DisplayAllProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed connection: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
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

            if (string.IsNullOrWhiteSpace(inventory_search.Text))
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
        }

        private void inventory_search_Enter(object sender, EventArgs e)
        {

            if (inventory_search.Text == "Search Product")
            {
                inventory_search.Text = "";
                inventory_search.ForeColor = Color.Black;
            }
        }


    }
}
