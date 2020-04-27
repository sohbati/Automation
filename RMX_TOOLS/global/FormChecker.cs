using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;

namespace RMX_TOOLS.global
{
    public static class FormChecker
    {
        private static Color EMPTY_COLOR = Color.Red;
        private static Color FULL_COLOR = Color.Black;
        private static ToolTip _toolTip = new ToolTip();

        public static bool CheckEmpty(object obj, Label lbl)
        {
            if (obj is ComboBox)
            {
                ComboBox c = ((ComboBox)obj);
                ((Control)lbl).ForeColor = FULL_COLOR;
                if (c.SelectedIndex < 0)
                {
                    _toolTip.SetToolTip(((Control)obj), "انتخاب یکی از آیتم های این فیلد اجباری است!");
                    ((Control)lbl).ForeColor = EMPTY_COLOR;
                    return false;
                }

                ComboBoxItem ci = (ComboBoxItem)((ComboBox)obj).Items[c.SelectedIndex];
                ((Control)lbl).ForeColor = FULL_COLOR;
                if (ci.Value == null || ci.Value == "" || int.Parse(ci.Value) < 0)
                {
                    ((Control)lbl).ForeColor = EMPTY_COLOR;
                    _toolTip.SetToolTip(((Control)obj), "انتخاب یکی از آیتم های این فیلد اجباری است!");
                    return false;
                }
                else
                {
                    ((Control)lbl).ForeColor = FULL_COLOR;
                    _toolTip.SetToolTip(((Control)obj), "");
                    return true;
                }
            }
            if (((Control)obj).Text.Trim().Length == 0 || ((Control)obj).Text.Trim().ToString().IndexOf("_") >= 0)
            {
                ((Control)lbl).ForeColor = EMPTY_COLOR;
                _toolTip.SetToolTip(((Control)obj), "وارد کردن این فیلد اجباری است");
                return false;
            }
            else
            {
                ((Control)lbl).ForeColor = FULL_COLOR;
                _toolTip.SetToolTip(((Control)obj), "");
                return true;
            }

        }

        public static bool CheckDate(object obj, Label lbl)
        {
            bool b = date.CheckDate.checkDate(((Control)obj).Text);
            if (!b)
            {
                
                _toolTip.SetToolTip(((Control)obj), "تاریخ وارد شده صحیح نیست");
                ((Control)lbl).ForeColor = EMPTY_COLOR;
            }
            else
            {
                _toolTip.SetToolTip(((Control)obj), "");
                ((Control)lbl).ForeColor = FULL_COLOR;
            }
            return b;
        }
    }
}
