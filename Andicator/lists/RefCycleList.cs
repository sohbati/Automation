using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;
using AndicatorBLL;
using AndicatorCommon;
using System.Collections;
using RMX_TOOLS.data.grid;
using Andicator.controls.tools;
using Andicator.controls;

namespace Andicator.lists
{
    public partial class RefCycleList : Form
    {
        private ReferenceCycleBL _referenceCycleBl = new ReferenceCycleBL();
        private GridTools _gridTools = new GridTools();
        private SearchTools _searchTools = new SearchTools();


        public RefCycleList()
        {
            InitializeComponent();

        }

        public void init()
        {
            BasicInfoUtil.fillCheckBoxList(cbReferAction, "ReferenceCycleAction", -1);
            UsersBS.fillCheckedListWithUsers(cbRefferFrom, -1);
        }

        private void RefCycleList_Load(object sender, EventArgs e)
        {
            init();

            String defaultCond = "";
            defaultCond = "(" + ReferenceCycleEntity.FIELD_ARCHIVE + "=0" + " OR " + ReferenceCycleEntity.FIELD_ARCHIVE + " is null)";
            fillGrid(defaultCond);
        }

        private void fillGrid(string cond)
        {
            ReferenceCycleEntity entity = null;

            entity = _referenceCycleBl.get(cond);

            System.Collections.Hashtable hash = new Hashtable();
            _gridTools.bindDataToGrid(dataGridView1, entity, null, hash);
        }

        private void search()
        {
            cmbCompareDate.SelectedIndex = 5;
            string cond = "";
            cond = _searchTools.getStringFldCond(ReferenceCycleEntity.FIELD_LETTERID + "_DESC", txtLetterNumber.Text, cond);
            cond = _searchTools.getCheckBoxListCond(cbRefferFrom, ReferenceCycleEntity.FIELD_SECONDTOUSER, cond);
            cond = _searchTools.getDateFldCond(ReferenceCycleEntity.FIELD_SECONDREFERDATE,
                txtRefDateFrom.Text, txtRefDateTo.Text, cmbCompareDate, cond);
            cond = _searchTools.getCheckBoxListCond(cbReferAction, ReferenceCycleEntity.FIELD_ACTION, cond);
            cond = _searchTools.getStringFldCond(ReferenceCycleEntity.FIELD_ACTIONDESCRIPTION, txtAction.Text, cond);

            if (cond.Length > 0)
                cond += "and";
            if (cbArchived.Checked)

                cond += " " + ReferenceCycleEntity.FIELD_ARCHIVE + "=1";
            else
                cond += " (" + ReferenceCycleEntity.FIELD_ARCHIVE + "=0" + " OR " + ReferenceCycleEntity.FIELD_ARCHIVE + " is null)";

            ReferenceCycleEntity entity = null;
            entity = _referenceCycleBl.get(cond);

            System.Collections.Hashtable hash = new Hashtable();
            _gridTools.bindDataToGrid(dataGridView1, entity, null, hash);

        }

        private void RefCycleList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
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
                    ReferenceCycleForm form = new ReferenceCycleForm(id);
                    form.ShowDialog();
                    search();
                    //gv.scro

                }
            }
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
                    ReferenceCycleForm form = new ReferenceCycleForm(id);
                    form.ShowDialog();
                    search();
                }
            }

        }
    }
}
