using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Data;
using RMX_TOOLS.hasti.bll;

namespace AndicatorBLL
{
    public class ChequeFieldsPermissionBL : RMX_TOOLS.BLL.AbstractBL
    {

        public ChequeFieldsPermissionBL()
        {
            _abstractDA = new ChequeFieldsPermissionDA();
        }

        public ChequeFieldsPermissionEntity getByUser(int userid)
        {
            return ((ChequeFieldsPermissionDA)_abstractDA).getByUser(userid);
        }

        public ChequeFieldsPermissionEntity getByTableindex(int tableindex)
        {
            return ((ChequeFieldsPermissionDA)_abstractDA).getByTableindex(tableindex);
        }
        
        public int addPermission(ChequeFieldsPermissionEntity entity)
        {
            return ((ChequeFieldsPermissionDA)_abstractDA).addPermission(entity);
        }

        public int update(ChequeFieldsPermissionEntity entity)
        {
            return ((ChequeFieldsPermissionDA)_abstractDA).update(entity);
        }

        internal int deleteByUser(int userid)
        {
            return ((ChequeFieldsPermissionDA)_abstractDA).deleteByUser(userid);
        }
    }
}
