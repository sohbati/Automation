using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMX_TOOLS.data.grid;
using AndicatorCommon;
using System.Collections;
using Andicator.controls;
using AndicatorBLL;

namespace Andicator.lists
{
    public partial class LetterPatternDesignList : Form
    {
        private LetterNumberPatternBL _letterNumberPatternBL;
        
        private GridTools _gridTools;

        public LetterPatternDesignList()
        {
            _gridTools = new GridTools();

            InitializeComponent();

            _letterNumberPatternBL = new LetterNumberPatternBL();
        }

        public void initList()
        {
            fillGrid();
        }

        private void fillGrid()
        {
            LetterNumberPatternEntity entity = null;
            entity = _letterNumberPatternBL.get();

            System.Collections.Hashtable hash = new Hashtable();
            _gridTools.bindDataToGrid(dataGridView1, entity, null, hash);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LetterPatternDesignList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LetterNumberPatternDesign form = new LetterNumberPatternDesign(-1);
            form.ShowDialog();
            fillGrid();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                int id = int.Parse(dr.Cells[LetterNumberPatternEntity.FIELD_ID].Value.ToString());
                LetterNumberPatternDesign form = new LetterNumberPatternDesign(id);
                form.ShowDialog();
                fillGrid();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.SelectedRows.Count <= 0)
                return;

            DataGridViewRow dr = gv.SelectedRows[0];
            int id = -1;
            id = int.Parse(dr.Cells[LetterNumberPatternEntity.FIELD_ID].Value.ToString());
            
            LetterNumberPatternDesign form = new LetterNumberPatternDesign(id);

            form.ShowDialog();
            fillGrid();
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
                    id = int.Parse(dr.Cells[LetterNumberPatternEntity.FIELD_ID].Value.ToString());

                    DialogResult dres = MessageBox.Show("آیا مایلید حذف کنید ؟", "", MessageBoxButtons.YesNo);
                    if (dres.Equals(DialogResult.Yes))
                    {
                        _letterNumberPatternBL.delete(id);
                        fillGrid();
                    }
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.SelectedCells.Count > 0)
            {
                DataGridViewColumn col = gv.Columns[4];
                string pName = col.DataPropertyName;
                DataGridViewRow dr = gv.SelectedCells[0].OwningRow;
                object canset = dr.Cells[LetterNumberPatternEntity.FIELD_CANSET].Value;
                if (canset != null && false.Equals(canset))
                {
                    btnDelete.Enabled = false;
                    //btnDisplay.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                  //  btnDisplay.Enabled = true;
                }
                
            }
        }
    }
}
