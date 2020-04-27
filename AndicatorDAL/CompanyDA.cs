using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;

namespace AndicatorDAL
{
    public class CompanyDA : AbstractDAL
    {
        public CompanyEntity get()
        {
            CompanyEntity entity = new CompanyEntity();
            string cond = "ID > 0";
            provider.loadToDataSet(entity, cond);
            return entity;
        }
        
        public CompanyEntity get(int id)
        {
            CompanyEntity entity = new CompanyEntity();
            string cond = CompanyEntity.FIELD_ID + "=" + provider.getSQLString(id);
            provider.loadToDataSet(entity, cond);
            return entity;
        }

        public string getCompanyName(int id)
        {
            CompanyEntity entity = new CompanyEntity();
            string cond = CompanyEntity.FIELD_ID + "=" + provider.getSQLString(id);
            provider.loadToDataSet(entity, cond);
            return entity.get(CompanyEntity.FIELD_COMPANY_NAME).ToString();
        }

        public CompanyEntity getOnlyActives(string cond)
        {
            CompanyEntity entity = new CompanyEntity();
            if (cond.Length > 0)
                cond += " AND ";
            cond += "("+ CompanyEntity.FIELD_ACTIVE + "=1 OR " + CompanyEntity.FIELD_ACTIVE + " IS NULL)";
            cond += " AND ID > 0";
            
            provider.loadToDataSet(entity, cond);
            return entity;
        }
        
        public CompanyEntity get(string cond)
        {
            CompanyEntity entity = new CompanyEntity();
            if (cond.Length > 0)
                cond += " AND ";
            cond += " ID > 0";
            provider.loadToDataSet(entity, cond);
            return entity;
        }


        public int add(CompanyEntity entity)
        {
            return provider.add(entity);
        }

        public int update(CompanyEntity entity)
        {
            return provider.update(entity);
        }

        public int delete(int id)
        {
            AbstractCommonData entity = new CompanyEntity();
            string delQuery = "DELETE FROM " + entity.TableName + " where " + entity.IndexFieldName + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }

    }
}
