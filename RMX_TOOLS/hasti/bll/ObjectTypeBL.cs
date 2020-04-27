using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.BLL;
using RMX_TOOLS.hasti.entity;
namespace RMX_TOOLS.hasti.bll
{
    public class ObjectTypeBL : AbstractBL
    {
        public ObjectTypeBL():base("ObjectType")
        {

        }

        public ObjectTypeEntity get(int objectTypeId) 
        {
            ObjectTypeEntity entity = new ObjectTypeEntity();
            load(entity);
            return entity;
        }

    }
}
