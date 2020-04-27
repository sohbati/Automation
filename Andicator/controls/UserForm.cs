using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMX_TOOLS.data.grid;
using AndicatorBLL;
using AndicatorCommon;
using RMX_TOOLS.hasti.tools;
using Andicator.lists;

namespace Andicator.controls
{
    public partial class UserForm : Form
    {
        private const string NEW_MODE = "new";
        private const string EDIT_MODE = "edit";
        private const string DELETE_MODE = "delete";

        private string dataMode = EDIT_MODE;
        private GridTools _gridTools;

        private UsersBS _usersBs;
        public UserForm()
        {
            InitializeComponent();
            _usersBs = new UsersBS();

            _gridTools = new GridTools();
            fillCombo();
        }

        private void fillCombo()
        {
            UsersEntity entity = _usersBs.getMasterUsers();
            //کاربران اصلی را در کاکبو لیست می کند
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                string name = entity.get(i, UsersEntity.FIELD_NAME).ToString() + " "  +
                    entity.get(i, UsersEntity.FIELD_FAMILY).ToString() + "(" + entity.get(i, UsersEntity.FIELD_USERNAME).ToString() + ")";

                int masterUserId = int.Parse(entity.get(i, UsersEntity.FIELD_ID).ToString());
                ComboBoxItem item = new ComboBoxItem();
                item.Text = name;
                item.Value = masterUserId.ToString();
            }
            //الگو ها را لیست می کند
            LetterNumberPatternBL letPatt = new LetterNumberPatternBL();
            LetterNumberPatternEntity pEntity = letPatt.get();

            for (int i = 0; i < pEntity.Tables[pEntity.FilledTableName].Rows.Count; i++)
            {
                string name = pEntity.get(i, LetterNumberPatternEntity.FIELD_PATTERN_NAME).ToString();
                string id = pEntity.get(i, LetterNumberPatternEntity.FIELD_ID).ToString();
                ComboBoxItem item = new ComboBoxItem();
                item.Text = name;
                item.Value = id;
                cmbLetterPattern.Items.Add(item);

            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtName.Focus();
            dataMode = NEW_MODE;
            emptyForm();
            newModeRestricts();
        }

        private void newModeRestricts()
        {
            dataGridView1.Enabled = false;
            btnDelete.Enabled = false;
            toolStripStatusLabel1.Text = "جدید";
        }

        private void emptyForm()
        {
            txtName.Text = "";
            txtFamily.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            cmbUserType.SelectedIndex = -1;
        }

        private string checkData()
        {
            txtName.Text = txtName.Text.Trim();
            txtFamily.Text = txtFamily.Text.Trim();
            txtUserName.Text = txtUserName.Text.Trim();
            txtPassword.Text = txtPassword.Text.Trim();

            string tmp;
            tmp = txtName.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
                return "لطفا نام را وارد کنید";
            tmp = txtFamily.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
                return "لطفا نام خانوادگی را وارد کنید";
            tmp = txtUserName.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
                return "لطفا نام کاربری را وارد کنید";
            tmp = txtPassword.Text;
            if (tmp == null || tmp.Trim().Length <= 0)
                return "لطفا  کلمه عبور را وارد کنید";
            if (cmbUserType.SelectedIndex == -1)
                return "لطفا  نوع کاربر را وارد کنید";
            return null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string check = checkData();
            if (check != null)
            {
                MessageBox.Show(check);
                return;
            }
            if (dataGridView1.RowCount <= 0)
                dataMode = NEW_MODE;

            UsersEntity entity = new UsersEntity();

            DataRow dr = null;
            dr = entity.Tables[entity.TableName].NewRow();
            entity.FilledTableName = entity.TableName; 
               

            dr[UsersEntity.FIELD_NAME] = txtName.Text;
            dr[UsersEntity.FIELD_FAMILY] = txtFamily.Text;
            dr[UsersEntity.FIELD_USERNAME] = txtUserName.Text;
            dr[UsersEntity.FIELD_PASSWORD] = txtPassword.Text;
            dr[UsersEntity.FIELD_USER_TYPE] = (cmbUserType.SelectedIndex + 1);
            dr[UsersEntity.FIELD_ACTIVE] = (cbActive.Checked ? 1 : 0);
            if (cmbLetterPattern.SelectedIndex >= 0)
            {
                ComboBoxItem item = (ComboBoxItem)cmbLetterPattern.Items[cmbLetterPattern.SelectedIndex];
                dr[UsersEntity.FIELD_LETTER_PATTERN_ID] = item.Value;
            }

            if (!dataMode.Equals(NEW_MODE))
                dr[entity.IndexFieldName] = _gridTools.getCurrentRowValue(dataGridView1, entity.IndexFieldName);

            object id = _gridTools.getCurrentRowValue(dataGridView1, entity.IndexFieldName);
            entity.Tables[entity.TableName].Rows.Add(dr);

            int count;
            if (dataMode.Equals(NEW_MODE))
            {
                UsersEntity en = _usersBs.get(UsersEntity.FIELD_USERNAME + "='" + txtUserName.Text + "'");
                if (en.Tables[en.FilledTableName].Rows.Count > 0)
                {
                    MessageBox.Show("نام کاربری تعیین شده قبلا تعریف شده است، لطفا نام دیگری را انتخاب نمایید");
                    return;
                }
                count = _usersBs.add(entity);
            }
            else if (dataMode.Equals(EDIT_MODE))
                count = _usersBs.update(entity);

            dataMode = EDIT_MODE;
            btnRefresh_Click(null, null);
            fillGrid();
        }

        private int getLetters(int userId)
        {
            LetterBL letter = new LetterBL();
            LetterEntity e = letter.getRefferedToUser(userId, false);
            int i = e.Tables[e.FilledTableName].Rows.Count;
            return i;
        }

        private int getCheques(int userId)
        {
            ChequeBL bl = new ChequeBL();
            ChequeEntity e = bl.getRefferedToUser(userId);
            int i = e.Tables[e.FilledTableName].Rows.Count;
            return i;
        }

        private int getLetterRefferences(int userid)
        {
            ReferLetterBL bl = new ReferLetterBL();
            ReferLetterEntity entity = bl.getByUserId(userid);
            return entity.Tables[entity.FilledTableName].Rows.Count;
        }

        private int getChequeRefferences(int userid)
        {
            ReferChequeBL bl = new ReferChequeBL();
            ReferChequeEntity entity = bl.getByUserId(userid);
            return entity.Tables[entity.FilledTableName].Rows.Count;
        }

        private void removeUserRefs(int userid)
        {
            ReferChequeBL cbl = new ReferChequeBL();
            ReferLetterBL rbl = new ReferLetterBL();

            cbl.removeUserRefer(userid);
            rbl.removeUserRefer(userid);


        }

        private int getUserInTree(int id)
        {
            UserTreeBL bl = new UserTreeBL();
            UserTreeEntity en = bl.getUserAllAccessPath(id);
            return en.Tables[en.FilledTableName].Rows.Count;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            int cheques = 0;
            int letters = 0;
            int letterRefrences = 0;
            int chequeRefrences = 0;
            int userInTree = 0;
            string val = _gridTools.getCurrentRowValue(dataGridView1, new UsersEntity().IndexFieldName) + "";
            if (val == null || val.Trim().Length <= 0)
                return;
            DialogResult dr = MessageBox.Show("آیا مایلید حذف کنید ؟", "", MessageBoxButtons.YesNo);
            if (dr.Equals(DialogResult.Yes))
            {
                int id = int.Parse(val);
                letters = getLetters(id);
                cheques = getCheques(id);
                if (letters > 0 || cheques > 0)
                {
                    MessageBox.Show("به تعداد " + letters + " نامه و به تعداد  "  + cheques + " چک در اختیار این کاربر می باشد " + "/n"
                       + " امکان حذف این کاربر نیست");
                    return;
                }
                // remove references
                letterRefrences = getLetterRefferences(id);
                chequeRefrences = getChequeRefferences(id);
                userInTree = getUserInTree(id);
                if (userInTree > 0)
                {
                    MessageBox.Show("این کاربر در درخت کاربران استفاده شده است لطفا ابتدا این کاربر را از درخت حذف نمایید");
                    return;
                }

                if (letterRefrences > 0 || chequeRefrences > 0)
                {
                    DialogResult dr2 = MessageBox.Show("ارجاعاتی از نامه و چک برای این کاربر ثبت شده است !" + "/n" + 
                        "آیا مایلید این ارجاعات حذف گردند", "", MessageBoxButtons.YesNo);
                    if (dr.Equals(DialogResult.Yes))
                    {
                        removeUserRefs(id);
                    }
                    else
                        return;
                }
                _usersBs.delete(id);
                emptyForm();

            }
            fillGrid();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            UsersEntity entity = UsersBS.loginedUser;
            int userype = int.Parse(entity.Tables[entity.FilledTableName].Rows[0][UsersEntity.FIELD_USER_TYPE] + "");
            if (userype != UsersBS.ADMIN)
            {
                MessageBox.Show("فقط مدیر سیستم می تواند این فرم را مشاهده کند");
                this.Close();
            }
            fillGrid();
            // LANGAUGE CHANGEING TO PERSIAN
            InputLanguage persinLanguage = InputLanguage.CurrentInputLanguage;
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
                if (InputLanguage.InstalledInputLanguages[i].LayoutName.Equals("Farsi"))
                    persinLanguage = InputLanguage.InstalledInputLanguages[i];
            InputLanguage.CurrentInputLanguage = persinLanguage;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            btnDelete.Enabled = true;
            toolStripStatusLabel1.Text = "";
            dataMode = EDIT_MODE;
        }

        private void UserForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Delete)
            {
                if (!dataMode.Equals(NEW_MODE))
                    btnDelete_Click(null, null);
            }
            if (e.KeyCode == Keys.Insert)
                btnNew_Click(null, null);
            if (e.KeyCode == Keys.F10)
                btnUpdate_Click(null, null);
            if (e.KeyCode == Keys.F9)
                btnRefresh_Click(null, null);
        }

        private void fillGrid()
        {
            string cond = "";
            if (rbActiveUsers.Checked)
                cond += "ACTIVE=1";
            else
                cond += "(ACTIVE=0 OR ACTIVE is null)";
            UsersEntity entity = _usersBs.load(cond);
            dataGridView1.DataSource = entity;
            dataGridView1.DataMember = entity.FilledTableName;
            setControls();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            UserForm_KeyDown(sender, e);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            setControls();
        }

        private void setControls()
        {
            _gridTools.setValue(dataGridView1, txtName, UsersEntity.FIELD_NAME);
            _gridTools.setValue(dataGridView1, txtFamily, UsersEntity.FIELD_FAMILY);
            _gridTools.setValue(dataGridView1, txtUserName, UsersEntity.FIELD_USERNAME);
            _gridTools.setValue(dataGridView1, txtPassword, UsersEntity.FIELD_PASSWORD);
            _gridTools.setValue(dataGridView1, cmbUserType, UsersEntity.FIELD_USER_TYPE);
            _gridTools.setComboBoxItemValue(dataGridView1, cmbLetterPattern, UsersEntity.FIELD_LETTER_PATTERN_ID);
            
            if (_gridTools.getCurrentRowValue(dataGridView1, UsersEntity.FIELD_ACTIVE) != null)
                cbActive.Checked =   _gridTools.getCurrentRowValue(dataGridView1, UsersEntity.FIELD_ACTIVE).ToString().Equals("1");
            if (UsersBS.ADMIN.ToString().Equals(cmbUserType.SelectedIndex + 1 + ""))
            {
                btnLetterFormPerm.Visible = false;
                btnMenuPersmission.Visible = false;
                btnChequeFieldsPerm.Visible = false;
            }
            else
            {
                btnLetterFormPerm.Visible = true;
                btnMenuPersmission.Visible = true;
                btnChequeFieldsPerm.Visible = true;
            }

        }

        public void setValue(DataGridView grid, CheckBox cb, string fieldName)
        {
            object obj = _gridTools.getCurrentRowValue(grid, fieldName);

            if (obj != null && obj.ToString() != "")
            {
                cb.Checked = (Boolean)obj;
            }
            else
                cb.Checked = false;
        }


        private void btnSetLetterItemsPerm_Click(object sender, EventArgs e)
        {
            string val = _gridTools.getCurrentRowValue(dataGridView1, new UsersEntity().IndexFieldName) + "";
            if (val == null || val.Trim().Length <= 0)
                return;
            int id = int.Parse(val);

            LetterItemsPermForm form = new LetterItemsPermForm(id);
            form.load();
            form.ShowDialog();
        }

        private void btnMenuPersmission_Click(object sender, EventArgs e)
        {
            string val = _gridTools.getCurrentRowValue(dataGridView1, new UsersEntity().IndexFieldName) + "";
            if (val == null || val.Trim().Length <= 0)
                return;
            int id = int.Parse(val);
            MenuPersmissionForm form = new MenuPersmissionForm(id);
            form.ShowDialog();
        }

        private void btnDisableUser_Click(object sender, EventArgs e)
        {
            string val = _gridTools.getCurrentRowValue(dataGridView1, new UsersEntity().IndexFieldName) + "";
            if (val == null || val.Trim().Length <= 0)
                return;
            int id = int.Parse(val);
        }

        private void btnShowUserList_Click(object sender, EventArgs e)
        {
            string val = _gridTools.getCurrentRowValue(dataGridView1, new UsersEntity().IndexFieldName) + "";
            if (val == null || val.Trim().Length <= 0)
                return;
            int id = int.Parse(val);

            UserList list = new UserList();
            list.UnselectIds = id + "";
            list.initList();
            list.ShowDialog();
        }

        private void radioButtonActiveUseschangedactive(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void ChequeFieldsPerm_Click(object sender, EventArgs e)
        {
            string val = _gridTools.getCurrentRowValue(dataGridView1, new UsersEntity().IndexFieldName) + "";
            if (val == null || val.Trim().Length <= 0)
                return;
            int id = int.Parse(val);

            ChequeFormPerm form = new ChequeFormPerm(id);
            form.load();
            form.ShowDialog();
        }

    }
}
