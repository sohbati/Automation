using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Data;
using RMX_TOOLS.hasti.bll;

namespace AndicatorBLL
{
    public class LetterBL : RMX_TOOLS.BLL.AbstractBL
    {
        public static int LETTER_TYPE_RECIEVE = 1;
        public static int LETTER_TYPE_SEND = 2;

        public LetterBL()
        {
            _abstractDA = new LetterDA(); 
        }

        public LetterEntity get(string ids)
        {
            return ((LetterDA)_abstractDA).get(ids);
        }

        public LetterEntity get(int letterType, bool showLastChained)
        {
            return ((LetterDA)_abstractDA).get(letterType, showLastChained);
        }
        public LetterEntity get(string cond, int letterType, bool showLastChained)
        {
            return ((LetterDA)_abstractDA).get(cond, letterType, showLastChained);
        }

        public LetterEntity get(int letterType, string letterNumber, bool showLastChained)
        {
            return ((LetterDA)_abstractDA).get(letterType, letterNumber, showLastChained);
        }

        public LetterEntity get(int letterType, bool isArchived, bool showLastChained)
        {
            return ((LetterDA)_abstractDA).get(letterType, isArchived, showLastChained);
        }

        public LetterEntity get(int letterType, bool isArchived, int userId, bool showLastChained)
        {
            return ((LetterDA)_abstractDA).get(letterType, isArchived, userId, showLastChained);
        }

        public LetterEntity getRefferedToUser(int userId, bool showLastChained)
        {
            return ((LetterDA)_abstractDA).getRefferedToUser(userId, showLastChained);
        }

        public LetterEntity getByUserTreeId(int userTreeId)
        {
            return ((LetterDA)_abstractDA).getByUserTreeId(userTreeId);
        }

        public LetterEntity getByUserTreeIds(string userTreeIds)
        {
            return ((LetterDA)_abstractDA).getByUserTreeIds(userTreeIds);
        }

        public LetterEntity getByLetterId(int id)
        {
            return ((LetterDA)_abstractDA).getByLetterId(id);
        }
        
        public LetterEntity getByGroupId(int id)
        {
            return ((LetterDA)_abstractDA).getByGroupId(id);
        }
        
        public LetterEntity getByLetterNumber(string letterNumber)
        {
            return ((LetterDA)_abstractDA).getByLetterNumber(letterNumber);
        }

        public LetterEntity getRecievedLetters(bool showLastChained)
        {
            return get(LETTER_TYPE_RECIEVE, showLastChained);
        }

        public LetterEntity getSentLetters(bool showLastChained)
        {
            return get(LETTER_TYPE_SEND, showLastChained);
        }

        public int add(LetterEntity entity)
        {
            return ((LetterDA)_abstractDA).add(entity);
        }

        public int changeUserTreeOwnedLetters(int fromUserTreeId, int toUserTreeId) {
            return ((LetterDA)_abstractDA).changeUserTreeOwnedLetters(fromUserTreeId, toUserTreeId);
        }
        
        public int changeUserTreeOwnedLetters(string fromUserTreeIds, int toUserTreeId)
        {
            return ((LetterDA)_abstractDA).changeUserTreeOwnedLetters(fromUserTreeIds, toUserTreeId);
        }

        public int update(LetterEntity entity)
        {
            return ((LetterDA)_abstractDA).update(entity);
        }

        public int updateColor(int letterStateID, string color)
        {
            return ((LetterDA)_abstractDA).updateColor(letterStateID, color);
        }

        private int updateRefColor(int letterid, string color)
        {
            return ((LetterDA)_abstractDA).updateRefCountColor(letterid, color);
        }

        public int updateMaxRefLimitColor(int maxRefLimit, String color)
        {
            return ((LetterDA)_abstractDA).updateMaxRefLimitColor(maxRefLimit, color);
        }

        public int updateConfimedsColor(String color) {
            return ((LetterDA)_abstractDA).updateConfimedsColor(color);
        }

        public int updateRefferenceUser(int letterid, int userTreeId)
        {
            if (letterid < 0)
                return 0;
            //
            int referFromUserId = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString()); 
            ((LetterDA)_abstractDA).updateRefferenceUser(letterid, userTreeId, referFromUserId);
            
            ReferLetterBL referLetterBL = new ReferLetterBL();
            //Register Refer to referletter table
            int currUserId = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
            // کاربری که در درخت قرار دارد را شناسایی کرده و 
            // به userTreeUserId الحاق شود
            UserTreeBL userTreeBL = new UserTreeBL();

            UserTreeEntity usertreeEntity = userTreeBL.get(userTreeId);
            int usertreeUserId = int.Parse(usertreeEntity.get(UserTreeEntity.FIELD_USER_ID).ToString());

            //بررسی برای برگشت ارجاع
            // اگر برگشت باشد ثبت می کند
            checkForReferenceCycle(letterid, currUserId, usertreeUserId);


            ReferLetterEntity entity = new ReferLetterEntity();
            DataRow dr = entity.Tables[entity.TableName].NewRow();

            dr[ReferLetterEntity.FIELD_LETTER_ID] = letterid;
            dr[ReferLetterEntity.FIELD_REFER_DATE] = DateTime.Now;
            dr[ReferLetterEntity.FIELD_REFER_FROM_USER] = currUserId;
            dr[ReferLetterEntity.FIELD_REFER_TO_USER] = usertreeUserId;// کاربر در درخت کاربران

            entity.Tables[entity.TableName].Rows.Add(dr);
            referLetterBL.add(entity);

            //check how many reffer occured this letter 
            // اگر بیش از حد ارجاع شده باشد رنگ ان را تغییر خواهیم داد
            int refCount = referLetterBL.getReferCount(letterid);
            ApplicationPropertiesBL appProBl = new ApplicationPropertiesBL();
            int masterRefCount =  int.Parse(appProBl.getValue(ApplicationPropertiesBL.REFERENCE_COUNT));
            if (refCount >= masterRefCount)
            {
                string refColor = appProBl.getValue(ApplicationPropertiesBL.COLOR_REFERENCE_LIMIT);
                updateRefColor(letterid, refColor);
            }
            return 1;
        }

        /**
         * find any cycle happening in any refer o fletter between users
         * */
        private void checkForReferenceCycle(int letterId, int newFromUserId, int newToUserId)
        {
            ReferLetterEntity referEntity = getLastReferedEntity(letterId);
            if (referEntity == null)
                return;
            int lastFromUser = int.Parse(
                referEntity.Tables[0].Rows[0][ReferLetterEntity.FIELD_REFER_FROM_USER].ToString());

            if (lastFromUser == newToUserId)
            {
                //a cycle happened
                // persist it 
                ReferenceCycleEntity cycleEntity = new ReferenceCycleEntity();
                DataRow dr = null;
                dr = cycleEntity.Tables[cycleEntity.TableName].NewRow();
                cycleEntity.FilledTableName = cycleEntity.TableName;


                dr[ReferenceCycleEntity.FIELD_FIRSTREFERDATE] = referEntity.Tables[0].Rows[0][ReferLetterEntity.FIELD_REFER_DATE];
                dr[ReferenceCycleEntity.FIELD_FIRSTFROMUSER] = referEntity.Tables[0].Rows[0][ReferLetterEntity.FIELD_REFER_FROM_USER];
                dr[ReferenceCycleEntity.FIELD_FIRSTTOUSER] = referEntity.Tables[0].Rows[0][ReferLetterEntity.FIELD_REFER_TO_USER];

                dr[ReferenceCycleEntity.FIELD_SECONDREFERDATE] = DateTime.Now;
                dr[ReferenceCycleEntity.FIELD_SECONDFROMUSER] = newFromUserId;
                dr[ReferenceCycleEntity.FIELD_SECONDTOUSER] = newToUserId;

                dr[ReferenceCycleEntity.FIELD_LETTERID] = letterId;

                cycleEntity.Tables[cycleEntity.TableName].Rows.Add(dr);

                ReferenceCycleBL referenceCycleBL = new ReferenceCycleBL();
                referenceCycleBL.add(cycleEntity);

            }
        }

        public int getLetterType(int id)
        {
            LetterEntity letterEntity = getByLetterId(id);
            int type  = int.Parse(letterEntity.get(LetterEntity.FIELD_LETTER_TYPE).ToString());
            return type;
        }

        private ReferLetterEntity getLastReferedEntity(int letterId)
        {
            ReferLetterBL refLetterBL = new ReferLetterBL();
            ReferLetterEntity entity = refLetterBL.getLastRefered(letterId);

            if (entity == null || entity.Tables.Count == 0 || entity.Tables[0].Rows.Count == 0)
                return null;

            String user = entity.Tables[0].Rows[0][ReferLetterEntity.FIELD_REFER_FROM_USER].ToString();
            if (user == null || user.Length == 0)
                return null;

            return entity;
        }

        public int delete(int id)
        {
            return ((LetterDA)_abstractDA).delete(id);
        }

        public void updateRefferenceDate(DateTime dateTime, int letterId)
        {
            ((LetterDA)_abstractDA).updateRefferenceDate(dateTime, letterId);
        }

        public int getFastActionCount(bool showLastChained)
        {
            if (UsersBS.loginedUser == null)
                return 0;
            int userid = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
            LetterEntity entity = ((LetterDA)_abstractDA).getFastActions(userid, showLastChained);
            return entity.Tables[entity.FilledTableName].Rows.Count;
        }

        public LetterEntity getFastActions(int userid, bool showLastChained)
        {
            return ((LetterDA)_abstractDA).getFastActions(userid, showLastChained);
        }

        public int UpdateNextLetter(int masterLetterId, int nextLetterId)
        {
            return ((LetterDA)_abstractDA).UpdateNextLetter(masterLetterId, nextLetterId);
        }
        public int UpdatePriorLetter(int masterLetterId, int priorLetterId)
        {
            return ((LetterDA)_abstractDA).UpdatePriorLetter(masterLetterId, priorLetterId);
        }

        public void updateChainedArchives(int lastOfChinLetterId, bool archive, bool finalConfirm, bool fastAction)
        {
            ((LetterDA)_abstractDA).updateChainedArchives(lastOfChinLetterId, archive, finalConfirm, fastAction);
        }

        public string getAllChainedsByLetterId(int letterId)
        {
            return ((LetterDA)_abstractDA).getAllChainedsByLetterId(letterId);
            
        }

        public void addLetterGroup(int letterId, int letterGroupId)
        {
            ((LetterDA)_abstractDA).addLetterGroup(letterId, letterGroupId);

            updateLetterNumbersInLetterGroupTable(letterGroupId);
        }

        public void updateLetterNumbersInLetterGroupTable(int letterGroupId)
        {
            //1- collect  letter numbers
            string s = "";
            LetterEntity letterEntity = getByGroupId(letterGroupId);
            for (int i = 0; i < letterEntity.Tables[letterEntity.FilledTableName].Rows.Count; i++)
            {
                s = s + letterEntity.get(LetterEntity.FIELD_LETTER_NUMBER) + ",";
            }

            s = "".Equals(s) ? "" :  s.Substring(0, s.Length - 1);

            //2 - update letter group table
            LetterGroupBL letterGroupBL = new LetterGroupBL();
            letterGroupBL.updateLetterNumbers(letterGroupId, s);

        }

        public void removeFromGroup(int letterId, int letterGroupId)
        {
            ((LetterDA)_abstractDA).removeFromGroup(letterId);
            updateLetterNumbersInLetterGroupTable(letterGroupId);
        }
    }

}
