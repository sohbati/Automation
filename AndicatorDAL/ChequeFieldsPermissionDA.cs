using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class ChequeFieldsPermissionDA : AbstractDAL
    {
        public ChequeFieldsPermissionEntity getByUser(int userid)
        {
            ChequeFieldsPermissionEntity entity = new ChequeFieldsPermissionEntity();
            string cond = ChequeFieldsPermissionEntity.FIELD_USERID + "=" + provider.getSQLString(userid);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public ChequeFieldsPermissionEntity getByTableindex(int tableindex)
        {
            ChequeFieldsPermissionEntity entity = new ChequeFieldsPermissionEntity();
            string cond = ChequeFieldsPermissionEntity.FIELD_ID + "=" + provider.getSQLString(tableindex);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public int addPermission(ChequeFieldsPermissionEntity entity)
        {
            return provider.add(entity);
        }

        public int update(ChequeFieldsPermissionEntity entity)
        {
            return provider.update(entity);
        }

        public int deleteByUser(int userid)
        {
            AbstractCommonData entity = new ChequeFieldsPermissionEntity();
            string delQuery = "DELETE FROM " + entity.TableName + " WHERE " + ChequeFieldsPermissionEntity.FIELD_USERID + "=" + provider.getSQLString(userid);
            return provider.delete(delQuery);
        }
    }
}
