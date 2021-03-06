﻿namespace Andicator.lists
{
    partial class LetterGroupList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RADIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 416);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 29);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTitle);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(894, 34);
            this.panel2.TabIndex = 1;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(79, 8);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(743, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(817, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "شرح گروه : ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(894, 382);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.STAR,
            this.RADIF,
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
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(894, 382);
            this.dataGridView1.TabIndex = 1;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.STAR.DefaultCellStyle = dataGridViewCellStyle1;
            this.STAR.HeaderText = "  ";
            this.STAR.Name = "STAR";
            this.STAR.ReadOnly = true;
            this.STAR.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.STAR.Visible = false;
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
            // LetterGroupList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 445);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LetterGroupList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست نامه های گروه";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LetterGroupList_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn STAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn RADIF;
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
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblName;
    }
}