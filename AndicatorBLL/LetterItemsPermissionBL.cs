using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Data;
using RMX_TOOLS.hasti.bll;

namespace AndicatorBLL
{
    public class LetterItemsPermissionBL : RMX_TOOLS.BLL.AbstractBL
    {

        public LetterItemsPermissionBL()
        {
            _abstractDA = new LetterItemsPermissionDA();
        }

        public LetterItemsPermissionEntity getByUser(int userid)
        {
            return ((LetterItemsPermissionDA)_abstractDA).getByUser(userid);
        }

        public LetterItemsPermissionEntity getByTableindex(int tableindex)
        {
            return ((LetterItemsPermissionDA)_abstractDA).getByTableindex(tableindex);
        }
        
        public int addPermission(LetterItemsPermissionEntity entity)
        {
            return ((LetterItemsPermissionDA)_abstractDA).addPermission(entity);
        }

        public int update(LetterItemsPermissionEntity entity)
        {
            return ((LetterItemsPermissionDA)_abstractDA).update(entity);
        }

        internal int deleteByUser(int userid)
        {
            return ((LetterItemsPermissionDA)_abstractDA).deleteByUser(userid);
        }
    }
}
