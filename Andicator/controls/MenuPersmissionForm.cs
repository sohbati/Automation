using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorBLL;
using AndicatorCommon;

namespace Andicator.controls
{
    public partial class MenuPersmissionForm : Form
    {
        #region private variables
        private int _userid;
        private UserpropertiesBL _userProperties;
        #endregion


        public MenuPersmissionForm(int userid)
        {
            _userid = userid;
            
            InitializeComponent();
            _userProperties = new UserpropertiesBL();
            load();
            cbCompanies_CheckedChanged(null, null);
            cbAgent_CheckedChanged(null, null);
        }

        private void load()
        {
            UserPropertiesEntity entity = _userProperties.get(_userid);
            bool recievedLetterPerm = false;
            bool sendLetterPerm = false;
            bool chequeInfo = false;
            bool usersPerm = false;
            bool basicInfoPerm = false;
            bool companyPerm = false;
            bool companyPermReadOnly = false;
            bool colorPerm = false;
            bool agentPerm = false;
            bool agentPermReadOnly = false;
            bool workingStatistic = false;
            bool referenceCycle = false;
            bool letterAnswerCountList = false;

            //recieved letters
            string v = _userProperties.getValue(entity, UserpropertiesBL.MENU_RECIEVED_PERMISSION);
            if(v != null) recievedLetterPerm = bool.Parse(v);
            //send letters
            v = _userProperties.getValue(entity, UserpropertiesBL.MENU_SEND_PERMISSION);
            if (v != null)sendLetterPerm = bool.Parse(v);
            //cheque info
            v = _userProperties.getValue(entity, UserpropertiesBL.MENU_CHEQUE_INFO);
            if (v != null) chequeInfo = bool.Parse(v);
            //users
            v = _userProperties.getValue(entity, UserpropertiesBL.MENU_USERS_PERMISSION);
            if (v != null)usersPerm = bool.Parse(v);
            //basicInfo
            v = _userProperties.getValue(entity, UserpropertiesBL.MENU_BASIC_INFO_PERMISSION);
            if (v != null)basicInfoPerm = bool.Parse(v);
           //company
            v = _userProperties.getValue(entity, UserpropertiesBL.MENU_COMPANY_PERMISSION);
            if (v != null)companyPerm = bool.Parse(v);
            //company readOnly
            v = _userProperties.getValue(entity, UserpropertiesBL.MENU_COMPANY_READ_ONLY_PERMISSION);
            if (v != null) companyPermReadOnly = bool.Parse(v);
            //color
            v = _userProperties.getValue(entity, UserpropertiesBL.MENU_COLOR_PERMISSION);
            if (v != null)colorPerm = bool.Parse(_userProperties.getValue(entity, UserpropertiesBL.MENU_COLOR_PERMISSION));
            //agent
            v = _userProperties.getValue(entity, UserpropertiesBL.MENU_AGENT_PERMISSION);
            if (v != null) agentPerm = bool.Parse(v);
            //agent read Only
            v = _userProperties.getValue(entity, UserpropertiesBL.MENU_AGENT_READ_ONLY_PERMISSION);
            if (v != null) agentPermReadOnly = bool.Parse(v);
            //workingStatistic
            v = _userProperties.getValue(entity, UserpropertiesBL.MENU_WORKING_STATISTIC);
            if (v != null) workingStatistic = bool.Parse(v);

            //ReferenceCycle
            v = _userProperties.getValue(entity, UserpropertiesBL.MENU_REFERENCE_CYCLE);
            if (v != null) referenceCycle = bool.Parse(v);

            //Letter Answer Count List
            v = _userProperties.getValue(entity, UserpropertiesBL.MENU_LETTER_ANSWER_COUNTLIST);
            if (v != null) letterAnswerCountList = bool.Parse(v);

            cbRecievedLetter.Checked = recievedLetterPerm;
            cbSendLetter.Checked = sendLetterPerm;
            cbCheckInfo.Checked = chequeInfo;
            cbUsers.Checked = usersPerm;
            cbBasicInfo.Checked = basicInfoPerm;
            cbCompanies.Checked = companyPerm;
            cbCompaniesReadOnly.Checked = companyPermReadOnly;
            cbColors.Checked = colorPerm;
            cbAgent.Checked = agentPerm;
            cbAgentsReadOnly.Checked = agentPermReadOnly;
            cbWorkingStatistic.Checked = workingStatistic;
            cbReferenceCycle.Checked = referenceCycle;
            cbLetterAnswerCountList.Checked = letterAnswerCountList;

        }

        private void MenuPersmissionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UserPropertiesEntity entity = _userProperties.get(_userid);
            bool recievedLetterPerm = false;
            bool sendLetterPerm = false;
            bool chequeInfoPerm = false;
            bool usersPerm = false;
            bool basicInfoPerm = false;
            bool companyPerm = false;
            bool companyReadOnlyPerm = false;
            bool colorPerm = false;
            bool agentPerm = false;
            bool agentReadOnlyPerm = false;
            bool workingStatistic = false;
            bool referenceCycle = false;
            bool letterAnswerCountList = false;

            recievedLetterPerm = cbRecievedLetter.Checked;
            sendLetterPerm = cbSendLetter.Checked;
            chequeInfoPerm = cbCheckInfo.Checked;
            usersPerm = cbUsers.Checked;
            basicInfoPerm = cbBasicInfo.Checked;
            companyPerm = cbCompanies.Checked;
            companyReadOnlyPerm = cbCompaniesReadOnly.Checked;
            colorPerm = cbColors.Checked;
            agentPerm = cbAgent.Checked;
            agentReadOnlyPerm = cbAgentsReadOnly.Checked;
            workingStatistic = cbWorkingStatistic.Checked;
            referenceCycle = cbReferenceCycle.Checked;
            letterAnswerCountList = cbLetterAnswerCountList.Checked;

            _userProperties.updateProperty(_userid, UserpropertiesBL.MENU_RECIEVED_PERMISSION, recievedLetterPerm.ToString());
            _userProperties.updateProperty(_userid, UserpropertiesBL.MENU_SEND_PERMISSION, sendLetterPerm.ToString());
            _userProperties.updateProperty(_userid, UserpropertiesBL.MENU_CHEQUE_INFO, chequeInfoPerm.ToString());
            _userProperties.updateProperty(_userid, UserpropertiesBL.MENU_USERS_PERMISSION, usersPerm.ToString());
            _userProperties.updateProperty(_userid, UserpropertiesBL.MENU_BASIC_INFO_PERMISSION, basicInfoPerm.ToString());
            _userProperties.updateProperty(_userid, UserpropertiesBL.MENU_COMPANY_PERMISSION, companyPerm.ToString());
            _userProperties.updateProperty(_userid, UserpropertiesBL.MENU_COMPANY_READ_ONLY_PERMISSION, companyReadOnlyPerm.ToString());
            _userProperties.updateProperty(_userid, UserpropertiesBL.MENU_COLOR_PERMISSION, colorPerm.ToString());
            _userProperties.updateProperty(_userid, UserpropertiesBL.MENU_AGENT_PERMISSION, agentPerm.ToString());
            _userProperties.updateProperty(_userid, UserpropertiesBL.MENU_AGENT_READ_ONLY_PERMISSION, agentReadOnlyPerm.ToString());
            _userProperties.updateProperty(_userid, UserpropertiesBL.MENU_WORKING_STATISTIC, workingStatistic.ToString());
            _userProperties.updateProperty(_userid, UserpropertiesBL.MENU_REFERENCE_CYCLE, referenceCycle.ToString());
            _userProperties.updateProperty(_userid, UserpropertiesBL.MENU_LETTER_ANSWER_COUNTLIST, letterAnswerCountList.ToString());

            lblMsg.Text = "دخیره گردید";
        }

        private void cbCompanies_CheckedChanged(object sender, EventArgs e)
        {
            cbCompaniesReadOnly.Enabled = cbCompanies.Checked;
        }

        private void cbAgent_CheckedChanged(object sender, EventArgs e)
        {
            cbAgentsReadOnly.Enabled = cbAgent.Checked;
        }

    }
}
