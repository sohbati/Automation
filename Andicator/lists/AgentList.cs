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
    public partial class ReferenceCycleList : Form
    {
        private AgentBL _AgentBL;
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
        public ReferenceCycleList()
        {
            _gridTools = new GridTools();

            InitializeComponent();

            _AgentBL = new AgentBL();
            checkPerm();

            initList();
        }

        private void checkPerm()
        {
            //agent readonly 
            UserPropertiesEntity entity = UsersBS.LogginedUserProperties;
            UserpropertiesBL userProperties = new UserpropertiesBL();
            String v = userProperties.getValue(entity, UserpropertiesBL.MENU_AGENT_READ_ONLY_PERMISSION);
            if (v != null && bool.Parse(v))
            {
                _readOnly = true;
            }

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

            new GridTools().selectRow(dataGridView1, AgentEntity.FIELD_ID, _id);
        }

        private void initSearch()
        {
            _searchFields = new string[6];
            _searchPanels = new Panel[6];

            _searchFields[0] = AgentEntity.FIELD_Agent_NAME;
            _searchFields[1] = AgentEntity.FIELD_AGENTCODE;
            _searchFields[2] = AgentEntity.FIELD_TELEPHONE;
            _searchFields[3] = AgentEntity.FIELD_MOBILE;
            _searchFields[4] = AgentEntity.FIELD_FAX;
            _searchFields[5] = AgentEntity.FIELD_ADDRESS;

            _searchPanels[00] = pnlAgentName;
            _searchPanels[01] = pnlAgentcode;
            _searchPanels[02] = pnlTelephone;
            _searchPanels[03] = pnlMobile;
            _searchPanels[04] = pnlFax;
            _searchPanels[05] = pnlAddress;

            selectSearchPanel(0);

        }
        private void fillGrid()
        {
            fillGrid("");
        }

        private void fillGrid(string cond)
        {
            AgentEntity entity = null;
            if (_readOnly)
                entity = _AgentBL.getOnlyActives(cond);
            else
                entity = _AgentBL.get(cond);

            System.Collections.Hashtable hash = new Hashtable();
            _gridTools.bindDataToGrid(dataGridView1, entity, null, hash);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgentList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AgentForm form = new AgentForm(-1);
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
                    id = int.Parse(dr.Cells[AgentEntity.FIELD_ID].Value.ToString());
                    AgentForm form = new AgentForm(id, _readOnly);
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
                    id = int.Parse(dr.Cells[AgentEntity.FIELD_ID].Value.ToString());
                    AgentForm form = new AgentForm(id, _readOnly);
                    form.ShowDialog();
                    fillGrid();
                    //gv.scro
                    
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
                cond = searchTools.getStringFldCond(AgentEntity.FIELD_Agent_NAME, txtAgentName.Text, "");
            else if (_searchPanels[1].Visible)
                cond = searchTools.getStringFldCond(AgentEntity.FIELD_AGENTCODE, txtAgentCode.Text, "");
            else if (_searchPanels[2].Visible)
                cond = searchTools.getStringFldCond(AgentEntity.FIELD_TELEPHONE, txtTelephone.Text, "");
            else if (_searchPanels[3].Visible)
                cond = searchTools.getStringFldCond(AgentEntity.FIELD_MOBILE, txtMobile.Text, "");
            else if (_searchPanels[4].Visible)
                cond = searchTools.getStringFldCond(AgentEntity.FIELD_FAX, txtFax.Text, "");
            else if (_searchPanels[5].Visible)
                cond = searchTools.getStringFldCond(AgentEntity.FIELD_ADDRESS, txtAddress.Text, "");
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
            if (gv.SelectedCells.Count > 0 && gv.SelectedCells[0].ColumnIndex >= 0)
            {
                _id = int.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells[AgentEntity.FIELD_ID].Value.ToString());
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
                            _AgentBL.delete(id);
                            fillGrid();
                        }
                    }
                }
            }

        }
    }
}

