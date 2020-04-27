using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class LetterItemsPermissionDA : AbstractDAL
    {
        public LetterItemsPermissionEntity getByUser(int userid)
        {
            LetterItemsPermissionEntity entity = new LetterItemsPermissionEntity();
            string cond = LetterItemsPermissionEntity.FIELD_USER_ID + "=" + provider.getSQLString(userid);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public LetterItemsPermissionEntity getByTableindex(int tableindex)
        {
            LetterItemsPermissionEntity entity = new LetterItemsPermissionEntity();
            string cond = LetterItemsPermissionEntity.FIELD_ID + "=" + provider.getSQLString(tableindex);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public int addPermission(LetterItemsPermissionEntity entity)
        {
            return provider.add(entity);
        }

        public int update(LetterItemsPermissionEntity entity)
        {
            return provider.update(entity);
        }

        public int deleteByUser(int userid)
        {
            AbstractCommonData entity = new LetterItemsPermissionEntity();
            string delQuery = "DELETE FROM " + entity.TableName + " WHERE " + LetterItemsPermissionEntity.FIELD_USER_ID + "=" + provider.getSQLString(userid);
            return provider.delete(delQuery);
        }
    }
}
