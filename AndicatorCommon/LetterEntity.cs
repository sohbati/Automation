using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;
using System.Data;

namespace AndicatorCommon
{
    public class LetterEntity : AbstractCommonData
    {

        public const string FIELD_ID = "ID";
        public const string FIELD_LETTER_NUMBER = "LETTERNUMBER";
        public const string FIELD_LETTER_DATE = "LETTERDATE";
        public const string FIELD_LETTER_SUBJECT = "LETTERSUBJECT";
        public const string FIELD_INPUT_REGISTER_NUMBER = "INPUTREGISTERNUMBER";
        public const string FIELD_LETTER_SUMMARY = "SUMMARY";
        public const string FIELD_INSURANCE_TYPE_ID =  "INSURANCETYPEID";
        public const string FIELD_MANAGEMENT_ACTION_ID = "MANAGEMENTACTIONID";
        public const string FIELD_INSURANCE_NUMBER = "INSURANCENUMBER";
        public const string FIELD_INSURANCE_DATE = "INSURANCEDATE";
        public const string FIELD_LETTER_STATE_ID = "LETTERSTATEID";
        public const string FIELD_COMPANY_ID = "COMPANYID";
        public const string FIELD_GROUP_ID = "GROUPID";
        
        public const string FIELD_USER_REPLY_ID = "USERREPLYID";
        public const string FIELD_LETTER_TYPE = "LETTERTYPE";
        public const string FIELD_USER_TREE_ID = "USERTREEID";
        public const string FIELD_CANCEL = "CANCEL";
        public const string FIELD_RECIEVEDLETTERNUMBER = "RECIEVEDLETTERNUMBER";
        public const string FIELD_RECIEVEDLETTERDATE = "RECIEVEDLETTERDATE";
        public const string FIELD_ARCHIVE = "ARCHIVE";
        public const string FIELD_COLOR = "COLOR";
        public const string FIELD_FINAL_CONFIRM = "FINALCONFIRM";
        public const string FIELD_INSURANCE_COMPANY = "INSURANCECOMPANY";
        public const string FIELD_FASTACTION = "FASTACTION";

        public const string FIELD_AGENT_ID = "AGENTID";
        public const string FIELD_REFFER_DATE = "REFFERDATE";

        public const string FIELD_REFER_FROM_USER_ID = "REFFERFROM";

        public const string FIELD_PREVIOUSLETTERID = "PREVIOUSLETTERID";
        public const string FIELD_NEXTLETTERID = "NEXTLETTERID";
        //فیلد ارجاع کاربر 
        public const string VIEW_FIELD_REFERENCED_USER_ID = "REFERENCEUSERID";
         
        public const string indexField = FIELD_ID;

        public LetterEntity()
        {
            TableName = "LETTER";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }


        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);

            DataColumnCollection myColumns = dataTable.Columns;
            
            myColumns.Add(FIELD_ID, typeof(System.Int32));
            myColumns.Add(FIELD_COMPANY_ID, typeof(System.Int32));
            myColumns.Add(FIELD_INPUT_REGISTER_NUMBER, typeof(System.String));
            myColumns.Add(FIELD_INSURANCE_DATE, typeof(System.DateTime));
            myColumns.Add(FIELD_INSURANCE_NUMBER, typeof(System.String));
            myColumns.Add(FIELD_INSURANCE_TYPE_ID, typeof(System.Int32));
            myColumns.Add(FIELD_LETTER_DATE, typeof(System.DateTime));
            myColumns.Add(FIELD_LETTER_NUMBER, typeof(System.String));
            myColumns.Add(FIELD_LETTER_STATE_ID, typeof(System.Int32));
            myColumns.Add(FIELD_LETTER_SUBJECT, typeof(System.String));
            myColumns.Add(FIELD_LETTER_SUMMARY, typeof(System.String));
            myColumns.Add(FIELD_LETTER_TYPE, typeof(System.Byte));
            myColumns.Add(FIELD_USER_TREE_ID, typeof(System.Int64));
            myColumns.Add(FIELD_USER_REPLY_ID, typeof(System.Int32));
            myColumns.Add(FIELD_CANCEL, typeof(System.Byte));
            myColumns.Add(FIELD_RECIEVEDLETTERNUMBER, typeof(System.String));
            myColumns.Add(FIELD_RECIEVEDLETTERDATE, typeof(System.DateTime));
            myColumns.Add(FIELD_ARCHIVE, typeof(System.Boolean));
            myColumns.Add(FIELD_COLOR, typeof(System.String));
            myColumns.Add(FIELD_FINAL_CONFIRM, typeof(System.Boolean));
            myColumns.Add(FIELD_INSURANCE_COMPANY, typeof(System.String));
            myColumns.Add(FIELD_AGENT_ID, typeof(System.Int32));
            myColumns.Add(FIELD_REFER_FROM_USER_ID, typeof(System.Int32));
            myColumns.Add(FIELD_FASTACTION, typeof(System.Boolean));
            myColumns.Add(FIELD_GROUP_ID, typeof(System.Int32));

            myColumns.Add(FIELD_RADIF, typeof(System.Int32));
            myColumns.Add(FIELD_REFFER_DATE, typeof(System.DateTime));

            myColumns.Add(FIELD_MANAGEMENT_ACTION_ID, typeof(System.Int32));

            myColumns.Add(FIELD_PREVIOUSLETTERID, typeof(System.Int32));
            myColumns.Add(FIELD_NEXTLETTERID, typeof(System.Int32));
            //DataColumn dc = new DataColumn();

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            viewDataTable.Columns.Add(FIELD_INSURANCE_TYPE_ID + "_DESC", typeof(System.String));
            viewDataTable.Columns.Add(FIELD_LETTER_STATE_ID + "_DESC", typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_REFERENCED_USER_ID + "_DESC", typeof(System.String));
            viewDataTable.Columns.Add(VIEW_FIELD_REFERENCED_USER_ID , typeof(System.Int64));

            viewDataTable.Columns.Add(FIELD_REFER_FROM_USER_ID + "DESC", typeof(System.String));

            viewDataTable.Columns.Add(FIELD_COMPANY_ID + "_DESC", typeof(System.String));
            viewDataTable.Columns.Add("STAR", typeof(System.String));

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }
    }
}
