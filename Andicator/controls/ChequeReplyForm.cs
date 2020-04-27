using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorBLL;
using AndicatorCommon;
using RMX_TOOLS.converter;
using RMX_TOOLS.global;
using Andicator.lists;

namespace Andicator.controls
{
    public partial class ChequeReplyForm : Form
    {
        #region properties
        private int _chequeId = -1;

        public int ChequeId
        {
            get { return _chequeId; }
            set { _chequeId = value; }
        }
        #endregion 

        #region privates
        private int _id;
        private ChequeReplyBL _chequeReplyBL;
        #endregion

        public ChequeReplyForm(int id, string companyName)
        {
            
            _id = id;
            _chequeReplyBL = new ChequeReplyBL();
            InitializeComponent();
            txtCompanyName.Text = companyName;
        }


        public void initForm()
        {
            if (_id > 0)
            {
                ChequeReplyEntity entity = _chequeReplyBL.get(_id);
                DateConverter converter = new DateConverter();

                txtRecieptBillNumber.Text = entity.get(ChequeReplyEntity.FIELD_RECIEPTBILLNUMBER).ToString();
                txtIssueDate.Text = converter.valueToString(entity.get(ChequeReplyEntity.FIELD_ISSUEDATE));
                txtPrice.Text = entity.get(ChequeReplyEntity.FIELD_PRICE).ToString();
                txtDescription.Text = entity.get(ChequeReplyEntity.FIELD_DESCRIPTION).ToString();
            }

            if (_id < 0)
                linkAttachment.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool BeforSave()
        {
            bool b;
            b = FormChecker.CheckEmpty(txtRecieptBillNumber, lblRecieptBillNumber);
            b &= FormChecker.CheckDate(txtIssueDate, lblIssueDate);
            b &= FormChecker.CheckEmpty(txtPrice, lblPrice);
            
            try
            {
                if (txtPrice.Text.Length > 0)
                {
                    int i = int.Parse(txtPrice.Text);
                    lblPrice.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                b &= false;
                lblPrice.ForeColor = Color.Red;
            }

            return b;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!BeforSave())
                return;

            DateConverter dateconverter = new DateConverter();

            ChequeReplyEntity entity = new ChequeReplyEntity();
            DataRow dr = entity.Tables[entity.TableName].NewRow();
            if (_id > 0)
                dr[ChequeReplyEntity.FIELD_ID] = _id;

            dr[ChequeReplyEntity.FIELD_RECIEPTBILLNUMBER] = txtRecieptBillNumber.Text;
            dr[ChequeReplyEntity.FIELD_ISSUEDATE] = dateconverter.stringToValue(txtIssueDate.Text);
            dr[ChequeReplyEntity.FIELD_CHEQUEID] = _chequeId;
            dr[ChequeReplyEntity.FIELD_PRICE] = txtPrice.Text;
            dr[ChequeReplyEntity.FIELD_DESCRIPTION] = txtDescription.Text;
            entity.Tables[entity.TableName].Rows.Add(dr);

            if (_id < 0)
            {
                _id = _chequeReplyBL.add(entity);
                lblMsg.Text = "دخیره شده ";
            }
            else
            {
                _chequeReplyBL.update(entity);
                lblMsg.Text = "به روز رسانی گردید.";
            }
            this.Close();
        }

        private void ChequeReplyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void linkAttachment_MouseClick(object sender, MouseEventArgs e)
        {
            AttachmentChequeReceiptList list = new AttachmentChequeReceiptList(_id);
            list.ShowDialog();
        }

       
    }
}
