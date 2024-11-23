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
    public partial class Form1 : Form
    {
        public static string username;

        SqlConnection connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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


        private void login_btn_Click_1(object sender, EventArgs e)
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    using (SqlCommand cmd = new SqlCommand("LoginProcedure", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Username", login_username.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", login_password.Text.Trim());

                        SqlParameter userRoleParam = new SqlParameter("@UserRole", SqlDbType.NVarChar, 50)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(userRoleParam);

                        SqlParameter messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, -1)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(messageParam);

                        cmd.ExecuteNonQuery();

                        string userRole = userRoleParam.Value as string;
                        string message = messageParam.Value.ToString();

                        MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (message == "Login successfully!")
                        {
                            username = login_username.Text.Trim();

                            if (userRole == "Admin")
                            {
                                MainForm mForm = new MainForm();
                                mForm.Show();
                                this.Hide();
                            }
                            else if (userRole == "Cashier")
                            {
                                CashierMainForm cForm = new CashierMainForm();
                                cForm.Show();
                                this.Hide();
                            }
                        }
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

        private void registerlabel_Click(object sender, EventArgs e)
        {
            signup signupForm = new signup();
            signupForm.Show();

            this.Hide();
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }
    }
}
