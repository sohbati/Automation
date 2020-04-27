using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RMX_TOOLS.common;

namespace AndicatorCommon
{
    public class AgentEntity : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_Agent_NAME = "AGENTNAME";
        public const string FIELD_AGENTCODE = "AGENTCODE";
        public const string FIELD_TELEPHONE = "TELEPHONE";
        public const string FIELD_MOBILE = "MOBILE";
        public const string FIELD_FAX = "FAX";
        public const string FIELD_ADDRESS = "ADDRESS";
        public const string FIELD_ACTIVE = "ACTIVE";

        public AgentEntity()
        {
            TableName = "AGENT";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);
            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(FIELD_ID, typeof(System.Int64));
            myColumns.Add(FIELD_Agent_NAME, typeof(System.String));
            myColumns.Add(FIELD_TELEPHONE, typeof(System.String));
            myColumns.Add(FIELD_AGENTCODE, typeof(System.String));
            myColumns.Add(FIELD_MOBILE, typeof(System.String));
            myColumns.Add(FIELD_ADDRESS, typeof(System.String));
            myColumns.Add(FIELD_FAX, typeof(System.String));
            myColumns.Add(FIELD_ACTIVE, typeof(System.Boolean));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }

    }
}
