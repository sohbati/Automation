using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;

namespace AndicatorBLL
{
    public class ChequeReplyBL : RMX_TOOLS.BLL.AbstractBL
    {
        public ChequeReplyBL()
        {
            _abstractDA = new ChequeReplyDA();
        }

        public ChequeReplyEntity get()
        {
            return ((ChequeReplyDA)_abstractDA).get();
        }

        public ChequeReplyEntity get(int id)
        {
            return ((ChequeReplyDA)_abstractDA).get(id);
        }

        public ChequeReplyEntity getByCheque(int chequeid, string cond)
        {
            return ((ChequeReplyDA)_abstractDA).getByCheque(chequeid, cond);
        }

        public ChequeReplyEntity get(string cond)
        {
            return ((ChequeReplyDA)_abstractDA).get(cond);
        }

        public int add(ChequeReplyEntity entity)
        {
            return ((ChequeReplyDA)_abstractDA).add(entity);
        }

        public int update(ChequeReplyEntity entity)
        {
            return ((ChequeReplyDA)_abstractDA).update(entity);
        }

        public int delete(int id)
        {
            return ((ChequeReplyDA)_abstractDA).delete(id);
        }

    }
}
