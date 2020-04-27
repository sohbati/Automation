using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class LetterStateDA : AbstractDAL
    {
        public LetterStateEntity get(int letterId)
        {
            LetterStateEntity entity = new LetterStateEntity();
            string cond = LetterStateEntity.FIELD_LETTERID + "=" + provider.getSQLString(letterId);
            provider.loadToDataSet(entity, cond);

            return entity;
        }

        public int add(LetterStateEntity entity)
        {
            return provider.add(entity);
        }

        public int update(LetterStateEntity entity)
        {
            return provider.update(entity);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new LetterStateEntity();
            string delQuery = "DELETE FROM " + entity.TableName + " where " + entity.IndexFieldName + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }


    }
}
