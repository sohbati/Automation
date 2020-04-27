using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorCommon;
using AndicatorBLL;
using RMX_TOOLS.global;
using RMX_TOOLS.hasti.tools;
using RMX_TOOLS.converter;
using RMX_TOOLS.hasti.bll;
using Andicator.lists;

namespace Andicator.controls
{
    public partial class LetterForm : Form
    {
        #region properties

        private bool _dataChanged = false;

        public bool DataChanged
        {
            get { return _dataChanged; }
            set { _dataChanged = value; }
        }

        private LetterEntity _entity;

        public LetterEntity LetterEntity
        {
            get { return _entity; }
            set { _entity = value; }
        }
        private int _letterId = -1;

        public int LetterId
        {
            get { return _letterId; }
            set { _letterId = value; }
        }
        private string _mode;

        public string Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        
        private int _letterType;
        public int LetterType
        {
            get { return _letterType; }
            set { _letterType = value; }
        }

        public bool readOnly { get; set; }
        #endregion

        #region variable

        private LetterItemsPermissionEntity m_permissionEntity = null;
        private LetterBL _letterBL;
        private LetterNumberPatternBL _letterNumberPatternBL;
        
        private int topSend;
        private int topRecieve;

        #endregion

        public LetterForm(int letterType)
        {
            InitializeComponent();
            init();
        }


        public LetterForm()
        {
            InitializeComponent();
            init();

        }

        private void init()
        {
            topSend = pnlItems.Top - 20;
            topRecieve = pnlItems.Top;

            _letterBL = new LetterBL();
            _letterNumberPatternBL = new LetterNumberPatternBL();
        }

        public void initLetter()
        {
            lblMsg.Text = "";
            initLetter(false);
            if (readOnly == true)
            {
                btnSave.Enabled = false;
                btnReferToMasterUser.Enabled = false;
                btnUsersReplies.Enabled = false;
                btnLetterState.Enabled = false;
            }

            updateChaningButtons();
            setPaging();
        }

        public void initLetter(bool isReadOnly)
        {
            if (isReadOnly)
            {
                btnSave.Enabled = false;
                btnReferToMasterUser.Enabled = false;
                tableLayoutPanel1.ForeColor = Color.BlueViolet;
            }

            if (_letterId >= 0)
            {
                _mode = RMX_TOOLS.global.Constants.EDIT_MODE;
               _entity = _letterBL.getByLetterId(_letterId);
               _letterType = int.Parse(_entity.get(LetterEntity.FIELD_LETTER_TYPE).ToString());
            }else {
                _mode = RMX_TOOLS.global.Constants.ADD_MODE;
                _entity = new LetterEntity();
                
                btnUsersReplies.Visible = false;
                btnReferToMasterUser.Visible = false;

                cbArchive.Visible = false;
                lblCbArchive.Visible = false;
                cbFinalConfirm.Visible = false;
                lblFinalConfirm.Visible = false;
                
            }

            loadForm();

            if (LetterBL.LETTER_TYPE_SEND.Equals(LetterType))
            {
                txtRecievedLetterDate.Visible = false;
                txtRecievedLetterNumber.Visible = false;
                lblRecievedLetterDate.Visible = false;
                lblRecievedLetterNumber.Visible = false;
                pnlItems.Top = topSend;
                this.Text = "نامه صادره";
               lblInputRegisterNumber.Text = "شماره ثبت ورودی : ";
            }
            else
            {
                txtRecievedLetterDate.Visible = true;
                txtRecievedLetterNumber.Visible = true;
                lblRecievedLetterDate.Visible = true;
                lblRecievedLetterNumber.Visible = true;

                pnlItems.Top = topRecieve;
                this.Text = "نامه وارده";
                lblInputRegisterNumber.Text = "شماره ثبت خروجی : ";
            }

            setPermision();
            loadUsersReplies();
            loadAttachmentCount();
            this.Update();
            this.Refresh();
            if (_letterId <= 0)
            {
                lblMsg.Text = "ثبت " + this.Text + " جدید";
                cmbReferenceUserId.Enabled = true;
                linkAttachment.Visible = false;
            }
            else
            {
                cmbReferenceUserId.Visible = false;
                lblReferenceUserId.Visible = false;
                int userid = -1;
                 if (_entity.get(LetterEntity.VIEW_FIELD_REFERENCED_USER_ID).ToString() != "")
                     userid =  int.Parse(_entity.get(LetterEntity.VIEW_FIELD_REFERENCED_USER_ID).ToString());

                 UsersBS user = new UsersBS();
                 UsersEntity userEntity = user.get(userid);
                 if (cbArchive.Checked)
                 {
                     lblMsg.Text = "،این نامه در حال حاضر بایگانی شده و آخرین کاربری که نامه به وی ارجاع شده " +
                         userEntity.ToString() + "   می باشد ";
                 }
                 else
                 {
                     string s = (cbFinalConfirm.Checked ? " تایید نهایی شده است " : " هنوز تایید نهایی نشده است ");
                     lblMsg.Text = " این نامه در کارتابل  " + userEntity.ToString() + " می باشد" + " و " + s;
                 }
            }
            initGroup();
        }

        private void initGroup()
        {
            object letterGroupId = _entity.get(LetterEntity.FIELD_GROUP_ID).ToString();
            if (letterGroupId != null && letterGroupId.ToString().Trim().Length != 0) // has a group ? 
            {
                btnAddToGroup.Enabled = false;
                BtnDeleteFromGroup.Enabled = true;
            }else // Doesn't have a group
            {
                btnAddToGroup.Enabled = true;
                BtnDeleteFromGroup.Enabled = false;
            }
        }

        private void loadAttachmentCount()
        {
            AttachmentBL attachmentBl = new AttachmentBL();
            int count =  attachmentBl.getCount(_letterId);
            if (count <= 0)
            {
                linkAttachment.Text = " افزودن ضمیمه به نامه"; 
            }else
                linkAttachment.Text = "به تعداد  " + count + " " + " فایل ضمیمه برای این نامه وجود دارد"; 

        }

        private void setPermision()
        {
            int userid = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
            LetterItemsPermissionBL letItemPerm = new LetterItemsPermissionBL();
            m_permissionEntity = letItemPerm.getByUser(userid);
            
            if (UsersBS.ADMIN.ToString().Equals(UsersBS.loginedUser.get(UsersEntity.FIELD_USER_TYPE).ToString()))
                return;

            doPerm(txtRecievedLetterNumber,m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_RECIEVEDLETTERNUMBER));
            doPerm(txtRecievedLetterDate,m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_RECIEVEDLETTERDATE));
            doPerm(txtLetterSubject,m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_LETTER_SUBJECT));
            doPerm(txtInputRegisterNumber,m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_INPUT_REGISTER_NUMBER));
            doPerm(btnSearch,m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_BTN_SEARCH));
            doPerm(txtSummary,m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_LETTER_SUMMARY));
            doPerm(cmbInsuranceType,m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_INSURANCE_TYPE_ID));
            doPerm(cmbManagemtAction, m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_MANAGEMENT_ACTION));
            doPerm(txtInsuranceDate,m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_INSURANCE_DATE));
            doPerm(txtInsuranceNumber,m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_INSURANCE_NUMBER));
            doPerm(txtCompany,m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_COMPANY_ID));
            doPerm(btnShowCompany, m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_COMPANY_ID));
            doPerm(cmbLetterStateId,m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_LETTER_STATE_ID));
            doPerm(btnLetterState,m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_BTN_LETTER_STATE));
            //doPerm(cmbReferenceUserId,entity.get(LetterItemsPermissionEntity.FIELD_REFERENCED_USER_ID));
            doPerm(btnUsersReplies,m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_BTN_USERS_REPLIES));
            doPerm(btnReferToMasterUser, m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_BTN_REFER_TO_MASTER));
            doPerm(btnShowRefrences, m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_BTN_SHOW_REFFRENCES));
            doPerm(txtRefferDate, m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_ALARM_STARTDATE));
            doPerm(btnAgent, m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_BTN_AGENT));
            
            doPerm(cbFastAction, m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_FASTACTION));
            doPerm(cbArchive, m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_ARCHIVE));
            doPerm(cbFinalConfirm, m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_FINAL_CONFIRM));

            doPerm(btnDoChainingToRecive, m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_BTN_DO_CHANING_TO_RECIEVE));
            doPerm(btnDoChainingToSend, m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_BTN_DO_CHANING_TO_SEND));
            doPerm(btnDoChainingToSend, m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_BTN_SEPERATE_CHANING));
            
            doPerm(cmbInsuranceCompany, m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_INSURANCE_COMPANY));

        }

        private void doPerm(Control c, object value)
        {
            if (int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_USER_TYPE).ToString()).Equals(UsersBS.ADMIN))
                return;
            if (value == null || value.ToString().Equals("") || ((Boolean)value).Equals(false)){
                c.Enabled = false;
                c.BackColor = txtLetterDate.BackColor;
            }  else
                c.Enabled = true;
        }

        private void loadForm()
        {
            
            if (_mode.Equals(Constants.EDIT_MODE))
            {
                DateConverter converter = new DateConverter();
                cbOral.Visible = false;
                txtLetterNumber.Text = (string)_entity.get(LetterEntity.FIELD_LETTER_NUMBER);
                
                txtLetterSubject.Text =(string) _entity.get(LetterEntity.FIELD_LETTER_SUBJECT);
                txtInputRegisterNumber.Text = (string)_entity.get(LetterEntity.FIELD_INPUT_REGISTER_NUMBER);
                txtSummary.Text = (string)_entity.get(LetterEntity.FIELD_LETTER_SUMMARY);
                txtInsuranceNumber.Text = (string)_entity.get(LetterEntity.FIELD_INSURANCE_NUMBER);

                txtLetterDate.Text = converter.valueToString(_entity.get(LetterEntity.FIELD_LETTER_DATE));
                txtInsuranceDate.Text = converter.valueToString(_entity.get(LetterEntity.FIELD_INSURANCE_DATE));
                
                cbArchive.Checked = (Boolean)("".Equals(_entity.get(LetterEntity.FIELD_ARCHIVE).ToString()) ? false :_entity.get(LetterEntity.FIELD_ARCHIVE));
                cbFastAction.Checked = (Boolean)("".Equals(_entity.get(LetterEntity.FIELD_FASTACTION).ToString()) ? false : _entity.get(LetterEntity.FIELD_FASTACTION));

                cbFinalConfirm.Checked = (Boolean)("".Equals(_entity.get(LetterEntity.FIELD_FINAL_CONFIRM).ToString()) ? false : _entity.get(LetterEntity.FIELD_FINAL_CONFIRM));

                txtRefferDate.Text = converter.valueToString(_entity.get(LetterEntity.FIELD_REFFER_DATE));

                BasicInfoUtil.fillComboBox(cmbInsuranceType, "InsuranceType", int.Parse(_entity.get(LetterEntity.FIELD_INSURANCE_TYPE_ID).ToString()));
                int m = -1;
                if (_entity.get(LetterEntity.FIELD_MANAGEMENT_ACTION_ID) != null && _entity.get(LetterEntity.FIELD_MANAGEMENT_ACTION_ID).ToString().Length > 0)
                    m = int.Parse(_entity.get(LetterEntity.FIELD_MANAGEMENT_ACTION_ID).ToString());
                BasicInfoUtil.fillComboBox(cmbManagemtAction, "managementAction", m);
                BasicInfoUtil.fillComboBox(cmbLetterStateId, "LetterState", int.Parse(_entity.get(LetterEntity.FIELD_LETTER_STATE_ID).ToString()));
                int insCompanyId = 0;
                if (_entity.get(LetterEntity.FIELD_INSURANCE_COMPANY).ToString().Length >0)
                    insCompanyId = int.Parse(_entity.get(LetterEntity.FIELD_INSURANCE_COMPANY).ToString());
                BasicInfoUtil.fillComboBox(cmbInsuranceCompany, "InsuranceCompany", insCompanyId);
                txtCompany.Tag = 0;
                if (_entity.get(LetterEntity.FIELD_COMPANY_ID).ToString().Length > 0)
                {
                    txtCompany.Tag = (int) _entity.get(LetterEntity.FIELD_COMPANY_ID);
                    txtCompany.Text = CompanyBL.getCompanyName((int)txtCompany.Tag);

                }
                txtAgent.Tag = 0;
                if (_entity.get(LetterEntity.FIELD_AGENT_ID).ToString().Length > 0)
                {
                    txtAgent.Tag = (int)_entity.get(LetterEntity.FIELD_AGENT_ID);
                    txtAgent.Text = AgentBL.getAgentName((int)txtAgent.Tag);
                }

                if (_entity.get(LetterEntity.VIEW_FIELD_REFERENCED_USER_ID).ToString() == "")
                {
                    MessageBox.Show("این نامه به هیچ کاربری ارجاع نشده است");
                    fillUserRefferenceCombo(-1);
                    
                }
                else
                    fillUserRefferenceCombo(int.Parse(_entity.get(LetterEntity.FIELD_USER_TREE_ID).ToString()));
                if(LetterBL.LETTER_TYPE_RECIEVE.Equals(LetterType))
                {
                    txtRecievedLetterNumber.Text = (string)_entity.get(LetterEntity.FIELD_RECIEVEDLETTERNUMBER);
                    txtRecievedLetterDate.Text = converter.valueToString(_entity.get(LetterEntity.FIELD_RECIEVEDLETTERDATE));
                }
            }
            else
            {
                try
                {
                    if (LetterBL.LETTER_TYPE_RECIEVE.Equals(LetterType))
                    {
                        txtLetterNumber.Tag = _letterNumberPatternBL.GenerateNewRecieveLetterNumber();
                        txtLetterNumber.Text = ((string[])txtLetterNumber.Tag)[0];

                        cbOral.Tag = _letterNumberPatternBL.GenerateOralRecieveLetterNumber();
                    }
                    else
                    {
                        txtLetterNumber.Tag = _letterNumberPatternBL.GenerateNewSendLetterNumber();
                        txtLetterNumber.Text = txtLetterNumber.Text = ((string[])txtLetterNumber.Tag)[0];

                        cbOral.Tag = _letterNumberPatternBL.GenerateOralSendLetterNumber();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                txtLetterDate.Text = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.Now);
                txtAgent.Tag = 0;
                //che
                checkLetterNumberDuplicating(txtLetterNumber.Text);

                BasicInfoUtil.fillComboBox(cmbInsuranceType, "InsuranceType", -1);
                BasicInfoUtil.fillComboBox(cmbManagemtAction, "managementAction", -1);
                BasicInfoUtil.fillComboBox(cmbLetterStateId, "LetterState", -1);
                BasicInfoUtil.fillComboBox(cmbInsuranceCompany, "InsuranceCompany", -1);
                fillUserRefferenceCombo(-1);

                cmbLetterStateId_SelectedIndexChanged(null, null);
            }
        }

        private void fillUserRefferenceCombo(int defaultValue)
        {
            UserTreeBL userTreeBL = new UserTreeBL();
            int loggineduserid = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
            UserTreeEntity entity = userTreeBL.getUserAllAccessPath(loggineduserid);
            cmbReferenceUserId.DataSource = null;
            cmbReferenceUserId.Items.Clear();

            var dataSource = new List<ComboBoxItem>();
            BasicInfoUtil.AddUnKnown(dataSource);
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                string name = entity.get(i, UserTreeEntity.VIEW_FIELD_USER_NAME).ToString();
                string treeid = entity.get(i, UserTreeEntity.FIELD_ID).ToString();
                string userid = entity.get(i, UserTreeEntity.FIELD_USER_ID).ToString();
                dataSource.Add(new ComboBoxItem(name,treeid,userid));
            }

            cmbReferenceUserId.DataSource = dataSource;
            cmbReferenceUserId.DisplayMember = "Text";
            cmbReferenceUserId.ValueMember = "Value";
            for (int i = 0; i < cmbReferenceUserId.Items.Count; i++)
            {
                string c = ((ComboBoxItem)cmbReferenceUserId.Items[i]).CustomData;
                if(c != null && c.Equals(defaultValue.ToString()))
                {
                    cmbReferenceUserId.SelectedIndex = i;
                    break;
                }
            }
            
        }

        private void checkLetterNumberDuplicating(string LetterNumber)
        {
            LetterEntity entity = _letterBL.getByLetterNumber(LetterNumber);
            if (entity.Tables[entity.FilledTableName].Rows.Count > 0)
            {
                MessageBox.Show("با بررسی صورت گرفته ، مشاهده شد که قبلا نامه ای با این شماره تولید شده در سیستم ذخیره شده ، لطفا با مدیر سیستم تماس بگیرید");
                btnSave.Enabled = false;
                btnLetterState.Enabled = false;
                btnReferToMasterUser.Enabled = false;
                btnUsersReplies.Enabled = false;
                btnShowRefrences.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //if (Constants.EDIT_MODE.Equals(_mode))
            //{
            //    LetterStateBL letterStateBl = new LetterStateBL();
            //    LetterStateEntity entity = letterStateBl.get(_letterId);
            //    if (entity.Tables[entity.FilledTableName].Rows.Count <= 0)
            //    {
            //        DialogResult dialogResult = MessageBox.Show("فرم وضعیت نامه را پر نکرده اید ، آیا میخواهید آن را پر نمایید", "نامه ", MessageBoxButtons.YesNo);
            //        if (dialogResult == DialogResult.Yes)
            //        {
            //            btnLetterState_Click(null, null);
            //            return;
            //        }
                    
            //    }
            //}
            this.Close();
        }

        private bool BeforSave()
        {
            bool b;
            b = FormChecker.CheckEmpty(txtLetterNumber, lblLetterNumber);
            b &= FormChecker.CheckEmpty(txtLetterSubject, lblLetterSubject);
            b &= FormChecker.CheckEmpty(cmbInsuranceCompany, lblInsuranceCompany);
            b &= FormChecker.CheckDate(txtLetterDate, lblLetterDate);
          //  b &= FormChecker.CheckDate(txtInsuranceDate, lblInsuranceDate);
            if (String.Join("", txtRefferDate.Text.Split('/')).Trim().Length > 0)
            {
                b &= FormChecker.CheckDate(txtRefferDate, lblRefferDate);
            }
           // b &= FormChecker.CheckEmpty(txtSummary, lblSummary);
           // b &= FormChecker.CheckEmpty(txtInsuranceNumber, lblInsuranceNumber);

            b &= FormChecker.CheckEmpty(cmbInsuranceType, lblInsuranceType);
            //b &= FormChecker.CheckEmpty(cmbManagemtAction, lblManagemtAction);
            b &= FormChecker.CheckEmpty(cmbLetterStateId, lblLetterState);
           if(Constants.ADD_MODE.Equals(_mode))
                b &= FormChecker.CheckEmpty(cmbReferenceUserId, lblReferenceUserId);
            b &= FormChecker.CheckEmpty(txtCompany, lblCompany);
            return b;

           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!BeforSave())
                return;

            DateConverter dateconverter = new DateConverter();
            
            LetterEntity entity = new LetterEntity();
            DataRow dr = entity.Tables[_entity.TableName].NewRow();

            dr[LetterEntity.FIELD_LETTER_NUMBER] = txtLetterNumber.Text;
            
            dr[LetterEntity.FIELD_LETTER_SUBJECT] = txtLetterSubject.Text;
            dr[LetterEntity.FIELD_INPUT_REGISTER_NUMBER] = txtInputRegisterNumber.Text;
            dr[LetterEntity.FIELD_LETTER_SUMMARY] = txtSummary.Text;
            dr[LetterEntity.FIELD_INSURANCE_NUMBER] = txtInsuranceNumber.Text;
            
            dr[LetterEntity.FIELD_INSURANCE_DATE] = dateconverter.stringToValue(txtInsuranceDate.Text);
            dr[LetterEntity.FIELD_LETTER_DATE] = dateconverter.stringToValue(txtLetterDate.Text);
            
            dr[LetterEntity.FIELD_LETTER_STATE_ID] = ((ComboBoxItem)cmbLetterStateId.Items[cmbLetterStateId.SelectedIndex]).Value;
            dr[LetterEntity.FIELD_INSURANCE_TYPE_ID] = ((ComboBoxItem)cmbInsuranceType.Items[cmbInsuranceType.SelectedIndex]).Value;
            if (cmbManagemtAction.SelectedIndex >=0)
                dr[LetterEntity.FIELD_MANAGEMENT_ACTION_ID] = ((ComboBoxItem)cmbManagemtAction.Items[cmbManagemtAction.SelectedIndex]).Value;
            dr[LetterEntity.FIELD_INSURANCE_COMPANY] = ((ComboBoxItem)cmbInsuranceCompany.Items[cmbInsuranceCompany.SelectedIndex]).Value;
            dr[LetterEntity.FIELD_COMPANY_ID] = txtCompany.Tag;
            
            dr[LetterEntity.FIELD_AGENT_ID] = txtAgent.Tag;
           // dr[LetterEntity.FIELD_REFERENCED_USER_ID] = ((ComboBoxItem)cmbReferenceUserId.Items[cmbReferenceUserId.SelectedIndex]).Value;
            dr[LetterEntity.FIELD_ARCHIVE] = cbArchive.Checked;
            dr[LetterEntity.FIELD_FASTACTION] = cbFastAction.Checked;
            dr[LetterEntity.FIELD_FINAL_CONFIRM] = cbFinalConfirm.Checked;
            

            if (String.Join("", txtRefferDate.Text.Split('/')).Trim().Length == 0)
            {
                dr[LetterEntity.FIELD_REFFER_DATE] = dateconverter.stringToValue(txtLetterDate.Text);
            }
            else 
                dr[LetterEntity.FIELD_REFFER_DATE] = dateconverter.stringToValue(txtRefferDate.Text);

            ComboBoxItem item = (ComboBoxItem)cmbLetterStateId.Items[cmbLetterStateId.SelectedIndex];
            dr[LetterEntity.FIELD_COLOR] = item.CustomData.ToString();

            dr[LetterEntity.FIELD_LETTER_TYPE] = _letterType;
            if (cbFinalConfirm.Checked)
            {
                dr[LetterEntity.FIELD_COLOR] = new ApplicationPropertiesBL().getValue(ApplicationPropertiesBL.COLOR_CONFIRMED_LETTER);
            }
            if (LetterBL.LETTER_TYPE_RECIEVE.Equals(LetterType))
            {
                dr[LetterEntity.FIELD_RECIEVEDLETTERNUMBER] = txtRecievedLetterNumber.Text;
                dr[LetterEntity.FIELD_RECIEVEDLETTERDATE] = dateconverter.stringToValue(txtRecievedLetterDate.Text);
            }

            int logginedUserId = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());

            if (Mode.Equals(RMX_TOOLS.global.Constants.ADD_MODE))
            {
                entity.Tables[entity.TableName].Rows.Add(dr);
                _letterId = _letterBL.add(entity);
                _mode = Constants.EDIT_MODE;
                lblMsg.Text = "یک نامه جدید اضافه گردید";
                //btnLetterState_Click(null, null);
                
                int refUserTreeid = int.Parse(((ComboBoxItem)cmbReferenceUserId.Items[cmbReferenceUserId.SelectedIndex]).Value);
                _letterBL.updateRefferenceUser(_letterId, refUserTreeid);
                saveNextGeneratedNumber();
                DataChanged = true;
                
                //INSERT ATTACHEMENTS
                DialogResult dres = MessageBox.Show("آیا می خواهید به نامه جدیدی که اضافه شده فایلی الحاق یا اسکن نمایید؟", "", MessageBoxButtons.YesNo);
                if (dres.Equals(DialogResult.Yes))
                {
                    AttachmentList list = new AttachmentList(_letterId);
                    list.ShowDialog();
                }
            }
            else
            {
                dr[LetterEntity.FIELD_ID] = _letterId;
                if(_entity.get(LetterEntity.FIELD_USER_TREE_ID).ToString().Length > 0)
                    dr[LetterEntity.FIELD_USER_TREE_ID] = _entity.get(LetterEntity.FIELD_USER_TREE_ID);
                if (_entity.get(LetterEntity.FIELD_REFER_FROM_USER_ID).ToString().Length > 0)
                    dr[LetterEntity.FIELD_REFER_FROM_USER_ID] = int.Parse(_entity.get(LetterEntity.FIELD_REFER_FROM_USER_ID).ToString());
                
                object p = _entity.get(LetterEntity.FIELD_PREVIOUSLETTERID);
                if (p != null && p.ToString().Length> 0)
                    dr[LetterEntity.FIELD_PREVIOUSLETTERID] = p;
                object n = _entity.get(LetterEntity.FIELD_NEXTLETTERID);
                if (n != null && n.ToString().Length > 0)
                    dr[LetterEntity.FIELD_NEXTLETTERID] = n;

                entity.Tables[entity.TableName].Rows.Add(dr);

                
                _letterBL.update(entity);
                _letterBL.updateChainedArchives(_letterId, cbArchive.Checked, cbFinalConfirm.Checked, cbFastAction.Checked);
                lblMsg.Text = "به روز رسانی گردید";
                DataChanged = true;
            }
            this.Close();
            DataChanged = true;
        }

        private void saveNextGeneratedNumber()
        {
            if (cbOral.Checked)
            {
                LetterNumberPatternEntity entity = _letterNumberPatternBL.getOralPattern();
                if (LetterBL.LETTER_TYPE_RECIEVE.Equals(LetterType))
                    entity.Tables[entity.FilledTableName].Rows[0][LetterNumberPatternEntity.FIELD_LASTNUMBER_RECIEVE] = ((string[])cbOral.Tag)[1];
                else
                    entity.Tables[entity.FilledTableName].Rows[0][LetterNumberPatternEntity.FIELD_LASTNUMBER_SEND] = ((string[])cbOral.Tag)[1];
                entity.Tables[entity.FilledTableName].Rows[0][LetterNumberPatternEntity.FIELD_REGISTER_DATE] = DateTime.Now;
                _letterNumberPatternBL.update(entity);
            }
            else
            {
                string pId = UsersBS.loginedUser.get(UsersEntity.FIELD_LETTER_PATTERN_ID).ToString();

                LetterNumberPatternEntity entity = _letterNumberPatternBL.getById(int.Parse(pId));
                if (LetterBL.LETTER_TYPE_RECIEVE.Equals(LetterType))
                    entity.Tables[entity.FilledTableName].Rows[0][LetterNumberPatternEntity.FIELD_LASTNUMBER_RECIEVE] = ((string[])txtLetterNumber.Tag)[1];
                else
                    entity.Tables[entity.FilledTableName].Rows[0][LetterNumberPatternEntity.FIELD_LASTNUMBER_SEND] = ((string[])txtLetterNumber.Tag)[1];
                entity.Tables[entity.FilledTableName].Rows[0][LetterNumberPatternEntity.FIELD_REGISTER_DATE] = DateTime.Now;
                _letterNumberPatternBL.update(entity);
            }
        }

        private void txtUsersReplies_Click(object sender, EventArgs e)
        {
            int userid = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());

            UsersReplyForm form = new UsersReplyForm(userid, _letterId);
            form.ShowDialog();
            loadUsersReplies();
        }

        private void loadUsersReplies()
        {
            while (flowLayoutPanel1.Controls.Count > 0)
                flowLayoutPanel1.Controls.RemoveAt(0);
            refreshForm();
            if (Constants.ADD_MODE.Equals(_mode))
            {
                return;
            }

            UsersRelpyBL usersReplyBl = new UsersRelpyBL();
            UsersReplyEntity entity = null;

            UsersEntity userEntity = UsersBS.loginedUser;
            if (int.Parse(userEntity.get(UsersEntity.FIELD_USER_TYPE).ToString()).Equals(UsersBS.USER))
            {
               // int userid = int.Parse(userEntity.get(UsersEntity.FIELD_ID).ToString());
                entity = usersReplyBl.get(_letterId);
            }
            else
            {
                entity = usersReplyBl.get(_letterId);
            }

            int h = 0;
             int logginedUserId = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());

            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                string date = RMX_TOOLS.date.DateXFormer.gregorianToPersianString((DateTime)entity.get(i, UsersReplyEntity.FIELD_RESPONSEDATE));
                string text = entity.get(i, UsersReplyEntity.FIELD_DESCRIPTION).ToString();
                string username = entity.get(i, UsersReplyEntity.FIELD_USERID + UsersReplyEntity.DESC_QUALIFIRE).ToString();
                
                int ownerUserId = int.Parse(entity.get(i, UsersReplyEntity.FIELD_USERID).ToString());
               

                bool finalized = false;
                if(entity.get(i, UsersReplyEntity.FIELD_FINALIZED) != null && entity.get(i, UsersReplyEntity.FIELD_FINALIZED).ToString().Length >0)
                    finalized = bool.Parse(entity.get(i, UsersReplyEntity.FIELD_FINALIZED).ToString());
                Panel p = new Panel();
                p.Top = 0;
                p.Left = 0;
                p.Width = flowLayoutPanel1.Width;
               // p.Height = 100;
                p.BackColor = System.Drawing.SystemColors.AppWorkspace;
                
                RichTextBox rtBox = new RichTextBox();
                
                rtBox.Top = 0;
                //rtBox.AutoSize = true;
                //rtBox.Height = p.Height;
                rtBox.Multiline = true;
                rtBox.Width = p.Width - 170;

                rtBox.ScrollBars =  RichTextBoxScrollBars.None;
                rtBox.Show();
                rtBox.ReadOnly = true;
                rtBox.Left = p.Width - rtBox.Width-80;
                
                rtBox.BorderStyle = BorderStyle.FixedSingle;

                p.Controls.Add(rtBox);
                //Label
                Label lbl = new Label();
                lbl.Text = "پاسخ شماره " + (i + 1) + " : ";
                lbl.Top = 10;
                lbl.Left =p.Width - 90;
                lbl.Height = 40;
                lbl.Width = 90;
                lbl.AutoSize = false;
                p.Controls.Add(lbl);

                //Button
                if (!finalized && ownerUserId == logginedUserId)
                {
                    Button btn = new Button();
                    btn.Text = "ویرایش پاسخ";
                    btn.Click += new System.EventHandler(Button1Click);
                    btn.Tag = entity.get(i, UsersReplyEntity.FIELD_ID);
                    btn.Top = 10;
                    btn.Left = 10;
                    btn.Height = 25;
                    btn.Width = 80;
                    p.Controls.Add(btn);
                }
                //
                flowLayoutPanel1.Controls.Add(p);

                rtBox.Text = date + "         " + username + "\n" + text + "\n\n";
                rtBox.Height = rtBox.Lines.Length * 15;
                p.Height = rtBox.Height;
                h += p.Height + 5;
            }
            flowLayoutPanel1.Height = h;
        }

        private void Button1Click(object obj, EventArgs e)
        {

            int id = int.Parse(((Button)obj).Tag.ToString());
            UsersReplyForm form = new UsersReplyForm(id);
            form.ShowDialog();
            loadUsersReplies();

        }

        private void btnLetterState_Click(object sender, EventArgs e)
        {
            if (_letterId < 0)
            {
                MessageBox.Show("لطفا ابتدا نامه را ثبت نمایید سپس  فرم وضعیت را پر کنید");
                return;
            }
            int stateId = int.Parse(((ComboBoxItem)cmbLetterStateId.Items[cmbLetterStateId.SelectedIndex]).Value);
            if(stateId >=0) 
            {
                int userid = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
                LetterStateForm form = new LetterStateForm(_letterId,stateId, userid);
                form.CompanyName1 = txtCompany.Text;
                form.init();
                form.ShowDialog();
            }
        }

        private void btnReferToMasterUSer_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
            if (_letterId < 0)
                return;
            if (_entity != null && _entity.Tables[_entity.FilledTableName].Rows.Count > 0)
            {
                //نودی از درخت که نامه در دست وی است
                //ابتدا بررسی می کنیم که آیا کاربر وارد شده همان شخصی است که این نامه در دست وی است ،
                // اگر نبود یک سوال پرسیده خواهد شد.
                int userTreeId = -1;
                if (_entity.get(LetterEntity.FIELD_USER_TREE_ID).ToString().Length > 0)
                    userTreeId = int.Parse(_entity.get(LetterEntity.FIELD_USER_TREE_ID).ToString());

                bool iss = checkIsLetterUserEqualLogginedUser(userTreeId);
                if (!iss)
                {
                    DialogResult re = MessageBox.Show("نامه جاری در اختیار شما نمی باشد! آیا مایلید که نامه را  به شخص دیگری ارجاع نمایید ؟ ", "", MessageBoxButtons.YesNo);
                    if (re.Equals(DialogResult.No))
                        return;
                }

                RefferToForm form = new RefferToForm(txtRefferDate.Enabled);
                form.UserTreeId = userTreeId;
                form.LetterId = _letterId;
                form.RefferDate = txtRefferDate.Text;
                form.LoadForm();
                form.ShowDialog();
                if (form.IsRefferDone) 
                {
                    this.DataChanged = true;
                    this.Close();
                }
            }
        }

        private bool checkIsLetterUserEqualLogginedUser(int letterOwnerTreeNodeId) 
        {
            int loggindeUserId = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
            UserTreeBL userTree = new UserTreeBL();
            UserTreeEntity treeEntity =  userTree.get(letterOwnerTreeNodeId);
            if(treeEntity.Tables[treeEntity.FilledTableName].Rows.Count > 0) {
                int userId = int.Parse(treeEntity.get(UserTreeEntity.FIELD_USER_ID).ToString());
                if (userId.Equals(loggindeUserId))
                    return true;
            }
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LetterRefferencesForm form = new LetterRefferencesForm();
            form.initForm(_letterId);
            form.ShowDialog();
        }

        private void LetterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Close();
                return;
            }
            if (e.KeyCode.Equals(Keys.F1))
            {
                help.HelpForm form = new help.HelpForm();
                form.ShowDialog();

                return;
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String letterNumber = txtInputRegisterNumber.Text;
            int type = -1;

            if (LetterBL.LETTER_TYPE_RECIEVE.Equals(LetterType))
            {
                type = LetterBL.LETTER_TYPE_SEND;
            }
            else
            {
                type = LetterBL.LETTER_TYPE_RECIEVE;
            }

            LetterEntity entity = _letterBL.get(type, letterNumber, false);
            if (entity.Tables[entity.FilledTableName].Rows.Count <= 0)
            {
                MessageBox.Show("موردی یافت نشد!!");
            }
            else
            {
                int id = int.Parse(entity.get(LetterEntity.FIELD_ID).ToString());
                LetterForm form = new LetterForm(type);
                form.LetterId = id;
                form.initLetter(true);
                form.ShowDialog();
            }
        }

        private void linkAttachment_MouseClick(object sender, MouseEventArgs e)
        {
            AttachmentList list = new AttachmentList(_letterId);
            list.ShowDialog();
        }

        private void btnShowCompany_Click(object sender, EventArgs e)
        {
            if (txtCompany.Tag == null)
                txtCompany.Tag = 0;
            CompanyList list = new CompanyList();
            list.ReadOnly = true;
            list.Id = (int)txtCompany.Tag;
            list.initList();
            list.ShowDialog();
            txtCompany.Tag = list.Id;
            txtCompany.Text = CompanyBL.getCompanyName(list.Id);
        }

        private void cmbLetterStateId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLetterStateId.SelectedIndex >=0) {
                int id = BasicInfoUtil.getId("AgentsRequest");
                ComboBoxItem item = (ComboBoxItem)cmbLetterStateId.Items[cmbLetterStateId.SelectedIndex];
                if (item.Value.Length > 0 && int.Parse(item.Value) == id)
                {
                    pnlAgent.Visible = true;
                    btnLetterState.Enabled = false;
                }
                else
                {
                    pnlAgent.Visible = false;
                    btnLetterState.Enabled = true;
                }
            }
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

        private void txtCompany_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCompany_Click(object sender, EventArgs e)
        {

        }

        private void btnDoChainingToSend_Click(object sender, EventArgs e)
        {
            DoChaining(LetterBL.LETTER_TYPE_SEND, "لیست نامه های صادره");
        }

        private void btnDoChainingToRecive_Click(object sender, EventArgs e)
        {
            DoChaining(LetterBL.LETTER_TYPE_RECIEVE, "لیست نامه های وارده");
        }

        private void DoChaining(int letterType, string title)
        {
            lists.LetterList letterList = new lists.LetterList(letterType, true);
            letterList.DisableCbWithChain = true;
            letterList.init();
            letterList.Text = title;
            letterList.ShowDialog(this);
            object thisId = _entity.get(LetterEntity.FIELD_ID);

            if (letterList.ReturnLetterId <= 0)
                return;
            if (letterList.ReturnLetterId.Equals(thisId))
            {
                MessageBox.Show("نامه انتخاب شده نامه جاری است، لطفا مورد دیگری را انتخاب نمایید!");
                return;
            }

            bool isSelectedItemChainedThisLetter = isCurrentLetterChainedToSelectedLetter((int)thisId, letterList.ReturnLetterId);
            if (isSelectedItemChainedThisLetter)
            {
                MessageBox.Show("نامه انتخاب شده درحال حاضر به نامه جاری زنجیر گردیده است!");
                return;
            }
            bool isSelectedItemChained = isChainedToOtherLetter(letterList.ReturnLetterId);
            bool iscurrentLetterChainedToOther = isChainedToOtherLetter((int)thisId);

            if (isSelectedItemChained && iscurrentLetterChainedToOther)
            {//هر دو نمی تواند زنجیره باشند حتما فقط باید یکی یا هیچکدام زنجیره باشند
                MessageBox.Show("نامه انتخاب شده و نامه فعلی هر دو دارای زنجیره جداگانه هستند فعلا امکان زنجیره دو گروه زنجیره وجود ندارد");
                return;
            }

            DialogResult result = MessageBox.Show("آیا مایلید نامه انتخاب شده به نامه فعلی زنجیر گردد، با این عمل نامه انتخاب شده از لیست برداشته خواهد شد", "برنامه اتوماسیون اداری", MessageBoxButtons.YesNo);
            if (result.Equals(DialogResult.No))
                return;
            //attaching Letter
            LetterEntity newChainingLetter = _letterBL.getByLetterId(letterList.ReturnLetterId);

            object o = newChainingLetter.Tables[newChainingLetter.FilledTableName].Rows[0][LetterEntity.FIELD_LETTER_DATE];
            DateTime newchainingLetterDate = (DateTime)newChainingLetter.get(LetterEntity.FIELD_LETTER_DATE);

            LetterEntity chainedLetter = null;
            //LetterEntity newChainingLetter = null;

            if (isSelectedItemChained)
            {
                chainedLetter = newChainingLetter;
                newChainingLetter = _entity;
            }
            else
            {
                chainedLetter = _entity;
                //newChainingLetter = ;
            }
            //attch to letter

            chainedLetter = getLastLetter(chainedLetter);

            DateTime chainedLetterDate = (DateTime)chainedLetter.get(LetterEntity.FIELD_LETTER_DATE);
            newchainingLetterDate = (DateTime)newChainingLetter.get(LetterEntity.FIELD_LETTER_DATE);
            
            while (true)
            {
                int chainedLetterId = (int)chainedLetter.get(LetterEntity.FIELD_ID);
                int newChainingLetterrId = (int)newChainingLetter.get(LetterEntity.FIELD_ID);
                if (chainedLetterId == newChainingLetterrId)
                {
                    //ادعا می کنم که هیچ وقت این پیغام ظاهر نخواهد شد
                    MessageBox.Show("mistake in chaining. Please call system developer");
                } 

                if (newchainingLetterDate > chainedLetterDate)
                {
                    SewToNext(chainedLetter, newChainingLetter);
                    break;
                    //chainig complete
                }
                else
                {
                    object uo = chainedLetter.get(LetterEntity.FIELD_PREVIOUSLETTERID);
                    if (uo != null && uo.ToString().Length > 0)
                    {
                        int beforeLetterId = (int)uo;
                        chainedLetter = _letterBL.getByLetterId(beforeLetterId);
                        chainedLetterDate = (DateTime)chainedLetter.get(LetterEntity.FIELD_LETTER_DATE);
                    }
                    else
                    {
                        SewToPrior(chainedLetter, newChainingLetter);
                        break;
                    }
                }
            }
            updateChaningButtons();
            _dataChanged = true;
            setPaging();
        }

        private LetterEntity getLastLetter(LetterEntity entity)
        {
            object nextId = entity.get(LetterEntity.FIELD_NEXTLETTERID);
            if (nextId == null || nextId.ToString().Length <= 0)
                return entity;
            LetterEntity en = null;
            while (true)
            {
                en = _letterBL.getByLetterId((int)nextId);
                nextId = en.get(LetterEntity.FIELD_NEXTLETTERID);
                if (nextId == null || nextId.ToString().Length <= 0)
                    return en;
            }
        }

        private bool isCurrentLetterChainedToSelectedLetter(int currentLetter, int newSelectedLetter)
        {
            //LetterEntity entity = _letterBL.getByLetterId(currentLetter);
            //object priorId = entity.get(LetterEntity.FIELD_PREVIOUSLETTERID);
            //object nextId = entity.get(LetterEntity.FIELD_NEXTLETTERID);

            //return ((priorId != null && priorId.ToString().Length > 0 && newSelectedLetter == (int)priorId) ||
            //    (nextId != null && nextId.ToString().Length > 0 && newSelectedLetter == (int)nextId));

            string all = _letterBL.getAllChainedsByLetterId(currentLetter);
            return (all + ",").IndexOf(newSelectedLetter + ",") >= 0;
        }

        private bool isChainedToOtherLetter(int letterid)
        {
            LetterEntity entity = _letterBL.getByLetterId(letterid);
            object priorId = entity.get(LetterEntity.FIELD_PREVIOUSLETTERID);
            object nextId = entity.get(LetterEntity.FIELD_NEXTLETTERID);

            return ((priorId != null && priorId.ToString().Length > 0) ||
                (nextId != null && nextId.ToString().Length > 0));
        }

        private void SewToNext(LetterEntity chainedLetter, LetterEntity newChainig)
        {
            object n = chainedLetter.get(LetterEntity.FIELD_NEXTLETTERID);
            if (n != null && n.ToString().Length > 0)
            {
                _letterBL.UpdateNextLetter((int)newChainig.get(LetterEntity.FIELD_ID), (int)n);
                _letterBL.UpdatePriorLetter((int)n, (int)newChainig.get(LetterEntity.FIELD_ID));
            }

            _letterBL.UpdatePriorLetter((int)newChainig.get(LetterEntity.FIELD_ID) ,(int)chainedLetter.get(LetterEntity.FIELD_ID));
            _letterBL.UpdateNextLetter((int)chainedLetter.get(LetterEntity.FIELD_ID) ,(int)newChainig.get(LetterEntity.FIELD_ID));
            
            _entity = _letterBL.getByLetterId((int)chainedLetter.get(LetterEntity.FIELD_ID));
        }

        private void SewToPrior(LetterEntity chainedLetter, LetterEntity newChainig)
        {
            object p = chainedLetter.get(LetterEntity.FIELD_PREVIOUSLETTERID);
            if (p != null && p.ToString().Length > 0)
            {
                _letterBL.UpdatePriorLetter((int)newChainig.get(LetterEntity.FIELD_ID), (int)p);
                _letterBL.UpdateNextLetter((int)p, (int)newChainig.get(LetterEntity.FIELD_ID));
            }

            _letterBL.UpdatePriorLetter((int)chainedLetter.get(LetterEntity.FIELD_ID), (int)newChainig.get(LetterEntity.FIELD_ID));
            _letterBL.UpdateNextLetter((int)newChainig.get(LetterEntity.FIELD_ID), (int)chainedLetter.get(LetterEntity.FIELD_ID));

            _entity = _letterBL.getByLetterId((int)chainedLetter.get(LetterEntity.FIELD_ID));
        }

        private void btnLastLetter_Click(object sender, EventArgs e)
        {
            loadLetter(getLastLetter(_entity));
        }

        private void loadLetter(LetterEntity entity)
        {
            refreshForm();
            _entity = entity;
            object t = _entity.get(LetterEntity.FIELD_ID);
            LetterId = (int)t;
            LetterType = int.Parse(_entity.get(LetterEntity.FIELD_LETTER_TYPE).ToString());
            initLetter();
          

        }

        private void refreshForm()
        {
            panel3.VerticalScroll.Value = 0;
            panel3.AutoScrollPosition = new Point(0, 0);
            panel3.Update();
            panel3.Refresh();
        }

        private void btnNextLetter_Click(object sender, EventArgs e)
        {
            object t = _entity.get(LetterEntity.FIELD_NEXTLETTERID);
            if (t != null && t.ToString().Length > 0) {
                
                loadLetter(_letterBL.getByLetterId((int)t));
            }
            
        }

        private void btnPriorLetter_Click(object sender, EventArgs e)
        {
            object t = _entity.get(LetterEntity.FIELD_PREVIOUSLETTERID);
            if (t != null && t.ToString().Length > 0)
                loadLetter(_letterBL.getByLetterId((int)t));
           
        }

        private void updateChaningButtons()
        {
            object prior = _entity.get(LetterEntity.FIELD_PREVIOUSLETTERID);
            object next = _entity.get(LetterEntity.FIELD_NEXTLETTERID);
            object id = _entity.get(LetterEntity.FIELD_ID);


            if (prior == null || prior.ToString().Length <= 0)
                btnPriorLetter.Enabled = false;
            else
            {
                if (prior == id)
                {
                    _letterBL.UpdatePriorLetter((int)id, -1);
                }else
                    btnPriorLetter.Enabled = true;
            }
            if (next == null || next.ToString().Length <= 0)
            {
                btnNextLetter.Enabled = false;
                btnLastLetter.Enabled = false;
            }
            else
            {
                if (next == id)
                {
                    _letterBL.UpdateNextLetter((int)id, -1);
                }
                else
                {
                    btnNextLetter.Enabled = true;
                    btnLastLetter.Enabled = true;
                }
            }

            btnSeperateFromChain.Enabled = !((prior == null || prior.ToString().Length <= 0) &&
                (next == null || next.ToString().Length <= 0));

            //disable fastAction and Archive Button
            if ((next == null || next.ToString().Length <= 0))
            {
                cbFastAction.Enabled = true;
                cbArchive.Enabled = true;

                doPerm(cbArchive, m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_ARCHIVE));
                doPerm(cbFastAction, m_permissionEntity.get(LetterItemsPermissionEntity.FIELD_FASTACTION));

            }
            else
            {
                cbFastAction.Enabled = false;
                cbArchive.Enabled = false;
            }
        }

        private void btnSeperateFromChain_Click(object sender, EventArgs e)
        {
            object this_next = _entity.get(LetterEntity.FIELD_NEXTLETTERID);
            object this_prev = _entity.get(LetterEntity.FIELD_PREVIOUSLETTERID);
            object this_id = _entity.get(LetterEntity.FIELD_ID);

            if ((this_next == null || this_next.ToString().Length <=0)&&
                (this_prev == null || this_prev.ToString().Length <=0))
            {
                return;
            }

            DialogResult result = MessageBox.Show("آیا از جدا کردن این نامه از زنجیره مطمئن هستید ؟ ", "برنامه اتوماسیون اداری", MessageBoxButtons.YesNo);
            if (result.Equals(DialogResult.No))
                return;

            if ((this_next != null && this_next.ToString().Length > 0) && // in the middle
                (this_prev != null && this_prev.ToString().Length > 0))
            {
                //آنهایی که چسبیده اند
                _letterBL.UpdateNextLetter(int.Parse(this_prev.ToString()), int.Parse(this_next.ToString()));
                _letterBL.UpdatePriorLetter(int.Parse(this_next.ToString()), int.Parse(this_prev.ToString()));
                //لینک های این نامه
                _letterBL.UpdatePriorLetter(int.Parse(this_id.ToString()), -1);
                _letterBL.UpdateNextLetter(int.Parse(this_id.ToString()), -1);

            }
            else if (this_next == null || this_next.ToString().Length <= 0)
            {
                //چسبیده ها
                _letterBL.UpdateNextLetter(int.Parse(this_prev.ToString()), -1);
                //خود نامه
                _letterBL.UpdatePriorLetter(int.Parse(this_id.ToString()), -1);

            }
            else
            {
                //چسبیده ها
                _letterBL.UpdatePriorLetter(int.Parse(this_next.ToString()), -1);
                //خود نامه
                _letterBL.UpdateNextLetter(int.Parse(this_id.ToString()), -1);
            }
            _entity = _letterBL.getByLetterId((int)this_id);
            updateChaningButtons();
            _dataChanged = true;
        }

        private void cbOral_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOral.Checked)
                txtLetterNumber.Text = ((string[])cbOral.Tag)[0];
            else
                txtLetterNumber.Text = ((string[])txtLetterNumber.Tag)[0];
        }

        private void setPaging()
        {
            string s = _letterBL.getAllChainedsByLetterId(_letterId);
            string[] arr = s.Split(new char[] { ',' });
            int n = arr.Length;
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (int.Parse(arr[i]) == _letterId)
                {
                    k = i;
                    break;
                }
            }

            k = n - k;
            lblPaging.Text ="نامه " + k + " از " + n;
        }

        private void btnShowChains_Click(object sender, EventArgs e)
        {
            string s = _letterBL.getAllChainedsByLetterId(_letterId);
            LetterSimpleList list = new LetterSimpleList(s);
            list.Show();
        }

        private void txtRefferDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void linkAttachment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnGroupList_Click(object sender, EventArgs e)
        {
            if (_entity.get(LetterEntity.FIELD_GROUP_ID) != null &&
                !"".Equals(_entity.get(LetterEntity.FIELD_GROUP_ID)))
            {
                int groupid = int.Parse(_entity.get(LetterEntity.FIELD_GROUP_ID).ToString());
                LetterGroupList groupList = new LetterGroupList();
                groupList.initList(groupid);
                groupList.ShowDialog();
            }else
            {
                MessageBox.Show("این نامه عضو گروه نامه ای نمی باشد");
            }
        }

        private void btnAddToGroup_Click(object sender, EventArgs e)
        {
            LetterGroupSelect letterGroupSelect = new LetterGroupSelect();
            letterGroupSelect.initList();
            letterGroupSelect.ShowDialog();
            int letterGroupId = letterGroupSelect.Id;

            if (letterGroupId > 0)
            {
                _letterBL.addLetterGroup(_letterId, letterGroupId);
                _entity = _letterBL.getByLetterId(_letterId);
                btnAddToGroup.Enabled = false;
                BtnDeleteFromGroup.Enabled = true;
            }
        }

        private void BtnDeleteFromGroup_Click(object sender, EventArgs e)
        {
            //INSERT ATTACHEMENTS
            DialogResult dres = MessageBox.Show(" آیا از جدا کردن این نامه از  گروه مطمئن هستید ؟ ", "", MessageBoxButtons.YesNo);
            if (dres.Equals(DialogResult.Yes))
            {
                int letterGroupId = int.Parse(_entity.get(LetterEntity.FIELD_GROUP_ID).ToString());
                _letterBL.removeFromGroup(_letterId, letterGroupId);
                _entity = _letterBL.getByLetterId(_letterId);
                btnAddToGroup.Enabled = true;
                BtnDeleteFromGroup.Enabled = false;
            }
        }
    }
}
