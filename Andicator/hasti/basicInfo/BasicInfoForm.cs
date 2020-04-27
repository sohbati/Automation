using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMX_TOOLS.hasti.entity;
using RMX_TOOLS.hasti.bll;
using RMX_TOOLS.global;
using RMX_TOOLS.hasti.tools;

namespace Andicator.hasti.basicInfo
{
    public partial class BasicInfoForm : Form
    {
        #region properties
        private BasicInfoEntity _entity;

        public BasicInfoEntity BasicInfoEntity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        private int _parentId = -1;

        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }


        private int _id = -1;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _mode;

        public string Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        #endregion

        #region variables

        private BasicInfoBL _basicInfoBL;
        #endregion
        public BasicInfoForm()
        {

            InitializeComponent();
            _basicInfoBL = new BasicInfoBL();

        }

        public void intiForm() 
        {
            if (Constants.DELETE_MODE.Equals(Mode))
            {
                pnlContainer.Visible = false;
                btnSave.Visible = false;
                if (Id < 0)
                {
                    return;
                }
                _entity = _basicInfoBL.get(_id);
                string s = _entity.get(BasicInfoEntity.FIELD_USERCANCHANGE).ToString();
                bool b = false;
                if (s != null && s.Length > 0)
                {
                    b = Boolean.Parse(s);
                }
                if (b)
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "امکان حذف این مورد وجود ندارد";
                    return;
                }
                doDelete();
                return;
            }
            if (_entity != null)
            {
                _id = int.Parse(_entity.get(BasicInfoEntity.FIELD_ID).ToString());
                _mode = RMX_TOOLS.global.Constants.EDIT_MODE;
            }
            else if (_id > 0)
            {
                _mode = RMX_TOOLS.global.Constants.EDIT_MODE;
               _entity = _basicInfoBL.get(_id);
               loadForm();
            }else {
                _mode = RMX_TOOLS.global.Constants.ADD_MODE;
                _entity = new BasicInfoEntity();
            }
        
        }

        private void doDelete() 
        {
            _basicInfoBL.delete(_id);
            lblMsg.Text = "حذف گردید!";
        }
        private void loadForm()
        {
            lblMsg.Text = "";
            txtDescription.Text = _entity.get(BasicInfoEntity.FIELD_DESCRIPTION).ToString();
            
            Boolean b = Boolean.Parse(_entity.get(BasicInfoEntity.FIELD_ACTIVE).ToString());
            cmbActive.SelectedIndex = (b? 0 : 1);

            string s = _entity.get(BasicInfoEntity.FIELD_CONTAINUNKNOWN).ToString();
            cmbContainsUnknown.SelectedIndex = ((s != null && s.Trim().Length > 0) ? (Boolean.Parse(s.ToString()) ?0 :1) : 1);

        }

        private bool BeforSave()
        {
            bool b = true;
            b &= FormChecker.CheckEmpty(txtDescription, lblDescription);

            return b;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!BeforSave())
                return;

            DataRow dr;
            if (_id < 0)
            {
                dr = _entity.Tables[_entity.TableName].NewRow();
                dr[BasicInfoEntity.FIELD_PARENT_ID] = ParentId;
            }
            else {
                _entity.FilledTableName = _entity.FilledTableName == null || _entity.FilledTableName.Length <= 0 ? _entity.TableName : _entity.FilledTableName;
                dr = _entity.Tables[_entity.FilledTableName].Rows[0];
            }
            dr[BasicInfoEntity.FIELD_DESCRIPTION] = txtDescription.Text;
            int s = cmbActive.SelectedIndex;
            dr[BasicInfoEntity.FIELD_ACTIVE] = (s == 0? true : false);

            s = cmbContainsUnknown.SelectedIndex;
            dr[BasicInfoEntity.FIELD_CONTAINUNKNOWN] = (s == 0 ? true : false);
            if (_id < 0)
            {
                _entity.Tables[_entity.TableName].Rows.Add(dr);
                _id = _basicInfoBL.add(_entity);
                lblMsg.Text = "ذخیره شد";
            }
            else
            {
                _basicInfoBL.update(_entity);
                lblMsg.Text = "به روز رسانی گردید";
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BasicInfoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }
    }
}
