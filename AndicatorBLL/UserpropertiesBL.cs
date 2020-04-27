using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;
using System.Data;

namespace AndicatorBLL
{
    public class UserpropertiesBL : RMX_TOOLS.BLL.AbstractBL
    {
        public static string MENU_RECIEVED_PERMISSION = "MNU_RECIEVED_LETTER_PERM";
        public static string MENU_SEND_PERMISSION = "MNU_SEND_LETTER_PERM";
        public static string MENU_CHEQUE_INFO = "MNU_CHEQUE_INFO";
        public static string MENU_USERS_PERMISSION = "MNU_USERS_PERM";
        public static string MENU_BASIC_INFO_PERMISSION = "MNU_BASIC_INFO_PERM";
        public static string MENU_COMPANY_PERMISSION = "MNU_COMPANY_PERM";
        public static string MENU_COMPANY_READ_ONLY_PERMISSION = "MNU_COMPANY_READ_ONLY_PERM";
        public static string MENU_COLOR_PERMISSION = "MNU_COLOR_PERM";
        public static string MENU_AGENT_PERMISSION = "MNU_AGENT_PERM";
        public static string MENU_AGENT_READ_ONLY_PERMISSION = "MNU_AGENT_READ_ONLY_PERM";
        public static string MENU_WORKING_STATISTIC = "MNU_WORKING_STATISTIC";
        public static string MENU_REFERENCE_CYCLE = "MNU_REFERENCE_CYCLE";
        public static string MENU_LETTER_ANSWER_COUNTLIST = "MNU_LETTER_ANSWER_COUNTLIST";

        public UserpropertiesBL()
        {
            _abstractDA = new UserPropertiesDA(); 
        }

        public UserPropertiesEntity get()
        {
            return ((UserPropertiesDA)_abstractDA).get();
        }

        public UserPropertiesEntity get(int userid)
        {
            return ((UserPropertiesDA)_abstractDA).get(userid);
        }
        
        public UserPropertiesEntity get(int userid, string proerty)
        {
            return ((UserPropertiesDA)_abstractDA).get(userid,proerty);
        }

        public void updateProperty(int userid, string property, string value)
        {
            UserPropertiesEntity entity = get(userid, property);
            if (entity.Tables[entity.FilledTableName].Rows.Count > 0)
            {
                ((UserPropertiesDA)_abstractDA).updateProperty(userid, property, value);
            }
            else
            {
                UserPropertiesEntity newEntity = new UserPropertiesEntity();
                DataRow dr = newEntity.Tables[newEntity.TableName].NewRow();
                dr[UserPropertiesEntity.FIELD_USERID] = userid;
                dr[UserPropertiesEntity.FIELD_PROPERTY] = property;
                dr[UserPropertiesEntity.FIELD_VALUE] = value;
                newEntity.Tables[newEntity.TableName].Rows.Add(dr);
                 ((UserPropertiesDA)_abstractDA).add(newEntity);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity">UserPropertiesEntity instance</param>
        /// <param name="property">property name in UserPropertiesBL</param>
        /// <returns>null if empty</returns>
        public string getValue(UserPropertiesEntity entity, string property)
        {
            if (entity == null)
                return "" ;
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                string p = "";
                if(entity.get(UserPropertiesEntity.FIELD_PROPERTY) != null)
                    p = entity.get(i, UserPropertiesEntity.FIELD_PROPERTY).ToString();
                if (p.Equals(property))
                {
                    object v = entity.get(i, UserPropertiesEntity.FIELD_VALUE);
                    return (v != null ? v.ToString() : null); 
                }
            }
            return null;
        }

        internal int deleteByUser(int userid)
        {
            return ((UserPropertiesDA)_abstractDA).deleteByUserId(userid);
        }
    }
}
