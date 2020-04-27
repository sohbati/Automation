using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorBLL;
using Andicator.controls;
using Andicator.hasti.basicInfo;
using AndicatorCommon;
using RMX_TOOLS.data.grid;
using System.Collections;
using Andicator.setting;
using Andicator.lists;
using RMX_TOOLS.hasti.bll;
namespace Andicator
{
    public partial class MainForm : Form
    {
        private LetterBL _letterBL;
        private ChequeBL _chequeBL;
        private GridTools _gridTools;

        private int _fastActionCount = 0;

        public MainForm()
        {
            InitializeComponent();

            _letterBL = new LetterBL();
            _chequeBL = new ChequeBL();
            _gridTools = new GridTools();
            gridSends.Tag = LetterBL.LETTER_TYPE_SEND;
            gridRecieveds.Tag = LetterBL.LETTER_TYPE_RECIEVE;
        }


        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuResivedLetter_Click(object sender, EventArgs e)
        {
            lists.LetterList letterList = new lists.LetterList(LetterBL.LETTER_TYPE_RECIEVE);
            letterList.init();
            letterList.Text = "لیست نامه های وارده";
            letterList.ShowDialog(this);
            FillGrids();
        }

        private void mnuSendLetter_Click(object sender, EventArgs e)
        {
            lists.LetterList letterList = new lists.LetterList(LetterBL.LETTER_TYPE_SEND);
            letterList.init();
            letterList.Text = "لیست نامه های صادره";
            letterList.ShowDialog(this);
            FillGrids();
        }

        private void UsersMenuItem_Click(object sender, EventArgs e)
        {
            controls.UserForm form = new controls.UserForm();
            form.ShowDialog(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckBank();
            if (Login())
            {
                FillGrids();
                setPermision();
                setAlarmRefreshTime();
            }
        }

        private void setAlarmRefreshTime()
        {
            if (RMX_TOOLS.data.Config.provider.connectionStatus)
            {
                ApplicationPropertiesBL app = new ApplicationPropertiesBL();
                string s = app.getValue(ApplicationPropertiesBL.ALARM_LIST_REFRESH_TIME);
                if (s != null && s.Length > 0)
                {
                    timer1.Interval = int.Parse(s) * 60 * 1000;
                }
            }
        }

        private void setPermision()
        {
            if (UsersBS.loginedUser != null && UsersBS.ADMIN.ToString().Equals(UsersBS.loginedUser.get(UsersEntity.FIELD_USER_TYPE).ToString()))
            {
                mnuResivedLetter.Enabled = true;
                mnuSendLetter.Enabled = true;
                mnuChequeInfo.Enabled = true;
                mnuUsers.Enabled = true;
                mnuBasicInfo.Enabled = true;
                mnuColorSetting.Enabled = true;
                mnuCompanies.Enabled = true;
                mnuServerSetting.Enabled = true;
                mnuLetterPatternDefine.Enabled = true;
                MnuUserTree.Enabled = true;
                mnuAgent.Enabled = true;
                pnlWorkingStatistic.Visible = true;
                mnuReferCycleList.Visible = true;
                LetterListByAnswerCount.Visible = true;
                return;
            }

            UserPropertiesEntity entity = UsersBS.LogginedUserProperties;
            UserpropertiesBL userProperties = new UserpropertiesBL();
            bool recievedLetterPerm = false;
            bool sendLetterPerm = false;
            bool chequeInfo = false;
            bool usersPerm = false;
            bool basicInfoPerm = false;
            bool companyPerm = false;
            bool colorPerm = false;
            bool agentPerm = false;
            bool workingStatisticPerm = false;
            bool referenceCycle = false;
            bool letterListByAnswerCount = false;

            //recieved letters
            string v = userProperties.getValue(entity, UserpropertiesBL.MENU_RECIEVED_PERMISSION);
            if (v != null) recievedLetterPerm = bool.Parse(v);
            //send letters
            v = userProperties.getValue(entity, UserpropertiesBL.MENU_SEND_PERMISSION);
            if (v != null) sendLetterPerm = bool.Parse(v);
            //Cheque info
            v = userProperties.getValue(entity, UserpropertiesBL.MENU_CHEQUE_INFO);
            if (v != null) chequeInfo = bool.Parse(v);
            //users
            v = userProperties.getValue(entity, UserpropertiesBL.MENU_USERS_PERMISSION);
            if (v != null) usersPerm = bool.Parse(v);
            //basicInfo
            v = userProperties.getValue(entity, UserpropertiesBL.MENU_BASIC_INFO_PERMISSION);
            if (v != null) basicInfoPerm = bool.Parse(v);
            //company
            v = userProperties.getValue(entity, UserpropertiesBL.MENU_COMPANY_PERMISSION);
            if (v != null) companyPerm = bool.Parse(v);
            //color
            v = userProperties.getValue(entity, UserpropertiesBL.MENU_COLOR_PERMISSION);
            if (v != null) colorPerm = bool.Parse(userProperties.getValue(entity, UserpropertiesBL.MENU_COLOR_PERMISSION));
            //agent
            v = userProperties.getValue(entity, UserpropertiesBL.MENU_AGENT_PERMISSION);
            if (v != null) agentPerm = bool.Parse(v);
            //working statistis
            v = userProperties.getValue(entity, UserpropertiesBL.MENU_WORKING_STATISTIC);
            if (v != null) workingStatisticPerm = bool.Parse(v);
            //working statistis
            v = userProperties.getValue(entity, UserpropertiesBL.MENU_REFERENCE_CYCLE);
            if (v != null) referenceCycle = bool.Parse(v); else referenceCycle = false;
            //answer count  list
            v = userProperties.getValue(entity, UserpropertiesBL.MENU_LETTER_ANSWER_COUNTLIST);
            if (v != null) letterListByAnswerCount = bool.Parse(v); else letterListByAnswerCount = false;       
            
            mnuResivedLetter.Enabled = recievedLetterPerm;
            mnuSendLetter.Enabled = sendLetterPerm;
            mnuChequeInfo.Enabled = chequeInfo;
            mnuUsers.Enabled = usersPerm;
            mnuBasicInfo.Enabled = basicInfoPerm;
            mnuColorSetting.Enabled = colorPerm;
            mnuCompanies.Enabled = companyPerm;
            mnuAgent.Enabled = agentPerm;
            pnlWorkingStatistic.Visible = workingStatisticPerm;
            mnuReferCycleList.Visible = referenceCycle;
            LetterListByAnswerCount.Visible = letterListByAnswerCount;

            //disable for all but they are enabled only for admins
            mnuServerSetting.Enabled = false;
            mnuLetterPatternDefine.Enabled = false;
            MnuUserTree.Enabled = false;
            
            /*     if (UsersBS.loginedUser != null && UsersBS.USER.ToString().Equals(UsersBS.loginedUser.get(UsersEntity.FIELD_USER_TYPE).ToString()))
                 { // کاربر معمولی
                     mnuResivedLetter.Enabled = false;
                     mnuSendLetter.Enabled = false;
                     mnuUsers.Enabled = false;
                     mnuBasicInfo.Enabled = false;
                     mnuServerSetting.Enabled = false;
                     mnuLetterPatternDefine.Enabled = false;
                     mnuColorSetting.Enabled = false;
                     mnuCompanies.Enabled = false;
                 }
                 else if (UsersBS.loginedUser != null && UsersBS.MASTER_USER.ToString().Equals(UsersBS.loginedUser.get(UsersEntity.FIELD_USER_TYPE).ToString()))
                 {
                     mnuUsers.Enabled = false;
                     mnuBasicInfo.Enabled = false;
                     mnuServerSetting.Enabled = false;
                     mnuLetterPatternDefine.Enabled = false;
                     mnuColorSetting.Enabled = false;
                     mnuCompanies.Enabled = true;
                 }
                 else
                 {
                     mnuResivedLetter.Enabled = true;
                     mnuSendLetter.Enabled = true;
                     mnuUsers.Enabled = true;
                     mnuBasicInfo.Enabled = true;
                     mnuServerSetting.Enabled = true;
                     mnuLetterPatternDefine.Enabled = true;
                     mnuColorSetting.Enabled = true;
                     mnuCompanies.Enabled = true;

                 }*/
            
        }

        private void FillGrids() 
        {
            if (UsersBS.loginedUser != null && UsersBS.loginedUser.get(UsersEntity.FIELD_ID) != null)
            {
                int userid = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());

                LetterEntity entityRecieve = _letterBL.get(LetterBL.LETTER_TYPE_RECIEVE, false, userid, true);
                LetterEntity entitySend = _letterBL.get(LetterBL.LETTER_TYPE_SEND, false, userid, true);

                ChequeEntity entityCheque = _chequeBL.get("(" +ChequeEntity.FIELD_PRICE + "<>" + ChequeEntity.VIEW_FIELD_REMAINED + 
                    " OR " + ChequeEntity.VIEW_FIELD_REMAINED + " IS NULL)" ,false, userid);

                System.Collections.Hashtable hash = new Hashtable();
                hash.Add("colorField", "COLOR");

                _gridTools.bindDataToGrid(gridRecieveds, entityRecieve, new GridTools.changingRow(_gridTools.changeColor), hash);

                System.Collections.Hashtable hash2 = new Hashtable();
                hash2.Add("colorField", "COLOR_1");

                _gridTools.bindDataToGrid(gridSends, entitySend, new GridTools.changingRow(_gridTools.changeColor), hash2);

                //checque
                System.Collections.Hashtable hash3 = new Hashtable();
                hash3.Add("colorField", "COLOR_2");

                _gridTools.bindDataToGrid(chequeGridView, entityCheque, new GridTools.changingRow(_gridTools.changeColor), hash3);

                fastActionCheckBank_Tick(null, null);
            }
        }

        private void CheckBank()
        {
            if (RMX_TOOLS.data.Config.provider.connectionStatus == false)
            {
                MessageBox.Show("اطلاعات بانک اطلاعاتی درست تنظیم نشده");
                new SettingForm().ShowDialog();
                Application.Exit();
            }
        }

        private bool Login()
        {
            LoginForm lFrm = new LoginForm();
            lFrm.ShowDialog();

            if (!LoginForm._loggined)
            {
                Application.Exit();
                return false;
            }
            else
                this.Text = "" +  UsersBS.loginedUser.get(UsersEntity.FIELD_NAME) + " " + UsersBS.loginedUser.get(UsersEntity.FIELD_FAMILY);
            return true;
        }

        private void mnuServerSetting_Click(object sender, EventArgs e)
        {
            controls.SettingForm form = new SettingForm();
            form.ShowDialog();
        }

        private void mnuBasicInfo_Click(object sender, EventArgs e)
        {
            BasicInfoList list = new BasicInfoList();
            list.ShowDialog();
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            
            DataGridView gv = (DataGridView)sender;

            if (gv.SelectedCells.Count > 0)
            {
                DataGridViewColumn col = gv.Columns[gv.SelectedCells[0].ColumnIndex];

                if (col.DataGridView.SelectedCells.Count > 0 && gv.SelectedCells[0].Selected)
                {
                    DataGridViewRow dr = gv.SelectedCells[0].OwningRow;
                    int id = -1;
                    if (gv.Tag.Equals(LetterBL.LETTER_TYPE_SEND))
                    {
                        id = int.Parse(dr.Cells[LetterEntity.FIELD_ID + "_1"].Value.ToString());
                    }
                    else
                    {
                        id = int.Parse(dr.Cells[LetterEntity.FIELD_ID].Value.ToString());
                    }
                    LetterForm form = new LetterForm((int)gv.Tag);
                    form.LetterId = id;
                    form.initLetter();
                    form.ShowDialog();
                    if (form.DataChanged)
                        FillGrids();
                }
            }
        }

        private void mnuLetterPatternDefine_Click(object sender, EventArgs e)
        {
            LetterPatternDesignList form = new LetterPatternDesignList();
            form.initList();
            form.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillGrids();
        }

        private void mnuColorSetting_Click(object sender, EventArgs e)
        {
            ColorSetting form = new ColorSetting();
            form.ShowDialog();  
            FillGrids();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FillGrids();
        }

        private void mnuChangeUser_Click(object sender, EventArgs e)
        {
            LoginForm lFrm = new LoginForm();
            lFrm.ShowDialog();

            if (!LoginForm._loggined)
            {
                //Do nothing
                fastActionCheckBank_Tick(null, null);
            }
            else
            {
                this.Text = UsersBS.loginedUser.get(UsersEntity.FIELD_NAME) + " " + UsersBS.loginedUser.get(UsersEntity.FIELD_FAMILY);
                FillGrids();
                setPermision();
            }
        }

        private void mnuCompanies_Click(object sender, EventArgs e)
        {
            CompanyList list = new CompanyList();
            list.ShowDialog();
        }

        private void MnuUserTree_Click(object sender, EventArgs e)
        {
            UsersTreeForm form = new UsersTreeForm();
            form.loadTree();
            form.ShowDialog();
        }

        private void mnuChequeInfo_Click(object sender, EventArgs e)
        {
            ChequeList list = new ChequeList();
            list.initList();
            list.ShowDialog();
            FillGrids();
        }

        private void mnuAgent_Click(object sender, EventArgs e)
        {
            ReferenceCycleList list = new ReferenceCycleList();
            list.ShowDialog();
        }

        private void pnlWorkingStatistic_Click(object sender, EventArgs e)
        {
            UsersWorkingStattisticList list = new UsersWorkingStattisticList();
            list.Left = 20;
            list.Top = 100;
            list.fillGrid();
            list.ShowDialog();

        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            DataGridView gv = (DataGridView)sender;
            if (gv.SelectedCells.Count > 0)
            {
                DataGridViewColumn col = gv.Columns[gv.SelectedCells[0].ColumnIndex];

                if (col.DataGridView.SelectedCells.Count > 0 && gv.SelectedCells[0].Selected)
                {
                    DataGridViewRow dr = gv.SelectedCells[0].OwningRow;
                    int id = -1;
                    id = int.Parse(dr.Cells[ChequeEntity.FIELD_ID + "_2"].Value.ToString());
                    ChequeForm form = new ChequeForm(id);
                    form.initForm();
                    form.ShowDialog();
                    if (form.DataChanged1)
                        FillGrids();
                }
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            about.About about = new about.About();
            about.ShowDialog();
        }

        private void chequeGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fastActionCheckBank_Tick(object sender, EventArgs e)
        {
            try { 
                _fastActionCount = _letterBL.getFastActionCount(false);
                if (_fastActionCount > 0)
                {
                    fastActionTimer.Enabled = true;
                    pnlFastDo.Visible = true;
                }else{
                    fastActionTimer.Enabled = false;
                    pnlFastDo.Visible = false;

                }
            }catch(Exception ex){

            }
        }

        private void fastActionTimer_Tick(object sender, EventArgs e)
        {
            if (!LoginForm._loggined)
                return;
            if (_fastActionCount <= 0)
                pnlFastDo.Visible = false;
            else
                pnlFastDo.Visible = !pnlFastDo.Visible;
        }

        private void pnlFastDo_Click(object sender, EventArgs e)
        {
            int userid = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
            FastDoForm form = new FastDoForm(userid);
            form.ShowDialog();

        }

        private void mnuReferCycleList_Click(object sender, EventArgs e)
        {
            RefCycleList list = new RefCycleList();
            list.ShowDialog();
        }

        private void LetterListByAnswerCount_Click(object sender, EventArgs e)
        {
            LetterAnswerCountList list = new LetterAnswerCountList();
            list.ShowDialog();
        }

        private void mnuLetterGroup_Click(object sender, EventArgs e)
        {
            LetterGroup letterGroup = new LetterGroup();
            letterGroup.initList();
            letterGroup.ShowDialog();
        }
    }
}
