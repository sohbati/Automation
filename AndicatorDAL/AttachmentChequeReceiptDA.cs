using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class AttachmentChequeReceiptDA : AbstractDAL
    {

        public AttachmentChequeReceiptEntity get(int letterid)
        {
            AttachmentChequeReceiptEntity entity = new AttachmentChequeReceiptEntity();
            String cond = AttachmentChequeReceiptEntity.FIELD_RECEIPT_ID + "=" + provider.getSQLString(letterid);
            provider.loadToDataSet(entity, cond);

            return entity;
        }

        public int getCount(int letterid)
        {
            //ToDo reprogram this lines
            AttachmentChequeReceiptEntity entity = new AttachmentChequeReceiptEntity();
            String sql = "SELECT COUNT(1) FROM " + entity.TableName + " WHERE " + AttachmentChequeReceiptEntity.FIELD_RECEIPT_ID 
                + "=" + provider.getSQLString(letterid);
            String cond = AttachmentChequeReceiptEntity.FIELD_RECEIPT_ID + "=" + provider.getSQLString(letterid);
            provider.loadToDataSet(entity, cond);
            return entity.Tables[entity.FilledTableName].Rows.Count;
        }

        public AttachmentChequeReceiptEntity getById(int id)
        {
            AttachmentChequeReceiptEntity entity = new AttachmentChequeReceiptEntity();
            String cond = AttachmentChequeReceiptEntity.FIELD_ID + "=" + provider.getSQLString(id);
            provider.loadToDataSet(entity, cond);

            return entity;
        }

        public int add(AttachmentChequeReceiptEntity entity)
        {
            return provider.add(entity);
        }

        public int update(AttachmentChequeReceiptEntity entity)
        {
            return provider.update(entity);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new AttachmentChequeReceiptEntity();
            string delQuery = "DELETE FROM " + entity.TableName + " WHERE " + AttachmentChequeReceiptEntity.indexField + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }

    }
}
