using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;
using System.Data;

namespace AndicatorCommon
{
    public class LetterNumberPatternEntity : AbstractCommonData
    {
        public const string FIELD_ID = "ID";
        public const string FIELD_PATTERN_NAME = "PATTERNNAME";
        public const string FIELD_REGISTER_DATE = "REGISTERDATE";
        public const string FIELD_RECIEVE_PATTERN = "RECIEVEPATTERN";
        public const string FIELD_SEND_PATTERN = "SENDPATTERN";
        public const string FIELD_RESETBY = "RESETBY";
        public const string FIELD_LASTNUMBER_RECIEVE = "LASTNUMBERRECIEVE";
        public const string FIELD_LASTNUMBER_SEND = "LASTNUMBERSEND";
        public const string FIELD_CANSET = "CANSET";
        public const string FIELD_SYSTEMNAME = "SYSTEMNAME";

        public const string indexField = FIELD_ID;

        public LetterNumberPatternEntity()
        {
            TableName = "LETTERNUMBERPATTERN";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }


        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);

            DataColumnCollection myColumns = dataTable.Columns;
            
            myColumns.Add(FIELD_ID, typeof(System.Int64));
            myColumns.Add(FIELD_PATTERN_NAME, typeof(System.String));
            myColumns.Add(FIELD_REGISTER_DATE, typeof(System.DateTime));
            myColumns.Add(FIELD_RECIEVE_PATTERN, typeof(System.String));
            myColumns.Add(FIELD_SEND_PATTERN, typeof(System.String));
            myColumns.Add(FIELD_RESETBY, typeof(System.Int32));
            myColumns.Add(FIELD_LASTNUMBER_RECIEVE, typeof(System.String));
            myColumns.Add(FIELD_LASTNUMBER_SEND, typeof(System.String));
            myColumns.Add(FIELD_CANSET, typeof(System.Boolean));
            myColumns.Add(FIELD_SYSTEMNAME, typeof(System.String));
            
            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            //DataColumn dc = new DataColumn();

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }
    }
}
