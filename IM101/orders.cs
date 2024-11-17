using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IM101
{
    public partial class orders : UserControl
    {
        SqlConnection
          connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public orders()
        {
            InitializeComponent();
            displayAllAvailableProducts();
            displayAllCategories();
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
            displayAllAvailableProducts();
            displayAllCategories();
            displayOrders();
            displayTotalPrice();
        }

        public void displayAllAvailableProducts()
        {
            productdata apData = new productdata();
            List<productdata> listData = apData.allAvailableProducts();

            order_Gridview1.DataSource = listData;
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
        
        public void displayAllCategories()
        {

        }

        public void displayOrders()
        {
            ordersdata oData = new ordersdata();
            List<ordersdata> listData = oData.allOrdersData();

            dataGridView1.DataSource = listData;

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

        public void clearFields()
        {
            order_Remstock.Text = "";
            enterprodID.Text = "";
            order_prodName.Text = "";
            order_Totalprice.Text = "";
            enterQty.Text = "";
            dataGridView1.DataSource = null;
            totalPrice = 0;
        }

        public void clearFields1()
        {
            order_Remstock.Text = "";
            enterprodID.Text = "";
            order_prodName.Text = "";
            enterQty.Text = "";
            order_price.Text = "";
        }

        private void order_addbtn_Click(object sender, EventArgs e)
        {
            IDGenerator();

            if (string.IsNullOrEmpty(enterQty.Text) || string.IsNullOrEmpty(enterprodID.Text))
            {
                Console.WriteLine("Select item first");
            }
            else
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();

                        int availableStock = 0;
                        string prodName = "";
                        string category = "";
                        string unit = "";
                        float price = 0;
                        int productID = int.Parse(enterprodID.Text.Trim());

                        // Query product details
                        string selectData = @"
                                    SELECT p.ProductName, p.Price, p.Category, i.Stocks, i.Amount
                                    FROM Product p
                                    JOIN Inventory i ON p.ProductID = i.ProductID
                                    WHERE p.ProductID = @prodID AND p.Status = @status";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@prodID", productID);
                            cmd.Parameters.AddWithValue("@status", "Available");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    prodName = reader["ProductName"].ToString();
                                    price = Convert.ToSingle(reader["Price"]);
                                    category = reader["Category"].ToString();
                                    unit = reader["Amount"].ToString();
                                    availableStock = Convert.ToInt32(reader["Stocks"]);
                                }
                            }
                        }

                        int quantity = int.TryParse(enterQty.Text, out int qty) ? qty : 0;

                        if (quantity > availableStock)
                        {
                            MessageBox.Show("Order quantity exceeds available stock.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            float subtotal = price * quantity;
                            DateTime today = DateTime.Today;

                            // Insert data into Purchase table
                            string insertData = @"INSERT INTO Purchase (CustomerID, ProductID, ProductName, Category, Quantity, Unit, OriginalPrice, Subtotal, OrderDate) 
                          VALUES (@catID, @prodID, @prodName, @category, @qty, @unit, @price, @subtotal, @orderDate)";

                            using (SqlCommand insertCmd = new SqlCommand(insertData, connect))
                            {
                                insertCmd.Parameters.AddWithValue("@catID", idGen);
                                insertCmd.Parameters.AddWithValue("@prodID", productID);
                                insertCmd.Parameters.AddWithValue("@prodName", prodName);
                                insertCmd.Parameters.AddWithValue("@category", category);
                                insertCmd.Parameters.AddWithValue("@qty", quantity);
                                insertCmd.Parameters.AddWithValue("@unit", unit);
                                insertCmd.Parameters.AddWithValue("@price", price);
                                insertCmd.Parameters.AddWithValue("@subtotal", subtotal);
                                insertCmd.Parameters.AddWithValue("@orderDate", today);

                                insertCmd.ExecuteNonQuery();
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

                displayOrders();
                displayTotalPrice();
            }
        }
        private int purchaseID = 0;

        private void order_removebtn_Click(object sender, EventArgs e)
        {
            if (purchaseID == 0)
            {
                MessageBox.Show("Select an item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to remove ID: " + purchaseID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();

                        string fetchDataQuery = "SELECT ProductID, Quantity FROM Purchase WHERE PurchaseID = @pID";
                        string productID = string.Empty;
                        int qtyToRemove = 0;

                        using (SqlCommand fetchDataCmd = new SqlCommand(fetchDataQuery, connect))
                        {
                            fetchDataCmd.Parameters.AddWithValue("@pID", purchaseID);
                            using (SqlDataReader reader = fetchDataCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    productID = reader["ProductID"].ToString();
                                    qtyToRemove = Convert.ToInt32(reader["Quantity"]);
                                }
                                else
                                {
                                    MessageBox.Show("No data found for the specified Purchase ID.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }

                        string deleteData = "DELETE FROM Purchase WHERE PurchaseID = @pID";

                        using (SqlCommand deleteCmd = new SqlCommand(deleteData, connect))
                        {
                            deleteCmd.Parameters.AddWithValue("@pID", purchaseID);
                            deleteCmd.ExecuteNonQuery();
                        }

                        string updateStockQuery = "UPDATE Inventory SET Stocks = Stocks + @qty WHERE ProductID = @prodID";

                        using (SqlCommand updateCmd = new SqlCommand(updateStockQuery, connect))
                        {
                            updateCmd.Parameters.AddWithValue("@qty", qtyToRemove);
                            updateCmd.Parameters.AddWithValue("@prodID", productID);
                            updateCmd.ExecuteNonQuery();
                        }

                        displayOrders();
                        displayTotalPrice();
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
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clearFields();
            dataGridView1.ReadOnly = true;
        }

        private void order_clearbtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                purchaseID = Convert.ToInt32(row.Cells["PurchaseID"].Value);
            }
        }

        private void order_Gridview1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            order_Gridview1.ReadOnly = true;
        }

        private void order_Gridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void orders_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Search Product";
            textBox1.ForeColor = Color.Gray;

            displayAllAvailableProducts();
            displayOrders();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            productdata proddata = new productdata();
            List<productdata> filteredData;

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                filteredData = proddata.allAvailableProducts();
            }
            else
            {
                filteredData = proddata.SearchProducts(textBox1.Text.Trim());
            }

            order_Gridview1.DataSource = filteredData;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Search Product";
                textBox1.ForeColor = Color.Gray;
            }   
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search Product")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void enterprodID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string enteredValue = enterprodID.Text.Trim();

                if (checkConnection())
                {
                    if (!string.IsNullOrEmpty(enteredValue))
                    {
                        try
                        {
                            connect.Open();

                            // Query to get product details and available stock (without updating)
                            string selectData = @"
                    SELECT p.ProductName, p.Price, i.InventoryID, i.Stocks 
                    FROM Product p 
                    JOIN Inventory i ON p.ProductID = i.ProductID 
                    WHERE p.ProductID = @enteredValue AND p.Status = @status
                    ORDER BY i.InventoryID ASC"; // Ensures the stocks are processed in ascending order of InventoryID

                            using (SqlCommand cmd = new SqlCommand(selectData, connect))
                            {
                                cmd.Parameters.AddWithValue("@enteredValue", enteredValue);
                                cmd.Parameters.AddWithValue("@status", "Available");

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        string prodName = "";
                                        float prodPrice = 0;
                                        int totalStock = 0;

                                        // Loop through the rows, fetching product details and stock information
                                        while (reader.Read())
                                        {
                                            if (prodName == "") // Fetch product details only once
                                            {
                                                prodName = reader["ProductName"].ToString();
                                                prodPrice = Convert.ToSingle(reader["Price"]);
                                            }

                                            // Accumulate the total stock from all inventory rows
                                            totalStock += Convert.ToInt32(reader["Stocks"]);
                                        }

                                        // Now that we have all product and inventory data, display the information
                                        order_prodName.Text = prodName;
                                        order_price.Text = prodPrice.ToString("0.00");
                                        order_Remstock.Text = totalStock.ToString(); // Show total stock available
                                    }
                                    else
                                    {
                                        MessageBox.Show("Product not found or unavailable.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
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
                    else
                    {
                        MessageBox.Show("Please enter a Product ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                e.SuppressKeyPress = true; 
            }

        }

        private void enterQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                IDGenerator(); // Ensure ID is generated

                if (string.IsNullOrEmpty(enterQty.Text) || string.IsNullOrEmpty(enterprodID.Text))
                {
                    Console.WriteLine("Select item first");
                    return;
                }

                if (!checkConnection()) return;

                try
                {
                    connect.Open();

                    // Query to fetch product info
                    string query = @"
                SELECT p.ProductName, p.Price, p.Category, i.InventoryID, i.Stocks, i.Amount, i.Date, l.NewStock
                FROM Product p
                JOIN Inventory i ON p.ProductID = i.ProductID
                LEFT JOIN Logs l ON p.ProductID = l.ProductID
                WHERE p.ProductID = @prodID AND p.Status = @status
                ORDER BY i.Date ASC";

                    using (var cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@prodID", enterprodID.Text.Trim());
                        cmd.Parameters.AddWithValue("@status", "Available");

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string prodName = reader["ProductName"].ToString();
                                string category = reader["Category"].ToString();
                                string unit = reader["Amount"].ToString();
                                float price = Convert.ToSingle(reader["Price"]);
                                int availableStock = Convert.ToInt32(reader["NewStock"] ?? reader["NewStock"]);

                                int qty = int.TryParse(enterQty.Text, out int quantity) ? quantity : 0;

                                if (quantity > availableStock)
                                {
                                    MessageBox.Show("Order quantity exceeds available stock.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Insert purchase
                                string insertPurchase = @"
                            INSERT INTO Purchase (CustomerID, ProductID, ProductName, Category, Quantity, Unit, OriginalPrice, Subtotal, OrderDate)
                            VALUES (@catID, @prodID, @prodName, @category, @qty, @unit, @price, @subtotal, @orderDate)";

                                using (var insertCmd = new SqlCommand(insertPurchase, connect))
                                {
                                    insertCmd.Parameters.AddWithValue("@catID", idGen);
                                    insertCmd.Parameters.AddWithValue("@prodID", enterprodID.Text.Trim());
                                    insertCmd.Parameters.AddWithValue("@prodName", prodName);
                                    insertCmd.Parameters.AddWithValue("@category", category);
                                    insertCmd.Parameters.AddWithValue("@qty", quantity);
                                    insertCmd.Parameters.AddWithValue("@unit", unit);
                                    insertCmd.Parameters.AddWithValue("@price", price);
                                    insertCmd.Parameters.AddWithValue("@subtotal", price * quantity);
                                    insertCmd.Parameters.AddWithValue("@orderDate", DateTime.Today);
                                    insertCmd.ExecuteNonQuery();
                                }

                                // Update stock in the inventory
                                string updateStock = @"
                            UPDATE Logs 
                            SET NewStock = NewStock - @qty 
                            WHERE LogID = (SELECT TOP 1 LogID FROM Logs WHERE ProductID = @prodID ORDER BY Date ASC)";

                                using (var updateCmd = new SqlCommand(updateStock, connect))
                                {
                                    updateCmd.Parameters.AddWithValue("@qty", quantity);
                                    updateCmd.Parameters.AddWithValue("@prodID", enterprodID.Text.Trim());
                                    updateCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }

                displayOrders(); // Refresh order display
                displayTotalPrice(); // Update total price display
            }


        }

        private void enterprodID_TextChanged(object sender, EventArgs e)
        {

        }

        private void order_Remstock_Click(object sender, EventArgs e)
        {

        }
    }
}
