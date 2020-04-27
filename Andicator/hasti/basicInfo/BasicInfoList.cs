using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMX_TOOLS.data.grid;
using AndicatorCommon;
using RMX_TOOLS.hasti.entity;
using System.Collections;
using RMX_TOOLS.hasti.bll;
using RMX_TOOLS.global;

namespace Andicator.hasti.basicInfo
{
    public partial class BasicInfoList : Form
    {
        private GridTools _gridTools;
        private BasicInfoEntity _basicInfoEntity;
        private BasicInfoBL _basicInfoBl;
        private int _parentId = -1;
        public BasicInfoList()
        {
            InitializeComponent();
            _basicInfoEntity = new BasicInfoEntity();
            _basicInfoBl = new BasicInfoBL();
            _gridTools = new GridTools();
            fillGrid();
        }

        private void fillGrid()
        {
            fillGrid(-1);
        }

        private void fillGrid(int parentId)
        {
            System.Collections.Hashtable hash = new Hashtable();
            //hash.Add("colorField", InsuranceTypeData.INSURANCETYPECOLOR_FIELD);
            if (parentId <0)
                _basicInfoEntity = _basicInfoBl.getRoots(); 
            else
                _basicInfoEntity = _basicInfoBl.getByParentId(parentId, true); 

            _gridTools.bindDataToGrid(dataGridView1, _basicInfoEntity, new GridTools.changingRow(_gridTools.changeColor), hash);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (_parentId < 0)
            {
                MessageBox.Show("هیچ آیتمی انتخاب نشده است");
                return;
            }
            BasicInfoForm form = new BasicInfoForm();
            form.ParentId = _parentId;
            form.intiForm();

            form.ShowDialog();
            fillGrid(_parentId);
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                 DataGridViewRow dr = dataGridView1.SelectedRows[0];
                 int id = int.Parse(dr.Cells[BasicInfoEntity.FIELD_ID].Value.ToString());
                 BasicInfoForm form = new BasicInfoForm();
                 form.Id = id;
                 form.intiForm();

                 form.ShowDialog();
                 fillGrid(_parentId);    
            }
            

        }

        private void lblRoot_Click(object sender, EventArgs e)
        {
            lblItem.Text = "";
            _parentId = -1;
            fillGrid(_parentId);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (_parentId >= 0)
            {
                btnDisplay_Click(sender, e);
                return;
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                int id = int.Parse(dr.Cells[BasicInfoEntity.FIELD_ID].Value.ToString());
                lblItem.Text = dr.Cells[BasicInfoEntity.FIELD_DESCRIPTION].Value.ToString();
                _parentId = id;
                fillGrid(id);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_parentId < 0)
            {
                MessageBox.Show("اطلاعات پایه ریشه قابل حذف نیست");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("آیا جهت حذف مطمئن هستید !", "اطلاعات پایه", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                int id = int.Parse(dr.Cells[BasicInfoEntity.FIELD_ID].Value.ToString());
                BasicInfoForm form = new BasicInfoForm();
                form.Id = id;
                form.Mode = Constants.DELETE_MODE;
                form.intiForm();

                form.ShowDialog();
                fillGrid(_parentId);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BasicInfoList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }
    }
}
