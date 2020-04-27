using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;
using System.Data;

namespace RMX_TOOLS.hasti.entity
{
    public class BasicInfoEntity : AbstractCommonData 
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_PARENT_ID= "PARENTID";
        public const string FIELD_DESCRIPTION = "DESCRIPTION";
        public const string FIELD_ACTIVE = "ACTIVE";
        public const string FIELD_ENGLISHNAME = "ENGLISHNAME";
        public const string FIELD_CONTAINUNKNOWN = "CONTAINUNKNOWN";
        public const string FIELD_USERCANCHANGE = "USERCANCHANGE";
        public const string FIELD_CUSTOMFIELD = "CUSTOMFIELD";

        public BasicInfoEntity()
        {
            TableName = "BASICINFO";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);

            DataColumnCollection myColumns = dataTable.Columns;
            
            myColumns.Add(FIELD_ID, typeof(System.Int32));
            myColumns.Add(FIELD_PARENT_ID, typeof(System.Int32));
            myColumns.Add(FIELD_DESCRIPTION, typeof(System.String));
            myColumns.Add(FIELD_ACTIVE, typeof(System.Boolean));
            myColumns.Add(FIELD_ENGLISHNAME, typeof(System.String));
            myColumns.Add(FIELD_USERCANCHANGE, typeof(System.Boolean));
            myColumns.Add(FIELD_CONTAINUNKNOWN, typeof(System.Boolean));
            myColumns.Add(FIELD_CUSTOMFIELD, typeof(System.String));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }

    }
}
