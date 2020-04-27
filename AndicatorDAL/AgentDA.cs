using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class AgentDA : AbstractDAL
    {
        public AgentEntity get()
        {
            AgentEntity entity = new AgentEntity();
            string cond = "ID > 0";
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public AgentEntity get(int id)
        {
            AgentEntity entity = new AgentEntity();
            string cond = AgentEntity.FIELD_ID + "=" + provider.getSQLString(id);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public string getAgentName(int id)
        {
            AgentEntity entity = new AgentEntity();
            string cond = AgentEntity.FIELD_ID + "=" + provider.getSQLString(id);
            provider.loadToDataSet(entity, cond);
            return entity.get(AgentEntity.FIELD_Agent_NAME).ToString();
        }

        public AgentEntity getOnlyActives(string cond)
        {
            AgentEntity entity = new AgentEntity();
            if (cond.Length > 0)
                cond += " AND ";
            cond += "(" +AgentEntity.FIELD_ACTIVE + "=1 OR " + AgentEntity.FIELD_ACTIVE + " IS NULL)";
            cond += " AND ID > 0";
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public AgentEntity get(string cond)
        {
            AgentEntity entity = new AgentEntity();
            if (cond.Length > 0)
                cond += " AND ";
            cond += "ID > 0";
            provider.loadToDataSet(entity, cond);
            return entity;
        }


        public int add(AgentEntity entity)
        {
            return provider.add(entity);
        }

        public int update(AgentEntity entity)
        {
            return provider.update(entity);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new AgentEntity();
            string delQuery = "DELETE FROM " + entity.TableName + " where " + entity.IndexFieldName + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }

    }
}
