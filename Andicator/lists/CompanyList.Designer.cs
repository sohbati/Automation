namespace Andicator.lists
{
    partial class CompanyList
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
            this.COMPANYNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OFFICER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEMAT_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.searchMasterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCompanyName = new System.Windows.Forms.Panel();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.pnlOfficer = new System.Windows.Forms.Panel();
            this.txtOfficer = new System.Windows.Forms.TextBox();
            this.lblOfficer = new System.Windows.Forms.Label();
            this.pnlSemat = new System.Windows.Forms.Panel();
            this.lblSemat = new System.Windows.Forms.Label();
            this.cmbSemat = new System.Windows.Forms.ComboBox();
            this.pnlTel = new System.Windows.Forms.Panel();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.pnlFax = new System.Windows.Forms.Panel();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.pnlAddress = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.pnlDescription = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.searchMasterPanel.SuspendLayout();
            this.pnlCompanyName.SuspendLayout();
            this.pnlOfficer.SuspendLayout();
            this.pnlSemat.SuspendLayout();
            this.pnlTel.SuspendLayout();
            this.pnlFax.SuspendLayout();
            this.pnlAddress.SuspendLayout();
            this.pnlDescription.SuspendLayout();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.415842F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.58416F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(894, 445);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RADIF,
            this.ID,
            this.COMPANYNAME,
            this.OFFICER,
            this.SEMAT_DESC,
            this.TEL,
            this.ADDRESS,
            this.FAX,
            this.DESCRIPTION});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(888, 364);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
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
            // COMPANYNAME
            // 
            this.COMPANYNAME.DataPropertyName = "COMPANYNAME";
            this.COMPANYNAME.HeaderText = "نام شرکت";
            this.COMPANYNAME.Name = "COMPANYNAME";
            this.COMPANYNAME.ReadOnly = true;
            this.COMPANYNAME.Width = 200;
            // 
            // OFFICER
            // 
            this.OFFICER.DataPropertyName = "OFFICER";
            this.OFFICER.HeaderText = "نام متصدی";
            this.OFFICER.Name = "OFFICER";
            this.OFFICER.ReadOnly = true;
            // 
            // SEMAT_DESC
            // 
            this.SEMAT_DESC.DataPropertyName = "SEMAT_DESC";
            this.SEMAT_DESC.HeaderText = "سمت";
            this.SEMAT_DESC.Name = "SEMAT_DESC";
            this.SEMAT_DESC.ReadOnly = true;
            // 
            // TEL
            // 
            this.TEL.DataPropertyName = "TEL";
            this.TEL.HeaderText = "تلفن";
            this.TEL.Name = "TEL";
            this.TEL.ReadOnly = true;
            this.TEL.Width = 150;
            // 
            // ADDRESS
            // 
            this.ADDRESS.DataPropertyName = "ADDRESS";
            this.ADDRESS.HeaderText = "آدرس";
            this.ADDRESS.Name = "ADDRESS";
            this.ADDRESS.ReadOnly = true;
            this.ADDRESS.Width = 200;
            // 
            // FAX
            // 
            this.FAX.DataPropertyName = "FAX";
            this.FAX.HeaderText = "فکس";
            this.FAX.Name = "FAX";
            this.FAX.ReadOnly = true;
            this.FAX.Width = 150;
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.DataPropertyName = "DESCRIPTION";
            this.DESCRIPTION.HeaderText = "شرح";
            this.DESCRIPTION.Name = "DESCRIPTION";
            this.DESCRIPTION.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 407);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(888, 35);
            this.panel3.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnNew);
            this.flowLayoutPanel1.Controls.Add(this.btnDisplay);
            this.flowLayoutPanel1.Controls.Add(this.btnSelect);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(287, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(505, 28);
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
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(84, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(165, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "جدید";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(246, 3);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 16;
            this.btnDisplay.Text = "نمایش";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(327, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(117, 23);
            this.btnSelect.TabIndex = 17;
            this.btnSelect.Text = "انتخاب";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.txtChoise_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.searchMasterPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(888, 28);
            this.panel2.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(434, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // searchMasterPanel
            // 
            this.searchMasterPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.searchMasterPanel.Controls.Add(this.pnlCompanyName);
            this.searchMasterPanel.Controls.Add(this.pnlOfficer);
            this.searchMasterPanel.Controls.Add(this.pnlSemat);
            this.searchMasterPanel.Controls.Add(this.pnlTel);
            this.searchMasterPanel.Controls.Add(this.pnlFax);
            this.searchMasterPanel.Controls.Add(this.pnlAddress);
            this.searchMasterPanel.Controls.Add(this.pnlDescription);
            this.searchMasterPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.searchMasterPanel.Location = new System.Drawing.Point(512, -5);
            this.searchMasterPanel.Name = "searchMasterPanel";
            this.searchMasterPanel.Size = new System.Drawing.Size(367, 241);
            this.searchMasterPanel.TabIndex = 14;
            // 
            // pnlCompanyName
            // 
            this.pnlCompanyName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlCompanyName.Controls.Add(this.txtCompanyName);
            this.pnlCompanyName.Controls.Add(this.lblCompanyName);
            this.pnlCompanyName.Location = new System.Drawing.Point(5, 3);
            this.pnlCompanyName.Name = "pnlCompanyName";
            this.pnlCompanyName.Size = new System.Drawing.Size(359, 28);
            this.pnlCompanyName.TabIndex = 0;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.AcceptsTab = true;
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtCompanyName.ForeColor = System.Drawing.Color.Black;
            this.txtCompanyName.Location = new System.Drawing.Point(3, 3);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(234, 22);
            this.txtCompanyName.TabIndex = 5;
            this.txtCompanyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblCompanyName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCompanyName.Location = new System.Drawing.Point(243, 2);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(113, 23);
            this.lblCompanyName.TabIndex = 7;
            this.lblCompanyName.Tag = "";
            this.lblCompanyName.Text = "نام شخص/شرکت : ";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlOfficer
            // 
            this.pnlOfficer.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlOfficer.Controls.Add(this.txtOfficer);
            this.pnlOfficer.Controls.Add(this.lblOfficer);
            this.pnlOfficer.Location = new System.Drawing.Point(5, 37);
            this.pnlOfficer.Name = "pnlOfficer";
            this.pnlOfficer.Size = new System.Drawing.Size(359, 28);
            this.pnlOfficer.TabIndex = 2;
            // 
            // txtOfficer
            // 
            this.txtOfficer.AcceptsTab = true;
            this.txtOfficer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOfficer.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtOfficer.ForeColor = System.Drawing.Color.Black;
            this.txtOfficer.Location = new System.Drawing.Point(3, 3);
            this.txtOfficer.Name = "txtOfficer";
            this.txtOfficer.Size = new System.Drawing.Size(234, 22);
            this.txtOfficer.TabIndex = 5;
            this.txtOfficer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // lblOfficer
            // 
            this.lblOfficer.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblOfficer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOfficer.Location = new System.Drawing.Point(243, 1);
            this.lblOfficer.Name = "lblOfficer";
            this.lblOfficer.Size = new System.Drawing.Size(113, 23);
            this.lblOfficer.TabIndex = 7;
            this.lblOfficer.Tag = "";
            this.lblOfficer.Text = "نام متصدیان : ";
            this.lblOfficer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlSemat
            // 
            this.pnlSemat.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlSemat.Controls.Add(this.lblSemat);
            this.pnlSemat.Controls.Add(this.cmbSemat);
            this.pnlSemat.Location = new System.Drawing.Point(5, 71);
            this.pnlSemat.Name = "pnlSemat";
            this.pnlSemat.Size = new System.Drawing.Size(359, 28);
            this.pnlSemat.TabIndex = 5;
            // 
            // lblSemat
            // 
            this.lblSemat.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSemat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSemat.Location = new System.Drawing.Point(243, 3);
            this.lblSemat.Name = "lblSemat";
            this.lblSemat.Size = new System.Drawing.Size(77, 23);
            this.lblSemat.TabIndex = 21;
            this.lblSemat.Text = "سمت : ";
            this.lblSemat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSemat
            // 
            this.cmbSemat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemat.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cmbSemat.FormattingEnabled = true;
            this.cmbSemat.Location = new System.Drawing.Point(3, 4);
            this.cmbSemat.Name = "cmbSemat";
            this.cmbSemat.Size = new System.Drawing.Size(234, 22);
            this.cmbSemat.TabIndex = 20;
            this.cmbSemat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // pnlTel
            // 
            this.pnlTel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlTel.Controls.Add(this.txtTel);
            this.pnlTel.Controls.Add(this.lblTel);
            this.pnlTel.Location = new System.Drawing.Point(5, 105);
            this.pnlTel.Name = "pnlTel";
            this.pnlTel.Size = new System.Drawing.Size(359, 28);
            this.pnlTel.TabIndex = 6;
            // 
            // txtTel
            // 
            this.txtTel.AcceptsTab = true;
            this.txtTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtTel.ForeColor = System.Drawing.Color.Black;
            this.txtTel.Location = new System.Drawing.Point(3, 3);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(234, 22);
            this.txtTel.TabIndex = 5;
            this.txtTel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // lblTel
            // 
            this.lblTel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTel.Location = new System.Drawing.Point(243, 1);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(113, 23);
            this.lblTel.TabIndex = 7;
            this.lblTel.Tag = "";
            this.lblTel.Text = "شماره تلفن : ";
            this.lblTel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlFax
            // 
            this.pnlFax.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlFax.Controls.Add(this.txtFax);
            this.pnlFax.Controls.Add(this.lblFax);
            this.pnlFax.Location = new System.Drawing.Point(5, 139);
            this.pnlFax.Name = "pnlFax";
            this.pnlFax.Size = new System.Drawing.Size(359, 28);
            this.pnlFax.TabIndex = 7;
            // 
            // txtFax
            // 
            this.txtFax.AcceptsTab = true;
            this.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFax.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtFax.ForeColor = System.Drawing.Color.Black;
            this.txtFax.Location = new System.Drawing.Point(3, 3);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(234, 22);
            this.txtFax.TabIndex = 5;
            this.txtFax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // lblFax
            // 
            this.lblFax.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFax.Location = new System.Drawing.Point(243, 1);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(113, 23);
            this.lblFax.TabIndex = 7;
            this.lblFax.Tag = "";
            this.lblFax.Text = "دورنگار : ";
            this.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlAddress
            // 
            this.pnlAddress.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlAddress.Controls.Add(this.txtAddress);
            this.pnlAddress.Controls.Add(this.lblAddress);
            this.pnlAddress.Location = new System.Drawing.Point(5, 173);
            this.pnlAddress.Name = "pnlAddress";
            this.pnlAddress.Size = new System.Drawing.Size(359, 28);
            this.pnlAddress.TabIndex = 8;
            // 
            // txtAddress
            // 
            this.txtAddress.AcceptsTab = true;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.Location = new System.Drawing.Point(3, 3);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(234, 22);
            this.txtAddress.TabIndex = 5;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAddress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAddress.Location = new System.Drawing.Point(243, 1);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(113, 23);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Tag = "";
            this.lblAddress.Text = "آدرس : ";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlDescription
            // 
            this.pnlDescription.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlDescription.Controls.Add(this.txtDescription);
            this.pnlDescription.Controls.Add(this.lblDescription);
            this.pnlDescription.Location = new System.Drawing.Point(5, 207);
            this.pnlDescription.Name = "pnlDescription";
            this.pnlDescription.Size = new System.Drawing.Size(359, 28);
            this.pnlDescription.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.AcceptsTab = true;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.Location = new System.Drawing.Point(3, 3);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(234, 22);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDescription.Location = new System.Drawing.Point(243, 1);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(113, 23);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Tag = "";
            this.lblDescription.Text = "توضیحات : ";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CompanyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 445);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompanyList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست شرکت ها ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompanyList_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.searchMasterPanel.ResumeLayout(false);
            this.pnlCompanyName.ResumeLayout(false);
            this.pnlCompanyName.PerformLayout();
            this.pnlOfficer.ResumeLayout(false);
            this.pnlOfficer.PerformLayout();
            this.pnlSemat.ResumeLayout(false);
            this.pnlTel.ResumeLayout(false);
            this.pnlTel.PerformLayout();
            this.pnlFax.ResumeLayout(false);
            this.pnlFax.PerformLayout();
            this.pnlAddress.ResumeLayout(false);
            this.pnlAddress.PerformLayout();
            this.pnlDescription.ResumeLayout(false);
            this.pnlDescription.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel searchMasterPanel;
        private System.Windows.Forms.Panel pnlCompanyName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Panel pnlOfficer;
        private System.Windows.Forms.TextBox txtOfficer;
        private System.Windows.Forms.Label lblOfficer;
        private System.Windows.Forms.Panel pnlSemat;
        private System.Windows.Forms.Label lblSemat;
        private System.Windows.Forms.ComboBox cmbSemat;
        private System.Windows.Forms.Panel pnlTel;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Panel pnlFax;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.Panel pnlAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Panel pnlDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn RADIF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPANYNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn OFFICER;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEMAT_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADDRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn FAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPTION;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnDelete;
    }
}