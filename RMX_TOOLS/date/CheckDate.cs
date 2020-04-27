using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
namespace RMX_TOOLS.date
{
    public class CheckDate
    {
        /**
         *set strShamsiDate 
         * if strShamsiDate is valid shamsiDate then retrun true and...
         *  retY ,retM,retD have valid vaues
         */
        private   const int MAX_YEAR = 1400;
        private   const int MIN_YEAR = 1300;

        public static Boolean checkDate(string strShammsiDate)
        {
            int d = 0;
            int m = 0;
            int y = 0;
            return checkDate(strShammsiDate,ref y,ref m,ref d);
        }

        public static Boolean checkDate(string strShammsiDate,ref int retY,ref int retM,ref int retD) 
        {
            try
            {
                retY = 0;
                retM = 0;
                retD = 0;
                GregorianCalendar gcal = new GregorianCalendar();

                if (strShammsiDate == null || strShammsiDate.Trim().Length <= 0)
                    return false;

                String[] strDateArr = strShammsiDate.Split(new Char[] {'/'});
                if (strDateArr.Length != 3)
                    return false;
                if (strDateArr[0].Trim().Length <= 0 ||
                    strDateArr[1].Trim().Length <= 0 ||
                    strDateArr[2].Trim().Length <= 0)
                    return false;
                    int year = int.Parse(strDateArr[0]);
                    int month = int.Parse(strDateArr[1]);
                    int day = int.Parse(strDateArr[2]);
                if (year < MIN_YEAR || year > MAX_YEAR)
                    return false;
                if (month <= 0 || month > 12)
                    return false;
                if (day <= 0 || day > 31)
                    return false;

                if (month > 6)
                {
                    if (day >= 31)
                        return false;
                    // check leap year
                    PersianCalendar pcal = new PersianCalendar();
                    if (month == 12 && day == 30)
                    {
                        if (!pcal.IsLeapYear(year))
                            return false;
                    }
                }
                retY = year;
                retM = month;
                retD = day;

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public static string generalizeDate(string date)
        {
            string ret = "";
            string[] m = date.Split('/');
            ret = m[0];
            if (m[1].Length < 2)
                ret += "0" + m[1];
            else
                ret += m[1];
            if (m[2].Length < 2)
                ret += "0" + m[2];
            else
                ret += m[2];
            return ret;
        }

        
    }
}
