using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;
using System.Data;
namespace RMX_TOOLS.hasti.entity
{
    public class ObjectTypeEntity : AbstractCommonData 
    {
        public const string TABLE = "OBJECTTYPE";

        public const string FIELD_OBJECT_TYPE_ID = "OBJECTTYPEID";
        public const string FIELD_OBJECT_TYPE_NAME = "OBJECTTYPENAME";
        public const string FIELD_OBJECT_TYPE_ALIAS = "OBJECTTYPEALIAS";
        public const string FIELD_OBJECT_TYPE_FORM = "OBJECTTYPEFORM";
        public const string FIELD_COLUMN_LIST = "COLUMNLIST";
        
        public const string indexField = FIELD_OBJECT_TYPE_ID;

        public ObjectTypeEntity ()
        {
            BuildDataTables();
            generateCommands();
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TABLE);
            DataColumnCollection myColumns = dataTable.Columns;
            
            myColumns.Add(FIELD_OBJECT_TYPE_ID, typeof(System.Int64));
            myColumns.Add(FIELD_OBJECT_TYPE_NAME, typeof(System.String));
            myColumns.Add(FIELD_OBJECT_TYPE_ALIAS, typeof(System.String));
            myColumns.Add(FIELD_OBJECT_TYPE_FORM, typeof(System.String));
            myColumns.Add(FIELD_COLUMN_LIST, typeof(System.String));
            
            myColumns.Add(FIELD_RADIF, typeof(System.Int32));
            
            this.Tables.Add(dataTable);

        }

    }
}
