namespace Andicator.controls
{
    partial class ReferenceCycleForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtFirstRefToUser = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblActive = new System.Windows.Forms.Label();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.lblOfficer = new System.Windows.Forms.Label();
            this.txtLetterNumber = new System.Windows.Forms.TextBox();
            this.lblAgentName = new System.Windows.Forms.Label();
            this.txtFirstRefFromUser = new System.Windows.Forms.TextBox();
            this.txtActionDesc = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSecondRefFromUser = new System.Windows.Forms.TextBox();
            this.txtSecondRefToUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbArchive = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFirstRefDate = new System.Windows.Forms.MaskedTextBox();
            this.txtSecondRefDate = new System.Windows.Forms.MaskedTextBox();
            this.btnLetter = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 29);
            this.panel1.TabIndex = 200;
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblMsg.Location = new System.Drawing.Point(181, 2);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(361, 23);
            this.lblMsg.TabIndex = 5;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFirstRefToUser
            // 
            this.txtFirstRefToUser.AcceptsTab = true;
            this.txtFirstRefToUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstRefToUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstRefToUser.ForeColor = System.Drawing.Color.Black;
            this.txtFirstRefToUser.Location = new System.Drawing.Point(6, 89);
            this.txtFirstRefToUser.Name = "txtFirstRefToUser";
            this.txtFirstRefToUser.ReadOnly = true;
            this.txtFirstRefToUser.Size = new System.Drawing.Size(153, 22);
            this.txtFirstRefToUser.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(338, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 25);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "ثبت";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Controls.Add(this.btnLetter);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cbArchive);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.lblActive);
            this.panel3.Controls.Add(this.cmbAction);
            this.panel3.Controls.Add(this.txtLetterNumber);
            this.panel3.Controls.Add(this.lblAgentName);
            this.panel3.Controls.Add(this.txtActionDesc);
            this.panel3.Controls.Add(this.lblAddress);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(6, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(810, 359);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.TabIndex = 116;
            this.label1.Tag = "";
            this.label1.Text = "ارجاع به :‌";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblActive
            // 
            this.lblActive.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActive.Location = new System.Drawing.Point(674, 172);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(56, 23);
            this.lblActive.TabIndex = 113;
            this.lblActive.Text = "اقدام :‌";
            this.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbAction
            // 
            this.cmbAction.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(508, 169);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(157, 21);
            this.cmbAction.TabIndex = 6;
            // 
            // lblOfficer
            // 
            this.lblOfficer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOfficer.Location = new System.Drawing.Point(156, 31);
            this.lblOfficer.Name = "lblOfficer";
            this.lblOfficer.Size = new System.Drawing.Size(85, 23);
            this.lblOfficer.TabIndex = 108;
            this.lblOfficer.Tag = "";
            this.lblOfficer.Text = "تاریخ ارجاع : ";
            this.lblOfficer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLetterNumber
            // 
            this.txtLetterNumber.AcceptsTab = true;
            this.txtLetterNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLetterNumber.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetterNumber.ForeColor = System.Drawing.Color.Black;
            this.txtLetterNumber.Location = new System.Drawing.Point(508, 6);
            this.txtLetterNumber.Name = "txtLetterNumber";
            this.txtLetterNumber.ReadOnly = true;
            this.txtLetterNumber.Size = new System.Drawing.Size(164, 22);
            this.txtLetterNumber.TabIndex = 0;
            // 
            // lblAgentName
            // 
            this.lblAgentName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgentName.Location = new System.Drawing.Point(678, 5);
            this.lblAgentName.Name = "lblAgentName";
            this.lblAgentName.Size = new System.Drawing.Size(131, 23);
            this.lblAgentName.TabIndex = 107;
            this.lblAgentName.Tag = "";
            this.lblAgentName.Text = "شماره نامه :‌";
            this.lblAgentName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFirstRefFromUser
            // 
            this.txtFirstRefFromUser.AcceptsTab = true;
            this.txtFirstRefFromUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstRefFromUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstRefFromUser.ForeColor = System.Drawing.Color.Black;
            this.txtFirstRefFromUser.Location = new System.Drawing.Point(6, 59);
            this.txtFirstRefFromUser.Name = "txtFirstRefFromUser";
            this.txtFirstRefFromUser.ReadOnly = true;
            this.txtFirstRefFromUser.Size = new System.Drawing.Size(151, 22);
            this.txtFirstRefFromUser.TabIndex = 2;
            // 
            // txtActionDesc
            // 
            this.txtActionDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActionDesc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActionDesc.ForeColor = System.Drawing.Color.Black;
            this.txtActionDesc.Location = new System.Drawing.Point(76, 199);
            this.txtActionDesc.Multiline = true;
            this.txtActionDesc.Name = "txtActionDesc";
            this.txtActionDesc.Size = new System.Drawing.Size(596, 69);
            this.txtActionDesc.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(675, 202);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(100, 23);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "شرح اقدام :‌";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTel
            // 
            this.lblTel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel.Location = new System.Drawing.Point(160, 56);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(85, 23);
            this.lblTel.TabIndex = 2;
            this.lblTel.Tag = "";
            this.lblTel.Text = "ارجاع از :‌";
            this.lblTel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 412);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(810, 28);
            this.panel2.TabIndex = 200;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(822, 446);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFirstRefDate);
            this.groupBox1.Controls.Add(this.txtFirstRefFromUser);
            this.groupBox1.Controls.Add(this.txtFirstRefToUser);
            this.groupBox1.Controls.Add(this.lblTel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblOfficer);
            this.groupBox1.Location = new System.Drawing.Point(508, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 117);
            this.groupBox1.TabIndex = 117;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ارجاع اول";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSecondRefDate);
            this.groupBox2.Controls.Add(this.txtSecondRefFromUser);
            this.groupBox2.Controls.Add(this.txtSecondRefToUser);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(181, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 117);
            this.groupBox2.TabIndex = 118;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ارجاع دوم :‌";
            // 
            // txtSecondRefFromUser
            // 
            this.txtSecondRefFromUser.AcceptsTab = true;
            this.txtSecondRefFromUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecondRefFromUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondRefFromUser.ForeColor = System.Drawing.Color.Black;
            this.txtSecondRefFromUser.Location = new System.Drawing.Point(6, 59);
            this.txtSecondRefFromUser.Name = "txtSecondRefFromUser";
            this.txtSecondRefFromUser.ReadOnly = true;
            this.txtSecondRefFromUser.Size = new System.Drawing.Size(151, 22);
            this.txtSecondRefFromUser.TabIndex = 2;
            // 
            // txtSecondRefToUser
            // 
            this.txtSecondRefToUser.AcceptsTab = true;
            this.txtSecondRefToUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecondRefToUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondRefToUser.ForeColor = System.Drawing.Color.Black;
            this.txtSecondRefToUser.Location = new System.Drawing.Point(6, 89);
            this.txtSecondRefToUser.Name = "txtSecondRefToUser";
            this.txtSecondRefToUser.ReadOnly = true;
            this.txtSecondRefToUser.Size = new System.Drawing.Size(153, 22);
            this.txtSecondRefToUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(160, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 23);
            this.label2.TabIndex = 2;
            this.label2.Tag = "";
            this.label2.Text = "ارجاع از :‌";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(161, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 23);
            this.label3.TabIndex = 116;
            this.label3.Tag = "";
            this.label3.Text = "ارجاع به :‌";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(156, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 108;
            this.label4.Tag = "";
            this.label4.Text = "تاریخ ارجاع : ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbArchive
            // 
            this.cbArchive.AutoSize = true;
            this.cbArchive.Location = new System.Drawing.Point(658, 284);
            this.cbArchive.Name = "cbArchive";
            this.cbArchive.Size = new System.Drawing.Size(15, 14);
            this.cbArchive.TabIndex = 119;
            this.cbArchive.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(679, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 120;
            this.label5.Text = "بایگانی :‌";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFirstRefDate
            // 
            this.txtFirstRefDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstRefDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstRefDate.ForeColor = System.Drawing.Color.Black;
            this.txtFirstRefDate.Location = new System.Drawing.Point(6, 31);
            this.txtFirstRefDate.Mask = "0000/00/00";
            this.txtFirstRefDate.Name = "txtFirstRefDate";
            this.txtFirstRefDate.ReadOnly = true;
            this.txtFirstRefDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFirstRefDate.Size = new System.Drawing.Size(151, 22);
            this.txtFirstRefDate.TabIndex = 121;
            // 
            // txtSecondRefDate
            // 
            this.txtSecondRefDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecondRefDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondRefDate.ForeColor = System.Drawing.Color.Black;
            this.txtSecondRefDate.Location = new System.Drawing.Point(8, 31);
            this.txtSecondRefDate.Mask = "0000/00/00";
            this.txtSecondRefDate.Name = "txtSecondRefDate";
            this.txtSecondRefDate.ReadOnly = true;
            this.txtSecondRefDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSecondRefDate.Size = new System.Drawing.Size(150, 22);
            this.txtSecondRefDate.TabIndex = 122;
            // 
            // btnLetter
            // 
            this.btnLetter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnLetter.Location = new System.Drawing.Point(401, 5);
            this.btnLetter.Name = "btnLetter";
            this.btnLetter.Size = new System.Drawing.Size(101, 23);
            this.btnLetter.TabIndex = 121;
            this.btnLetter.Text = "مشاهده نامه";
            this.btnLetter.UseVisualStyleBackColor = true;
            this.btnLetter.Click += new System.EventHandler(this.btnLetter_Click);
            // 
            // ReferenceCycleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 446);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ReferenceCycleForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم برگشت ارجاعات کاربران";
            this.Load += new System.EventHandler(this.ReferenceCycleForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReferenceCycleForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtFirstRefToUser;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.Label lblOfficer;
        private System.Windows.Forms.TextBox txtLetterNumber;
        private System.Windows.Forms.Label lblAgentName;
        private System.Windows.Forms.TextBox txtFirstRefFromUser;
        private System.Windows.Forms.TextBox txtActionDesc;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbArchive;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSecondRefFromUser;
        private System.Windows.Forms.TextBox txtSecondRefToUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtFirstRefDate;
        private System.Windows.Forms.MaskedTextBox txtSecondRefDate;
        private System.Windows.Forms.Button btnLetter;
    }
}