using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IM101
{
    internal class customersdata
    {
        SqlConnection
        connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public string BillNo { get; set; }
        public string CustomerID { get; set; }
        public string TotalPrice { get; set; }
        public string Amount { get; set; }
        public string Change { get; set; }
        public string Date { get; set; }

        public List<customersdata> allCustomers()
        {
            List<customersdata> listData = new List<customersdata>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = @"SELECT * FROM Customers";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            customersdata cdata = new customersdata();
                            cdata.BillNo = reader["BillNo"].ToString();
                            cdata.CustomerID = reader["CustomerID"].ToString();
                            cdata.TotalPrice = reader["TotalPrice"].ToString();
                            cdata.Amount = reader["Amount"].ToString();
                            cdata.Change = reader["Change"].ToString();

                            DateTime orderDate = Convert.ToDateTime(reader["Date"]);
                            cdata.Date = orderDate.Date.ToString("yyyy-MM-dd"); 



                            listData.Add(cdata);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed Connection: " + ex.Message);
                }
                finally
                {
                    connect.Close();
                }
            }

            return listData;
        }



        public List<customersdata> allTodayCustomers()
        {
            List<customersdata> listData = new List<customersdata>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = @"
                SELECT * FROM Customers
                WHERE CAST(Date AS DATE) = CAST(GETDATE() AS DATE)";  

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            customersdata cdata = new customersdata();
                            cdata.BillNo = reader["BillNo"].ToString();
                            cdata.CustomerID = reader["CustomerID"].ToString();
                            cdata.TotalPrice = reader["TotalPrice"].ToString();
                            cdata.Amount = reader["Amount"].ToString();
                            cdata.Change = reader["Change"].ToString();

                            DateTime orderDate = Convert.ToDateTime(reader["Date"]);
                            cdata.Date = orderDate.Date.ToString("yyyy-MM-dd"); 


                            listData.Add(cdata);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed Connection: " + ex.Message);
                }
                finally
                {
                    connect.Close();
                }
            }

            return listData;
        }


        public List<customersdata> SearchCustomers(string searchTerm)
        {
            List<customersdata> listData = new List<customersdata>();

            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();

                string searchQuery = @"
    SELECT b.CustomerID, b.BillNo, p.TotalPrice, p.Amount, p.Change, p.Date, p.BillNo
    FROM Customers p
    JOIN Billing b ON p.BillNo = b.BillNo
    WHERE b.CustomerID LIKE @searchTerm OR b.BillNo LIKE @searchTerm";

                using (SqlCommand cmd = new SqlCommand(searchQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        customersdata cdata = new customersdata
                        {
                            BillNo = reader["BillNo"].ToString(),
                            CustomerID = reader["CustomerID"].ToString(),
                            TotalPrice = reader["TotalPrice"].ToString(),
                            Amount = reader["Amount"].ToString(),
                            Change = reader["Change"].ToString(),
                            Date = Convert.ToDateTime(reader["Date"]).ToString("yyyy-MM-dd")

                    };

                        listData.Add(cdata);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed Connection: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }

            return listData;
        }
    }
}
