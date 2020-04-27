using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorCommon;
using RMX_TOOLS.global;
using RMX_TOOLS.hasti.tools;
using AndicatorBLL;

namespace Andicator.controls
{
    public partial class CompanyForm : Form
    {
        private int _id = -1;
        private CompanyBL _companyBL;
        private bool _readOnly = false;

        public CompanyForm(int id)
        {
            _id = id;

            InitializeComponent();
            _companyBL = new CompanyBL();
            init();
        }

        public CompanyForm(int id, bool readOnly)
        {
            _id = id;
            _readOnly = readOnly;
            InitializeComponent();
            _companyBL = new CompanyBL();
            init();
        }

        private void init()
        {
            int sematId = 0;
            if (_id > 0)
            {
                CompanyEntity entity  = null;
                entity = _companyBL.get(_id);

                txtCompanyName.Text = entity.get(CompanyEntity.FIELD_COMPANY_NAME).ToString();
                txtTel.Text = entity.get(CompanyEntity.FIELD_TEL).ToString();
                txtOfficer.Text = entity.get(CompanyEntity.FIELD_OFFICER).ToString();
                txtFax.Text = entity.get(CompanyEntity.FIELD_FAX).ToString();
                txtAddress.Text = entity.get(CompanyEntity.FIELD_ADDRESS).ToString();
                txtDescription.Text = entity.get(CompanyEntity.FIELD_DESCRIPTION).ToString();
                if (entity.get(CompanyEntity.FIELD_SEMAT) != null && entity.get(CompanyEntity.FIELD_SEMAT).ToString().Length > 0)
                    sematId = int.Parse(entity.get(CompanyEntity.FIELD_SEMAT).ToString());
                if (entity.get(CompanyEntity.FIELD_ACTIVE) != null &&
                    entity.get(CompanyEntity.FIELD_ACTIVE).ToString().Length > 0 &&
                    ((bool)entity.get(CompanyEntity.FIELD_ACTIVE)) == false)
                    cmbActive.SelectedIndex = 1;
                else
                    cmbActive.SelectedIndex = 0;
            }
            else
            {
               if(_id == 0) 
                   _readOnly = true;
                sematId = 0;
                cmbActive.SelectedIndex = 0;
            }

            BasicInfoUtil.fillComboBox(cmbSemat, "Semat", sematId);
            if (_readOnly)
            {
                txtTel.Enabled = false;
                txtFax.Enabled = false;
                txtDescription.Enabled = false;
                txtCompanyName.Enabled = false;
                txtAddress.Enabled = false;
                btnSave.Enabled = false;
                txtOfficer.Enabled = false;
                cmbSemat.Enabled = false;
                cmbActive.Enabled = false;
            }

            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CompanyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }
        
        private bool BeforSave()
        {
            bool b;
            b = FormChecker.CheckEmpty(txtCompanyName, lblCompanyName);
            b = FormChecker.CheckEmpty(txtTel, lblTel);
            b &= FormChecker.CheckEmpty(txtAddress, lblAddress);
            return b;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!BeforSave())
                return;
            CompanyEntity entity = new CompanyEntity();
            DataRow dr = entity.Tables[entity.TableName].NewRow();
            if (_id > 0)
                dr[CompanyEntity.FIELD_ID] = _id;

            dr[CompanyEntity.FIELD_COMPANY_NAME] = txtCompanyName.Text;
            dr[CompanyEntity.FIELD_TEL] = txtTel.Text;
            dr[CompanyEntity.FIELD_SEMAT] = ((ComboBoxItem)cmbSemat.Items[cmbSemat.SelectedIndex]).Value;
            dr[CompanyEntity.FIELD_OFFICER] = txtOfficer.Text;
            dr[CompanyEntity.FIELD_FAX] = txtFax.Text;
            dr[CompanyEntity.FIELD_ADDRESS] = txtAddress.Text;
            dr[CompanyEntity.FIELD_DESCRIPTION] = txtDescription.Text;
            dr[CompanyEntity.FIELD_ACTIVE] = (cmbActive.SelectedIndex == 1? false : true);
            entity.Tables[entity.TableName].Rows.Add(dr);

            if (_id < 0)
            {
                _id = _companyBL.add(entity);
                lblMsg.Text = "دخیره شده ";
            }
            else
            {
                _companyBL.update(entity);
                lblMsg.Text = "به روز رسانی گردید.";
            }

        }

    }
}
