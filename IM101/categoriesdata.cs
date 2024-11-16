using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IM101
{
    internal class categoriesdata
    {
        public int CategoriesID { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }


        public List<categoriesdata> AllCategoriesData()
        {
            List<categoriesdata> listData = new List<categoriesdata>();

            using (SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                connect.Open();

                string selectData = "SELECT * FROM Category";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        categoriesdata cdata = new categoriesdata();
                        cdata.CategoriesID = (int)reader["categoryid"];
                        cdata.Category = reader["category"].ToString();
                        cdata.Date = reader["date"].ToString();

                        listData.Add(cdata);
                    }
                }

            }
            return listData;
        }

        public List<categoriesdata> SearchCategories(string searchTerm)
        {
            List<categoriesdata> listData = new List<categoriesdata>();

            try
            {
                using (SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    connect.Open();

                    // Use LIKE for partial matching on category, and check if searchTerm matches categoryid exactly
                    string selectData = "SELECT * FROM Category WHERE category LIKE @search OR CAST(categoryid AS VARCHAR) = @searchExact";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                        cmd.Parameters.AddWithValue("@searchExact", searchTerm); // Exact match for categoryid

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            categoriesdata cdata = new categoriesdata();
                            cdata.CategoriesID = (int)reader["categoryid"];
                            cdata.Category = reader["category"].ToString();
                            cdata.Date = reader["date"].ToString();

                            listData.Add(cdata);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listData;
        }
    }
}
