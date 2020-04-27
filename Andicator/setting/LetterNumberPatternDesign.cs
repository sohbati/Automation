using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorCommon;
using AndicatorBLL;
using System.Collections;
using RMX_TOOLS.global;

namespace Andicator.controls
{
    public partial class LetterNumberPatternDesign : Form
    {
        private static string LEGAL_CHARS = "ابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی1234567890YMD#/-_";
        private LetterNumberPatternBL _letterNumberPatternBL;
        private LetterNumberPatternEntity _entity;
        private int _id;
        
        public LetterNumberPatternDesign(int id)
        {
            _id = id;

            InitializeComponent();
            _letterNumberPatternBL = new LetterNumberPatternBL();
            loadLastPattern();
        }

        private void loadLastPattern()
        {
            _entity = _letterNumberPatternBL.getById(_id);
            int count = _entity.Tables[_entity.FilledTableName].Rows.Count;
            if (count > 0)
            {
                txtRecievePattern.Text = _entity.get(0, LetterNumberPatternEntity.FIELD_RECIEVE_PATTERN).ToString();
                txtSendPattern.Text = _entity.get(0, LetterNumberPatternEntity.FIELD_SEND_PATTERN).ToString();
                setReset((int) _entity.get(0, LetterNumberPatternEntity.FIELD_RESETBY));
                txtLastNumbeRecieve.Text = _entity.get(0, LetterNumberPatternEntity.FIELD_LASTNUMBER_RECIEVE).ToString();
                txtLastNumbeSend.Text = _entity.get(0, LetterNumberPatternEntity.FIELD_LASTNUMBER_SEND).ToString();
                txtPatternName.Text = _entity.get(0, LetterNumberPatternEntity.FIELD_PATTERN_NAME).ToString();
            }
            else
            {
                _entity = null;
                rdoBtnNone.Checked = true;
                txtLastNumbeRecieve.Text = "0";
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //بررسی اینکه علامت عددی ها پشت سر هم باشند//
        private bool checkNumberSignsTandem(string s)
        {
            if (s.IndexOf("#") < 0)
            {
                MessageBox.Show("الگو حتما باید دارای علامت # باشد");
                return false;
            }
            ArrayList list = new ArrayList();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Equals('#'))
                    list.Add(i);
            }
            if (list.Count < 2)
            {
                MessageBox.Show("لطفا تعداد  # ها را بیش از دو رقم انتخاب نمایید");
                return false;
            }
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (((int)list[i + 1]) - ((int)list[i]) >= 2)
                {
                    MessageBox.Show("علامت عددی # باید همه در کنار هم باشند");
                    return false;
                }
            }
            _NumberSignCount = list.Count;

            return true;
        }

        private bool checkMonthTandem(string s)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].ToString().ToUpper().Equals("M"))
                    list.Add(i);
            }
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (((int)list[i + 1]) - ((int)list[i]) >= 2)
                {
                    MessageBox.Show("علامت ماه باید همه در کنار هم باشند");
                    return false;
                }
            }

            if (list.Count == 0)
                return true;
            if (list.Count > 2)
            {
                MessageBox.Show("لطفا تعداد علامت های ماه را دو عدد وارد نمایید");
                return false;
            }
            return true;
        }

        private bool checkYearTandem(string s)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].ToString().ToUpper().Equals("Y"))
                    list.Add(i);
            }
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (((int)list[i + 1]) - ((int)list[i]) >= 2)
                {
                    MessageBox.Show("علامت سال باید همه در کنار هم باشند");
                    return false;
                }
            }

            if (list.Count == 0)
                return true;
            if (list.Count > 4)
            {
                MessageBox.Show("لطفا تعداد علامت های سال را تا چهار عدد وارد نمایید");
                return false;
            }
            return true;
        }

        private bool checkDayTandem(string s)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].ToString().ToUpper().Equals("D"))
                    list.Add(i);
            }
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (((int)list[i + 1]) - ((int)list[i]) >= 2)
                {
                    MessageBox.Show("علامت روز باید همه در کنار هم باشند");
                    return false;
                }
            }

            if (list.Count == 0)
                return true;
            if (list.Count > 2)
            {
                MessageBox.Show("لطفا تعداد علامت های سال را دو عدد وارد نمایید");
                return false;
            }
            return true;
        }

        int _NumberSignCount = 0;
        private bool checkData()
        {
            bool b;
            b = FormChecker.CheckEmpty(txtRecievePattern, lblRecievePattern);
            b &= FormChecker.CheckEmpty(txtSendPattern, lblSendPattern);
            
            b &= checkYearTandem(txtRecievePattern.Text);
            b &= checkMonthTandem(txtRecievePattern.Text);
            b &= checkDayTandem(txtRecievePattern.Text);

            b &= checkYearTandem(txtSendPattern.Text);
            b &= checkMonthTandem(txtSendPattern.Text);
            b &= checkDayTandem(txtSendPattern.Text);

            b &= checkNumberSignsTandem(txtRecievePattern.Text);
            int n1 = _NumberSignCount;
            b &= checkNumberSignsTandem(txtSendPattern.Text);
            int n2 = _NumberSignCount;
            
            if (n1 != txtLastNumbeRecieve.Text.Length)
            {
                MessageBox.Show("لطفا تعداد ارقام برای آخرین شماره نامه  تولیده شده وارده را به تعداد ارقام انتخابی وارد نمایید،");
                return false;
            }
            if (n2 != txtLastNumbeSend.Text.Length)
            {
                MessageBox.Show("لطفا تعداد ارقام برای آخرین شماره نامه  تولیده شده صادره را به تعداد ارقام انتخابی وارد نمایید،");
                return false;
            }
            
            if (!b)
               return false;
            
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool b = checkData();
            if (!b)
                return;
            DataRow dr = null;
            bool newRow = false;

            LetterNumberPatternEntity entity = new LetterNumberPatternEntity();
            dr = entity.Tables[entity.TableName].NewRow();
            if (_id < 0)
                newRow = true;

            dr[LetterNumberPatternEntity.FIELD_RECIEVE_PATTERN] = txtRecievePattern.Text;
            dr[LetterNumberPatternEntity.FIELD_SEND_PATTERN] = txtSendPattern.Text;
            dr[LetterNumberPatternEntity.FIELD_REGISTER_DATE] = DateTime.Now;
            dr[LetterNumberPatternEntity.FIELD_RESETBY] = resetByRadionBtn();
            dr[LetterNumberPatternEntity.FIELD_LASTNUMBER_RECIEVE] = txtLastNumbeRecieve.Text;
            dr[LetterNumberPatternEntity.FIELD_LASTNUMBER_SEND] = txtLastNumbeSend.Text;
            dr[LetterNumberPatternEntity.FIELD_PATTERN_NAME] = txtPatternName.Text;
            if (_entity == null)
                dr[LetterNumberPatternEntity.FIELD_CANSET] = true;
            else
            {
                object canset = _entity.get(LetterNumberPatternEntity.FIELD_CANSET);
                if (canset != null && canset.ToString().Length > 0)
                    dr[LetterNumberPatternEntity.FIELD_CANSET] = _entity.get(LetterNumberPatternEntity.FIELD_CANSET);
                else
                    dr[LetterNumberPatternEntity.FIELD_CANSET] = true;

                object systemName = _entity.get(LetterNumberPatternEntity.FIELD_SYSTEMNAME);
                if (systemName != null && systemName.ToString().Length > 0)
                    dr[LetterNumberPatternEntity.FIELD_SYSTEMNAME] = _entity.get(LetterNumberPatternEntity.FIELD_SYSTEMNAME);
            }
            if(!newRow)
                dr[LetterNumberPatternEntity.FIELD_ID] = _entity.get(LetterNumberPatternEntity.FIELD_ID);
            
            entity.Tables[entity.TableName].Rows.Add(dr);
            if (newRow)
            {
                lblMsg.Text = "دخیره شده";
               _id = _letterNumberPatternBL.add(entity);
               _entity = _letterNumberPatternBL.get();
            }
            else
            {
                _letterNumberPatternBL.update(entity);
                lblMsg.Text = "به روز گردید";
            }
            this.Close();
        }

        private int resetByRadionBtn()
        {
            if (rdoBtnDay.Checked)
                return LetterNumberPatternBL.RESET_BY_DAY;
            if (rdoBtnMonth.Checked)
                return LetterNumberPatternBL.RESET_BY_MONTH;
            if (rdoBtnYear.Checked)
                return LetterNumberPatternBL.RESET_BY_YEAR;
            if (rdoBtnNone.Checked)
                return LetterNumberPatternBL.RESET_BY_NONE;

            return LetterNumberPatternBL.RESET_BY_NONE;

        }

        private void setReset(int d) 
        {
            switch (d)
            {
                case LetterNumberPatternBL.RESET_BY_DAY:
                    rdoBtnDay.Checked = true;
                    break;
                case LetterNumberPatternBL.RESET_BY_MONTH:
                    rdoBtnMonth.Checked = true;
                    break;
                case LetterNumberPatternBL.RESET_BY_YEAR:
                    rdoBtnYear.Checked = true;
                    break;
                case LetterNumberPatternBL.RESET_BY_NONE:
                    rdoBtnNone.Checked = true;
                    break;
            }
        }
        private void txtSendPattern_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPress(sender, e);
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            string c = e.KeyChar.ToString();
            if (LEGAL_CHARS.IndexOf(c) >= 0 || c == "\b")
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void txtRecievePattern_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPress(sender, e);
        }

        private void btnResetNumberRec_Click(object sender, EventArgs e)
        {
            txtLastNumbeRecieve.Text = "0";
        }

        private void btnResetNumberSend_Click(object sender, EventArgs e)
        {
            txtLastNumbeSend.Text = "0";
        }

        private void LetterNumberPatternDesign_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();
        }

        private void txtLastNumbeRecieve_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastNumbeSend_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
