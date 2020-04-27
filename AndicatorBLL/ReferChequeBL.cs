using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;

namespace AndicatorBLL
{
    public class ReferChequeBL : RMX_TOOLS.BLL.AbstractBL
    {
        public ReferChequeBL()
        {
            _abstractDA = new ReferChequeDA();
        }

        public ReferChequeEntity get(int chequeId)
        {
            return ((ReferChequeDA)_abstractDA).get(chequeId);
        }

        public int getReferCount(int chequeId)
        {
            return ((ReferChequeDA)_abstractDA).getReferCount(chequeId);
        }
        public int add(ReferChequeEntity entity)
        {
            return ((ReferChequeDA)_abstractDA).add(entity);
        }

        public int update(ReferChequeEntity entity)
        {
            return ((ReferChequeDA)_abstractDA).update(entity);
        }

        public int delete(int id)
        {
            return ((ReferChequeDA)_abstractDA).delete(id);
        }


        public ReferChequeEntity getByUserId(int userid)
        {
            return ((ReferChequeDA)_abstractDA).getByUserId(userid);
        }

        public int removeUserRefer(int userid)
        {
            return ((ReferChequeDA)_abstractDA).removeUserRefer(userid);
        }
    }
}
