using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;
using RMX_TOOLS.global;
using AndicatorCommon;
using RMX_TOOLS.converter;
using AndicatorBLL;
using Andicator.lists;

namespace Andicator.controls
{
    public partial class LetterStateForm : Form
    {
        #region variables
        
        private int _letterid = -1;
        private int _index = 0;
        private string _mode = Constants.ADD_MODE;
        private int _letterStateBasicInfoId = -1;
        private int _userid;
        private LetterStateBL _letterStateBL;
        private LetterStateEntity _entity;

        private static object[,] array = new object[7, 3] {
                    {BasicInfoUtil.getId("RateDeclare"), "شماره بیمه نامه ", "تاریخ بیمه نامه"},
                    {BasicInfoUtil.getId("RateDeclareOral"), "شماره بیمه نامه ", "تاریخ بیمه نامه"},
                    {BasicInfoUtil.getId("IssuingAmendment"),"شماره الحاقیه", "تاریخ صدور الحاقیه"},
                    {BasicInfoUtil.getId("DamageDeclare"), "شماره حواله خسارت صادره", "تاریخ حواله"},
                    {BasicInfoUtil.getId("DamageTreatment"), "شماره حواله صادره", "تاریخ حواله"},
                    {BasicInfoUtil.getId("AgentsRequest"), "", ""},
                    {BasicInfoUtil.getId("other"), "", ""}}; 

        #endregion

        public LetterStateForm(int letterid, int letterStateBasicInfoId, int userid)
        {
            _letterid = letterid;
            _letterStateBasicInfoId = letterStateBasicInfoId;
            _userid = userid;
            
            InitializeComponent();

            _letterStateBL = new LetterStateBL();
           
            
        }
        #region properties
        private string _companyName = "";

        public string CompanyName1
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

   
        #endregion

        private void loadData()
        {
            _entity =  _letterStateBL.get(_letterid);
            if (_entity == null)
                return;
            
            txtCompany.Text = CompanyName1;

            if (_entity.RowCount() > 0)
            {
                _mode = Constants.EDIT_MODE;
                txtDate.Text = RMX_TOOLS.date.DateXFormer.gregorianToPersianString((DateTime)_entity.get(LetterStateEntity.FIELD_DATE));
                txtNumber.Text = _entity.get(LetterStateEntity.FIELD_NUMBER).ToString();
                txtDescription.Text = _entity.get(LetterStateEntity.FIELD_DESCRIPTION).ToString();
            }
            else
            {
                _mode = Constants.ADD_MODE;
                //_entity = null;
            }
           // txtCompany.Tag = 0;
           // if (_entity.get(LetterEntity.FIELD_COMPANY_ID).ToString().Length > 0)
           // {
           //     txtCompany.Tag = (int)_entity.get(LetterEntity.FIELD_COMPANY_ID);
           //     txtCompany.Text = CompanyBL.getCompanyName((int)txtCompany.Tag);

          //  }
            

        }

        public void init()
        {
            if (((int)array[0, 0]).Equals(_letterStateBasicInfoId) ||
                 ((int)array[1, 0]).Equals(_letterStateBasicInfoId))
                pnlCompany.Visible = true;
            else
                pnlCompany.Visible = false;
            
            for(int i = 0; i < 6;i++)
                if (((int)array[i, 0]).Equals(_letterStateBasicInfoId))
                {
                    _index = i;
                    break;
                }
            if ((string)array[_index, 1].ToString().Trim() != "")
            {
                lblNumber.Text = (string)array[_index, 1] + " : ";
            }
            else
            {
                lblNumber.Text = (string)array[0, 1] + " : ";
            }
            if ((string)array[_index, 2].ToString().Trim() != "")
            {
                lblDate.Text = (string)array[_index, 2] + " : ";
            }
            else
            {
                lblDate.Text = (string)array[0, 2] + " : ";
            }
            lblDescription.Text = "توضیحات" + " : ";

            loadData();
        }

        private bool BeforSave()
        {
            bool b;
            b = FormChecker.CheckDate(txtDate, lblDate);
            b &= FormChecker.CheckEmpty(txtNumber, lblNumber);

            return b;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!BeforSave())
                return;

            DataRow dr;
            if (_mode.Equals(Constants.ADD_MODE))
            {
                _entity = new LetterStateEntity();
                dr = _entity.Tables[_entity.TableName].NewRow();
            }
            else
            {
                if (_entity.FilledTableName == "")
                    _entity.FilledTableName = _entity.TableName;
                dr = _entity.Tables[_entity.FilledTableName].Rows[0];
            }
            DateConverter dateConverter = new DateConverter();

            dr[LetterStateEntity.FIELD_USERID] = _userid;
            dr[LetterStateEntity.FIELD_LETTERID] = _letterid;
            dr[LetterStateEntity.FIELD_DATE] = dateConverter.stringToValue(txtDate.Text);
            dr[LetterStateEntity.FIELD_NUMBER] = txtNumber.Text;
            dr[LetterStateEntity.FIELD_DESCRIPTION] = txtDescription.Text;
            //dr[LetterStateEntity.FIELD_COMPANYID] = txtCompany.Tag;
            if (_mode.Equals(Constants.ADD_MODE))
            {
                _entity.Tables[_entity.TableName].Rows.Add(dr);
                _letterStateBL.add(_entity);
                lblMsg.Text = "دخیره گردید";
                _mode = Constants.EDIT_MODE;
            }
            else
            {
                _letterStateBL.update(_entity);
                lblMsg.Text = "تغییرات به روز رسانی گردید";
            }
        }

        private void LetterStateForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
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

    }
}
