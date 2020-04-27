using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class UserTreeDA : AbstractDAL
    {
        public UserTreeEntity get()
        {
            UserTreeEntity entity = new UserTreeEntity();
            //string cond = UserTreeEntity.FIELD_LETTER_TYPE + "=" + provider.getSQLString(letterType);
            provider.loadToDataSet(entity);
            return removeDuplicates(entity);
        }

        public UserTreeEntity get(int id)
        {
            UserTreeEntity entity = new UserTreeEntity();
            string cond = UserTreeEntity.FIELD_ID + "=" + provider.getSQLString(id);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public UserTreeEntity getByUserIds(string ids)
        {
            UserTreeEntity entity = new UserTreeEntity();
            string cond = UserTreeEntity.FIELD_USER_ID + " in (" + ids + ")";
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public UserTreeEntity getByUserType(int userType)
        {
            UserTreeEntity entity = new UserTreeEntity();
            string cond = UserTreeEntity.VIEW_FIELD_USER_USERTYPE + "=" + userType;
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public UserTreeEntity getParent(int userid)
        {
            UserTreeEntity entity = new UserTreeEntity();
            string cond = "'/'+" + UserTreeEntity.FIELD_USER_PATH + " like" + provider.getSQLString("%/" + userid + "");
            provider.loadToDataSet(entity, cond);
            string parentIds = "";
            for(int i=0;i< entity.Tables[entity.FilledTableName].Rows.Count; i++) 
            {
                string path = entity.get(i, UserTreeEntity.FIELD_USER_PATH).ToString();
                if (path != null && path.Length >= 3)
                {
                    parentIds += getParent(path) + ",";
                }
            }

            if (parentIds.Length > 0)
            {
                parentIds = parentIds.Substring(0, parentIds.Length - 1);
                return getByUserIds(parentIds);
            }
            return null;
        }

        private string getParent(string path)
        {
            string[] s = path.Split('/');
            return s[s.Length - 2];
        }

        public UserTreeEntity getByUserTableId(int userid)
        {
            UserTreeEntity entity = new UserTreeEntity();
            string cond = UserTreeEntity.FIELD_USER_ID + "=" + userid;
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public UserTreeEntity getByUserId(string userid)
        {
            UserTreeEntity entity = new UserTreeEntity();
            string cond = "'/'+" + UserTreeEntity.FIELD_USER_PATH + " like" + provider.getSQLString("%/" + userid + "/%");
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public UserTreeEntity getUserAllAccessPath(int userid)
        {
            UserTreeEntity entity = new UserTreeEntity();
            string cond = "'/'+" + UserTreeEntity.FIELD_USER_PATH + "+'/' like" + provider.getSQLString("/%" + userid + "/%");
            provider.loadToDataSet(entity, cond);

            return removeDuplicates(entity);
        }

        private UserTreeEntity removeDuplicates(UserTreeEntity entity)
        {
            if (entity.Tables[entity.FilledTableName].Rows.Count == 0)
                return entity;
            string treeids = "";
            string blackids = "";
            int u1 = -1;
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                if (blackids.IndexOf(entity.get(i, UserTreeEntity.FIELD_ID) + ",") < 0)
                {
                    treeids += entity.get(i, UserTreeEntity.FIELD_ID) + ",";
                    u1 = int.Parse(entity.get(i, UserTreeEntity.FIELD_USER_ID).ToString());
                    int u2 = -1;
                    for (int j = i + 1; j < entity.Tables[entity.FilledTableName].Rows.Count; j++)
                    {
                        string treeId = entity.get(j, UserTreeEntity.FIELD_ID) + "";
                        u2 = int.Parse(entity.get(j, UserTreeEntity.FIELD_USER_ID).ToString());
                        if (u1 == u2)
                            blackids += treeId + ",";

                    }
                }
            }
            string cond = "ID IN(" + treeids.Substring(0, treeids.Length - 1) + ") AND ACTIVE=1";
            entity = new UserTreeEntity();
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public UserTreeEntity getByParentId(int parentId)
        {
            UserTreeEntity entity = new UserTreeEntity();
            string cond = "";
            if (parentId <= 0)
                cond = UserTreeEntity.FIELD_PARENT_ID + " <=0 OR " + UserTreeEntity.FIELD_PARENT_ID  + " IS NULL";
            else 
                cond = UserTreeEntity.FIELD_PARENT_ID + "=" + provider.getSQLString(parentId);
            provider.loadToDataSet(entity, cond);
            return entity;
        }
        
        public int add(UserTreeEntity entity)
        {
            return provider.add(entity);
        }

        public int update(UserTreeEntity entity)
        {
            return provider.update(entity);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new UserTreeEntity();
            string delQuery = "DELETE FROM " + entity.TableName + " where " + entity.IndexFieldName + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }

    }
}
