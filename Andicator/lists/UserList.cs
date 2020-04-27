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
    public partial class UserList : Form
    {
        private UsersBS _usersBS;
        private GridTools _gridTools;

        private Panel[] _searchPanels;
        private string[] _searchFields;

        #region properties
        private bool _showAdminUsers = true;

        public bool ShowAdminUsers
        {
            get { return _showAdminUsers; }
            set { _showAdminUsers = value; }
        }

        private string _unselectIds = null;

        public string UnselectIds
        {
            get { return _unselectIds; }
            set { _unselectIds = value; }
        }
        private string _userName = "";

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private int _id = -1;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        public UserList()
        {
            _gridTools = new GridTools();

            InitializeComponent();

            _usersBS = new UsersBS();
        }

        public void initList()
        {
            fillGrid();
            initSearch();

            _gridTools.selectRow(dataGridView1, UsersEntity.FIELD_ID, _id);
        }
        private void initSearch()
        {
            _searchFields = new string[4];
            _searchPanels = new Panel[4];

            _searchFields[0] = UsersEntity.FIELD_NAME;
            _searchFields[1] = UsersEntity.FIELD_FAMILY;
            _searchFields[2] = UsersEntity.FIELD_USERNAME;
            _searchFields[3] = UsersEntity.VIEW_FIELD_USERTYPE_DESC;

            _searchPanels[00] = pnlName;
            _searchPanels[01] = pnlFamily;
            _searchPanels[02] = pnlUserName;
            _searchPanels[03] = pnlUserType;

            selectSearchPanel(0);

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

        private void fillGrid()
        {
            fillGrid("");
        }

        private void fillGrid(string cond)
        {
            UsersEntity entity = null;
            if (cond.Length > 0)
                cond += " AND ";
            if (UnselectIds != null && UnselectIds.Length > 0)
                cond += UsersEntity.FIELD_ID +  " not in(" + UnselectIds + ")";
            if (!_showAdminUsers)
            {
                if (cond.Length > 0)
                    cond += " AND ";
                cond += UsersEntity.FIELD_USER_TYPE + "<>" + UsersBS.ADMIN;
            }
            if (cond.Length > 0)
                cond += "and";
            cond += " ACTIVE=1";
            entity = _usersBS.get(cond);

            System.Collections.Hashtable hash = new Hashtable();
            _gridTools.bindDataToGrid(dataGridView1, entity, null, hash);
        }

        private void UserList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                _id = -1;
                _userName = "";
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _id = -1;
            _userName = "";
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchTools searchTools = new SearchTools();
            string cond = "";

            if (_searchPanels[0].Visible)
                cond = searchTools.getStringFldCond(UsersEntity.FIELD_NAME, txtName.Text, "");
            else if (_searchPanels[1].Visible)
                cond = searchTools.getStringFldCond(UsersEntity.FIELD_FAMILY, txtFamily.Text, "");
            else if (_searchPanels[2].Visible)
                cond = searchTools.getStringFldCond(UsersEntity.FIELD_USERNAME, txtUserName.Text, "");
            else if (_searchPanels[3].Visible)
                cond = getCombofldCond(cmbUserType, UsersEntity.FIELD_USER_TYPE, "");
            
            fillGrid(cond);
        }

        public string getCombofldCond(ComboBox cmb, string fldName, string cond)
        {
            if (cmb.SelectedIndex >= 0)
            {
                int value = cmb.SelectedIndex + 1;
                if (cond.Length > 0)
                    cond += " AND ";
                return cond + fldName + "=" + value;
            }
            return cond;
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

        private void SearchItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                btnSearch_Click(null, null);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DataGridView gv = dataGridView1;
            if (gv.SelectedCells.Count > 0 && gv.SelectedCells[0].ColumnIndex >= 0)
            {
                _id = int.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells[UsersEntity.FIELD_ID].Value.ToString());
                _userName = dataGridView1.SelectedCells[0].OwningRow.Cells[UsersEntity.FIELD_NAME].Value.ToString() +
                    dataGridView1.SelectedCells[0].OwningRow.Cells[UsersEntity.FIELD_FAMILY].Value.ToString() + "(" +
                    dataGridView1.SelectedCells[0].OwningRow.Cells[UsersEntity.FIELD_USERNAME].Value.ToString() + ")";
                this.Close();
            }
            else
                MessageBox.Show("لطفا یکی را انتخاب کنید");

        }

        private void UserList_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }


    }
}
