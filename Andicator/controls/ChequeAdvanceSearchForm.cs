using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;
using Andicator.controls.tools;
using AndicatorCommon;
using Andicator.lists;
using AndicatorBLL;

namespace Andicator.controls
{
    public partial class ChequeAdvanceSearchForm : Form
    {
        private SearchTools _searchTools;
        private string _resultCondition;

        public string ResultCondition
        {
            get { return _resultCondition; }
            set { _resultCondition = value; }
        }


        public ChequeAdvanceSearchForm()
        {
            InitializeComponent();
            _searchTools = new SearchTools();
            init();
        }

        private void init()
        {
            cmbPayType.Items.Clear();
            ComboBoxItem item = new ComboBoxItem("چک", "0");
            cmbPayType.Items.Add(item);
            item = new ComboBoxItem("نقد", "1");
            cmbPayType.Items.Add(item);

            BasicInfoUtil.fillCheckBoxList(cbInsuranceCompany, "InsuranceCompany", -1);
            BasicInfoUtil.fillCheckBoxList(cbBankId, "Bank", -1);

            cmbMaturityDate.SelectedIndex = 0;
            cmbMaturityDate_SelectedIndexChanged(cmbMaturityDate, null);

            cmbEntryDate.SelectedIndex = 0;
            cmbEntryDate_SelectedIndexChanged(cmbEntryDate, null);
        }

        private void ChequeAdvanceSearchForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void btnDoSearch_Click(object sender, EventArgs e)
        {
            ResultCondition = "";
            preparecondition();
            this.Close();
        }
        private void preparecondition()
        {
            string cond = "";
            cond = _searchTools.getCombofldCond(cmbPayType, ChequeEntity.FIELD_PAY_TYPE, cond);
            cond = _searchTools.getStringFldCond(ChequeEntity.FIELD_CHEQUE_NUMBER, txtChequeNumber.Text, cond);
            cond = _searchTools.getDateFldCond(ChequeEntity.FIELD_MATURITY_DATE, txtMaturityDate.Text,txtMaturityDateTo.Text, cmbMaturityDate, cond);
            cond = _searchTools.getDateFldCond(ChequeEntity.FIELD_ENTRY_DATE, txtEntryDate.Text,txtEntryDateTo.Text, cmbEntryDate, cond);
            cond = _searchTools.getCheckBoxListCond(cbBankId, ChequeEntity.FIELD_BANK_ID, cond);

            cond = _searchTools.getNumberFldCond(ChequeEntity.FIELD_PRICE, txtPrice.Text,txtPriceTo.Text,cmbPrice, cond);
            cond = _searchTools.getCheckBoxListCond(cbInsuranceCompany, ChequeEntity.FIELD_INSURANCE_COMPANY, cond);
            cond = _searchTools.getStringFldCond(ChequeEntity.FIELD_INSURANCE_NUMBER, txtInsuranceNumber.Text, cond);
            cond = _searchTools.getStringFldCond(ChequeEntity.FIELD_ACCOUNT_NUMBER, txtAccountNumber.Text, cond);
            cond = _searchTools.getStringFldCond(ChequeEntity.FIELD_ACCOUNT_HOLDER_NAME, txtAccountHolderName.Text, cond);
            //cond = _searchTools.getStringFldCond(ChequeEntity.FIELD_DESCRIPTION, txtDescription.Text, cond);
            cond = _searchTools.getCombofldCond(cmbArchive, ChequeEntity.FIELD_ARCHIVE, cond);
            cond = _searchTools.getNumberFldCond(txtCompany.Tag, ChequeEntity.FIELD_COMPANY_ID, cond);
            ResultCondition = cond;
        }

        private void cmbMaturityDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            bool b = cmb.SelectedIndex == 5 ? b = true :  false;
            lblMAturityDateFrom.Visible = b;
            lblMaturityDateTo.Visible = b;
            txtMaturityDateTo.Visible = b;
        }

        private void cmbEntryDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            bool b = cmb.SelectedIndex == 5 ? b = true :  false;
            lblEntryDateFrom.Visible = b;
            lblEntryDateTo.Visible = b;
            txtEntryDateTo.Visible = b;
        }

        private void cmbPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            bool b = cmb.SelectedIndex == 5 ? b = true :  false;
            lblPriceFrom.Visible = b;
            lblPriceTo.Visible = b;
            txtPriceTo.Visible = b;
            }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbPayType.SelectedIndex = 0;
            txtChequeNumber.Text = "";
            cmbMaturityDate.SelectedIndex = 0;
            txtMaturityDate.Text = "";
            txtMaturityDateTo.Text = "";
            cbBankId.ClearSelected();
            cmbPrice.SelectedIndex = 0;
            txtPrice.Text = "";
            txtPriceTo.Text = "";
            cbInsuranceCompany.ClearSelected();
            txtInsuranceNumber.Text = "";
            txtAccountNumber.Text = "";
            txtAccountHolderName.Text = "";
            cmbArchive.SelectedIndex = 0;
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
        }
    
}
