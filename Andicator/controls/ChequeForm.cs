using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorBLL;
using RMX_TOOLS.hasti.tools;
using AndicatorCommon;
using RMX_TOOLS.global;
using RMX_TOOLS.converter;
using RMX_TOOLS.data.grid;
using System.Collections;
using Andicator.controls.tools;
using RMX_TOOLS.hasti.bll;
using Andicator.lists;

namespace Andicator.controls
{
    public partial class ChequeForm : Form
    {
        #region properties
        private bool DataChanged = false;

        public bool DataChanged1
        {
            get { return DataChanged; }
            set { DataChanged = value; }
        }
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public bool readOnly { get; set; }

        #endregion

        #region privates
        private ChequeBL _chequeBL;

        private int _userTreeId = -1;
        #endregion

        public ChequeForm(int id)
        {
            _id = id;
            _chequeBL = new ChequeBL();
            _chequeReplyBL = new ChequeReplyBL();
            InitializeComponent();
        }

        public void initForm()
        {
            cmbPayType.Items.Clear();
            ComboBoxItem item = new ComboBoxItem("چک", "0");
            cmbPayType.Items.Add(item);
            item = new ComboBoxItem("نقد", "1");
            cmbPayType.Items.Add(item);

            int bankid = 0;
            int companyId = 0;
            DateConverter converter = new DateConverter();

            if (_id > 0)
            {
                ChequeEntity entity = _chequeBL.get(_id);

                if (entity.get(ChequeEntity.FIELD_PAY_TYPE).ToString().Length > 0)
                {
                    if (((bool)entity.get(ChequeEntity.FIELD_PAY_TYPE)) == true)
                        cmbPayType.SelectedIndex = 1;
                    else
                        cmbPayType.SelectedIndex = 0;
                }
                else
                {
                    cmbPayType.SelectedIndex = -1;
                    lblCbArchive.Visible = false;
                    cbArchive.Visible = false;
                }
                if (entity.get(ChequeEntity.FIELD_USER_TREE_ID).ToString().Length > 0)
                    _userTreeId = int.Parse(entity.get(ChequeEntity.FIELD_USER_TREE_ID).ToString());

                txtChequeNumber.Text = entity.get(ChequeEntity.FIELD_CHEQUE_NUMBER).ToString();
                txtMaturityDate.Text = converter.valueToString(entity.get(ChequeEntity.FIELD_MATURITY_DATE));
                txtEntryDate.Text = converter.valueToString(entity.get(ChequeEntity.FIELD_ENTRY_DATE));
                txtRefferDate.Text = converter.valueToString(entity.get(ChequeEntity.FIELD_REFFER_DATE));
                txtPrice.Text = entity.get(ChequeEntity.FIELD_PRICE).ToString();
                txtAccountNumber.Text = entity.get(ChequeEntity.FIELD_ACCOUNT_NUMBER).ToString();
                txtInsuranceNumber.Text = entity.get(ChequeEntity.FIELD_INSURANCE_NUMBER).ToString();
                txtAccountHolderName.Text = entity.get(ChequeEntity.FIELD_ACCOUNT_HOLDER_NAME).ToString();
                //txtDescription.Text = entity.get(ChequeEntity.FIELD_DESCRIPTION).ToString();
                txtRegistrantUser.Text = UsersBS.loginedUser.ToString();
                if (entity.get(ChequeEntity.FIELD_BANK_ID).ToString().Length > 0)
                    bankid = int.Parse(entity.get(ChequeEntity.FIELD_BANK_ID).ToString());

                txtCompany.Tag = 0;
                if (entity.get(ChequeEntity.FIELD_COMPANY_ID).ToString().Length > 0)
                {
                    txtCompany.Tag = (int)entity.get(ChequeEntity.FIELD_COMPANY_ID);
                    txtCompany.Text = CompanyBL.getCompanyName((int)txtCompany.Tag);
                }

                cbArchive.Checked = (Boolean)("".Equals(entity.get(ChequeEntity.FIELD_ARCHIVE).ToString()) ? false : entity.get(ChequeEntity.FIELD_ARCHIVE));

                if (entity.get(ChequeEntity.FIELD_INSURANCE_COMPANY).ToString().Length > 0)
                    companyId = int.Parse(entity.get(ChequeEntity.FIELD_INSURANCE_COMPANY).ToString());
                
                UsersBS usersBs = new UsersBS();
                string s = "";
                int id = -1;
                if (entity.get(ChequeEntity.FIELD_REGISTRANT_USER).ToString().Length > 0)
                {

                    UsersEntity ue = usersBs.get(int.Parse(entity.get(ChequeEntity.FIELD_REGISTRANT_USER).ToString()));
                    if (ue.Tables[ue.FilledTableName].Rows.Count <= 0)
                    {
                        s = UsersBS.loginedUser.ToString();
                        id = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
                    }
                    else
                    {
                        s = ue.ToString();
                        id = int.Parse(ue.get(UsersEntity.FIELD_ID).ToString());
                    }
                }
                else
                {
                    s = UsersBS.loginedUser.ToString();
                    id = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
                }
                txtRegistrantUser.Text = s;
                txtRegistrantUser.Tag = id;

                if (entity.get(ChequeEntity.FIELD_REGISTER_DATE) != null &&
                    entity.get(ChequeEntity.FIELD_REGISTER_DATE).ToString().Length > 0)
                {
                    txtRegisterDate.Text = converter.valueToString(entity.get(ChequeEntity.FIELD_REGISTER_DATE));
                }
                else
                {
                    txtRegisterDate.Text = converter.valueToString(DateTime.Now);
                }

                cmbReferenceUserId.Visible = false;
                lblReferenceUserId.Visible = false;

            }
            else
            {
                //lblChqueReply.Visible = false;
                tblReply.Visible = false;
                txtRegistrantUser.Tag = UsersBS.loginedUser.get(UsersEntity.FIELD_ID);
                txtRegistrantUser.Text = UsersBS.loginedUser.ToString();

                txtRegisterDate.Text = converter.valueToString(DateTime.Now);
                
                cmbReferenceUserId.Visible = true;
                lblReferenceUserId.Visible = true;
                fillUserRefferenceCombo(-1);
                txtCompany.Tag = 0;

            }

            BasicInfoUtil.fillComboBox(cmbInsuranceCompany, "InsuranceCompany", companyId);
            BasicInfoUtil.fillComboBox(cmbBankId, "Bank", bankid);
            initList();

            if (readOnly == true)
            {
                btnSave.Enabled = false;
                btnReferToMasterUser.Enabled = false;
            }

            setPermision();
            if (_id < 0)
                linkAttachment.Visible = false;
            
        }

        private void fillUserRefferenceCombo(int defaultValue)
        {
            UserTreeBL userTreeBL = new UserTreeBL();
            int loggineduserid = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
            UserTreeEntity entity = userTreeBL.getUserAllAccessPath(loggineduserid);
            cmbReferenceUserId.DataSource = null;
            cmbReferenceUserId.Items.Clear();

            var dataSource = new List<ComboBoxItem>();
            BasicInfoUtil.AddUnKnown(dataSource);
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

        private void ChequeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool BeforSave()
        {
            bool b;

            lblAccountHolderName.ForeColor = Color.Black;
            lblAccountNumber.ForeColor = Color.Black;
            lblBankName.ForeColor = Color.Black;
            lblChequeNumber.ForeColor = Color.Black;
            //lblChqueReply.ForeColor = Color.Black;
            //lblDescription.ForeColor = Color.Black;
            lblDescription2.ForeColor = Color.Black;
            lblEntryDate.ForeColor = Color.Black;
            lblInsuranceNumber.ForeColor = Color.Black;
            lblIssueDate.ForeColor = Color.Black;
            lblMaturityDate.ForeColor = Color.Black;
            lblPayType.ForeColor = Color.Black;

            b = FormChecker.CheckEmpty(cmbPayType, lblPayType);
            b &= FormChecker.CheckEmpty(cmbInsuranceCompany, lblInsuranceCompany);
           
/*            b &= FormChecker.CheckEmpty(txtCompany, lblCompany);
            if (txtCompany.Tag == null || ((int)txtCompany.Tag) <= 0)
            {
                b &= false;
                lblCompany.ForeColor = Color.Red;
            }
            else
                lblCompany.ForeColor = Color.Black;
*/
            if (_id <0)
                b &= FormChecker.CheckEmpty(cmbReferenceUserId, lblReferenceUserId);

            if (cmbPayType.SelectedIndex == 0)
            {
                b &= FormChecker.CheckEmpty(txtChequeNumber, lblChequeNumber);
                b &= FormChecker.CheckDate(txtMaturityDate, lblMaturityDate);
                b &= FormChecker.CheckEmpty(txtPrice, lblPrice);
                b &= FormChecker.CheckEmpty(cmbBankId, lblBankName);
                b &= FormChecker.CheckEmpty(txtAccountNumber, lblAccountNumber);
                b &= FormChecker.CheckEmpty(txtAccountHolderName, lblAccountHolderName);
                b &= FormChecker.CheckEmpty(txtInsuranceNumber, lblInsuranceNumber);
            }
            else if (cmbPayType.SelectedIndex == 1)
            {
                b &= FormChecker.CheckEmpty(txtPrice, lblPrice);
                b &= FormChecker.CheckEmpty(txtInsuranceNumber, lblInsuranceNumber);
            }

            try
            {
                if (txtPrice.Text.Length > 0)
                {
                    int i = int.Parse(txtPrice.Text);
                    lblPrice.ForeColor = Color.Black;
                }
            }
            catch(Exception ex)
            {
                b &= false;
                lblPrice.ForeColor = Color.Red;
            }

            return b;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!BeforSave())
                return;

            DateConverter dateconverter = new DateConverter();
            
            ChequeEntity entity = new ChequeEntity();
            DataRow dr = entity.Tables[entity.TableName].NewRow();
            if (_id > 0)
                dr[ChequeEntity.FIELD_ID] = _id;

            dr[ChequeEntity.FIELD_PAY_TYPE] = cmbPayType.SelectedIndex== 0 ? false : true;
            dr[ChequeEntity.FIELD_CHEQUE_NUMBER] = txtChequeNumber.Text;
            dr[ChequeEntity.FIELD_MATURITY_DATE] = dateconverter.stringToValue(txtMaturityDate.Text);
            dr[ChequeEntity.FIELD_ENTRY_DATE] = dateconverter.stringToValue(txtEntryDate.Text);
            dr[ChequeEntity.FIELD_PRICE] = txtPrice.Text;
            if (cmbBankId.SelectedIndex == 0)
                dr[ChequeEntity.FIELD_BANK_ID] = 0;
            else
                dr[ChequeEntity.FIELD_BANK_ID] = ((ComboBoxItem)cmbBankId.Items[cmbBankId.SelectedIndex]).Value;

            dr[ChequeEntity.FIELD_ARCHIVE] = cbArchive.Checked;

            dr[ChequeEntity.FIELD_ACCOUNT_NUMBER] = txtAccountNumber.Text;
            dr[ChequeEntity.FIELD_INSURANCE_NUMBER] = txtInsuranceNumber.Text;
            dr[ChequeEntity.FIELD_ACCOUNT_HOLDER_NAME] = txtAccountHolderName.Text;
            //dr[ChequeEntity.FIELD_DESCRIPTION] = txtDescription.Text;

            dr[ChequeEntity.FIELD_INSURANCE_COMPANY] = ((ComboBoxItem)cmbInsuranceCompany.Items[cmbInsuranceCompany.SelectedIndex]).Value;

            dr[ChequeEntity.FIELD_REGISTER_DATE] = dateconverter.stringToValue(txtRegisterDate.Text);
            dr[ChequeEntity.FIELD_REGISTRANT_USER] = txtRegistrantUser.Tag;
            dr[ChequeEntity.FIELD_COMPANY_ID] = txtCompany.Tag;

            if (String.Join("", txtRefferDate.Text.Split('/')).Trim().Length == 0)
            {
                dr[ChequeEntity.FIELD_REFFER_DATE] = dateconverter.stringToValue(txtRegisterDate.Text);
            }
            else
                dr[ChequeEntity.FIELD_REFFER_DATE] = dateconverter.stringToValue(txtRefferDate.Text);
            
            if (_id < 0)
            {
                int treeId = int.Parse(((ComboBoxItem)cmbReferenceUserId.Items[cmbReferenceUserId.SelectedIndex]).Value);
                int loggindeUserId = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());

                dr[ChequeEntity.FIELD_USER_TREE_ID] = treeId;
                dr[ChequeEntity.FIELD_REFER_FROM_USER_ID] = loggindeUserId;
                dr[ChequeEntity.FIELD_REGISTRANT_USER] = loggindeUserId;

                entity.Tables[entity.TableName].Rows.Add(dr);

                _id = _chequeBL.add(entity);
                lblMsg.Text = "دخیره شده ";
                //int treeId = int.Parse(((ComboBoxItem)cmbReferenceUserId.Items[cmbReferenceUserId.SelectedIndex]).Value);
               //int updateds = _chequeBL.updateRefferenceUser(_id, treeId);
                
                cmbReferenceUserId.Visible = false;
                lblReferenceUserId.Visible = false;
                
                checkColorOFCheque();
                tblReply.Visible = true;
            }
            else
            {

                dr[ChequeEntity.FIELD_ID] = _id;

                dr[ChequeEntity.FIELD_USER_TREE_ID] = _userTreeId;
                
                entity.Tables[entity.TableName].Rows.Add(dr);

                _chequeBL.update(entity);
                checkColorOFCheque();
                lblMsg.Text = "به روز رسانی گردید.";
                this.Close();
            }
            DataChanged = true;
        }

        #region chequeReply Region

        private GridTools _gridTools;
        
        private Panel[] _searchPanels;
        private string[] _searchFields;
        private ChequeReplyBL _chequeReplyBL;
        
        private void initList()
        {
            _chequeReplyBL = new ChequeReplyBL();
            _gridTools = new GridTools();
        
            fillGrid();
            initSearch();

            new GridTools().selectRow(dataGridView1, ChequeReplyEntity.FIELD_ID, _id);
        }

        private void initSearch()
        {
            _searchFields = new string[4];
            _searchPanels = new Panel[4];

            _searchFields[0] = ChequeReplyEntity.FIELD_RECIEPTBILLNUMBER;
            _searchFields[1] = ChequeReplyEntity.FIELD_ISSUEDATE;
            _searchFields[2] = ChequeReplyEntity.FIELD_PRICE;
            _searchFields[3] = ChequeReplyEntity.FIELD_DESCRIPTION;

            _searchPanels[00] = pnlRecieptBillNumber;
            _searchPanels[01] = pnlIssueDate;
            _searchPanels[02] = pnlPrice;
            _searchPanels[03] = pnlDescription;

            selectSearchPanel(0);

        }


        private void fillGrid()
        {
            fillGrid("");
        }

        private void fillGrid(string cond)
        {
            ChequeReplyEntity entity = null;
            entity = _chequeReplyBL.getByCheque(_id, cond);
            int count = entity.RowCount();
            
            tblReply.Height = 70 + count * 20;
            System.Collections.Hashtable hash = new Hashtable();
            if (_gridTools == null)
                _gridTools = new GridTools();
            _gridTools.bindDataToGrid(dataGridView1, entity, null, hash);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ChequeReplyForm form = new ChequeReplyForm(-1, txtCompany.Text);
            form.ChequeId = _id;
            form.initForm();
            form.ShowDialog();
            checkColorOFCheque();
            fillGrid();
        }

        private void checkColorOFCheque()
        {
            
            ChequeReplyEntity en = _chequeReplyBL.getByCheque(_id, "");
            if (en.Tables[en.FilledTableName].Rows.Count > 0)
                _chequeBL.updateColor(_id, "");
            else {
                ApplicationPropertiesBL appPropertiesBL = new ApplicationPropertiesBL();
                string color = appPropertiesBL.getValue(ApplicationPropertiesBL.CHEQUE_WITHNO_REPLY);
                _chequeBL.updateColor(_id, color);
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DataGridView gv = dataGridView1;
            if (gv.SelectedCells.Count > 0)
            {
                DataGridViewColumn col = gv.Columns[gv.SelectedCells[0].ColumnIndex];

                if (col.DataGridView.SelectedCells.Count > 0 && gv.SelectedCells[0].Selected)
                {
                    DataGridViewRow dr = gv.SelectedCells[0].OwningRow;
                    int id = -1;
                    id = int.Parse(dr.Cells[ChequeReplyEntity.FIELD_ID].Value.ToString());
                    ChequeReplyForm form = new ChequeReplyForm(id, txtCompany.Text);
                    form.ChequeId = _id;
                    form.initForm();
                    form.ShowDialog();
                    checkColorOFCheque();
                    fillGrid();

                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.SelectedCells.Count > 0)
            {
                DataGridViewColumn col = gv.Columns[gv.SelectedCells[0].ColumnIndex];

                if (col.DataGridView.SelectedCells.Count > 0 && gv.SelectedCells[0].Selected)
                {
                    DataGridViewRow dr = gv.SelectedCells[0].OwningRow;
                    int id = -1;
                    id = int.Parse(dr.Cells[ChequeReplyEntity.FIELD_ID].Value.ToString());
                    ChequeReplyForm form = new ChequeReplyForm(id, txtCompany.Text);
                    form.ChequeId = _id;
                    form.initForm();
                    form.ShowDialog();
                    fillGrid();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.SelectedCells.Count > 0 && gv.SelectedCells[0].ColumnIndex > 1)
            {
                DataGridViewColumn col = gv.Columns[dataGridView1.SelectedCells[0].ColumnIndex];
                string pName = col.DataPropertyName;
                if (pName.Equals(_searchFields[0])) selectSearchPanel(0);
                else if (pName.Equals(_searchFields[01])) selectSearchPanel(01);
                else if (pName.Equals(_searchFields[02])) selectSearchPanel(02);
                else if (pName.Equals(_searchFields[03])) selectSearchPanel(03);
                
            }
        }

        private void selectSearchPanel(int index)
        {
            for (int i = 0; i < _searchPanels.Length; i++)
            {
                if (index == i)
                    _searchPanels[i].Visible = true;
                else
                    _searchPanels[i].Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchTools searchTools = new SearchTools();
            string cond = "";

            if (_searchPanels[0].Visible)
                cond = searchTools.getStringFldCond(ChequeReplyEntity.FIELD_RECIEPTBILLNUMBER, txtRecieptBillNumber.Text, "");
            else if (_searchPanels[1].Visible)
                cond = searchTools.getDateFldCond(ChequeReplyEntity.FIELD_ISSUEDATE, txtIssueDate.Text, txtIssueDate.Text, cmbCompareIssueDate, "");
            else if (_searchPanels[2].Visible)
                cond = searchTools.getStringFldCond(ChequeReplyEntity.FIELD_PRICE, txtPrice2.Text, "");
            else if (_searchPanels[3].Visible)
                cond = searchTools.getStringFldCond(ChequeReplyEntity.FIELD_DESCRIPTION, txtDescription2.Text, "");
            fillGrid(cond);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridView gv = dataGridView1;
            if (gv.SelectedCells.Count > 0)
            {
                DataGridViewColumn col = gv.Columns[gv.SelectedCells[0].ColumnIndex];

                if (col.DataGridView.SelectedCells.Count > 0 && gv.SelectedCells[0].Selected)
                {
                    DataGridViewRow dr = gv.SelectedCells[0].OwningRow;
                    int id = -1;
                    id = int.Parse(dr.Cells[ChequeReplyEntity.FIELD_ID].Value.ToString());

                    DialogResult dres = MessageBox.Show("آیا مایلید حذف کنید ؟", "", MessageBoxButtons.YesNo);
                    if (dres.Equals(DialogResult.Yes))
                    {
                        _chequeReplyBL.delete(id);
                        checkColorOFCheque();
                        fillGrid();
                    }
                }
            }
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                btnSearch_Click(null, null);
        }

        #endregion

        private void btnReferToMasterUser_Click(object sender, EventArgs e)
        {
            if (_id < 0)
                return;
            ChequeEntity entity = _chequeBL.get(_id);
            if (entity != null && entity.Tables[entity.FilledTableName].Rows.Count > 0)
            {
                //نودی از درخت که نامه در دست وی است
                //ابتدا بررسی می کنیم که آیا کاربر وارد شده همان شخصی است که این نامه در دست وی است ،
                // اگر نبود یک سوال پرسیده خواهد شد.
                int userTreeId = -1;
                if (entity.get(ChequeEntity.FIELD_USER_TREE_ID).ToString().Length > 0)
                    userTreeId = int.Parse(entity.get(ChequeEntity.FIELD_USER_TREE_ID).ToString());

                bool iss = checkIsLetterUserEqualLogginedUser(userTreeId);
                if (!iss)
                {
                    DialogResult re = MessageBox.Show("این چک در اختیار شما نمی باشد! آیا مایلید که آن را  به شخص دیگری ارجاع نمایید ؟ ", "", MessageBoxButtons.YesNo);
                    if (re.Equals(DialogResult.No))
                        return;
                }

                RefferToForm form = new RefferToForm(txtRefferDate.Enabled);
                form.UserTreeId = userTreeId;
                form.ChequeId = _id;
                form.LoadForm();
                form.ShowDialog();
                if (form.IsRefferDone)
                {
                    this.DataChanged1 = true;
                    this.Close();
                }
            }
        }
        
        private bool checkIsLetterUserEqualLogginedUser(int ownerTreeNodeId)
        {
            int loggindeUserId = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
            UserTreeBL userTree = new UserTreeBL();
            UserTreeEntity treeEntity = userTree.get(ownerTreeNodeId);
            if (treeEntity.Tables[treeEntity.FilledTableName].Rows.Count > 0)
            {
                int userId = int.Parse(treeEntity.get(UserTreeEntity.FIELD_USER_ID).ToString());
                if (userId.Equals(loggindeUserId))
                    return true;
            }
            return false;
        }

        private void cmbCompareIssueDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            bool b = cmb.SelectedIndex == 5 ? b = true : false;
            lblFrom.Visible = b;
            lblTo.Visible = b;
            txtTo.Visible = b;
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {

            //_searchFields[0] = ChequeReplyEntity.FIELD_RECIEPTBILLNUMBER;
            //_searchFields[1] = ChequeReplyEntity.FIELD_ISSUEDATE;
            //_searchFields[2] = ChequeReplyEntity.FIELD_PRICE;
            //_searchFields[3] = ChequeReplyEntity.FIELD_DESCRIPTION;

            SearchTools searchTools = new SearchTools();
            string cond = "";

            if (_searchPanels[0].Visible)
                cond = searchTools.getStringFldCond(ChequeReplyEntity.FIELD_RECIEPTBILLNUMBER, txtRecieptBillNumber.Text, "");
            else if (_searchPanels[1].Visible)
                cond = searchTools.getDateFldCond(ChequeReplyEntity.FIELD_ISSUEDATE, txtIssueDate.Text, txtTo.Text, cmbCompareIssueDate, "");
            else if (_searchPanels[2].Visible)
                cond = searchTools.getStringFldCond(ChequeReplyEntity.FIELD_PRICE, txtPrice2.Text, "");
            else if (_searchPanels[3].Visible)
                cond = searchTools.getStringFldCond(ChequeReplyEntity.FIELD_DESCRIPTION, txtDescription2.Text, "");
            fillGrid(cond);
        }

        private void btnShowCompany_Click(object sender, EventArgs e)
        {
            if (txtCompany.Tag == null)
                txtCompany.Tag = 0;
            CompanyList list = new CompanyList();
            list.ReadOnly = true;
            list.Id = (int)txtCompany.Tag;
            list.initList();
            list.ShowDialog();
            txtCompany.Tag = list.Id;
            txtCompany.Text = CompanyBL.getCompanyName(list.Id);
        }

        private void btnShowRefrences_Click(object sender, EventArgs e)
        {
            ChequeRefferencesForm form = new ChequeRefferencesForm();
            form.initForm(_id);
            form.ShowDialog();
        }

        private void lblCompany_Click(object sender, EventArgs e)
        {

        }

        private void txtCompany_TextChanged(object sender, EventArgs e)
        {

        }

        private void setPermision()
        {
            int userid = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
            ChequeFieldsPermissionBL chqFieldsPermBL = new ChequeFieldsPermissionBL();
            ChequeFieldsPermissionEntity m_permissionEntity = chqFieldsPermBL.getByUser(userid);

            if (UsersBS.ADMIN.ToString().Equals(UsersBS.loginedUser.get(UsersEntity.FIELD_USER_TYPE).ToString()))
                return;

            doPerm(cmbPayType, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_PAYTYPE));
            doPerm(txtChequeNumber, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_CHEQUENUMBER));
            doPerm(txtMaturityDate, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_MATURITYDATE));
            doPerm(txtEntryDate, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_ENTRYDATE));
            doPerm(cmbBankId, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_BANKID));
            doPerm(txtPrice, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_PRICE));
            doPerm(txtAccountNumber, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_ACCOUNTNUMBER));
            doPerm(txtCompany, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_COMPANYID));
            doPerm(btnShowCompany, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_COMPANYID));
            doPerm(txtRefferDate, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_REFFERDATE));
            doPerm(cmbReferenceUserId, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_REFFERFROM));
            doPerm(cmbInsuranceCompany, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_INSURANCECOMPANY));
            doPerm(txtInsuranceNumber, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_INSURANCENUMBER));
            doPerm(txtAccountHolderName, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_ACCOUNTHOLDERNAME));
            doPerm(tblReply, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_CHEQUEITEMS));
            doPerm(cbArchive, m_permissionEntity.get(ChequeFieldsPermissionEntity.FIELD_ARCHIVE));


        }

        private void doPerm(Control c, object value)
        {
            if (int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_USER_TYPE).ToString()).Equals(UsersBS.ADMIN))
                return;
            if (value == null || value.ToString().Equals("") || ((Boolean)value).Equals(false))
            {
                c.Enabled = false;
            }
            else
                c.Enabled = true;
        }

        private void linkAttachment_MouseClick(object sender, MouseEventArgs e)
        {
            AttachmentChequeList list = new AttachmentChequeList(_id);
            list.ShowDialog();
        }

    }

    }
