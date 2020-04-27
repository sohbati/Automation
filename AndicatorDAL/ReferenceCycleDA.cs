using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class ReferenceCycleDA : AbstractDAL
    {
        public ReferenceCycleEntity get()
        {
            ReferenceCycleEntity entity = new ReferenceCycleEntity();
            string cond = "ID > 0";
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public ReferenceCycleEntity get(int id)
        {
            ReferenceCycleEntity entity = new ReferenceCycleEntity();
            string cond = ReferenceCycleEntity.FIELD_ID + "=" + provider.getSQLString(id);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public ReferenceCycleEntity get(string cond)
        {
            ReferenceCycleEntity entity = new ReferenceCycleEntity();
            if (cond.Length > 0)
                cond += " AND ";
            cond += "ID > 0";
            provider.loadToDataSet(entity, cond);
            return entity;
        }


        public int add(ReferenceCycleEntity entity)
        {
            return provider.add(entity);
        }

        public int update(ReferenceCycleEntity entity)
        {
            return provider.update(entity);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new ReferenceCycleEntity();
            string delQuery = "DELETE FROM " + entity.TableName + " where " + entity.IndexFieldName + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }

    }
}
