using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class AttachmentDA : AbstractDAL
    {

        public AttachmentEntity get(int letterid)
        {
            AttachmentEntity entity = new AttachmentEntity();
            String cond = AttachmentEntity.FIELD_LETTER_ID + "=" + provider.getSQLString(letterid);
            provider.loadToDataSet(entity, cond);

            return entity;
        }

        public int getCount(int letterid)
        {
            //ToDo reprogram this lines
            AttachmentEntity entity = new AttachmentEntity();
            String sql = "SELECT COUNT(1) FROM " + entity.TableName + " WHERE " + AttachmentEntity.FIELD_LETTER_ID 
                + "=" + provider.getSQLString(letterid);
            String cond = AttachmentEntity.FIELD_LETTER_ID + "=" + provider.getSQLString(letterid);
            provider.loadToDataSet(entity, cond);
            return entity.Tables[entity.FilledTableName].Rows.Count;
        }

        public AttachmentEntity getById(int id)
        {
            AttachmentEntity entity = new AttachmentEntity();
            String cond = AttachmentEntity.FIELD_ID + "=" + provider.getSQLString(id);
            provider.loadToDataSet(entity, cond);

            return entity;
        }

        public int add(AttachmentEntity entity)
        {
            return provider.add(entity);
        }

        public int update(AttachmentEntity entity)
        {
            return provider.update(entity);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new AttachmentEntity();
            string delQuery = "DELETE FROM " + entity.TableName + " WHERE " + AttachmentEntity.indexField + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }

    }
}
