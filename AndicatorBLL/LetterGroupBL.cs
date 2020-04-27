using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;

namespace AndicatorBLL
{
    public class LetterGroupBL : RMX_TOOLS.BLL.AbstractBL
    {
        public LetterGroupBL()
        {
            _abstractDA = new LetterGroupDA(); 
        }

        public LetterGroupEntity get()
        {
            return ((LetterGroupDA)_abstractDA).get();
        }
        
        public LetterGroupEntity get(int id)
        {
            return ((LetterGroupDA)_abstractDA).getById(id);
        }

        public LetterGroupEntity get(string cond)
        {
            LetterGroupEntity entity = new LetterGroupEntity();
            return ((LetterGroupDA)_abstractDA).get(entity, cond);
        }

        public int add(LetterGroupEntity entity)
        {
            return ((LetterGroupDA)_abstractDA).add(entity);
        }

        public int update(LetterGroupEntity entity)
        {
            return ((LetterGroupDA)_abstractDA).update(entity);
        }
        
        public int updateLetterNumbers(int groupId, string letterNumbers)
        {
            return ((LetterGroupDA)_abstractDA).updateLetterNumbers(groupId, letterNumbers);
        }

        public int delete(int id)
        {
            return ((LetterGroupDA)_abstractDA).delete(id);
        }

        public void updateTitle(int groupId, string s)
        {
             ((LetterGroupDA)_abstractDA).updateTitle(groupId, s);
        }
    }
}
