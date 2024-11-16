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
    internal class supplierdata
    {
        SqlConnection
      connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }

        public List<supplierdata> AllSuppliersData()
        {
            List<supplierdata> listData = new List<supplierdata>();

            using (SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                connect.Open();
                string selectData = "SELECT * FROM Supplier";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        supplierdata sdata = new supplierdata();
                        sdata.SupplierID = (int)reader["SupplierID"];
                        sdata.SupplierName = reader["SupplierName"].ToString();
                        sdata.Email = reader["Email"].ToString();
                        sdata.MobileNumber = reader["MobileNumber"].ToString();

                        listData.Add(sdata);
                    }
                }
            }
            return listData;
        }

        public List<supplierdata> SearchSupplier(string searchTerm)
        {
            List<supplierdata> listData = new List<supplierdata>();

            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string searchQuery = @"
                    SELECT SupplierID, SupplierName, MobileNumber, Email
                    FROM Supplier
                    WHERE SupplierName LIKE @searchTerm OR SupplierName LIKE @searchTerm";

                using (SqlCommand cmd = new SqlCommand(searchQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        supplierdata data = new supplierdata
                        {
                            SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID")),
                            SupplierName = reader.GetString(reader.GetOrdinal("SupplierName")),
                            MobileNumber = reader.GetString(reader.GetOrdinal("MobileNumber")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),

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
