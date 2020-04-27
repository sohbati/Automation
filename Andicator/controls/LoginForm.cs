using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorCommon;
using AndicatorBLL;

namespace Andicator.controls
{
    public partial class LoginForm : Form
    {
        public static Boolean _loggined = false;
        public static Boolean _checkJustManager = false;
        public LoginForm()
        {
            InitializeComponent();
            _loggined = false;
        }


        private string checkData()
        {
            string tmp;
            tmp = txtUserName.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
                return "لطفا نام کاربری را وارد کنید";
            tmp = txtPassword.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
                return "لطفا  کلمه عبور را وارد کنید";
            return null;
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loggined = false;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEnter_Click(null, null);
            }
        }

        private void txtEnter_Click(object sender, EventArgs e)
        {
            string check = checkData();
            if (check != null)
            {
                MessageBox.Show(check);
                return;
            }
            UsersBS isb = new UsersBS();
            UsersEntity entity = new UsersEntity();
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            entity = isb.checkUser(userName, password, _checkJustManager);
            int userCount = entity.Tables[entity.FilledTableName].Rows.Count;
            if (userCount > 0)
            {
                UsersBS.loginedUser = entity;
                UsersBS.LogginedUserProperties = new UserpropertiesBL().get(int.Parse(entity.get(UsersEntity.FIELD_ID).ToString()));
                _loggined = true;
                this.Hide();
            }
            else
            {
                MessageBox.Show("نام کاربر یا کلمه عبور معتبر نیست! چنین کاربری یافت نشد!");
            }

        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}