using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RMX_TOOLS.common
{
    public class AbstractCommonData :DataSet
    {
        public const string FIELD_RADIF = "RADIF";
        public const string PASTOFEXPIRE = "EXP";
        
        public const string SHAMSIDATE = "SHAMSIDATE";
        public const string BEGINDATE_SHAMSI = "BEGINDATE_SHAMSI";

        public string VIEW_QUALIFIRE = "VIEW_";
        public static string DESC_QUALIFIRE = "_DESC";

        //جدولی که در هنگام پر شدن دیتا ست پر می شود
        private string filledTableName = "";

        public string FilledTableName
        {
            get { return filledTableName; }
            set { filledTableName = value; }
        }

        private string tableName = "";

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        private string indexFieldName;

        public string IndexFieldName
        {
            get { return indexFieldName; }
            set { indexFieldName = value; }
        }

        public string updatecmdWithIndexedWhereCluse;
        public string updatecmdWithoutWhereCluse;
        public string deleteCmdWithIndexedWhereCluse;
        public string deleteCmdWithoutWhereCluse;
        public string insertCommand;

        public SqlParameterCollection sqlParamColl;
 
        public AbstractCommonData()
        {
        }

        private Boolean checkIsAppearable(string field, string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                if (field.Equals(arr[i]))
                    return false;
            return true;
        }

        protected void generateCommands()
        {
            // the field that don't want to display in query
            string[] disappears = new string[2];
            disappears[0] = indexFieldName;
            disappears[1] = FIELD_RADIF;
            // create  an array for filed who must appear in query
            string[] appears = new string[this.Tables[tableName].Columns.Count - disappears.Length];
            string fld;
            int index = 0;
            for (int i = 0; i < this.Tables[tableName].Columns.Count; i++)
            {
                fld = this.Tables[tableName].Columns[i].Caption;
                if (checkIsAppearable(fld, disappears))
                {
                    appears[index] = fld;
                    index++;
                }
            }
            string whereCluse = " WHERE [" + indexFieldName + "] = @" + indexFieldName; ;
            //delete Command 
            string delete = "DELETE FROM [dbo].[" + getTable(tableName) + "] ";

            deleteCmdWithIndexedWhereCluse = delete + whereCluse;
            deleteCmdWithoutWhereCluse = delete;

            // insert command 

            string insert = "INSERT INTO " + getTable(tableName);
            string fields = "(";
            string values = "VALUES(";
            for (int i = 0; i < appears.Length - 1; i++)
            {
                fld = appears[i];
                fields += "[" + fld + "],";
                values += "@" + fld + ",";
                 
            }
             
            fld = appears[appears.Length - 1];
            fields += "[" + fld + "])";
            values += "@" + fld + ")";
            
            insert += fields + values;
            insertCommand = insert;

            //update command
            string update = "UPDATE [dbo].[" + getTable(tableName) + "] SET ";
            for (int i = 0; i < appears.Length -1 ; i++)
            {
                fld = appears[i];
                update += " [" + fld + "] = @" + fld + ",";
                 
            }
             
            fld = appears[appears.Length -1];
                update += "[" + fld + "] = @" + fld + "";

            updatecmdWithIndexedWhereCluse = update + whereCluse;
            updatecmdWithoutWhereCluse = update;
        }

        public string getTable(string tableName)
        {
            if (tableName.IndexOf(VIEW_QUALIFIRE) >= 0)
                return tableName.Substring(VIEW_QUALIFIRE.Length, tableName.Length);
            return tableName;
        }

        public object get(string fieldName)
        {
            if (this.FilledTableName.Length <= 0)
                this.FilledTableName = this.tableName;

            if (this.Tables.Count > 0 && this.Tables[this.FilledTableName].Rows.Count > 0)
            {
                if(this.Tables[this.FilledTableName].Rows[0][fieldName].ToString().Equals(System.DBNull.Value.ToString()))
                    return "";
                return this.Tables[this.FilledTableName].Rows[0][fieldName];
            }
            else
                return "";
        }

        public object get(int index, string fieldName)
        {
            if (this.Tables.Count > 0 && this.Tables[filledTableName].Rows.Count > 0)
                return this.Tables[this.FilledTableName].Rows[index][fieldName];
            else
                return "";
        }

        public int RowCount()
        {
            if (this.Tables.Count > 0 && this.Tables[this.FilledTableName].Rows.Count > 0)
                return this.Tables[this.FilledTableName].Rows.Count;
            else
                return 0;
        }

    }


}
