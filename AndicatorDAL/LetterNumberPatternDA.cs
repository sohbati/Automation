using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class LetterNumberPatternDA : AbstractDAL
    {
        public LetterNumberPatternEntity get()
        {
            LetterNumberPatternEntity entity = new LetterNumberPatternEntity();
            provider.loadToDataSet(entity, "");
            return entity;
        }

        public LetterNumberPatternEntity getById(int id)
        {
            LetterNumberPatternEntity entity = new LetterNumberPatternEntity();
            string cond = LetterNumberPatternEntity.FIELD_ID + "=" + provider.getSQLString(id);

            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public LetterNumberPatternEntity getOralPattern()
        {
            LetterNumberPatternEntity entity = new LetterNumberPatternEntity();
            string cond = LetterNumberPatternEntity.FIELD_SYSTEMNAME + "=" + "'oral'";

            provider.loadToDataSet(entity, cond);
            return entity;
        }
        public int add(LetterNumberPatternEntity entity)
        {
            return provider.add(entity);
        }

        public int update(LetterNumberPatternEntity entity)
        {
            return provider.update(entity);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new LetterNumberPatternEntity();
            string delQuery = "delete from " + entity.TableName + " where " + LetterEntity.indexField + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }

    }
}
