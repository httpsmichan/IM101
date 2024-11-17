namespace IM101
{
    partial class orders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.order_removebtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.enterQty = new System.Windows.Forms.TextBox();
            this.enterprodID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.order_addbtn = new System.Windows.Forms.Button();
            this.order_price = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.order_Remstock = new System.Windows.Forms.Label();
            this.order_Totalprice = new System.Windows.Forms.Label();
            this.order_clearbtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.order_prodName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.order_Gridview1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.order_Gridview1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // order_removebtn
            // 
            this.order_removebtn.BackColor = System.Drawing.Color.Firebrick;
            this.order_removebtn.ForeColor = System.Drawing.Color.White;
            this.order_removebtn.Location = new System.Drawing.Point(237, 457);
            this.order_removebtn.Name = "order_removebtn";
            this.order_removebtn.Size = new System.Drawing.Size(123, 38);
            this.order_removebtn.TabIndex = 49;
            this.order_removebtn.Text = "Remove";
            this.order_removebtn.UseVisualStyleBackColor = false;
            this.order_removebtn.Click += new System.EventHandler(this.order_removebtn_Click);
            // 
            // label10
            // 
            this.label10.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(3, 330);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 20);
            this.label10.TabIndex = 47;
            this.label10.Text = "Total Price (₱):";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Location = new System.Drawing.Point(3, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(367, 272);
            this.dataGridView1.TabIndex = 47;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // enterQty
            // 
            this.enterQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterQty.Location = new System.Drawing.Point(523, 362);
            this.enterQty.Name = "enterQty";
            this.enterQty.Size = new System.Drawing.Size(152, 31);
            this.enterQty.TabIndex = 56;
            this.enterQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enterQty_KeyDown);
            // 
            // enterprodID
            // 
            this.enterprodID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterprodID.Location = new System.Drawing.Point(334, 362);
            this.enterprodID.Name = "enterprodID";
            this.enterprodID.Size = new System.Drawing.Size(152, 31);
            this.enterprodID.TabIndex = 55;
            this.enterprodID.TextChanged += new System.EventHandler(this.enterprodID_TextChanged);
            this.enterprodID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enterprodID_KeyDown);
            // 
            // label5
            // 
            this.label5.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(520, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 53;
            this.label5.Text = "Quantity";
            // 
            // label11
            // 
            this.label11.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(331, 341);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 20);
            this.label11.TabIndex = 52;
            this.label11.Text = "ProductID";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(695, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // order_addbtn
            // 
            this.order_addbtn.BackColor = System.Drawing.Color.Firebrick;
            this.order_addbtn.ForeColor = System.Drawing.Color.White;
            this.order_addbtn.Location = new System.Drawing.Point(530, 459);
            this.order_addbtn.Name = "order_addbtn";
            this.order_addbtn.Size = new System.Drawing.Size(176, 38);
            this.order_addbtn.TabIndex = 46;
            this.order_addbtn.Text = "Add to Cart";
            this.order_addbtn.UseVisualStyleBackColor = false;
            this.order_addbtn.Click += new System.EventHandler(this.order_addbtn_Click);
            // 
            // order_price
            // 
            this.order_price.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.order_price.AutoSize = true;
            this.order_price.BackColor = System.Drawing.Color.White;
            this.order_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.order_price.ForeColor = System.Drawing.Color.Black;
            this.order_price.Location = new System.Drawing.Point(98, 463);
            this.order_price.Name = "order_price";
            this.order_price.Size = new System.Drawing.Size(40, 18);
            this.order_price.TabIndex = 45;
            this.order_price.Text = "0.00";
            // 
            // label9
            // 
            this.label9.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(22, 463);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 18);
            this.label9.TabIndex = 44;
            this.label9.Text = "Price (₱):";
            // 
            // order_Remstock
            // 
            this.order_Remstock.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.order_Remstock.AutoSize = true;
            this.order_Remstock.BackColor = System.Drawing.Color.White;
            this.order_Remstock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.order_Remstock.ForeColor = System.Drawing.Color.Black;
            this.order_Remstock.Location = new System.Drawing.Point(151, 436);
            this.order_Remstock.Name = "order_Remstock";
            this.order_Remstock.Size = new System.Drawing.Size(26, 18);
            this.order_Remstock.TabIndex = 43;
            this.order_Remstock.Text = "00";
            this.order_Remstock.Click += new System.EventHandler(this.order_Remstock_Click);
            // 
            // order_Totalprice
            // 
            this.order_Totalprice.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.order_Totalprice.AutoSize = true;
            this.order_Totalprice.BackColor = System.Drawing.Color.Transparent;
            this.order_Totalprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.order_Totalprice.ForeColor = System.Drawing.Color.Black;
            this.order_Totalprice.Location = new System.Drawing.Point(3, 6);
            this.order_Totalprice.Name = "order_Totalprice";
            this.order_Totalprice.Size = new System.Drawing.Size(75, 33);
            this.order_Totalprice.TabIndex = 48;
            this.order_Totalprice.Text = "0.00";
            // 
            // order_clearbtn
            // 
            this.order_clearbtn.BackColor = System.Drawing.Color.Firebrick;
            this.order_clearbtn.ForeColor = System.Drawing.Color.White;
            this.order_clearbtn.Location = new System.Drawing.Point(108, 457);
            this.order_clearbtn.Name = "order_clearbtn";
            this.order_clearbtn.Size = new System.Drawing.Size(123, 38);
            this.order_clearbtn.TabIndex = 51;
            this.order_clearbtn.Text = "Clear";
            this.order_clearbtn.UseVisualStyleBackColor = false;
            this.order_clearbtn.Click += new System.EventHandler(this.order_clearbtn_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.order_Totalprice);
            this.panel3.Location = new System.Drawing.Point(121, 319);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(190, 47);
            this.panel3.TabIndex = 50;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.order_clearbtn);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.order_removebtn);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(733, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 509);
            this.panel2.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 48;
            this.label2.Text = "Cart";
            // 
            // label7
            // 
            this.label7.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(20, 436);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 18);
            this.label7.TabIndex = 42;
            this.label7.Text = "Remaining Stock:";
            // 
            // order_prodName
            // 
            this.order_prodName.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.order_prodName.AutoSize = true;
            this.order_prodName.BackColor = System.Drawing.Color.White;
            this.order_prodName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.order_prodName.ForeColor = System.Drawing.Color.Black;
            this.order_prodName.Location = new System.Drawing.Point(131, 410);
            this.order_prodName.Name = "order_prodName";
            this.order_prodName.Size = new System.Drawing.Size(116, 18);
            this.order_prodName.TabIndex = 41;
            this.order_prodName.Text = "Product Name";
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 410);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 40;
            this.label1.Text = "Product Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(16, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 18);
            this.label4.TabIndex = 34;
            this.label4.Text = "Browse Product";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox1.Location = new System.Drawing.Point(431, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 27);
            this.textBox1.TabIndex = 29;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 18);
            this.label3.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(3, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(170, 18);
            this.label8.TabIndex = 28;
            this.label8.Text = "All Available Products";
            // 
            // order_Gridview1
            // 
            this.order_Gridview1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.order_Gridview1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.order_Gridview1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.order_Gridview1.DefaultCellStyle = dataGridViewCellStyle8;
            this.order_Gridview1.Location = new System.Drawing.Point(3, 43);
            this.order_Gridview1.Name = "order_Gridview1";
            this.order_Gridview1.Size = new System.Drawing.Size(716, 272);
            this.order_Gridview1.TabIndex = 27;
            this.order_Gridview1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.order_Gridview1_CellClick);
            this.order_Gridview1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.order_Gridview1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.enterQty);
            this.panel1.Controls.Add(this.enterprodID);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.order_addbtn);
            this.panel1.Controls.Add(this.order_price);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.order_Remstock);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.order_prodName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.order_Gridview1);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 506);
            this.panel1.TabIndex = 48;
            // 
            // orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "orders";
            this.Size = new System.Drawing.Size(1113, 512);
            this.Load += new System.EventHandler(this.orders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.order_Gridview1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button order_removebtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox enterQty;
        private System.Windows.Forms.TextBox enterprodID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button order_addbtn;
        private System.Windows.Forms.Label order_price;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label order_Remstock;
        private System.Windows.Forms.Label order_Totalprice;
        private System.Windows.Forms.Button order_clearbtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label order_prodName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView order_Gridview1;
        private System.Windows.Forms.Panel panel1;
    }
}
