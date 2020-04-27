using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;

namespace AndicatorBLL
{
    public class LetterStateBL : RMX_TOOLS.BLL.AbstractBL
    {
        public LetterStateBL()
        {
            _abstractDA = new LetterStateDA(); 
        }
        
        public LetterStateEntity get(int letterid)
        {
            return ((LetterStateDA)_abstractDA).get(letterid);
        }

        public int add(LetterStateEntity entity)
        {
            return ((LetterStateDA)_abstractDA).add(entity);
        }

        public int update(LetterStateEntity entity)
        {
            return ((LetterStateDA)_abstractDA).update(entity);
        }

        public int delete(int id)
        {
            return ((LetterStateDA)_abstractDA).delete(id);
        }
    }
}
