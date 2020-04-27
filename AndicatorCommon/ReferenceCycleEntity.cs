using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;
using System.Data;

namespace AndicatorCommon
{
    public class ReferenceCycleEntity : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_FIRSTREFERDATE = "FIRSTREFERDATE";
        public const string FIELD_FIRSTFROMUSER = "FIRSTFROMUSERID";
        public const string FIELD_FIRSTTOUSER = "FIRSTTOUSERID";
        public const string FIELD_SECONDREFERDATE = "SECONDREFERDATE";
        public const string FIELD_SECONDFROMUSER = "SECONDFROMUSERID";
        public const string FIELD_SECONDTOUSER = "SECONDTOUSERID";
        public const string FIELD_LETTERID = "LETTERID";
        public const string FIELD_ACTION = "ACTION";
        public const string FIELD_ACTIONDESCRIPTION = "ACTIONDESCRIPTION";
        public const string FIELD_ARCHIVE = "ARCHIVE";

        public ReferenceCycleEntity()
        {
            TableName = "REFERENCECYCLE";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);
            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(FIELD_ID, typeof(System.Int64));
            
            myColumns.Add(FIELD_FIRSTREFERDATE, typeof(System.DateTime));
            myColumns.Add(FIELD_FIRSTFROMUSER, typeof(System.Int64));
            myColumns.Add(FIELD_FIRSTTOUSER, typeof(System.Int64));
            
            myColumns.Add(FIELD_SECONDREFERDATE, typeof(System.DateTime));
            myColumns.Add(FIELD_SECONDFROMUSER, typeof(System.Int64));
            myColumns.Add(FIELD_SECONDTOUSER, typeof(System.Int64));
            
            myColumns.Add(FIELD_LETTERID, typeof(System.Int64));
            
            myColumns.Add(FIELD_ACTION, typeof(System.String));
            myColumns.Add(FIELD_ACTIONDESCRIPTION, typeof(System.String));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            myColumns.Add(FIELD_ARCHIVE, typeof(System.Boolean));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }
    }
}
