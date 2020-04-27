using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMX_TOOLS.data.grid;
using AndicatorBLL;
using Andicator.controls.tools;
using AndicatorCommon;
using System.Collections;
using Andicator.controls;

namespace Andicator.lists
{
    public partial class LetterAnswerCountList : Form
    {
        private LetterReplyCountBL _replyCountBl = new LetterReplyCountBL();
        private GridTools _gridTools = new GridTools();
        private SearchTools _searchTools = new SearchTools();

        public LetterAnswerCountList()
        {
            InitializeComponent();
            cmbCompare.SelectedIndex = 4;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string cond = "";
            cond = _searchTools.getNumberFldCond(LetterReplyCountViewEntity.FIELD_REPLYCOUNT, 
                txtAnswerCount.Text, txtAnswerCount.Text, cmbCompare, cond);
            if (cond.Length > 0)
                cond += " AND ";
            if (cbArchive.Checked)

                cond += "  " + LetterReplyCountViewEntity.FIELD_ARCHIVE + "=1";
            else
                cond += " (" + LetterReplyCountViewEntity.FIELD_ARCHIVE + "=0" + " OR " + LetterReplyCountViewEntity.FIELD_ARCHIVE + " is null)";


            LetterReplyCountViewEntity entity = null;
            entity = _replyCountBl.get(cond);

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
                    if (dr.Cells[LetterEntity.FIELD_ID] == null || dr.Cells[LetterEntity.FIELD_ID].Value == null)
                        return;
                    id = int.Parse(dr.Cells[LetterEntity.FIELD_ID].Value.ToString());


                    LetterForm form = new LetterForm();
                    form.LetterId = id;
                    form.initLetter();
                    form.ShowDialog();
                         
                            
                    
                    

                }
            }
        }
    }
}
