namespace Andicator.lists
{
    partial class LetterGroupSelect
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.searchMasterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlGroupTitle = new System.Windows.Forms.Panel();
            this.txtGroupTitle = new System.Windows.Forms.TextBox();
            this.lblGroupTitle = new System.Windows.Forms.Label();
            this.pnlLetterNumbers = new System.Windows.Forms.Panel();
            this.txtLetterNumbers = new System.Windows.Forms.TextBox();
            this.lblLetterNumbers = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RADIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GROUPTITLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LETTERNUMBERS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSelectNewGroup = new System.Windows.Forms.Button();
            this.txtNewGroupTitle = new System.Windows.Forms.TextBox();
            this.lblNewGroupTitle = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.searchMasterPanel.SuspendLayout();
            this.pnlGroupTitle.SuspendLayout();
            this.pnlLetterNumbers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 351);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(906, 35);
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(906, 38);
            this.panel2.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearch.Location = new System.Drawing.Point(454, 3);
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
            this.searchMasterPanel.Location = new System.Drawing.Point(535, 3);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RADIF,
            this.ID,
            this.GROUPTITLE,
            this.LETTERNUMBERS});
            this.dataGridView1.Location = new System.Drawing.Point(5, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(896, 308);
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
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 351);
            this.panel1.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(920, 421);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.txtNewGroupTitle);
            this.tabPage1.Controls.Add(this.lblNewGroupTitle);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(912, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "گروه جدید";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.Controls.Add(this.flowLayoutPanel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 354);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(906, 35);
            this.panel5.TabIndex = 10;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.button1);
            this.flowLayoutPanel2.Controls.Add(this.btnSelectNewGroup);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(247, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(239, 28);
            this.flowLayoutPanel2.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "بستن";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSelectNewGroup
            // 
            this.btnSelectNewGroup.Location = new System.Drawing.Point(84, 3);
            this.btnSelectNewGroup.Name = "btnSelectNewGroup";
            this.btnSelectNewGroup.Size = new System.Drawing.Size(117, 23);
            this.btnSelectNewGroup.TabIndex = 17;
            this.btnSelectNewGroup.Text = "انتخاب";
            this.btnSelectNewGroup.UseVisualStyleBackColor = true;
            this.btnSelectNewGroup.Click += new System.EventHandler(this.btnSelectNewGroup_Click);
            // 
            // txtNewGroupTitle
            // 
            this.txtNewGroupTitle.AcceptsTab = true;
            this.txtNewGroupTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewGroupTitle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtNewGroupTitle.ForeColor = System.Drawing.Color.Black;
            this.txtNewGroupTitle.Location = new System.Drawing.Point(576, 19);
            this.txtNewGroupTitle.Name = "txtNewGroupTitle";
            this.txtNewGroupTitle.Size = new System.Drawing.Size(234, 22);
            this.txtNewGroupTitle.TabIndex = 8;
            // 
            // lblNewGroupTitle
            // 
            this.lblNewGroupTitle.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblNewGroupTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNewGroupTitle.Location = new System.Drawing.Point(816, 18);
            this.lblNewGroupTitle.Name = "lblNewGroupTitle";
            this.lblNewGroupTitle.Size = new System.Drawing.Size(83, 23);
            this.lblNewGroupTitle.TabIndex = 9;
            this.lblNewGroupTitle.Tag = "";
            this.lblNewGroupTitle.Text = " عنوان گروه : ";
            this.lblNewGroupTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(912, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "گروه های موجود";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(906, 386);
            this.panel4.TabIndex = 0;
            // 
            // LetterGroupSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 421);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LetterGroupSelect";
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSelectNewGroup;
        private System.Windows.Forms.TextBox txtNewGroupTitle;
        private System.Windows.Forms.Label lblNewGroupTitle;
    }
}