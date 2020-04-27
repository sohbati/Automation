using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class AttachmentChequeDA : AbstractDAL
    {

        public AttachmentChequeEntity get(int letterid)
        {
            AttachmentChequeEntity entity = new AttachmentChequeEntity();
            String cond = AttachmentChequeEntity.FIELD_CHEQUE_ID + "=" + provider.getSQLString(letterid);
            provider.loadToDataSet(entity, cond);

            return entity;
        }

        public int getCount(int letterid)
        {
            //ToDo reprogram this lines
            AttachmentChequeEntity entity = new AttachmentChequeEntity();
            String sql = "SELECT COUNT(1) FROM " + entity.TableName + " WHERE " + AttachmentChequeEntity.FIELD_CHEQUE_ID 
                + "=" + provider.getSQLString(letterid);
            String cond = AttachmentChequeEntity.FIELD_CHEQUE_ID + "=" + provider.getSQLString(letterid);
            provider.loadToDataSet(entity, cond);
            return entity.Tables[entity.FilledTableName].Rows.Count;
        }

        public AttachmentChequeEntity getById(int id)
        {
            AttachmentChequeEntity entity = new AttachmentChequeEntity();
            String cond = AttachmentChequeEntity.FIELD_ID + "=" + provider.getSQLString(id);
            provider.loadToDataSet(entity, cond);

            return entity;
        }

        public int add(AttachmentChequeEntity entity)
        {
            return provider.add(entity);
        }

        public int update(AttachmentChequeEntity entity)
        {
            return provider.update(entity);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new AttachmentChequeEntity();
            string delQuery = "DELETE FROM " + entity.TableName + " WHERE " + AttachmentChequeEntity.indexField + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }

    }
}
