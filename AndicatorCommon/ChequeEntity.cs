using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RMX_TOOLS.common;

namespace AndicatorCommon
{
    public class ChequeEntity : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_CHEQUE_NUMBER = "CHEQUENUMBER";
        public const string FIELD_MATURITY_DATE = "MATURITYDATE";
        public const string FIELD_ENTRY_DATE = "ENTRYDATE";
        public const string FIELD_PRICE = "PRICE";
        public const string FIELD_BANK_ID = "BANKID";
        public const string FIELD_ACCOUNT_NUMBER = "ACCOUNTNUMBER";
        public const string FIELD_INSURANCE_NUMBER = "INSURANCENUMBER";
        public const string FIELD_ACCOUNT_HOLDER_NAME  = "ACCOUNTHOLDERNAME";
        public const string FIELD_DESCRIPTION = "DESCRIPTION";
        public const string FIELD_REGISTER_DATE = "REGISTERDATE";
        public const string FIELD_REGISTRANT_USER = "REGISTRANTUSER";
        public const string FIELD_PAY_TYPE = "PAYTYPE";
        public const string FIELD_INSURANCE_COMPANY = "INSURANCECOMPANY";
        public const string FIELD_ARCHIVE = "ARCHIVE";
        public const string FIELD_COLOR = "COLOR";
        public const string FIELD_USER_TREE_ID = "USERTREEID";
        public const string FIELD_COMPANY_ID = "COMPANYID";
        public const string FIELD_FISHNO = "FISHNO";
        public const string FIELD_REFER_FROM_USER_ID = "REFFERFROM";
        public const string FIELD_REFFER_DATE = "REFFERDATE";


        public const string VIEW_FIELD_BI_BANK_DESCRIPTION = "BI_BANK_DESCRIPTION";
        public const string VIEW_FIELD_INSURANCECOMPANY_DESC = "INSURANCE_COMPANY_DESC";
        public const string VIEW_FIELD_PAYTYPE_DESC = "PAYTYPE_DESC";
        public const string VIEW_FIELD_COMPANYNAME = "COMPANYNAME";
        public const string VIEW_FIELD_REMAINED = "REMAINED";
        public const string VIEW_FIELD_USERNAME = "USERNAME";

        public const string VIEW_FIELD_REFERENCED_USER_ID = "REFERENCEUSERID";

        public ChequeEntity()
        {
            TableName = "CHEQUE";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);
            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(FIELD_ID, typeof(System.Int64));
            myColumns.Add(FIELD_CHEQUE_NUMBER, typeof(System.String));
            myColumns.Add(FIELD_MATURITY_DATE, typeof(System.DateTime));
            myColumns.Add(FIELD_ENTRY_DATE, typeof(System.DateTime));
            myColumns.Add(FIELD_PRICE, typeof(System.Int64));
            myColumns.Add(FIELD_BANK_ID, typeof(System.Int32));
            myColumns.Add(FIELD_ACCOUNT_NUMBER, typeof(System.String));
            myColumns.Add(FIELD_INSURANCE_NUMBER, typeof(System.String));
            myColumns.Add(FIELD_INSURANCE_COMPANY, typeof(System.Int32));
            myColumns.Add(FIELD_ACCOUNT_HOLDER_NAME, typeof(System.String));
            myColumns.Add(FIELD_DESCRIPTION, typeof(System.String));
            myColumns.Add(FIELD_REGISTRANT_USER, typeof(System.Int64));
            myColumns.Add(FIELD_REGISTER_DATE, typeof(System.DateTime));
            myColumns.Add(FIELD_PAY_TYPE, typeof(System.Boolean));
            myColumns.Add(FIELD_ARCHIVE, typeof(System.Boolean));
            myColumns.Add(FIELD_COLOR, typeof(System.String));
            myColumns.Add(FIELD_USER_TREE_ID, typeof(System.Int64));
            myColumns.Add(FIELD_COMPANY_ID, typeof(System.Int32));
            myColumns.Add(FIELD_FISHNO, typeof(System.Int32));
            myColumns.Add(FIELD_REFER_FROM_USER_ID, typeof(System.Int32));
            myColumns.Add(FIELD_REFFER_DATE, typeof(System.DateTime));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            viewDataTable.Columns.Add(VIEW_FIELD_BI_BANK_DESCRIPTION, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_INSURANCECOMPANY_DESC, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_PAYTYPE_DESC, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_REMAINED, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_REFERENCED_USER_ID, typeof(System.Int64));
            viewDataTable.Columns.Add(VIEW_FIELD_COMPANYNAME, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_USERNAME, typeof(System.String));
            viewDataTable.Columns.Add(FIELD_REFER_FROM_USER_ID + "DESC", typeof(System.String));
            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }

    }
}
