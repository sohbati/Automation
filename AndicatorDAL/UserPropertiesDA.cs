using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class UserPropertiesDA : AbstractDAL
    {
        public UserPropertiesEntity get()
        {
            UserPropertiesEntity entity = new UserPropertiesEntity();
            //string cond = UserPropertiesEntity.FIELD_LETTER_TYPE + "=" + provider.getSQLString(letterType);
            provider.loadToDataSet(entity);
            return entity;
        }

        public UserPropertiesEntity get(int userid)
        {
            UserPropertiesEntity entity = new UserPropertiesEntity();
            string cond = UserPropertiesEntity.FIELD_USERID + "=" + provider.getSQLString(userid);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public UserPropertiesEntity get(int userid, string property)
        {
            UserPropertiesEntity entity = new UserPropertiesEntity();
            string cond = UserPropertiesEntity.FIELD_USERID + "=" + provider.getSQLString(userid) +
                " AND " + UserPropertiesEntity.FIELD_PROPERTY + "=" + provider.getSQLString(property);

            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public int add(UserPropertiesEntity entity)
        {
            return provider.add(entity);
        }

        public int update(UserPropertiesEntity entity)
        {
            return provider.update(entity);
        }

        public void updateProperty(int userid, string property, string value)
        {
            UserPropertiesEntity  en = new UserPropertiesEntity();
            string sql = "UPDATE " + en.TableName + " set " + UserPropertiesEntity.FIELD_VALUE +"=" +provider.getSQLString(value) +
                " WHERE " + UserPropertiesEntity.FIELD_USERID +"=" + provider.getSQLString(userid) + " AND " +
                UserPropertiesEntity.FIELD_PROPERTY + "=" + provider.getSQLString(property);
            provider.executeNonQuery(sql);
        }



        public int deleteByUserId(int userid)
        {
            AbstractCommonData entity = new UserPropertiesEntity();
            string delQuery = "DELETE FROM " + entity.TableName + " WHERE " + UserPropertiesEntity.FIELD_USERID + "=" + provider.getSQLString(userid);
            return provider.delete(delQuery);
        }
    }
}
