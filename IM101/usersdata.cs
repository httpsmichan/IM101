using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM101
{
    internal class usersdata
    {
        public int StaffID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Mobilenum { get; set; }

        public List<usersdata> AllUsersData()
        {
            List<usersdata> listData = new List<usersdata>();

            using (SqlConnection
          connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                connect.Open();

                string selectData = "SELECT * FROM Staff";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        usersdata udata = new usersdata();
                        udata.StaffID = (int)reader["staffid"];
                        udata.Username = reader["username"].ToString();
                        udata.Password = reader["password"].ToString();
                        udata.Email = reader["email"].ToString();
                        udata.Role = reader["role"].ToString();
                        udata.Mobilenum = reader["mobilenum"].ToString();


                        listData.Add(udata);
                    }
                }

            }
            return listData;
        }


        public List<usersdata> SearchUsers(string searchTerm)
        {
            List<usersdata> listData = new List<usersdata>();

            using (SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True"))
            {
                connect.Open();

                string selectData = "SELECT * FROM Staff WHERE Username LIKE @search OR StaffID LIKE @search OR Role LIKE @search";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usersdata udata = new usersdata
                            {
                                StaffID = reader.GetInt32(reader.GetOrdinal("StaffID")),
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                Password = reader.GetString(reader.GetOrdinal("Password")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Role = reader.GetString(reader.GetOrdinal("Role")),
                                Mobilenum = reader.GetString(reader.GetOrdinal("Mobilenum"))
                            };

                            listData.Add(udata);
                        }
                    }
                }
            }

            return listData;
        }

    }
}
