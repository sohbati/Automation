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

namespace Andicator.lists
{
    public partial class CompanyList : Form
    {
        private CompanyBL _companyBL;
        private GridTools _gridTools;

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
        public CompanyList()
        {
            _gridTools = new GridTools();

            InitializeComponent();

            _companyBL = new CompanyBL();
            checkPerm();

            initList();
        }
        
        public void initList()
        {
            fillGrid();
            initSearch();

            if (_readOnly)
            {
                btnDelete.Visible = false;
                btnNew.Visible = false;
                btnSelect.Visible = true;
            }
            else
                btnSelect.Visible = false;

            new GridTools().selectRow(dataGridView1, CompanyEntity.FIELD_ID, _id);
        }

        private void checkPerm()
        {
            //company readonly 
            UserPropertiesEntity entity = UsersBS.LogginedUserProperties;
            UserpropertiesBL userProperties = new UserpropertiesBL();
            String v = userProperties.getValue(entity, UserpropertiesBL.MENU_COMPANY_READ_ONLY_PERMISSION);
            if (v != null && bool.Parse(v))
            {
                _readOnly = true;
            }

        }

        private void initSearch()
        {
            _searchFields = new string[7];
            _searchPanels = new Panel[7];

            BasicInfoUtil.fillComboBox(cmbSemat, "Semat", -1);

            _searchFields[0] = CompanyEntity.FIELD_COMPANY_NAME;
            _searchFields[1] = CompanyEntity.FIELD_OFFICER;
            _searchFields[2] = CompanyEntity.VIEW_FIELD_SEMAT;
            _searchFields[3] = CompanyEntity.FIELD_TEL;
            _searchFields[4] = CompanyEntity.FIELD_FAX;
            _searchFields[5] = CompanyEntity.FIELD_ADDRESS;
            _searchFields[6] = CompanyEntity.FIELD_DESCRIPTION;

            _searchPanels[00] = pnlCompanyName;
            _searchPanels[01] = pnlOfficer;
            _searchPanels[02] = pnlSemat;
            _searchPanels[03] = pnlTel;
            _searchPanels[04] = pnlFax;
            _searchPanels[05] = pnlAddress;
            _searchPanels[06] = pnlDescription;

            selectSearchPanel(0);

        }
        private void fillGrid()
        {
            fillGrid("");
        }

        private void fillGrid(string cond)
        {
            CompanyEntity entity = null;
            if (_readOnly)
                entity = _companyBL.getOnlyActives(cond);
            else
                entity = _companyBL.get(cond);

            System.Collections.Hashtable hash = new Hashtable();
            _gridTools.bindDataToGrid(dataGridView1, entity, null, hash);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CompanyList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CompanyForm form = new CompanyForm(-1);
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
                    id = int.Parse(dr.Cells[CompanyEntity.FIELD_ID].Value.ToString());
                    CompanyForm form = new CompanyForm(id,_readOnly);
                    form.ShowDialog();
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
                    id = int.Parse(dr.Cells[CompanyEntity.FIELD_ID].Value.ToString());
                    CompanyForm form = new CompanyForm(id, _readOnly);
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
                else if (pName.Equals(_searchFields[04])) selectSearchPanel(04);
                else if (pName.Equals(_searchFields[05])) selectSearchPanel(05);
                else if (pName.Equals(_searchFields[06])) selectSearchPanel(06);
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
                cond = searchTools.getStringFldCond(CompanyEntity.FIELD_COMPANY_NAME, txtCompanyName.Text, "");
            else if (_searchPanels[1].Visible)
                cond = searchTools.getStringFldCond(CompanyEntity.FIELD_OFFICER, txtOfficer.Text, "");
            else if (_searchPanels[2].Visible)
                cond = searchTools.getCombofldCond(cmbSemat, CompanyEntity.FIELD_SEMAT, "");
            else if (_searchPanels[3].Visible)
                cond = searchTools.getStringFldCond(CompanyEntity.FIELD_TEL, txtTel.Text, "");
            else if (_searchPanels[4].Visible)
                cond = searchTools.getStringFldCond(CompanyEntity.FIELD_FAX, txtFax.Text, "");
            else if (_searchPanels[5].Visible)
                cond = searchTools.getStringFldCond(CompanyEntity.FIELD_ADDRESS, txtAddress.Text, "");
            else if (_searchPanels[6].Visible)
                cond = searchTools.getStringFldCond(CompanyEntity.FIELD_DESCRIPTION, txtDescription.Text, "");
            fillGrid(cond);

        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                btnSearch_Click(null, null);
        }

        private void txtChoise_Click(object sender, EventArgs e)
        {
            DataGridView gv = dataGridView1;
            if (gv.SelectedCells.Count > 0 && gv.SelectedCells[0].ColumnIndex >= 0) {
                _id = int.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells[CompanyEntity.FIELD_ID].Value.ToString());
                this.Close();
            }
            else
                MessageBox.Show("لطفا یکی را انتخاب کنید");
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
                    if (id > 0)
                    {
                        DialogResult dres = MessageBox.Show("آیا مایلید حذف کنید ؟", "", MessageBoxButtons.YesNo);
                        if (dres.Equals(DialogResult.Yes))
                        {
                            _companyBL.delete(id);
                            fillGrid();
                        }
                    }
                }
            }

        }
        }
    }

