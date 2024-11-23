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
    internal class supplydatas
    {
        SqlConnection
        connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public int SupplyID { get; set; }
        public int SupplierID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int QtySupplied { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }
        public string SupplyDate { get; set; }

        public List<supplydatas> AllSupplyData()
        {
            List<supplydatas> listData = new List<supplydatas>();

            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();
                    string selectQuery = "SELECT * FROM Supply";
                    using (SqlCommand cmd = new SqlCommand(selectQuery, connect))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                supplydatas data = new supplydatas
                                {
                                    SupplyID = reader.IsDBNull(reader.GetOrdinal("SupplyID")) ? 0 : reader.GetInt32(reader.GetOrdinal("SupplyID")),
                                    SupplierID = reader.IsDBNull(reader.GetOrdinal("SupplierID")) ? 0 : reader.GetInt32(reader.GetOrdinal("SupplierID")),
                                    ProductID = reader.IsDBNull(reader.GetOrdinal("ProductID")) ? 0 : reader.GetInt32(reader.GetOrdinal("ProductID")),
                                    ProductName = reader.IsDBNull(reader.GetOrdinal("ProductName")) ? string.Empty : reader.GetString(reader.GetOrdinal("ProductName")),
                                    QtySupplied = reader.IsDBNull(reader.GetOrdinal("QtySupplied")) ? 0 : reader.GetInt32(reader.GetOrdinal("QtySupplied")),
                                    UnitCost = reader.IsDBNull(reader.GetOrdinal("UnitCost")) ? 0 : reader.GetDecimal(reader.GetOrdinal("UnitCost")),
                                    TotalCost = reader.IsDBNull(reader.GetOrdinal("TotalCost")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TotalCost")),


                                    SupplyDate = reader.IsDBNull(reader.GetOrdinal("SupplyDate"))
                                        ? DateTime.MinValue.ToString("yyyy-MM-dd")
                                        : reader.GetDateTime(reader.GetOrdinal("SupplyDate")).ToString("yyyy-MM-dd"),

                                    Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? string.Empty : reader.GetString(reader.GetOrdinal("Status"))
                                };

                                listData.Add(data);
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
            return listData;
        }


        public List<supplydatas> SearchSupply(string searchTerm)
        {
            List<supplydatas> listData = new List<supplydatas>();

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string searchQuery = @"
            SELECT SupplyID, SupplierID, ProductID, ProductName, QtySupplied, UnitCost, TotalCost, SupplyDate, Status 
            FROM Supply 
            WHERE ProductName LIKE @searchTerm OR ProductName LIKE @searchTerm";

                using (SqlCommand cmd = new SqlCommand(searchQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        supplydatas data = new supplydatas
                        {
                            SupplyID = reader.GetInt32(reader.GetOrdinal("SupplyID")),
                            SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID")),
                            ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                            ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                            QtySupplied = reader.IsDBNull(reader.GetOrdinal("QtySupplied")) ? 0 : reader.GetInt32(reader.GetOrdinal("QtySupplied")),
                            UnitCost = reader.IsDBNull(reader.GetOrdinal("UnitCost")) ? 0 : reader.GetDecimal(reader.GetOrdinal("UnitCost")),
                            TotalCost = reader.IsDBNull(reader.GetOrdinal("TotalCost")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TotalCost")),

                            SupplyDate = reader.IsDBNull(reader.GetOrdinal("SupplyDate"))
                                        ? string.Empty 
                                        : reader.GetDateTime(reader.GetOrdinal("SupplyDate")).ToString("yyyy-MM-dd"), 


                            Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? string.Empty : reader.GetString(reader.GetOrdinal("Status")),
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

            return listData;
        }

    }
}
