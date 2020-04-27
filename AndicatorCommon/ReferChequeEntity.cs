using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;
using System.Data;

namespace AndicatorCommon
{
    public class ReferChequeEntity : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_CHEQUE_ID = "CHEQUEID";
        public const string FIELD_REFER_DATE = "REFERDATE";
        public const string FIELD_REFER_FROM_USER = "REFERFROMUSER";
        public const string FIELD_REFER_TO_USER = "REFERTOUSER";

        public const string VIEW_FIELD_MATURITYDATE = "MATURITYDATE";
        public const string VIEW_FIELD_CHEQUENUMBER = "CHEQUENUMBER";
        public const string VIEW_FIELD_PAYTYPE = "PAYTYPE";

        public const string VIEW_FIELD_USERSFROM = "USERSFROM";
        public const string VIEW_FIELD_USERSTO = "USERSTO";

        public const string indexField = FIELD_ID;

        public ReferChequeEntity()
        {
            TableName = "REFERCHEQUE";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }


        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);

            DataColumnCollection myColumns = dataTable.Columns;

            myColumns.Add(FIELD_ID, typeof(System.Int64));
            myColumns.Add(FIELD_CHEQUE_ID, typeof(System.Int64));
            myColumns.Add(FIELD_REFER_DATE, typeof(System.DateTime));
            myColumns.Add(FIELD_REFER_FROM_USER, typeof(System.Int64));
            myColumns.Add(FIELD_REFER_TO_USER, typeof(System.Int64));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            viewDataTable.Columns.Add(VIEW_FIELD_MATURITYDATE, typeof(System.DateTime));
            viewDataTable.Columns.Add(VIEW_FIELD_CHEQUENUMBER, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_PAYTYPE, typeof(System.String));

            viewDataTable.Columns.Add(VIEW_FIELD_USERSFROM, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_USERSTO, typeof(System.String));

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }
    }
}
