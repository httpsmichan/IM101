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

                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }


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


                string status = supply_status.SelectedItem == null ? "Order Placed" : supply_status.SelectedItem.ToString();


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
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@Date", DateTime.Today);

                    command.ExecuteNonQuery(); 
                }


                if (status == "Received")
                {

                    InsertLogEntry(connect, supply_prodID.Text, supply_qtys.Text, "Supply Received");

                    InsertInventory(connect, supply_prodID.Text, productName, unitCost, supply_qtys.Text);

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

        private void InsertInventory(SqlConnection connection, string productID, string productName, double unitCost, string quantitySupplied)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }


                string checkInventoryQuery = "SELECT COUNT(1) FROM Inventory WHERE ProductID = @ProductID";

                int inventoryExists;
                using (SqlCommand checkCommand = new SqlCommand(checkInventoryQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@ProductID", productID);
                    inventoryExists = (int)checkCommand.ExecuteScalar();
                }

                if (inventoryExists > 0)
                {

                    string updateInventoryQuery = @"
                UPDATE Inventory
                SET Stocks = Stocks + @QuantitySupplied, Price = @Price, Date = @Date
                WHERE ProductID = @ProductID";

                    using (SqlCommand updateCommand = new SqlCommand(updateInventoryQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@ProductID", productID);
                        updateCommand.Parameters.AddWithValue("@QuantitySupplied", Convert.ToInt32(quantitySupplied));
                        updateCommand.Parameters.AddWithValue("@Price", unitCost);
                        updateCommand.Parameters.AddWithValue("@Date", DateTime.Today);

                        updateCommand.ExecuteNonQuery();
                    }

                    Console.WriteLine("Inventory updated successfully!");
                }
                else
                {
                    string insertInventoryQuery = @"
                INSERT INTO Inventory (ProductID, ProductName, Price, Stocks, Amount, Date)
                VALUES (@ProductID, @ProductName, @Price, @Stocks, @Amount, @Date)";

                    using (SqlCommand insertCommand = new SqlCommand(insertInventoryQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@ProductID", productID);
                        insertCommand.Parameters.AddWithValue("@ProductName", productName);
                        insertCommand.Parameters.AddWithValue("@Price", unitCost);
                        insertCommand.Parameters.AddWithValue("@Stocks", Convert.ToInt32(quantitySupplied));
                        insertCommand.Parameters.AddWithValue("@Amount", "pcs");
                        insertCommand.Parameters.AddWithValue("@Date", DateTime.Today);

                        insertCommand.ExecuteNonQuery();
                    }

                    Console.WriteLine("Inventory inserted successfully!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting/updating inventory: " + ex.Message);
            }
        }


        private void InsertLogEntry(SqlConnection connection, string productID, string quantitySupplied, string actionType)
        {
            try
            {

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }


                int prevStock = GetCurrentStock(connection, Convert.ToInt32(productID));


                int newStock = prevStock + Convert.ToInt32(quantitySupplied);


                string getSupplyIDQuery = @"
            SELECT TOP 1 SupplyID 
            FROM Supply 
            WHERE ProductID = @ProductID 
            ORDER BY SupplyID DESC"; 

                int supplyID = 0;
                using (var getSupplyIDCmd = new SqlCommand(getSupplyIDQuery, connection))
                {
                    getSupplyIDCmd.Parameters.AddWithValue("@ProductID", productID);
                    object result = getSupplyIDCmd.ExecuteScalar();
                    if (result != null)
                    {
                        supplyID = Convert.ToInt32(result); 
                    }
                }


                string insertLogQuery = @"
            INSERT INTO Logs (ActionType, ProductID, QuantityChange, PrevStock, NewStock, Staff, Date, IDs) 
            VALUES (@actionType, @prodID, @quantityChange, @prevStock, @newStock, @staff, @date, @ids)";

                using (var cmdLog = new SqlCommand(insertLogQuery, connection))
                {
                    string username = Form1.username?.Substring(0, 1).ToUpper() + Form1.username?.Substring(1).ToLower();
                    if (string.IsNullOrWhiteSpace(username))
                    {
                        throw new InvalidOperationException("Username is not set. Please ensure the user is logged in.");
                    }


                    cmdLog.Parameters.Add(new SqlParameter("@actionType", SqlDbType.NVarChar, 50) { Value = actionType });
                    cmdLog.Parameters.Add(new SqlParameter("@prodID", SqlDbType.Int) { Value = Convert.ToInt32(productID) });
                    cmdLog.Parameters.Add(new SqlParameter("@quantityChange", SqlDbType.Int) { Value = Convert.ToInt32(quantitySupplied) });
                    cmdLog.Parameters.Add(new SqlParameter("@prevStock", SqlDbType.Int) { Value = prevStock });
                    cmdLog.Parameters.Add(new SqlParameter("@newStock", SqlDbType.Int) { Value = newStock });
                    cmdLog.Parameters.Add(new SqlParameter("@staff", SqlDbType.NVarChar, 50) { Value = "@" + username });
                    cmdLog.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime) { Value = DateTime.Now });
                    cmdLog.Parameters.Add(new SqlParameter("@ids", SqlDbType.NVarChar, 100) { Value = "SupplyID: " + supplyID });


                    int rowsAffected = cmdLog.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("No row was inserted into Logs.");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error inserting log: {ex.Message}\n{ex.StackTrace}");
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
           
        }
        private void remove_removebtn_Click(object sender, EventArgs e)
        {

            if (supply_grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }


            var selectedRow = supply_grid.SelectedRows[0];
            int supplyID = Convert.ToInt32(selectedRow.Cells["SupplyID"].Value);


            DialogResult confirmation = MessageBox.Show(
                "Are you sure you want to delete the selected Supply record?",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question );


            if (confirmation == DialogResult.No)
            {
                return;
            }

            string checkSupplyQuery = "SELECT COUNT(1) FROM Supply WHERE SupplyID = @SupplyID";
            string deleteQuery = "DELETE FROM Supply WHERE SupplyID = @SupplyID";

            try
            {

                if (checkConnection())
                {
                    connect.Open();
                }


                using (SqlCommand checkCommand = new SqlCommand(checkSupplyQuery, connect))
                {
                    checkCommand.Parameters.AddWithValue("@SupplyID", supplyID);

                    int supplyExists = (int)checkCommand.ExecuteScalar();
                    if (supplyExists == 0)
                    {
                        MessageBox.Show("The SupplyID does not exist in the Supply table.");
                        return;
                    }
                }


                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connect))
                {
                    deleteCommand.Parameters.AddWithValue("@SupplyID", supplyID);
                    deleteCommand.ExecuteNonQuery();
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
