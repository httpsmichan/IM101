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

                    if (reader.HasRows) 
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
                try
                {
                    connect.Open();


                    string selectData = @"
                SELECT * 
                FROM Product 
                WHERE CAST(ProductID AS VARCHAR) LIKE @search 
                OR ProductName LIKE @search 
                OR Category LIKE @search
                OR Status LIKE @search";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%"); 

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            productdata proddata = new productdata
                            {

                                ProductID = reader["ProductID"] != DBNull.Value ? Convert.ToInt32(reader["ProductID"]) : 0,
                                ProductName = reader["ProductName"] != DBNull.Value ? reader["ProductName"].ToString() : string.Empty,
                                Category = reader["Category"] != DBNull.Value ? reader["Category"].ToString() : string.Empty,
                                Price = reader["Price"] != DBNull.Value ? reader["Price"].ToString() : "0",  
                                Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : "Unknown", 
                                Date = reader["Date"] != DBNull.Value ? Convert.ToDateTime(reader["Date"]).ToString("yyyy-MM-dd") : "N/A"  
                            };

                            listData.Add(proddata);
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error while searching products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return listData;
        }

        public List<productdata> SearchAvailableProducts(string searchTerm)
        {
            List<productdata> listData = new List<productdata>();

            using (SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                try
                {
                    connect.Open();

                    string selectData = @"
                SELECT * 
                FROM Product 
                WHERE Status = @Status 
                AND (
                    CAST(ProductID AS VARCHAR) LIKE @search 
                    OR ProductName LIKE @search 
                    OR Category LIKE @search
                )";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@Status", "Available");
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            productdata proddata = new productdata
                            {
                                ProductID = reader["ProductID"] != DBNull.Value ? Convert.ToInt32(reader["ProductID"]) : 0,
                                ProductName = reader["ProductName"] != DBNull.Value ? reader["ProductName"].ToString() : string.Empty,
                                Category = reader["Category"] != DBNull.Value ? reader["Category"].ToString() : string.Empty,
                                Price = reader["Price"] != DBNull.Value ? reader["Price"].ToString() : "0",
                                Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : "Unknown",
                                Date = reader["Date"] != DBNull.Value ? Convert.ToDateTime(reader["Date"]).ToString("yyyy-MM-dd") : "N/A"
                            };

                            listData.Add(proddata);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while searching available products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return listData;
        }
    }
}
