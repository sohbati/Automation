namespace Andicator.lists
{
    partial class ReferenceCycleList
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
            this.lblTelephone = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RADIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGENTNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGENTCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELEPHONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOBILE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.searchMasterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlAgentName = new System.Windows.Forms.Panel();
            this.txtAgentName = new System.Windows.Forms.TextBox();
            this.lblAgentName = new System.Windows.Forms.Label();
            this.pnlAgentcode = new System.Windows.Forms.Panel();
            this.txtAgentCode = new System.Windows.Forms.TextBox();
            this.lblAgentCode = new System.Windows.Forms.Label();
            this.pnlTelephone = new System.Windows.Forms.Panel();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.pnlMobile = new System.Windows.Forms.Panel();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.pnlFax = new System.Windows.Forms.Panel();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.pnlAddress = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.searchMasterPanel.SuspendLayout();
            this.pnlAgentName.SuspendLayout();
            this.pnlAgentcode.SuspendLayout();
            this.pnlTelephone.SuspendLayout();
            this.pnlMobile.SuspendLayout();
            this.pnlFax.SuspendLayout();
            this.pnlAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTelephone
            // 
            this.lblTelephone.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTelephone.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTelephone.Location = new System.Drawing.Point(243, 3);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(44, 23);
            this.lblTelephone.TabIndex = 21;
            this.lblTelephone.Text = "تلفن : ";
            this.lblTelephone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.017544F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.98245F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(869, 497);
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
            this.AGENTNAME,
            this.AGENTCODE,
            this.TELEPHONE,
            this.MOBILE,
            this.FAX,
            this.ADDRESS});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(863, 418);
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
            // AGENTNAME
            // 
            this.AGENTNAME.DataPropertyName = "AGENTNAME";
            this.AGENTNAME.HeaderText = "نام نماینده";
            this.AGENTNAME.Name = "AGENTNAME";
            this.AGENTNAME.ReadOnly = true;
            this.AGENTNAME.Width = 200;
            // 
            // AGENTCODE
            // 
            this.AGENTCODE.DataPropertyName = "AGENTCODE";
            this.AGENTCODE.HeaderText = "کد نماینده";
            this.AGENTCODE.Name = "AGENTCODE";
            this.AGENTCODE.ReadOnly = true;
            // 
            // TELEPHONE
            // 
            this.TELEPHONE.DataPropertyName = "TELEPHONE";
            this.TELEPHONE.HeaderText = "تلفن";
            this.TELEPHONE.Name = "TELEPHONE";
            this.TELEPHONE.ReadOnly = true;
            // 
            // MOBILE
            // 
            this.MOBILE.DataPropertyName = "MOBILE";
            this.MOBILE.HeaderText = "موبایل";
            this.MOBILE.Name = "MOBILE";
            this.MOBILE.ReadOnly = true;
            this.MOBILE.Width = 120;
            // 
            // FAX
            // 
            this.FAX.DataPropertyName = "FAX";
            this.FAX.HeaderText = "فکس";
            this.FAX.Name = "FAX";
            this.FAX.ReadOnly = true;
            this.FAX.Width = 120;
            // 
            // ADDRESS
            // 
            this.ADDRESS.DataPropertyName = "ADDRESS";
            this.ADDRESS.HeaderText = "آدرس";
            this.ADDRESS.Name = "ADDRESS";
            this.ADDRESS.ReadOnly = true;
            this.ADDRESS.Width = 200;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 459);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(863, 35);
            this.panel3.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnNew);
            this.flowLayoutPanel1.Controls.Add(this.btnDisplay);
            this.flowLayoutPanel1.Controls.Add(this.btnSelect);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(196, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(380, 28);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(3, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(84, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "جدید";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(165, 3);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 16;
            this.btnDisplay.Text = "نمایش";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(246, 3);
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
            this.panel2.Size = new System.Drawing.Size(863, 26);
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
            this.searchMasterPanel.Controls.Add(this.pnlAgentName);
            this.searchMasterPanel.Controls.Add(this.pnlAgentcode);
            this.searchMasterPanel.Controls.Add(this.pnlTelephone);
            this.searchMasterPanel.Controls.Add(this.pnlMobile);
            this.searchMasterPanel.Controls.Add(this.pnlFax);
            this.searchMasterPanel.Controls.Add(this.pnlAddress);
            this.searchMasterPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.searchMasterPanel.Location = new System.Drawing.Point(512, -5);
            this.searchMasterPanel.Name = "searchMasterPanel";
            this.searchMasterPanel.Size = new System.Drawing.Size(367, 210);
            this.searchMasterPanel.TabIndex = 14;
            // 
            // pnlAgentName
            // 
            this.pnlAgentName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlAgentName.Controls.Add(this.txtAgentName);
            this.pnlAgentName.Controls.Add(this.lblAgentName);
            this.pnlAgentName.Location = new System.Drawing.Point(5, 3);
            this.pnlAgentName.Name = "pnlAgentName";
            this.pnlAgentName.Size = new System.Drawing.Size(359, 28);
            this.pnlAgentName.TabIndex = 0;
            // 
            // txtAgentName
            // 
            this.txtAgentName.AcceptsTab = true;
            this.txtAgentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAgentName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtAgentName.ForeColor = System.Drawing.Color.Black;
            this.txtAgentName.Location = new System.Drawing.Point(3, 3);
            this.txtAgentName.Name = "txtAgentName";
            this.txtAgentName.Size = new System.Drawing.Size(234, 22);
            this.txtAgentName.TabIndex = 5;
            // 
            // lblAgentName
            // 
            this.lblAgentName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAgentName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAgentName.Location = new System.Drawing.Point(243, 2);
            this.lblAgentName.Name = "lblAgentName";
            this.lblAgentName.Size = new System.Drawing.Size(74, 23);
            this.lblAgentName.TabIndex = 7;
            this.lblAgentName.Tag = "";
            this.lblAgentName.Text = "نام نماینده : ";
            this.lblAgentName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlAgentcode
            // 
            this.pnlAgentcode.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlAgentcode.Controls.Add(this.txtAgentCode);
            this.pnlAgentcode.Controls.Add(this.lblAgentCode);
            this.pnlAgentcode.Location = new System.Drawing.Point(5, 37);
            this.pnlAgentcode.Name = "pnlAgentcode";
            this.pnlAgentcode.Size = new System.Drawing.Size(359, 28);
            this.pnlAgentcode.TabIndex = 2;
            // 
            // txtAgentCode
            // 
            this.txtAgentCode.AcceptsTab = true;
            this.txtAgentCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAgentCode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtAgentCode.ForeColor = System.Drawing.Color.Black;
            this.txtAgentCode.Location = new System.Drawing.Point(3, 3);
            this.txtAgentCode.Name = "txtAgentCode";
            this.txtAgentCode.Size = new System.Drawing.Size(234, 22);
            this.txtAgentCode.TabIndex = 5;
            // 
            // lblAgentCode
            // 
            this.lblAgentCode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAgentCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAgentCode.Location = new System.Drawing.Point(243, 1);
            this.lblAgentCode.Name = "lblAgentCode";
            this.lblAgentCode.Size = new System.Drawing.Size(74, 23);
            this.lblAgentCode.TabIndex = 7;
            this.lblAgentCode.Tag = "";
            this.lblAgentCode.Text = "کد نماینده : ";
            this.lblAgentCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlTelephone
            // 
            this.pnlTelephone.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlTelephone.Controls.Add(this.txtTelephone);
            this.pnlTelephone.Controls.Add(this.lblTelephone);
            this.pnlTelephone.Location = new System.Drawing.Point(5, 71);
            this.pnlTelephone.Name = "pnlTelephone";
            this.pnlTelephone.Size = new System.Drawing.Size(359, 28);
            this.pnlTelephone.TabIndex = 5;
            // 
            // txtTelephone
            // 
            this.txtTelephone.AcceptsTab = true;
            this.txtTelephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelephone.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtTelephone.ForeColor = System.Drawing.Color.Black;
            this.txtTelephone.Location = new System.Drawing.Point(3, 4);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(234, 22);
            this.txtTelephone.TabIndex = 22;
            // 
            // pnlMobile
            // 
            this.pnlMobile.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlMobile.Controls.Add(this.txtMobile);
            this.pnlMobile.Controls.Add(this.lblMobile);
            this.pnlMobile.Location = new System.Drawing.Point(5, 105);
            this.pnlMobile.Name = "pnlMobile";
            this.pnlMobile.Size = new System.Drawing.Size(359, 28);
            this.pnlMobile.TabIndex = 6;
            // 
            // txtMobile
            // 
            this.txtMobile.AcceptsTab = true;
            this.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobile.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMobile.ForeColor = System.Drawing.Color.Black;
            this.txtMobile.Location = new System.Drawing.Point(3, 3);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(234, 22);
            this.txtMobile.TabIndex = 5;
            // 
            // lblMobile
            // 
            this.lblMobile.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblMobile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMobile.Location = new System.Drawing.Point(243, 1);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(51, 23);
            this.lblMobile.TabIndex = 7;
            this.lblMobile.Tag = "";
            this.lblMobile.Text = "موبایل : ";
            this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // 
            // lblFax
            // 
            this.lblFax.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFax.Location = new System.Drawing.Point(243, 1);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(48, 23);
            this.lblFax.TabIndex = 7;
            this.lblFax.Tag = "";
            this.lblFax.Text = "فکس : ";
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
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAddress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAddress.Location = new System.Drawing.Point(243, 1);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 23);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Tag = "";
            this.lblAddress.Text = "آدرس : ";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AgentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 497);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgentList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست نمایندگان";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AgentList_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.searchMasterPanel.ResumeLayout(false);
            this.pnlAgentName.ResumeLayout(false);
            this.pnlAgentName.PerformLayout();
            this.pnlAgentcode.ResumeLayout(false);
            this.pnlAgentcode.PerformLayout();
            this.pnlTelephone.ResumeLayout(false);
            this.pnlTelephone.PerformLayout();
            this.pnlMobile.ResumeLayout(false);
            this.pnlMobile.PerformLayout();
            this.pnlFax.ResumeLayout(false);
            this.pnlFax.PerformLayout();
            this.pnlAddress.ResumeLayout(false);
            this.pnlAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel searchMasterPanel;
        private System.Windows.Forms.Panel pnlAgentName;
        private System.Windows.Forms.TextBox txtAgentName;
        private System.Windows.Forms.Label lblAgentName;
        private System.Windows.Forms.Panel pnlAgentcode;
        private System.Windows.Forms.TextBox txtAgentCode;
        private System.Windows.Forms.Label lblAgentCode;
        private System.Windows.Forms.Panel pnlTelephone;
        private System.Windows.Forms.Panel pnlMobile;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Panel pnlFax;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.Panel pnlAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn RADIF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AGENTNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn AGENTCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELEPHONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOBILE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADDRESS;
    }
}