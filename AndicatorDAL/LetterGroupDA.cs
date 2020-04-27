using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;
using System.Data.SqlClient;
using System.Data;

namespace AndicatorDAL
{
    public class LetterGroupDA : AbstractDAL
    {
        
        public LetterGroupEntity get(LetterGroupEntity entity, string cond) 
        {
            provider.loadToDataSet(entity, cond);
            return entity;
        }
         public LetterGroupEntity get() 
         {
            LetterGroupEntity entity = new LetterGroupEntity();
            provider.loadToDataSet(entity);
            return entity;
        }

        public LetterGroupEntity get(string ids)
        {
            LetterGroupEntity entity = new LetterGroupEntity();
            string cond = LetterGroupEntity.FIELD_ID+ " in (" + ids + ")";

            return get(entity, cond);
        }


        public LetterGroupEntity getById(int id)
        {
            LetterGroupEntity entity = new LetterGroupEntity();
            string cond = LetterGroupEntity.FIELD_ID+ "=" + provider.getSQLString(id);

            return get(entity, cond);
        }
       

        public int add(LetterGroupEntity letterGroupEntity)
        {
            return provider.add(letterGroupEntity);
        }

        public int update(LetterGroupEntity entity)
        {
            return provider.update(entity);
        }
       
        public int updateLetterNumbers(int groupId, string letterNumbers)
        {

            string sql = "update LETTERGROUP set LETTERNUMBERS= " + provider.getSQLString(letterNumbers) +
                " WHERE " + LetterGroupEntity.FIELD_ID + "=" + groupId;
            return provider.executeNonQuery(sql);
        }

        public void updateTitle(int groupId, string s)
        {
            string sql = "update LETTERGROUP set GROUPTITLE= " + provider.getSQLString(s) +
                " WHERE " + LetterGroupEntity.FIELD_ID + "=" + groupId;
            provider.executeNonQuery(sql);
        }

        public int delete(int id)
        {
            
            string delQuery = "DELETE FROM " + " LETTERGROUP " +  " WHERE " + LetterGroupEntity.indexField + "=" + provider.getSQLString(id);
            return provider.delete(delQuery);
        }

        

        public string getAllChainedsByLetterId(int letterid)
        {
            DataSet ds = ((SqlServerProvider)Config.provider).executeSelect("select dbo.fn_getAllChainedsById(" + letterid+ ")");
            return ds.Tables[0].Rows[0][0].ToString();
        }
    }
}
