using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class UsersReplyDA : AbstractDAL
    {
        public UsersReplyEntity get(int letterid)
        {
            UsersReplyEntity entity = new UsersReplyEntity();
            string cond = UsersReplyEntity.FIELD_LETTERID + "=" + provider.getSQLString(letterid);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public UsersReplyEntity getById(int id)
        {
            UsersReplyEntity entity = new UsersReplyEntity();
            string cond = UsersReplyEntity.FIELD_ID + "=" + provider.getSQLString(id);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public UsersReplyEntity get(int letterid, int userid)
        {
            UsersReplyEntity entity = new UsersReplyEntity();
            string cond = UsersReplyEntity.FIELD_LETTERID + "=" + provider.getSQLString(letterid)
             + " AND " + UsersReplyEntity.FIELD_USERID + "=" + provider.getSQLString(userid);

            provider.loadToDataSet(entity, cond);
            
            return entity;
        }
        
        public int finalizeReply(int letterid, int userid)
        {
            AbstractCommonData entity = new UsersReplyEntity();
            string update = "UPDATE " + entity.TableName + " SET " + UsersReplyEntity.FIELD_FINALIZED + "=" +
                provider.getSQLString(true) 
                + "  WHERE " + UsersReplyEntity.FIELD_LETTERID + "=" + provider.getSQLString(letterid) + " AND " +
                UsersReplyEntity.FIELD_USERID + "=" + provider.getSQLString(userid);
            return provider.delete(update);

        }

        public int add(UsersReplyEntity entity)
        {
            return provider.add(entity);
        }

        public int update(UsersReplyEntity entity)
        {
            return provider.update(entity);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new UsersReplyEntity();
            string delQuery = "delete from" + entity.TableName + " where " + entity.IndexFieldName + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }

    }
}
