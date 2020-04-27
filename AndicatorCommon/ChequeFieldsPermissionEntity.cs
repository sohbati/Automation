using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;
using System.Data;

namespace AndicatorCommon
{
    public class ChequeFieldsPermissionEntity : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_USERID = "USERID";
        public const string FIELD_CHEQUENUMBER = "CHEQUENUMBER";
        public const string FIELD_MATURITYDATE = "MATURITYDATE";
        public const string FIELD_ENTRYDATE = "ENTRYDATE";
        public const string FIELD_PRICE = "PRICE";
        public const string FIELD_ACCOUNTNUMBER = "ACCOUNTNUMBER";
        public const string FIELD_ACCOUNTHOLDERNAME = "ACCOUNTHOLDERNAME";
        public const string FIELD_DESCRIPTION = "DESCRIPTION";
        public const string FIELD_REGISTERDATE = "REGISTERDATE";
        public const string FIELD_REGISTRANTUSER = "REGISTRANTUSER";
        public const string FIELD_PAYTYPE = "PAYTYPE";
        public const string FIELD_INSURANCENUMBER = "INSURANCENUMBER";
        public const string FIELD_INSURANCECOMPANY = "INSURANCECOMPANY";
        public const string FIELD_ARCHIVE = "ARCHIVE";
        public const string FIELD_BANKID = "BANKID";
        public const string FIELD_COMPANYID = "COMPANYID";
        public const string FIELD_REFFERFROM = "REFFERFROM";
        public const string FIELD_REFFERDATE = "REFFERDATE";
        public const string FIELD_CHEQUEITEMS = "CHEQUEITEMS";
        

        public const string indexField = FIELD_ID;

        public ChequeFieldsPermissionEntity()
        {
            TableName = "CHEQUEFIELDSPERM";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }


        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);

            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(FIELD_ID, typeof(System.Int64));

            myColumns.Add(FIELD_CHEQUENUMBER, typeof(System.Boolean));
            myColumns.Add(FIELD_MATURITYDATE, typeof(System.Boolean));
            myColumns.Add(FIELD_ENTRYDATE, typeof(System.Boolean));
            myColumns.Add(FIELD_PRICE, typeof(System.Boolean));
            myColumns.Add(FIELD_ACCOUNTNUMBER, typeof(System.Boolean));
            myColumns.Add(FIELD_ACCOUNTHOLDERNAME, typeof(System.Boolean));
            myColumns.Add(FIELD_PAYTYPE, typeof(System.Boolean));
            myColumns.Add(FIELD_INSURANCENUMBER, typeof(System.Boolean));
            myColumns.Add(FIELD_ARCHIVE, typeof(System.Boolean));
            myColumns.Add(FIELD_INSURANCECOMPANY, typeof(System.Boolean));
            myColumns.Add(FIELD_CHEQUEITEMS, typeof(System.Boolean));
            myColumns.Add(FIELD_BANKID, typeof(System.Boolean));
            myColumns.Add(FIELD_COMPANYID, typeof(System.Boolean));
            myColumns.Add(FIELD_REFFERDATE, typeof(System.Boolean));
            myColumns.Add(FIELD_REFFERFROM, typeof(System.Boolean));


           
            myColumns.Add(FIELD_USERID, typeof(System.Int32));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }

    }
}
