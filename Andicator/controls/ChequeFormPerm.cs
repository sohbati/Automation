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
using RMX_TOOLS.global;
using RMX_TOOLS.converter;
using RMX_TOOLS.data.grid;
using System.Collections;
using Andicator.controls.tools;
using RMX_TOOLS.hasti.bll;
using Andicator.lists;

namespace Andicator.controls
{
    public partial class ChequeFormPerm: Form
    {
        private int _userid = -1;
        private int _tableIndex = -1;

        private ChequeFieldsPermissionBL _chequeFieldsPermBL; 
        private/*const*/ Color CHECK = Color.Green;
        private Color UNCHECK = Color.Red;

        public ChequeFormPerm(int userid)
        {
            InitializeComponent();
            _userid = userid;
        }
         

        public void load()
        {
            _chequeFieldsPermBL = new ChequeFieldsPermissionBL();
            ChequeFieldsPermissionEntity entity = _chequeFieldsPermBL.getByUser(_userid);
            if (entity.Tables[entity.FilledTableName].Rows.Count <= 0)
            {
                setAllUnchecked();
                return;
            }
            _tableIndex = int.Parse(entity.get(ChequeFieldsPermissionEntity.FIELD_ID).ToString());

            doItem(entity, ChequeFieldsPermissionEntity.FIELD_PAYTYPE, cmbPayType, cbcmbPayType);
            doItem(entity, ChequeFieldsPermissionEntity.FIELD_CHEQUENUMBER, txtChequeNumber, cbtxtChequeNumber);
            doItem(entity, ChequeFieldsPermissionEntity.FIELD_MATURITYDATE, txtMaturityDate, cbtxtMaturityDate);
            doItem(entity, ChequeFieldsPermissionEntity.FIELD_ENTRYDATE, txtEntryDate, cbtxtEntryDate);
            doItem(entity, ChequeFieldsPermissionEntity.FIELD_BANKID, cmbBankId, cbcmbBankId);
            doItem(entity, ChequeFieldsPermissionEntity.FIELD_PRICE, txtPrice, cbtxtPrice);
            doItem(entity, ChequeFieldsPermissionEntity.FIELD_ACCOUNTNUMBER, txtAccountNumber, cbtxtAccountNumber);
            doItem(entity, ChequeFieldsPermissionEntity.FIELD_COMPANYID, txtCompany, cbtxtCompany);
            doItem(entity, ChequeFieldsPermissionEntity.FIELD_REFFERFROM, cmbReferenceUserId, cbcmbReferenceUserId);
            doItem(entity, ChequeFieldsPermissionEntity.FIELD_REFFERDATE, txtRefferDate, cbtxtRefferDate);
            doItem(entity, ChequeFieldsPermissionEntity.FIELD_INSURANCECOMPANY, cmbInsuranceCompany, cbcmbInsuranceCompany);
            doItem(entity, ChequeFieldsPermissionEntity.FIELD_INSURANCENUMBER, txtInsuranceNumber, cbtxtInsuranceNumber);
            doItem(entity, ChequeFieldsPermissionEntity.FIELD_ACCOUNTHOLDERNAME, txtAccountHolderName, cbtxtAccountHolderName);
            doItem(entity, ChequeFieldsPermissionEntity.FIELD_ARCHIVE, cbArchive, cbcbArchive);
            doItem(entity, ChequeFieldsPermissionEntity.FIELD_CHEQUEITEMS, null, cbdataGridView1);
        }

        private void doItem(ChequeFieldsPermissionEntity entity, string fld, Control item, CheckBox checkBoxControl) 
        {
            bool b = false;
            if (entity.get(fld).ToString().Length <= 0)
                b = false;
            else
                b = bool.Parse(entity.get(fld).ToString());
            checkBoxControl.Checked = b;
        }

        private void setAllUnchecked()
        {
             
        }

         

        private void btnSave_Click(object sender, EventArgs e)
        {
            ChequeFieldsPermissionEntity entity = new ChequeFieldsPermissionEntity();
            DataRow dr = entity.Tables[entity.TableName].NewRow();
            if (_userid > 0)
            {
                dr[ChequeFieldsPermissionEntity.FIELD_USERID] = _userid;
                dr[ChequeFieldsPermissionEntity.FIELD_ID] = _tableIndex;

                dr[ChequeFieldsPermissionEntity.FIELD_PAYTYPE] = cbcmbPayType.Checked;
                dr[ChequeFieldsPermissionEntity.FIELD_CHEQUENUMBER] = cbtxtChequeNumber.Checked;
                dr[ChequeFieldsPermissionEntity.FIELD_MATURITYDATE] = cbtxtMaturityDate.Checked;
                dr[ChequeFieldsPermissionEntity.FIELD_ENTRYDATE] = cbtxtEntryDate.Checked;
                dr[ChequeFieldsPermissionEntity.FIELD_BANKID] = cbcmbBankId.Checked;
                dr[ChequeFieldsPermissionEntity.FIELD_PRICE] = cbtxtPrice.Checked;
                dr[ChequeFieldsPermissionEntity.FIELD_ACCOUNTNUMBER] = cbtxtAccountNumber.Checked;
                dr[ChequeFieldsPermissionEntity.FIELD_COMPANYID] = cbtxtCompany.Checked;
                dr[ChequeFieldsPermissionEntity.FIELD_REFFERFROM] = cbcmbReferenceUserId.Checked;
                dr[ChequeFieldsPermissionEntity.FIELD_REFFERDATE] = cbtxtRefferDate.Checked;
                dr[ChequeFieldsPermissionEntity.FIELD_INSURANCECOMPANY] = cbcmbInsuranceCompany.Checked;
                dr[ChequeFieldsPermissionEntity.FIELD_INSURANCENUMBER]= cbtxtInsuranceNumber.Checked;
                dr[ChequeFieldsPermissionEntity.FIELD_ACCOUNTHOLDERNAME] = cbtxtAccountHolderName.Checked;
                dr[ChequeFieldsPermissionEntity.FIELD_ARCHIVE] = cbcbArchive.Checked;
                dr[ChequeFieldsPermissionEntity.FIELD_CHEQUEITEMS] = cbdataGridView1.Checked; 

                entity.Tables[entity.TableName].Rows.Add(dr);
                if (_tableIndex < 0) 
                    _tableIndex = _chequeFieldsPermBL.addPermission(entity);
                else
                    _chequeFieldsPermBL.update(entity);
                lblMsg.Text = "تغییرات ثبت گردید";
            }
        }

        private void ChequeFormPerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }

}
