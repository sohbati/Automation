using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMX_TOOLS.hasti.bll;
using RMX_TOOLS.global;
using AndicatorCommon;
using AndicatorBLL;
using System.Collections;
using Andicator.controls;

namespace Andicator.lists
{
    public partial class LetterRefferToUsersStatistics2 : Form
    {
        LetterBL _letterBL = new LetterBL();
        ReferLetterBL _referLetterBL = new ReferLetterBL();
        UsersBS _usersBL = new UsersBS();
 
        public LetterRefferToUsersStatistics2()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            ApplicationPropertiesBL appPropertiesBL = new ApplicationPropertiesBL();
            txtReferLimit.Text = appPropertiesBL.getValue(ApplicationPropertiesBL.REFERENCE_COUNT);
            
            txtToDate.Text = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.Now);
            DateTime dt = DateTime.Now;
            dt = dt.AddMonths(-1);
            txtFromDate.Text = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(dt);
        }

        private void LetterRefferToUsersStatistics2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            bool b = FormChecker.CheckDate(txtFromDate, lblFromDate);
            b &= FormChecker.CheckDate(txtToDate, lblToDate);
            int count = 0;
            try
            {
                count = int.Parse(txtReferLimit.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("عدد وارد شده صحیح نیست");
                return;
            }
            if (!b)
            {
                MessageBox.Show("خطا در تاریخ های وارده شده");
                return;
            }
            try
            {
                while (dataGridView1.Rows.Count > 0)
                    dataGridView1.Rows.RemoveAt(0);
            }
            catch (Exception ex) { }

            DateTime dateFrom = RMX_TOOLS.date.DateXFormer.persianToGreGorian(txtFromDate.Text);
            DateTime dateTo = RMX_TOOLS.date.DateXFormer.persianToGreGorian(txtToDate.Text);
            
            ReferCountLetterEntity en = _referLetterBL.getReferCount(count, dateFrom, dateTo);
            
            ArrayList list = getLetterWithReffereds(en);
            int currentRowIndex = 0;
            for (int i = 0; i < list.Count; i++)
            {
                currentRowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[currentRowIndex].Cells[0].Value = ((ArrayList)list[i])[0];
                dataGridView1.Rows[currentRowIndex].Cells[1].Value = ((ArrayList)list[i])[1];
                dataGridView1.Rows[currentRowIndex].Cells[2].Value = ((ArrayList)list[i])[2];
                dataGridView1.Rows[currentRowIndex].Cells[3].Value = ((ArrayList)list[i])[3];
                dataGridView1.Rows[currentRowIndex].Cells[4].Value = ((ArrayList)list[i])[4];
            }
            
        }

        private ArrayList getLetterWithReffereds(ReferCountLetterEntity entity)
        {
            ArrayList row = null;
            ArrayList list = new ArrayList();

            LetterEntity letterEntity = null;
            
            for (int i = 0; i < entity.RowCount(); i++)
            {
                row = new ArrayList();
                int letterId = int.Parse(entity.get(i,ReferCountLetterEntity.FIELD_LETTER_ID).ToString());
                letterEntity = _letterBL.getByLetterId(letterId);

                row.Add(i + 1 + "");
                row.Add(RMX_TOOLS.date.DateXFormer.gregorianToPersianString((DateTime)
                    entity.get(i,ReferCountLetterEntity.FIEL_LETTERDATE)));
                row.Add(entity.get(i, ReferCountLetterEntity.FIEL_LETTERSUBJECT).ToString());
                row.Add(getUsers(letterId));
                row.Add(letterId);

                list.Add(row);
            }
            return list;
        }

        private string getUsers(int letterid) 
        {
            string retStr = "";
            ReferLetterEntity refLetterEntity = _referLetterBL.get(letterid);
            if (refLetterEntity.RowCount() <= 0)
            {
                return "";
            }

            string fromName = "";
            string toName = "";
            string date = "";

            UsersEntity usersEntity = null;
            for (int i = 0; i < refLetterEntity.RowCount(); i++)
            {
                date = RMX_TOOLS.date.DateXFormer.gregorianToPersianString((DateTime)
                    refLetterEntity.get(i, ReferLetterEntity.FIELD_REFER_DATE));

                
                if (refLetterEntity.get(i,  ReferLetterEntity.FIELD_REFER_FROM_USER).ToString().Length > 0) 
                {
                    int id = int.Parse(refLetterEntity.get(i,  ReferLetterEntity.FIELD_REFER_FROM_USER).ToString());
                    usersEntity = _usersBL.get(id);
                    fromName = usersEntity.ToString();
                }
                if (refLetterEntity.get(i, ReferLetterEntity.FIELD_REFER_TO_USER).ToString().Length > 0)
                {
                    int id = int.Parse(refLetterEntity.get(i, ReferLetterEntity.FIELD_REFER_TO_USER).ToString());
                    usersEntity = _usersBL.get(id);
                    toName = usersEntity.ToString();
                }

                retStr += "[" + (i + 1) + "-" + date + " " + " از " + fromName + " به " + toName + "]";
            }
            return retStr;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
                return;
            int letterid = (int)(dataGridView1.SelectedRows[0].Cells[4].Value);
            
            LetterEntity entity = _letterBL.getByLetterId(letterid);

            int letterType = int.Parse(entity.get(LetterEntity.FIELD_LETTER_TYPE).ToString());
            LetterForm form = new LetterForm(letterType);
            form.LetterId = letterid;
            form.LetterEntity = entity;
            form.initLetter();
            form.ShowDialog();
            //if (form.DataChanged)
            //    FillGrids();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LetterRefferToUsersStatistics2_Load(object sender, EventArgs e)
        {

        }
    }
}
