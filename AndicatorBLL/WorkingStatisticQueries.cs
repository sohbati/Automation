using System;
using System.Collections.Generic;
using System.Text;
using AndicatorCommon;

namespace AndicatorBLL
{
   public class WorkingStatisticQueries
    {
        private LetterBL _letter = new LetterBL();
        private string _userLable = "@userid@";


        public LetterEntity getCurLetterAll(int userid) //1
        {
            String CUR_LETTER_ALL = "SELECT * FROM dbo.VIEW_LETTER WHERE (ARCHIVE IS NULL OR ARCHIVE = 0) AND (REFFERDATE < GETDATE()) " +
            "AND USERTREEID IN(SELECT USERTREE.ID FROM USERTREE WHERE USERID = @userid@) AND NEXTLETTERID is null";

            LetterEntity entity = new LetterEntity();
            RMX_TOOLS.data.Config.provider.executeSelect(CUR_LETTER_ALL.Replace(_userLable, userid + ""), entity, entity.Tables[1].TableName);
            return entity;
        }

        public LetterEntity getCurLetterMarked(int userid) //2
        {
            String CUR_LETTER_ALL = " SELECT * FROM dbo.VIEW_LETTER WHERE (ARCHIVE IS NULL OR ARCHIVE = 0) AND "+
          " (REFFERDATE < GETDATE() - CAST('1900-01-04' AS DATETIME)) " +
         " AND USERTREEID IN(SELECT USERTREE.ID FROM USERTREE WHERE USERID = @userid@) AND NEXTLETTERID is null";

            LetterEntity entity = new LetterEntity();
            RMX_TOOLS.data.Config.provider.executeSelect(CUR_LETTER_ALL.Replace(_userLable, userid + ""), entity, entity.Tables[1].TableName);
            return entity;
        }

        public LetterEntity getgridRateDecAll(int userid) //3
        {
            String CUR_LETTER_ALL = " SELECT * FROM dbo.VIEW_LETTER WHERE (ARCHIVE IS NULL OR ARCHIVE = 0) AND " +
          "(REFFERDATE < GETDATE()) AND (LETTERSTATEID = 6) " +
         " AND USERTREEID IN(SELECT USERTREE.ID FROM USERTREE WHERE USERID = @userid@) AND NEXTLETTERID is null";

            LetterEntity entity = new LetterEntity();
            RMX_TOOLS.data.Config.provider.executeSelect(CUR_LETTER_ALL.Replace(_userLable, userid + ""), entity, entity.Tables[1].TableName);
            return entity;
        }

        public LetterEntity getgridRateDecMarked(int userid) //4
        {
            String CUR_LETTER_ALL = " SELECT * FROM dbo.VIEW_LETTER WHERE (ARCHIVE IS NULL OR ARCHIVE = 0) AND " +
          "(REFFERDATE < GETDATE() - CAST('1900-01-04' AS DATETIME)) AND (LETTERSTATEID = 6) " +
         " AND USERTREEID IN(SELECT USERTREE.ID FROM USERTREE WHERE USERID = @userid@) AND NEXTLETTERID is null";

            LetterEntity entity = new LetterEntity();
            RMX_TOOLS.data.Config.provider.executeSelect(CUR_LETTER_ALL.Replace(_userLable, userid + ""), entity, entity.Tables[1].TableName);
            return entity;
        }

        public LetterEntity getgridRateDecOralAll(int userid) //5
        {
            String CUR_LETTER_ALL = " SELECT * FROM dbo.VIEW_LETTER WHERE (ARCHIVE IS NULL OR ARCHIVE = 0) AND " +
          "(REFFERDATE < GETDATE()) AND (LETTERSTATEID = 24) " +
         " AND USERTREEID IN(SELECT USERTREE.ID FROM USERTREE WHERE USERID = @userid@) AND NEXTLETTERID is null";

            LetterEntity entity = new LetterEntity();
            RMX_TOOLS.data.Config.provider.executeSelect(CUR_LETTER_ALL.Replace(_userLable, userid + ""), entity, entity.Tables[1].TableName);
            return entity;
        }

        public LetterEntity getgridRateDecOralMarked(int userid)
        {
            String CUR_LETTER_ALL = " SELECT * FROM dbo.VIEW_LETTER WHERE (ARCHIVE IS NULL OR ARCHIVE = 0) AND " +
          "(REFFERDATE < GETDATE() - CAST('1900-01-04' AS DATETIME)) AND (LETTERSTATEID = 24) " +
          " AND USERTREEID IN(SELECT USERTREE.ID FROM USERTREE WHERE USERID = @userid@) AND NEXTLETTERID is null";
            
            LetterEntity entity = new LetterEntity();
            RMX_TOOLS.data.Config.provider.executeSelect(CUR_LETTER_ALL.Replace(_userLable, userid + ""), entity, entity.Tables[1].TableName);
            return entity;
        }

        public ChequeEntity getGridChequeHasRemainder(int userid)
        {
         String CHEQUE_HAS_REMAINDER = " SELECT * FROM         (SELECT     *,  ID AS CHEQUEID "+
         "    FROM         dbo.VIEW_CHEQUE) AS R_1 " +
         "    WHERE  (ARCHIVE IS NULL OR ARCHIVE = 0) AND (R_1.REFFERDATE < GETDATE() - CAST('1900-01-04' AS DATETIME)) AND (PRICE<>REMAINED OR REMAINED IS NULL) AND " + 
         "         EXISTS " +
         "              (SELECT     ID, CHEQUEID, RECIEPTBILLNUMBER, ISSUEDATE, PRICE, DESCRIPTION, " +
         "              REGISTERDATE, REGISTRANTUSER " +
         "                 FROM         dbo.CHEQUEREPLY AS CHEQUEREPLY_2 " +
         "                 WHERE     (CHEQUEID = R_1.CHEQUEID)) " +
         "     " +
         "                  AND USERTREEID IN(SELECT USERTREE.ID FROM USERTREE WHERE USERID =@userid@)";

            ChequeEntity entity = new ChequeEntity();
            RMX_TOOLS.data.Config.provider.executeSelect(CHEQUE_HAS_REMAINDER.Replace(_userLable, userid + ""), entity, entity.Tables[1].TableName);
            return entity;
        }
    
        public ChequeEntity getGridChequeWithoutAnswer(int userid)
        {
            String CHEQUE_WHITHOUT_ANS = " SELECT    * FROM         dbo.VIEW_CHEQUE AS R" +
            "   WHERE   (ARCHIVE IS NULL OR ARCHIVE = 0)AND (R.REFFERDATE < GETDATE() - CAST('1900-01-04' AS DATETIME)) AND " +
            "    (NOT EXISTS " +
            " (SELECT     ID, CHEQUEID, RECIEPTBILLNUMBER, ISSUEDATE, PRICE, DESCRIPTION, REGISTERDATE, REGISTRANTUSER " +
            " FROM         dbo.CHEQUEREPLY AS CHEQUEREPLY_1 " +
            " WHERE     (CHEQUEID = R.ID))) " +
              
             "     " +
             "                  AND USERTREEID IN(SELECT USERTREE.ID FROM USERTREE WHERE USERID =@userid@)";

            ChequeEntity entity = new ChequeEntity();
            RMX_TOOLS.data.Config.provider.executeSelect(CHEQUE_WHITHOUT_ANS.Replace(_userLable, userid + ""), entity, entity.Tables[1].TableName);
            return entity;
        }
   }

}
