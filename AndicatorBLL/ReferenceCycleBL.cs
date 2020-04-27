using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;

namespace AndicatorBLL
{
    public class ReferenceCycleBL : RMX_TOOLS.BLL.AbstractBL
    {
        public ReferenceCycleBL()
        {
            _abstractDA = new ReferenceCycleDA();
        }

        public ReferenceCycleEntity get()
        {
            return ((ReferenceCycleDA)_abstractDA).get();
        }

        public ReferenceCycleEntity get(int id)
        {
            return ((ReferenceCycleDA)_abstractDA).get(id);
        }

        public ReferenceCycleEntity get(string cond)
        {
            return ((ReferenceCycleDA)_abstractDA).get(cond);
        }

        public int add(ReferenceCycleEntity entity)
        {
            return ((ReferenceCycleDA)_abstractDA).add(entity);
        }

        public int update(ReferenceCycleEntity entity)
        {
            return ((ReferenceCycleDA)_abstractDA).update(entity);
        }

        public int delete(int id)
        {
            return ((ReferenceCycleDA)_abstractDA).delete(id);
        }

    }
}
