namespace IM101
{
    partial class supply
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
            this.supply_supplierID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.supply_upbtn = new System.Windows.Forms.Button();
            this.remove_removebtn = new System.Windows.Forms.Button();
            this.supply_clearbtn = new System.Windows.Forms.Button();
            this.supply_addbtn = new System.Windows.Forms.Button();
            this.supply_status = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.supply_totalcost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.supply_unitcost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.supply_prodID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.supply_prodname = new System.Windows.Forms.TextBox();
            this.supply_qtys = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.supply_grid = new System.Windows.Forms.DataGridView();
            this.supply_search = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supply_grid)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // supply_supplierID
            // 
            this.supply_supplierID.Location = new System.Drawing.Point(19, 61);
            this.supply_supplierID.Name = "supply_supplierID";
            this.supply_supplierID.Size = new System.Drawing.Size(154, 20);
            this.supply_supplierID.TabIndex = 51;
            // 
            // label9
            // 
            this.label9.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(16, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 16);
            this.label9.TabIndex = 50;
            this.label9.Text = "Supplier ID";
            // 
            // supply_upbtn
            // 
            this.supply_upbtn.BackColor = System.Drawing.Color.Firebrick;
            this.supply_upbtn.ForeColor = System.Drawing.Color.White;
            this.supply_upbtn.Location = new System.Drawing.Point(107, 397);
            this.supply_upbtn.Name = "supply_upbtn";
            this.supply_upbtn.Size = new System.Drawing.Size(90, 38);
            this.supply_upbtn.TabIndex = 63;
            this.supply_upbtn.Text = "Update";
            this.supply_upbtn.UseVisualStyleBackColor = false;
            this.supply_upbtn.Click += new System.EventHandler(this.supply_upbtn_Click);
            // 
            // remove_removebtn
            // 
            this.remove_removebtn.BackColor = System.Drawing.Color.Firebrick;
            this.remove_removebtn.ForeColor = System.Drawing.Color.White;
            this.remove_removebtn.Location = new System.Drawing.Point(107, 455);
            this.remove_removebtn.Name = "remove_removebtn";
            this.remove_removebtn.Size = new System.Drawing.Size(90, 38);
            this.remove_removebtn.TabIndex = 62;
            this.remove_removebtn.Text = "Remove";
            this.remove_removebtn.UseVisualStyleBackColor = false;
            this.remove_removebtn.Click += new System.EventHandler(this.remove_removebtn_Click);
            // 
            // supply_clearbtn
            // 
            this.supply_clearbtn.BackColor = System.Drawing.Color.Firebrick;
            this.supply_clearbtn.ForeColor = System.Drawing.Color.White;
            this.supply_clearbtn.Location = new System.Drawing.Point(11, 455);
            this.supply_clearbtn.Name = "supply_clearbtn";
            this.supply_clearbtn.Size = new System.Drawing.Size(90, 38);
            this.supply_clearbtn.TabIndex = 61;
            this.supply_clearbtn.Text = "Clear";
            this.supply_clearbtn.UseVisualStyleBackColor = false;
            this.supply_clearbtn.Click += new System.EventHandler(this.supply_clearbtn_Click);
            // 
            // supply_addbtn
            // 
            this.supply_addbtn.BackColor = System.Drawing.Color.Firebrick;
            this.supply_addbtn.ForeColor = System.Drawing.Color.White;
            this.supply_addbtn.Location = new System.Drawing.Point(11, 397);
            this.supply_addbtn.Name = "supply_addbtn";
            this.supply_addbtn.Size = new System.Drawing.Size(90, 38);
            this.supply_addbtn.TabIndex = 60;
            this.supply_addbtn.Text = "Add";
            this.supply_addbtn.UseVisualStyleBackColor = false;
            this.supply_addbtn.Click += new System.EventHandler(this.supply_addbtn_Click);
            // 
            // supply_status
            // 
            this.supply_status.FormattingEnabled = true;
            this.supply_status.Items.AddRange(new object[] {
            "Order Placed",
            "Received"});
            this.supply_status.Location = new System.Drawing.Point(22, 332);
            this.supply_status.Name = "supply_status";
            this.supply_status.Size = new System.Drawing.Size(154, 21);
            this.supply_status.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(22, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 58;
            this.label6.Text = "Status";
            // 
            // supply_totalcost
            // 
            this.supply_totalcost.Location = new System.Drawing.Point(22, 285);
            this.supply_totalcost.Name = "supply_totalcost";
            this.supply_totalcost.Size = new System.Drawing.Size(154, 20);
            this.supply_totalcost.TabIndex = 57;
            this.supply_totalcost.TextChanged += new System.EventHandler(this.supply_totalcost_TextChanged);
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "TotalCost";
            // 
            // supply_unitcost
            // 
            this.supply_unitcost.Location = new System.Drawing.Point(22, 240);
            this.supply_unitcost.Name = "supply_unitcost";
            this.supply_unitcost.Size = new System.Drawing.Size(154, 20);
            this.supply_unitcost.TabIndex = 55;
            this.supply_unitcost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.supply_unitcost_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 31;
            this.label1.Text = "Manage Supply";
            // 
            // supply_prodID
            // 
            this.supply_prodID.Location = new System.Drawing.Point(22, 105);
            this.supply_prodID.Name = "supply_prodID";
            this.supply_prodID.Size = new System.Drawing.Size(154, 20);
            this.supply_prodID.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 48;
            this.label3.Text = "Product ID";
            // 
            // supply_prodname
            // 
            this.supply_prodname.Location = new System.Drawing.Point(22, 149);
            this.supply_prodname.Name = "supply_prodname";
            this.supply_prodname.Size = new System.Drawing.Size(154, 20);
            this.supply_prodname.TabIndex = 52;
            // 
            // supply_qtys
            // 
            this.supply_qtys.Location = new System.Drawing.Point(22, 194);
            this.supply_qtys.Name = "supply_qtys";
            this.supply_qtys.Size = new System.Drawing.Size(154, 20);
            this.supply_qtys.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(19, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 51;
            this.label5.Text = "Product Name";
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 50;
            this.label2.Text = "UnitCost";
            // 
            // label7
            // 
            this.label7.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(22, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 53;
            this.label7.Text = "QtySupplied";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(864, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // supply_grid
            // 
            this.supply_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.supply_grid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.supply_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.supply_grid.DefaultCellStyle = dataGridViewCellStyle6;
            this.supply_grid.Location = new System.Drawing.Point(3, 34);
            this.supply_grid.Name = "supply_grid";
            this.supply_grid.Size = new System.Drawing.Size(886, 463);
            this.supply_grid.TabIndex = 30;
            this.supply_grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.supply_grid_CellClick);
            this.supply_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.supply_grid_CellContentClick);
            // 
            // supply_search
            // 
            this.supply_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supply_search.ForeColor = System.Drawing.SystemColors.GrayText;
            this.supply_search.Location = new System.Drawing.Point(601, 3);
            this.supply_search.Name = "supply_search";
            this.supply_search.Size = new System.Drawing.Size(288, 27);
            this.supply_search.TabIndex = 64;
            this.supply_search.TextChanged += new System.EventHandler(this.supply_search_TextChanged);
            this.supply_search.Enter += new System.EventHandler(this.supply_search_Enter);
            this.supply_search.Leave += new System.EventHandler(this.supply_search_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(14, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 18);
            this.label8.TabIndex = 29;
            this.label8.Text = "Supply";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.supply_supplierID);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.supply_upbtn);
            this.panel2.Controls.Add(this.remove_removebtn);
            this.panel2.Controls.Add(this.supply_clearbtn);
            this.panel2.Controls.Add(this.supply_addbtn);
            this.panel2.Controls.Add(this.supply_status);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.supply_totalcost);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.supply_unitcost);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.supply_prodID);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.supply_prodname);
            this.panel2.Controls.Add(this.supply_qtys);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(905, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 508);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.supply_grid);
            this.panel1.Controls.Add(this.supply_search);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 505);
            this.panel1.TabIndex = 2;
            // 
            // supply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "supply";
            this.Size = new System.Drawing.Size(1113, 513);
            this.Load += new System.EventHandler(this.supply_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supply_grid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox supply_supplierID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button supply_upbtn;
        private System.Windows.Forms.Button remove_removebtn;
        private System.Windows.Forms.Button supply_clearbtn;
        private System.Windows.Forms.Button supply_addbtn;
        private System.Windows.Forms.ComboBox supply_status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox supply_totalcost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox supply_unitcost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox supply_prodID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox supply_prodname;
        private System.Windows.Forms.TextBox supply_qtys;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView supply_grid;
        private System.Windows.Forms.TextBox supply_search;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}
