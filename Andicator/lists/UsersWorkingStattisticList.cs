using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorCommon;
using AndicatorBLL;
using RMX_TOOLS.data.grid;
using System.Collections;

namespace Andicator.lists
{
    public partial class UsersWorkingStattisticList : Form
    {
        WorkingStatisticBL _workingStatisticBL;
        private GridTools _gridTools;
        
        public UsersWorkingStattisticList()
        {
            InitializeComponent();
            _gridTools = new GridTools();
            _workingStatisticBL = new WorkingStatisticBL();
        }

        private void UsersWorkingStattisticList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fillGrid();
        }
        
        public void fillGrid()
        {
            WorkingStatisticEntity entity = null;
            entity = _workingStatisticBL.get();

            System.Collections.Hashtable hash = new Hashtable();
            entity.Tables[1].TableName = "filledviwe";
            entity.FilledTableName = entity.Tables[1].TableName;

            _gridTools.bindDataToGrid(dataGridView1, entity, null, hash);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void btnLetterReffers_Click(object sender, EventArgs e)
        {
            LetterRefferToUsersStatistics2 stat = new LetterRefferToUsersStatistics2();
            stat.ShowDialog();
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
                    id = int.Parse(dr.Cells[WorkingStatisticEntity.VIEW_FIELD_USER_ID].Value.ToString());
                    if (gv.SelectedCells[0].ColumnIndex > 0)
                    {
                        StatisticSimpleListForm form = new StatisticSimpleListForm(id, gv.SelectedCells[0].ColumnIndex);
                        form.ShowDialog();
                    }
                    
                }
            }
        }

    }
}
