using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;
using System.Data;

namespace RMX_TOOLS.hasti.entity
{
    public class ApplicationPropertiesEntity: AbstractCommonData 
    {
        
        public const string FIELD_ID = "ID";
        public const string FIELD_PROPERTY = "PROPERTY";
        public const string FIELD_VALUE = "VALUE";

        public ApplicationPropertiesEntity()
        {
            TableName = "APPLICATIONPROPERTIES";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);

            DataColumnCollection myColumns = dataTable.Columns;
            
            myColumns.Add(FIELD_ID, typeof(System.Int32));
            myColumns.Add(FIELD_PROPERTY, typeof(System.String));
            myColumns.Add(FIELD_VALUE, typeof(System.String));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }
    }
}
