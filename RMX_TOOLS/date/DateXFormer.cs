using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace RMX_TOOLS.date
{
   public class DateXFormer
    {
       private static GregorianCalendar gcal = new GregorianCalendar();
       private static PersianCalendar pcal = new PersianCalendar();
        
       public static DateTime persianToGreGorian(DateTime dt)
       {
           DateTime greorianDateTime =
               new DateTime(gcal.GetYear(dt),
                            gcal.GetMonth(dt),
                            gcal.GetDayOfMonth(dt), new GregorianCalendar());
           return greorianDateTime;
           
       }

       public static DateTime persianToGreGorian(string strDate)
       {
           int y = 0;
           int m = 0;
           int d = 0;
           if (!CheckDate.checkDate(strDate, ref y, ref m, ref d))
               return DateTime.MinValue;

           DateTime persianDateDime = new DateTime(y, m, d, new PersianCalendar());
           DateTime greorianDateTime =
               new DateTime(gcal.GetYear(persianDateDime),
                            gcal.GetMonth(persianDateDime),
                            gcal.GetDayOfMonth(persianDateDime), new GregorianCalendar());
           return greorianDateTime;

       }

        
       public static string gregorianToPersianString(DateTime dt)
       {
           if (dt.CompareTo(DateTime.MinValue) == 0 || dt.CompareTo(DateTime.MinValue) < 0)
               return "";
           int yy = pcal.GetYear(dt);
           int mm = pcal.GetMonth(dt);
           int dd = pcal.GetDayOfMonth(dt);
           if (yy < 1300)
               return "";
           return generalizeDate(yy + "/" + mm + "/" + dd);
       }

       public static string generalizeDate(string date)
       {
           string ret = "";
           string[] m = date.Split('/');
           ret = m[0];
           ret += "/";
           if (m[1].Length < 2)
               ret += "0" + m[1];
           else
               ret += m[1];
           ret += "/";
           if (m[2].Length < 2)
               ret += "0" + m[2];
           else
               ret += m[2];
           return ret;
       }

       public static string getShamsiYear(string shamsiDateStr)
       {
           string[] s = shamsiDateStr.Split(new char[]{'/'});
           return s[0];
       }

       public static string getShamsiMonth(string shamsiDateStr)
       {
           string[] s = shamsiDateStr.Split(new char[] { '/' });
           return s[1];
       }

       public static string getShamsiDay(string shamsiDateStr)
       {
           string[] s = shamsiDateStr.Split(new char[] { '/' });
           return s[2];
       }

    }
}
