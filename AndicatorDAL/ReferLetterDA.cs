using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class ReferLetterDA : AbstractDAL
    {
        
        public ReferLetterEntity get(int letterId)
        {
            ReferLetterEntity entity = new ReferLetterEntity();
            string cond = ReferLetterEntity.FIELD_LETTER_ID+ "=" + provider.getSQLString(letterId);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public int getReferCount(int letterId)
        {
            ReferLetterEntity entity = get(letterId);
            return entity.Tables[entity.FilledTableName].Rows.Count;
        }

        public int add(ReferLetterEntity letterEntity)
        {
            return provider.add(letterEntity);
        }

        public int update(ReferLetterEntity entity)
        {
            return provider.update(entity);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new ReferLetterEntity();
            string delQuery = "DELETE FROM " + entity.TableName + " WHERE " + ReferLetterEntity.indexField + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }

        public ReferLetterEntity getByUserId(int userid)
        {
            ReferLetterEntity entity = new ReferLetterEntity();
            string cond = ReferLetterEntity.FIELD_REFER_FROM_USER + "=" + provider.getSQLString(userid) + " OR " +
                ReferLetterEntity.FIELD_REFER_TO_USER + "=" + provider.getSQLString(userid);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public ReferLetterEntity getByUserFromId(int userid, DateTime fromDate, DateTime toDate)
        {
            ReferLetterEntity entity = new ReferLetterEntity();
            string cond = ReferLetterEntity.FIELD_REFER_FROM_USER + "=" + provider.getSQLString(userid) + " and " +
               provider.getBetweenDate(ReferLetterEntity.FIELD_REFER_DATE, fromDate, toDate, null);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public ReferLetterEntity getByUserToId(int userid, DateTime fromDate, DateTime toDate)
        {
            ReferLetterEntity entity = new ReferLetterEntity();
            string cond = ReferLetterEntity.FIELD_REFER_TO_USER+ "=" + provider.getSQLString(userid) + " and "  +
                provider.getBetweenDate(ReferLetterEntity.FIELD_REFER_DATE, fromDate, toDate, null);
            provider.loadToDataSet(entity, cond);
            return entity;
        }


        public int removeUserRefer(int userid)
        {
            int i = 0;
            AbstractCommonData entity = new ReferLetterEntity();

            string delQuery = "UPDATE " + entity.TableName + " SET " + ReferLetterEntity.FIELD_REFER_FROM_USER + "=" +
               provider.getSQLString(userid) + " WHERE " + ReferLetterEntity.FIELD_REFER_FROM_USER + "=" + provider.getSQLString(userid);
            i = provider.executeNonQuery(delQuery);

            delQuery = "UPDATE " + entity.TableName + " SET " + ReferLetterEntity.FIELD_REFER_TO_USER + "=" +
               provider.getSQLString(userid) + " WHERE " + ReferLetterEntity.FIELD_REFER_TO_USER + "=" + provider.getSQLString(userid);
            i += provider.executeNonQuery(delQuery);

            return i;
        }

        public ReferCountLetterEntity getReferCount(int count, DateTime fromDate, DateTime toDate)
        {
            ReferCountLetterEntity entity = new ReferCountLetterEntity();

            string cond = ReferCountLetterEntity.FIELD_REFER_COUNT+ ">=" + provider.getSQLString(count) + " and " +
                provider.getBetweenDate(ReferCountLetterEntity.FIEL_LETTERDATE, fromDate, toDate, null);
            
            provider.loadToDataSet(entity, cond);
            return entity;

        }

        public ReferLetterEntity getLastRefered(int letterId)
        {

            string sqlQuery = "SELECT * " +
                  "FROM [andicator].[dbo].[REFERLETTER] REF, " +
                  "(SELECT MAX(REFERDATE) MAXREF " +
                  "  FROM [andicator].[dbo].REFERLETTER INREF " +
                  " WHERE INREF.LETTERID = " + letterId + ") REF2 " +
                  "WHERE REF.LETTERID =" + letterId + " AND REF2.MAXREF = REF.REFERDATE";
            
            ReferLetterEntity entity = new ReferLetterEntity();

            provider.executeSelect(sqlQuery, entity);
            return entity;        
            
        }

    }

}
