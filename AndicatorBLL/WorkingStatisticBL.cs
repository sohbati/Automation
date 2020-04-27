using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;

namespace AndicatorBLL
{
    public class WorkingStatisticBL : RMX_TOOLS.BLL.AbstractBL
    {
        public WorkingStatisticBL()
        {
            _abstractDA = new WorkingStatisticDA();
        }

        public WorkingStatisticEntity get()
        {
            return ((WorkingStatisticDA)_abstractDA).get();
        }
    }
}
