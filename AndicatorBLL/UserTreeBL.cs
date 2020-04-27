using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;

namespace AndicatorBLL
{
    public class UserTreeBL: RMX_TOOLS.BLL.AbstractBL
    {
        public UserTreeBL()
        {
            _abstractDA = new UserTreeDA(); 
        }

        public UserTreeEntity get()
        {
            return ((UserTreeDA)_abstractDA).get();
        }

        public UserTreeEntity get(int id)
        {
            return ((UserTreeDA)_abstractDA).get(id);
        }

        public UserTreeEntity getByUserType(int userType)
        {
            return ((UserTreeDA)_abstractDA).getByUserType(userType);
        }

        public UserTreeEntity getByUserTableId(int userId)
        {
            UserTreeEntity u = ((UserTreeDA)_abstractDA).getByUserTableId(userId);
            return u;
        }

        public UserTreeEntity getByUser(int userId)
        {
            //UserTreeEntity userTreeEntity = get(userTreeId);
            //string userPath = userTreeEntity.get(UserTreeEntity.FIELD_USER_PATH).ToString();
            string userPath = userId + "";
            UserTreeEntity u = ((UserTreeDA)_abstractDA).getByUserId(userPath);

            return u;
        } 
        
        public int getUserIdByTreeId(int userTreeId)
        {
            //UserTreeEntity userTreeEntity = get(userTreeId);
            //string userPath = userTreeEntity.get(UserTreeEntity.FIELD_USER_PATH).ToString();
            if (userTreeId <0)
            {
                return userTreeId;
            } 
            UserTreeEntity u = ((UserTreeDA)_abstractDA).get(userTreeId);
            int userid = int.Parse(u.get(UserTreeEntity.FIELD_USER_ID).ToString());
            return userid;
        }

        //برای این کاربر در هر جای درخت چه به عنوان پدر یا فرزند لیست می گردد
        public UserTreeEntity getUserAllAccessPath(int userid)
        {
            return ((UserTreeDA)_abstractDA).getUserAllAccessPath(userid);
        }

        public UserTreeEntity getParent(int userid)  
        {
            return ((UserTreeDA)_abstractDA).getParent(userid);
        }

        public UserTreeEntity getByParent(int parentId)
        {
            return ((UserTreeDA)_abstractDA).getByParentId(parentId);
        }

        public string getAllChildsIds(int parentId)
        {
            UserTreeEntity entity = ((UserTreeDA)_abstractDA).getByParentId(parentId);
            if (entity.Tables[entity.FilledTableName].Rows.Count <= 0)
                return "";
            string ids = "";
            for (int i = 0; i < entity.RowCount(); i++)
            {
                ids += entity.get(i, UserTreeEntity.FIELD_USER_ID).ToString() + ",";
            }
            return ids.Substring(0, ids.Length - 1); 
        }

        public int add(UserTreeEntity entity)
        {
            return ((UserTreeDA)_abstractDA).add(entity);
        }

        public int update(UserTreeEntity entity)
        {
            return ((UserTreeDA)_abstractDA).update(entity);
        }

        public int delete(int id)
        {
            return ((UserTreeDA)_abstractDA).delete(id);
        }
    }
}
