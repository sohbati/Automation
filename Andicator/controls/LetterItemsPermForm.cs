using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorCommon;
using AndicatorBLL;

namespace Andicator.controls
{
    public partial class LetterItemsPermForm : Form
    {
        private int _userid = -1;
        private int _tableIndex = -1;

        private LetterItemsPermissionBL _letterItemPermBL; 
        private/*const*/ Color CHECK = Color.Green;
        private Color UNCHECK = Color.Red;
      
        public LetterItemsPermForm(int userid)
        {
            InitializeComponent();
            _userid = userid;
            init();
        }
        private void init()
        {
            txtRecievedLetterNumber.Tag = cbRecievedLetterNumber;
            txtRecievedLetterDate.Tag = cbRecievedLetterDate;
            txtLetterSubject.Tag = cbLetterSubject;
            txtInputRegisterNumber.Tag = cbInputRegisterNumber;
            btnSearch.Tag = cbBtnSearch;
            txtSummary.Tag = cbSummary;
            cmbInsuranceType.Tag = cbCmbInsuranceType;
            cmbManagemtAction.Tag = cbCmbManagemtAction;
            txtInsuranceDate.Tag = cbInsuranceDate;
            txtInsuranceNumber.Tag = cbCmbInsuranceNumber;
            cmbCompanyId.Tag = cbCmbCompanyId;
            cmbLetterStateId.Tag = cbCmbLetterStateId;
            btnLetterState.Tag = cbBtnLetterState;
            cmbReferenceUserId.Tag = cbCmbReferenceUserId;
            cbCbArchive.Tag = cbCbArchive;
            cbCbFinalConfirm.Tag = cbCbFinalConfirm;
            btnUsersReplies.Tag = cbBtnUsersReplies;
            btnReferToMasterUSer.Tag = cbRefertoMaster;
            btnShowRefrences.Tag = cbShowReffrences;
            txtRefferDate.Tag = cbAlarmStartDate;
            btnAgent.Tag = cbAgent;
            btnDelete.Tag = cbDeleteLetter;
            cbCbFastAction.Tag = cbCbFastAction;

            btnDoChainingToRecive.Tag = cbDoChainingToRecieve;
            btnDoChainingToSend.Tag = cbDoChainingToSend;
            btnSeperateFromChain.Tag = cbSeperateFromChain;
            cmbInsuranceCompany.Tag = cbInsuranceCompany;

        }

        public void load()
        {
            _letterItemPermBL = new LetterItemsPermissionBL();
            LetterItemsPermissionEntity entity = _letterItemPermBL.getByUser(_userid);
            if (entity.Tables[entity.FilledTableName].Rows.Count <= 0)
            {
                setAllUnchecked();
                return;
            }
            _tableIndex = int.Parse(entity.get(LetterItemsPermissionEntity.FIELD_ID).ToString());

            doItem(entity, LetterItemsPermissionEntity.FIELD_RECIEVEDLETTERNUMBER, txtRecievedLetterNumber);
            doItem(entity, LetterItemsPermissionEntity.FIELD_RECIEVEDLETTERNUMBER, txtRecievedLetterDate);
            doItem(entity, LetterItemsPermissionEntity.FIELD_LETTER_SUBJECT, txtLetterSubject);
            doItem(entity, LetterItemsPermissionEntity.FIELD_INPUT_REGISTER_NUMBER, txtInputRegisterNumber);
            doItem(entity, LetterItemsPermissionEntity.FIELD_BTN_SEARCH,btnSearch);
            doItem(entity, LetterItemsPermissionEntity.FIELD_LETTER_SUMMARY, txtSummary);
            doItem(entity, LetterItemsPermissionEntity.FIELD_INSURANCE_TYPE_ID, cmbInsuranceType);
            doItem(entity, LetterItemsPermissionEntity.FIELD_MANAGEMENT_ACTION, cmbManagemtAction);
            doItem(entity, LetterItemsPermissionEntity.FIELD_INSURANCE_DATE, txtInsuranceDate);
            doItem(entity, LetterItemsPermissionEntity.FIELD_INSURANCE_NUMBER, txtInsuranceNumber);
            doItem(entity, LetterItemsPermissionEntity.FIELD_COMPANY_ID, cmbCompanyId);
            doItem(entity, LetterItemsPermissionEntity.FIELD_LETTER_STATE_ID, cmbLetterStateId);
            doItem(entity, LetterItemsPermissionEntity.FIELD_BTN_LETTER_STATE, btnLetterState);
            doItem(entity, LetterItemsPermissionEntity.FIELD_REFERENCED_USER_ID, cmbReferenceUserId);
            doItem(entity, LetterItemsPermissionEntity.FIELD_ARCHIVE, cbCbArchive);
            doItem(entity, LetterItemsPermissionEntity.FIELD_FINAL_CONFIRM, cbCbFinalConfirm);
            doItem(entity, LetterItemsPermissionEntity.FIELD_BTN_USERS_REPLIES, btnUsersReplies);
            doItem(entity, LetterItemsPermissionEntity.FIELD_BTN_REFER_TO_MASTER, btnReferToMasterUSer);
            doItem(entity, LetterItemsPermissionEntity.FIELD_BTN_SHOW_REFFRENCES, btnShowRefrences);
            doItem(entity, LetterItemsPermissionEntity.FIELD_ALARM_STARTDATE, txtRefferDate);
            doItem(entity, LetterItemsPermissionEntity.FIELD_BTN_AGENT, btnAgent);
            doItem(entity, LetterItemsPermissionEntity.FIELD_DELETE_LETTER, btnDelete);
            doItem(entity, LetterItemsPermissionEntity.FIELD_FASTACTION, cbCbFastAction);

            doItem(entity, LetterItemsPermissionEntity.FIELD_BTN_DO_CHANING_TO_RECIEVE, btnDoChainingToRecive);
            doItem(entity, LetterItemsPermissionEntity.FIELD_BTN_DO_CHANING_TO_SEND, btnDoChainingToSend);
            doItem(entity, LetterItemsPermissionEntity.FIELD_BTN_SEPERATE_CHANING, btnSeperateFromChain);
            doItem(entity, LetterItemsPermissionEntity.FIELD_INSURANCE_COMPANY, cmbInsuranceCompany);

        }

        private void doItem(LetterItemsPermissionEntity entity, string fld, Control item) 
        {
            bool b = false;
            if (entity.get(fld).ToString().Length <= 0)
                b = false;
            else
              b = bool.Parse(entity.get(fld).ToString());
           if (b)
               checkItem(item);
           else
               UncheckItem(item);
        }

        private void setAllUnchecked()
        {
            UncheckItem(txtRecievedLetterNumber);
            UncheckItem(txtRecievedLetterDate);
            UncheckItem(txtLetterSubject);
            UncheckItem(txtInputRegisterNumber);
            UncheckItem(btnSearch);
            UncheckItem(txtSummary);
            UncheckItem(cmbInsuranceType);
            UncheckItem(cmbManagemtAction);
            UncheckItem(txtInsuranceDate);
            UncheckItem(txtInsuranceNumber);
            UncheckItem(cmbCompanyId);
            UncheckItem(cmbLetterStateId);
            UncheckItem(btnLetterState);
            UncheckItem(cmbReferenceUserId);
            UncheckItem(cbCbArchive);
            UncheckItem(cbCbFinalConfirm);
            UncheckItem(btnUsersReplies);
            UncheckItem(btnReferToMasterUSer);
            UncheckItem(btnShowRefrences);
            UncheckItem(txtRefferDate);
            UncheckItem(btnAgent);
            UncheckItem(btnDelete);
            UncheckItem(cbCbFastAction);
            UncheckItem(cbInsuranceCompany);
        }

        private void UncheckItem(Control c)
        {
           // c.BackColor = UNCHECK;
            ((CheckBox)c.Tag).Checked = false;
            ((CheckBox)c.Tag).ForeColor = Color.Black;
        }
        
        private void checkItem(Control c)
        {
           // c.BackColor = CHECK;
            ((CheckBox)c.Tag).Checked = true;
            ((CheckBox)c.Tag).ForeColor = Color.Green;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LetterItemsPermissionEntity entity = new LetterItemsPermissionEntity();
            DataRow dr = entity.Tables[entity.TableName].NewRow();
            if (_userid > 0)
            {
                dr[LetterItemsPermissionEntity.FIELD_USER_ID] = _userid;
                dr[LetterItemsPermissionEntity.FIELD_ID] = _tableIndex;

                dr[LetterItemsPermissionEntity.FIELD_RECIEVEDLETTERNUMBER] = cbRecievedLetterNumber.Checked;
                dr[LetterItemsPermissionEntity.FIELD_RECIEVEDLETTERDATE] = cbRecievedLetterDate.Checked;
                dr[LetterItemsPermissionEntity.FIELD_INPUT_REGISTER_NUMBER] = cbInputRegisterNumber.Checked;
                dr[LetterItemsPermissionEntity.FIELD_BTN_SEARCH] = cbBtnSearch.Checked;
                dr[LetterItemsPermissionEntity.FIELD_LETTER_SUBJECT] = cbLetterSubject.Checked;
                dr[LetterItemsPermissionEntity.FIELD_LETTER_SUMMARY] = cbSummary.Checked;
                dr[LetterItemsPermissionEntity.FIELD_COMPANY_ID] = cbCmbCompanyId.Checked;
                dr[LetterItemsPermissionEntity.FIELD_INSURANCE_TYPE_ID] = cbCmbInsuranceType.Checked;
                dr[LetterItemsPermissionEntity.FIELD_MANAGEMENT_ACTION] = cbCmbManagemtAction.Checked;
                dr[LetterItemsPermissionEntity.FIELD_INSURANCE_DATE] = cbInsuranceDate.Checked;
                dr[LetterItemsPermissionEntity.FIELD_INSURANCE_NUMBER] = cbCmbInsuranceNumber.Checked;
                dr[LetterItemsPermissionEntity.FIELD_LETTER_STATE_ID] = cbCmbLetterStateId.Checked;
                dr[LetterItemsPermissionEntity.FIELD_BTN_LETTER_STATE] = cbBtnLetterState.Checked;
                dr[LetterItemsPermissionEntity.FIELD_REFERENCED_USER_ID] = cbCmbReferenceUserId.Checked;
                dr[LetterItemsPermissionEntity.FIELD_ARCHIVE] = cbCbArchive.Checked;
                dr[LetterItemsPermissionEntity.FIELD_FINAL_CONFIRM] = cbCbFinalConfirm.Checked;
                dr[LetterItemsPermissionEntity.FIELD_BTN_USERS_REPLIES] = cbBtnUsersReplies.Checked;
                dr[LetterItemsPermissionEntity.FIELD_BTN_REFER_TO_MASTER] = cbRefertoMaster.Checked;
                dr[LetterItemsPermissionEntity.FIELD_BTN_SHOW_REFFRENCES] = cbShowReffrences.Checked;
                dr[LetterItemsPermissionEntity.FIELD_ALARM_STARTDATE] = cbAlarmStartDate.Checked;
                dr[LetterItemsPermissionEntity.FIELD_BTN_AGENT] = cbAgent.Checked;
                dr[LetterItemsPermissionEntity.FIELD_DELETE_LETTER] = cbDeleteLetter.Checked;
                dr[LetterItemsPermissionEntity.FIELD_FASTACTION] = cbCbFastAction.Checked;
                dr[LetterItemsPermissionEntity.FIELD_BTN_DO_CHANING_TO_RECIEVE] = cbDoChainingToRecieve.Checked;
                dr[LetterItemsPermissionEntity.FIELD_BTN_DO_CHANING_TO_SEND] = cbDoChainingToSend.Checked;
                dr[LetterItemsPermissionEntity.FIELD_BTN_SEPERATE_CHANING] = cbSeperateFromChain.Checked;
                dr[LetterItemsPermissionEntity.FIELD_INSURANCE_COMPANY] = cbInsuranceCompany.Checked;
                

                entity.Tables[entity.TableName].Rows.Add(dr);
                if (_tableIndex < 0) 
                    _tableIndex = _letterItemPermBL.addPermission(entity);
                else
                    _letterItemPermBL.update(entity);
                lblMsg.Text = "تغییرات ثبت گردید";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LetterItemsPermForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtRecievedLetterDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
