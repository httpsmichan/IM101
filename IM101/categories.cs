using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IM101
{

    public partial class categories : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public int getID = 0;
        public categories()
        {
            InitializeComponent();
            displayCategoriesData();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayCategoriesData();
        }

        public void displayCategoriesData()
        {
            categoriesdata cData = new categoriesdata();
            List<categoriesdata> listData = cData.AllCategoriesData();

            category_grid.DataSource = listData;
        }

        private void category_addbtn_Click(object sender, EventArgs e)
        {
            if (category_name.Text == "")
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();
                        string checkCat = "SELECT * FROM Category WHERE category = @cat";
                        using (SqlCommand cmd = new SqlCommand(checkCat, connect))
                        {
                            cmd.Parameters.AddWithValue("@cat", category_name.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();

                            adapter.Fill(table);


                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show("Category: " + category_name.Text.Trim() + "already exist"
                                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO Category (category, date) VALUES(@cat, @date)";

                                using (SqlCommand insertD = new SqlCommand(insertData, connect))
                                {

                                    DateTime today = DateTime.Today;
                                    insertD.Parameters.AddWithValue("@cat", category_name.Text.Trim());
                                    insertD.Parameters.AddWithValue("@date", today);

                                    insertD.ExecuteNonQuery();
                                    clearFields();
                                    displayCategoriesData();

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        public bool checkConnection()
        {
            if (connect.State == ConnectionState.Closed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void clearFields()
        {
            category_name.Text = "";
        }

        private void category_updatebtn_Click(object sender, EventArgs e)
        {
            if (category_name.Text == "")
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Update Cat ID: " + getID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {

                            connect.Open();


                            string storedProcedure = "UpdateCategory";

                            using (SqlCommand cmd = new SqlCommand(storedProcedure, connect))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@CategoryID", getID); 
                                cmd.Parameters.AddWithValue("@CategoryName", category_name.Text.Trim());

                                cmd.ExecuteNonQuery();

                                clearFields();
                                displayCategoriesData();

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Update failed: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }
            }
        }

        private void category_clearbtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void category_removebtn_Click(object sender, EventArgs e)
        {
            if (category_name.Text == "")
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Remove Cat ID: " + getID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();

                            string storedProcedure = "RemoveCategoryAndProducts";

                            using (SqlCommand cmd = new SqlCommand(storedProcedure, connect))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@CategoryID", getID);  
                                cmd.Parameters.AddWithValue("@CategoryName", category_name.Text.Trim()); 

                                cmd.ExecuteNonQuery();

                                clearFields();
                                displayCategoriesData();

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Removal failed: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }
            }
        }

        private void category_search_TextChanged(object sender, EventArgs e)
        {
            categoriesdata cData = new categoriesdata();
            List<categoriesdata> filteredData;

            if (string.IsNullOrWhiteSpace(category_search.Text) || category_search.Text == "Search Category")
            {
                filteredData = cData.AllCategoriesData();
            }
            else
            {
                filteredData = cData.SearchCategories(category_search.Text.Trim());
            }

            category_grid.DataSource = filteredData;
        }

        private void category_search_Enter(object sender, EventArgs e)
        {
            if (category_search.Text == "Search Category")
            {
                category_search.Text = "";
                category_search.ForeColor = Color.Black;
            }
        }

        private void category_search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(category_search.Text))
            {
                category_search.Text = "Search Category";
                category_search.ForeColor = Color.Gray;
            }
        }

        private void categories_Load(object sender, EventArgs e)
        {
            category_search.Text = "Search Category";
            category_search.ForeColor = Color.Gray;

            displayCategoriesData();
        }

        private void category_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            category_grid.ReadOnly = true;
        }

        private void category_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = category_grid.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value;
                category_name.Text = row.Cells[1].Value.ToString();

            }
        }
    }
}
