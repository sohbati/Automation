namespace Andicator.controls
{
    partial class RefferToForm
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
            this.lblMsg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.txtRefferDate = new System.Windows.Forms.MaskedTextBox();
            this.lblRefferDate = new System.Windows.Forms.Label();
            this.grpPannel = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbAdmins = new System.Windows.Forms.RadioButton();
            this.rbUsers = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lstUserList = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnReffferLetter = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.grpPannel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Silver;
            this.lblMsg.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Black;
            this.lblMsg.Location = new System.Drawing.Point(78, 3);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(361, 28);
            this.lblMsg.TabIndex = 5;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.pnlDate);
            this.panel1.Controls.Add(this.grpPannel);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(17, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 295);
            this.panel1.TabIndex = 1;
            // 
            // pnlDate
            // 
            this.pnlDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDate.Controls.Add(this.txtRefferDate);
            this.pnlDate.Controls.Add(this.lblRefferDate);
            this.pnlDate.Location = new System.Drawing.Point(5, 3);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(455, 31);
            this.pnlDate.TabIndex = 341;
            // 
            // txtRefferDate
            // 
            this.txtRefferDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRefferDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefferDate.ForeColor = System.Drawing.Color.Black;
            this.txtRefferDate.Location = new System.Drawing.Point(167, 4);
            this.txtRefferDate.Mask = "0000/00/00";
            this.txtRefferDate.Name = "txtRefferDate";
            this.txtRefferDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRefferDate.Size = new System.Drawing.Size(152, 22);
            this.txtRefferDate.TabIndex = 339;
            // 
            // lblRefferDate
            // 
            this.lblRefferDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefferDate.Location = new System.Drawing.Point(319, 2);
            this.lblRefferDate.Name = "lblRefferDate";
            this.lblRefferDate.Size = new System.Drawing.Size(127, 23);
            this.lblRefferDate.TabIndex = 340;
            this.lblRefferDate.Text = "تاریخ شروع آلارم ارجاع : ";
            this.lblRefferDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpPannel
            // 
            this.grpPannel.Controls.Add(this.panel5);
            this.grpPannel.Controls.Add(this.panel4);
            this.grpPannel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPannel.Location = new System.Drawing.Point(3, 40);
            this.grpPannel.Name = "grpPannel";
            this.grpPannel.Size = new System.Drawing.Size(456, 250);
            this.grpPannel.TabIndex = 0;
            this.grpPannel.TabStop = false;
            this.grpPannel.Text = "ارجاع  به : ";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.rbAdmins);
            this.panel5.Controls.Add(this.rbUsers);
            this.panel5.Location = new System.Drawing.Point(6, 23);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(441, 34);
            this.panel5.TabIndex = 3;
            // 
            // rbAdmins
            // 
            this.rbAdmins.AutoSize = true;
            this.rbAdmins.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAdmins.Location = new System.Drawing.Point(232, 9);
            this.rbAdmins.Name = "rbAdmins";
            this.rbAdmins.Size = new System.Drawing.Size(64, 20);
            this.rbAdmins.TabIndex = 1;
            this.rbAdmins.TabStop = true;
            this.rbAdmins.Text = "به مدیر";
            this.rbAdmins.UseVisualStyleBackColor = true;
            this.rbAdmins.Click += new System.EventHandler(this.radioButtons_changed);
            // 
            // rbUsers
            // 
            this.rbUsers.AutoSize = true;
            this.rbUsers.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUsers.Location = new System.Drawing.Point(327, 8);
            this.rbUsers.Name = "rbUsers";
            this.rbUsers.Size = new System.Drawing.Size(77, 20);
            this.rbUsers.TabIndex = 0;
            this.rbUsers.TabStop = true;
            this.rbUsers.Text = "به کاربران";
            this.rbUsers.UseVisualStyleBackColor = true;
            this.rbUsers.Click += new System.EventHandler(this.radioButtons_changed);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lstUserList);
            this.panel4.Location = new System.Drawing.Point(6, 62);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(444, 184);
            this.panel4.TabIndex = 2;
            // 
            // lstUserList
            // 
            this.lstUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUserList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstUserList.ForeColor = System.Drawing.Color.Black;
            this.lstUserList.FormattingEnabled = true;
            this.lstUserList.ItemHeight = 16;
            this.lstUserList.Location = new System.Drawing.Point(0, 0);
            this.lstUserList.Name = "lstUserList";
            this.lstUserList.Size = new System.Drawing.Size(444, 184);
            this.lstUserList.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.btnReffferLetter);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 376);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(497, 36);
            this.panel3.TabIndex = 201;
            // 
            // btnReffferLetter
            // 
            this.btnReffferLetter.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReffferLetter.Location = new System.Drawing.Point(175, 3);
            this.btnReffferLetter.Name = "btnReffferLetter";
            this.btnReffferLetter.Size = new System.Drawing.Size(145, 23);
            this.btnReffferLetter.TabIndex = 14;
            this.btnReffferLetter.Text = "ارجاع";
            this.btnReffferLetter.UseVisualStyleBackColor = true;
            this.btnReffferLetter.Click += new System.EventHandler(this.btnReffferLetter_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.lblMsg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(497, 40);
            this.panel2.TabIndex = 202;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(503, 415);
            this.tableLayoutPanel1.TabIndex = 204;
            // 
            // RefferToForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 415);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RefferToForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ارجاع نامه ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RefferToForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.grpPannel.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpPannel;
        private System.Windows.Forms.Button btnReffferLetter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbAdmins;
        private System.Windows.Forms.RadioButton rbUsers;
        private System.Windows.Forms.ListBox lstUserList;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.MaskedTextBox txtRefferDate;
        private System.Windows.Forms.Label lblRefferDate;
        private System.Windows.Forms.Panel pnlDate;
    }
}