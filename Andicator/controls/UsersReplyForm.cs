using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorCommon;
using AndicatorBLL;
using RMX_TOOLS.global;

namespace Andicator.controls
{
    public partial class UsersReplyForm : Form
    {
        #region
        private int _letterId = -1;
        private int _userId = -1;
        private string _mode = Constants.ADD_MODE;
        private int _id = -1;
        private UsersRelpyBL _usersReplyBL = null;
        
        #endregion
        public UsersReplyForm(int userId, int letterId)
        {
            _letterId = letterId;
            _userId = userId;

            InitializeComponent();

            _usersReplyBL = new UsersRelpyBL();

            txtRegisterDate.Text = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.Now);
        }
        
        public UsersReplyForm(int id)
        {
            _id = id;
            InitializeComponent();

            _usersReplyBL = new UsersRelpyBL();
            _mode = Constants.EDIT_MODE;
            
            UsersReplyEntity entity = _usersReplyBL.getById(_id);
            
            _userId =  int.Parse(entity.get(UsersReplyEntity.FIELD_USERID).ToString());
            _letterId = int.Parse(entity.get(UsersReplyEntity.FIELD_LETTERID).ToString());
            txtRegisterDate.Text = RMX_TOOLS.date.DateXFormer.gregorianToPersianString((DateTime)
                    entity.get(UsersReplyEntity.FIELD_RESPONSEDATE));
            txtDescription.Text = entity.get(UsersReplyEntity.FIELD_DESCRIPTION).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UsersReplyEntity entity = new UsersReplyEntity();
            DataRow dr = entity.Tables[entity.TableName].NewRow();

            dr[UsersReplyEntity.FIELD_ID] = _id;
            dr[UsersReplyEntity.FIELD_USERID] = _userId;
            dr[UsersReplyEntity.FIELD_LETTERID] = _letterId;
            dr[UsersReplyEntity.FIELD_RESPONSEDATE] = DateTime.Now;
            dr[UsersReplyEntity.FIELD_DESCRIPTION] = txtDescription.Text;

            entity.Tables[entity.TableName].Rows.Add(dr);

            if (_mode.Equals(Constants.ADD_MODE))
            {
                _id = _usersReplyBL.add(entity);
                lblMsg.Text = "دخیره گردید";
                _mode = Constants.EDIT_MODE;
                this.Close();
            }
            else
            {
                _usersReplyBL.update(entity);
                lblMsg.Text = "تغییرات به روز رسانی گردید";
            }
            
        }

        private void UsersReplyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }
    }
}
