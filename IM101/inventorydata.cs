using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IM101
{
    internal class inventorydata
    {
        SqlConnection
        connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public int InventoryID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stocks { get; set; }
        public string Unit { get; set; }
        public string Date { get; set; }

        public List<inventorydata> AllInventoryData()
        {
            List<inventorydata> listData = new List<inventorydata>();

            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    string selectQuery = @"
        SELECT 
            i.InventoryID, 
            i.ProductID, 
            p.ProductName, 
            i.Price AS i_Price, 
            i.Stocks, 
            i.Amount,
            i.Date AS i_Date, 
            p.Price AS Price
        FROM 
            Inventory i
        INNER JOIN 
            Product p
        ON 
            i.ProductID = p.ProductID";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            inventorydata data = new inventorydata
                            {
                                InventoryID = reader.GetInt32(reader.GetOrdinal("InventoryID")),
                                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                                Price = reader.GetDecimal(reader.GetOrdinal("i_Price")),
                                Stocks = reader.IsDBNull(reader.GetOrdinal("Stocks")) ? 0 : Convert.ToInt32(reader.GetDecimal(reader.GetOrdinal("Stocks"))),
                                Unit = reader.IsDBNull(reader.GetOrdinal("Amount")) ? string.Empty : reader.GetString(reader.GetOrdinal("Amount")),

                                // Format the date to show only the date portion
                                Date = reader.GetDateTime(reader.GetOrdinal("i_Date")).ToString("yyyy-MM-dd")
                            };

                            listData.Add(data);
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

            return listData;
        }


        public List<inventorydata> SearchInventory(string searchTerm)
        {
            List<inventorydata> listData = new List<inventorydata>();

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string searchQuery = @"
            SELECT i.InventoryID, i.ProductID, p.ProductName, 
                   i.Price AS i_Price, i.Stocks, i.Amount, i.Date AS i_Date 
            FROM Inventory i
            INNER JOIN Product p ON i.ProductID = p.ProductID
            WHERE p.ProductName LIKE @searchTerm OR i.ProductID LIKE @searchTerm";

                using (SqlCommand cmd = new SqlCommand(searchQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        try
                        {
                            inventorydata data = new inventorydata
                            {
                                InventoryID = reader.GetInt32(reader.GetOrdinal("InventoryID")),
                                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                                Price = reader.IsDBNull(reader.GetOrdinal("i_Price")) ? 0m : reader.GetDecimal(reader.GetOrdinal("i_Price")),
                                Stocks = reader.IsDBNull(reader.GetOrdinal("Stocks")) ? 0 : Convert.ToInt32(reader.GetDecimal(reader.GetOrdinal("Stocks"))), // Keep integer conversion
                                Unit = reader.IsDBNull(reader.GetOrdinal("Amount")) ? "0" : reader.GetString(reader.GetOrdinal("Amount")),
                                Date = reader.IsDBNull(reader.GetOrdinal("i_Date"))
                                        ? DateTime.MinValue.ToString("yyyy-MM-dd")
                                        : reader.GetDateTime(reader.GetOrdinal("i_Date")).ToString("yyyy-MM-dd")

                        };

                            listData.Add(data);
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine("SQL Error: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("General Error: " + ex.Message);
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

            return listData;
        }
    }
}
