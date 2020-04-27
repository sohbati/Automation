using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RMX_TOOLS.common;

namespace AndicatorCommon
{
    public class UserTreeEntity : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_USER_ID = "USERID";
        public const string FIELD_PARENT_ID = "PARENTID";
        public const string FIELD_USER_PATH = "USERPATH";

        public const string VIEW_FIELD_USER_NAME = "USERS_NAME";
        //public const string VIEW_FIELD_USER_ACTIVE = "ACTIVE";
        public const string VIEW_FIELD_USER_USERTYPE = "USERTYPE";

        public UserTreeEntity()
        {
            TableName = "USERTREE";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);
            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(FIELD_ID, typeof(System.Int64));
            myColumns.Add(FIELD_USER_ID, typeof(System.Int64));
            myColumns.Add(FIELD_PARENT_ID, typeof(System.Int64));
            myColumns.Add(FIELD_USER_PATH, typeof(System.String));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            viewDataTable.Columns.Add(VIEW_FIELD_USER_NAME, typeof(System.String));
          //  viewDataTable.Columns.Add(VIEW_FIELD_USER_ACTIVE, typeof(System.Boolean));
            viewDataTable.Columns.Add(VIEW_FIELD_USER_USERTYPE, typeof(System.Int64));

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }

    }
}
