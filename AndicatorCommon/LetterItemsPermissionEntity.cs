using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.common;
using System.Data;

namespace AndicatorCommon
{
    public class LetterItemsPermissionEntity : AbstractCommonData
    {

        public const string FIELD_ID = "ID";

        public const string FIELD_LETTER_SUBJECT = "LETTERSUBJECT";
        public const string FIELD_INPUT_REGISTER_NUMBER = "INPUTREGISTERNUMBER";
        public const string FIELD_LETTER_SUMMARY = "SUMMARY";
        public const string FIELD_INSURANCE_TYPE_ID = "INSURANCETYPEID";
        public const string FIELD_INSURANCE_NUMBER = "INSURANCENUMBER";
        public const string FIELD_INSURANCE_DATE = "INSURANCEDATE";
        public const string FIELD_LETTER_STATE_ID = "LETTERSTATEID";
        public const string FIELD_COMPANY_ID = "COMPANYID";
        public const string FIELD_REFERENCED_USER_ID = "REFERENCEUSERID";
        public const string FIELD_RECIEVEDLETTERNUMBER = "RECIEVEDLETTERNUMBER";
        public const string FIELD_RECIEVEDLETTERDATE = "RECIEVEDLETTERDATE";
        public const string FIELD_ARCHIVE = "ARCHIVE";
        public const string FIELD_FINAL_CONFIRM = "FINALCONFIRM";
        public const string FIELD_BTN_SEARCH = "BTNSEARCH";
        public const string FIELD_BTN_LETTER_STATE = "BTNLETTERSTATE";
        public const string FIELD_BTN_USERS_REPLIES = "BTNUSERSREPLIES";
        public const string FIELD_BTN_REFER_TO_MASTER = "REFERTOMASTER";
        public const string FIELD_BTN_SHOW_REFFRENCES = "SHOWREFFRENCES";
        public const string FIELD_ALARM_STARTDATE = "ALARMSTARTDATE";
        public const string FIELD_BTN_AGENT = "BTN_AGENT";
        public const string FIELD_DELETE_LETTER = "BTN_DELETE";
        public const string FIELD_FASTACTION = "FASTACTION";
        public const string FIELD_INSURANCE_COMPANY = "INSURANCE_COMPANY";

        public const string FIELD_BTN_DO_CHANING_TO_SEND = "DO_CHANING_TO_SEND";
        public const string FIELD_BTN_DO_CHANING_TO_RECIEVE = "DO_CHANING_TO_RECIEVE";
        public const string FIELD_BTN_SEPERATE_CHANING = "SEPERATE_CHANING";
        public const string FIELD_MANAGEMENT_ACTION = "MANAGEMENT_ACTION";
        public const string FIELD_USER_ID = "USERID";

        public const string indexField = FIELD_ID;

        public LetterItemsPermissionEntity()
        {
            TableName = "LETTERITEMSPERMISSION";
            IndexFieldName = FIELD_ID;

            BuildDataTables();
            generateCommands();
        }


        private void BuildDataTables()
        {
            DataTable dataTable = new DataTable(TableName);

            DataColumnCollection myColumns = dataTable.Columns;
            myColumns.Add(FIELD_ID, typeof(System.Int64));

            myColumns.Add(FIELD_COMPANY_ID, typeof(System.Boolean));
            myColumns.Add(FIELD_INPUT_REGISTER_NUMBER, typeof(System.Boolean));
            myColumns.Add(FIELD_INSURANCE_DATE, typeof(System.Boolean));
            myColumns.Add(FIELD_INSURANCE_NUMBER, typeof(System.Boolean));
            myColumns.Add(FIELD_INSURANCE_TYPE_ID, typeof(System.Boolean));
            myColumns.Add(FIELD_LETTER_STATE_ID, typeof(System.Boolean));
            myColumns.Add(FIELD_LETTER_SUBJECT, typeof(System.Boolean));
            myColumns.Add(FIELD_LETTER_SUMMARY, typeof(System.Boolean));
            myColumns.Add(FIELD_REFERENCED_USER_ID, typeof(System.Boolean));
            myColumns.Add(FIELD_RECIEVEDLETTERNUMBER, typeof(System.Boolean));
            myColumns.Add(FIELD_RECIEVEDLETTERDATE, typeof(System.Boolean));
            myColumns.Add(FIELD_ARCHIVE, typeof(System.Boolean));
            myColumns.Add(FIELD_FINAL_CONFIRM, typeof(System.Boolean));
            myColumns.Add(FIELD_BTN_SEARCH, typeof(System.Boolean));
            myColumns.Add(FIELD_BTN_LETTER_STATE, typeof(System.Boolean));
            myColumns.Add(FIELD_BTN_USERS_REPLIES, typeof(System.Boolean));
            myColumns.Add(FIELD_BTN_REFER_TO_MASTER, typeof(System.Boolean));
            myColumns.Add(FIELD_BTN_SHOW_REFFRENCES, typeof(System.Boolean));
            myColumns.Add(FIELD_ALARM_STARTDATE, typeof(System.Boolean));
            myColumns.Add(FIELD_BTN_AGENT, typeof(System.Boolean));
            myColumns.Add(FIELD_DELETE_LETTER, typeof(System.Boolean));
            myColumns.Add(FIELD_FASTACTION, typeof(System.Boolean));
            myColumns.Add(FIELD_MANAGEMENT_ACTION, typeof(System.Boolean));
            myColumns.Add(FIELD_INSURANCE_COMPANY, typeof(System.Boolean));

            myColumns.Add(FIELD_USER_ID, typeof(System.Int32));
            
            myColumns.Add(FIELD_BTN_DO_CHANING_TO_RECIEVE, typeof(System.Boolean));
            myColumns.Add(FIELD_BTN_DO_CHANING_TO_SEND, typeof(System.Boolean));
            myColumns.Add(FIELD_BTN_SEPERATE_CHANING, typeof(System.Boolean));
            
            myColumns.Add(FIELD_RADIF, typeof(System.Int32));

            DataTable viewDataTable = dataTable.Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + viewDataTable.TableName;

            this.Tables.Add(dataTable);
            this.Tables.Add(viewDataTable);
        }



        
    }
}
