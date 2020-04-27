using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorCommon;
using RMX_TOOLS.data.grid;
using System.Collections;
using Andicator.controls;
using RMX_TOOLS.hasti.tools;
using AndicatorBLL;
using Andicator.controls.tools;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;

namespace Andicator.lists
{
    public partial class ChequeList : Form
    {
        private ChequeEntity _entity = null;
        private ChequeBL _chequeBL;
        private GridTools _gridTools;

        private ChequeAdvanceSearchForm _advanceSearchForm;

        private Panel[] _searchPanels;
        private string[] _searchFields;

        #region
        private int _id = -1;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private bool _readOnly;

        public bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }
        #endregion
        public ChequeList()
        {
            _gridTools = new GridTools();

            InitializeComponent();

            _chequeBL = new ChequeBL();
            _advanceSearchForm = new ChequeAdvanceSearchForm();
            
            initList();
            //permision
            if (!UsersBS.ADMIN.ToString().Equals(UsersBS.loginedUser.get(UsersEntity.FIELD_USER_TYPE).ToString()))
                btnDelete.Enabled = false;
        }

        public void initList()
        {
            fillGrid();
            initSearch();

            if (_readOnly)
            {
                btnNew.Visible = false;
            }

            new GridTools().selectRow(dataGridView1, ChequeEntity.FIELD_ID, _id);
            cmbPayType.Items.Clear();
            ComboBoxItem item = new ComboBoxItem("نامشخص", "-1");
            cmbPayType.Items.Add(item);
            item = new ComboBoxItem("چک", "0");
            cmbPayType.Items.Add(item);
            item = new ComboBoxItem("نقد", "1");
            cmbPayType.Items.Add(item);

            cmbCompareMaturityDate.SelectedIndex = 0;
            cmbCompareMaturityDate_SelectedIndexChanged(cmbCompareMaturityDate, null);

            cmbCompareEntryDate.SelectedIndex = 0;
            cmbCompareEntryDate_SelectedIndexChanged(cmbCompareEntryDate, null);
        }

        private void initSearch()
        {
            _searchFields = new string[12];
            _searchPanels = new Panel[12];

            BasicInfoUtil.fillComboBox(cmbBankId, "Bank", -1);
            UsersBS.fillComboWithUsers(cmbRefferFrom, -1);
            UsersBS.fillComboWithUsers(cmbRefferToUser, -1);

            _searchFields[0] = ChequeEntity.FIELD_CHEQUE_NUMBER;
            _searchFields[1] = ChequeEntity.FIELD_MATURITY_DATE;
            _searchFields[2] = ChequeEntity.FIELD_ENTRY_DATE;
            _searchFields[3] = ChequeEntity.FIELD_PRICE;
            _searchFields[4] = ChequeEntity.VIEW_FIELD_BI_BANK_DESCRIPTION;
            _searchFields[5] = ChequeEntity.FIELD_ACCOUNT_HOLDER_NAME;
            _searchFields[6] = ChequeEntity.FIELD_ACCOUNT_NUMBER;
            _searchFields[7] = ChequeEntity.FIELD_DESCRIPTION;
            _searchFields[8] = ChequeEntity.VIEW_FIELD_PAYTYPE_DESC;
            _searchFields[9] = ChequeEntity.VIEW_FIELD_COMPANYNAME;
            _searchFields[10] = ChequeEntity.FIELD_REFER_FROM_USER_ID + "_DESC";
            _searchFields[11] = ChequeEntity.VIEW_FIELD_USERNAME;

            _searchPanels[00] = pnlChequeNumber;
            _searchPanels[01] = pnlMaturityDate;
            _searchPanels[02] = pnlEntryDate;
            _searchPanels[03] = pnlPrice;
            _searchPanels[04] = pnlBank;
            _searchPanels[05] = pnlAccountHolderName;
            _searchPanels[06] = pnlAccountNumber;
            _searchPanels[07] = pnlDescription;
            _searchPanels[08] = pnlPayType;
            _searchPanels[09] = pnlCompanyName;
            _searchPanels[10] = pnlRefferFrom;
            _searchPanels[11] = pnlRefferToUser;

            selectSearchPanel(0);

        }

        private void fillGrid()
        {
            fillGrid("");
        }

        private void fillGrid(string cond)
        {
            
            //entity = _chequeBL.get(cond);
            if (rbDisplayAll.Checked)
                _entity = _chequeBL.get(cond);
            else if (rbDisplayArchived.Checked)
                _entity = _chequeBL.get(cond, true);
            else
                _entity = _chequeBL.get(cond, false);

            System.Collections.Hashtable hash = new Hashtable();
            hash.Add("colorField", "COLOR");
            _gridTools.bindDataToGrid(dataGridView1, _entity, new GridTools.changingRow(_gridTools.changeColor), hash);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ChequeForm form = new ChequeForm(-1);
            form.initForm();
            form.ShowDialog();
            fillGrid();
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
                    id = int.Parse(dr.Cells[ChequeEntity.FIELD_ID].Value.ToString());
                    ChequeForm form = new ChequeForm(id);
                    form.initForm();
                    form.ShowDialog();
                    if (form.DataChanged1) 
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
                    id = int.Parse(dr.Cells[ChequeEntity.FIELD_ID].Value.ToString());
                    ChequeForm form = new ChequeForm(id);
                    form.initForm();
                    form.ShowDialog();
                    if(form.DataChanged1)
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
                if      (pName.Equals(_searchFields[0]))  selectSearchPanel(0);
                else if (pName.Equals(_searchFields[01])) selectSearchPanel(01);
                else if (pName.Equals(_searchFields[02])) selectSearchPanel(02);
                else if (pName.Equals(_searchFields[03])) selectSearchPanel(03);
                else if (pName.Equals(_searchFields[04])) selectSearchPanel(04);
                else if (pName.Equals(_searchFields[05])) selectSearchPanel(05);
                else if (pName.Equals(_searchFields[06])) selectSearchPanel(06);
                else if (pName.Equals(_searchFields[07])) selectSearchPanel(07);
                else if (pName.Equals(_searchFields[08])) selectSearchPanel(08);
                else if (pName.Equals(_searchFields[09])) selectSearchPanel(09);
                else if (pName.Equals(_searchFields[10])) selectSearchPanel(10);
                else if (pName.Equals(_searchFields[11])) selectSearchPanel(11);
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
                cond = searchTools.getStringFldCond(ChequeEntity.FIELD_CHEQUE_NUMBER, txtChequeNumber.Text, "");
            else if (_searchPanels[1].Visible)
                cond = searchTools.getDateFldCond(ChequeEntity.FIELD_MATURITY_DATE, txtMaturityDate.Text,txtMaturityDateTo.Text, cmbCompareMaturityDate, "");
            else if (_searchPanels[2].Visible)
                cond = searchTools.getDateFldCond(ChequeEntity.FIELD_ENTRY_DATE, txtEntryDate.Text,txtEntryDateTo.Text, cmbCompareEntryDate, "");
            else if (_searchPanels[3].Visible)
                cond = searchTools.getStringFldCond(ChequeEntity.FIELD_PRICE, txtPrice.Text, "");
            else if (_searchPanels[4].Visible)
                cond = searchTools.getCombofldCond(cmbBankId, ChequeEntity.FIELD_BANK_ID, "");
            else if (_searchPanels[5].Visible)
                cond = searchTools.getStringFldCond(ChequeEntity.FIELD_ACCOUNT_HOLDER_NAME, txtAccountHolderName.Text, "");
            else if (_searchPanels[6].Visible)
                cond = searchTools.getStringFldCond(ChequeEntity.FIELD_ACCOUNT_NUMBER, txtAccountNumber.Text, "");
            else if (_searchPanels[7].Visible)
                cond = searchTools.getStringFldCond(ChequeEntity.FIELD_DESCRIPTION, txtDescription.Text, "");
            else if (_searchPanels[8].Visible)
                cond = searchTools.getCombofldCond(cmbPayType, ChequeEntity.FIELD_PAY_TYPE, "");
            else if (_searchPanels[9].Visible)
                cond = searchTools.getNumberFldCond((int)txtCompany.Tag, ChequeEntity.FIELD_COMPANY_ID, "");
            else if (_searchPanels[10].Visible)
                cond = searchTools.getCombofldCond(cmbRefferFrom, ChequeEntity.FIELD_REFER_FROM_USER_ID, "");
            else if (_searchPanels[11].Visible)
                cond = searchTools.getCombofldCond(cmbRefferToUser, ChequeEntity.VIEW_FIELD_REFERENCED_USER_ID, "");

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
                    id = int.Parse(dr.Cells[ChequeEntity.FIELD_ID].Value.ToString());

                    DialogResult dres = MessageBox.Show("آیا مایلید حذف کنید ؟", "", MessageBoxButtons.YesNo);
                    if (dres.Equals(DialogResult.Yes))
                    {
                        try
                        {
                           int i =  _chequeBL.delete(id);

                           if (i == 0)
                           {
                               MessageBox.Show("موردی حذف نشد ، در صورت داشتن پاسخ برای این مورد لطفا ابتدا آنها را حذف نمایید");
                               return;
                           }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("امکان حذف این آیتم وجود ندارد، احتمالا برای این چک پاسخی ثبت شده است." + "/n"  + 
                                ex.Message);
                            return;
                        }
                        fillGrid();
                    }
                }
            }

        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                btnSearch_Click(null, null);
        }

        private void form_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }
    
        private void checkedChanged(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            _advanceSearchForm.ResultCondition = "";

            _advanceSearchForm.ShowDialog();
            string cond = _advanceSearchForm.ResultCondition;
            if (cond.Trim().Length > 0)
                fillGrid(cond);

        }

        private void cmbCompareMaturityDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            bool b = cmb.SelectedIndex == 5 ? b = true : false;
            lblMAturityDateFrom.Visible = b;
            lblMaturityDateTo.Visible = b;
            txtMaturityDateTo.Visible = b;
        }

        private void cmbCompareEntryDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            bool b = cmb.SelectedIndex == 5 ? b = true : false;
            lblEntryDateFrom.Visible = b;
            lblEntryDateTo.Visible = b;
            txtEntryDateTo.Visible = b;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_entity == null)
                return;

            Stimulsoft.Report.StiReport stiReport1;
            stiReport1 = new StiReport();
            stiReport1.Dictionary.DataStore.Clear();

            stiReport1.Load("chequeReport.mrt");
            stiReport1.Dictionary.DataSources.Clear();
            stiReport1.Dictionary.Databases.Clear();
            stiReport1.Dictionary.Databases.Add(new StiSqlDatabase("ارتباط", RMX_TOOLS.data.IDataProvider.connectionString));
            stiReport1.RegData(_entity.FilledTableName, _entity.FilledTableName, _entity.Tables[_entity.FilledTableName]);
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

    }
}
