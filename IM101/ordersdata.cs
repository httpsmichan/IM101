using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM101
{
    internal class ordersdata
    {
        SqlConnection
         connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;");

        public int PurchaseID { set; get; }
        public string CustomerID { set; get; }
        public int ProductID { set; get; }
        public string ProductName { set; get; }
        public string Category { set; get; }
        public string OriginalPrice { set; get; }
        public int Quantity { set; get; }
        public string Unit { set; get; }
        public string Subtotal { set; get; }
        public string OrderDate { set; get; }

        public List<ordersdata> allOrdersData()
        {
            List<ordersdata> listData = new List<ordersdata>();

            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();

                    int custID = 0;
                    string selectCustData = "SELECT MAX (CustomerID) FROM Purchase";

                    using (SqlCommand cmd = new SqlCommand(selectCustData, connect))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            int temp = Convert.ToInt32(result);

                            if (temp == 0)
                            {
                                custID = 1;
                            }
                            else
                            {
                                custID = temp;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error ID");
                        }
                    }

                    string selectData = "SELECT * FROM Purchase WHERE CustomerID = @catID ";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@catID", custID);

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            ordersdata oData = new ordersdata();
                            oData.PurchaseID = (int)reader["PurchaseID"];
                            oData.CustomerID = reader["CustomerID"].ToString();
                            oData.ProductID = Convert.ToInt32(reader["ProductID"]);
                            oData.ProductName = reader["ProductName"].ToString();
                            oData.Category = reader["Category"].ToString();
                            oData.OriginalPrice = reader["OriginalPrice"].ToString();
                            oData.Quantity = Convert.ToInt32(reader["Quantity"]);
                            oData.Unit = reader["Unit"].ToString();
                            oData.Subtotal = reader["Subtotal"].ToString();
                            oData.OrderDate = reader["OrderDate"].ToString();

                            listData.Add(oData);
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
    }
}
