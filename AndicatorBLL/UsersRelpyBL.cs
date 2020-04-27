using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;

namespace AndicatorBLL
{
    public class UsersRelpyBL: RMX_TOOLS.BLL.AbstractBL
    {
        public UsersRelpyBL()
        {
            _abstractDA = new UsersReplyDA();
        }
        
        public UsersReplyEntity get(int letterid) 
        {
            return ((UsersReplyDA)_abstractDA).get(letterid);
        }

        public UsersReplyEntity getById(int id)
        {
            return ((UsersReplyDA)_abstractDA).getById(id);
        }

        public UsersReplyEntity get(int letterid, int userid)
        {
            return ((UsersReplyDA)_abstractDA).get(letterid, userid);
        }

        public int finalizeReply(int letterid, int userid)
        {
            return ((UsersReplyDA)_abstractDA).finalizeReply(letterid, userid);
        }

        public int add(UsersReplyEntity entity)
        {
            return ((UsersReplyDA)_abstractDA).add(entity);
        }

        public int update(UsersReplyEntity entity)
        {
            return ((UsersReplyDA)_abstractDA).update(entity);
        }

        public int delete(int id)
        {
            return ((UsersReplyDA)_abstractDA).delete(id);
        }
    }
}
