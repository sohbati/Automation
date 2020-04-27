using System;
using System.Windows.Forms;
using AndicatorCommon;
using RMX_TOOLS.data.grid;
using System.Collections;
using AndicatorBLL;
using Andicator.controls.tools;
using Andicator.controls;

namespace Andicator.lists
{
    public partial class LetterGroupSelect: Form
    {
        private LetterGroupBL _letterGroupBL;
        private LetterBL _letterBL = new LetterBL();
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

        private int _id = -1;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        public LetterGroupSelect()
        {
            _gridTools = new GridTools();

            InitializeComponent();

            _letterGroupBL = new LetterGroupBL();
        }

        public void initList()
        {
            fillGrid();
            initSearch();

            _gridTools.selectRow(dataGridView1, LetterGroupEntity.FIELD_ID, _id);
            tabControl1.SelectTab(1);
        }
        private void initSearch()
        {
            _searchFields = new string[2];
            _searchPanels = new Panel[2];

            _searchFields[0] = LetterGroupEntity.FIELD_GROUPTITLE;
            _searchFields[1] = LetterGroupEntity.FIELD_LETTERNUMBERS;

            _searchPanels[00] = pnlGroupTitle;
            _searchPanels[01] = pnlLetterNumbers;

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
            LetterGroupEntity entity = null;
            if (UnselectIds != null && UnselectIds.Length > 0)
            {
                if (cond.Length > 0)
                    cond += " AND ";
                cond += LetterGroupEntity.FIELD_ID + " not in(" + UnselectIds + ")";
            }
            
             
            entity = _letterGroupBL.get(cond);

            System.Collections.Hashtable hash = new Hashtable();
            _gridTools.bindDataToGrid(dataGridView1, entity, null, hash);
        }

        private void UserList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                _id = -1;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _id = -1;
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchTools searchTools = new SearchTools();
            string cond = "";

            if (_searchPanels[0].Visible)
                cond = searchTools.getStringFldCond(LetterGroupEntity.FIELD_GROUPTITLE, txtGroupTitle.Text, "");
            else if (_searchPanels[1].Visible)
                cond = searchTools.getStringFldCond(LetterGroupEntity.FIELD_LETTERNUMBERS, txtLetterNumbers.Text, "");
            
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
                _id = int.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells[LetterGroupEntity.FIELD_ID].Value.ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            _id = -1;
            this.Close();
        }

        private void btnSelectNewGroup_Click(object sender, EventArgs e)
        {
            if (txtNewGroupTitle.Text != null && txtNewGroupTitle.Text.Trim().Length > 0)
            {
                LetterGroupEntity entity = new LetterGroupEntity();
                System.Data.DataRow dataRow = entity.Tables[entity.TableName].NewRow();
                
                dataRow[LetterGroupEntity.FIELD_GROUPTITLE] = txtNewGroupTitle.Text;
                
                entity.Tables[entity.TableName].Rows.Add(dataRow);
                int id = _letterGroupBL.add(entity);
                _id = id;
                this.Close();
            }
            
        }
    }
}
