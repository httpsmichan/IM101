using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace IM101
{
    internal class logdata
    {
        SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public int LogID { get; set; }
        public string ActionType { get; set; } 
        public int ProductID { get; set; }
        public string QuantityChange { get; set; }
        public int? PrevStock { get; set; } 
        public int? NewStock { get; set; } 
        public string Staff { get; set; }
        public string IDs { get; set; }
        public string Date { get; set; }


        public List<logdata> GetAllLogs()
        {
            List<logdata> listData = new List<logdata>();

            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();

                string selectData = @"SELECT * FROM Logs";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        logdata log = new logdata
                        {
                            LogID = Convert.ToInt32(reader["LogID"]),
                            ActionType = reader["ActionType"] == DBNull.Value ? null : reader["ActionType"].ToString(),
                            ProductID = Convert.ToInt32(reader["ProductID"]),
                            QuantityChange = reader["QuantityChange"] == DBNull.Value ? null: (Convert.ToInt32(reader["QuantityChange"]) > 0 ? $"+{reader["QuantityChange"]}" : reader["QuantityChange"].ToString()),
                            PrevStock = reader["PrevStock"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["PrevStock"]),
                            NewStock = reader["NewStock"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NewStock"]),
                            Staff = reader["Staff"] == DBNull.Value ? null : reader["Staff"].ToString(),
                            IDs = reader["IDs"] == DBNull.Value ? null : reader["IDs"].ToString(),
                            Date = reader.IsDBNull(reader.GetOrdinal("Date"))
                                    ? string.Empty 
                                    : Convert.ToDateTime(reader["Date"]).ToString("yyyy-MM-dd") 

                    };

                        listData.Add(log);
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

        public List<logdata> SearchLogs(string searchTerm)
        {
            List<logdata> listData = new List<logdata>();

            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();

                string searchQuery = @"
            SELECT * FROM Logs
            WHERE ActionType LIKE @searchTerm 
               OR ProductID LIKE @searchTerm
               OR Staff LIKE @searchTerm"; // Add Staff to the WHERE clause

                using (SqlCommand cmd = new SqlCommand(searchQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        logdata log = new logdata
                        {
                            LogID = Convert.ToInt32(reader["LogID"]),
                            ActionType = reader["ActionType"] == DBNull.Value ? null : reader["ActionType"].ToString(),
                            ProductID = Convert.ToInt32(reader["ProductID"]),
                            QuantityChange = reader["QuantityChange"] == DBNull.Value ? null : reader["QuantityChange"].ToString(),
                            PrevStock = reader["PrevStock"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["PrevStock"]),
                            NewStock = reader["NewStock"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["NewStock"]),
                            Staff = reader["Staff"] == DBNull.Value ? null : reader["Staff"].ToString(),
                            IDs = reader["IDs"] == DBNull.Value ? null : reader["IDs"].ToString(),
                            Date = reader.IsDBNull(reader.GetOrdinal("Date")) ? string.Empty : Convert.ToDateTime(reader["Date"]).ToString("yyyy-MM-dd")
                        };

                        listData.Add(log);
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
