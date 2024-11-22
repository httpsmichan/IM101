using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IM101
{
    public partial class CashierMainForm : Form
    {
        public CashierMainForm()
        {
            InitializeComponent();
            displayUsername();
        }

        public void displayUsername()
        {
            string username = Form1.username.Substring(0, 1).ToUpper() + Form1.username.Substring(1);
            cashier.Text = ("@" + username);

        }

        public interface IRefreshable
        {
            void refreshData();
        }

        private void ShowControl(UserControl visibleControl)
        {
            dashboard1.Visible = false;
            products1.Visible = false;
            customers1.Visible = false;
            categories1.Visible = false;
            placeorder1.Visible = false;
            orders1.Visible = false;
            viewLogs1.Visible = false;
            viewInventory1.Visible = false;

            visibleControl.Visible = true;

            if (visibleControl is IRefreshable refreshableForm)
            {
                refreshableForm.refreshData();
            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout? ", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            ShowControl(dashboard1);

            dashboard dashForm = dashboard1 as dashboard;

            if (dashForm != null)
            {
                dashForm.refreshData();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void categories_btn_Click(object sender, EventArgs e)
        {
            ShowControl(categories1);

            categories catForm = categories1 as categories;

            if (catForm != null)
            {
                catForm.refreshData();
            }
        }

        private void products_btn_Click(object sender, EventArgs e)
        {
            ShowControl(products1);

            products productForm = products1 as products;

            if (productForm != null)
            {
                productForm.refreshData();
            }
        }

        private void cart_btn_Click(object sender, EventArgs e)
        {
            ShowControl(orders1);

            orders orderForm = orders1 as orders;

            if (orderForm != null)
            {
                orderForm.refreshData();
            }
        }

        private void placeorder_btn_Click(object sender, EventArgs e)
        {
            ShowControl(placeorder1);

            placeorder placeorderForm = placeorder1 as placeorder;

            if (placeorderForm != null)
            {
                placeorderForm.refreshData();
            }
        }

        private void customer_btn_Click(object sender, EventArgs e)
        {
            ShowControl(customers1);

            customers customerForm = customers1 as customers;

            if (customerForm != null)
            {
                customerForm.refreshData();
            }
        }

        private void CashierMainForm_Load(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;

            string formattedDate = currentDate.ToString("dddd, MMMM d, yyyy");

            Day.Text = formattedDate;
        }

        private void Day_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowControl(viewInventory1);

            viewInventory viewinv = viewInventory1 as viewInventory;

            if (viewinv != null)
            {
                viewinv.refreshData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowControl(viewLogs1);

            viewLogs viewlog = viewLogs1 as viewLogs;

            if (viewlog != null)
            {
                viewlog.refreshData();
            }
        }
    }
}
