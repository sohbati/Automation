using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.hasti.entity;
using RMX_TOOLS.common;

namespace RMX_TOOLS.hasti.dal
{
    public class BasicInfoDA : AbstractDAL
    {
        IDataProvider dp = Config.provider;
        
        /*public BasicInfoEntity get(int id)
        {
            BasicInfoEntity entity = new BasicInfoEntity();
            string cond = BasicInfoEntity.FIELD_ID + "=" + dp.getSQLString(id);
            dp.loadToDataSet(BasicInfoEntity.TABLE, entity, "");
            return entity;
        }
        */
        public int add(BasicInfoEntity basicInfoEntity)
        {
            return dp.add(basicInfoEntity);
        }
        
        public int updateCustomData(int id, string customData)
        {
            BasicInfoEntity entity = new BasicInfoEntity();
            string q = "UPDATE " + entity.TableName + " SET " + 
                BasicInfoEntity.FIELD_CUSTOMFIELD + "=" + dp.getSQLString(customData) + " WHERE " +
                BasicInfoEntity.FIELD_ID + "=" + dp.getSQLString(id);
            return provider.executeNonQuery(q);
        }

        public int delete(int id)
        {

            BasicInfoEntity entity = new BasicInfoEntity();
            string delQuery = "delete from " + entity.TableName + " where " + entity.IndexFieldName + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }

    }
}
