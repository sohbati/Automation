using System;
using System.Windows.Forms;
using AndicatorCommon;
using RMX_TOOLS.data.grid;
using System.Collections;
using AndicatorBLL;

namespace Andicator.lists
{
    public partial class LetterGroupList: Form
    {
        private LetterBL _letterBL;
        private LetterGroupBL _letterGroupBL;
        private GridTools _gridTools;
        private int _groupId;


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
        public LetterGroupList()
        {
            _gridTools = new GridTools();

            InitializeComponent();

            _letterBL = new LetterBL();
            _letterGroupBL = new LetterGroupBL();

          
        }
        
        public void initList(int groupId)
        {
            _groupId = groupId;
            addTitle();
            fillGrid();
            new GridTools().selectRow(dataGridView1, LetterEntity.FIELD_ID, _id);
        }

        private void addTitle()
        {
            LetterGroupEntity letterGroupEntity =  _letterGroupBL.get(_groupId);
            string title = letterGroupEntity.get(LetterGroupEntity.FIELD_GROUPTITLE).ToString();
            txtTitle.Text = title;
        }

        private void fillGrid()
        {
            LetterEntity entity;
            entity = _letterBL.getByGroupId(_groupId);
            System.Collections.Hashtable hash = new Hashtable();
            _gridTools.bindDataToGrid(dataGridView1, entity, null, hash);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    //CompanyForm form = new CompanyForm(id, _readOnly);
                    //form.ShowDialog();
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
                    if (id > 0)
                    {
                        DialogResult dres = MessageBox.Show("آیا مایلید حذف کنید ؟", "", MessageBoxButtons.YesNo);
                        if (dres.Equals(DialogResult.Yes))
                        {
                            fillGrid();
                        }
                    }
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void LetterGroupList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Close();
                return;
            }
        }
    }
    }

