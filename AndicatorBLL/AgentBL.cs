using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;

namespace AndicatorBLL
{
    public class AgentBL : RMX_TOOLS.BLL.AbstractBL
    {
        public AgentBL()
        {
            _abstractDA = new AgentDA();
        }

        public AgentEntity get()
        {
            return ((AgentDA)_abstractDA).get();
        }

        public AgentEntity get(int id)
        {
            return ((AgentDA)_abstractDA).get(id);
        }

        public AgentEntity getOnlyActives(string cond)
        {
            return ((AgentDA)_abstractDA).getOnlyActives(cond);
        }


        public AgentEntity get(string cond)
        {
            return ((AgentDA)_abstractDA).get(cond);
        }

        public int add(AgentEntity entity)
        {
            return ((AgentDA)_abstractDA).add(entity);
        }

        public int update(AgentEntity entity)
        {
            return ((AgentDA)_abstractDA).update(entity);
        }

        public int delete(int id)
        {
            return ((AgentDA)_abstractDA).delete(id);
        }

        public static string getAgentName(int id)
        {
            AgentDA cda = new AgentDA();
            return cda.getAgentName(id);
        }
    }
}
