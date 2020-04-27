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
    public class ReferLetterBL : RMX_TOOLS.BLL.AbstractBL
    {
        public ReferLetterBL()
        {
            _abstractDA = new ReferLetterDA(); 
        }

        public ReferLetterEntity get(int letterid)
        {
            return ((ReferLetterDA)_abstractDA).get(letterid);
        }

        public ReferLetterEntity getByUserId(int userid)
        {
            return ((ReferLetterDA)_abstractDA).getByUserId(userid);
        }

        public ReferLetterEntity getLastRefered(int letterId)
        {
            return ((ReferLetterDA)_abstractDA).getLastRefered(letterId);
        }

        public ReferLetterEntity getByUserFromId(int userid, DateTime fromDate, DateTime toDate)
        {
            return ((ReferLetterDA)_abstractDA).getByUserFromId(userid, fromDate, toDate);
        }

        public ReferLetterEntity getByUserToId(int userid, DateTime fromDate, DateTime toDate)
        {
            return ((ReferLetterDA)_abstractDA).getByUserToId(userid, fromDate, toDate);
        }

        public int getReferCount(int letterid)
        {
            return ((ReferLetterDA)_abstractDA).getReferCount(letterid);
        }
        public int add(ReferLetterEntity entity)
        {
            return ((ReferLetterDA)_abstractDA).add(entity);
        }

        public int update(ReferLetterEntity entity)
        {
            return ((ReferLetterDA)_abstractDA).update(entity);
        }

        public int delete(int id)
        {
            return ((ReferLetterDA)_abstractDA).delete(id);
        }

        public int removeUserRefer(int userid)
        {
            return ((ReferLetterDA)_abstractDA).removeUserRefer(userid);
        }

        public ReferCountLetterEntity getReferCount(int count, DateTime fromDate, DateTime toDate)
        {
            return ((ReferLetterDA)_abstractDA).getReferCount(count, fromDate, toDate);
        }
    }
}
