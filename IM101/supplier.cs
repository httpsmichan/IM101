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
    public partial class supplier : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public supplier()
        {
            InitializeComponent();
            displayAllSuppliersData();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayAllSuppliersData();
        }

        public void displayAllSuppliersData()
        {
            supplierdata sdata = new supplierdata();

            List<supplierdata> listData = sdata.AllSuppliersData();

            supplier_dataGrid.DataSource = listData;

        }

        private void supplier_addbtn_Click(object sender, EventArgs e)
        {
            if (supplier_name.Text == "" || supplier_email.Text == "")
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
                        string insertData = "INSERT INTO Supplier (SupplierName, Email, MobileNumber) VALUES (@name, @email, @mnum)";

                        using (SqlCommand insertCmd = new SqlCommand(insertData, connect))
                        {
                            insertCmd.Parameters.AddWithValue("@name", supplier_name.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@email", supplier_email.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@mnum", supplier_mnum.Text.Trim());

                            insertCmd.ExecuteNonQuery();
                            clearFields();
                            displayAllSuppliersData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection failed: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void supplier_updatebtn_Click(object sender, EventArgs e)
        {
            if (supplier_name.Text == "" || supplier_email.Text == "")
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to update Supplier ID: " + getID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();
                            string updateData = "UPDATE Supplier SET SupplierName = @name, Email = @email, MobileNumber = @mnum WHERE SupplierID = @id";

                            using (SqlCommand updateCmd = new SqlCommand(updateData, connect))
                            {
                                updateCmd.Parameters.AddWithValue("@name", supplier_name.Text.Trim());
                                updateCmd.Parameters.AddWithValue("@email", supplier_email.Text.Trim());
                                updateCmd.Parameters.AddWithValue("@mnum", supplier_mnum.Text.Trim());
                                updateCmd.Parameters.AddWithValue("@id", getID);

                                updateCmd.ExecuteNonQuery();
                                clearFields();
                                displayAllSuppliersData();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Connection failed: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }
            }
        }

        private void supplier_removebtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove Supplier ID: " + getID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();
                        string deleteData = "DELETE FROM Supplier WHERE SupplierID = @id";

                        using (SqlCommand deleteCmd = new SqlCommand(deleteData, connect))
                        {
                            deleteCmd.Parameters.AddWithValue("@id", getID);

                            deleteCmd.ExecuteNonQuery();
                            clearFields();
                            displayAllSuppliersData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection failed: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }
        public void clearFields()
        {
            supplier_name.Text = "";
            supplier_email.Text = "";
            supplier_mnum.Text = "";
        }

        public bool checkConnection()
        {
            return connect.State == ConnectionState.Closed;
        }

        private int getID = 0;

        private void supplier_dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = supplier_dataGrid.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value;
                string name = row.Cells[1].Value.ToString();
                string email = row.Cells[2].Value.ToString();
                string mnum = row.Cells[3].Value.ToString();

                supplier_name.Text = name;
                supplier_email.Text = email;
                supplier_mnum.Text = mnum;
            }
        }

        private void supplier_search_TextChanged(object sender, EventArgs e)
        {
            supplierdata iData = new supplierdata();
            List<supplierdata> filteredData;

            if (string.IsNullOrWhiteSpace(supplier_search.Text))
            {
                filteredData = iData.AllSuppliersData();
            }
            else
            {
                filteredData = iData.SearchSupplier(supplier_search.Text.Trim());
            }

            supplier_dataGrid.DataSource = filteredData;
        }

        private void supplier_Load(object sender, EventArgs e)
        {
            supplier_search.Text = "Search Supplier Name";
            supplier_search.ForeColor = Color.Gray;

            displayAllSuppliersData();
        }

        private void supplier_search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(supplier_search.Text))
            {
                supplier_search.Text = "Search Supplier Name";
                supplier_search.ForeColor = Color.Gray;
            }
        }

        private void supplier_search_Enter(object sender, EventArgs e)
        {
            if (supplier_search.Text == "Search Supplier Name")
            {
                supplier_search.Text = "";
                supplier_search.ForeColor = Color.Black;
            }
        }

        private void supplier_clearbtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}
