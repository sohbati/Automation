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
using AndicatorBLL;

namespace Andicator.lists
{
    public partial class AttachmentChequeList : Form
    {
        private AttachmentChequeBL _attachmentChequeBl;
        private GridTools _gridTools;
        private int _chequeId;

        public AttachmentChequeList(int cheqieId)
        {
            _chequeId = cheqieId;

            _gridTools = new GridTools();
            _attachmentChequeBl = new AttachmentChequeBL();

            InitializeComponent();

            fillGrid();
        }

        private void AttachmentChequeList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void fillGrid()
        {
            AttachmentChequeEntity entity = null;
            entity = _attachmentChequeBl.get(_chequeId);

            System.Collections.Hashtable hash = new Hashtable();
            _gridTools.bindDataToGrid(dataGridView1, entity, null, hash);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AttachmentChequeForm form = new AttachmentChequeForm(-1, _chequeId);
            form.ShowDialog();
            fillGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                int id = int.Parse(dr.Cells[AttachmentChequeEntity.FIELD_ID].Value.ToString());
                AttachmentChequeForm form = new AttachmentChequeForm(id, _chequeId);
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
            id = int.Parse(dr.Cells[AttachmentChequeEntity.FIELD_ID].Value.ToString());
            AttachmentChequeForm form = new AttachmentChequeForm(id, _chequeId);

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
                    id = int.Parse(dr.Cells[LetterEntity.FIELD_ID].Value.ToString());
                    if (id > 0)
                    {
                        DialogResult dres = MessageBox.Show("آیا مایلید حذف کنید ؟", "", MessageBoxButtons.YesNo);
                        if (dres.Equals(DialogResult.Yes))
                        {
                            _attachmentChequeBl.delete(id);
                            fillGrid();
                        }
                    }
                }
            }
        }

        private void AttachmentChequeList_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }
    }
}
