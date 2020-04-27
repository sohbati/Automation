using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;
using System.Data;
using RMX_TOOLS.hasti.bll;

namespace AndicatorBLL
{
    public class ChequeBL : RMX_TOOLS.BLL.AbstractBL
    {
        public ChequeBL()
        {
            _abstractDA = new ChequeDA();
        }

        public ChequeEntity get()
        {
            return ((ChequeDA)_abstractDA).get();
        }

        public ChequeEntity get(int id)
        {
            return ((ChequeDA)_abstractDA).get(id);
        }

        public ChequeEntity get(string cond, bool isArchived)
        {
            return ((ChequeDA)_abstractDA).get(cond, isArchived);
        }

        public ChequeEntity get(string cond)
        {
            return ((ChequeDA)_abstractDA).get(cond);
        }

        public int add(ChequeEntity entity)
        {
            return ((ChequeDA)_abstractDA).add(entity);
        }

        public int update(ChequeEntity entity)
        {
            return ((ChequeDA)_abstractDA).update(entity);
        }

        public int delete(int id)
        {
            return ((ChequeDA)_abstractDA).delete(id);
        }

        public static void fillComboBox(ComboBox cmb, int defaultItem)
        {
            cmb.Items.Clear();
            ChequeBL bl = new ChequeBL();

            ChequeEntity entity = bl.get();
            var dataSource = new List<ComboBoxItem>();

            BasicInfoUtil.AddUnKnown(dataSource);

            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                string id = entity.Tables[entity.FilledTableName].Rows[i][ChequeEntity.FIELD_ID].ToString();
                string desc = entity.Tables[entity.FilledTableName].Rows[i][ChequeEntity.FIELD_BANK_ID].ToString();

                dataSource.Add(new ComboBoxItem(desc, id, ""));
            }
            cmb.DataSource = dataSource;
            cmb.DisplayMember = "Text";
            cmb.ValueMember = "Value";

            for (int i = 0; i < cmb.Items.Count; i++)
            {
                if (((ComboBoxItem)cmb.Items[i]).Value.Equals(defaultItem.ToString()))
                {
                    cmb.SelectedIndex = i;
                    break;
                }
            }

        }

        public int updateRefferenceUser(int chequeId, int userTreeId)
        {
            if (chequeId < 0)
                return 0;
            int referFromUserId = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
           int updated =  ((ChequeDA)_abstractDA).updateRefferenceUser(chequeId, userTreeId, referFromUserId);

            ReferChequeBL referChequeBL = new ReferChequeBL();
            //Register Refer to refer cheque table
            int currUserId = int.Parse(UsersBS.loginedUser.get(UsersEntity.FIELD_ID).ToString());
            // کاربری که در درخت قرار دارد را شناسایی کرده و 
            // به userTreeUserId الحاق شود
            UserTreeBL userTreeBL = new UserTreeBL();

            UserTreeEntity usertreeEntity = userTreeBL.get(userTreeId);
            int usertreeUserId = int.Parse(usertreeEntity.get(UserTreeEntity.FIELD_USER_ID).ToString());

            ReferChequeEntity entity = new ReferChequeEntity();
            DataRow dr = entity.Tables[entity.TableName].NewRow();

            dr[ReferChequeEntity.FIELD_CHEQUE_ID] = chequeId;
            dr[ReferChequeEntity.FIELD_REFER_DATE] = DateTime.Now;
            dr[ReferChequeEntity.FIELD_REFER_FROM_USER] = currUserId;
            dr[ReferChequeEntity.FIELD_REFER_TO_USER] = usertreeUserId;// کاربر در درخت کاربران

            entity.Tables[entity.TableName].Rows.Add(dr);
            referChequeBL.add(entity);

            //check how many reffer occured this cheque 
            // اگر بیش از حد ارجاع شده باشد رنگ ان را تغییر خواهیم داد
            int refCount = referChequeBL.getReferCount(chequeId);
            ApplicationPropertiesBL appProBl = new ApplicationPropertiesBL();
            int masterRefCount = int.Parse(appProBl.getValue(ApplicationPropertiesBL.REFERENCE_COUNT));
            if (refCount >= masterRefCount)
            {
                string refColor = appProBl.getValue(ApplicationPropertiesBL.COLOR_REFERENCE_LIMIT);
                updateColor(chequeId, refColor);
            }
            return updated;
        }

        public void updateColor(string color)
        {
            ((ChequeDA)_abstractDA).updateColor(color);
        }
        
        public int updateColor(int chequeid, string color)
        {
            return ((ChequeDA)_abstractDA).updateColor(chequeid, color);
        }

        public ChequeEntity get(string cond, bool archive, int userid)
        {
            return ((ChequeDA)_abstractDA).get(cond, archive, userid);
        }

        public ChequeEntity getRefferedToUser(int userId)
        {
            return ((ChequeDA)_abstractDA).getRefferedToUser(userId);
        }

        public ChequeEntity getByUserTreeId(int userTreeId)
        {
            return ((ChequeDA)_abstractDA).getByUserTreeId(userTreeId);
        }
        
        public ChequeEntity getByUserTreeIds(string userTreeIds)
        {
            return ((ChequeDA)_abstractDA).getByUserTreeIds(userTreeIds);
        }

        public int changeUserTreeOwnedCheques(int fromUserTreeId, int toUserTreeId)
        {
            return ((ChequeDA)_abstractDA).changeUserTreeOwnedCheques(fromUserTreeId, toUserTreeId);
        }

        public int changeUserTreeOwnedCheques(string fromUserTreeIds, int toUserTreeId)
        {
            return ((ChequeDA)_abstractDA).changeUserTreeOwnedCheques(fromUserTreeIds, toUserTreeId);
        }

    }
}
