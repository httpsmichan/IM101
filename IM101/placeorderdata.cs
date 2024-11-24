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
    internal class placeorderdata
    {
        SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;");

        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string OriginalPrice { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string Subtotal { get; set; }
        public string OrderDate { get; set; }

        public List<placeorderdata> GetBillingDataGB()
        {
            List<placeorderdata> listData = new List<placeorderdata>();

            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    int custID = 0;

                    string selectCustData = "SELECT MAX(CustomerID) FROM Purchase";

                    using (SqlCommand cmd = new SqlCommand(selectCustData, connect))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            custID = Convert.ToInt32(result);
                        }
                        else
                        {
                            Console.WriteLine("Error fetching CustomerID");
                            return listData; 
                        }
                    }


                    string selectData = @"
            SELECT CustomerID, ProductID, ProductName, OriginalPrice, Quantity, Unit, Subtotal, OrderDate
            FROM Purchase
            WHERE CustomerID = @custID";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@custID", custID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                placeorderdata pData = new placeorderdata
                                {
                                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    ProductName = reader["ProductName"].ToString(),
                                    OriginalPrice = reader["OriginalPrice"].ToString(),
                                    Quantity = Convert.ToInt32(reader["Quantity"]),
                                    Unit = reader["Unit"].ToString(),
                                    Subtotal = reader["Subtotal"].ToString(),
                                    OrderDate = reader["OrderDate"].ToString()
                                };

                                listData.Add(pData);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection failed: " + ex.Message);
                }
                finally
                {
                    connect.Close();
                }
            }

            return listData;
        }
    }
}
