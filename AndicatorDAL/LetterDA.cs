using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;
using System.Data.SqlClient;
using System.Data;

namespace AndicatorDAL
{
    public class LetterDA : AbstractDAL
    {
        private string addChainedCondition()
        {
            return "(" + LetterEntity.FIELD_NEXTLETTERID + " IS NULL OR " +
                    LetterEntity.FIELD_NEXTLETTERID + "<= 0)";
        }

        private LetterEntity get(LetterEntity entity, string cond, bool showLastChained) 
        {
            if (cond != null && cond.Length > 0)
                cond += " AND (" + LetterEntity.FIELD_CANCEL + "= 0 OR " + LetterEntity.FIELD_CANCEL + " IS NULL )";
            else
                cond += " (" + LetterEntity.FIELD_CANCEL + "= 0 OR" + LetterEntity.FIELD_CANCEL + " IS NULL )";

            if (showLastChained)
            {
                cond += " AND " + addChainedCondition();
            }

            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public LetterEntity get(string ids)
        {
            LetterEntity entity = new LetterEntity();
            string cond = LetterEntity.FIELD_ID+ " in (" + ids + ")";

            return get(entity, cond, false);
        }

        public LetterEntity get(int letterType, bool showLastChained)
        {
            LetterEntity entity = new LetterEntity();
            string cond = LetterEntity.FIELD_LETTER_TYPE + "=" + provider.getSQLString(letterType) ;
            
            return get(entity, cond, showLastChained);
        }

        public LetterEntity get(string cond, int letterType, bool showLastChained)
        {
            LetterEntity entity = new LetterEntity();
            if (cond != null && cond.Length > 0)
                cond += " AND ";
            cond += " "  + LetterEntity.FIELD_LETTER_TYPE + "=" + provider.getSQLString(letterType);
            return get(entity, cond, showLastChained);
        }

        public LetterEntity get(int letterType, String letterNumber, bool showLastChained)
        {
            LetterEntity entity = new LetterEntity();
            string cond = LetterEntity.FIELD_LETTER_TYPE + "=" + provider.getSQLString(letterType) +
                " AND " + LetterEntity.FIELD_LETTER_NUMBER + "=" +provider.getSQLString(letterNumber);
            
            return get(entity, cond, showLastChained);
        }

        public LetterEntity get(int letterType, bool isArchived, bool showLastChained)
        {
            LetterEntity entity = new LetterEntity();
            string archive = "";
            if (!isArchived)
                archive = " (ARCHIVE is null OR ARCHIVE=0) ";
            else
                archive = " ARCHIVE=1 ";
            string cond = LetterEntity.FIELD_LETTER_TYPE + "=" + provider.getSQLString(letterType) +
                " AND " + archive;
            
            return get(entity, cond, showLastChained);
        }

        public LetterEntity getFastActions(int userid, bool showLastChained)
        {
            LetterEntity entity = new LetterEntity();
            string archive = " (ARCHIVE is null OR ARCHIVE=0) ";

            string cond = archive + " AND " + LetterEntity.VIEW_FIELD_REFERENCED_USER_ID + "=" + provider.getSQLString(userid);
            cond += " AND FASTACTION=1";
            return get(entity, cond, showLastChained);
        }

        public LetterEntity get(int letterType, bool isArchived, int userid, bool showLastChained)
        {
            LetterEntity entity = new LetterEntity();
            string archive = "";
            if (!isArchived)
                archive = " (ARCHIVE is null OR ARCHIVE=0) ";
            else
                archive = " ARCHIVE=1 ";

            string cond = LetterEntity.FIELD_LETTER_TYPE + "=" + provider.getSQLString(letterType) +
                " AND " + archive +
                "AND (" + LetterEntity.VIEW_FIELD_REFERENCED_USER_ID + "=" + provider.getSQLString(userid);

            cond += " AND GETDATE() >=" + LetterEntity.FIELD_REFFER_DATE + ")";

            //cond += "or (" + LetterEntity.FIELD_LETTER_TYPE + "=" + provider.getSQLString(letterType) + " AND "
            //    + LetterEntity.FIELD_REFER_FROM_USER_ID + "=" + provider.getSQLString(userid) + " AND GETDATE() <REFFERDATE)";
            return get(entity, cond, showLastChained);
        }

        public LetterEntity getRefferedToUser(int userid, bool showLastChained)
        {
            LetterEntity entity = new LetterEntity();
            string cond = LetterEntity.VIEW_FIELD_REFERENCED_USER_ID + "=" + provider.getSQLString(userid);
            
            return get(entity, cond, showLastChained);
        }

        public LetterEntity getByLetterId(int id)
        {
            LetterEntity entity = new LetterEntity();
            string cond = LetterEntity.FIELD_ID+ "=" + provider.getSQLString(id);

            return get(entity, cond, false);
        }
        
        public LetterEntity getByGroupId(int id)
        {
            LetterEntity entity = new LetterEntity();
            string cond = LetterEntity.FIELD_GROUP_ID+ "=" + provider.getSQLString(id);

            return get(entity, cond, false);
        }

        public LetterEntity getByUserTreeId(int userTreeid)
        {
            LetterEntity entity = new LetterEntity();
            string cond = LetterEntity.FIELD_USER_TREE_ID+ "=" + provider.getSQLString(userTreeid) +
            " and  (" + LetterEntity.FIELD_ARCHIVE + "= 0 or " + LetterEntity.FIELD_ARCHIVE + " is null)";
            return get(entity, cond, false);
        }

        public LetterEntity getByUserTreeIds(string userTreeids)
        {
            LetterEntity entity = new LetterEntity();
            string cond = LetterEntity.FIELD_USER_TREE_ID + " in(" + userTreeids + ")" +
            " and  (" + LetterEntity.FIELD_ARCHIVE + "= 0 or " + LetterEntity.FIELD_ARCHIVE + " is null)";
            return get(entity, cond, false);
        }

        public LetterEntity getByLetterNumber(string letterNumber)
        {
            LetterEntity entity = new LetterEntity();
            string cond = LetterEntity.FIELD_LETTER_NUMBER + "=" + provider.getSQLString(letterNumber);
            
            return get(entity, cond, false);
        }

        public int add(LetterEntity letterEntity)
        {
            return provider.add(letterEntity);
        }

        public int update(LetterEntity entity)
        {
            return provider.update(entity);
        }
        
        public int changeUserTreeOwnedLetters(int fromUserTreeId, int toUSerTreeId)
        {
            string sql = "UPDATE LETTER SET " + LetterEntity.FIELD_USER_TREE_ID + "=" + provider.getSQLString(toUSerTreeId) +
                " WHERE " + LetterEntity.FIELD_USER_TREE_ID + "=" + provider.getSQLString(fromUserTreeId) +
                  "  and (" + LetterEntity.FIELD_ARCHIVE + "= 0 or " + LetterEntity.FIELD_ARCHIVE + " is null)";
            return provider.executeNonQuery(sql);
        }
        
        public int changeUserTreeOwnedLetters(string fromUserTreeIds, int toUSerTreeId)
        {
            string sql = "UPDATE LETTER SET " + LetterEntity.FIELD_USER_TREE_ID + "=" + provider.getSQLString(toUSerTreeId) +
                " WHERE " + LetterEntity.FIELD_USER_TREE_ID + " in(" + fromUserTreeIds  + ")   "
                 + " and (" + LetterEntity.FIELD_ARCHIVE +"= 0 or " + LetterEntity.FIELD_ARCHIVE + " is null)";
            return provider.executeNonQuery(sql);
        }

        public int updateRefferenceUser(int letterid, int userTreeId, int referFromUserId)
        {
            string sql = "UPDATE LETTER SET " + LetterEntity.FIELD_USER_TREE_ID + "=" + provider.getSQLString(userTreeId) +
                " , " + LetterEntity.FIELD_REFER_FROM_USER_ID + "=" + provider.getSQLString(referFromUserId) +
                " WHERE " + LetterEntity.indexField + "=" + provider.getSQLString(letterid);
              
            return provider.executeNonQuery(sql);
        }

        public int updateRefCountColor(int letterid, String color)
        {
            string sql = "UPDATE LETTER SET " + LetterEntity.FIELD_COLOR + "=" + provider.getSQLString(color) +
                " WHERE " + LetterEntity.indexField + "=" + provider.getSQLString(letterid);
            return provider.executeNonQuery(sql);
        }
 

        public int updateMaxRefLimitColor(int maxRefLimit, String color)
        {
               string sql ="UPDATE LETTER " +
	            " SET COLOR = '" + color + "' " +
	            " WHERE ID IN (select ID from ( " + 
                " SELECT L.ID, L.SUMMARY,(SELECT COUNT(*) FROM REFERLETTER R " + 
                " WHERE R.LETTERID = L.ID)as CO FROM LETTER L " +
                ")f where CO >= " + provider.getSQLString(maxRefLimit) + ")";

            return provider.executeNonQuery(sql);
        }

        public int updateConfimedsColor(String color)
        {
            string sql = "UPDATE LETTER SET " + LetterEntity.FIELD_COLOR + "=" + provider.getSQLString(color) +
                " WHERE " + LetterEntity.FIELD_FINAL_CONFIRM+ "=" + provider.getSQLString(true);
            return provider.executeNonQuery(sql);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new LetterEntity();
            string delQuery = "update " + entity.TableName +" set " + LetterEntity.FIELD_CANCEL + "=" + 
                provider.getSQLString(1) + " where " + LetterEntity.indexField + "=" + provider.getSQLString(id);

            //delQuery = "DELETE FROM " + entity.TableName +  " WHERE " + LetterEntity.indexField + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }

        public int updateColor(int letterStateID, string color)
        {
            string sql = "UPDATE LETTER SET " + LetterEntity.FIELD_COLOR + "=" + provider.getSQLString(color) +
                " WHERE " + LetterEntity.FIELD_LETTER_STATE_ID + "=" + provider.getSQLString(letterStateID);
            return provider.executeNonQuery(sql);
        }

        public int updateRefferenceDate(DateTime dateTime, int letterId)
        {
            string sql = "UPDATE LETTER SET " +  
                LetterEntity.FIELD_REFFER_DATE +
                //"='" + dateTime.ToShortDateString() + "'" +

                 "= convert(datetime,'" + 
                 dateTime.Year + "-" +
                 dateTime.Month + "-" +
                 dateTime.Day + 
                 " 00:00:00.000" + "') " + 
                " WHERE " + LetterEntity.FIELD_ID + "=" + provider.getSQLString(letterId);
            
            return provider.executeNonQuery(sql);
        }

        public void removeFromGroup(int letterId)
        {
            string query = "UPDATE LETTER SET GROUPID=null "  + " WHERE ID=" + letterId;
            RMX_TOOLS.data.Config.provider.executeNonQuery(query);
        }

        public void addLetterGroup(int letterId, int letterGroupId)
        {
            string query = "UPDATE LETTER SET GROUPID=" + letterGroupId + " WHERE ID=" + letterId;
            RMX_TOOLS.data.Config.provider.executeNonQuery(query);
        }

        public int UpdateNextLetter(int masterLetterId, int nextLetterId)
        {
            string s = nextLetterId + "";
            if (nextLetterId <= 0)
                s = "null";

            string query = "UPDATE LETTER SET NEXTLETTERID=" + s + " WHERE ID=" + masterLetterId;
            return RMX_TOOLS.data.Config.provider.executeNonQuery(query);
        }

        public int UpdatePriorLetter(int masterLetterId, int priorLetterId)
        {
            string s = priorLetterId + "";
            if (priorLetterId <= 0)
                s = "null";
            string query = "UPDATE LETTER SET PREVIOUSLETTERID=" + s + " WHERE ID=" + masterLetterId;
            return RMX_TOOLS.data.Config.provider.executeNonQuery(query);
        }

        public void updateChainedArchives(int lastOfChinLetterId, bool archive, bool finalConfirm, bool fastAction)
        {
            SqlParameter p1 = new SqlParameter("@LetterId", lastOfChinLetterId);
            SqlParameter p2 = new SqlParameter("@archive", archive);
            SqlParameter p3 = new SqlParameter("@confirm", finalConfirm);
            SqlParameter p4 = new SqlParameter("@fastAction", fastAction);

            System.Collections.ArrayList list = new System.Collections.ArrayList();
            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
            list.Add(p4);

            ((SqlServerProvider)Config.provider).RunStoredProcedure("UpdateArchiveInChainIds", list);
        }

        public string getAllChainedsByLetterId(int letterid)
        {
            DataSet ds = ((SqlServerProvider)Config.provider).executeSelect("select dbo.fn_getAllChainedsById(" + letterid+ ")");
            return ds.Tables[0].Rows[0][0].ToString();
        }
    }
}
