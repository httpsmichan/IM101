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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            displayUsername();
        }

        public void displayUsername()
        {

            string username = Form1.username.Substring(0, 1).ToUpper() + Form1.username.Substring(1);
            admin.Text = ("@" + username);

        }
        public interface IRefreshable
        {
            void refreshData();
        }

        private void ShowControl(UserControl visibleControl)
        {
            dashboard1.Visible = false;
            products1.Visible = false;
            users1.Visible = false;
            customers1.Visible = false;
            categories1.Visible = false;
            inventory1.Visible = false;
            supply1.Visible = false;
            supplier1.Visible = false;
            logs1.Visible = false;

            visibleControl.Visible = true;

            if (visibleControl is IRefreshable refreshableForm)
            {
                refreshableForm.refreshData();
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

        private void supply_btn_Click(object sender, EventArgs e)
        {
            ShowControl(supply1);

            supply supplyForm = supply1 as supply;

            if (supplyForm != null)
            {
                supplyForm.refreshData();
            }
        }

        private void products_btn_Click(object sender, EventArgs e)
        {
            ShowControl(products1);

            products prodForm = products1 as products;

            if (prodForm != null)
            {
                prodForm.refreshData();
            }
        }

        private void staff_btn_Click(object sender, EventArgs e)
        {
            ShowControl(users1);

            users staffForm = users1 as users;

            if (staffForm != null)
            {
                staffForm.refreshData();
            }
        }

        private void supplier_btn_Click(object sender, EventArgs e)
        {
            ShowControl(supplier1);

            supplier supplierForm = supplier1 as supplier;

            if (supplierForm != null)
            {
                supplierForm.refreshData();
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

        private void inventory_btn_Click(object sender, EventArgs e)
        {
            ShowControl(inventory1);

            inventory invForm = inventory1 as inventory;

            if (invForm != null)
            {
                invForm.refreshData();
            }
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

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout? ", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
        }


        private void logs_Click(object sender, EventArgs e)
        {
            ShowControl(logs1);

            logs logForm = logs1 as logs;

            if (logForm != null)
            {
                logForm.refreshData();
            }
        }

        private void admin_Click(object sender, EventArgs e)
        {

        }

        private void Day_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;

            string formattedDate = currentDate.ToString("dddd, MMMM d, yyyy");

            Day.Text = formattedDate;
        }
    }
}
