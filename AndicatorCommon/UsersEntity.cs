using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RMX_TOOLS.common;
namespace AndicatorCommon
{
    public class UsersEntity : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_NAME = "NAME";
        public const string FIELD_FAMILY = "FAMILY";
        public const string FIELD_USERNAME = "USERNAME";
        public const string FIELD_ACTIVE = "ACTIVE";
        public const string FIELD_PASSWORD = "PASSWORD";
        public const string FIELD_USER_TYPE = "USERTYPE";
        public const string FIELD_LETTER_PATTERN_ID = "LETTERPATTERNID";
        
        public const string VIEW_FIELD_USERTYPE_DESC = "USERTYPE_DESC";
        public const string VIEW_FIELD_S_FULLNAME= "S_FULLNAME";
        
        public UsersEntity()
        {
            TableName = "USERS";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);
            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(FIELD_ID, typeof(System.Int64));
            myColumns.Add(FIELD_NAME, typeof(System.String));
            myColumns.Add(FIELD_FAMILY, typeof(System.String));
            myColumns.Add(FIELD_USERNAME, typeof(System.String));
            myColumns.Add(FIELD_PASSWORD, typeof(System.String));
            myColumns.Add(FIELD_USER_TYPE, typeof(System.Int64));
            myColumns.Add(FIELD_ACTIVE, typeof(System.Int16));

            myColumns.Add(FIELD_LETTER_PATTERN_ID, typeof(System.Int64));
            
            myColumns.Add(FIELD_RADIF, typeof(System.Int32));


            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            viewDataTable.Columns.Add(VIEW_FIELD_USERTYPE_DESC, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_S_FULLNAME, typeof(System.String));

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }

        public override string ToString()
        {
            return get(FIELD_NAME) + " " + get(FIELD_FAMILY) + " (" + get(FIELD_USERNAME) + ")";
        }

        public string ToString(int index)
        {
            return get(index, FIELD_NAME) + " " + get(index, FIELD_FAMILY) + " (" + get(index, FIELD_USERNAME) + ")";
        }
    }
}
