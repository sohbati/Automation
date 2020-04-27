namespace Andicator.lists
{
    partial class UserList
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RADIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FAMILY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERTYPE_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.searchMasterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlName = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlFamily = new System.Windows.Forms.Panel();
            this.txtFamily = new System.Windows.Forms.TextBox();
            this.lblFamily = new System.Windows.Forms.Label();
            this.pnlUserName = new System.Windows.Forms.Panel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pnlUserType = new System.Windows.Forms.Panel();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.lblUserType = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.searchMasterPanel.SuspendLayout();
            this.pnlName.SuspendLayout();
            this.pnlFamily.SuspendLayout();
            this.pnlUserName.SuspendLayout();
            this.pnlUserType.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.40351F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.59649F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(703, 383);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RADIF,
            this.ID,
            this.NAME,
            this.FAMILY,
            this.USERNAME,
            this.USERTYPE_DESC});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(697, 297);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // RADIF
            // 
            this.RADIF.DataPropertyName = "RADIF";
            this.RADIF.HeaderText = "ردیف";
            this.RADIF.Name = "RADIF";
            this.RADIF.ReadOnly = true;
            this.RADIF.Width = 50;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.HeaderText = "نام کاربر";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.Width = 150;
            // 
            // FAMILY
            // 
            this.FAMILY.DataPropertyName = "FAMILY";
            this.FAMILY.HeaderText = "نام خانوادگی";
            this.FAMILY.Name = "FAMILY";
            this.FAMILY.ReadOnly = true;
            this.FAMILY.Width = 150;
            // 
            // USERNAME
            // 
            this.USERNAME.DataPropertyName = "USERNAME";
            this.USERNAME.HeaderText = "نام کاربری";
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.ReadOnly = true;
            this.USERNAME.Width = 150;
            // 
            // USERTYPE_DESC
            // 
            this.USERTYPE_DESC.DataPropertyName = "USERTYPE_DESC";
            this.USERTYPE_DESC.HeaderText = "نوع کاربر";
            this.USERTYPE_DESC.Name = "USERTYPE_DESC";
            this.USERTYPE_DESC.ReadOnly = true;
            this.USERTYPE_DESC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.USERTYPE_DESC.Width = 120;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 345);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(697, 35);
            this.panel3.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnSelect);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(247, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(239, 28);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "بستن";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(84, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(117, 23);
            this.btnSelect.TabIndex = 17;
            this.btnSelect.Text = "انتخاب";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.searchMasterPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(697, 33);
            this.panel2.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(240, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 30);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // searchMasterPanel
            // 
            this.searchMasterPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.searchMasterPanel.Controls.Add(this.pnlName);
            this.searchMasterPanel.Controls.Add(this.pnlFamily);
            this.searchMasterPanel.Controls.Add(this.pnlUserName);
            this.searchMasterPanel.Controls.Add(this.pnlUserType);
            this.searchMasterPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.searchMasterPanel.Location = new System.Drawing.Point(321, 3);
            this.searchMasterPanel.Name = "searchMasterPanel";
            this.searchMasterPanel.Size = new System.Drawing.Size(367, 140);
            this.searchMasterPanel.TabIndex = 14;
            // 
            // pnlName
            // 
            this.pnlName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlName.Controls.Add(this.txtName);
            this.pnlName.Controls.Add(this.lblName);
            this.pnlName.Location = new System.Drawing.Point(5, 3);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(359, 28);
            this.pnlName.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.AcceptsTab = true;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(3, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(234, 22);
            this.txtName.TabIndex = 5;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchItems_KeyDown);
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblName.Location = new System.Drawing.Point(243, 2);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 23);
            this.lblName.TabIndex = 7;
            this.lblName.Tag = "";
            this.lblName.Text = "نام : ";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlFamily
            // 
            this.pnlFamily.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlFamily.Controls.Add(this.txtFamily);
            this.pnlFamily.Controls.Add(this.lblFamily);
            this.pnlFamily.Location = new System.Drawing.Point(5, 37);
            this.pnlFamily.Name = "pnlFamily";
            this.pnlFamily.Size = new System.Drawing.Size(359, 28);
            this.pnlFamily.TabIndex = 2;
            // 
            // txtFamily
            // 
            this.txtFamily.AcceptsTab = true;
            this.txtFamily.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFamily.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtFamily.ForeColor = System.Drawing.Color.Black;
            this.txtFamily.Location = new System.Drawing.Point(3, 3);
            this.txtFamily.Name = "txtFamily";
            this.txtFamily.Size = new System.Drawing.Size(234, 22);
            this.txtFamily.TabIndex = 5;
            this.txtFamily.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchItems_KeyDown);
            // 
            // lblFamily
            // 
            this.lblFamily.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFamily.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFamily.Location = new System.Drawing.Point(243, 1);
            this.lblFamily.Name = "lblFamily";
            this.lblFamily.Size = new System.Drawing.Size(86, 23);
            this.lblFamily.TabIndex = 7;
            this.lblFamily.Tag = "";
            this.lblFamily.Text = "نام خانوادگی : ";
            this.lblFamily.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlUserName
            // 
            this.pnlUserName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlUserName.Controls.Add(this.txtUserName);
            this.pnlUserName.Controls.Add(this.lblUserName);
            this.pnlUserName.Location = new System.Drawing.Point(5, 71);
            this.pnlUserName.Name = "pnlUserName";
            this.pnlUserName.Size = new System.Drawing.Size(359, 28);
            this.pnlUserName.TabIndex = 5;
            // 
            // txtUserName
            // 
            this.txtUserName.AcceptsTab = true;
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtUserName.ForeColor = System.Drawing.Color.Black;
            this.txtUserName.Location = new System.Drawing.Point(3, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(234, 22);
            this.txtUserName.TabIndex = 22;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchItems_KeyDown);
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUserName.Location = new System.Drawing.Point(243, 3);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(77, 23);
            this.lblUserName.TabIndex = 21;
            this.lblUserName.Text = "نام کاربری : ";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlUserType
            // 
            this.pnlUserType.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlUserType.Controls.Add(this.cmbUserType);
            this.pnlUserType.Controls.Add(this.lblUserType);
            this.pnlUserType.Location = new System.Drawing.Point(5, 105);
            this.pnlUserType.Name = "pnlUserType";
            this.pnlUserType.Size = new System.Drawing.Size(359, 28);
            this.pnlUserType.TabIndex = 6;
            // 
            // cmbUserType
            // 
            this.cmbUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Items.AddRange(new object[] {
            "مدیر سیستم",
            "کاربر",
            "کاربر اصلی"});
            this.cmbUserType.Location = new System.Drawing.Point(5, 4);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(232, 21);
            this.cmbUserType.TabIndex = 8;
            this.cmbUserType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchItems_KeyDown);
            // 
            // lblUserType
            // 
            this.lblUserType.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblUserType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUserType.Location = new System.Drawing.Point(247, 1);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(57, 23);
            this.lblUserType.TabIndex = 7;
            this.lblUserType.Tag = "";
            this.lblUserType.Text = "نوع کاربر : ";
            this.lblUserType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 383);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست کاربران";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserList_KeyDown_1);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.searchMasterPanel.ResumeLayout(false);
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            this.pnlFamily.ResumeLayout(false);
            this.pnlFamily.PerformLayout();
            this.pnlUserName.ResumeLayout(false);
            this.pnlUserName.PerformLayout();
            this.pnlUserType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel searchMasterPanel;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlFamily;
        private System.Windows.Forms.TextBox txtFamily;
        private System.Windows.Forms.Label lblFamily;
        private System.Windows.Forms.Panel pnlUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel pnlUserType;
        private System.Windows.Forms.Label lblUserType;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.ComboBox cmbUserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RADIF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn FAMILY;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERTYPE_DESC;
    }
}