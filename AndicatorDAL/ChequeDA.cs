using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class ChequeDA : AbstractDAL
    {
        public ChequeEntity get()
        {
            ChequeEntity entity = new ChequeEntity();
            //string cond = ChequeEntity.FIELD_LETTER_TYPE + "=" + provider.getSQLString(letterType);
            provider.loadToDataSet(entity);
            return entity;
        }

        public ChequeEntity get(int id)
        {
            ChequeEntity entity = new ChequeEntity();
            string cond = ChequeEntity.FIELD_ID + "=" + provider.getSQLString(id);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public ChequeEntity get(string cond, bool isArchived)
        {
            string archive = "";
            if (!isArchived)
                archive = " (ARCHIVE is null OR ARCHIVE=0) ";
            else
                archive = " ARCHIVE=1 ";

            ChequeEntity entity = new ChequeEntity();
            
            if (cond.Length > 0)
                cond += " AND ";
            cond += archive;

            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public ChequeEntity get(string cond, bool isArchived, int userid)
        {
            string archive = "";
            if (!isArchived)
                archive = " (ARCHIVE is null OR ARCHIVE=0) ";
            else
                archive = " ARCHIVE=1 ";

            ChequeEntity entity = new ChequeEntity();

            if (cond.Length > 0)
                cond += " AND ";
            cond += archive;

            cond += " AND (" + ChequeEntity.VIEW_FIELD_REFERENCED_USER_ID + "=" + provider.getSQLString(userid) +
               " AND GETDATE() - CAST('1900-01-04' AS DATETIME) >" + ChequeEntity.FIELD_REFFER_DATE + ")";
            provider.loadToDataSet(entity, cond);
            return entity;
        }
        public ChequeEntity get(string cond)
        {
            ChequeEntity entity = new ChequeEntity();
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public int add(ChequeEntity entity)
        {
            return provider.add(entity);
        }

        public int update(ChequeEntity entity)
        {
            return provider.update(entity);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new ChequeEntity();
            string delQuery = "DELETE FROM " + entity.TableName + " where " + entity.IndexFieldName + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }

        public int updateRefferenceUser(int chequeId, int userTreeId, int referFromUserId)
        {
            AbstractCommonData entity = new ChequeEntity();
            string sql = "UPDATE " + entity.TableName + " SET " + ChequeEntity.FIELD_USER_TREE_ID + "=" + provider.getSQLString(userTreeId) +
                " , " + ChequeEntity.FIELD_REFER_FROM_USER_ID + "=" + provider.getSQLString(referFromUserId) +
                " WHERE " + entity.IndexFieldName + "=" + provider.getSQLString(chequeId);
            return provider.executeNonQuery(sql);
        }

        public int updateColor(int chequeid , string color)
        {
            string sql1 = "UPDATE CHEQUE  SET COLOR = '" + color + "' WHERE ID = " + chequeid;
            return provider.executeNonQuery(sql1);
        }

        public int updateColor(string color)
        {
            string sql1 = "UPDATE CHEQUE  SET COLOR = '' WHERE ARCHIVE = 1";

            string sql2 = "UPDATE CHEQUE SET COLOR = '' WHERE  " +
                 " (SELECT COUNT(0) FROM CHEQUEREPLY WHERE  CHEQUEREPLY.CHEQUEID = CHEQUE.ID) > 0 " +
                 " AND (ARCHIVE = 0 OR ARCHIVE IS NULL) ";
            string sql3 = "UPDATE CHEQUE SET COLOR = '" + color + "' WHERE  " +
                   " (SELECT COUNT(0) FROM CHEQUEREPLY WHERE  CHEQUEREPLY.CHEQUEID = CHEQUE.ID) <= 0 " +
                 " AND (ARCHIVE = 0 OR ARCHIVE IS NULL)";
            provider.executeNonQuery(sql1);
            provider.executeNonQuery(sql2);
            provider.executeNonQuery(sql3);
            return 1;
        }



        public ChequeEntity getRefferedToUser(int userId)
        {
            ChequeEntity entity = new ChequeEntity();
            string cond = ChequeEntity.VIEW_FIELD_REFERENCED_USER_ID + "=" + provider.getSQLString(userId);

            return get(cond);
        }

        public ChequeEntity getByUserTreeId(int userTreeId)
        {
            ChequeEntity entity = new ChequeEntity();
            string cond = ChequeEntity.FIELD_USER_TREE_ID + "=" + provider.getSQLString(userTreeId) +
                "AND  (" + ChequeEntity.FIELD_ARCHIVE + "= 0 or " + ChequeEntity.FIELD_ARCHIVE + " is null)"; 

            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public ChequeEntity getByUserTreeIds(string userTreeIds)
        {
            ChequeEntity entity = new ChequeEntity();
            string cond = ChequeEntity.FIELD_USER_TREE_ID + " in(" + userTreeIds + ")" +
                  "AND  (" + ChequeEntity.FIELD_ARCHIVE + "= 0 or " + ChequeEntity.FIELD_ARCHIVE + " is null)"; 
                  
                    
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public int changeUserTreeOwnedCheques(int fromUserTreeId, int toUSerTreeId)
        {
            string sql = "UPDATE CHEQUE SET " + ChequeEntity.FIELD_USER_TREE_ID + "=" + provider.getSQLString(toUSerTreeId) +
                " WHERE " + ChequeEntity.FIELD_USER_TREE_ID + "=" + provider.getSQLString(fromUserTreeId) +
                  " and (" + ChequeEntity.FIELD_ARCHIVE + "= 0 or " + ChequeEntity.FIELD_ARCHIVE + " is null)";
            return provider.executeNonQuery(sql);
        }

        public int changeUserTreeOwnedCheques(string fromUserTreeIds, int toUSerTreeId)
        {
            string sql = "UPDATE CHEQUE SET " + ChequeEntity.FIELD_USER_TREE_ID + "=" + provider.getSQLString(toUSerTreeId) +
                " WHERE " + ChequeEntity.FIELD_USER_TREE_ID + " in(" + fromUserTreeIds + ")" +
                " AND  (" + ChequeEntity.FIELD_ARCHIVE + "= 0 or " + ChequeEntity.FIELD_ARCHIVE + " is null)";
            return provider.executeNonQuery(sql);
        }
    }
}
