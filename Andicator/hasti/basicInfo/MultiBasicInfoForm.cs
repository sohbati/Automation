using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMX_TOOLS.hasti.entity;
using RMX_TOOLS.hasti.bll;
using RMX_TOOLS.hasti.tools;

namespace Andicator.hasti.basicInfo
{
    public partial class MultiBasicInfoForm : Form
    {
        private string _engName;
        private string _selectedItems;
        private BasicInfoBL _basicInfoBL;
        
        public MultiBasicInfoForm(string engName, string selectedItems)
        {
            InitializeComponent();
            _basicInfoBL = new BasicInfoBL();
            _engName = engName;
            _selectedItems = selectedItems;
        }

        public void load()
        {
            int biId = _basicInfoBL.getId(_engName);
            BasicInfoEntity entity = _basicInfoBL.getByParentId(biId);
            CheckBox cb;
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                string desc = entity.get(i, BasicInfoEntity.FIELD_DESCRIPTION).ToString();
                int id = int.Parse(entity.get(i, BasicInfoEntity.FIELD_ID).ToString());

                cb = new CheckBox();
                cb.Checked = false;
                cb.Tag = id;
                cb.Text = desc;
                cb.Height = 20;
                cb.Width = flowLayoutPanel1.Width -5;
                flowLayoutPanel1.Controls.Add(cb);
            }
        }

        private void btnChoise_Click(object sender, EventArgs e)
        {

        }
    }
}

