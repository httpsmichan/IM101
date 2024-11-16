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
    public partial class products : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        private int getID = 0;
        public products()
        {
            InitializeComponent();
            displayCategories();
            displayAllProducts();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayCategories();
            displayAllProducts();
        }

        public bool emptyFields()
        {
            if (addprod_name.Text == "" || addprod_category.SelectedIndex == -1
                || addprod_price.Text == "" || addprod_status.SelectedIndex == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void displayCategories()
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    addprod_category.Items.Clear();

                    string selectData = "SELECT DISTINCT Category FROM Category";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                addprod_category.Items.Add(reader["Category"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message);
                }
                finally
                {
                    connect.Close();
                }
            }
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

        public void displayAllProducts()
        {
            productdata apData = new productdata();
            List<productdata> listData = apData.AllProductsData();
            if (listData.Count > 0)
            {
                addprod_dataGrid.DataSource = listData;
            }
            else
            {
                MessageBox.Show("No data to display.");
            }
        }


        public void clearFields()
        {
            addprod_name.Text = "";
            addprod_category.SelectedIndex = -1;
            addprod_price.Text = "";
            addprod_status.SelectedIndex = -1;
        }

        private void products_Load(object sender, EventArgs e)
        {
            product_search.Text = "Search Product";
            product_search.ForeColor = Color.Gray;

            displayAllProducts();
        }

        private void addprod_updatebtn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Empty Fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Update Product ID: " +
                    getID.ToString() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();

                            string updateData = "UPDATE Product SET ProductName = @prodname, Category = @cat, " +
                                "Price = @price, Status = @status, Date = @date WHERE ProductID = @prodID";

                            using (SqlCommand updateD = new SqlCommand(updateData, connect))
                            {
                                // Assign ProductName
                                updateD.Parameters.AddWithValue("@prodName", addprod_name.Text.Trim());

                                // Assign Category (use DBNull.Value if null)
                                if (addprod_category.SelectedItem != null)
                                    updateD.Parameters.AddWithValue("@cat", addprod_category.SelectedItem.ToString());
                                else
                                    updateD.Parameters.AddWithValue("@cat", DBNull.Value);

                                // Assign Price
                                updateD.Parameters.AddWithValue("@price", addprod_price.Text.Trim());

                                // Assign Status (use DBNull.Value if null)
                                if (addprod_status.SelectedItem != null)
                                    updateD.Parameters.AddWithValue("@status", addprod_status.SelectedItem.ToString());
                                else
                                    updateD.Parameters.AddWithValue("@status", DBNull.Value);

                                // Assign Date
                                DateTime today = DateTime.Today;
                                updateD.Parameters.AddWithValue("@date", today);

                                // Assign ProductID (ensure `getID` has the correct product ID value)
                                updateD.Parameters.AddWithValue("@prodID", getID);

                                // Execute the query
                                updateD.ExecuteNonQuery();

                                // Clear fields and refresh product list
                                clearFields();
                                displayAllProducts();
                            }
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
            }
        }

        private void addprod_addbtn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Empty Fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();

                        string selectProductQuery = "SELECT ProductID FROM Product WHERE ProductName = @prodName";

                        using (SqlCommand cmd = new SqlCommand(selectProductQuery, connect))
                        {
                            cmd.Parameters.AddWithValue("@prodName", addprod_name.Text.Trim());
                            object result = cmd.ExecuteScalar();

                            if (result != null)
                            {

                                MessageBox.Show("Product already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertProductQuery = @"
                            INSERT INTO Product (ProductName, Category, Price, Status, Date)
                            VALUES (@prodName, @cat, @price, @status, @date);
                            SELECT SCOPE_IDENTITY();";

                                int newProductId;
                                using (SqlCommand insertProductCmd = new SqlCommand(insertProductQuery, connect))
                                {
                                    insertProductCmd.Parameters.AddWithValue("@prodName", addprod_name.Text.Trim());
                                    insertProductCmd.Parameters.AddWithValue("@cat", addprod_category.SelectedItem);
                                    insertProductCmd.Parameters.AddWithValue("@price", addprod_price.Text.Trim());
                                    insertProductCmd.Parameters.AddWithValue("@status", addprod_status.SelectedItem);
                                    insertProductCmd.Parameters.AddWithValue("@date", DateTime.Today);

                                    newProductId = Convert.ToInt32(insertProductCmd.ExecuteScalar());

                                }

                                string insertInventoryQuery = @"
                            INSERT INTO Inventory (ProductID, Price, Date)
                            VALUES (@prodID, @price, @date)";

                                using (SqlCommand insertInventoryCmd = new SqlCommand(insertInventoryQuery, connect))
                                {
                                    insertInventoryCmd.Parameters.AddWithValue("@prodID", newProductId);
                                    insertInventoryCmd.Parameters.AddWithValue("@price", addprod_price.Text.Trim());
                                    insertInventoryCmd.Parameters.AddWithValue("@date", DateTime.Today);

                                    insertInventoryCmd.ExecuteNonQuery();
                                }

                                clearFields();
                                displayAllProducts();
                            }
                        }
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
        }

        private void addprod_clearbtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void addprod_dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = addprod_dataGrid.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value;

                addprod_name.Text = row.Cells[1].Value.ToString();
                addprod_category.Text = row.Cells[2].Value.ToString();
                addprod_price.Text = row.Cells[3].Value.ToString();
                addprod_status.Text = row.Cells[4].Value.ToString();

            }
        }

        private void addprod_removebtn_Click(object sender, EventArgs e)
        {

            if (emptyFields())
            {
                MessageBox.Show("Empty Fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Delete Product ID: " +
                    getID.ToString() + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();

                            string deleteData = "DELETE FROM Product WHERE ProductID = @prodID";
                            using (SqlCommand deleteD = new SqlCommand(deleteData, connect))
                            {
                                deleteD.Parameters.AddWithValue("@prodID", getID);
                                deleteD.ExecuteNonQuery();
                            }

                            string deleteInventory = "DELETE FROM Inventory WHERE ProductID = @prodID";
                            using (SqlCommand cmd = new SqlCommand(deleteInventory, connect))
                            {
                                cmd.Parameters.AddWithValue("@prodID", getID);
                                cmd.ExecuteNonQuery();
                            }

                            clearFields();
                            displayAllProducts();


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
            }
        }

        private void addprod_dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            addprod_dataGrid.ReadOnly = true;
        }

        private void product_search_TextChanged(object sender, EventArgs e)
        {
            productdata proddata = new productdata();
            List<productdata> filteredData;

            if (string.IsNullOrWhiteSpace(product_search.Text))
            {
                filteredData = proddata.AllProductsData();
            }
            else
            {
                filteredData = proddata.SearchProducts(product_search.Text.Trim());
            }

            addprod_dataGrid.DataSource = filteredData;
        }

        private void product_search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(product_search.Text))
            {
                product_search.Text = "Search Product";
                product_search.ForeColor = Color.Gray;
            }
        }

        private void product_search_Enter(object sender, EventArgs e)
        {
            if (product_search.Text == "Search Product")
            {
                product_search.Text = "";
                product_search.ForeColor = Color.Black;
            }
        }
    }
}
