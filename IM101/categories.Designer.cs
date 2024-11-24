namespace IM101
{
    partial class categories
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
            this.category_grid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.category_search = new System.Windows.Forms.TextBox();
            this.category_removebtn = new System.Windows.Forms.Button();
            this.category_clearbtn = new System.Windows.Forms.Button();
            this.category_updatebtn = new System.Windows.Forms.Button();
            this.category_addbtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.category_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.category_grid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // category_grid
            // 
            this.category_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.category_grid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.category_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.category_grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.category_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.category_grid.Location = new System.Drawing.Point(6, 43);
            this.category_grid.Name = "category_grid";
            this.category_grid.Size = new System.Drawing.Size(884, 463);
            this.category_grid.TabIndex = 50;
            this.category_grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.category_grid_CellClick);
            this.category_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.category_grid_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.category_grid);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.category_search);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 508);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IM101.Properties.Resources.loupe;
            this.pictureBox1.Location = new System.Drawing.Point(868, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 47;
            this.label1.Text = "Categories";
            // 
            // category_search
            // 
            this.category_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_search.ForeColor = System.Drawing.SystemColors.GrayText;
            this.category_search.Location = new System.Drawing.Point(605, 10);
            this.category_search.Name = "category_search";
            this.category_search.Size = new System.Drawing.Size(288, 27);
            this.category_search.TabIndex = 29;
            this.category_search.TextChanged += new System.EventHandler(this.category_search_TextChanged);
            this.category_search.Enter += new System.EventHandler(this.category_search_Enter);
            this.category_search.Leave += new System.EventHandler(this.category_search_Leave);
            // 
            // category_removebtn
            // 
            this.category_removebtn.BackColor = System.Drawing.Color.Firebrick;
            this.category_removebtn.ForeColor = System.Drawing.Color.White;
            this.category_removebtn.Location = new System.Drawing.Point(107, 444);
            this.category_removebtn.Name = "category_removebtn";
            this.category_removebtn.Size = new System.Drawing.Size(90, 38);
            this.category_removebtn.TabIndex = 46;
            this.category_removebtn.Text = "Remove";
            this.category_removebtn.UseVisualStyleBackColor = false;
            this.category_removebtn.Click += new System.EventHandler(this.category_removebtn_Click);
            // 
            // category_clearbtn
            // 
            this.category_clearbtn.BackColor = System.Drawing.Color.Firebrick;
            this.category_clearbtn.ForeColor = System.Drawing.Color.White;
            this.category_clearbtn.Location = new System.Drawing.Point(11, 444);
            this.category_clearbtn.Name = "category_clearbtn";
            this.category_clearbtn.Size = new System.Drawing.Size(90, 38);
            this.category_clearbtn.TabIndex = 45;
            this.category_clearbtn.Text = "Clear";
            this.category_clearbtn.UseVisualStyleBackColor = false;
            this.category_clearbtn.Click += new System.EventHandler(this.category_clearbtn_Click);
            // 
            // category_updatebtn
            // 
            this.category_updatebtn.BackColor = System.Drawing.Color.Firebrick;
            this.category_updatebtn.ForeColor = System.Drawing.Color.White;
            this.category_updatebtn.Location = new System.Drawing.Point(107, 386);
            this.category_updatebtn.Name = "category_updatebtn";
            this.category_updatebtn.Size = new System.Drawing.Size(90, 38);
            this.category_updatebtn.TabIndex = 44;
            this.category_updatebtn.Text = "Update";
            this.category_updatebtn.UseVisualStyleBackColor = false;
            this.category_updatebtn.Click += new System.EventHandler(this.category_updatebtn_Click);
            // 
            // category_addbtn
            // 
            this.category_addbtn.BackColor = System.Drawing.Color.Firebrick;
            this.category_addbtn.ForeColor = System.Drawing.Color.White;
            this.category_addbtn.Location = new System.Drawing.Point(11, 386);
            this.category_addbtn.Name = "category_addbtn";
            this.category_addbtn.Size = new System.Drawing.Size(90, 38);
            this.category_addbtn.TabIndex = 43;
            this.category_addbtn.Text = "Add";
            this.category_addbtn.UseVisualStyleBackColor = false;
            this.category_addbtn.Click += new System.EventHandler(this.category_addbtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.category_name);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.category_removebtn);
            this.panel2.Controls.Add(this.category_clearbtn);
            this.panel2.Controls.Add(this.category_updatebtn);
            this.panel2.Controls.Add(this.category_addbtn);
            this.panel2.Location = new System.Drawing.Point(905, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 509);
            this.panel2.TabIndex = 9;
            // 
            // category_name
            // 
            this.category_name.Location = new System.Drawing.Point(18, 76);
            this.category_name.Name = "category_name";
            this.category_name.Size = new System.Drawing.Size(157, 20);
            this.category_name.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(21, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 18);
            this.label6.TabIndex = 30;
            this.label6.Text = "Manage Categories";
            // 
            // label8
            // 
            this.label8.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(18, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 16);
            this.label8.TabIndex = 50;
            this.label8.Text = "Category Name";
            // 
            // categories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "categories";
            this.Size = new System.Drawing.Size(1113, 512);
            this.Load += new System.EventHandler(this.categories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.category_grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView category_grid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox category_search;
        private System.Windows.Forms.Button category_removebtn;
        private System.Windows.Forms.Button category_clearbtn;
        private System.Windows.Forms.Button category_updatebtn;
        private System.Windows.Forms.Button category_addbtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox category_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}
