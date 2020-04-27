using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RMX_TOOLS.common;

namespace AndicatorCommon
{
    public class CompanyEntity : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_COMPANY_NAME = "COMPANYNAME";
        public const string FIELD_TEL = "TEL";
        public const string FIELD_SEMAT = "SEMAT";
        public const string FIELD_OFFICER = "OFFICER";
        public const string FIELD_ADDRESS = "ADDRESS";
        public const string FIELD_FAX = "FAX";
        public const string FIELD_DESCRIPTION = "DESCRIPTION";
        public const string FIELD_ACTIVE = "ACTIVE";

        public const string VIEW_FIELD_REFFERED_USER_NAME = "REFFEREDUSERNAME";
        
        public const string VIEW_FIELD_SEMAT = FIELD_SEMAT+ "_DESC";

        public CompanyEntity()
        {
            TableName = "COMPANY";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }

        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);
            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(FIELD_ID, typeof(System.Int64));
            myColumns.Add(FIELD_COMPANY_NAME, typeof(System.String));
            myColumns.Add(FIELD_TEL, typeof(System.String));
            myColumns.Add(FIELD_SEMAT, typeof(System.Int32));
            myColumns.Add(FIELD_OFFICER, typeof(System.String));
            myColumns.Add(FIELD_ADDRESS, typeof(System.String));
            myColumns.Add(FIELD_FAX, typeof(System.String));
            myColumns.Add(FIELD_ACTIVE, typeof(System.Boolean));
            myColumns.Add(FIELD_DESCRIPTION, typeof(System.String));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            viewDataTable.Columns.Add(VIEW_FIELD_REFFERED_USER_NAME, typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_SEMAT, typeof(System.String));

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }

    }
}
