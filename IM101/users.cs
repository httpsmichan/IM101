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
    public partial class users : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public users()
        {
            InitializeComponent();
            displayAllUsersData();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayAllUsersData();
        }

        public void displayAllUsersData()
        {
            usersdata udata = new usersdata();
            List<usersdata> listData = udata.AllUsersData();
            adduser_dataGrid.DataSource = listData;
           
        }


        private void adduser_addbtn_Click(object sender, EventArgs e)
        {
            if (adduser_uname.Text == "" || adduser_pass.Text == "")
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AddUser();
            }
        }

        private void AddUser()
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();
                    if (IsUsernameTaken(adduser_uname.Text.Trim()))
                    {
                        MessageBox.Show(adduser_role.Text.Trim() + " is already taken", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        InsertUser(adduser_uname.Text.Trim(), adduser_pass.Text.Trim(), adduser_role.SelectedItem.ToString(),
                                   adduser_email.Text.Trim(), adduser_mnum.Text.Trim());
                        clearFields();
                        displayAllUsersData();
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

        private bool IsUsernameTaken(string username)
        {
            string checkUsername = "SELECT * FROM Staff WHERE username = @usern";
            using (SqlCommand cmd = new SqlCommand(checkUsername, connect))
            {
                cmd.Parameters.AddWithValue("@usern", username);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table.Rows.Count > 0;
            }
        }

        private void InsertUser(string username, string password, string role, string email, string mobilenum)
        {
            string insertData = "INSERT INTO Staff (username, password, role, email, mobilenum) " +
                                "VALUES(@usern, @pass, @role, @email, @mnum)";
            using (SqlCommand insertID = new SqlCommand(insertData, connect))
            {
                insertID.Parameters.AddWithValue("@usern", username);
                insertID.Parameters.AddWithValue("@pass", password);
                insertID.Parameters.AddWithValue("@role", role);
                insertID.Parameters.AddWithValue("@email", email);
                insertID.Parameters.AddWithValue("@mnum", mobilenum);
                insertID.ExecuteNonQuery();
            }
        }

        private void adduser_updatebtn_Click(object sender, EventArgs e)
        {
            if (adduser_uname.Text == "" || adduser_pass.Text == "")
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UpdateUser();
            }
        }

        private void UpdateUser()
        {
            if (MessageBox.Show($"Are you sure you want to update User ID: {getID}?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();
                        string updateData = "UPDATE Staff SET username = @usern, password = @pass, role = @role, email = @email, mobilenum = @mnum WHERE staffid = @id";
                        ExecuteNonQuery(updateData, adduser_uname.Text.Trim(), adduser_pass.Text.Trim(), adduser_role.SelectedItem.ToString(), adduser_email.Text.Trim(), adduser_mnum.Text.Trim(), getID);
                        clearFields();
                        displayAllUsersData();
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

        private void ExecuteNonQuery(string query, string username, string password, string role, string email, string mobilenum, int id = 0)
        {
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                cmd.Parameters.AddWithValue("@usern", username);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@mnum", mobilenum);
                if (id != 0)
                {
                    cmd.Parameters.AddWithValue("@id", id);
                }
                cmd.ExecuteNonQuery();
            }
        }
        public void clearFields()
        {
            adduser_uname.Text = "";
            adduser_pass.Text = "";
            adduser_role.SelectedIndex = -1;
            adduser_email.Text = "";
            adduser_mnum.Text = "";

        }

        private void adduser_clearbtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void adduser_removebtn_Click(object sender, EventArgs e)
        {
            if (adduser_uname.Text == "" || adduser_pass.Text == "")
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RemoveUser();
            }
        }

        private void RemoveUser()
        {
            if (MessageBox.Show($"Are you sure you want to remove User ID: {getID}?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();
                        string deleteData = "DELETE FROM Staff WHERE staffid = @id";
                        ExecuteNonQuery(deleteData, "", "", "", "", "", getID);
                        clearFields();
                        displayAllUsersData();
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


        public bool checkConnection()
        {
            return connect.State == ConnectionState.Closed;
        }

        private int getID = 0;

        private void adduser_dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = adduser_dataGrid.Rows[e.RowIndex];
                getID = (int)row.Cells[0].Value;
                adduser_uname.Text = row.Cells[1].Value.ToString();
                adduser_pass.Text = row.Cells[2].Value.ToString();
                adduser_role.Text = row.Cells[4].Value.ToString();
                adduser_email.Text = row.Cells[3].Value.ToString();
                adduser_mnum.Text = row.Cells[5].Value.ToString();
            }
        }

        private void adduser_dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            adduser_dataGrid.ReadOnly = true;
        }

        private void staff_search_TextChanged(object sender, EventArgs e)
        {
            usersdata uData = new usersdata();
            List<usersdata> filteredData;


            if (string.IsNullOrWhiteSpace(staff_search.Text) || staff_search.Text == "Search StaffID or Username")
            {
                filteredData = uData.AllUsersData(); 
            }
            else
            {
                filteredData = uData.SearchUsers(staff_search.Text.Trim()); 
            }

            adduser_dataGrid.DataSource = filteredData; 
        }

        private void staff_search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(staff_search.Text))
            {
                staff_search.Text = "Search StaffID or Username";
                staff_search.ForeColor = Color.Gray; 
            }
            else
            {
                staff_search.ForeColor = Color.Black; 
            }
        }

        private void staff_search_Enter(object sender, EventArgs e)
        {

            if (staff_search.Text == "Search StaffID or Username")
            {
                staff_search.Text = "";
                staff_search.ForeColor = Color.Black; 
            }
        }

        private void users_Load(object sender, EventArgs e)
        {
            staff_search.Text = "Search StaffID or Username";
            staff_search.ForeColor = Color.Gray;
            displayAllUsersData();

        }
    }
}
