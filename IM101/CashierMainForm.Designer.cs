namespace IM101
{
    partial class CashierMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierMainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Day = new System.Windows.Forms.Label();
            this.placeorder_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logout_btn = new System.Windows.Forms.Button();
            this.customer_btn = new System.Windows.Forms.Button();
            this.cart_btn = new System.Windows.Forms.Button();
            this.products_btn = new System.Windows.Forms.Button();
            this.categories_btn = new System.Windows.Forms.Button();
            this.dashboard_btn = new System.Windows.Forms.Button();
            this.cashier = new System.Windows.Forms.Label();
            this.cashierCustomerForm1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dashboard1 = new IM101.dashboard();
            this.viewInventory1 = new IM101.viewInventory();
            this.viewLogs1 = new IM101.viewLogs();
            this.categories1 = new IM101.categories();
            this.products1 = new IM101.products();
            this.orders1 = new IM101.orders();
            this.placeorder1 = new IM101.placeorder();
            this.customers1 = new IM101.customers();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.cashierCustomerForm1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Brown;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Day);
            this.panel1.Location = new System.Drawing.Point(0, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1296, 38);
            this.panel1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1027, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cornsilk;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(339, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Funtilon Hardware and Contruction Supplies";
            // 
            // Day
            // 
            this.Day.AutoSize = true;
            this.Day.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Day.ForeColor = System.Drawing.Color.Cornsilk;
            this.Day.Location = new System.Drawing.Point(1059, 9);
            this.Day.Name = "Day";
            this.Day.Size = new System.Drawing.Size(182, 18);
            this.Day.TabIndex = 6;
            this.Day.Text = "Wednesday, May 30, 2024";
            this.Day.Click += new System.EventHandler(this.Day_Click);
            // 
            // placeorder_btn
            // 
            this.placeorder_btn.FlatAppearance.BorderSize = 0;
            this.placeorder_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.placeorder_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.placeorder_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.placeorder_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeorder_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.placeorder_btn.Location = new System.Drawing.Point(-2, 195);
            this.placeorder_btn.Name = "placeorder_btn";
            this.placeorder_btn.Size = new System.Drawing.Size(168, 42);
            this.placeorder_btn.TabIndex = 18;
            this.placeorder_btn.Text = "       Place Order";
            this.placeorder_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.placeorder_btn.UseVisualStyleBackColor = true;
            this.placeorder_btn.Click += new System.EventHandler(this.placeorder_btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Brown;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.placeorder_btn);
            this.panel2.Controls.Add(this.logout_btn);
            this.panel2.Controls.Add(this.customer_btn);
            this.panel2.Controls.Add(this.cart_btn);
            this.panel2.Controls.Add(this.products_btn);
            this.panel2.Controls.Add(this.categories_btn);
            this.panel2.Controls.Add(this.dashboard_btn);
            this.panel2.Location = new System.Drawing.Point(0, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(168, 622);
            this.panel2.TabIndex = 12;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // logout_btn
            // 
            this.logout_btn.BackColor = System.Drawing.Color.Maroon;
            this.logout_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.logout_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.logout_btn.Location = new System.Drawing.Point(19, 581);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(130, 29);
            this.logout_btn.TabIndex = 17;
            this.logout_btn.Text = "Logout";
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // customer_btn
            // 
            this.customer_btn.FlatAppearance.BorderSize = 0;
            this.customer_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.customer_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.customer_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customer_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.customer_btn.Location = new System.Drawing.Point(-2, 243);
            this.customer_btn.Name = "customer_btn";
            this.customer_btn.Size = new System.Drawing.Size(168, 42);
            this.customer_btn.TabIndex = 14;
            this.customer_btn.Text = "       Customer\'s Info";
            this.customer_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customer_btn.UseVisualStyleBackColor = true;
            this.customer_btn.Click += new System.EventHandler(this.customer_btn_Click);
            // 
            // cart_btn
            // 
            this.cart_btn.FlatAppearance.BorderSize = 0;
            this.cart_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.cart_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.cart_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cart_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cart_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cart_btn.Location = new System.Drawing.Point(-2, 147);
            this.cart_btn.Name = "cart_btn";
            this.cart_btn.Size = new System.Drawing.Size(168, 42);
            this.cart_btn.TabIndex = 13;
            this.cart_btn.Text = "       Cart";
            this.cart_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cart_btn.UseVisualStyleBackColor = true;
            this.cart_btn.Click += new System.EventHandler(this.cart_btn_Click);
            // 
            // products_btn
            // 
            this.products_btn.FlatAppearance.BorderSize = 0;
            this.products_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.products_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.products_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.products_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.products_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.products_btn.Location = new System.Drawing.Point(-2, 99);
            this.products_btn.Name = "products_btn";
            this.products_btn.Size = new System.Drawing.Size(168, 42);
            this.products_btn.TabIndex = 12;
            this.products_btn.Text = "       Products";
            this.products_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.products_btn.UseVisualStyleBackColor = true;
            this.products_btn.Click += new System.EventHandler(this.products_btn_Click);
            // 
            // categories_btn
            // 
            this.categories_btn.FlatAppearance.BorderSize = 0;
            this.categories_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.categories_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.categories_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categories_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categories_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.categories_btn.Location = new System.Drawing.Point(-2, 51);
            this.categories_btn.Name = "categories_btn";
            this.categories_btn.Size = new System.Drawing.Size(168, 42);
            this.categories_btn.TabIndex = 11;
            this.categories_btn.Text = "       Categories";
            this.categories_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.categories_btn.UseVisualStyleBackColor = true;
            this.categories_btn.Click += new System.EventHandler(this.categories_btn_Click);
            // 
            // dashboard_btn
            // 
            this.dashboard_btn.FlatAppearance.BorderSize = 0;
            this.dashboard_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.dashboard_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.dashboard_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboard_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_btn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dashboard_btn.Location = new System.Drawing.Point(-2, 3);
            this.dashboard_btn.Name = "dashboard_btn";
            this.dashboard_btn.Size = new System.Drawing.Size(168, 42);
            this.dashboard_btn.TabIndex = 10;
            this.dashboard_btn.Text = "       Dashboard";
            this.dashboard_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboard_btn.UseVisualStyleBackColor = true;
            this.dashboard_btn.Click += new System.EventHandler(this.dashboard_btn_Click);
            // 
            // cashier
            // 
            this.cashier.AutoSize = true;
            this.cashier.BackColor = System.Drawing.Color.Transparent;
            this.cashier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashier.ForeColor = System.Drawing.Color.Black;
            this.cashier.Location = new System.Drawing.Point(1017, 71);
            this.cashier.Name = "cashier";
            this.cashier.Size = new System.Drawing.Size(59, 16);
            this.cashier.TabIndex = 2;
            this.cashier.Text = "@Admin";
            // 
            // cashierCustomerForm1
            // 
            this.cashierCustomerForm1.BackColor = System.Drawing.Color.White;
            this.cashierCustomerForm1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cashierCustomerForm1.Controls.Add(this.dashboard1);
            this.cashierCustomerForm1.Controls.Add(this.viewInventory1);
            this.cashierCustomerForm1.Controls.Add(this.viewLogs1);
            this.cashierCustomerForm1.Controls.Add(this.categories1);
            this.cashierCustomerForm1.Controls.Add(this.products1);
            this.cashierCustomerForm1.Controls.Add(this.orders1);
            this.cashierCustomerForm1.Controls.Add(this.placeorder1);
            this.cashierCustomerForm1.Controls.Add(this.customers1);
            this.cashierCustomerForm1.Location = new System.Drawing.Point(174, 148);
            this.cashierCustomerForm1.Name = "cashierCustomerForm1";
            this.cashierCustomerForm1.Size = new System.Drawing.Size(1113, 515);
            this.cashierCustomerForm1.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Controls.Add(this.cashier);
            this.panel3.Location = new System.Drawing.Point(174, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1112, 100);
            this.panel3.TabIndex = 13;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1020, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(8, 8);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(160, 79);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(-1, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 42);
            this.button1.TabIndex = 19;
            this.button1.Text = "       Inventory";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(-2, 339);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 42);
            this.button2.TabIndex = 20;
            this.button2.Text = "       Logs";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dashboard1
            // 
            this.dashboard1.Location = new System.Drawing.Point(-2, -2);
            this.dashboard1.Name = "dashboard1";
            this.dashboard1.Size = new System.Drawing.Size(1113, 512);
            this.dashboard1.TabIndex = 7;
            // 
            // viewInventory1
            // 
            this.viewInventory1.BackColor = System.Drawing.Color.White;
            this.viewInventory1.Location = new System.Drawing.Point(-1, -2);
            this.viewInventory1.Name = "viewInventory1";
            this.viewInventory1.Size = new System.Drawing.Size(1115, 513);
            this.viewInventory1.TabIndex = 6;
            // 
            // viewLogs1
            // 
            this.viewLogs1.Location = new System.Drawing.Point(-2, -2);
            this.viewLogs1.Name = "viewLogs1";
            this.viewLogs1.Size = new System.Drawing.Size(1115, 513);
            this.viewLogs1.TabIndex = 5;
            // 
            // categories1
            // 
            this.categories1.Location = new System.Drawing.Point(-2, -2);
            this.categories1.Name = "categories1";
            this.categories1.Size = new System.Drawing.Size(1113, 512);
            this.categories1.TabIndex = 4;
            // 
            // products1
            // 
            this.products1.Location = new System.Drawing.Point(-2, -4);
            this.products1.Name = "products1";
            this.products1.Size = new System.Drawing.Size(1113, 512);
            this.products1.TabIndex = 3;
            // 
            // orders1
            // 
            this.orders1.Location = new System.Drawing.Point(-33, -9);
            this.orders1.Name = "orders1";
            this.orders1.Size = new System.Drawing.Size(1113, 512);
            this.orders1.TabIndex = 2;
            // 
            // placeorder1
            // 
            this.placeorder1.Location = new System.Drawing.Point(-2, -2);
            this.placeorder1.Name = "placeorder1";
            this.placeorder1.Size = new System.Drawing.Size(1113, 513);
            this.placeorder1.TabIndex = 1;
            // 
            // customers1
            // 
            this.customers1.Location = new System.Drawing.Point(-2, -2);
            this.customers1.Name = "customers1";
            this.customers1.Size = new System.Drawing.Size(1113, 512);
            this.customers1.TabIndex = 0;
            // 
            // CashierMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cashierCustomerForm1);
            this.Controls.Add(this.panel3);
            this.Name = "CashierMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cashier\'s Portal - Funtilon Hardware and Construction Supplies";
            this.Load += new System.EventHandler(this.CashierMainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.cashierCustomerForm1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Day;
        private System.Windows.Forms.Button placeorder_btn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Button customer_btn;
        private System.Windows.Forms.Button cart_btn;
        private System.Windows.Forms.Button products_btn;
        private System.Windows.Forms.Button categories_btn;
        private System.Windows.Forms.Button dashboard_btn;
        private System.Windows.Forms.Label cashier;
        private System.Windows.Forms.Panel cashierCustomerForm1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private customers customers1;
        private categories categories1;
        private products products1;
        private orders orders1;
        private placeorder placeorder1;
        private dashboard dashboard1;
        private viewInventory viewInventory1;
        private viewLogs viewLogs1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}