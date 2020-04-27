using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;
using RMX_TOOLS.hasti.bll;
using AndicatorBLL;

namespace Andicator.setting
{
    public partial class ColorSetting : Form
    {
        private BasicInfoBL _basicInfoBL = new BasicInfoBL();

        public ColorSetting()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            pnlLetterStateColor.BackColor = Color.White;
            BasicInfoUtil.fillComboBox(cmbLetterStateId, "LetterState", -1);

            ApplicationPropertiesBL appPropertiesBL = new ApplicationPropertiesBL();
             
            pnlColorConfirmedLetter.BackColor = ColorTranslator.FromHtml(appPropertiesBL.getValue(ApplicationPropertiesBL.COLOR_CONFIRMED_LETTER));
            pnlReferenceColor.BackColor       = ColorTranslator.FromHtml(appPropertiesBL.getValue(ApplicationPropertiesBL.COLOR_REFERENCE_LIMIT));
            txtReferLimit.Text = appPropertiesBL.getValue(ApplicationPropertiesBL.REFERENCE_COUNT);
            pnlCheque.BackColor = ColorTranslator.FromHtml(appPropertiesBL.getValue(ApplicationPropertiesBL.CHEQUE_WITHNO_REPLY));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnColorConfirmedLetter_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            pnlColorConfirmedLetter.BackColor = cd.Color;

        }

        private void cmbLetterStateId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbLetterStateId.SelectedIndex;
            if (i <= 0)
            {
                pnlLetterStateColor.BackColor = Color.White;
                return;
            }
            ComboBoxItem item = (ComboBoxItem)cmbLetterStateId.Items[i];
            
            if(item.CustomData != null && item.CustomData.Length > 0)
                pnlLetterStateColor.BackColor = ColorTranslator.FromHtml(item.CustomData);
            else
                pnlLetterStateColor.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (cmbLetterStateId.SelectedIndex <= 0)
            {
                pnlLetterStateColor.BackColor = Color.White;
                return;
            }

            int i = cmbLetterStateId.SelectedIndex;

            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            pnlLetterStateColor.BackColor = cd.Color;
            ComboBoxItem item = (ComboBoxItem)cmbLetterStateId.Items[i];
            item.CustomData = ColorTranslator.ToHtml(cd.Color);
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dres = MessageBox.Show("با تغییر رنگ نامه های قبلی نیز به رنگ جدید تغییر می کنند، آیا ادامه می دهید", "", MessageBoxButtons.YesNo);
            if (dres.Equals(DialogResult.No))
            {
                return;
            }

           
            for (int i = 0; i < cmbLetterStateId.Items.Count; i++)
            {
                ComboBoxItem item = (ComboBoxItem)cmbLetterStateId.Items[i];
                if (item.CustomData != null && item.CustomData.Length > 0)
                    _basicInfoBL.updateCustomData(int.Parse(item.Value.ToString()), item.CustomData);
            }
            ApplicationPropertiesBL appPropertiesBL = new ApplicationPropertiesBL();
           int kk =     appPropertiesBL.add(ApplicationPropertiesBL.COLOR_CONFIRMED_LETTER, ColorTranslator.ToHtml(pnlColorConfirmedLetter.BackColor));
           kk = appPropertiesBL.add(ApplicationPropertiesBL.COLOR_REFERENCE_LIMIT, ColorTranslator.ToHtml(pnlReferenceColor.BackColor));
           kk=  appPropertiesBL.add(ApplicationPropertiesBL.REFERENCE_COUNT, txtReferLimit.Text);
           kk = appPropertiesBL.add(ApplicationPropertiesBL.CHEQUE_WITHNO_REPLY, ColorTranslator.ToHtml(pnlCheque.BackColor));
           
            updateLetterColors();
            updateChequeColors();
            lblMsg.Text = "تغییرات دذخیره گردید";

        }

        private void updateChequeColors() 
        {
            ChequeBL bl = new ChequeBL();
            bl.updateColor(ColorTranslator.ToHtml(pnlCheque.BackColor));
        }

        private void updateLetterColors()
        {

            LetterBL letterBL = new LetterBL();
            for (int i = 0; i < cmbLetterStateId.Items.Count; i++)
            {
                ComboBoxItem item = (ComboBoxItem)cmbLetterStateId.Items[i];
                if (item.CustomData != null && item.CustomData.Length > 0)
                {
                    int stateID = int.Parse(item.Value);
                    string color = item.CustomData;
                    letterBL.updateColor(stateID, color);
                }
            }

            letterBL.updateConfimedsColor(ColorTranslator.ToHtml(pnlColorConfirmedLetter.BackColor));
            letterBL.updateMaxRefLimitColor(int.Parse(txtReferLimit.Text), ColorTranslator.ToHtml(pnlReferenceColor.BackColor));

        }
        private void btnReferenceColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            pnlReferenceColor.BackColor = cd.Color;

        }

        private void ColorSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void btnCheque_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            pnlCheque.BackColor = cd.Color;
        }
    }
}
