using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AndicatorCommon
{
    public class LetterReplyCountViewEntity : LetterEntity
    {
        public const string FIELD_REPLYCOUNT = "REPLYCOUNT";

        public LetterReplyCountViewEntity() : base()
        {

            DataTable viewDataTable = this.Tables[VIEW_QUALIFIRE + TableName].Copy();
            viewDataTable.TableName = VIEW_QUALIFIRE + "LETTERREPLYCOUNT";
            FilledTableName = VIEW_QUALIFIRE + "LETTERREPLYCOUNT";

            viewDataTable.Columns.Add(FIELD_REPLYCOUNT, typeof(System.Int64));

            this.Tables.Add(viewDataTable);

        }
    }
}
