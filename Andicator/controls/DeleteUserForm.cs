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

namespace Andicator.controls
{
    public partial class DeleteUserForm : Form
    {
        #region privates 
        private LetterBL _letterBl;
        private UserTreeBL _userTreeBL;
        ChequeBL _chequeBL = new ChequeBL();
        #endregion

        #region properties
        private bool _isUserTreeNodeDeleted = false;

        public bool IsUserTreeNodeDeleted
        {
            get { return _isUserTreeNodeDeleted; }
            set { _isUserTreeNodeDeleted = value; }
        }
        private int _userTreeId;

        public int UserTreeId
        {
            get { return _userTreeId; }
            set { _userTreeId = value; }
        }

        #endregion

        public DeleteUserForm()
        {
            _letterBl = new LetterBL();
            _userTreeBL = new UserTreeBL();
            InitializeComponent();
        }

        public void loadForm()
        {
            lblTextMessage.Text = "";
           

            ChequeEntity chequeEntity = _chequeBL.getByUserTreeId(_userTreeId); 
            LetterEntity letterentity = _letterBl.getByUserTreeId(_userTreeId);

            if (letterentity.Tables[letterentity.FilledTableName].Rows.Count <= 0 &&
                chequeEntity.Tables[chequeEntity.FilledTableName].Rows.Count <=0)
            {
                cmbReferenceUserId.Enabled = false;
                btnReffferLetter.Enabled = false;
                btnDeleteUser.Enabled = true;
                lbl3.Text = "0";
                lbl4.Text = "0";
                lblTextMessage.Text = "این کاربر نامه ای   و چکی در اختیار ندارد ، می توان این کاربر را حدف نمود";
            }
            else
            {
                btnDeleteUser.Enabled = false;
                cmbReferenceUserId.Enabled = true;
                btnReffferLetter.Enabled = true;
                lblTextMessage.Text = "ارجاعات";
                lbl3.Text = letterentity.RowCount().ToString();
                lbl4.Text = chequeEntity.RowCount().ToString();

                fillUserRefferenceCombo(-1);
            }
        }

        private void fillUserRefferenceCombo(int defaultValue)
        {
            UserTreeBL userTreeBL = new UserTreeBL();
            int loggineduserid = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
            UserTreeEntity entity = userTreeBL.get();
            cmbReferenceUserId.DataSource = null;
            cmbReferenceUserId.Items.Clear();

            var dataSource = new List<ComboBoxItem>();
            //BasicInfoUtil.AddUnKnown(dataSource);
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                string name = entity.get(i, UserTreeEntity.VIEW_FIELD_USER_NAME).ToString();
                string treeid = entity.get(i, UserTreeEntity.FIELD_ID).ToString();
                string userid = entity.get(i, UserTreeEntity.FIELD_USER_ID).ToString();
                dataSource.Add(new ComboBoxItem(name, treeid, userid));
            }

            cmbReferenceUserId.DataSource = dataSource;
            cmbReferenceUserId.DisplayMember = "Text";
            cmbReferenceUserId.ValueMember = "Value";
            for (int i = 0; i < cmbReferenceUserId.Items.Count; i++)
            {
                string c = ((ComboBoxItem)cmbReferenceUserId.Items[i]).CustomData;
                if (c != null && c.Equals(defaultValue.ToString()))
                {
                    cmbReferenceUserId.SelectedIndex = i;
                    break;
                }
            }

        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DialogResult dres = MessageBox.Show("آیا مایلید حذف کنید ؟", "", MessageBoxButtons.YesNo);
            if (dres.Equals(DialogResult.Yes))
            {
                _userTreeBL.delete(_userTreeId);
                MessageBox.Show("کاربر مورد نظر از درخت حذف گردید");
                _isUserTreeNodeDeleted = true;
                this.Close();
            }
        }

        private void btnReffferLetter_Click(object sender, EventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)cmbReferenceUserId.Items[cmbReferenceUserId.SelectedIndex];
            if (item.Value == null || item.Value.Equals("") || int.Parse(item.Value) <= 0)
                return;
            DialogResult dres = MessageBox.Show("آیا از ارجاع نامه ها به کاربری دیگر مطمئن هستید؟", "", MessageBoxButtons.YesNo);
            if (dres.Equals(DialogResult.Yes))
            {
                int treeid = int.Parse(item.Value);
                int i = _letterBl.changeUserTreeOwnedLetters(_userTreeId, treeid);
                int j = _chequeBL.changeUserTreeOwnedCheques(_userTreeId, treeid);
                MessageBox.Show("نامه ها از کاربر مورد نظر به کاربر دیگر ارجاع داده شد");
               // btnDeleteUser.Enabled = true;
               // cmbReferenceUserId.Enabled = false;
               // btnReffferLetter.Enabled = false;
                loadForm();
            }
        }

        private void DeleteUserForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
