using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Data;
using RMX_TOOLS.hasti.bll;

namespace AndicatorBLL
{
    public class AttachmentChequeBL : RMX_TOOLS.BLL.AbstractBL
    {
        public AttachmentChequeBL()
        {
            _abstractDA = new AttachmentChequeDA();
        }
        public AttachmentChequeEntity get(int chequeid)
        {
            return ((AttachmentChequeDA)_abstractDA).get(chequeid);
        }

        public int getCount(int chequeid)
        {
            return ((AttachmentChequeDA)_abstractDA).getCount(chequeid);
        }

        public AttachmentChequeEntity getById(int id)
        {
            return ((AttachmentChequeDA)_abstractDA).getById(id);
        }

        public int add(AttachmentChequeEntity entity)
        {
            return ((AttachmentChequeDA)_abstractDA).add(entity);
        }

        public int update(AttachmentChequeEntity entity)
        {
            return ((AttachmentChequeDA)_abstractDA).update(entity);
        }

        public int delete(int id)
        {
            return ((AttachmentChequeDA)_abstractDA).delete(id);
        }
    }
}
