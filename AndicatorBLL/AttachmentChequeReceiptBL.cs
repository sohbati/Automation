using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Data;
using RMX_TOOLS.hasti.bll;

namespace AndicatorBLL
{
    public class AttachmentChequeReceiptBL : RMX_TOOLS.BLL.AbstractBL
    {
        public AttachmentChequeReceiptBL()
        {
            _abstractDA = new AttachmentChequeReceiptDA();
        }
        public AttachmentChequeReceiptEntity get(int receiptId)
        {
            return ((AttachmentChequeReceiptDA)_abstractDA).get(receiptId);
        }

        public int getCount(int receiptId)
        {
            return ((AttachmentChequeReceiptDA)_abstractDA).getCount(receiptId);
        }

        public AttachmentChequeReceiptEntity getById(int id)
        {
            return ((AttachmentChequeReceiptDA)_abstractDA).getById(id);
        }

        public int add(AttachmentChequeReceiptEntity entity)
        {
            return ((AttachmentChequeReceiptDA)_abstractDA).add(entity);
        }

        public int update(AttachmentChequeReceiptEntity entity)
        {
            return ((AttachmentChequeReceiptDA)_abstractDA).update(entity);
        }

        public int delete(int id)
        {
            return ((AttachmentChequeReceiptDA)_abstractDA).delete(id);
        }
    }
}
