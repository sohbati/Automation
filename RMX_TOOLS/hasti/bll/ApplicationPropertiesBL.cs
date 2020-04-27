using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.BLL;
using RMX_TOOLS.hasti.entity;
using RMX_TOOLS.hasti.dal;

namespace RMX_TOOLS.hasti.bll
{
    public class ApplicationPropertiesBL : AbstractBL
    {
        public const string COLOR_CONFIRMED_LETTER = "COLOR_CONFIRMED_LETTER";
        public const string COLOR_REFERENCE_LIMIT = "COLOR_REFERENCE_LIMIT";
        public const string REFERENCE_COUNT = "REFERENCE_COUNT";
        public const string CHEQUE_WITHNO_REPLY = "CHEQUE_WITHNO_REPLY";
        public const string ALARM_LIST_REFRESH_TIME = "ALARM_LIST_REFRESH_TIME";

        ApplicationPropertiesDA _applicationPropertiesDA;
        public ApplicationPropertiesBL()
        {
            _abstractDA = new ApplicationPropertiesDA();
        }

        public string getValue(string property)
        {
            return ((ApplicationPropertiesDA)_abstractDA).getValue(property);
        }

        public int add(string property, string value)
        {
            return ((ApplicationPropertiesDA)_abstractDA).add(property, value);
        }

        public ApplicationPropertiesEntity get(string property)
        {
            return ((ApplicationPropertiesDA)_abstractDA).get(property);
        }
    }
}
