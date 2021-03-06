using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;

namespace RMX_TOOLS.DAL
{
    public class AbstractDAL
    {
        protected data.IDataProvider provider = data.Config.provider;
        public AbstractDAL()
        {

        }

        public int deleteWithIndexField(AbstractCommonData entity) {
            string sql = "delete from " + entity.TableName + " where " + entity.IndexFieldName + "=" +
            provider.getSQLString(entity.Tables[entity.FilledTableName].Rows[0][entity.IndexFieldName].ToString());

            return provider.executeNonQuery(sql);
        }

        public int update(AbstractCommonData entity)
        {
            return provider.update(entity);
        }

        /*
         * ردیف اضافه می کنیم
         * 
         */
        protected void fillRadif(AbstractCommonData entity)
        {
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                entity.Tables[entity.FilledTableName].Rows[i][AbstractCommonData.FIELD_RADIF] = i + 1;

            }
        }

        public void load(AbstractCommonData entity)
        {
            provider.loadToDataSet(entity);
        }

        public void load(AbstractCommonData entity, string cond)
        {
            provider.loadToDataSet(entity, cond);
        }


    }
}
