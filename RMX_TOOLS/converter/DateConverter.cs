using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.date;
using System.Globalization;
namespace RMX_TOOLS.converter
{
    public class DateConverter :IConverter
    {
        GregorianCalendar gcal = new GregorianCalendar();
        PersianCalendar pcal = new PersianCalendar();

        private string nullDate = "    /  /  ";
        private DateTime nullDateTime = new DateTime(1753, 1, 1);
        
        public string valueToString(object value)
        {
            if (value == null || value.ToString().Length <= 0 )
                return null;
            
            DateTime greorianDateTime = (DateTime)value;
            if (greorianDateTime.Equals(DateTime.MinValue) || greorianDateTime.Equals(nullDateTime))
                return nullDate;
            //test
            int yy = pcal.GetYear(greorianDateTime);
            int mm = pcal.GetMonth(greorianDateTime);
            int dd = pcal.GetDayOfMonth(greorianDateTime);
            return generalizeDate(yy + "/" + mm + "/" + dd);

           // DateTime persianDateTime =
           //     new DateTime(yy,mm,dd, new GregorianCalendar());
           // return persianDateTime.Year + "/" + persianDateTime.Month + "/" + persianDateTime.Day;
        }

        public object stringToValue(string str)
        {
            int d = 12;
            int m = 0;
            int y = 0;
            
            Boolean chk =  CheckDate.checkDate(str,ref y,ref m,ref d);
            if (!chk)
                return nullDateTime;

            DateTime persianDateDime = new DateTime(y, m, d, new PersianCalendar());
            DateTime greorianDateTime =
                new DateTime(gcal.GetYear(persianDateDime),
                             gcal.GetMonth(persianDateDime),
                             gcal.GetDayOfMonth(persianDateDime), new GregorianCalendar());
            return greorianDateTime;
        }

        private string generalizeDate(string date)
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
