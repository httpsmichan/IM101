namespace IM101
{
    partial class placeorder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(placeorder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.order_Totalprice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grid_placeorder = new System.Windows.Forms.DataGridView();
            this.order_Printreceipt = new System.Windows.Forms.Button();
            this.order_placeorderbtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.order_Cashamount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.order_Change = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel_bank = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel_Gcash = new System.Windows.Forms.Panel();
            this.panel_cash = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grid_placeorder)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel_bank.SuspendLayout();
            this.panel_Gcash.SuspendLayout();
            this.panel_cash.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 47;
            this.label1.Text = "Place Order";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 55);
            this.label3.TabIndex = 1;
            this.label3.Text = "₱";
            // 
            // order_Totalprice
            // 
            this.order_Totalprice.AutoSize = true;
            this.order_Totalprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.order_Totalprice.Location = new System.Drawing.Point(66, -1);
            this.order_Totalprice.Name = "order_Totalprice";
            this.order_Totalprice.Size = new System.Drawing.Size(122, 55);
            this.order_Totalprice.TabIndex = 0;
            this.order_Totalprice.Text = "0.00";
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.TabIndex = 54;
            this.label2.Text = "Select Payment Method";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Cash",
            "Gcash",
            "Bank Transfer"});
            this.comboBox1.Location = new System.Drawing.Point(6, 338);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(243, 28);
            this.comboBox1.TabIndex = 53;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // grid_placeorder
            // 
            this.grid_placeorder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_placeorder.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_placeorder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_placeorder.DefaultCellStyle = dataGridViewCellStyle12;
            this.grid_placeorder.Location = new System.Drawing.Point(6, 35);
            this.grid_placeorder.Name = "grid_placeorder";
            this.grid_placeorder.Size = new System.Drawing.Size(1098, 276);
            this.grid_placeorder.TabIndex = 52;
            this.grid_placeorder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_placeorder_CellClick);
            this.grid_placeorder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_placeorder_CellContentClick);
            // 
            // order_Printreceipt
            // 
            this.order_Printreceipt.BackColor = System.Drawing.Color.Firebrick;
            this.order_Printreceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.order_Printreceipt.ForeColor = System.Drawing.Color.White;
            this.order_Printreceipt.Location = new System.Drawing.Point(909, 450);
            this.order_Printreceipt.Name = "order_Printreceipt";
            this.order_Printreceipt.Size = new System.Drawing.Size(176, 38);
            this.order_Printreceipt.TabIndex = 51;
            this.order_Printreceipt.Text = "Print Reciept";
            this.order_Printreceipt.UseVisualStyleBackColor = false;
            this.order_Printreceipt.Click += new System.EventHandler(this.order_Printreceipt_Click);
            // 
            // order_placeorderbtn
            // 
            this.order_placeorderbtn.BackColor = System.Drawing.Color.Firebrick;
            this.order_placeorderbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.order_placeorderbtn.ForeColor = System.Drawing.Color.White;
            this.order_placeorderbtn.Location = new System.Drawing.Point(909, 404);
            this.order_placeorderbtn.Name = "order_placeorderbtn";
            this.order_placeorderbtn.Size = new System.Drawing.Size(176, 38);
            this.order_placeorderbtn.TabIndex = 50;
            this.order_placeorderbtn.Text = "Pay Order/s";
            this.order_placeorderbtn.UseVisualStyleBackColor = false;
            this.order_placeorderbtn.Click += new System.EventHandler(this.order_placeorderbtn_Click);
            // 
            // label10
            // 
            this.label10.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(28, 389);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 20);
            this.label10.TabIndex = 49;
            this.label10.Text = "Total Price (₱):";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.order_Totalprice);
            this.panel2.Location = new System.Drawing.Point(31, 418);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 59);
            this.panel2.TabIndex = 48;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // order_Cashamount
            // 
            this.order_Cashamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.order_Cashamount.Location = new System.Drawing.Point(163, 3);
            this.order_Cashamount.Name = "order_Cashamount";
            this.order_Cashamount.Size = new System.Drawing.Size(185, 31);
            this.order_Cashamount.TabIndex = 35;
            this.order_Cashamount.TextChanged += new System.EventHandler(this.order_Cashamount_TextChanged);
            this.order_Cashamount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.order_Cashamount_KeyDown);
            // 
            // label12
            // 
            this.label12.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(22, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 20);
            this.label12.TabIndex = 36;
            this.label12.Text = "Change (₱): ";
            // 
            // label8
            // 
            this.label8.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(77, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 20);
            this.label8.TabIndex = 37;
            this.label8.Text = "Bank #:";
            // 
            // label11
            // 
            this.label11.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(22, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 20);
            this.label11.TabIndex = 37;
            this.label11.Text = "Cash Amount (₱):";
            // 
            // order_Change
            // 
            this.order_Change.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.order_Change.AutoSize = true;
            this.order_Change.BackColor = System.Drawing.Color.White;
            this.order_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.order_Change.ForeColor = System.Drawing.Color.Black;
            this.order_Change.Location = new System.Drawing.Point(126, 53);
            this.order_Change.Name = "order_Change";
            this.order_Change.Size = new System.Drawing.Size(58, 25);
            this.order_Change.TabIndex = 38;
            this.order_Change.Text = "0.00";
            // 
            // label16
            // 
            this.label16.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(155, 126);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(258, 29);
            this.label16.TabIndex = 44;
            this.label16.Text = "4 0 1 8 1 0 0 3 3 3 1 8";
            // 
            // label15
            // 
            this.label15.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(77, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 20);
            this.label15.TabIndex = 43;
            this.label15.Text = "Bank #:";
            // 
            // label14
            // 
            this.label14.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(77, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(329, 20);
            this.label14.TabIndex = 42;
            this.label14.Text = "Funtilon Hardware and Construction Supplies";
            // 
            // label9
            // 
            this.label9.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(77, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 20);
            this.label9.TabIndex = 41;
            this.label9.Text = "Anne Rea Funtilon";
            // 
            // label7
            // 
            this.label7.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(155, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(258, 29);
            this.label7.TabIndex = 40;
            this.label7.Text = "4 0 1 8 1 0 0 3 5 0 0 6";
            // 
            // label13
            // 
            this.label13.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Window;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(10, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 25);
            this.label13.TabIndex = 39;
            this.label13.Text = "PNB ";
            // 
            // panel_bank
            // 
            this.panel_bank.Controls.Add(this.label16);
            this.panel_bank.Controls.Add(this.label15);
            this.panel_bank.Controls.Add(this.label14);
            this.panel_bank.Controls.Add(this.label9);
            this.panel_bank.Controls.Add(this.label7);
            this.panel_bank.Controls.Add(this.label13);
            this.panel_bank.Controls.Add(this.label8);
            this.panel_bank.Location = new System.Drawing.Point(383, 324);
            this.panel_bank.Name = "panel_bank";
            this.panel_bank.Size = new System.Drawing.Size(478, 164);
            this.panel_bank.TabIndex = 57;
            // 
            // label18
            // 
            this.label18.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(180, 47);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(167, 29);
            this.label18.TabIndex = 40;
            this.label18.Text = "09276172269";
            // 
            // label19
            // 
            this.label19.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.Window;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Blue;
            this.label19.Location = new System.Drawing.Point(10, 6);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 25);
            this.label19.TabIndex = 39;
            this.label19.Text = "GCash";
            // 
            // label20
            // 
            this.label20.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(102, 51);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 20);
            this.label20.TabIndex = 37;
            this.label20.Text = "GCash #:";
            // 
            // panel_Gcash
            // 
            this.panel_Gcash.Controls.Add(this.label18);
            this.panel_Gcash.Controls.Add(this.label19);
            this.panel_Gcash.Controls.Add(this.label20);
            this.panel_Gcash.Location = new System.Drawing.Point(382, 357);
            this.panel_Gcash.Name = "panel_Gcash";
            this.panel_Gcash.Size = new System.Drawing.Size(414, 148);
            this.panel_Gcash.TabIndex = 58;
            // 
            // panel_cash
            // 
            this.panel_cash.Controls.Add(this.order_Cashamount);
            this.panel_cash.Controls.Add(this.label12);
            this.panel_cash.Controls.Add(this.label11);
            this.panel_cash.Controls.Add(this.order_Change);
            this.panel_cash.Location = new System.Drawing.Point(427, 389);
            this.panel_cash.Name = "panel_cash";
            this.panel_cash.Size = new System.Drawing.Size(382, 84);
            this.panel_cash.TabIndex = 55;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel_Gcash);
            this.panel1.Controls.Add(this.panel_bank);
            this.panel1.Controls.Add(this.panel_cash);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.grid_placeorder);
            this.panel1.Controls.Add(this.order_Printreceipt);
            this.panel1.Controls.Add(this.order_placeorderbtn);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1107, 507);
            this.panel1.TabIndex = 5;
            // 
            // placeorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "placeorder";
            this.Size = new System.Drawing.Size(1113, 513);
            this.Load += new System.EventHandler(this.placeorder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_placeorder)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel_bank.ResumeLayout(false);
            this.panel_bank.PerformLayout();
            this.panel_Gcash.ResumeLayout(false);
            this.panel_Gcash.PerformLayout();
            this.panel_cash.ResumeLayout(false);
            this.panel_cash.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label order_Totalprice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView grid_placeorder;
        private System.Windows.Forms.Button order_Printreceipt;
        private System.Windows.Forms.Button order_placeorderbtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.TextBox order_Cashamount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label order_Change;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel_bank;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel_Gcash;
        private System.Windows.Forms.Panel panel_cash;
        private System.Windows.Forms.Panel panel1;
    }
}
