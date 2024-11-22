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
    public partial class signup : Form
    {
        SqlConnection
        connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public signup()
        {
            InitializeComponent();
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

        private void signup_btn_Click(object sender, EventArgs e)
        {
            if (signup_username.Text == "" || signup_password.Text == "" || signup_cpassword.Text == "")
            {
                MessageBox.Show("Please fill all empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();

                        using (SqlCommand cmd = new SqlCommand("SignUpProcedure", connect))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Username", signup_username.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", signup_password.Text.Trim());
                            cmd.Parameters.AddWithValue("@ConfirmPassword", signup_cpassword.Text.Trim());
                            cmd.Parameters.AddWithValue("@Email", " "); 
                            cmd.Parameters.AddWithValue("@MobileNum", " "); 

                            SqlParameter outputMessage = new SqlParameter("@Message", SqlDbType.NVarChar, -1);
                            outputMessage.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(outputMessage);

                            cmd.ExecuteNonQuery();

                            string message = outputMessage.Value.ToString();

                            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (message == "Successfully signed up!")
                            {
                                Form1 loginForm = new Form1();
                                loginForm.Show();
                                this.Hide();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection Failed: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void loginlabel_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();

            this.Hide();
        }

        private void signup_showPass_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = signup_showPass.Checked ? '\0' : '*';
            signup_cpassword.PasswordChar = signup_showPass.Checked ? '\0' : '*';
        }
    }
}
