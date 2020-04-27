using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorBLL;
using AndicatorCommon;
using System.Collections;
using RMX_TOOLS.data.grid;

namespace Andicator.controls
{
    public partial class LetterRefferencesForm : Form
    {
        private GridTools _gridTools;

        public LetterRefferencesForm()
        {
            _gridTools = new GridTools();
            InitializeComponent();
        }

        public void initForm(int letterid)
        {
            ReferLetterBL refLetterBl = new ReferLetterBL();
            ReferLetterEntity entity = refLetterBl.get(letterid);
            //_letterBl.get(LetterType);
            
            System.Collections.Hashtable hash = new Hashtable();
            hash.Add("colorField", "COLOR");

            //_gridTools.bindDataToGrid(dataGridView1, entity, new GridTools.changingRow(_gridTools.changeColor), hash);
            _gridTools.bindDataToGrid(dataGridView1, entity, null, hash);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefferencesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

    }
}
