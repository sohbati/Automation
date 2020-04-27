namespace Andicator.lists
{
    partial class RefCycleList
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLetterDateFrom = new System.Windows.Forms.Label();
            this.txtRefDateFrom = new System.Windows.Forms.MaskedTextBox();
            this.lblLetterDateTo = new System.Windows.Forms.Label();
            this.txtRefDateTo = new System.Windows.Forms.MaskedTextBox();
            this.cbRefferFrom = new System.Windows.Forms.CheckedListBox();
            this.lblRefferFrom = new System.Windows.Forms.Label();
            this.txtLetterNumber = new System.Windows.Forms.TextBox();
            this.lblRecievedLetterNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAction = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbArchived = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbReferAction = new System.Windows.Forms.CheckedListBox();
            this.RADIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SECONDREFERDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SECONDTOUSERID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LETTERID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACTIONDESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbCompareDate = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RADIF,
            this.ID,
            this.SECONDREFERDATE,
            this.SECONDTOUSERID,
            this.LETTERID,
            this.ACTION,
            this.ACTIONDESCRIPTION});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 178);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(957, 266);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // btnSearch
            // 
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(13, 138);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(128, 26);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.cmbCompareDate);
            this.panel2.Controls.Add(this.cbReferAction);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cbArchived);
            this.panel2.Controls.Add(this.txtAction);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtLetterNumber);
            this.panel2.Controls.Add(this.lblRecievedLetterNumber);
            this.panel2.Controls.Add(this.cbRefferFrom);
            this.panel2.Controls.Add(this.lblRefferFrom);
            this.panel2.Controls.Add(this.flowLayoutPanel2);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel2.Size = new System.Drawing.Size(957, 169);
            this.panel2.TabIndex = 4;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.14989F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.85011F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(963, 488);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 450);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(957, 35);
            this.panel3.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnDisplay);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(196, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(424, 28);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(346, 3);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 16;
            this.btnDisplay.Text = "نمایش";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblLetterDateFrom);
            this.flowLayoutPanel2.Controls.Add(this.txtRefDateFrom);
            this.flowLayoutPanel2.Controls.Add(this.lblLetterDateTo);
            this.flowLayoutPanel2.Controls.Add(this.txtRefDateTo);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(171, 7);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(383, 28);
            this.flowLayoutPanel2.TabIndex = 309;
            // 
            // lblLetterDateFrom
            // 
            this.lblLetterDateFrom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetterDateFrom.Location = new System.Drawing.Point(258, 0);
            this.lblLetterDateFrom.Name = "lblLetterDateFrom";
            this.lblLetterDateFrom.Size = new System.Drawing.Size(122, 20);
            this.lblLetterDateFrom.TabIndex = 361;
            this.lblLetterDateFrom.Tag = "";
            this.lblLetterDateFrom.Text = "برگشت ارجاع از تاریخ :‌";
            this.lblLetterDateFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRefDateFrom
            // 
            this.txtRefDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRefDateFrom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefDateFrom.ForeColor = System.Drawing.Color.Black;
            this.txtRefDateFrom.Location = new System.Drawing.Point(177, 3);
            this.txtRefDateFrom.Mask = "0000/00/00";
            this.txtRefDateFrom.Name = "txtRefDateFrom";
            this.txtRefDateFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRefDateFrom.Size = new System.Drawing.Size(75, 22);
            this.txtRefDateFrom.TabIndex = 1;
            // 
            // lblLetterDateTo
            // 
            this.lblLetterDateTo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetterDateTo.Location = new System.Drawing.Point(119, 0);
            this.lblLetterDateTo.Name = "lblLetterDateTo";
            this.lblLetterDateTo.Size = new System.Drawing.Size(52, 20);
            this.lblLetterDateTo.TabIndex = 363;
            this.lblLetterDateTo.Tag = "";
            this.lblLetterDateTo.Text = "تا تاریخ : ";
            this.lblLetterDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRefDateTo
            // 
            this.txtRefDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRefDateTo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefDateTo.ForeColor = System.Drawing.Color.Black;
            this.txtRefDateTo.Location = new System.Drawing.Point(28, 3);
            this.txtRefDateTo.Mask = "0000/00/00";
            this.txtRefDateTo.Name = "txtRefDateTo";
            this.txtRefDateTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRefDateTo.Size = new System.Drawing.Size(85, 22);
            this.txtRefDateTo.TabIndex = 364;
            // 
            // cbRefferFrom
            // 
            this.cbRefferFrom.FormattingEnabled = true;
            this.cbRefferFrom.Location = new System.Drawing.Point(591, 35);
            this.cbRefferFrom.Name = "cbRefferFrom";
            this.cbRefferFrom.Size = new System.Drawing.Size(229, 124);
            this.cbRefferFrom.TabIndex = 344;
            // 
            // lblRefferFrom
            // 
            this.lblRefferFrom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefferFrom.Location = new System.Drawing.Point(825, 27);
            this.lblRefferFrom.Name = "lblRefferFrom";
            this.lblRefferFrom.Size = new System.Drawing.Size(54, 23);
            this.lblRefferFrom.TabIndex = 343;
            this.lblRefferFrom.Text = "ارجاع از : ";
            this.lblRefferFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLetterNumber
            // 
            this.txtLetterNumber.AcceptsTab = true;
            this.txtLetterNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLetterNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterNumber.ForeColor = System.Drawing.Color.Black;
            this.txtLetterNumber.Location = new System.Drawing.Point(591, 7);
            this.txtLetterNumber.Name = "txtLetterNumber";
            this.txtLetterNumber.Size = new System.Drawing.Size(231, 22);
            this.txtLetterNumber.TabIndex = 345;
            // 
            // lblRecievedLetterNumber
            // 
            this.lblRecievedLetterNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecievedLetterNumber.Location = new System.Drawing.Point(825, 4);
            this.lblRecievedLetterNumber.Name = "lblRecievedLetterNumber";
            this.lblRecievedLetterNumber.Size = new System.Drawing.Size(100, 23);
            this.lblRecievedLetterNumber.TabIndex = 346;
            this.lblRecievedLetterNumber.Tag = "";
            this.lblRecievedLetterNumber.Text = "شماره نامه وارده :";
            this.lblRecievedLetterNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(471, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 347;
            this.label1.Text = "اقدام :‌";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAction
            // 
            this.txtAction.AcceptsTab = true;
            this.txtAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAction.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAction.ForeColor = System.Drawing.Color.Black;
            this.txtAction.Location = new System.Drawing.Point(183, 139);
            this.txtAction.Name = "txtAction";
            this.txtAction.Size = new System.Drawing.Size(282, 22);
            this.txtAction.TabIndex = 349;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(471, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 350;
            this.label2.Tag = "";
            this.label2.Text = "شرح اقدام شامل :‌";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbArchived
            // 
            this.cbArchived.AutoSize = true;
            this.cbArchived.Location = new System.Drawing.Point(32, 42);
            this.cbArchived.Name = "cbArchived";
            this.cbArchived.Size = new System.Drawing.Size(15, 14);
            this.cbArchived.TabIndex = 351;
            this.cbArchived.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 23);
            this.label4.TabIndex = 353;
            this.label4.Tag = "";
            this.label4.Text = "بایگانی شده :‌";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbReferAction
            // 
            this.cbReferAction.FormattingEnabled = true;
            this.cbReferAction.Location = new System.Drawing.Point(183, 39);
            this.cbReferAction.Name = "cbReferAction";
            this.cbReferAction.Size = new System.Drawing.Size(282, 94);
            this.cbReferAction.TabIndex = 362;
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
            // SECONDREFERDATE
            // 
            this.SECONDREFERDATE.DataPropertyName = "SECONDREFERDATE";
            this.SECONDREFERDATE.HeaderText = "تاریخ برگشت ارجاع";
            this.SECONDREFERDATE.Name = "SECONDREFERDATE";
            this.SECONDREFERDATE.ReadOnly = true;
            this.SECONDREFERDATE.Width = 130;
            // 
            // SECONDTOUSERID
            // 
            this.SECONDTOUSERID.DataPropertyName = "SECONDTOUSERID_DESC";
            this.SECONDTOUSERID.HeaderText = "کاربر ارجاع شونده";
            this.SECONDTOUSERID.Name = "SECONDTOUSERID";
            this.SECONDTOUSERID.ReadOnly = true;
            this.SECONDTOUSERID.Width = 140;
            // 
            // LETTERID
            // 
            this.LETTERID.DataPropertyName = "LETTERID_DESC";
            this.LETTERID.HeaderText = "شماره نامه";
            this.LETTERID.Name = "LETTERID";
            this.LETTERID.ReadOnly = true;
            // 
            // ACTION
            // 
            this.ACTION.DataPropertyName = "ACTION_DESC";
            this.ACTION.HeaderText = "اقدام صورت گرفته";
            this.ACTION.Name = "ACTION";
            this.ACTION.ReadOnly = true;
            this.ACTION.Width = 150;
            // 
            // ACTIONDESCRIPTION
            // 
            this.ACTIONDESCRIPTION.DataPropertyName = "ACTIONDESCRIPTION";
            this.ACTIONDESCRIPTION.HeaderText = "شرح اقدام";
            this.ACTIONDESCRIPTION.Name = "ACTIONDESCRIPTION";
            this.ACTIONDESCRIPTION.ReadOnly = true;
            this.ACTIONDESCRIPTION.Width = 250;
            // 
            // cmbCompareDate
            // 
            this.cmbCompareDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompareDate.FormattingEnabled = true;
            this.cmbCompareDate.Items.AddRange(new object[] {
            "مساوی با",
            "کوچکتر از",
            "کوچکتر مساوی ",
            "بزرگتر از",
            "بزرگتر مساوی",
            "مابین"});
            this.cmbCompareDate.Location = new System.Drawing.Point(93, 11);
            this.cmbCompareDate.Name = "cmbCompareDate";
            this.cmbCompareDate.Size = new System.Drawing.Size(72, 21);
            this.cmbCompareDate.TabIndex = 363;
            this.cmbCompareDate.Visible = false;
            // 
            // RefCycleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 488);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "RefCycleList";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست برگشت ارجاعات کابران";
            this.Load += new System.EventHandler(this.RefCycleList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RefCycleList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblLetterDateFrom;
        private System.Windows.Forms.MaskedTextBox txtRefDateFrom;
        private System.Windows.Forms.Label lblLetterDateTo;
        private System.Windows.Forms.MaskedTextBox txtRefDateTo;
        private System.Windows.Forms.CheckedListBox cbRefferFrom;
        private System.Windows.Forms.Label lblRefferFrom;
        private System.Windows.Forms.TextBox txtLetterNumber;
        private System.Windows.Forms.Label lblRecievedLetterNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbArchived;
        private System.Windows.Forms.CheckedListBox cbReferAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn RADIF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SECONDREFERDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SECONDTOUSERID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LETTERID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACTIONDESCRIPTION;
        private System.Windows.Forms.ComboBox cmbCompareDate;
    }
}