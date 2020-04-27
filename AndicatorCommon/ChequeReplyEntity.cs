using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RMX_TOOLS.common;

namespace AndicatorCommon
{
    public class ChequeReplyEntity : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_CHEQUEID = "CHEQUEID";
        public const string FIELD_RECIEPTBILLNUMBER = "RECIEPTBILLNUMBER";
        public const string FIELD_ISSUEDATE = "ISSUEDATE";
        public const string FIELD_PRICE = "PRICE";
        public const string FIELD_DESCRIPTION = "DESCRIPTION";
        public const string FIELD_REGISTER_DATE = "REGISTERDATE";
        public const string FIELD_REGISTRANT_USER = "REGISTRANTUSER";

        public ChequeReplyEntity()
        {
            TableName = "CHEQUEREPLY";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);
            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(FIELD_ID, typeof(System.Int64));
            myColumns.Add(FIELD_CHEQUEID, typeof(System.String));
            myColumns.Add(FIELD_RECIEPTBILLNUMBER, typeof(System.String));
            myColumns.Add(FIELD_ISSUEDATE, typeof(System.DateTime));
            myColumns.Add(FIELD_PRICE, typeof(System.Int64));
            myColumns.Add(FIELD_DESCRIPTION, typeof(System.String));
            myColumns.Add(FIELD_REGISTRANT_USER, typeof(System.Int64));
            myColumns.Add(FIELD_REGISTER_DATE, typeof(System.DateTime));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }

    }
}
