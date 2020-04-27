using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AndicatorBLL;
using AndicatorCommon;
using RMX_TOOLS.hasti.tools;
using RMX_TOOLS.data.grid;
using System.Collections;
using Andicator.controls;

namespace Andicator.lists
{
    public partial class StatisticSimpleListForm : Form
    {
        private int _userid = -1;
        private GridTools _gridTools = new GridTools();
        private WorkingStatisticQueries _wsq = new WorkingStatisticQueries();

        public StatisticSimpleListForm()
        {
            InitializeComponent();
        }
        
        public StatisticSimpleListForm(int userid, int collindex)
        {
            if (collindex <= 0)
                return;
            _userid = userid;
            InitializeComponent();
            fillUserRefferenceCombo(_userid);
            fillLists();

            //
            collindex -= 2;
            ta12.SelectedTab = ta12.TabPages[collindex];
            ta12.TabPages[collindex].Select();
            ta12.TabPages[collindex].Show();
        }

        private void fillLists() 
        {
            string colorField = "COLOR";
            bindToGrid(_wsq.getCurLetterAll(_userid), gridCurLetterAll, colorField);
            bindToGrid(_wsq.getCurLetterMarked(_userid), gridCurLetterMarked, colorField + "_1");
            bindToGrid(_wsq.getgridRateDecAll(_userid), gridRateDecAll, colorField + "_3");
            bindToGrid(_wsq.getgridRateDecMarked(_userid), gridRateDecMarked, colorField + "_4");
            bindToGrid(_wsq.getgridRateDecOralAll(_userid), gridRateDecOralAll, colorField + "_5");
            bindToGrid(_wsq.getgridRateDecOralMarked(_userid), gridRateDecOralMarked, colorField + "_6");
            bindToGrid(_wsq.getGridChequeHasRemainder(_userid), gridHasChequeRemainder, colorField + "_7");
            bindToGrid(_wsq.getGridChequeWithoutAnswer(_userid), gridChequeWithoutAnswer, colorField + "_8");

        }

        private void bindToGrid(RMX_TOOLS.common.AbstractCommonData entity, DataGridView grid, String colorfield)
        {
            System.Collections.Hashtable hash = new Hashtable();
            hash.Add("colorField", colorfield);
            //entity.Tables[1].TableName = "filledviwe";
            entity.FilledTableName = entity.Tables[1].TableName;

            _gridTools.bindDataToGrid(grid, entity, new GridTools.changingRow(_gridTools.changeColor), hash);
        }

        private void fillUserRefferenceCombo(int defaultValue)
        {
            UserTreeBL userTreeBL = new UserTreeBL();
            int loggineduserid = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
            UserTreeEntity entity = userTreeBL.get();
            cmbReferenceUserId.DataSource = null;
            cmbReferenceUserId.Items.Clear();

            var dataSource = new List<ComboBoxItem>();
            //BasicInfoUtil.AddUnKnown(dataSource);
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                string name = entity.get(i, UserTreeEntity.VIEW_FIELD_USER_NAME).ToString();
                string treeid = entity.get(i, UserTreeEntity.FIELD_ID).ToString();
                string userid = entity.get(i, UserTreeEntity.FIELD_USER_ID).ToString();
                dataSource.Add(new ComboBoxItem(name, treeid, userid));
            }

            cmbReferenceUserId.DataSource = dataSource;
            cmbReferenceUserId.DisplayMember = "Text";
            cmbReferenceUserId.ValueMember = "Value";
            for (int i = 0; i < cmbReferenceUserId.Items.Count; i++)
            {
                string c = ((ComboBoxItem)cmbReferenceUserId.Items[i]).CustomData;
                if (c != null && c.Equals(defaultValue.ToString()))
                {
                    cmbReferenceUserId.SelectedIndex = i;
                    break;
                }
            }

        }

        private void StatisticSimpleListForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();

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

        private void showCheque(object sender, string index)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.SelectedCells.Count > 0)
            {
                DataGridViewColumn col = gv.Columns[gv.SelectedCells[0].ColumnIndex];

                if (col.DataGridView.SelectedCells.Count > 0 && gv.SelectedCells[0].Selected)
                {
                    DataGridViewRow dr = gv.SelectedCells[0].OwningRow;
                    int id = -1;
                    id = int.Parse(dr.Cells[ChequeEntity.FIELD_ID + index].Value.ToString());
                    
                    ChequeForm form = new ChequeForm(id);
                    
                    form.readOnly = true;
                    form.initForm();
                    form.ShowDialog();
                }
            }
        }
        private void cmbReferenceUserId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)cmbReferenceUserId.SelectedItem;
            int userid = int.Parse(item.CustomData);
            _userid = userid;
            fillLists();
        }

        private void gridCurLetterAll_DoubleClick(object sender, EventArgs e)
        {
            showLetter(sender, "");
        }

        private void gridCurLetterMarked_DoubleClick(object sender, EventArgs e)
        {
            showLetter(sender, "_1");
        }

        private void gridRateDecAll_DoubleClick(object sender, EventArgs e)
        {
            showLetter(sender, "_3");
        }

        private void gridRateDecMarked_DoubleClick(object sender, EventArgs e)
        {
            showLetter(sender, "_4");
        }

        private void gridRateDecOralAll_DoubleClick(object sender, EventArgs e)
        {
            showLetter(sender, "_5");
        }

        private void gridRateDecOralMarked_DoubleClick(object sender, EventArgs e)
        {
            showLetter(sender, "_6");
        }

        private void gridHasChequeRemainder_DoubleClick(object sender, EventArgs e)
        {
            showCheque(sender, "_7");
        }

        private void gridChequeWithoutAnswer_DoubleClick(object sender, EventArgs e)
        {
            showCheque(sender, "_8");
        }

    }
}
