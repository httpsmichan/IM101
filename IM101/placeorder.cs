using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IM101
{
    public partial class placeorder : UserControl
    {
        SqlConnection
          connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public placeorder()
        {
            InitializeComponent();
            displayOrders();
            displayTotalPrice();
        }

        private int prodID = 0;
        private int idGen;
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayOrders();
            displayTotalPrice();
        }

        public bool checkConnection()
        {
            if (connect.State == ConnectionState.Closed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void displayOrders()
        {
            placeorderdata pData = new placeorderdata();
            List<placeorderdata> listData = pData.GetBillingDataGB();

            grid_placeorder.DataSource = listData;
        }

        public void IDGenerator()
        {
            using (SqlConnection
          connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                connect.Open();

                string selectData = "SELECT MAX(CustomerID) FROM Billing";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        int temp = Convert.ToInt32(result);
                        idGen = temp + 1;
                    }
                    else
                    {
                        idGen = 1;
                    }
                }
            }
        }

        private float totalPrice = 0;
        public void displayTotalPrice()
        {

            IDGenerator();

            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT SUM (Subtotal) FROM Purchase WHERE CustomerID = @catID";

                    using (SqlCommand cmd = new SqlCommand(@selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("catID", idGen);

                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            totalPrice = Convert.ToSingle(result);

                            order_Totalprice.Text = totalPrice.ToString("0.00");
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }


        private void grid_placeorder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = grid_placeorder.Rows[e.RowIndex];

                prodID = (int)row.Cells[0].Value;

            }
        }
        public void clearFields()
        {
            grid_placeorder.DataSource = null;
            order_Cashamount.Text = "";
            order_Change.Text = "";
            totalPrice = 0;
            order_Cashamount.Text = "";
            order_Change.Text = "";
            order_Totalprice.Text = "";
        }

        private void order_placeorderbtn_Click(object sender, EventArgs e)
        {
            IDGenerator();

            if (string.IsNullOrEmpty(order_Cashamount.Text) || grid_placeorder.Rows.Count == 0)
            {
                MessageBox.Show("Something went wrong", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure to pay your orders?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string connectionString = "Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
                DateTime today = DateTime.Today;

                try
                {
                    using (var localConnect = new SqlConnection(connectionString))
                    {
                        localConnect.Open();


                        int billNo = InsertBillingAndPayment(localConnect, today);


                        var productAggregates = AggregateProducts();
                        InsertLogsAndUpdateInventory(localConnect, productAggregates, today, billNo);


                        MessageBox.Show("Order placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int InsertBillingAndPayment(SqlConnection connection, DateTime today)
        {
            int billNo;
            decimal totalPrice = Convert.ToDecimal(order_Totalprice.Text);
            decimal amountPaid = Convert.ToDecimal(order_Cashamount.Text);
            decimal change = Convert.ToDecimal(order_Change.Text);

            try
            {
                using (var cmd = new SqlCommand("InsertBillingAndPaymentFromPurchase", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", idGen); 
                    cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
                    cmd.Parameters.AddWithValue("@AmountPaid", amountPaid);
                    cmd.Parameters.AddWithValue("@Change", change);

                    billNo = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing the billing and payment: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; 
            }

            return billNo;
        }

        private Dictionary<int, int> AggregateProducts()
        {
            var productAggregates = new Dictionary<int, int>();
            foreach (DataGridViewRow row in grid_placeorder.Rows)
            {
                if (row.Cells["ProductID"]?.Value != null && row.Cells["Quantity"]?.Value != null)
                {
                    int productID = Convert.ToInt32(row.Cells["ProductID"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                    if (productAggregates.ContainsKey(productID))
                        productAggregates[productID] += quantity;
                    else
                        productAggregates[productID] = quantity;
                }
            }
            return productAggregates;
        }



        private void InsertLogsAndUpdateInventory(SqlConnection connection, Dictionary<int, int> productAggregates, DateTime today, int billNo)
        {

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            foreach (var entry in productAggregates)
            {
                int productID = entry.Key;
                int totalQuantityChange = entry.Value;

                int prevStock = GetCurrentStock(connection, productID);
                int newStock = prevStock - totalQuantityChange;
                int pstock = RecentStock(connection, productID);

                int relatedInventoryID = GetRelatedInventoryID(connection, productID);

                InsertLog(connection, "Order Purchase", productID, -totalQuantityChange, prevStock, newStock, today, relatedInventoryID);

                if (newStock == 0)
                {
                    HandleStockAtCapacity(connection, productID, pstock, today, relatedInventoryID);
                }

                UpdateInventory(connection, productID, totalQuantityChange);
            }

            DeletePurchaseByCustomerID(connection, billNo);

            connection.Close();
        }

        private void InsertLog(SqlConnection connection, string actionType, int productID, int quantityChange, int prevStock, int newStock, DateTime date, int relatedInventoryID)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            int pStock = GetCurrentStock(connection, productID); 
            int nStock = pStock; 

            string username = Form1.username.Substring(0, 1).ToUpper() + Form1.username.Substring(1).ToLower();

            string insertLogQuery = @"
        INSERT INTO Logs (ActionType, ProductID, QuantityChange, PrevStock, NewStock, Staff, Date, IDs) 
        VALUES (@actionType, @prodID, @quantityChange, @prevStock, @newStock, @staff, @date, @ids)";

            using (var cmdLog = new SqlCommand(insertLogQuery, connection))
            {
                cmdLog.Parameters.AddWithValue("@actionType", actionType);
                cmdLog.Parameters.AddWithValue("@prodID", productID);
                cmdLog.Parameters.AddWithValue("@quantityChange", quantityChange);
                cmdLog.Parameters.AddWithValue("@prevStock", prevStock);
                cmdLog.Parameters.AddWithValue("@newStock", newStock); 
                cmdLog.Parameters.AddWithValue("@staff", "@" + username);  
                cmdLog.Parameters.AddWithValue("@date", date);
                cmdLog.Parameters.AddWithValue("@ids", "InventoryID: " + relatedInventoryID);

                cmdLog.ExecuteNonQuery();
            }
        }


        private void HandleStockAtCapacity(SqlConnection connection, int productID, int pstock, DateTime today, int relatedInventoryID)
        {
            InsertLog(connection, "Stock at Capacity", productID, 0, pstock, pstock, today, relatedInventoryID);

            string updateInventoryQuery = @"
    UPDATE Inventory 
    SET Stocks = 0 
    WHERE InventoryID = @InventoryID";

            using (var cmdUpdateInventory = new SqlCommand(updateInventoryQuery, connection))
            {
                cmdUpdateInventory.Parameters.AddWithValue("@InventoryID", relatedInventoryID);
                cmdUpdateInventory.ExecuteNonQuery();
            }

            string checkStockQuery = @"
    SELECT Stocks FROM Inventory 
    WHERE InventoryID = @InventoryID";

            int currentStock = 0;
            using (var cmdCheckStock = new SqlCommand(checkStockQuery, connection))
            {
                cmdCheckStock.Parameters.AddWithValue("@InventoryID", relatedInventoryID);
                var result = cmdCheckStock.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    currentStock = Convert.ToInt32(result);
                }
            }

            if (currentStock == 0)
            {
                string deleteInventoryQuery = @"
        DELETE FROM Inventory
        WHERE InventoryID = @InventoryID AND Stocks = 0"; 

                using (var cmdDeleteInventory = new SqlCommand(deleteInventoryQuery, connection))
                {
                    cmdDeleteInventory.Parameters.AddWithValue("@InventoryID", relatedInventoryID);
                    cmdDeleteInventory.ExecuteNonQuery();
                }
            }
        }

        private int DeleteAllPurchases(SqlConnection connection)
        {
            int rowsAffected = 0;

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string deleteQuery = "DELETE FROM Purchase";

                using (var cmdDelete = new SqlCommand(deleteQuery, connection))
                {
                    rowsAffected = cmdDelete.ExecuteNonQuery();
                }

                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting all purchases: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0; 
            }
        }


        private int GetRelatedInventoryID(SqlConnection connection, int productID)
        {
            using (var getSupplyIDCmd = new SqlCommand(@"
        SELECT InventoryID 
        FROM Inventory 
        WHERE ProductID = @ProductID AND Stocks > 0 
        ORDER BY InventoryID ASC", connection))
            {
                getSupplyIDCmd.Parameters.AddWithValue("@ProductID", productID);
                object result = getSupplyIDCmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private void DeletePurchaseByCustomerID(SqlConnection connection, int customerID)
        {
            using (var cmdDelete = new SqlCommand("DELETE FROM Purchase WHERE CustomerID = @cID", connection))
            {
                cmdDelete.Parameters.AddWithValue("@cID", customerID);
                cmdDelete.ExecuteNonQuery();
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

        private int RecentStock(SqlConnection connection, int productID)
        {
            string query = "SELECT SUM(Stocks) FROM Inventory WHERE ProductID = @prodID GROUP BY ProductID";
            using (var cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@prodID", productID);
                var result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }



        private void UpdateInventory(SqlConnection connection, int productID, int totalQuantityChange)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            string inventoryQuery = @"
    SELECT InventoryID, Stocks FROM Inventory
    WHERE ProductID = @prodID AND Stocks > 0
    ORDER BY InventoryID ASC";  

            using (var cmdFetchInventory = new SqlCommand(inventoryQuery, connection))
            {
                cmdFetchInventory.Parameters.AddWithValue("@prodID", productID);

                using (var inventoryReader = cmdFetchInventory.ExecuteReader())
                {
                    int remainingQuantity = totalQuantityChange;
                    bool insufficientStock = false;

                    while (inventoryReader.Read() && remainingQuantity > 0)
                    {
                        int inventoryID = Convert.ToInt32(inventoryReader["InventoryID"]);
                        int currentStock = Convert.ToInt32(inventoryReader["Stocks"]);

                        if (currentStock >= remainingQuantity)
                        {
                            string updateQuery = "UPDATE Inventory SET Stocks = Stocks - @deductQty WHERE InventoryID = @inventoryID";
                            using (var cmdUpdate = new SqlCommand(updateQuery, connection))
                            {
                                cmdUpdate.Parameters.AddWithValue("@deductQty", remainingQuantity);
                                cmdUpdate.Parameters.AddWithValue("@inventoryID", inventoryID);
                                cmdUpdate.ExecuteNonQuery();
                            }
                            remainingQuantity = 0;  
                        }
                        else
                        {
                            string updateQuery = "UPDATE Inventory SET Stocks = 0 WHERE InventoryID = @inventoryID";
                            using (var cmdUpdate = new SqlCommand(updateQuery, connection))
                            {
                                cmdUpdate.Parameters.AddWithValue("@inventoryID", inventoryID);
                                cmdUpdate.ExecuteNonQuery();
                            }
                            remainingQuantity -= currentStock;  
                        }

                        string checkStockQuery = "SELECT Stocks FROM Inventory WHERE InventoryID = @inventoryID";
                        int updatedStock = 0;
                        using (var cmdCheckStock = new SqlCommand(checkStockQuery, connection))
                        {
                            cmdCheckStock.Parameters.AddWithValue("@inventoryID", inventoryID);
                            var result = cmdCheckStock.ExecuteScalar();
                            if (result != DBNull.Value)
                            {
                                updatedStock = Convert.ToInt32(result);
                            }
                        }

                        if (updatedStock == 0)
                        {
                            InsertLog(connection, "Stock at Capacity", productID, 0, currentStock, 0, DateTime.Now, inventoryID);

                            string deleteQuery = "DELETE FROM Inventory WHERE InventoryID = @inventoryID";
                            using (var cmdDelete = new SqlCommand(deleteQuery, connection))
                            {
                                cmdDelete.Parameters.AddWithValue("@inventoryID", inventoryID);
                                cmdDelete.ExecuteNonQuery();
                            }
                        }
                    }

                    if (remainingQuantity > 0)
                    {
                        insufficientStock = true;
                    }

                    if (insufficientStock)
                    {
                        MessageBox.Show("Not enough stock available to fulfill the order.", "Stock Insufficient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }

       


        private void order_Cashamount_TextChanged(object sender, EventArgs e)
        {
        }
        private int rowIndex = 0;

        private void order_Printreceipt_Click(object sender, EventArgs e)
        {
            if (order_Cashamount.Text == "" || grid_placeorder.Rows.Count <= 0)
            {
                MessageBox.Show("Please order first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                printDocument1.BeginPrint += new PrintEventHandler(printDocument1_BeginPrint);

                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();

                if (checkConnection())
                {
                    try
                    {
                        connect.Open();

                        int rowsDeleted = DeleteAllPurchases(connect); 

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection failed: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }

                clearFields();
            }
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            rowIndex = 0;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            displayTotalPrice(); 

            float y = 0;
            int count = 0;
            int colWidth = 100;
            int headerMargin = 8;
            int tableMargin = 5;

            Font font = new Font("Arial", 7);
            Font bold = new Font("Arial", 7, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font labelFont = new Font("Arial", 7, FontStyle.Bold);

            float margin = e.MarginBounds.Top;

            StringFormat alignCenter = new StringFormat();
            alignCenter.Alignment = StringAlignment.Center;
            alignCenter.LineAlignment = StringAlignment.Center;

            string headerText = "Funtilon Hardware and Construction Supplies\r\n";
            y = margin + count * headerFont.GetHeight(e.Graphics) + headerMargin;
            e.Graphics.DrawString(headerText, headerFont, Brushes.Black, e.MarginBounds.Left + (grid_placeorder.Columns.Count / 2) * colWidth, y, alignCenter);

            count++;
            y += tableMargin;

            string[] header = { "ProductID", "ProductName", "Price", "Quantity", "Unit", "Total", "OrderDate" };
            for (int q = 0; q < header.Length; q++)
            {
                y = margin + count * bold.GetHeight(e.Graphics) + headerMargin;
                e.Graphics.DrawString(header[q], bold, Brushes.Black, e.MarginBounds.Left + q * colWidth, y, alignCenter);
            }

            count++;

            float rSpace = e.MarginBounds.Bottom - y;
            while (rowIndex < grid_placeorder.Rows.Count)
            {
                DataGridViewRow row = grid_placeorder.Rows[rowIndex];

                for (int q = 0; q < grid_placeorder.Columns.Count; q++)
                {
                    object cellValue = row.Cells[q].Value;
                    string cell = (cellValue != null) ? cellValue.ToString() : string.Empty;

                    y = margin + count * font.GetHeight(e.Graphics) + tableMargin;
                    e.Graphics.DrawString(cell, font, Brushes.Black, e.MarginBounds.Left + q * colWidth, y, alignCenter);
                }

                count++;
                rowIndex++;

                if (y + font.GetHeight(e.Graphics) > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            int labelMargin = (int)Math.Min(rSpace, 200);

            DateTime today = DateTime.Today;
            float labelX = e.MarginBounds.Right - e.Graphics.MeasureString("--------------------------", labelFont).Width;

            y = e.MarginBounds.Bottom - labelMargin - labelFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("Total Price: \t₱" + totalPrice.ToString("0.00") + "\nAmount: \t₱" + order_Cashamount.Text.Trim()
                + "\n\t\t-------------------\nChange: \t₱" + order_Change.Text.Trim(), labelFont, Brushes.Black, labelX, y);

            labelMargin = (int)Math.Min(rSpace, -40);

            string labelText = today.ToString();
            y = e.MarginBounds.Bottom - labelMargin - labelFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(labelText, labelFont, Brushes.Black, e.MarginBounds.Right - e.Graphics.MeasureString("-------------------", labelFont).Width, y);
        }

        private void grid_placeorder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            grid_placeorder.ReadOnly = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedPaymentMethod = comboBox1.SelectedItem.ToString();

                panel_cash.Visible = false;
                panel_Gcash.Visible = false;
                panel_bank.Visible = false;

                if (selectedPaymentMethod == "Cash")
                {
                    panel_cash.Visible = true;

                    order_Cashamount.Text = "";
                    order_Change.Text = "";
                }
                else if (selectedPaymentMethod == "Gcash" || selectedPaymentMethod == "Bank Transfer")
                {
                    panel_Gcash.Visible = selectedPaymentMethod == "Gcash";
                    panel_bank.Visible = selectedPaymentMethod == "Bank Transfer";

                    order_Cashamount.Text = order_Totalprice.Text;
                    order_Change.Text = "0";
                }
            }
        }

        private void placeorder_Load(object sender, EventArgs e)
        {
            panel_cash.Visible = false;
            panel_Gcash.Visible = false;
            panel_bank.Visible = false;

            displayOrders();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void order_Cashamount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    float getAmount = Convert.ToSingle(order_Cashamount.Text);
                    float getChange = (getAmount - totalPrice);

                    if (getChange <= -1)
                    {
                        order_Cashamount.Text = "";
                        order_Change.Text = "";
                    }
                    else
                    {
                        order_Change.Text = getChange.ToString("0.00");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    order_Cashamount.Text = "";
                    order_Change.Text = "";
                }
            }
        }
    }
}
