using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RMX_TOOLS.common;

namespace AndicatorCommon
{
    public class LetterStateEntity: AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_NUMBER = "NUMBER";
        public const string FIELD_DATE = "DATE";
        public const string FIELD_DESCRIPTION = "DESCRIPTIONS";
        public const string FIELD_LETTERID = "LETTERID";
        public const string FIELD_USERID = "USERID";
        public const string FIELD_COMPANYID = "COMPANYID";

        public LetterStateEntity()
        {
            TableName = "LETTERSTATE";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);
            DataColumnCollection myColumns = dataTable.Columns;

            myColumns.Add(FIELD_ID, typeof(System.Int64));
            myColumns.Add(FIELD_NUMBER, typeof(System.String));
            myColumns.Add(FIELD_DATE, typeof(System.DateTime));
            myColumns.Add(FIELD_DESCRIPTION, typeof(System.String));
            myColumns.Add(FIELD_LETTERID, typeof(System.Int64));
            myColumns.Add(FIELD_USERID, typeof(System.Int64));
            myColumns.Add(FIELD_COMPANYID, typeof(System.Int32));

            myColumns.Add(FIELD_RADIF, typeof(System.Int64));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }

    }
}
