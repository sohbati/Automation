using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class UsersDA : AbstractDAL
    {
        IDataProvider dp = Config.provider;

        public UsersDA()
        {

        }

        public UsersEntity load(string cond)
        {
            UsersEntity entity = new UsersEntity();
            //string query = "select *,ltrim(rtrim( " +UsersEntity.FIELD_NAME +
            //                "))+' '+ltrim(rtrim(" + UsersEntity.FIELD_FAMILY + "))as nameFamily from " + entity.TableName;
            dp.loadToDataSet(entity, cond);
            fillRadif(entity);
            return entity;
        }

        public UsersEntity getMasterUsers(int masterUserType)
        {
            UsersEntity entity = new UsersEntity();
            string cond = UsersEntity.FIELD_USER_TYPE + "=" + provider.getSQLString(masterUserType); 
            dp.loadToDataSet(entity, cond);
            fillRadif(entity);
            return entity;
        
        }
        public UsersEntity get(int userid)
        {
            UsersEntity entity = new UsersEntity();
            string cond = UsersEntity.FIELD_ID + "=" + provider.getSQLString(userid);
            dp.loadToDataSet(entity, cond);
            fillRadif(entity);
            return entity;
        }

        public UsersEntity get(string cond)
        {
            UsersEntity entity = new UsersEntity();
            dp.loadToDataSet(entity, cond);
            fillRadif(entity);
            return entity;
        }

        public int add(UsersEntity dataSet)
        {
            return dp.add(dataSet);
        }

        public int update(UsersEntity entity)
        {
            return dp.update(entity);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new UsersEntity();
            string sql = "delete from " + entity.TableName + " where " + entity.IndexFieldName + "=" + provider.getSQLString(id); 
            return dp.delete(sql);
        }

        public UsersEntity checkUser(string userName, String password,Boolean isManager)
        {
            UsersEntity entity = new UsersEntity();
            userName = userName.Trim();
            password = password.Trim();
            string s  = (isManager ? "AND USERTYPE =0 " : "");
            string condition = "";
            condition += " USERNAME = '" + userName + "' AND ";
            condition += " PASSWORD = '" + password + "' ";
            
            condition += s;

            condition += " AND ACTIVE=1";
            dp.loadToDataSet(entity, condition);
            return entity;
        }
    }
}
