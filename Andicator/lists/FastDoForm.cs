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
using System.Collections;
using Andicator.controls;
using AndicatorCommon;

namespace Andicator.lists
{
    public partial class FastDoForm : Form
    {
        private GridTools _gridTools = new GridTools();
        private LetterBL _letterBL = new LetterBL();
        private int _userid = 0;

        public FastDoForm(int userid)
        {
            _userid = userid;
            InitializeComponent();
            fillLists();
        }

        private void fillLists()
        {
            string colorField = "COLOR";
            LetterEntity entity = _letterBL.getFastActions(_userid, true);
            
            entity = util.Util.filterChainedLetters(entity);

            bindToGrid(entity, gridCurLetterAll, colorField);

        }

        private void bindToGrid(RMX_TOOLS.common.AbstractCommonData entity, DataGridView grid, String colorfield)
        {
            System.Collections.Hashtable hash = new Hashtable();
            hash.Add("colorField", colorfield);
            //entity.Tables[1].TableName = "filledviwe";
            entity.FilledTableName = entity.Tables[1].TableName;

            _gridTools.bindDataToGrid(grid, entity, new GridTools.changingRow(_gridTools.changeColor), hash);
        }

        private void gridCurLetterAll_DoubleClick(object sender, EventArgs e)
        {
            showLetter(sender, "");
        }

        private void showLetter(object sender, string index)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.SelectedCells.Count > 0)
            {
                DataGridViewColumn col = gv.Columns[gv.SelectedCells[0].ColumnIndex];

                if (col.DataGridView.SelectedCells.Count > 0 && gv.SelectedCells[0].Selected)
                {
                    DataGridViewRow dr = gv.SelectedCells[0].OwningRow;
                    int id = -1;
                    id = int.Parse(dr.Cells[LetterEntity.FIELD_ID + index].Value.ToString());
                    int letterType = int.Parse(dr.Cells[LetterEntity.FIELD_LETTER_TYPE + index].Value.ToString());
                    LetterForm form = new LetterForm(letterType);
                    form.LetterId = id;
                    //form.readOnly = true;
                    form.initLetter();
                    form.ShowDialog();
                }
            }
        }

        private void FastDoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }
    }
}
