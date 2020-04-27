using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using RMX_TOOLS.hasti.dal;
using RMX_TOOLS.hasti.entity;
using RMX_TOOLS.hasti.tools;

namespace RMX_TOOLS.BLL
{
    public class AbstractBL
    {
        #region variables
        private AbstractCommonData _entity;
        protected AbstractDAL _abstractDA;

        #endregion

        public AbstractBL()
        {

        }

        public AbstractBL(int objectTypeId)
        {
            buildDA(objectTypeId);
            
        }

        public AbstractBL(string objectTypeName)
        {
            buildDA(objectTypeName);
        }

        private void buildDA(String objectTypeName)
        {
            _abstractDA = (AbstractDAL)ClassFactory.createDAL(objectTypeName);
        }

        private void buildDA(int objectTypeId) 
        {
            ObjectTypeDA objectTypeDA = new ObjectTypeDA();
            ObjectTypeEntity entity = objectTypeDA.get(objectTypeId);
            
            string name = entity.Tables[entity.FilledTableName].Rows[0][ObjectTypeEntity.FIELD_OBJECT_TYPE_NAME].ToString();
            _abstractDA = (AbstractDAL)ClassFactory.createDAL(name);
        }

        public void load(AbstractCommonData entity)
        {
            _abstractDA.load(entity);
        }

        public void load(AbstractCommonData entity, string cond)
        {
            _abstractDA.load(entity, cond);
        }
    }
}
