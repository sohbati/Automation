using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using AndicatorBLL;
using AndicatorCommon;
using RMX_TOOLS.data.grid;
using Andicator.controls;
using RMX_TOOLS.hasti.tools;
using Andicator.controls.tools;
using System.Data.SqlClient;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Export;

namespace Andicator.lists
{
    public partial class LetterList : Form
    {
        #region variables
        
        private LetterBL _letterBl;
        private GridTools _gridTools;
        private AdvanceSearchForm _advanceSearchForm;

        private Panel[] _searchPanels;
        private string[] _searchFields;
        private LetterEntity _entity = null;
        #endregion

        #region properties
        private int _letterType;

        public int LetterType
        {
            get { return _letterType; }
            set { _letterType = value; }
        }

        private bool _selectMode = false;

        private int _returnLetterId = -1;

        public int ReturnLetterId
        {
            get { return _returnLetterId; }
            set { _returnLetterId = value; }
        }

        private bool _disableCbWithChain;

        public bool DisableCbWithChain
        {
            get { return _disableCbWithChain; }
            set { _disableCbWithChain = value; }
        }

        #endregion

        public LetterList(int letterType): this(letterType, false)
        {
        }

        public LetterList(int letterType, bool selectMode)
        {
            InitializeComponent();
            LetterType = letterType;
            _selectMode = selectMode;
            _letterBl = new LetterBL();
            _gridTools = new GridTools();
        }

        public void init()
        {
            fillGrid();
            flowLayoutPanel1.SuspendLayout();
            dataGridView1.Tag = _letterType;

            cmbCompareLetterDate.SelectedIndex = 0;

            _advanceSearchForm = new AdvanceSearchForm(_letterType);
            initSearch();

            doPermision();

            doSelectMode();

            if (DisableCbWithChain)
                cbWithChainig.Enabled = false; 
        }

        public void setWithchainig(bool b)
        {
            cbWithChainig.Checked = b;
        }

        private void doSelectMode()
        {
            btnCancel.Visible = btnPrint.Visible = btnDelete.Visible = btnNew.Visible = btnDisplay.Visible = !_selectMode;
            btnChoise.Visible = _selectMode;
        }

        private void doPermision()
        {
            //permision
            if (UsersBS.ADMIN.ToString().Equals(UsersBS.loginedUser.get(UsersEntity.FIELD_USER_TYPE).ToString()))
                return;
            int userid = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());

            LetterItemsPermissionBL letItemPerm = new LetterItemsPermissionBL();
            LetterItemsPermissionEntity entity = letItemPerm.getByUser(userid);

            doPerm(btnDelete, entity.get(LetterItemsPermissionEntity.FIELD_DELETE_LETTER));
        }

        private void doPerm(Control c, object value)
        {
            if (value == null || value.ToString().Equals("") || ((Boolean)value).Equals(false))
            {
                c.Enabled = false;
            }
            else
                c.Enabled = true;
        }

        private void initSearch()
        {
            _searchFields = new string[9];
            _searchPanels = new Panel[9];

            BasicInfoUtil.fillComboBox(cmbInsuranceType, "InsuranceType", -1);
            BasicInfoUtil.fillComboBox(cmbLetterStateId, "LetterState", -1);
            UsersBS.fillComboWithUsers(cmbReferenceUserId, -1);
            UsersBS.fillComboWithUsers(cmbRefferFrom, -1);

            _searchFields[0] = LetterEntity.FIELD_LETTER_NUMBER;
            _searchFields[1] = LetterEntity.FIELD_LETTER_DATE;
            _searchFields[2] = LetterEntity.FIELD_LETTER_SUBJECT;
            _searchFields[3] = LetterEntity.FIELD_INSURANCE_TYPE_ID + "_DESC";
            _searchFields[4] = LetterEntity.FIELD_INSURANCE_DATE;
            _searchFields[5] = LetterEntity.FIELD_LETTER_STATE_ID + "_DESC";
            _searchFields[6] = LetterEntity.VIEW_FIELD_REFERENCED_USER_ID + "_DESC";
            _searchFields[7] = LetterEntity.FIELD_COMPANY_ID + "_DESC";
            _searchFields[8] = LetterEntity.FIELD_REFER_FROM_USER_ID + "_DESC";

            _searchPanels[00]=pnlLetterNumber;
            _searchPanels[01]=pnlLetterDate;
            _searchPanels[02]=pnlSubject;
            _searchPanels[03]=pnlInsurance;
            _searchPanels[04] = pnlInsuranceDate;
            _searchPanels[05]=pnlLetterState;
            _searchPanels[06]=pnlReferenceUser;
            _searchPanels[07] = pnlCompanyName;
            _searchPanels[08] = pnlRefferFrom;

            selectSearchPanel(0);
            
            cmbCompareInsuranceDate.SelectedIndex = 0;
            cmbCompareLetterDate.SelectedIndex = 0;
            
            cmbCompareInsuranceDate_SelectedIndexChanged(cmbCompareInsuranceDate, null);
            cmbCompareLetterDate_SelectedIndexChanged(cmbCompareLetterDate, null);

        }

        private void fillGrid(string cond)
        {
            _entity = _letterBl.get(cond, _letterType, cbWithChainig.Checked);

            //_letterBl.get(LetterType);
            System.Collections.Hashtable hash = new Hashtable();
            hash.Add("colorField", "COLOR");

            _gridTools.bindDataToGrid(dataGridView1, _entity, new GridTools.changingRow(_gridTools.changeColor), hash);

        }

        private void fillGrid()
        {
            //lblMsg.Text = "";
            
            if(rbDisplayAll.Checked)
                _entity = _letterBl.get(LetterType, cbWithChainig.Checked);
            else if (rbDisplayArchived.Checked)
                _entity = _letterBl.get(LetterType, cbWithChainig.Checked);
            else
                _entity = _letterBl.get(LetterType, cbWithChainig.Checked);

            //_letterBl.get(LetterType);
            System.Collections.Hashtable hash = new Hashtable();
            hash.Add("colorField", "COLOR");

            _gridTools.bindDataToGrid(dataGridView1, _entity, new GridTools.changingRow(_gridTools.changeColor), hash);

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DataGridViewColumn col = dataGridView1.Columns[dataGridView1.SelectedCells[0].ColumnIndex];
            
            if(col.DataGridView.SelectedCells.Count > 0 && dataGridView1.SelectedCells[0].Selected)
            //if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedCells[0].OwningRow;
                int id = int.Parse(dr.Cells[LetterEntity.FIELD_ID].Value.ToString());
                LetterForm form = new LetterForm();
                form.LetterType = LetterType;
                form.LetterId = id;

                form.initLetter();
                form.ShowDialog();
                if (form.DataChanged)
                    fillGrid();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LetterForm form = new LetterForm();
            form.LetterType = LetterType;
            form.initLetter();
            form.LetterId = -1;
            form.ShowDialog();
            if (form.DataChanged)
                fillGrid();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkedChanged(object sender, EventArgs e)
        {
            fillGrid();
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
                    id = int.Parse(dr.Cells[LetterEntity.FIELD_ID].Value.ToString());
                    if (!_selectMode)
                    {
                        LetterForm form = new LetterForm((int)gv.Tag);
                        form.LetterId = id;
                        form.initLetter();
                        form.ShowDialog();
                        if (form.DataChanged)
                            fillGrid();
                    }
                    else
                    {
                        _returnLetterId = id;
                        this.Close();
                    }

                }
            }
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
                    id = int.Parse(dr.Cells[LetterEntity.FIELD_ID].Value.ToString());

                    DialogResult dres = MessageBox.Show("آیا مایلید حذف کنید ؟", "", MessageBoxButtons.YesNo);
                    if (dres.Equals(DialogResult.Yes))
                    {
                       id =  _letterBl.delete(id);
                        fillGrid();
                    }
                }
            }
        }

        private void LetterList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchTools searchTools = new SearchTools();
            string cond = "";
            if (pnlLetterNumber.Visible)
                cond = searchTools.getStringFldCond(LetterEntity.FIELD_LETTER_NUMBER, txtLetterNumber.Text, "");
            else if (pnlLetterDate.Visible)
                cond = searchTools.getDateFldCond(LetterEntity.FIELD_LETTER_DATE  , txtLetterDate.Text  , txtTo1.Text , cmbCompareLetterDate, "");
            else if (pnlSubject.Visible)
                cond = searchTools.getStringFldCond(LetterEntity.FIELD_LETTER_SUBJECT, txtSubject.Text, "");
            else if (pnlInsurance.Visible)
            {
                cond = searchTools.getCombofldCond(cmbInsuranceType, LetterEntity.FIELD_INSURANCE_TYPE_ID, "");
                cond = searchTools.getStringFldCond(LetterEntity.FIELD_INSURANCE_NUMBER, txtInsuranceNumber.Text, cond);
            }else if (pnlInsuranceDate.Visible)
                cond = searchTools.getDateFldCond(LetterEntity.FIELD_INSURANCE_DATE, txtInsuranceDate.Text, txtTo2.Text, cmbCompareInsuranceDate, "");
            else if (pnlLetterState.Visible)
                cond = searchTools.getCombofldCond(cmbLetterStateId, LetterEntity.FIELD_LETTER_STATE_ID, "");
            else if (pnlReferenceUser.Visible)
                cond = searchTools.getCombofldCond(cmbReferenceUserId, LetterEntity.VIEW_FIELD_REFERENCED_USER_ID, "");
            else if (pnlRefferFrom.Visible)
                cond = searchTools.getCombofldCond(cmbRefferFrom, LetterEntity.FIELD_REFER_FROM_USER_ID, "");
            else if (pnlCompanyName.Visible)
                cond = searchTools.getNumberFldCond((int)txtCompany.Tag, LetterEntity.FIELD_COMPANY_ID, "");

            if (cond.Length > 0)
                cond += " AND ";
            cond += LetterEntity.FIELD_LETTER_TYPE + "=" + _letterType;

            if (rbDisplayArchived.Checked)
            {
                if (cond.Length > 0)
                    cond += " AND ";
                cond += LetterEntity.FIELD_ARCHIVE+ "=1";
            }else if (rbDisplayNew.Checked)
            {
                if (cond.Length > 0)
                    cond += " AND ";
                cond += "(" + LetterEntity.FIELD_ARCHIVE + "=0 OR " + LetterEntity.FIELD_ARCHIVE + " IS NULL)" ;
            }
            fillGrid(cond);
        }

        private void txtLetterNumber_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtLetterDate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            
            _advanceSearchForm.ResultCondition = "";
            _advanceSearchForm.init();

            _advanceSearchForm.ShowDialog();
            string cond = _advanceSearchForm.ResultCondition;
            if (cond.Trim().Length > 0)
                fillGrid(cond);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.SelectedCells.Count > 0 && gv.SelectedCells[0].ColumnIndex > 2)
            {
                DataGridViewColumn col = gv.Columns[dataGridView1.SelectedCells[0].ColumnIndex];
                string pName = col.DataPropertyName;
                if (pName.Equals(_searchFields[0])) selectSearchPanel(0);
                else if (pName.Equals(_searchFields[01])) selectSearchPanel(01);
                else if (pName.Equals(_searchFields[02])) selectSearchPanel(02);
                else if (pName.Equals(_searchFields[03])) selectSearchPanel(03);
                else if (pName.Equals(_searchFields[04])) selectSearchPanel(04);
                else if (pName.Equals(_searchFields[05])) selectSearchPanel(05);
                else if (pName.Equals(_searchFields[06])) selectSearchPanel(06);
                else if (pName.Equals(_searchFields[07])) selectSearchPanel(07);
                else if (pName.Equals(_searchFields[08])) selectSearchPanel(08);

                // for return value
                if (_selectMode)
                {
                    if (gv.SelectedCells.Count > 0)
                    {
                        if (col.DataGridView.SelectedCells.Count > 0 && gv.SelectedCells[0].Selected)
                        {
                            DataGridViewRow dr = gv.SelectedCells[0].OwningRow;
                            int id = -1;
                            id = int.Parse(dr.Cells[LetterEntity.FIELD_ID].Value.ToString());
                            _returnLetterId = id;
                        }
                    }
                }
            }
        }

        private void selectSearchPanel(int index) {
            for (int i = 0; i < _searchPanels.Length; i++)
            {
                if (index == i)
                    _searchPanels[i].Visible = true;
                else
                    _searchPanels[i].Visible = false;
            }
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                btnSearch_Click(null, null);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_entity == null)
                return;
            
              Stimulsoft.Report.StiReport stiReport1;
              stiReport1 = new StiReport();
              stiReport1.Dictionary.DataStore.Clear();
              
              stiReport1.Load("letterReport.mrt");
              stiReport1.Dictionary.DataSources.Clear();
              stiReport1.Dictionary.Databases.Clear();
              stiReport1.Dictionary.Databases.Add(new StiSqlDatabase("ارتباط", RMX_TOOLS.data.IDataProvider.connectionString));
              stiReport1.RegData(_entity.FilledTableName,_entity.FilledTableName, _entity.Tables[_entity.FilledTableName]);
              stiReport1.Dictionary.Synchronize();
              stiReport1.Compile();
              try
              {
                  // StiWebViewer1.Report = stiReport1;               
                //  stiReport1.CompiledReport.ExportDocument(StiExportFormat.ExcelXml, "tmp\\document.xml");
                  
                  //stiReport1.CompiledReport.ExportDocument(StiExportFormat.Word2007, "tmp\\document.docx");
                  // StiExcelExportService export = new StiExcelExportService();
                  // export.ExportExcel(stiReport1, "tmp\\document.xls");
                  //System.Diagnostics.Process.Start("tmp\\document.xml");
                  stiReport1.Show();
              }
              catch (Exception ex)
              {
                 // stiReport1.Show();
              }
        }

        private void cmbCompareLetterDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            bool b = cmb.SelectedIndex == 5 ? b = true : false;
            lblFrom1.Visible = b;
            lblTo1.Visible = b;
            txtTo1.Visible = b;
        }

        private void cmbCompareInsuranceDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            bool b = cmb.SelectedIndex == 5 ? b = true : false;
            lblFrom2.Visible = b;
            lblTo2.Visible = b;
            txtTo2.Visible = b;
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

        private void btnChoise_Click(object sender, EventArgs e)
        {
            if (_returnLetterId < 0)
            {
                MessageBox.Show("نامه ای انتخاب نشده است. لطفا یک نامه انتخاب نمایید");
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
