using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.BLL;
using RMX_TOOLS.hasti.entity;
using RMX_TOOLS.hasti.dal;

namespace RMX_TOOLS.hasti.bll
{
    public class BasicInfoBL : AbstractBL
    {
        BasicInfoDA _basicInfoDA;
        public BasicInfoBL(): base("BasicInfo")
        {
            _basicInfoDA = new BasicInfoDA();
        }

        public BasicInfoEntity get() 
        {
            BasicInfoEntity entity = new BasicInfoEntity();
           // string cond = "ACTIVE = 1";
            load(entity);
            return entity;
        }

        public BasicInfoEntity get(int id)
        {
            BasicInfoEntity entity = new BasicInfoEntity();
            string cond = BasicInfoEntity.FIELD_ID + "=" + RMX_TOOLS.data.Config.provider.getSQLString(id); 
            load(entity, cond);

            return entity;
        }

        public string getCustomData(int id)
        {
            BasicInfoEntity entity = new BasicInfoEntity();
            string cond = BasicInfoEntity.FIELD_ID + "=" + RMX_TOOLS.data.Config.provider.getSQLString(id);
            load(entity, cond);
            return entity.Tables[entity.FilledTableName].Rows[0][BasicInfoEntity.FIELD_CUSTOMFIELD].ToString();
        }

        public string getCustomData(string englishName)
        {
            BasicInfoEntity entity = new BasicInfoEntity();
            string cond = BasicInfoEntity.FIELD_ENGLISHNAME + "=" + RMX_TOOLS.data.Config.provider.getSQLString(englishName);
            load(entity, cond);
            return entity.Tables[entity.FilledTableName].Rows[0][BasicInfoEntity.FIELD_CUSTOMFIELD].ToString();
        }
        
        public int getId(string englishName)
        {
            BasicInfoEntity entity = new BasicInfoEntity();
            string cond = BasicInfoEntity.FIELD_ENGLISHNAME + "=" + RMX_TOOLS.data.Config.provider.getSQLString(englishName);
            load(entity, cond);
            return int.Parse(entity.Tables[entity.FilledTableName].Rows[0][BasicInfoEntity.FIELD_ID].ToString());
        }

        public BasicInfoEntity getRoots()
        {
            BasicInfoEntity entity = new BasicInfoEntity();
            string cond = BasicInfoEntity.FIELD_PARENT_ID + " is null AND ID > 0";
            load(entity, cond);
            return entity;
        }
        
        public BasicInfoEntity getByEnglishName(string englishName)
        {
            BasicInfoEntity entity = new BasicInfoEntity();
            string cond = BasicInfoEntity.FIELD_ENGLISHNAME + "=" + data.Config.provider.getSQLString(englishName);
            load(entity, cond);
            return entity;
        }

        public BasicInfoEntity getByParentId(int parentId)
        {
            return getByParentId(parentId, false);
        }
        public BasicInfoEntity getByParentId(int parentId, bool showInactives)
        {
            BasicInfoEntity entity = new BasicInfoEntity();
            string cond = BasicInfoEntity.FIELD_PARENT_ID + "=" + data.Config.provider.getSQLString(parentId);
            if (!showInactives)
                cond += " AND " + BasicInfoEntity.FIELD_ACTIVE + " = " + 1;
            load(entity, cond);
            return entity;
        }


        public int add(BasicInfoEntity entity)
        {
            return _basicInfoDA.add(entity);
        }

        public int update(BasicInfoEntity entity)
        {
            return _basicInfoDA.update(entity);
        }

        public int updateCustomData(int id, string customData)
        {
            return _basicInfoDA.updateCustomData(id, customData);
        }

        public int delete(int id)
        {
            return _basicInfoDA.delete(id);
        }

    }
}
