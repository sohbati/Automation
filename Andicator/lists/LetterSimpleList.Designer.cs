namespace Andicator.lists
{
    partial class LetterSimpleList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.INSURANCENUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCurLetterAll = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RADIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LETTERTYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LETTERTYPE_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LETTERNUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LETTERDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LETTERSUBJECT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUMMARY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INSURANCETYPEID_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INSURANCEDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LETTERSTATEID_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPANYID_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REFFERFROM_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REFERENCEUSERID_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridCurLetterAll)).BeginInit();
            this.SuspendLayout();
            // 
            // INSURANCENUMBER
            // 
            this.INSURANCENUMBER.DataPropertyName = "INSURANCENUMBER";
            this.INSURANCENUMBER.HeaderText = "شماره بیمه";
            this.INSURANCENUMBER.Name = "INSURANCENUMBER";
            this.INSURANCENUMBER.ReadOnly = true;
            this.INSURANCENUMBER.Visible = false;
            // 
            // gridCurLetterAll
            // 
            this.gridCurLetterAll.AllowUserToAddRows = false;
            this.gridCurLetterAll.AllowUserToDeleteRows = false;
            this.gridCurLetterAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCurLetterAll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.STAR,
            this.RADIF,
            this.LETTERTYPE,
            this.LETTERTYPE_DESC,
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
            this.gridCurLetterAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCurLetterAll.Location = new System.Drawing.Point(0, 0);
            this.gridCurLetterAll.Name = "gridCurLetterAll";
            this.gridCurLetterAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridCurLetterAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridCurLetterAll.Size = new System.Drawing.Size(955, 464);
            this.gridCurLetterAll.TabIndex = 3;
            this.gridCurLetterAll.DoubleClick += new System.EventHandler(this.gridCurLetterAll_DoubleClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.DividerWidth = 1;
            this.id.HeaderText = "شناسه";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // STAR
            // 
            this.STAR.DataPropertyName = "STAR";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.MediumBlue;
            this.STAR.DefaultCellStyle = dataGridViewCellStyle4;
            this.STAR.HeaderText = "  ";
            this.STAR.Name = "STAR";
            this.STAR.ReadOnly = true;
            this.STAR.Width = 30;
            // 
            // RADIF
            // 
            this.RADIF.DataPropertyName = "RADIF";
            this.RADIF.HeaderText = "ردیف";
            this.RADIF.Name = "RADIF";
            this.RADIF.ReadOnly = true;
            this.RADIF.Width = 40;
            // 
            // LETTERTYPE
            // 
            this.LETTERTYPE.DataPropertyName = "LETTERTYPE";
            this.LETTERTYPE.HeaderText = "نوع نامه";
            this.LETTERTYPE.Name = "LETTERTYPE";
            this.LETTERTYPE.ReadOnly = true;
            this.LETTERTYPE.Visible = false;
            // 
            // LETTERTYPE_DESC
            // 
            this.LETTERTYPE_DESC.DataPropertyName = "LETTERTYPE_DESC";
            this.LETTERTYPE_DESC.HeaderText = "نوع نامه";
            this.LETTERTYPE_DESC.Name = "LETTERTYPE_DESC";
            this.LETTERTYPE_DESC.ReadOnly = true;
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
            // LetterSimpleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 464);
            this.Controls.Add(this.gridCurLetterAll);
            this.KeyPreview = true;
            this.Name = "LetterSimpleList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست نامه ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LetterSimpleList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridCurLetterAll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn INSURANCENUMBER;
        private System.Windows.Forms.DataGridView gridCurLetterAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn STAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn RADIF;
        private System.Windows.Forms.DataGridViewTextBoxColumn LETTERTYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LETTERTYPE_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn LETTERNUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn LETTERDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LETTERSUBJECT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUMMARY;
        private System.Windows.Forms.DataGridViewTextBoxColumn INSURANCETYPEID_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn INSURANCEDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LETTERSTATEID_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPANYID_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn REFFERFROM_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn REFERENCEUSERID_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLOR;
    }
}