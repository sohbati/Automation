namespace Andicator.controls
{
    partial class DeleteUserForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnReffferLetter = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTextMessage = new System.Windows.Forms.Label();
            this.lblReferenceUserId = new System.Windows.Forms.Label();
            this.cmbReferenceUserId = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblMsg.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblMsg.Location = new System.Drawing.Point(78, 3);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(361, 28);
            this.lblMsg.TabIndex = 5;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.btnDeleteUser);
            this.panel3.Controls.Add(this.btnReffferLetter);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 287);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(577, 36);
            this.panel3.TabIndex = 201;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.Location = new System.Drawing.Point(112, 4);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(163, 23);
            this.btnDeleteUser.TabIndex = 15;
            this.btnDeleteUser.Text = "برداشتن کاربر از درخت";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnReffferLetter
            // 
            this.btnReffferLetter.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReffferLetter.Location = new System.Drawing.Point(281, 4);
            this.btnReffferLetter.Name = "btnReffferLetter";
            this.btnReffferLetter.Size = new System.Drawing.Size(144, 23);
            this.btnReffferLetter.TabIndex = 14;
            this.btnReffferLetter.Text = "ارجاع";
            this.btnReffferLetter.UseVisualStyleBackColor = true;
            this.btnReffferLetter.Click += new System.EventHandler(this.btnReffferLetter_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.lblMsg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 29);
            this.panel2.TabIndex = 202;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.lbl4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbl3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblTextMessage);
            this.panel1.Controls.Add(this.lblReferenceUserId);
            this.panel1.Controls.Add(this.cmbReferenceUserId);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(17, 51);
            this.panel1.Margin = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 217);
            this.panel1.TabIndex = 1;
            // 
            // lblTextMessage
            // 
            this.lblTextMessage.AccessibleDescription = "";
            this.lblTextMessage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTextMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTextMessage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextMessage.ForeColor = System.Drawing.Color.Red;
            this.lblTextMessage.Location = new System.Drawing.Point(16, 9);
            this.lblTextMessage.Name = "lblTextMessage";
            this.lblTextMessage.Size = new System.Drawing.Size(530, 27);
            this.lblTextMessage.TabIndex = 331;
            this.lblTextMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReferenceUserId
            // 
            this.lblReferenceUserId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferenceUserId.Location = new System.Drawing.Point(405, 179);
            this.lblReferenceUserId.Name = "lblReferenceUserId";
            this.lblReferenceUserId.Size = new System.Drawing.Size(100, 23);
            this.lblReferenceUserId.TabIndex = 330;
            this.lblReferenceUserId.Text = "ارجاع نامه به : ";
            this.lblReferenceUserId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbReferenceUserId
            // 
            this.cmbReferenceUserId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReferenceUserId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReferenceUserId.FormattingEnabled = true;
            this.cmbReferenceUserId.Location = new System.Drawing.Point(174, 179);
            this.cmbReferenceUserId.Name = "cmbReferenceUserId";
            this.cmbReferenceUserId.Size = new System.Drawing.Size(225, 22);
            this.cmbReferenceUserId.TabIndex = 329;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(583, 326);
            this.tableLayoutPanel1.TabIndex = 205;
            // 
            // lbl3
            // 
            this.lbl3.AccessibleDescription = "";
            this.lbl3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(85, 103);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(48, 27);
            this.lbl3.TabIndex = 337;
            this.lbl3.Text = "0";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "";
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(139, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(395, 27);
            this.label6.TabIndex = 336;
            this.label6.Text = "نامه هایی که به این کاربر در این مکان از درخت ارجاع شده است :‌";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl4
            // 
            this.lbl4.AccessibleDescription = "";
            this.lbl4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(85, 133);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(48, 27);
            this.lbl4.TabIndex = 339;
            this.lbl4.Text = "0";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "";
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(139, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(395, 27);
            this.label8.TabIndex = 338;
            this.label8.Text = "چک هایی که به این کاربر در این مکان از درخت ارجاع شده است :‌";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DeleteUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 326);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteUserForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم ارجاع نامه های فرد حذف شونده";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeleteUserForm_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnReffferLetter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblReferenceUserId;
        private System.Windows.Forms.ComboBox cmbReferenceUserId;
        private System.Windows.Forms.Label lblTextMessage;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label label6;
    }
}