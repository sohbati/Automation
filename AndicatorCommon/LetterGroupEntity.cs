using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;
using System.Data;

namespace AndicatorCommon
{
    public class LetterGroupEntity : AbstractCommonData
    {

        public const string FIELD_ID = "ID";
        public const string FIELD_GROUPTITLE = "GROUPTITLE";
        public const string FIELD_LETTERNUMBERS = "LETTERNUMBERS";
         
           
        public const string indexField = FIELD_ID;

        public LetterGroupEntity()
        {
            TableName = "LETTERGROUP";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }


        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);

            DataColumnCollection myColumns = dataTable.Columns;
            
            myColumns.Add(FIELD_ID, typeof(System.Int32));
            myColumns.Add(FIELD_GROUPTITLE, typeof(System.String));
            myColumns.Add(FIELD_LETTERNUMBERS, typeof(System.String));


            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }
    }
}
