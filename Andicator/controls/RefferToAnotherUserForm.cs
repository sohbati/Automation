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
    public partial class RefferToAnotherUserForm : Form
    {
        #region privates 
        private LetterBL _letterBl;
        private UserTreeBL _userTreeBL;
        ChequeBL _chequeBL = new ChequeBL();

        private string _userTreeIds = "";
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

        public RefferToAnotherUserForm()
        {
            _letterBl = new LetterBL();
            _userTreeBL = new UserTreeBL();
            InitializeComponent();
        }

        public void loadForm()
        {
            lblTextMessage.Text = "";
          

            _userTreeIds = getSameUserIdsLikeThisNode(_userTreeId);

            LetterEntity letterentity1 = _letterBl.getByUserTreeIds(_userTreeIds);
            ChequeEntity chequeEntity2 = _chequeBL.getByUserTreeIds(_userTreeIds);

            LetterEntity letterentity3 = _letterBl.getByUserTreeId(_userTreeId);
            ChequeEntity chequeEntity4 = _chequeBL.getByUserTreeId(_userTreeId);

            if (letterentity1.Tables[letterentity1.FilledTableName].Rows.Count <= 0 &&
                chequeEntity2.Tables[chequeEntity2.FilledTableName].Rows.Count <=0)
            {
                cmbReferenceUserId.Enabled = false;
                btnReffferLetter.Enabled = false;
                 
                lblTextMessage.Text = "این کاربر نامه ای   یا چکی در اختیار ندارد";
            }
            else
            {
                 
                cmbReferenceUserId.Enabled = true;
                btnReffferLetter.Enabled = true;
                lblTextMessage.Text = "ارجاعات";
                lbl1.Text = letterentity1.RowCount().ToString();
                lbl2.Text = chequeEntity2.RowCount().ToString();
                lbl3.Text = letterentity3.RowCount().ToString();
                lbl4.Text = chequeEntity4.RowCount().ToString();

                fillUserRefferenceCombo(-1);
            }
        }

        //return treeids for user of this tree -- users that is owner of nodes
        private string getSameUserIdsLikeThisNode(int treeid)
        {
            string treeids = "";
            UserTreeEntity uEntity = _userTreeBL.get(treeid);
            int userid = int.Parse(uEntity.get(UserTreeEntity.FIELD_USER_ID).ToString());
            uEntity = _userTreeBL.getByUserTableId(userid);
            for (int i = 0; i < uEntity.Tables[uEntity.FilledTableName].Rows.Count; i++)
            {
                treeids += uEntity.get(i, UserTreeEntity.FIELD_ID) +  ",";
            }

            return treeids.Substring(0, treeids.Length - 1);
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

        private void btnReffferLetter_Click(object sender, EventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)cmbReferenceUserId.Items[cmbReferenceUserId.SelectedIndex];
            if (item.Value == null || item.Value.Equals("") || int.Parse(item.Value) <= 0)
                return;
            DialogResult dres = MessageBox.Show("آیا از ارجاع نامه ها به کاربری دیگر مطمئن هستید؟", "", MessageBoxButtons.YesNo);
            if (dres.Equals(DialogResult.Yes))
            {
                int treeid = int.Parse(item.Value);
                 int i = _letterBl.changeUserTreeOwnedLetters(_userTreeIds, treeid);
                 int j = _chequeBL.changeUserTreeOwnedCheques(_userTreeIds, treeid);
                MessageBox.Show("نامه ها از کاربر مورد نظر به کاربر دیگر ارجاع داده شد");
               // btnDeleteUser.Enabled = true;
               // cmbReferenceUserId.Enabled = false;
               // btnReffferLetter.Enabled = false;
                loadForm();
            }
        }

        private void RefferToAnotherUserForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

    }
}
