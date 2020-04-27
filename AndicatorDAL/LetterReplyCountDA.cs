using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class LetterReplyCountDA : AbstractDAL
    {
        public LetterReplyCountViewEntity get()
        {
            LetterReplyCountViewEntity entity = new LetterReplyCountViewEntity();
            string cond = "ID > 0";
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public LetterReplyCountViewEntity get(int id)
        {
            LetterReplyCountViewEntity entity = new LetterReplyCountViewEntity();
            string cond = LetterReplyCountViewEntity.FIELD_ID + "=" + provider.getSQLString(id);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public LetterReplyCountViewEntity get(string cond)
        {
            LetterReplyCountViewEntity entity = new LetterReplyCountViewEntity();
            if (cond.Length > 0)
                cond += " AND ";
            cond += "ID > 0";
            provider.loadToDataSet(entity, cond,"", entity.FilledTableName);
            return entity;
        }
    }
}
