using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RMX_TOOLS.common;
namespace AndicatorCommon
{
    public class WorkingStatisticEntity : AbstractCommonData
    {
        public const string VIEW_FIELD_ID = "ID";
        public const string VIEW_FIELD_USER_ID = "USERID";
        public const string VIEW_FIELD_USERNAME = "USERNAME";
        public const string VIEW_FIELD_CUR_LETTER_ALL = "CUR_LETTER_ALL";
        public const string VIEW_FIELD_CUR_LETTER_MARKED = "CUR_LETTER_MARKED";
        public const string VIEW_FIELD_RATE_DEC_ALL = "RATE_DEC_ALL";
        public const string VIEW_FIELD_RATE_DEC_MARKED = "RATE_DEC_MARKED";
        public const string VIEW_FIELD_RATE_DEC_ORAL_ALL = "RATE_DEC_ORAL_ALL";
        public const string VIEW_FIELD_RATE_DEC_ORAL_MARKED = "RATE_DEC_ORAL_MARKED";
        public const string VIEW_FIELD_CHEQUE_HAS_REMAINDER = "CHEQUE_HAS_REMAINDER";
        public const string VIEW_FIELD_CHEQUE_WHITHOUT_ANS = "CHEQUE_WHITHOUT_ANS";

        public WorkingStatisticEntity()
        {
            TableName = "WORKINGSTATISTIC";
            IndexFieldName = VIEW_FIELD_ID;

            BuildDataTables();
           // generateCommands();
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);
            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(VIEW_FIELD_ID, typeof(System.Int64));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));


            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            viewDataTable.Columns.Add(VIEW_FIELD_USER_ID, typeof(System.Int32));
            viewDataTable.Columns.Add(VIEW_FIELD_USERNAME, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_CUR_LETTER_ALL, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_CUR_LETTER_MARKED, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_RATE_DEC_ALL, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_RATE_DEC_MARKED, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_RATE_DEC_ORAL_ALL, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_RATE_DEC_ORAL_MARKED, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_CHEQUE_HAS_REMAINDER, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_CHEQUE_WHITHOUT_ANS, typeof(System.String));

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }

        public override string ToString()
        {
            return get(VIEW_FIELD_USERNAME) + "";
        }

        public string ToString(int index)
        {
            return get(index, VIEW_FIELD_USERNAME) + "";
        }
    }
}
