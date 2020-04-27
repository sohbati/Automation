using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;

namespace AndicatorBLL
{
    public class LetterReplyCountBL : RMX_TOOLS.BLL.AbstractBL
    {
        public LetterReplyCountBL()
        {
            _abstractDA = new LetterReplyCountDA();
        }

        public LetterReplyCountViewEntity get()
        {
            return ((LetterReplyCountDA)_abstractDA).get();
        }

        public LetterReplyCountViewEntity get(int id)
        {
            return ((LetterReplyCountDA)_abstractDA).get(id);
        }

        public LetterReplyCountViewEntity get(string cond)
        {
            return ((LetterReplyCountDA)_abstractDA).get(cond);
        }
    }
}
