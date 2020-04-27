using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class ReferChequeDA : AbstractDAL
    {

        public ReferChequeEntity get(int chequeId)
        {
            ReferChequeEntity entity = new ReferChequeEntity();
            string cond = ReferChequeEntity.FIELD_CHEQUE_ID + "=" + provider.getSQLString(chequeId);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public int getReferCount(int chequeId)
        {
            ReferChequeEntity entity = get(chequeId);
            return entity.Tables[entity.FilledTableName].Rows.Count;
        }

        public int add(ReferChequeEntity ChequeEntity)
        {
            return provider.add(ChequeEntity);
        }

        public int update(ReferChequeEntity entity)
        {
            return provider.update(entity);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new ReferChequeEntity();
            string delQuery = "DELETE FROM " + entity.TableName + " WHERE " + ReferChequeEntity.indexField + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }


        public ReferChequeEntity getByUserId(int userid)
        {
            ReferChequeEntity entity = new ReferChequeEntity();
            string cond = ReferChequeEntity.FIELD_REFER_FROM_USER + "=" + provider.getSQLString(userid) + " OR " +
                ReferChequeEntity.FIELD_REFER_TO_USER + "=" + provider.getSQLString(userid);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public int removeUserRefer(int userid)
        {
            int i = 0;
            AbstractCommonData entity = new ReferChequeEntity();
            
            string delQuery = "UPDATE " + entity.TableName + " SET " + ReferChequeEntity.FIELD_REFER_FROM_USER + "=" + 
               provider.getSQLString(userid) + " WHERE " + ReferChequeEntity.FIELD_REFER_FROM_USER + "=" + provider.getSQLString(userid);
            i = provider.executeNonQuery(delQuery);

            delQuery = "UPDATE " + entity.TableName + " SET " + ReferChequeEntity.FIELD_REFER_TO_USER + "=" +
               provider.getSQLString(userid) + " WHERE " + ReferChequeEntity.FIELD_REFER_TO_USER + "=" + provider.getSQLString(userid);
            i += provider.executeNonQuery(delQuery);

            return i;
        }
    }
}
