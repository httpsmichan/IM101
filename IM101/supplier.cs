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
            if (AreFieldsEmpty())
            {
                ShowError("Empty fields");
            }
            else
            {
                AddSupplier();
            }
        }



        private void supplier_updatebtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsEmpty())
            {
                ShowError("Empty fields");
            }
            else if (ConfirmAction($"Are you sure you want to update Supplier ID: {getID}?"))
            {
                UpdateSupplier();
            }
        }

        private void supplier_removebtn_Click(object sender, EventArgs e)
        {
            if (ConfirmAction($"Are you sure you want to remove Supplier ID: {getID}?"))
            {
                RemoveSupplier();
            }
        }

        private void AddSupplier()
        {
            ExecuteQuery(
                "INSERT INTO Supplier (SupplierName, Email, MobileNumber) VALUES (@name, @email, @mnum)",
                new SqlParameter("@name", supplier_name.Text.Trim()),
                new SqlParameter("@email", supplier_email.Text.Trim()),
                new SqlParameter("@mnum", supplier_mnum.Text.Trim())
            );
        }

        private void UpdateSupplier()
        {
            ExecuteQuery(
                "UPDATE Supplier SET SupplierName = @name, Email = @email, MobileNumber = @mnum WHERE SupplierID = @id",
                new SqlParameter("@name", supplier_name.Text.Trim()),
                new SqlParameter("@email", supplier_email.Text.Trim()),
                new SqlParameter("@mnum", supplier_mnum.Text.Trim()),
                new SqlParameter("@id", getID)
            );
        }

        private void RemoveSupplier()
        {
            ExecuteQuery(
                "DELETE FROM Supplier WHERE SupplierID = @id",
                new SqlParameter("@id", getID)
            );
        }

        private void ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddRange(parameters);
                        cmd.ExecuteNonQuery();
                    }
                    clearFields();
                    displayAllSuppliersData();
                }
                catch (Exception ex)
                {
                    ShowError($"Connection failed: {ex.Message}");
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private bool AreFieldsEmpty()
        {
            return string.IsNullOrWhiteSpace(supplier_name.Text) || string.IsNullOrWhiteSpace(supplier_email.Text);
        }

        private bool ConfirmAction(string message)
        {
            return MessageBox.Show(message, "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                supplier_name.Text = row.Cells[1].Value.ToString();
                supplier_email.Text = row.Cells[2].Value.ToString();
                supplier_mnum.Text = row.Cells[3].Value.ToString();
            }
        }

        private void supplier_search_TextChanged(object sender, EventArgs e)
        {
            supplierdata iData = new supplierdata();
            List<supplierdata> filteredData;

            // Check if the search text is empty or contains the placeholder text
            if (string.IsNullOrWhiteSpace(supplier_search.Text) || supplier_search.Text == "Search Suppliers")
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
            ResetSearchField();
            displayAllSuppliersData();
        }

        private void supplier_search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(supplier_search.Text))
            {
                ResetSearchField();
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

        private void ResetSearchField()
        {
            supplier_search.Text = "Search Supplier Name";
            supplier_search.ForeColor = Color.Gray;
        }

        private void supplier_clearbtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void supplier_dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            supplier_dataGrid.ReadOnly = true;

        }
    }
}
