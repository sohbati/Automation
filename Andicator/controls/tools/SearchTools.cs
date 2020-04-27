using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;

namespace Andicator.controls.tools
{
    public class SearchTools
    {
        public string getCheckBoxfldCond(ComboBox cmb, string fldName, string cond)
        {
            if (cmb.SelectedIndex > 0)
            {
                if (cond.Length > 0)
                    cond += " AND ";
                if (cmb.SelectedIndex == 1)
                    return cond + fldName + "=1 ";
                else
                    return cond + "(" + fldName + "= 0  OR " + fldName + " is null) ";
            }
            return cond;
        }

        public string getCombofldCond(ComboBox cmb, string fldName, string cond)
        {
            if (cmb.SelectedIndex > 0)
            {
                ComboBoxItem item = (ComboBoxItem)cmb.Items[cmb.SelectedIndex];
                int value = int.Parse(item.Value);
                if (cond.Length > 0)
                    cond += " AND ";
                return cond + fldName + "=" + value;

            }
            return cond;
        }

        public string getCheckBoxListCond(CheckedListBox cb, string fldName, string cond)
        {
            CheckedListBox.CheckedItemCollection coll = cb.CheckedItems;
            if (coll.Count <= 0)
                return cond;
            string values = "";
            for (int i = 0; i < coll.Count; i++)
            {
                ComboBoxItem item = (ComboBoxItem)coll[i];
                int value = int.Parse(item.Value);
                if (value >= 0)
                {
                    values += value + ",";
                }
            }
            if (values.Length <= 0)
                return cond;

            if (cond.Length > 0)
                cond += " AND ";
            cond = cond + fldName + " in (" + values.Substring(0, values.Length - 1) + ")";
            return cond;
        }

        public string getStringFldCond(string fldName, string fldValue, string cond)
        {
            if (fldValue.Trim().Length > 0)
            {
                if (cond.Length > 0)
                    cond += " AND ";
                return cond + fldName + " like '%" + fldValue + "%'";
            }
            return cond;
        }
        
        public string getNumberFldCond(String fldName, string valueStr1,string valueStr2, ComboBox cmbCompare, string cond)
        {
            if (valueStr1 == null || valueStr1.Length <= 0)
                return cond;
            int value = -1;
            try
            {
                value = int.Parse(valueStr1);
            }
            catch (Exception ex) 
            {
                return cond;
            }

            if (value> 0 )
            {
                if (cond.Length > 0)
                    cond += " AND ";
                switch (cmbCompare.SelectedIndex)
                {
                    case 0:
                        cond += fldName + "=" + value;
                        break;
                    case 1:
                        cond += fldName + "<" + value;
                        break;
                    case 2:
                        cond += fldName + "<=" + value;
                        break;
                    case 3:
                        cond += fldName + ">" + value;
                        break;
                    case 4:
                        cond += fldName + ">=" + value;
                        break;
                    case 5:
                        {
                            int value1 = -1;
                            try
                            {
                                value1 = int.Parse(valueStr2);
                            }
                            catch (Exception ex)
                            {
                                return cond;
                            }
                            cond += "(" + fldName + " BETWEEN " + value + " AND " + value1 + ")";
                            break;
                        }
                }
            }
            return cond;
        }

        public string getDateFldCond(String fldName, string dateValue,string dateValue2, ComboBox cmbCompare, string cond)
        {
            if (dateValue.Length > 0 && RMX_TOOLS.date.CheckDate.checkDate(dateValue))
            {
                if (cond.Length > 0)
                    cond += " AND ";
                DateTime date = RMX_TOOLS.date.DateXFormer.persianToGreGorian(dateValue);
                DateTime date2;
                if (RMX_TOOLS.date.CheckDate.checkDate(dateValue2))
                    date2 = RMX_TOOLS.date.DateXFormer.persianToGreGorian(dateValue2);
                else
                    date2 = date;

                switch (cmbCompare.SelectedIndex)
                {
                    case 0:
                        cond += RMX_TOOLS.data.Config.provider.getAsSqlDate(fldName, date);
                        break;
                    case 1:
                        {
                            string d1 = date.Year + "-" + date.Month + "-" + date.Day + " " + RMX_TOOLS.date.DateConstants.BEGIN_OF_DAY;
                            cond += fldName + "<" + "CAST('" + d1 + "' AS DATETime)";
                        }
                        break;
                    case 2:
                        {
                            string d1 = date.Year + "-" + date.Month + "-" + date.Day + " " + RMX_TOOLS.date.DateConstants.END_OF_DAY;
                            cond += fldName + "<=" + "CAST('" + d1 + "' AS DATETime)";
                        }
                        break;
                    case 3:
                        {
                            string d1 = date.Year + "-" + date.Month + "-" + date.Day + " " + RMX_TOOLS.date.DateConstants.END_OF_DAY;
                            cond += fldName + ">" + "CAST('" + d1 + "' AS DATETime)";
                        }
                        break;
                    case 4:
                        {
                            string d1 = date.Year + "-" + date.Month + "-" + date.Day + " " + RMX_TOOLS.date.DateConstants.BEGIN_OF_DAY;
                            cond += fldName + ">=" + "CAST('" + d1 + "' AS DATETime)";
                        }
                        break;
                    case 5:
                        {
                            string d1 = date.Year + "-" + date.Month + "-" + date.Day + " " + RMX_TOOLS.date.DateConstants.BEGIN_OF_DAY;
                            string d2 = date2.Year + "-" + date2.Month + "-" + date2.Day + " " + RMX_TOOLS.date.DateConstants.END_OF_DAY;
                            cond += fldName + " BETWEEN " + "CAST('" + d1 + "' AS DATETime)" + " AND " +
                                "CAST('" + d2 + "' AS DATETime)";
                        }
                        break;
                }
            }
            return cond;
        }

        internal string getNumberFldCond(object value, string fldName, string cond)
        {
            if (value == null)
                return cond;
            int v =-1;
            try
            {
                v = int.Parse(value.ToString());
            }
            catch (Exception ex)
            {
                v = -1;
            }

            if (v >= 0)
            {
                if (cond.Length > 0)
                    cond += " AND ";
                cond += fldName + "=" + v;
            }
            return cond;
        }
    }
}
