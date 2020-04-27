using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorBLL;
using RMX_TOOLS.hasti.tools;
using AndicatorCommon;
using Andicator.controls.tools;
using Andicator.lists;
using Andicator.hasti.basicInfo;

namespace Andicator.controls
{
    public partial class AdvanceSearchForm : Form
    {
        #region properties
        private string resultCondition = "";

        public string ResultCondition
        {
            get { return resultCondition; }
            set { resultCondition = value; }
        }
        #endregion

        private int _letterType = -1;
        private SearchTools _searchTools;
        public AdvanceSearchForm(int letterType)
        {
            _letterType = letterType;
            _searchTools = new SearchTools();

            InitializeComponent();
        }

        public void init()
        {
            if (LetterBL.LETTER_TYPE_SEND.Equals(_letterType))
            {
                txtRecievedLetterDate.Enabled = false;
                txtRecLetterDateTo.Visible = false;
                txtRecievedLetterNumber.Visible = false;
                lblRecievedLetterDate.Visible = false;
                lblRecievedLetterNumber.Visible = false;
                pnlRecLetterDate.Visible = false;
                cmbCompareInputLetterDate.Visible = false;
                this.Text = "نامه صادره";
                lblInputRegisterNumber.Text = "شماره ثبت ورودی : ";
            }
            else
            {
                this.Text = "نامه وارده";
                lblInputRegisterNumber.Text = "شماره ثبت خروجی : ";
            }
            
            //BasicInfoUtil.fillComboBox(cmbInsuranceType, "InsuranceType", -1);
            BasicInfoUtil.fillCheckBoxList(cbListInsuranceType, "InsuranceType", -1);
            BasicInfoUtil.fillCheckBoxList(cmbManagemtAction, "managementAction", -1);

            BasicInfoUtil.fillCheckBoxList(cbLetterStateId, "LetterState", -1);
            UsersBS.fillCheckedListWithUsers(cbReferenceUserId, -1);
            UsersBS.fillCheckedListWithUsers(cbRefferFrom, -1);

            cmbArchive.SelectedIndex = 0;
            cmbFinalConfirm.SelectedIndex = 0;
            cmbManagerAction.SelectedIndex = 0;

            cmbCompareLetterDate.SelectedIndex = 0;
            cmbCompareInputLetterDate.SelectedIndex = 0;
            cmbCompareInsuranceDate.SelectedIndex = 0;
            cmbCompareLetterDate_SelectedIndexChanged(cmbCompareLetterDate, null);
            cmbCompareInputLetterDate_SelectedIndexChanged(cmbCompareInputLetterDate, null);
            cmbCompareInsuranceDate_SelectedIndexChanged(cmbCompareInsuranceDate, null);

         }

        private void AdvanceSearchForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            resultCondition = "";
            this.Close();
        }

        private void btnDoSearch_Click(object sender, EventArgs e)
        {
            resultCondition = "";
            preparecondition();
            this.Close();
        }
        
        private void preparecondition()
        {
            string cond = "";
            cond = _searchTools.getStringFldCond(LetterEntity.FIELD_LETTER_NUMBER, txtLetterNumber.Text, cond);
            cond = _searchTools.getDateFldCond(LetterEntity.FIELD_LETTER_DATE, txtLetterDate.Text,txtLetterDateTo.Text, cmbCompareLetterDate, cond);
            cond = _searchTools.getStringFldCond(LetterEntity.FIELD_RECIEVEDLETTERNUMBER, txtRecievedLetterNumber.Text, cond);
            cond = _searchTools.getDateFldCond(LetterEntity.FIELD_RECIEVEDLETTERDATE, txtRecievedLetterDate.Text,txtRecLetterDateTo.Text, cmbCompareInputLetterDate, cond);
            cond = _searchTools.getStringFldCond(LetterEntity.FIELD_LETTER_SUBJECT, txtLetterSubject.Text, cond);
            cond = _searchTools.getStringFldCond(LetterEntity.FIELD_INPUT_REGISTER_NUMBER, txtInputRegisterNumber.Text, cond);
            cond = _searchTools.getStringFldCond(LetterEntity.FIELD_LETTER_SUMMARY, txtSummary.Text, cond);
            cond = _searchTools.getCheckBoxListCond(cbListInsuranceType, LetterEntity.FIELD_INSURANCE_TYPE_ID, cond);
            cond = _searchTools.getCheckBoxListCond(cmbManagemtAction, LetterEntity.FIELD_MANAGEMENT_ACTION_ID, cond);
            cond = _searchTools.getStringFldCond(LetterEntity.FIELD_INSURANCE_NUMBER, txtInsuranceNumber.Text, cond);
            cond = _searchTools.getDateFldCond(LetterEntity.FIELD_INSURANCE_DATE, txtInsuranceDate.Text,txtInsuranceDateTo.Text, cmbCompareInsuranceDate, cond);
            cond = _searchTools.getCheckBoxListCond(cbLetterStateId, LetterEntity.FIELD_LETTER_STATE_ID, cond);
            cond = _searchTools.getNumberFldCond(txtCompany.Tag, LetterEntity.FIELD_COMPANY_ID, cond);
            cond = _searchTools.getCheckBoxListCond(cbReferenceUserId, LetterEntity.VIEW_FIELD_REFERENCED_USER_ID, cond);
            cond = _searchTools.getCheckBoxListCond(cbRefferFrom, LetterEntity.FIELD_REFER_FROM_USER_ID , cond);
            cond = _searchTools.getCheckBoxfldCond(cmbArchive, LetterEntity.FIELD_ARCHIVE, cond);
            cond = _searchTools.getCheckBoxfldCond(cmbFinalConfirm, LetterEntity.FIELD_FINAL_CONFIRM, cond);
            cond = _searchTools.getCheckBoxfldCond(cmbManagerAction, LetterEntity.FIELD_MANAGEMENT_ACTION_ID, cond);
            cond = _searchTools.getNumberFldCond(txtAgent.Tag, LetterEntity.FIELD_AGENT_ID, cond);
            resultCondition = cond;
        }


        public void btnReset_Click(object sender, EventArgs e)
        {
            resultCondition = "";
            txtLetterNumber.Text = "";
            txtLetterDate.Text = "";
            txtRecievedLetterDate.Text = "";
            txtRecievedLetterNumber.Text = "";
            txtLetterSubject.Text = "";
            txtInputRegisterNumber.Text = "";
            txtSummary.Text = "";
            cbListInsuranceType.ClearSelected();
            cmbManagemtAction.ClearSelected();
            txtInsuranceNumber.Text = "";
            txtInsuranceDate.Text = "    /  /  ";
            cbLetterStateId.ClearSelected();
            cbReferenceUserId.SelectedIndex = 0;
            txtCompany.Text = "";
            txtCompany.Tag = null;

            cmbFinalConfirm.SelectedIndex = 0;
            cmbManagerAction.SelectedIndex = 0;

            cmbCompareInputLetterDate.SelectedIndex = 0;
            cmbCompareInsuranceDate.SelectedIndex = 0;
            cmbCompareLetterDate.SelectedIndex = 0;
        }

        private void cmbCompareLetterDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            bool b = cmb.SelectedIndex == 5 ? b = true : false;
            lblLetterDateFrom.Visible = b;
            lblLetterDateTo.Visible = b;
            txtLetterDateTo.Visible = b;
        }

        private void cmbCompareInputLetterDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            bool b = cmb.SelectedIndex == 5 ? b = true : false;
            lblRecLetterDateFrom.Visible = b;
            lblRecLetterDateTo.Visible = b;
            txtRecLetterDateTo.Visible = b;
        }

        private void cmbCompareInsuranceDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            bool b = cmb.SelectedIndex == 5 ? b = true : false;
            lblInsuranceDateFrom.Visible = b;
            lblInsuranceDateTo.Visible = b;
            txtInsuranceDateTo.Visible = b;
        }

        private void btnShowCompany_Click(object sender, EventArgs e)
        {
            if (txtCompany.Tag == null)
                txtCompany.Tag = -1;
            CompanyList list = new CompanyList();
            list.ReadOnly = true;
            list.Id = (int)txtCompany.Tag;
            list.initList();
            list.ShowDialog();
            txtCompany.Tag = list.Id;
            txtCompany.Text = CompanyBL.getCompanyName(list.Id);
        }

        private void btnAgent_Click(object sender, EventArgs e)
        {
            if (txtAgent.Tag == null)
                txtAgent.Tag = 0;
            ReferenceCycleList list = new ReferenceCycleList();
            list.ReadOnly = true;
            list.Id = (int)txtAgent.Tag;
            list.initList();
            list.ShowDialog();
            txtAgent.Tag = list.Id;
            txtAgent.Text = AgentBL.getAgentName(list.Id);
        }

        private void btnLetterState_Click(object sender, EventArgs e)
        {
            int biId = BasicInfoUtil.getId("LetterState");
          //  MultiBasicInfoForm bi = new MultiBasicInfoForm(biId);

           // bi.load();
         //   bi.ShowDialog();
        }

    }
}
