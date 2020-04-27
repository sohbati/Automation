using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class ChequeReplyDA : AbstractDAL
    {
        public ChequeReplyEntity get()
        {
            ChequeReplyEntity entity = new ChequeReplyEntity();
            //string cond = ChequeReplyEntity.FIELD_LETTER_TYPE + "=" + provider.getSQLString(letterType);
            provider.loadToDataSet(entity);
            return entity;
        }

        public ChequeReplyEntity get(int id)
        {
            ChequeReplyEntity entity = new ChequeReplyEntity();
            string cond = ChequeReplyEntity.FIELD_ID + "=" + provider.getSQLString(id);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public ChequeReplyEntity getByCheque(int chequeid, string cond)
        {
            ChequeReplyEntity entity = new ChequeReplyEntity();
            if (cond == null || cond.Length == 0) 
                cond = ChequeReplyEntity.FIELD_CHEQUEID + "=" + provider.getSQLString(chequeid);
            else
                cond += " AND " + ChequeReplyEntity.FIELD_CHEQUEID + "=" + provider.getSQLString(chequeid);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public ChequeReplyEntity get(string cond)
        {
            ChequeReplyEntity entity = new ChequeReplyEntity();
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public int add(ChequeReplyEntity entity)
        {
            return provider.add(entity);
        }

        public int update(ChequeReplyEntity entity)
        {
            return provider.update(entity);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new ChequeReplyEntity();
            string delQuery = "DELETE FROM " + entity.TableName + " where " + entity.IndexFieldName + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }

    }
}
