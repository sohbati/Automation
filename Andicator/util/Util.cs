using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndicatorCommon;
using AndicatorBLL;

namespace Andicator.util
{
    public class Util
    {
        public static LetterBL _letterBL= new LetterBL();

        public static LetterEntity filterChainedLetters(LetterEntity entityList)
        {
            string ids = ""; //جلوگیری از تکراری بودن نامه

            LetterEntity entity = new LetterEntity();
            entity.FilledTableName = entityList.FilledTableName;

            string tableName = entityList.FilledTableName;

            for (int i = 0; i < entityList.Tables[entityList.FilledTableName].Rows.Count; i++)
            {
                object next = entityList.get(i, LetterEntity.FIELD_NEXTLETTERID);
                if (next != null && next.ToString().Length > 0 && ((int)next) > 0)
                {
                    if (ids.IndexOf(next.ToString() + ",") < 0)
                    {
                        LetterEntity last = getLastLetter((int)next);
                        RMX_TOOLS.util.EntityUtil.joinEntities(entity, last, tableName, last.FilledTableName);
                        ids += next.ToString() + ",";
                    }
                }
                else
                {
                    string id = entityList.get(i, LetterEntity.FIELD_ID).ToString();
                    if (ids.IndexOf(id + ",") < 0)
                    {
                        RMX_TOOLS.util.EntityUtil.joinRow(entity, entityList, tableName, entityList.FilledTableName, i);
                        ids += id + ",";
                    }
                }
            }

            return entity;
        }

        private static LetterEntity getLastLetter(int letterid)
        {
            return _letterBL.getByLetterId(letterid);
        }

    }
}
