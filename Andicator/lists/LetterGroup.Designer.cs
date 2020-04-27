namespace Andicator.lists
{
    partial class LetterGroup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.searchMasterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlGroupTitle = new System.Windows.Forms.Panel();
            this.txtGroupTitle = new System.Windows.Forms.TextBox();
            this.lblGroupTitle = new System.Windows.Forms.Label();
            this.pnlLetterNumbers = new System.Windows.Forms.Panel();
            this.txtLetterNumbers = new System.Windows.Forms.TextBox();
            this.lblLetterNumbers = new System.Windows.Forms.Label();
            this.gridLetterGroup = new System.Windows.Forms.DataGridView();
            this.RADIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GROUPTITLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LETTERNUMBERS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.letterGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LETTERNUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LETTERDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LETTERSUBJECT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUMMARY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INSURANCETYPEID_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INSURANCENUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INSURANCEDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LETTERSTATEID_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPANYID_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REFFERFROM_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REFERENCEUSERID_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.BtnChangeGroupName = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.searchMasterPanel.SuspendLayout();
            this.pnlGroupTitle.SuspendLayout();
            this.pnlLetterNumbers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLetterGroup)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.letterGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 551);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1271, 35);
            this.panel3.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnDeleteGroup);
            this.flowLayoutPanel1.Controls.Add(this.BtnChangeGroupName);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(247, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(526, 28);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "بستن";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.searchMasterPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1271, 38);
            this.panel2.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(765, 3);
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
            this.searchMasterPanel.Controls.Add(this.pnlGroupTitle);
            this.searchMasterPanel.Controls.Add(this.pnlLetterNumbers);
            this.searchMasterPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.searchMasterPanel.Location = new System.Drawing.Point(846, 3);
            this.searchMasterPanel.Name = "searchMasterPanel";
            this.searchMasterPanel.Size = new System.Drawing.Size(367, 74);
            this.searchMasterPanel.TabIndex = 14;
            // 
            // pnlGroupTitle
            // 
            this.pnlGroupTitle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlGroupTitle.Controls.Add(this.txtGroupTitle);
            this.pnlGroupTitle.Controls.Add(this.lblGroupTitle);
            this.pnlGroupTitle.Location = new System.Drawing.Point(5, 3);
            this.pnlGroupTitle.Name = "pnlGroupTitle";
            this.pnlGroupTitle.Size = new System.Drawing.Size(359, 28);
            this.pnlGroupTitle.TabIndex = 0;
            // 
            // txtGroupTitle
            // 
            this.txtGroupTitle.AcceptsTab = true;
            this.txtGroupTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupTitle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtGroupTitle.ForeColor = System.Drawing.Color.Black;
            this.txtGroupTitle.Location = new System.Drawing.Point(3, 3);
            this.txtGroupTitle.Name = "txtGroupTitle";
            this.txtGroupTitle.Size = new System.Drawing.Size(234, 22);
            this.txtGroupTitle.TabIndex = 5;
            this.txtGroupTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchItems_KeyDown);
            // 
            // lblGroupTitle
            // 
            this.lblGroupTitle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblGroupTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGroupTitle.Location = new System.Drawing.Point(243, 2);
            this.lblGroupTitle.Name = "lblGroupTitle";
            this.lblGroupTitle.Size = new System.Drawing.Size(83, 23);
            this.lblGroupTitle.TabIndex = 7;
            this.lblGroupTitle.Tag = "";
            this.lblGroupTitle.Text = " عنوان گروه : ";
            this.lblGroupTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlLetterNumbers
            // 
            this.pnlLetterNumbers.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlLetterNumbers.Controls.Add(this.txtLetterNumbers);
            this.pnlLetterNumbers.Controls.Add(this.lblLetterNumbers);
            this.pnlLetterNumbers.Location = new System.Drawing.Point(5, 37);
            this.pnlLetterNumbers.Name = "pnlLetterNumbers";
            this.pnlLetterNumbers.Size = new System.Drawing.Size(359, 28);
            this.pnlLetterNumbers.TabIndex = 2;
            // 
            // txtLetterNumbers
            // 
            this.txtLetterNumbers.AcceptsTab = true;
            this.txtLetterNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLetterNumbers.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtLetterNumbers.ForeColor = System.Drawing.Color.Black;
            this.txtLetterNumbers.Location = new System.Drawing.Point(3, 3);
            this.txtLetterNumbers.Name = "txtLetterNumbers";
            this.txtLetterNumbers.Size = new System.Drawing.Size(234, 22);
            this.txtLetterNumbers.TabIndex = 5;
            this.txtLetterNumbers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchItems_KeyDown);
            // 
            // lblLetterNumbers
            // 
            this.lblLetterNumbers.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblLetterNumbers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLetterNumbers.Location = new System.Drawing.Point(243, 1);
            this.lblLetterNumbers.Name = "lblLetterNumbers";
            this.lblLetterNumbers.Size = new System.Drawing.Size(93, 23);
            this.lblLetterNumbers.TabIndex = 7;
            this.lblLetterNumbers.Tag = "";
            this.lblLetterNumbers.Text = "شماره نامه ها : ";
            this.lblLetterNumbers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gridLetterGroup
            // 
            this.gridLetterGroup.AllowUserToAddRows = false;
            this.gridLetterGroup.AllowUserToDeleteRows = false;
            this.gridLetterGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLetterGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RADIF,
            this.ID,
            this.GROUPTITLE,
            this.LETTERNUMBERS});
            this.gridLetterGroup.Dock = System.Windows.Forms.DockStyle.Right;
            this.gridLetterGroup.Location = new System.Drawing.Point(789, 0);
            this.gridLetterGroup.Name = "gridLetterGroup";
            this.gridLetterGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridLetterGroup.Size = new System.Drawing.Size(482, 513);
            this.gridLetterGroup.TabIndex = 5;
            this.gridLetterGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.gridLetterGroup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // GROUPTITLE
            // 
            this.GROUPTITLE.DataPropertyName = "GROUPTITLE";
            this.GROUPTITLE.HeaderText = "عنوان گروه";
            this.GROUPTITLE.Name = "GROUPTITLE";
            this.GROUPTITLE.ReadOnly = true;
            this.GROUPTITLE.Width = 300;
            // 
            // LETTERNUMBERS
            // 
            this.LETTERNUMBERS.DataPropertyName = "LETTERNUMBERS";
            this.LETTERNUMBERS.HeaderText = "شماره نامه ها";
            this.LETTERNUMBERS.Name = "LETTERNUMBERS";
            this.LETTERNUMBERS.ReadOnly = true;
            this.LETTERNUMBERS.Width = 500;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.gridLetterGroup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1271, 513);
            this.panel1.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel4.Controls.Add(this.letterGrid);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(789, 513);
            this.panel4.TabIndex = 6;
            // 
            // letterGrid
            // 
            this.letterGrid.AllowUserToAddRows = false;
            this.letterGrid.AllowUserToDeleteRows = false;
            this.letterGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.letterGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.STAR,
            this.dataGridViewTextBoxColumn2,
            this.LETTERNUMBER,
            this.LETTERDATE,
            this.LETTERSUBJECT,
            this.SUMMARY,
            this.INSURANCETYPEID_DESC,
            this.INSURANCENUMBER,
            this.INSURANCEDATE,
            this.LETTERSTATEID_DESC,
            this.COMPANYID_DESC,
            this.REFFERFROM_DESC,
            this.REFERENCEUSERID_DESC,
            this.COLOR});
            this.letterGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.letterGrid.Location = new System.Drawing.Point(0, 0);
            this.letterGrid.Name = "letterGrid";
            this.letterGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.letterGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.letterGrid.Size = new System.Drawing.Size(789, 513);
            this.letterGrid.TabIndex = 7;
            this.letterGrid.DoubleClick += new System.EventHandler(this.letterGrid_DoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.DividerWidth = 1;
            this.dataGridViewTextBoxColumn1.HeaderText = "شناسه";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // STAR
            // 
            this.STAR.DataPropertyName = "STAR";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MediumBlue;
            this.STAR.DefaultCellStyle = dataGridViewCellStyle3;
            this.STAR.HeaderText = "  ";
            this.STAR.Name = "STAR";
            this.STAR.ReadOnly = true;
            this.STAR.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.STAR.Visible = false;
            this.STAR.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "RADIF";
            this.dataGridViewTextBoxColumn2.HeaderText = "ردیف";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // LETTERNUMBER
            // 
            this.LETTERNUMBER.DataPropertyName = "LETTERNUMBER";
            this.LETTERNUMBER.HeaderText = "شماره ثبت نامه";
            this.LETTERNUMBER.Name = "LETTERNUMBER";
            this.LETTERNUMBER.ReadOnly = true;
            // 
            // LETTERDATE
            // 
            this.LETTERDATE.DataPropertyName = "LETTERDATE";
            this.LETTERDATE.HeaderText = "تاریخ ثبت";
            this.LETTERDATE.Name = "LETTERDATE";
            this.LETTERDATE.ReadOnly = true;
            // 
            // LETTERSUBJECT
            // 
            this.LETTERSUBJECT.DataPropertyName = "LETTERSUBJECT";
            this.LETTERSUBJECT.HeaderText = "موضوع نامه";
            this.LETTERSUBJECT.Name = "LETTERSUBJECT";
            this.LETTERSUBJECT.ReadOnly = true;
            // 
            // SUMMARY
            // 
            this.SUMMARY.DataPropertyName = "SUMMARY";
            this.SUMMARY.HeaderText = "خلاصه نامه";
            this.SUMMARY.Name = "SUMMARY";
            this.SUMMARY.ReadOnly = true;
            this.SUMMARY.Visible = false;
            // 
            // INSURANCETYPEID_DESC
            // 
            this.INSURANCETYPEID_DESC.DataPropertyName = "INSURANCETYPEID_DESC";
            this.INSURANCETYPEID_DESC.HeaderText = "بیمه";
            this.INSURANCETYPEID_DESC.Name = "INSURANCETYPEID_DESC";
            this.INSURANCETYPEID_DESC.ReadOnly = true;
            // 
            // INSURANCENUMBER
            // 
            this.INSURANCENUMBER.DataPropertyName = "INSURANCENUMBER";
            this.INSURANCENUMBER.HeaderText = "شماره بیمه";
            this.INSURANCENUMBER.Name = "INSURANCENUMBER";
            this.INSURANCENUMBER.ReadOnly = true;
            this.INSURANCENUMBER.Visible = false;
            // 
            // INSURANCEDATE
            // 
            this.INSURANCEDATE.DataPropertyName = "INSURANCEDATE";
            this.INSURANCEDATE.HeaderText = "تاریخ بیمه صادره";
            this.INSURANCEDATE.Name = "INSURANCEDATE";
            this.INSURANCEDATE.ReadOnly = true;
            this.INSURANCEDATE.Width = 110;
            // 
            // LETTERSTATEID_DESC
            // 
            this.LETTERSTATEID_DESC.DataPropertyName = "LETTERSTATEID_DESC";
            this.LETTERSTATEID_DESC.HeaderText = "وضعیت نامه";
            this.LETTERSTATEID_DESC.Name = "LETTERSTATEID_DESC";
            this.LETTERSTATEID_DESC.ReadOnly = true;
            // 
            // COMPANYID_DESC
            // 
            this.COMPANYID_DESC.DataPropertyName = "COMPANYID_DESC";
            this.COMPANYID_DESC.HeaderText = "نام شرکت یا بیمه گذار";
            this.COMPANYID_DESC.Name = "COMPANYID_DESC";
            this.COMPANYID_DESC.ReadOnly = true;
            this.COMPANYID_DESC.Width = 130;
            // 
            // REFFERFROM_DESC
            // 
            this.REFFERFROM_DESC.DataPropertyName = "REFFERFROM_DESC";
            this.REFFERFROM_DESC.HeaderText = "ارجاع از";
            this.REFFERFROM_DESC.Name = "REFFERFROM_DESC";
            this.REFFERFROM_DESC.ReadOnly = true;
            // 
            // REFERENCEUSERID_DESC
            // 
            this.REFERENCEUSERID_DESC.DataPropertyName = "REFERENCEUSERID_DESC";
            this.REFERENCEUSERID_DESC.HeaderText = "ارجاع به";
            this.REFERENCEUSERID_DESC.Name = "REFERENCEUSERID_DESC";
            this.REFERENCEUSERID_DESC.ReadOnly = true;
            // 
            // COLOR
            // 
            this.COLOR.DataPropertyName = "COLOR";
            this.COLOR.HeaderText = "COLOR";
            this.COLOR.Name = "COLOR";
            this.COLOR.ReadOnly = true;
            this.COLOR.Visible = false;
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteGroup.Location = new System.Drawing.Point(101, 3);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(146, 23);
            this.btnDeleteGroup.TabIndex = 15;
            this.btnDeleteGroup.Text = "حذف گروه انتخاب  شده";
            this.btnDeleteGroup.UseVisualStyleBackColor = true;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // BtnChangeGroupName
            // 
            this.BtnChangeGroupName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnChangeGroupName.Location = new System.Drawing.Point(253, 3);
            this.BtnChangeGroupName.Name = "BtnChangeGroupName";
            this.BtnChangeGroupName.Size = new System.Drawing.Size(146, 23);
            this.BtnChangeGroupName.TabIndex = 16;
            this.BtnChangeGroupName.Text = "تغییر نام گروه";
            this.BtnChangeGroupName.UseVisualStyleBackColor = true;
            this.BtnChangeGroupName.Click += new System.EventHandler(this.BtnChangeGroupName_Click);
            // 
            // LetterGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 586);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LetterGroup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست گروه های نامه ها";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserList_KeyDown_1);
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.searchMasterPanel.ResumeLayout(false);
            this.pnlGroupTitle.ResumeLayout(false);
            this.pnlGroupTitle.PerformLayout();
            this.pnlLetterNumbers.ResumeLayout(false);
            this.pnlLetterNumbers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLetterGroup)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.letterGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gridLetterGroup;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel searchMasterPanel;
        private System.Windows.Forms.Panel pnlGroupTitle;
        private System.Windows.Forms.TextBox txtGroupTitle;
        private System.Windows.Forms.Label lblGroupTitle;
        private System.Windows.Forms.Panel pnlLetterNumbers;
        private System.Windows.Forms.TextBox txtLetterNumbers;
        private System.Windows.Forms.Label lblLetterNumbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn RADIF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GROUPTITLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LETTERNUMBERS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView letterGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LETTERNUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn LETTERDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LETTERSUBJECT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUMMARY;
        private System.Windows.Forms.DataGridViewTextBoxColumn INSURANCETYPEID_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn INSURANCENUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn INSURANCEDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LETTERSTATEID_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPANYID_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn REFFERFROM_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn REFERENCEUSERID_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLOR;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.Button BtnChangeGroupName;
    }
}