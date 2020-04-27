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
using RMX_TOOLS.converter;
using RMX_TOOLS.hasti.tools;

namespace Andicator.controls
{
    public partial class ReferenceCycleForm : Form
    {
        private int _id;
        ReferenceCycleBL _refCycleBL = new ReferenceCycleBL();
        ReferenceCycleEntity _entity = null;
        public ReferenceCycleForm(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void init()
        {
            if (_id <= 0)
                return;


           _entity = _refCycleBL.get(_id);

            txtLetterNumber.Text = _entity.get(ReferenceCycleEntity.FIELD_LETTERID + "_DESC").ToString();
            txtFirstRefDate.Text = _entity.get(ReferenceCycleEntity.FIELD_FIRSTREFERDATE + "").ToString();

            DateConverter converter = new DateConverter();

            txtFirstRefDate.Text = converter.valueToString(_entity.get(ReferenceCycleEntity.FIELD_FIRSTREFERDATE));
            txtSecondRefDate.Text = converter.valueToString(_entity.get(ReferenceCycleEntity.FIELD_SECONDREFERDATE));

            txtFirstRefFromUser.Text = _entity.get(ReferenceCycleEntity.FIELD_FIRSTFROMUSER + "_DESC").ToString();
            txtFirstRefToUser.Text = _entity.get(ReferenceCycleEntity.FIELD_FIRSTTOUSER + "_DESC").ToString();

            txtSecondRefFromUser.Text = _entity.get(ReferenceCycleEntity.FIELD_SECONDFROMUSER + "_DESC").ToString();
            txtSecondRefToUser.Text = _entity.get(ReferenceCycleEntity.FIELD_SECONDTOUSER + "_DESC").ToString();

            int action = 0;
            if (_entity.get(ReferenceCycleEntity.FIELD_ACTION).ToString().Length > 0)
                action = int.Parse(_entity.get(ReferenceCycleEntity.FIELD_ACTION).ToString());
            BasicInfoUtil.fillComboBox(cmbAction, "ReferenceCycleAction", action);

            txtActionDesc.Text = _entity.get(ReferenceCycleEntity.FIELD_ACTIONDESCRIPTION).ToString();

            bool archive = false;
            string a = _entity.get(ReferenceCycleEntity.FIELD_ARCHIVE).ToString();
            if (a == null || a.Length == 0)
                archive = false;
            else
                archive = bool.Parse(a);
            cbArchive.Checked = archive;
        }

        private void ReferenceCycleForm_Load(object sender, EventArgs e)
        {
            init();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ReferenceCycleEntity entity = new ReferenceCycleEntity();
            DataRow dr = entity.Tables[entity.TableName].NewRow();

            if (_id < 0)
                return;

            dr[ChequeEntity.FIELD_ID] = _id;
            dr[ReferenceCycleEntity.FIELD_LETTERID] = _entity.get(ReferenceCycleEntity.FIELD_LETTERID);
            
            dr[ReferenceCycleEntity.FIELD_FIRSTREFERDATE] = _entity.get(ReferenceCycleEntity.FIELD_FIRSTREFERDATE);
            dr[ReferenceCycleEntity.FIELD_FIRSTFROMUSER] = _entity.get(ReferenceCycleEntity.FIELD_FIRSTFROMUSER);
            dr[ReferenceCycleEntity.FIELD_FIRSTTOUSER] = _entity.get(ReferenceCycleEntity.FIELD_FIRSTTOUSER);

            dr[ReferenceCycleEntity.FIELD_SECONDREFERDATE] = _entity.get(ReferenceCycleEntity.FIELD_SECONDREFERDATE);
            dr[ReferenceCycleEntity.FIELD_SECONDFROMUSER] = _entity.get(ReferenceCycleEntity.FIELD_SECONDFROMUSER);
            dr[ReferenceCycleEntity.FIELD_SECONDTOUSER] = _entity.get(ReferenceCycleEntity.FIELD_SECONDTOUSER);

            dr[ReferenceCycleEntity.FIELD_ACTION] = ((ComboBoxItem)cmbAction.Items[cmbAction.SelectedIndex]).Value;
            dr[ReferenceCycleEntity.FIELD_ACTIONDESCRIPTION] = txtActionDesc.Text;
            dr[ReferenceCycleEntity.FIELD_ARCHIVE] = cbArchive.Checked;

            entity.Tables[entity.TableName].Rows.Add(dr);

            _refCycleBL.update(entity);

            this.Close();
        }

        private void ReferenceCycleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void btnLetter_Click(object sender, EventArgs e)
        {
            LetterBL letterBl = new LetterBL();
            LetterEntity letterEntity = letterBl.getByLetterNumber(txtLetterNumber.Text);


            LetterForm form = new LetterForm();
            form.LetterType =int.Parse(letterEntity.get(LetterEntity.FIELD_LETTER_TYPE).ToString());
            form.LetterId = (int) letterEntity.get(LetterEntity.FIELD_ID);
            form.readOnly = true;
            form.initLetter();
            form.ShowDialog();
        }
    }
}
