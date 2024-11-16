namespace IM101
{
    partial class inventory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.inventory_am = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.inventory_upbtn = new System.Windows.Forms.Button();
            this.inventory_stock = new System.Windows.Forms.TextBox();
            this.inventory_removebtn = new System.Windows.Forms.Button();
            this.inventory_clearbtn = new System.Windows.Forms.Button();
            this.inventory_addbtn = new System.Windows.Forms.Button();
            this.inventory_prodID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.inventory_price = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.inventory_search = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.inventory_prodname = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inventory_grid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventory_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(868, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // inventory_am
            // 
            this.inventory_am.Location = new System.Drawing.Point(24, 319);
            this.inventory_am.Name = "inventory_am";
            this.inventory_am.Size = new System.Drawing.Size(154, 20);
            this.inventory_am.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(21, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 49;
            this.label4.Text = "Unit";
            // 
            // inventory_upbtn
            // 
            this.inventory_upbtn.BackColor = System.Drawing.Color.Firebrick;
            this.inventory_upbtn.ForeColor = System.Drawing.Color.White;
            this.inventory_upbtn.Location = new System.Drawing.Point(107, 397);
            this.inventory_upbtn.Name = "inventory_upbtn";
            this.inventory_upbtn.Size = new System.Drawing.Size(90, 38);
            this.inventory_upbtn.TabIndex = 48;
            this.inventory_upbtn.Text = "Update";
            this.inventory_upbtn.UseVisualStyleBackColor = false;
            this.inventory_upbtn.Click += new System.EventHandler(this.inventory_upbtn_Click);
            // 
            // inventory_stock
            // 
            this.inventory_stock.Location = new System.Drawing.Point(24, 261);
            this.inventory_stock.Name = "inventory_stock";
            this.inventory_stock.Size = new System.Drawing.Size(154, 20);
            this.inventory_stock.TabIndex = 47;
            // 
            // inventory_removebtn
            // 
            this.inventory_removebtn.BackColor = System.Drawing.Color.Firebrick;
            this.inventory_removebtn.ForeColor = System.Drawing.Color.White;
            this.inventory_removebtn.Location = new System.Drawing.Point(107, 455);
            this.inventory_removebtn.Name = "inventory_removebtn";
            this.inventory_removebtn.Size = new System.Drawing.Size(90, 38);
            this.inventory_removebtn.TabIndex = 46;
            this.inventory_removebtn.Text = "Remove";
            this.inventory_removebtn.UseVisualStyleBackColor = false;
            this.inventory_removebtn.Click += new System.EventHandler(this.inventory_removebtn_Click);
            // 
            // inventory_clearbtn
            // 
            this.inventory_clearbtn.BackColor = System.Drawing.Color.Firebrick;
            this.inventory_clearbtn.ForeColor = System.Drawing.Color.White;
            this.inventory_clearbtn.Location = new System.Drawing.Point(11, 455);
            this.inventory_clearbtn.Name = "inventory_clearbtn";
            this.inventory_clearbtn.Size = new System.Drawing.Size(90, 38);
            this.inventory_clearbtn.TabIndex = 45;
            this.inventory_clearbtn.Text = "Clear";
            this.inventory_clearbtn.UseVisualStyleBackColor = false;
            this.inventory_clearbtn.Click += new System.EventHandler(this.inventory_clearbtn_Click);
            // 
            // inventory_addbtn
            // 
            this.inventory_addbtn.BackColor = System.Drawing.Color.Firebrick;
            this.inventory_addbtn.ForeColor = System.Drawing.Color.White;
            this.inventory_addbtn.Location = new System.Drawing.Point(11, 397);
            this.inventory_addbtn.Name = "inventory_addbtn";
            this.inventory_addbtn.Size = new System.Drawing.Size(90, 38);
            this.inventory_addbtn.TabIndex = 43;
            this.inventory_addbtn.Text = "Add";
            this.inventory_addbtn.UseVisualStyleBackColor = false;
            this.inventory_addbtn.Click += new System.EventHandler(this.inventory_addbtn_Click);
            // 
            // inventory_prodID
            // 
            this.inventory_prodID.Location = new System.Drawing.Point(24, 74);
            this.inventory_prodID.Name = "inventory_prodID";
            this.inventory_prodID.Size = new System.Drawing.Size(154, 20);
            this.inventory_prodID.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Manage Inventory";
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(21, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "Product ID";
            // 
            // inventory_price
            // 
            this.inventory_price.Location = new System.Drawing.Point(24, 195);
            this.inventory_price.Name = "inventory_price";
            this.inventory_price.Size = new System.Drawing.Size(154, 20);
            this.inventory_price.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Remaining Stocks";
            // 
            // label7
            // 
            this.label7.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(24, 176);
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
            this.label5.Location = new System.Drawing.Point(21, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "Product Name";
            // 
            // inventory_search
            // 
            this.inventory_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventory_search.ForeColor = System.Drawing.SystemColors.GrayText;
            this.inventory_search.Location = new System.Drawing.Point(605, 10);
            this.inventory_search.Name = "inventory_search";
            this.inventory_search.Size = new System.Drawing.Size(288, 27);
            this.inventory_search.TabIndex = 29;
            this.inventory_search.TextChanged += new System.EventHandler(this.inventory_search_TextChanged);
            this.inventory_search.Enter += new System.EventHandler(this.inventory_search_Enter);
            this.inventory_search.Leave += new System.EventHandler(this.inventory_search_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(12, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 18);
            this.label8.TabIndex = 28;
            this.label8.Text = "Inventory";
            // 
            // inventory_prodname
            // 
            this.inventory_prodname.Location = new System.Drawing.Point(24, 133);
            this.inventory_prodname.Name = "inventory_prodname";
            this.inventory_prodname.Size = new System.Drawing.Size(154, 20);
            this.inventory_prodname.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.inventory_am);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.inventory_upbtn);
            this.panel2.Controls.Add(this.inventory_stock);
            this.panel2.Controls.Add(this.inventory_removebtn);
            this.panel2.Controls.Add(this.inventory_clearbtn);
            this.panel2.Controls.Add(this.inventory_addbtn);
            this.panel2.Controls.Add(this.inventory_prodID);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.inventory_price);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.inventory_prodname);
            this.panel2.Location = new System.Drawing.Point(905, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 509);
            this.panel2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.inventory_grid);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.inventory_search);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 509);
            this.panel1.TabIndex = 4;
            // 
            // inventory_grid
            // 
            this.inventory_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inventory_grid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.inventory_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.inventory_grid.DefaultCellStyle = dataGridViewCellStyle12;
            this.inventory_grid.Location = new System.Drawing.Point(3, 43);
            this.inventory_grid.Name = "inventory_grid";
            this.inventory_grid.Size = new System.Drawing.Size(890, 463);
            this.inventory_grid.TabIndex = 27;
            this.inventory_grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inventory_grid_CellClick);
            // 
            // inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "inventory";
            this.Size = new System.Drawing.Size(1113, 512);
            this.Load += new System.EventHandler(this.inventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventory_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox inventory_am;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button inventory_upbtn;
        private System.Windows.Forms.TextBox inventory_stock;
        private System.Windows.Forms.Button inventory_removebtn;
        private System.Windows.Forms.Button inventory_clearbtn;
        private System.Windows.Forms.Button inventory_addbtn;
        private System.Windows.Forms.TextBox inventory_prodID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inventory_price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inventory_search;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox inventory_prodname;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView inventory_grid;
    }
}
