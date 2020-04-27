using System;
using System.Collections.Generic;
using System.Text;
using AndicatorCommon;
using AndicatorDAL;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;

namespace AndicatorBLL
{
    public class UsersBS
    {
        public static int ADMIN = 1;
        public static int USER = 2;
        public static int MASTER_USER = 3;

        #region  properties
        public static UsersEntity loginedUser;

        private static UserPropertiesEntity _logginedUserProperties;

        public static UserPropertiesEntity LogginedUserProperties
        {
            get { return UsersBS._logginedUserProperties; }
            set { UsersBS._logginedUserProperties = value; }
        }

       

        #endregion

        private UsersDA _usersDal;

        public UsersBS()
        {
            _usersDal = new UsersDA();
        }

        public UsersEntity load(string cond)
        {
            return _usersDal.load(cond);
        }

        public UsersEntity getMasterUsers()
        {
            return _usersDal.getMasterUsers(MASTER_USER);
        }
        
        public UsersEntity get(int userid)
        {
            return _usersDal.get(userid);
        }

        public UsersEntity get(string cond)
        {
            return _usersDal.get(cond);
        }

        public int add(UsersEntity dataSet)
        {
            return _usersDal.add(dataSet);
        }

        public int update(UsersEntity dataSet)
        {
            return _usersDal.update(dataSet);
        }

        public int delete(int id)
        {
            int userid = int.Parse(loginedUser.get(UsersEntity.FIELD_ID).ToString());
            
            LetterItemsPermissionBL letterItemPerm = new LetterItemsPermissionBL();
            UserpropertiesBL userpropertiesBL = new UserpropertiesBL();
            
            letterItemPerm.deleteByUser(userid);
            userpropertiesBL.deleteByUser(userid);

             return _usersDal.delete(id);

        }

        public UsersEntity checkUser(string userName, String password,Boolean isManager)
        {
            return _usersDal.checkUser(userName, password,isManager);
        }

        public static void fillComboWithUsers(ComboBox cmb, int defaultId)
        {
            UsersDA da = new UsersDA();
            String cond = "ACTIVE=1";
            UsersEntity entity = da.load(cond);
            
            var dataSource = new List<ComboBoxItem>();
            cmb.DataSource = null;
            cmb.Items.Clear();
            BasicInfoUtil.AddUnKnown(dataSource);

            for(int i=0;i< entity.Tables[entity.FilledTableName].Rows.Count; i++) 
            {
                string name = entity.get(i,UsersEntity.FIELD_NAME) + " " + entity.get(i, UsersEntity.FIELD_FAMILY) + " ( " +
                    entity.get(i, UsersEntity.FIELD_USERNAME) + " ) ";
                string id = entity.get(i, UsersEntity.FIELD_ID).ToString();
                
                dataSource.Add(new ComboBoxItem(name, id));
            }

            cmb.DataSource = dataSource;
            cmb.DisplayMember = "Text";
            cmb.ValueMember = "Value";
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                if (((ComboBoxItem)cmb.Items[i]).Value.Equals(defaultId.ToString()))
                {
                    cmb.SelectedIndex = i;
                    break;
                }
            }
            
        }

        public static void fillCheckedListWithUsers(CheckedListBox cmb, int defaultId)
        {
            UsersDA da = new UsersDA();
            string cond = "ACTIVE=1";
            UsersEntity entity = da.load(cond);

            var dataSource = new List<ComboBoxItem>();
            cmb.DataSource = null;
            cmb.Items.Clear();
            BasicInfoUtil.AddUnKnown(dataSource);

            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                string name = entity.get(i, UsersEntity.FIELD_NAME) + " " + entity.get(i, UsersEntity.FIELD_FAMILY) + " ( " +
                    entity.get(i, UsersEntity.FIELD_USERNAME) + " ) ";
                string id = entity.get(i, UsersEntity.FIELD_ID).ToString();

                dataSource.Add(new ComboBoxItem(name, id));
            }

            cmb.DataSource = dataSource;
            cmb.DisplayMember = "Text";
            cmb.ValueMember = "Value";
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                if (((ComboBoxItem)cmb.Items[i]).Value.Equals(defaultId.ToString()))
                {
                    cmb.SelectedIndex = i;
                    break;
                }
            }

        }
      
     }

}
