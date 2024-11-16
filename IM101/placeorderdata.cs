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

        public string ProductID { get; set; }
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
                            int temp = Convert.ToInt32(result);
                            custID = temp == 0 ? 1 : temp;
                        }
                        else
                        {
                            Console.WriteLine("Error ID");
                        }
                    }

                    string selectData = @"
                    SELECT p.ProductID, p.ProductName, p.OriginalPrice, p.Quantity, p.Unit, p.Subtotal, p.OrderDate
                    FROM Purchase p
                    LEFT JOIN Billing b ON p.ProductID = b.ProductID";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@catID", custID);

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            placeorderdata pData = new placeorderdata();
                            pData.ProductID = reader["ProductID"].ToString();
                            pData.ProductName = reader["ProductName"].ToString();
                            pData.OriginalPrice = reader["OriginalPrice"].ToString();
                            pData.Quantity = Convert.ToInt32(reader["Quantity"]);
                            pData.Unit = reader["Unit"].ToString();
                            pData.Subtotal = reader["Subtotal"].ToString();
                            pData.OrderDate = reader["OrderDate"].ToString();

                            listData.Add(pData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection failed: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listData;
        }

        public List<placeorderdata> GetBillingDataCash()
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
                            int temp = Convert.ToInt32(result);
                            custID = temp == 0 ? 1 : temp;
                        }
                        else
                        {
                            Console.WriteLine("Error ID");
                        }
                    }

                    string selectData = @"
            SELECT b.BillNo, b.Amount, b.Change, p.ProductID, p.ProductName, p.OriginalPrice, p.Quantity, p.Unit, p.Subtotal, p.OrderDate
            FROM Purchase p
            LEFT JOIN Billing b ON p.ProductID = b.ProductID
            WHERE p.CustomerID = @catID";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@catID", custID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                placeorderdata pData = new placeorderdata
                                {
                                    ProductID = reader["ProductID"].ToString(),
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
