using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Data;
using RMX_TOOLS.hasti.bll;

namespace AndicatorBLL
{
    public class AttachmentBL : RMX_TOOLS.BLL.AbstractBL
    {
        public AttachmentBL()
        {
            _abstractDA = new AttachmentDA();
        }
        public AttachmentEntity get(int letterid)
        {
            return ((AttachmentDA)_abstractDA).get(letterid);
        }

        public int getCount(int letterid)
        {
            return ((AttachmentDA)_abstractDA).getCount(letterid);
        }

        public AttachmentEntity getById(int id)
        {
            return ((AttachmentDA)_abstractDA).getById(id);
        }

        public int add(AttachmentEntity entity)
        {
            return ((AttachmentDA)_abstractDA).add(entity);
        }

        public int update(AttachmentEntity entity)
        {
            return ((AttachmentDA)_abstractDA).update(entity);
        }

        public int delete(int id)
        {
            return ((AttachmentDA)_abstractDA).delete(id);
        }
    }
}
