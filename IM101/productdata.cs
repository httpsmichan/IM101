using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IM101
{
    internal class productdata
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }


        public List<productdata> AllProductsData()
        {
            List<productdata> listData = new List<productdata>();

            using (SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                connect.Open();

                string selectData = "SELECT * FROM Product";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows) // Check if any rows are returned
                    {
                        while (reader.Read())
                        {
                            productdata proddata = new productdata
                            {
                                ProductID = (int)reader["ProductID"],
                                ProductName = reader["ProductName"].ToString(),
                                Category = reader["Category"].ToString(),
                                Price = reader["Price"].ToString(),
                                Status = reader["Status"].ToString(),

                                // Format the date to show only the date portion
                                Date = Convert.ToDateTime(reader["Date"]).ToString("yyyy-MM-dd")
                            };
                            listData.Add(proddata);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No products found in the database.");
                    }
                }
            }

            return listData;
        }


        public List<productdata> allAvailableProducts()
        {
            List<productdata> listData = new List<productdata>();

            using (SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                connect.Open();

                string selectData = "SELECT * FROM Product WHERE Status = @Status";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@Status", "Available");
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        productdata proddata = new productdata
                        {
                            ProductID = (int)reader["ProductID"],
                            ProductName = reader["ProductName"].ToString(),
                            Category = reader["Category"].ToString(),
                            Price = reader["Price"].ToString(),
                            Status = reader["Status"].ToString(),

                            // Format the date to show only the date portion
                            Date = Convert.ToDateTime(reader["Date"]).ToString("yyyy-MM-dd")
                        };

                        listData.Add(proddata);
                    }
                }
            }

            return listData;
        }


        public List<productdata> SearchProducts(string searchTerm)
        {
            List<productdata> listData = new List<productdata>();

            using (SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                connect.Open();

                // Updated query to include 'Status' in the search condition
                string selectData = @"
            SELECT * 
            FROM Product 
            WHERE CAST(ProductID AS VARCHAR) LIKE @search 
               OR ProductName LIKE @search 
               OR Category LIKE @search
               OR Status LIKE @search";  // Added Status to the search

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%"); // Parameterized search term

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        productdata proddata = new productdata
                        {
                            ProductID = (int)reader["ProductID"],
                            ProductName = reader["ProductName"].ToString(),
                            Category = reader["Category"].ToString(),
                            Price = reader["Price"].ToString(),
                            Status = reader["Status"].ToString(),  // Now fetching Status
                            Date = reader["Date"].ToString()
                        };

                        listData.Add(proddata);
                    }
                }
            }

            return listData;
        }
    }
}
