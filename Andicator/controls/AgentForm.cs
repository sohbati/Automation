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
    public partial class AgentForm : Form
    {
        private int _id = -1;
        private AgentBL _AgentBL;
        private bool _readOnly = false;

        public AgentForm(int id)
        {
            _id = id;

            InitializeComponent();
            _AgentBL = new AgentBL();
            init();
        }

        public AgentForm(int id, bool readOnly)
        {
            _id = id;
            _readOnly = readOnly;
            InitializeComponent();
            _AgentBL = new AgentBL();
            init();
        }

        private void init()
        {
            if (_id > 0)
            {
                AgentEntity entity = null;
                entity = _AgentBL.get(_id);

                txtAgentName.Text = entity.get(AgentEntity.FIELD_Agent_NAME).ToString();
                txtAgentCode.Text = entity.get(AgentEntity.FIELD_AGENTCODE).ToString();
                txtTelephone.Text = entity.get(AgentEntity.FIELD_TELEPHONE).ToString();
                txtMobile.Text = entity.get(AgentEntity.FIELD_MOBILE).ToString();
                txtFax.Text = entity.get(AgentEntity.FIELD_FAX).ToString();
                txtAddress.Text = entity.get(AgentEntity.FIELD_ADDRESS).ToString();
                if (entity.get(AgentEntity.FIELD_ACTIVE) != null &&
                    entity.get(AgentEntity.FIELD_ACTIVE).ToString().Length > 0 &&
                    ((bool)entity.get(AgentEntity.FIELD_ACTIVE)) == false)
                    cmbActive.SelectedIndex = 1;
                else
                    cmbActive.SelectedIndex = 0;
            }
            else
            {
                if (_id == 0)
                    _readOnly = true;
                cmbActive.SelectedIndex = 0;
            }
            
            if (_readOnly )
            {
                txtAgentName.Enabled = false;
                txtAgentCode.Enabled = false;
                txtTelephone.Enabled = false;
                txtMobile.Enabled = false;
                txtFax.Enabled = false;
                txtAddress.Enabled = false;
                cmbActive.Enabled = false;
            }


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgentForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private bool BeforSave()
        {
            bool b;
            b = FormChecker.CheckEmpty(txtAgentName, lblAgentName);
            b &= FormChecker.CheckEmpty(txtTelephone, lblTel);
            //b &= FormChecker.CheckEmpty(txtAddress, lblAddress);
            return b;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!BeforSave())
                return;
            AgentEntity entity = new AgentEntity();
            DataRow dr = entity.Tables[entity.TableName].NewRow();
            if (_id > 0)
                dr[AgentEntity.FIELD_ID] = _id;

            dr[AgentEntity.FIELD_Agent_NAME] = txtAgentName.Text;
            dr[AgentEntity.FIELD_AGENTCODE] = txtAgentCode.Text;
            dr[AgentEntity.FIELD_TELEPHONE] = txtTelephone.Text;
            dr[AgentEntity.FIELD_MOBILE] = txtMobile.Text;
            dr[AgentEntity.FIELD_FAX] = txtFax.Text;
            dr[AgentEntity.FIELD_ADDRESS] = txtAddress.Text;
            dr[AgentEntity.FIELD_ACTIVE] = (cmbActive.SelectedIndex == 1 ? false : true);
            entity.Tables[entity.TableName].Rows.Add(dr);

            if (_id < 0)
            {
                _id = _AgentBL.add(entity);
                lblMsg.Text = "دخیره شده ";
            }
            else
            {
                _AgentBL.update(entity);
                lblMsg.Text = "به روز رسانی گردید.";
            }
            this.Close();
        }

        private void lblActive_Click(object sender, EventArgs e)
        {

        }

        private void cmbActive_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblOfficer_Click(object sender, EventArgs e)
        {

        }

        private void txtAgentCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAgentName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAgentName_Click(object sender, EventArgs e)
        {

        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtFax_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFax_Click(object sender, EventArgs e)
        {

        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        private void lblTel_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblMsg_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
