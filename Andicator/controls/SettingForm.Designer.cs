namespace Andicator.controls
{
    partial class SettingForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbcheckBoxList = new System.Windows.Forms.GroupBox();
            this.cbxShowConfirmDialog = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.lblDataBaseName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.schaduleingTab = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbScheduleForRefresh = new System.Windows.Forms.ComboBox();
            this.schedule = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExit2 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbcheckBoxList.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.schaduleingTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(410, 227);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbcheckBoxList);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(402, 201);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "تنظیمات عمومی";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbcheckBoxList
            // 
            this.gbcheckBoxList.BackColor = System.Drawing.Color.Transparent;
            this.gbcheckBoxList.Controls.Add(this.cbxShowConfirmDialog);
            this.gbcheckBoxList.Location = new System.Drawing.Point(360, 6);
            this.gbcheckBoxList.Name = "gbcheckBoxList";
            this.gbcheckBoxList.Size = new System.Drawing.Size(34, 179);
            this.gbcheckBoxList.TabIndex = 4;
            this.gbcheckBoxList.TabStop = false;
            // 
            // cbxShowConfirmDialog
            // 
            this.cbxShowConfirmDialog.AutoSize = true;
            this.cbxShowConfirmDialog.Location = new System.Drawing.Point(6, 13);
            this.cbxShowConfirmDialog.Name = "cbxShowConfirmDialog";
            this.cbxShowConfirmDialog.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbxShowConfirmDialog.Size = new System.Drawing.Size(15, 14);
            this.cbxShowConfirmDialog.TabIndex = 0;
            this.cbxShowConfirmDialog.UseVisualStyleBackColor = true;
            this.cbxShowConfirmDialog.CheckedChanged += new System.EventHandler(this.cbxShowConfirmDialog_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(56, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "گرفتن تایید هنگام ثبت به عنوان انجام شده ، در فرم اصلی برنامه";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(402, 201);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تنظیمات بانک اطلاعاتی";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(118, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 43);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(142, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExit.Size = new System.Drawing.Size(52, 26);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(74, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(62, 26);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDatabaseName);
            this.panel1.Controls.Add(this.lblDataBaseName);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.txtServerName);
            this.panel1.Controls.Add(this.lblServerName);
            this.panel1.Location = new System.Drawing.Point(115, 16);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(259, 121);
            this.panel1.TabIndex = 7;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(3, 86);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDatabaseName.Size = new System.Drawing.Size(165, 21);
            this.txtDatabaseName.TabIndex = 3;
            // 
            // lblDataBaseName
            // 
            this.lblDataBaseName.AutoSize = true;
            this.lblDataBaseName.Location = new System.Drawing.Point(174, 89);
            this.lblDataBaseName.Name = "lblDataBaseName";
            this.lblDataBaseName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDataBaseName.Size = new System.Drawing.Size(50, 13);
            this.lblDataBaseName.TabIndex = 6;
            this.lblDataBaseName.Text = "نام بانک :";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(3, 60);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPassword.Size = new System.Drawing.Size(165, 21);
            this.txtPassword.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(168, 63);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPassword.Size = new System.Drawing.Size(59, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "کلمه عبور :";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(3, 34);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserName.Size = new System.Drawing.Size(165, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(174, 37);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "نام کاربری :";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(3, 8);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtServerName.Size = new System.Drawing.Size(165, 21);
            this.txtServerName.TabIndex = 0;
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(174, 11);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblServerName.Size = new System.Drawing.Size(55, 13);
            this.lblServerName.TabIndex = 0;
            this.lblServerName.Text = "نام سرور :";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.schaduleingTab);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(402, 201);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "زمانبندی";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // schaduleingTab
            // 
            this.schaduleingTab.BackColor = System.Drawing.Color.Transparent;
            this.schaduleingTab.Controls.Add(this.label2);
            this.schaduleingTab.Controls.Add(this.cmbScheduleForRefresh);
            this.schaduleingTab.Controls.Add(this.schedule);
            this.schaduleingTab.Location = new System.Drawing.Point(11, 13);
            this.schaduleingTab.Name = "schaduleingTab";
            this.schaduleingTab.Size = new System.Drawing.Size(383, 112);
            this.schaduleingTab.TabIndex = 10;
            this.schaduleingTab.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 38);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "دقیقه";
            // 
            // cmbScheduleForRefresh
            // 
            this.cmbScheduleForRefresh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScheduleForRefresh.FormattingEnabled = true;
            this.cmbScheduleForRefresh.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60"});
            this.cmbScheduleForRefresh.Location = new System.Drawing.Point(115, 35);
            this.cmbScheduleForRefresh.Name = "cmbScheduleForRefresh";
            this.cmbScheduleForRefresh.Size = new System.Drawing.Size(118, 21);
            this.cmbScheduleForRefresh.TabIndex = 2;
            // 
            // schedule
            // 
            this.schedule.AutoSize = true;
            this.schedule.Location = new System.Drawing.Point(230, 38);
            this.schedule.Name = "schedule";
            this.schedule.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.schedule.Size = new System.Drawing.Size(153, 13);
            this.schedule.TabIndex = 1;
            this.schedule.Text = "زمان به روز رسانی لیست آلارم :";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.btnExit2);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(11, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 43);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // btnExit2
            // 
            this.btnExit2.Location = new System.Drawing.Point(220, 11);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExit2.Size = new System.Drawing.Size(52, 26);
            this.btnExit2.TabIndex = 4;
            this.btnExit2.Text = "خروج";
            this.btnExit2.UseVisualStyleBackColor = true;
            this.btnExit2.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(152, 11);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button2.Size = new System.Drawing.Size(62, 26);
            this.button2.TabIndex = 5;
            this.button2.Text = "ذخیره";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 227);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات ";
            this.Load += new System.EventHandler(this.settingForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.settingForm_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gbcheckBoxList.ResumeLayout(false);
            this.gbcheckBoxList.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.schaduleingTab.ResumeLayout(false);
            this.schaduleingTab.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox gbcheckBoxList;
        public System.Windows.Forms.CheckBox cbxShowConfirmDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.Label lblDataBaseName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.GroupBox schaduleingTab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbScheduleForRefresh;
        private System.Windows.Forms.Label schedule;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExit2;
        private System.Windows.Forms.Button button2;
    }

}