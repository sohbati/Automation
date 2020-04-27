using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.hasti.entity;
using RMX_TOOLS.common;
using System.Data;

namespace RMX_TOOLS.hasti.dal
{
    public class ApplicationPropertiesDA : AbstractDAL
    {
        IDataProvider dp = Config.provider;
        
        public int add(string property, string value)
        {
            ApplicationPropertiesEntity entity = get(property);

            ApplicationPropertiesEntity newEntity = new ApplicationPropertiesEntity();
            DataRow dr = newEntity.Tables[newEntity.TableName].NewRow();
            dr[ApplicationPropertiesEntity.FIELD_PROPERTY] = property;
            dr[ApplicationPropertiesEntity.FIELD_VALUE] = value;
            if (entity.Tables[entity.FilledTableName].Rows.Count > 0)
                dr[ApplicationPropertiesEntity.FIELD_ID] = entity.get(ApplicationPropertiesEntity.FIELD_ID);

            newEntity.Tables[newEntity.TableName].Rows.Add(dr);
            
            if (entity.Tables[entity.FilledTableName].Rows.Count > 0)

                return dp.update(newEntity);
            else
                return dp.add(newEntity);
        }

        public ApplicationPropertiesEntity get(string property)
        {
            ApplicationPropertiesEntity entity = new ApplicationPropertiesEntity();
            string cond =  ApplicationPropertiesEntity.FIELD_PROPERTY + "=" + dp.getSQLString(property);
            dp.loadToDataSet(entity, cond);
            return entity;
        }

        public string getValue(string property)
        {
            ApplicationPropertiesEntity entity = new ApplicationPropertiesEntity();
            string cond = ApplicationPropertiesEntity.FIELD_PROPERTY + "=" + dp.getSQLString(property);
            dp.loadToDataSet(entity, cond);
            if (entity.Tables[entity.FilledTableName].Rows.Count > 0)
                return entity.Tables[entity.FilledTableName].Rows[0][ApplicationPropertiesEntity.FIELD_VALUE].ToString();
            return "";
        }

        public int delete(int id)
        {

            BasicInfoEntity entity = new BasicInfoEntity();
            string delQuery = "delete from " + entity.TableName + " where " + entity.IndexFieldName + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }


    }
}
