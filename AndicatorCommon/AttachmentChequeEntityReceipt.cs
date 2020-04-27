using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;
using System.Data;

namespace AndicatorCommon
{
    public class AttachmentChequeReceiptEntity : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_RECEIPT_ID = "RECEIPTID";
        public const string FIELD_CONTENT = "CONTENT";
        public const string FIELD_FILE_NAME = "FILENAME";
        
        public const string indexField = FIELD_ID;

        public AttachmentChequeReceiptEntity()
        {
            TableName = "ATTACHMENTCHEQUERECEIPT";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();

        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);

            DataColumnCollection myColumns = dataTable.Columns;

            myColumns.Add(FIELD_ID, typeof(System.Int32));
            myColumns.Add(FIELD_RECEIPT_ID, typeof(System.Int32));
            myColumns.Add(FIELD_CONTENT, typeof(System.Byte[]));
            myColumns.Add(FIELD_FILE_NAME, typeof(System.String));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }

    }
}
