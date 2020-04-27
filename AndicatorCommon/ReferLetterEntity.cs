using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;
using System.Data;

namespace AndicatorCommon
{
    public class ReferLetterEntity : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_LETTER_ID = "LETTERID";
        public const string FIELD_REFER_DATE = "REFERDATE";
        public const string FIELD_REFER_FROM_USER = "REFERFROMUSER";
        public const string FIELD_REFER_TO_USER = "REFERTOUSER";

        public const string VIEW_FIELD_LETTERDATE = "LETTERDATE";
        public const string VIEW_FIELD_LETTERNUMBER = "LETTERNUMBER";
        public const string VIEW_FIELD_USERSFROM = "USERSFROM";
        public const string VIEW_FIELD_USERSTO = "USERSTO";

        public const string indexField = FIELD_ID;

        public ReferLetterEntity()
        {
            TableName = "REFERLETTER";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }


        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);

            DataColumnCollection myColumns = dataTable.Columns;
            
            myColumns.Add(FIELD_ID, typeof(System.Int64));
            myColumns.Add(FIELD_LETTER_ID, typeof(System.Int64));
            myColumns.Add(FIELD_REFER_DATE, typeof(System.DateTime));
            myColumns.Add(FIELD_REFER_FROM_USER, typeof(System.Int64));
            myColumns.Add(FIELD_REFER_TO_USER, typeof(System.Int64));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            viewDataTable.Columns.Add("LETTERDATE", typeof(System.String));
            viewDataTable.Columns.Add("LETTERNUMBER", typeof(System.String));
            viewDataTable.Columns.Add("USERSFROM", typeof(System.String));
            viewDataTable.Columns.Add("USERSTO", typeof(System.String));

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }
    }
    
    public class ReferCountLetterEntity : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_LETTER_ID = "LETTERID";
        public const string FIELD_REFER_COUNT= "COUNT";
        public const string FIEL_LETTERDATE = "LETTERDATE";
        public const string FIEL_LETTERSUBJECT = "LETTERSUBJECT";
        //public const string indexField = FIELD_ID;

        public ReferCountLetterEntity()
        {
            TableName = "VIEW_REFERLETTERCOUNT";
            IndexFieldName = FIELD_ID;
            VIEW_QUALIFIRE = "";
            BuildDataTables();
            generateCommands();
        }


        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);

            DataColumnCollection myColumns = dataTable.Columns;

            myColumns.Add(FIELD_ID, typeof(System.Int64));
            myColumns.Add(FIELD_LETTER_ID, typeof(System.Int64));
            myColumns.Add(FIEL_LETTERDATE, typeof(System.DateTime));
            myColumns.Add(FIEL_LETTERSUBJECT, typeof(System.String));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

             this.Tables.Add(dataTable);
        }
    }
}
