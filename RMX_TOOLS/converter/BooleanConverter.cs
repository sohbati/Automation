using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.date;
using System.Globalization;
namespace RMX_TOOLS.converter
{
    public class BooleanConverter :IConverter
    {
        private const string TRUE = "true";
        private const string FALSE = "false";
        public string valueToString(object value)
        {
            if (value == null)
                return "false";
            string obj = value + "";
            if (obj.Trim().Length <= 0)
                return "false";
            if (obj.Trim().ToLower().Equals(TRUE))
                return "true";

            if (obj.Trim().ToLower().Equals(FALSE))
                return "false";
            int intVal = -1;
            try{
                intVal = int.Parse(obj);
            }catch(Exception e) {
                //nothig
            }
            if (intVal == 0)
                return "false";
            if (intVal > 0)
                return "true";

            return "false";

        }

        public object stringToValue(string str)
        {
            if (str == null || str.Trim().Length <= 0)
                return null;
            if(str.Trim().ToLower().Equals(TRUE))
                return true;
            if(str.Trim().ToLower().Equals(FALSE))
                return false;
            return null;
        }

    }
}
