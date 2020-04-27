using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorBLL;
using AndicatorCommon;
using RMX_TOOLS.hasti.tools;
using RMX_TOOLS.global;

namespace Andicator.controls
{
    public partial class RefferToForm : Form
    {
        #region 
        private String _refferDate;

        public String RefferDate
        {
            get { return _refferDate; }
            set { _refferDate = value; }
        }

        private bool _isRefferDone = false;

        public bool IsRefferDone
        {
            get { return _isRefferDone; }
            set { _isRefferDone = value; }
        }

        private int _letterId = -1;

        public int LetterId
        {
            get { return _letterId; }
            set { _letterId = value; }
        }
        private int _userTreeId = -1;

        public int UserTreeId
        {
            get { return _userTreeId; }
            set { _userTreeId = value; }
        }

        private int _chequeId = -1;

        public int ChequeId
        {
            get { return _chequeId; }
            set { _chequeId = value; }
        }
        #endregion

        private UserTreeBL _userTreeBL = new UserTreeBL();
        
        public RefferToForm(bool enableReferToDate)
        {
            InitializeComponent();
            rbUsers.Checked = true;
            txtRefferDate.Enabled = enableReferToDate;
        }

        public void LoadForm()
        {
            //if(int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_USER_TYPE).ToString()).Equals(UsersBS.USER))
            //    rbRefferToMaster.Checked = true;
            LoadUsers();
            if (LetterId <= 0)
            {
                pnlDate.Visible = false;
                txtRefferDate.Visible = false;
                lblRefferDate.Visible = false;
                grpPannel.Top = grpPannel.Top - 30;
            }

            if (_refferDate != null && _refferDate.Length > 0)
                txtRefferDate.Text = _refferDate;

        }

        private void LoadUsers()
        {
            int logginedUserid = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
            UserTreeEntity entity = null;
            if (_userTreeId <= 0)
            {
                fillUserRefferenceCombo(-1);
                rbAdmins.Enabled = false;
                rbUsers.Enabled = false;
            }
            else
            {

                if (rbAdmins.Checked)
                    entity = _userTreeBL.getByUserType(UsersBS.ADMIN);
                else if (rbUsers.Checked)
                {
                    int type = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_USER_TYPE).ToString());
                    if (type == UsersBS.ADMIN)
                    {
                        entity = _userTreeBL.get();
                    }
                    else
                    {
                        UserTreeEntity entity1 = _userTreeBL.getByUser(logginedUserid);
                        UserTreeEntity entity2 = _userTreeBL.getParent(logginedUserid);

                        entity = joinEntities(entity1, entity2);
                    }
                }
                lstUserList.DataSource = null;
                lstUserList.Items.Clear();

                var dataSource = new List<ComboBoxItem>();
                //BasicInfoUtil.AddUnKnown(dataSource);
                string hash = "";
                if (entity != null && entity.Tables[entity.FilledTableName].Rows.Count > 0)
                {
                    for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
                    {
                        string name = entity.get(i, UserTreeEntity.VIEW_FIELD_USER_NAME).ToString();
                        string treeid = entity.get(i, UserTreeEntity.FIELD_ID).ToString();
                        string userid = entity.get(i, UserTreeEntity.FIELD_USER_ID).ToString();
                        
                        if (hash.IndexOf(userid + ",") <0)
                            dataSource.Add(new ComboBoxItem(name, treeid, userid));
                        hash += userid + ",";
                    }

                    lstUserList.DataSource = dataSource;
                    lstUserList.DisplayMember = "Text";
                    lstUserList.ValueMember = "Value";
                    lstUserList.SelectedIndex = 0;
                }
            }
        }

        private UserTreeEntity joinEntities(UserTreeEntity u1, UserTreeEntity u2)
        {
            if (u2 == null)
                return u1;
            if (u1 == null)
                return u2;

            for (int i = 0; i < u2.Tables[u2.FilledTableName].Rows.Count; i++)
            {
                
                DataRow dr = u1.Tables[u1.FilledTableName].NewRow();

                int userid = int.Parse(u2.get(i, UserTreeEntity.FIELD_USER_ID).ToString());
                if (!ContainsItem(userid, u1)) {
                    dr[UserTreeEntity.VIEW_FIELD_USER_NAME] = u2.get(i, UserTreeEntity.VIEW_FIELD_USER_NAME);
                    dr[UserTreeEntity.VIEW_FIELD_USER_USERTYPE] = u2.get(i, UserTreeEntity.VIEW_FIELD_USER_USERTYPE);
                    dr[UserTreeEntity.FIELD_ID] = u2.get(i, UserTreeEntity.FIELD_ID);
                    dr[UserTreeEntity.FIELD_PARENT_ID] = u2.get(i, UserTreeEntity.FIELD_PARENT_ID);
                    dr[UserTreeEntity.FIELD_RADIF] = u2.get(i, UserTreeEntity.FIELD_RADIF);
                    dr[UserTreeEntity.FIELD_USER_ID] = u2.get(i, UserTreeEntity.FIELD_USER_ID);
                    dr[UserTreeEntity.FIELD_USER_PATH] = u2.get(i, UserTreeEntity.FIELD_USER_PATH);

                    u1.Tables[u1.FilledTableName].Rows.Add(dr);
                }
            }

            return u1;
        }

        private bool ContainsItem(int userid, UserTreeEntity entity)
        {
            for (int i = 0; i < entity.RowCount(); i++)
            {
                int uid = int.Parse(entity.get(i, UserTreeEntity.FIELD_USER_ID).ToString());
                if (uid == userid)
                    return true;
            }

            return false;
        }


        private void fillUserRefferenceCombo(int defaultValue)
        {
            int loggineduserid = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
            UserTreeEntity entity = _userTreeBL.getUserAllAccessPath(loggineduserid);
            lstUserList.DataSource = null;
            lstUserList.Items.Clear();

            var dataSource = new List<ComboBoxItem>();
         //   BasicInfoUtil.AddUnKnown(dataSource);
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                string name = entity.get(i, UserTreeEntity.VIEW_FIELD_USER_NAME).ToString();
                string treeid = entity.get(i, UserTreeEntity.FIELD_ID).ToString();
                string userid = entity.get(i, UserTreeEntity.FIELD_USER_ID).ToString();
                dataSource.Add(new ComboBoxItem(name, treeid, userid));
            }

            lstUserList.DataSource = dataSource;
            lstUserList.DisplayMember = "Text";
            lstUserList.ValueMember = "Value";
            for (int i = 0; i < lstUserList.Items.Count; i++)
            {
                string c = ((ComboBoxItem)lstUserList.Items[i]).CustomData;
                if (c != null && c.Equals(defaultValue.ToString()))
                {
                    lstUserList.SelectedIndex = i;
                    break;
                }
            }

        }

        private void RefferToForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void btnReffferLetter_Click(object sender, EventArgs e)
        {
            LetterBL letterBL = new LetterBL();
            ChequeBL chequeBL = new ChequeBL();

            IsRefferDone = false;
            int assignedUserId = 0;
            if (LetterId > 0)
            {
                LetterEntity letterEntity = letterBL.getByLetterId(LetterId);
                int assignedUserTreeId = int.Parse(letterEntity.get(LetterEntity.FIELD_USER_TREE_ID).ToString());
                assignedUserId = _userTreeBL.getUserIdByTreeId(assignedUserTreeId);
                bool b = FormChecker.CheckDate(txtRefferDate, lblRefferDate);
                if (!b)
                    return;
            }
            
            if (ChequeId > 0)
            {
                ChequeEntity chequeEntity = chequeBL.get(ChequeId);
                int assignedUserTreeId = int.Parse(chequeEntity.get(ChequeEntity.FIELD_USER_TREE_ID).ToString());
                assignedUserId = _userTreeBL.getUserIdByTreeId(assignedUserTreeId);
            }
            if (lstUserList.Items.Count <= 0 || lstUserList.SelectedIndex < 0)
            {
                MessageBox.Show("لطفا کاربری را انتخاب نمایید !");
                return;
            }
            ComboBoxItem item = (ComboBoxItem)lstUserList.Items[lstUserList.SelectedIndex];
            int userTreeId = int.Parse(item.Value);

        
            int assigntoNewUserID = _userTreeBL.getUserIdByTreeId(userTreeId);
            if (assignedUserId == assigntoNewUserID)
            {
                MessageBox.Show("آیتم مورد نظر در حال حاضر در اختیار کاربر انتخاب شده می باشد. ");
                return;
            }

            DialogResult re = MessageBox.Show("آیا از انجام عمل ارجاع مطمئن هستید ؟  ", "", MessageBoxButtons.YesNo);
            if (re.Equals(DialogResult.No))
                return;


            if (_letterId >= 0)
            {
                letterBL.updateRefferenceUser(_letterId, userTreeId);

                letterBL.updateRefferenceDate(RMX_TOOLS.date.DateXFormer.persianToGreGorian(txtRefferDate.Text), LetterId);
                    
                lblMsg.Text = "ارجاع انجام گردید!";
            }
            else if (_chequeId >= 0)
            {
                chequeBL.updateRefferenceUser(_chequeId, userTreeId);
                lblMsg.Text = "ارجاع انجام گردید!";
            }
            IsRefferDone = true;

            // this.Close();
            

        }

        

        private void radioButtons_changed(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
