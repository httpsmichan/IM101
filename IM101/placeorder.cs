using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IM101
{
    public partial class placeorder : UserControl
    {
        SqlConnection
          connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public placeorder()
        {
            InitializeComponent();
            grid_placeorder.AutoGenerateColumns = true;
            displayOrders();
            displayTotalPrice();
        }

        private int prodID = 0;
        private int idGen;
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayOrders();
            displayTotalPrice();
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

        public void displayOrders()
        {
            placeorderdata pData = new placeorderdata();
            List<placeorderdata> listData = pData.GetBillingDataGB();

            grid_placeorder.DataSource = listData;
        }

        public void IDGenerator()
        {
            using (SqlConnection
          connect = new SqlConnection(@"Data Source=SHINE;Initial Catalog=FuntilonDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                connect.Open();

                string selectData = "SELECT MAX(CustomerID) FROM Billing";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        int temp = Convert.ToInt32(result);
                        idGen = temp + 1;
                    }
                    else
                    {
                        idGen = 1;
                    }
                }
            }
        }

        private float totalPrice = 0;
        public void displayTotalPrice()
        {
            IDGenerator();

            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT SUM (Subtotal) FROM Purchase WHERE CustomerID = @catID";

                    using (SqlCommand cmd = new SqlCommand(@selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("catID", idGen);

                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            totalPrice = Convert.ToSingle(result);

                            order_Totalprice.Text = totalPrice.ToString("0.00");
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

        private void grid_placeorder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = grid_placeorder.Rows[e.RowIndex];

                prodID = (int)row.Cells[0].Value;

            }
        }
        public void clearFields()
        {
            grid_placeorder.DataSource = null;
            order_Cashamount.Text = "";
            order_Change.Text = "";
            totalPrice = 0;
            order_Cashamount.Text = "";
            order_Change.Text = "";
            order_Totalprice.Text = "";
        }

        private void order_placeorderbtn_Click(object sender, EventArgs e)
        {
            IDGenerator();

            if (order_Cashamount.Text == "" || grid_placeorder.Rows.Count <= 0)
            {
                MessageBox.Show("Something went wrong", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure to pay your orders? ", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();

                            DateTime today = DateTime.Today;

                            string insertBilling = "INSERT INTO Billing (CustomerID, TotalPrice, OrderDate) " +
                                                   "OUTPUT INSERTED.BillNo VALUES (@cID, @totalP, @odate)";

                            int billNo;

                            using (SqlCommand cmdBilling = new SqlCommand(insertBilling, connect))
                            {
                                cmdBilling.Parameters.AddWithValue("@cID", idGen);
                                cmdBilling.Parameters.AddWithValue("@totalP", Convert.ToDecimal(order_Totalprice.Text));
                                cmdBilling.Parameters.AddWithValue("@odate", today);

                                billNo = (int)cmdBilling.ExecuteScalar();
                            }

                            string insertData = "INSERT INTO Payment (CustomerID, ProductID, TotalPrice, Amount, Change, OrderDate, BillNo) " +
                                                "VALUES (@cID, @pID, @totalP, @amount, @change, @odate, @billNo)";

                            using (SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                cmd.Parameters.AddWithValue("@cID", idGen);
                                cmd.Parameters.AddWithValue("@pID", Convert.ToInt32(prodID));
                                cmd.Parameters.AddWithValue("@totalP", Convert.ToDecimal(order_Totalprice.Text));
                                cmd.Parameters.AddWithValue("@amount", Convert.ToDecimal(order_Cashamount.Text));
                                cmd.Parameters.AddWithValue("@change", Convert.ToDecimal(order_Change.Text));
                                cmd.Parameters.AddWithValue("@odate", today);
                                cmd.Parameters.AddWithValue("@billNo", billNo);

                                cmd.ExecuteNonQuery();
                            }


                            string deletePurchase = "DELETE FROM Purchase WHERE CustomerID = @cID";
                            using (SqlCommand cmdDelete = new SqlCommand(deletePurchase, connect))
                            {
                                cmdDelete.Parameters.AddWithValue("@cID", idGen);
                                cmdDelete.ExecuteNonQuery();
                            }

                            MessageBox.Show("Paid Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void order_Cashamount_TextChanged(object sender, EventArgs e)
        {
        }
        private int rowIndex = 0;

        private void order_Printreceipt_Click(object sender, EventArgs e)
        {
            if (order_Cashamount.Text == "" || grid_placeorder.Rows.Count <= 0)
            {
                MessageBox.Show("Please order first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                printDocument1.BeginPrint += new PrintEventHandler(printDocument1_BeginPrint);

                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();

                if (checkConnection())
                {
                    try
                    {
                        connect.Open();

                        string deletePurchase = "DELETE FROM Purchase WHERE CustomerID = @cID";
                        using (SqlCommand cmdDelete = new SqlCommand(deletePurchase, connect))
                        {
                            cmdDelete.Parameters.AddWithValue("@cID", idGen);
                            cmdDelete.ExecuteNonQuery();
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

                clearFields();
            }
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            rowIndex = 0;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            displayTotalPrice();

            float y = 0;
            int count = 0;
            int colWidth = 100;
            int headerMargin = 8;
            int tableMargin = 5;

            Font font = new Font("Arial", 7);
            Font bold = new Font("Arial", 7, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font labelFont = new Font("Arial", 7, FontStyle.Bold);

            float margin = e.MarginBounds.Top;

            StringFormat alignCenter = new StringFormat();
            alignCenter.Alignment = StringAlignment.Center;
            alignCenter.LineAlignment = StringAlignment.Center;

            string headerText = "Funtilon Hardware and Construction Supplies\r\n";
            y = (margin + count * headerFont.GetHeight(e.Graphics) + headerMargin);
            e.Graphics.DrawString(headerText, headerFont, Brushes.Black, e.MarginBounds.Left + (grid_placeorder.Columns.Count / 2) * colWidth, y, alignCenter);

            count++;
            y += tableMargin;

            string[] header = { "ProductID", "ProductName", "Price", "Quantity", "Unit", "Total", "OrderDate" };

            for (int q = 0; q < header.Length; q++)
            {
                y = margin + count * bold.GetHeight(e.Graphics) + headerMargin;
                e.Graphics.DrawString(header[q], bold, Brushes.Black, e.MarginBounds.Left + q * colWidth, y, alignCenter);
            }
            count++;

            float rSpace = e.MarginBounds.Bottom - y;

            while (rowIndex < grid_placeorder.Rows.Count)
            {
                DataGridViewRow row = grid_placeorder.Rows[rowIndex];

                for (int q = 0; q < grid_placeorder.Columns.Count; q++)
                {
                    object cellValue = row.Cells[q].Value;
                    string cell = (cellValue != null) ? cellValue.ToString() : string.Empty;

                    y = margin + count * font.GetHeight(e.Graphics) + tableMargin;
                    e.Graphics.DrawString(cell, font, Brushes.Black, e.MarginBounds.Left + q * colWidth, y, alignCenter);
                }
                count++;
                rowIndex++;

                if (y + font.GetHeight(e.Graphics) > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            int labelMargin = (int)Math.Min(rSpace, 200);

            DateTime today = DateTime.Today;


            float labelX = e.MarginBounds.Right - e.Graphics.MeasureString("--------------------------", labelFont).Width;

            y = e.MarginBounds.Bottom - labelMargin - labelFont.GetHeight(e.Graphics);

            e.Graphics.DrawString("Total Price: \t₱" + totalPrice + "\nAmount: \t₱" + order_Cashamount.Text.Trim()
                + "\n\t\t-------------------\nChange: \t₱" + order_Change.Text.Trim(), labelFont, Brushes.Black, labelX, y);

            labelMargin = (int)Math.Min(rSpace, -40);

            string labelText = today.ToString();
            y = e.MarginBounds.Bottom - labelMargin - labelFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(labelText, labelFont, Brushes.Black, e.MarginBounds.Right -
                e.Graphics.MeasureString("-------------------", labelFont).Width, y);

        }

        private void grid_placeorder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            grid_placeorder.ReadOnly = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedPaymentMethod = comboBox1.SelectedItem.ToString();

                panel_cash.Visible = false;
                panel_Gcash.Visible = false;
                panel_bank.Visible = false;

                if (selectedPaymentMethod == "Cash")
                {
                    panel_cash.Visible = true;

                    order_Cashamount.Text = "";
                    order_Change.Text = "";
                }
                else if (selectedPaymentMethod == "Gcash" || selectedPaymentMethod == "Bank Transfer")
                {
                    panel_Gcash.Visible = selectedPaymentMethod == "Gcash";
                    panel_bank.Visible = selectedPaymentMethod == "Bank Transfer";

                    order_Cashamount.Text = order_Totalprice.Text;
                    order_Change.Text = "0";
                }
            }
        }

        private void placeorder_Load(object sender, EventArgs e)
        {
            panel_cash.Visible = false;
            panel_Gcash.Visible = false;
            panel_bank.Visible = false;

            displayOrders();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void order_Cashamount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    float getAmount = Convert.ToSingle(order_Cashamount.Text);
                    float getChange = (getAmount - totalPrice);

                    if (getChange <= -1)
                    {
                        order_Cashamount.Text = "";
                        order_Change.Text = "";
                    }
                    else
                    {
                        order_Change.Text = getChange.ToString("0.00");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    order_Cashamount.Text = "";
                    order_Change.Text = "";
                }
            }
        }
    }
}
