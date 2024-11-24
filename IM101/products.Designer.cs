namespace IM101
{
    partial class products
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.addprod_removebtn = new System.Windows.Forms.Button();
            this.addprod_clearbtn = new System.Windows.Forms.Button();
            this.addprod_updatebtn = new System.Windows.Forms.Button();
            this.addprod_addbtn = new System.Windows.Forms.Button();
            this.addprod_status = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addprod_category = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addprod_price = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.addprod_name = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.product_search = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.addprod_dataGrid = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addprod_dataGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addprod_removebtn
            // 
            this.addprod_removebtn.BackColor = System.Drawing.Color.Firebrick;
            this.addprod_removebtn.ForeColor = System.Drawing.Color.White;
            this.addprod_removebtn.Location = new System.Drawing.Point(107, 455);
            this.addprod_removebtn.Name = "addprod_removebtn";
            this.addprod_removebtn.Size = new System.Drawing.Size(90, 38);
            this.addprod_removebtn.TabIndex = 46;
            this.addprod_removebtn.Text = "Remove";
            this.addprod_removebtn.UseVisualStyleBackColor = false;
            this.addprod_removebtn.Click += new System.EventHandler(this.addprod_removebtn_Click);
            // 
            // addprod_clearbtn
            // 
            this.addprod_clearbtn.BackColor = System.Drawing.Color.Firebrick;
            this.addprod_clearbtn.ForeColor = System.Drawing.Color.White;
            this.addprod_clearbtn.Location = new System.Drawing.Point(11, 455);
            this.addprod_clearbtn.Name = "addprod_clearbtn";
            this.addprod_clearbtn.Size = new System.Drawing.Size(90, 38);
            this.addprod_clearbtn.TabIndex = 45;
            this.addprod_clearbtn.Text = "Clear";
            this.addprod_clearbtn.UseVisualStyleBackColor = false;
            this.addprod_clearbtn.Click += new System.EventHandler(this.addprod_clearbtn_Click);
            // 
            // addprod_updatebtn
            // 
            this.addprod_updatebtn.BackColor = System.Drawing.Color.Firebrick;
            this.addprod_updatebtn.ForeColor = System.Drawing.Color.White;
            this.addprod_updatebtn.Location = new System.Drawing.Point(107, 397);
            this.addprod_updatebtn.Name = "addprod_updatebtn";
            this.addprod_updatebtn.Size = new System.Drawing.Size(90, 38);
            this.addprod_updatebtn.TabIndex = 44;
            this.addprod_updatebtn.Text = "Update";
            this.addprod_updatebtn.UseVisualStyleBackColor = false;
            this.addprod_updatebtn.Click += new System.EventHandler(this.addprod_updatebtn_Click);
            // 
            // addprod_addbtn
            // 
            this.addprod_addbtn.BackColor = System.Drawing.Color.Firebrick;
            this.addprod_addbtn.ForeColor = System.Drawing.Color.White;
            this.addprod_addbtn.Location = new System.Drawing.Point(11, 397);
            this.addprod_addbtn.Name = "addprod_addbtn";
            this.addprod_addbtn.Size = new System.Drawing.Size(90, 38);
            this.addprod_addbtn.TabIndex = 43;
            this.addprod_addbtn.Text = "Add";
            this.addprod_addbtn.UseVisualStyleBackColor = false;
            this.addprod_addbtn.Click += new System.EventHandler(this.addprod_addbtn_Click);
            // 
            // addprod_status
            // 
            this.addprod_status.FormattingEnabled = true;
            this.addprod_status.Items.AddRange(new object[] {
            "Available",
            "Not Available"});
            this.addprod_status.Location = new System.Drawing.Point(24, 278);
            this.addprod_status.Name = "addprod_status";
            this.addprod_status.Size = new System.Drawing.Size(157, 21);
            this.addprod_status.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(21, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "Status";
            // 
            // addprod_category
            // 
            this.addprod_category.FormattingEnabled = true;
            this.addprod_category.Items.AddRange(new object[] {
            "Admin",
            "Cashier"});
            this.addprod_category.Location = new System.Drawing.Point(24, 211);
            this.addprod_category.Name = "addprod_category";
            this.addprod_category.Size = new System.Drawing.Size(154, 21);
            this.addprod_category.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Manage Product";
            // 
            // addprod_price
            // 
            this.addprod_price.Location = new System.Drawing.Point(24, 145);
            this.addprod_price.Name = "addprod_price";
            this.addprod_price.Size = new System.Drawing.Size(154, 20);
            this.addprod_price.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Category";
            // 
            // label7
            // 
            this.label7.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(24, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "Price";
            // 
            // label5
            // 
            this.label5.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(21, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "Product Name";
            // 
            // addprod_name
            // 
            this.addprod_name.Location = new System.Drawing.Point(24, 83);
            this.addprod_name.Name = "addprod_name";
            this.addprod_name.Size = new System.Drawing.Size(154, 20);
            this.addprod_name.TabIndex = 35;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IM101.Properties.Resources.loupe;
            this.pictureBox1.Location = new System.Drawing.Point(868, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // product_search
            // 
            this.product_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.product_search.ForeColor = System.Drawing.SystemColors.GrayText;
            this.product_search.Location = new System.Drawing.Point(602, 10);
            this.product_search.Name = "product_search";
            this.product_search.Size = new System.Drawing.Size(288, 27);
            this.product_search.TabIndex = 51;
            this.product_search.TextChanged += new System.EventHandler(this.product_search_TextChanged);
            this.product_search.Enter += new System.EventHandler(this.product_search_Enter);
            this.product_search.Leave += new System.EventHandler(this.product_search_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(3, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 18);
            this.label8.TabIndex = 28;
            this.label8.Text = "Products";
            // 
            // addprod_dataGrid
            // 
            this.addprod_dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.addprod_dataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.addprod_dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.addprod_dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.addprod_dataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.addprod_dataGrid.Location = new System.Drawing.Point(6, 43);
            this.addprod_dataGrid.Name = "addprod_dataGrid";
            this.addprod_dataGrid.Size = new System.Drawing.Size(884, 463);
            this.addprod_dataGrid.TabIndex = 27;
            this.addprod_dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.addprod_dataGrid_CellClick);
            this.addprod_dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.addprod_dataGrid_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.addprod_removebtn);
            this.panel2.Controls.Add(this.addprod_clearbtn);
            this.panel2.Controls.Add(this.addprod_updatebtn);
            this.panel2.Controls.Add(this.addprod_addbtn);
            this.panel2.Controls.Add(this.addprod_status);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.addprod_category);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.addprod_price);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.addprod_name);
            this.panel2.Location = new System.Drawing.Point(905, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 509);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.product_search);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.addprod_dataGrid);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 509);
            this.panel1.TabIndex = 2;
            // 
            // products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "products";
            this.Size = new System.Drawing.Size(1113, 512);
            this.Load += new System.EventHandler(this.products_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addprod_dataGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addprod_removebtn;
        private System.Windows.Forms.Button addprod_clearbtn;
        private System.Windows.Forms.Button addprod_updatebtn;
        private System.Windows.Forms.Button addprod_addbtn;
        private System.Windows.Forms.ComboBox addprod_status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox addprod_category;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addprod_price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addprod_name;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox product_search;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView addprod_dataGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}
