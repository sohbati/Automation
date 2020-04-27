using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.hasti.entity;

namespace RMX_TOOLS.hasti.dal
{
    public class ObjectTypeDA : AbstractDAL
    {
        IDataProvider dp = Config.provider;

        public ObjectTypeEntity get(int objectTypeId)
        {
            ObjectTypeEntity entity = new ObjectTypeEntity();
            string cond = ObjectTypeEntity.FIELD_OBJECT_TYPE_ID + "=" + dp.getSQLString(objectTypeId);
            dp.loadToDataSet(entity, "");
            return entity;
        }

        public int add(ObjectTypeEntity ObjectTypeEntity)
        {
            return dp.add(ObjectTypeEntity);
        }
     }
}
