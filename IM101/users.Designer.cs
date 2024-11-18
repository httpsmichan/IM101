namespace IM101
{
    partial class users
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.adduser_role = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.adduser_removebtn = new System.Windows.Forms.Button();
            this.adduser_clearbtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.adduser_mnum = new System.Windows.Forms.TextBox();
            this.adduser_updatebtn = new System.Windows.Forms.Button();
            this.adduser_addbtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.adduser_uname = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.adduser_pass = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.adduser_email = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.staff_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.adduser_dataGrid = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adduser_dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.adduser_role);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.adduser_removebtn);
            this.panel2.Controls.Add(this.adduser_clearbtn);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.adduser_mnum);
            this.panel2.Controls.Add(this.adduser_updatebtn);
            this.panel2.Controls.Add(this.adduser_addbtn);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.adduser_uname);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.adduser_pass);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.adduser_email);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(905, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 509);
            this.panel2.TabIndex = 5;
            // 
            // adduser_role
            // 
            this.adduser_role.FormattingEnabled = true;
            this.adduser_role.Items.AddRange(new object[] {
            "Admin",
            "Cashier"});
            this.adduser_role.Location = new System.Drawing.Point(24, 71);
            this.adduser_role.Name = "adduser_role";
            this.adduser_role.Size = new System.Drawing.Size(152, 21);
            this.adduser_role.TabIndex = 59;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(21, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 18);
            this.label13.TabIndex = 47;
            this.label13.Text = "Manage Staff";
            // 
            // adduser_removebtn
            // 
            this.adduser_removebtn.BackColor = System.Drawing.Color.Firebrick;
            this.adduser_removebtn.ForeColor = System.Drawing.Color.White;
            this.adduser_removebtn.Location = new System.Drawing.Point(107, 452);
            this.adduser_removebtn.Name = "adduser_removebtn";
            this.adduser_removebtn.Size = new System.Drawing.Size(90, 38);
            this.adduser_removebtn.TabIndex = 46;
            this.adduser_removebtn.Text = "Remove";
            this.adduser_removebtn.UseVisualStyleBackColor = false;
            this.adduser_removebtn.Click += new System.EventHandler(this.adduser_removebtn_Click);
            // 
            // adduser_clearbtn
            // 
            this.adduser_clearbtn.BackColor = System.Drawing.Color.Firebrick;
            this.adduser_clearbtn.ForeColor = System.Drawing.Color.White;
            this.adduser_clearbtn.Location = new System.Drawing.Point(11, 452);
            this.adduser_clearbtn.Name = "adduser_clearbtn";
            this.adduser_clearbtn.Size = new System.Drawing.Size(90, 38);
            this.adduser_clearbtn.TabIndex = 45;
            this.adduser_clearbtn.Text = "Clear";
            this.adduser_clearbtn.UseVisualStyleBackColor = false;
            this.adduser_clearbtn.Click += new System.EventHandler(this.adduser_clearbtn_Click);
            // 
            // label11
            // 
            this.label11.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(19, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 16);
            this.label11.TabIndex = 50;
            this.label11.Text = "Role";
            // 
            // adduser_mnum
            // 
            this.adduser_mnum.Location = new System.Drawing.Point(24, 244);
            this.adduser_mnum.Name = "adduser_mnum";
            this.adduser_mnum.Size = new System.Drawing.Size(152, 20);
            this.adduser_mnum.TabIndex = 58;
            // 
            // adduser_updatebtn
            // 
            this.adduser_updatebtn.BackColor = System.Drawing.Color.Firebrick;
            this.adduser_updatebtn.ForeColor = System.Drawing.Color.White;
            this.adduser_updatebtn.Location = new System.Drawing.Point(107, 394);
            this.adduser_updatebtn.Name = "adduser_updatebtn";
            this.adduser_updatebtn.Size = new System.Drawing.Size(90, 38);
            this.adduser_updatebtn.TabIndex = 44;
            this.adduser_updatebtn.Text = "Update";
            this.adduser_updatebtn.UseVisualStyleBackColor = false;
            this.adduser_updatebtn.Click += new System.EventHandler(this.adduser_updatebtn_Click);
            // 
            // adduser_addbtn
            // 
            this.adduser_addbtn.BackColor = System.Drawing.Color.Firebrick;
            this.adduser_addbtn.ForeColor = System.Drawing.Color.White;
            this.adduser_addbtn.Location = new System.Drawing.Point(11, 394);
            this.adduser_addbtn.Name = "adduser_addbtn";
            this.adduser_addbtn.Size = new System.Drawing.Size(90, 38);
            this.adduser_addbtn.TabIndex = 43;
            this.adduser_addbtn.Text = "Add";
            this.adduser_addbtn.UseVisualStyleBackColor = false;
            this.adduser_addbtn.Click += new System.EventHandler(this.adduser_addbtn_Click);
            // 
            // label6
            // 
            this.label6.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(21, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 16);
            this.label6.TabIndex = 57;
            this.label6.Text = "Mobile Number";
            // 
            // adduser_uname
            // 
            this.adduser_uname.Location = new System.Drawing.Point(24, 115);
            this.adduser_uname.Name = "adduser_uname";
            this.adduser_uname.Size = new System.Drawing.Size(152, 20);
            this.adduser_uname.TabIndex = 52;
            // 
            // label10
            // 
            this.label10.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(21, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 16);
            this.label10.TabIndex = 51;
            this.label10.Text = "Username";
            // 
            // adduser_pass
            // 
            this.adduser_pass.Location = new System.Drawing.Point(24, 157);
            this.adduser_pass.Name = "adduser_pass";
            this.adduser_pass.Size = new System.Drawing.Size(152, 20);
            this.adduser_pass.TabIndex = 54;
            // 
            // label9
            // 
            this.label9.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(19, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 16);
            this.label9.TabIndex = 53;
            this.label9.Text = "Password";
            // 
            // adduser_email
            // 
            this.adduser_email.Location = new System.Drawing.Point(24, 202);
            this.adduser_email.Name = "adduser_email";
            this.adduser_email.Size = new System.Drawing.Size(152, 20);
            this.adduser_email.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(21, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 16);
            this.label8.TabIndex = 55;
            this.label8.Text = "Email";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(868, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            // 
            // staff_search
            // 
            this.staff_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staff_search.ForeColor = System.Drawing.SystemColors.GrayText;
            this.staff_search.Location = new System.Drawing.Point(605, 10);
            this.staff_search.Name = "staff_search";
            this.staff_search.Size = new System.Drawing.Size(288, 27);
            this.staff_search.TabIndex = 61;
            this.staff_search.TextChanged += new System.EventHandler(this.staff_search_TextChanged);
            this.staff_search.Enter += new System.EventHandler(this.staff_search_Enter);
            this.staff_search.Leave += new System.EventHandler(this.staff_search_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 60;
            this.label1.Text = "All Staff";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.staff_search);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.adduser_dataGrid);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 509);
            this.panel1.TabIndex = 4;
            // 
            // adduser_dataGrid
            // 
            this.adduser_dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.adduser_dataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.adduser_dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.adduser_dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.adduser_dataGrid.Location = new System.Drawing.Point(3, 43);
            this.adduser_dataGrid.Name = "adduser_dataGrid";
            this.adduser_dataGrid.Size = new System.Drawing.Size(890, 461);
            this.adduser_dataGrid.TabIndex = 28;
            this.adduser_dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adduser_dataGrid_CellClick);
            this.adduser_dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adduser_dataGrid_CellContentClick);
            // 
            // users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "users";
            this.Size = new System.Drawing.Size(1113, 512);
            this.Load += new System.EventHandler(this.users_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adduser_dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox adduser_role;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button adduser_removebtn;
        private System.Windows.Forms.Button adduser_clearbtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox adduser_mnum;
        private System.Windows.Forms.Button adduser_updatebtn;
        private System.Windows.Forms.Button adduser_addbtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox adduser_uname;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox adduser_pass;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox adduser_email;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox staff_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView adduser_dataGrid;
    }
}
