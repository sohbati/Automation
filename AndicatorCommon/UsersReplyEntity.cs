using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RMX_TOOLS.common;

namespace AndicatorCommon
{
    public class UsersReplyEntity : AbstractCommonData
    {

        public const string FIELD_ID = "ID";
        public const string FIELD_LETTERID = "LETTERID";
        public const string FIELD_USERID = "USERID";
        public const string FIELD_RESPONSEDATE = "RESPONSEDATE";
        public const string FIELD_DESCRIPTION = "DESCRIPTION";
        public const string FIELD_FINALIZED = "FINALIZED";

        public UsersReplyEntity()
        {
            TableName = "USERSREPLY";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);
            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(FIELD_ID, typeof(System.Int64));
            myColumns.Add(FIELD_LETTERID, typeof(System.Int64));
            myColumns.Add(FIELD_USERID, typeof(System.Int64));
            myColumns.Add(FIELD_RESPONSEDATE, typeof(System.DateTime));
            myColumns.Add(FIELD_DESCRIPTION, typeof(System.String));
            myColumns.Add(FIELD_FINALIZED, typeof(System.Boolean));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            viewDataTable.Columns.Add(FIELD_USERID + "_DESC", typeof(System.String));

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }

    }
}
