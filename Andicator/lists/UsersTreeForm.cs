using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AndicatorBLL;
using AndicatorCommon;
using Andicator.controls;

namespace Andicator.lists
{
    public partial class UsersTreeForm : Form
    {
        private UserTreeBL _userTreeBL;
        private UsersBS _usersBS;

        public UsersTreeForm()
        {
            _userTreeBL = new UserTreeBL();
            _usersBS = new UsersBS();
            InitializeComponent();
            
        }

        public void loadTree()
        {
            UserTreeEntity entity = _userTreeBL.getByParent(-1);
            if (entity.Tables[entity.FilledTableName].Rows.Count <= 0)
            {
                initTree();
            }
            else
                createTree(entity, null);
            treeView1.Nodes[0].Expand();
        }

        private void createTree(UserTreeEntity entity, TreeNode node)
        {
            UsersEntity userEntity = null;
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                int childUserId = int.Parse(entity.get(i, UserTreeEntity.FIELD_USER_ID).ToString());
                int parentId = int.Parse(entity.get(i, UserTreeEntity.FIELD_ID).ToString());
                userEntity = _usersBS.get(childUserId);
                TreeNode newNode = null;
                if (node == null)
                {
                    node = new TreeNode(userEntity.ToString(i));
                    node.Tag = NodeItem.ToNodeItem(entity, i);
                    node.ForeColor = Color.Green;
                    treeView1.Nodes.Add(node);
                    newNode = node;
                }
                else
                {
                    newNode = new TreeNode(userEntity.ToString());
                    newNode.Tag = NodeItem.ToNodeItem(entity, i);
                    newNode.ForeColor = Color.Green;
                    node.Nodes.Add(newNode);
                }
                
                createTree(_userTreeBL.getByParent(parentId), newNode);
            }
        }

        private void initTree()
        {
            UsersEntity entity = _usersBS.get(UsersEntity.FIELD_USER_TYPE + "=" + UsersBS.ADMIN);
            UserTreeEntity userTreeEntity = null;
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                userTreeEntity = new UserTreeEntity();
                DataRow dr = userTreeEntity.Tables[userTreeEntity.TableName].NewRow();
                dr[UserTreeEntity.FIELD_USER_ID] = entity.get(UsersEntity.FIELD_ID);
                dr[UserTreeEntity.FIELD_USER_PATH] = entity.get(UsersEntity.FIELD_ID).ToString();
                userTreeEntity.Tables[userTreeEntity.TableName].Rows.Add(dr);
                _userTreeBL.add(userTreeEntity);
                
            }

            userTreeEntity = _userTreeBL.get();
            for (int i = 0; i < userTreeEntity.Tables[userTreeEntity.FilledTableName].Rows.Count; i++)
            {
                entity = _usersBS.get(int.Parse(userTreeEntity.get(UserTreeEntity.FIELD_USER_ID).ToString()));
                TreeNode node = new TreeNode(entity.ToString());
                node.ForeColor = Color.Green;
                node.Tag = NodeItem.ToNodeItem(userTreeEntity, i);
                treeView1.Nodes.Add(node);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsersTreeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
                this.Close();

        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                contextMenuStrip.Tag = e.Node;
                contextMenuStrip.Show(Cursor.Position.X - contextMenuStrip.Width, Cursor.Position.Y);

            }
        }

        private void mnuAddUser_Click(object sender, EventArgs e)
        {
            TreeNode parentNode = (TreeNode)contextMenuStrip.Tag;
            NodeItem parentNodeItem = (NodeItem)parentNode.Tag;
            //show user List
            UserList list = new UserList();
            string childs = _userTreeBL.getAllChildsIds(parentNodeItem.Id);
            list.UnselectIds = parentNodeItem.UserPath.Replace("/", ",") + (childs.Length > 0? "," + childs : "");
            list.initList();
            list.ShowAdminUsers = false;
            list.ShowDialog();
            //prepare to create node and save it to database and also show in tree
            string name = list.UserName;
            int userid = list.Id;
            if (userid > 0) // if any user selected
            {
                //بررسی تکراری وارد نکردن کاربر
                if (("/" + parentNodeItem.UserPath + "/").IndexOf("/" + userid + "/") >= 0)
                {
                    MessageBox.Show("کاربری که اضافه می کنید در سطوح بالاتر وجود دارد، امکان اضافه کردن کاربر تکراری وجود ندارد");
                    return;
                }
                //create entity
                UserTreeEntity userTreeEntity = new UserTreeEntity();
                DataRow dr = userTreeEntity.Tables[userTreeEntity.TableName].NewRow();
                dr[UserTreeEntity.FIELD_USER_ID] = userid;
                dr[UserTreeEntity.FIELD_PARENT_ID] = parentNodeItem.Id;
                dr[UserTreeEntity.FIELD_USER_PATH] = parentNodeItem.UserPath+ "/" + userid;
                
                //add entity to database
                userTreeEntity.Tables[userTreeEntity.TableName].Rows.Add(dr);
                int newid = _userTreeBL.add(userTreeEntity);

                dr[UserTreeEntity.FIELD_ID] = newid;
                userTreeEntity.FilledTableName = userTreeEntity.TableName;
                
                //create node and add it to Tree
                UsersEntity entity = _usersBS.get(userid);
                TreeNode node = new TreeNode(entity.ToString());
                
                node.Tag = NodeItem.ToNodeItem(userTreeEntity);
                parentNode.Nodes.Add(node);
                parentNode.Expand();
            }

            
        }

        private void mnuDeleteUser_Click(object sender, EventArgs e)
        {
            TreeNode parentNode = (TreeNode)contextMenuStrip.Tag;
            NodeItem parentNodeItem = (NodeItem)parentNode.Tag;
            
            UserTreeEntity userTreeEntity = _userTreeBL.getByParent(parentNodeItem.Id);
            if (userTreeEntity.RowCount() > 0)
            {
                MessageBox.Show("برای حذف یک نود کاربر باید ابتدا تمامی کاربران زیرین را حذف نمایید!");
                return;
            }
            else
            {
                DeleteUserForm form = new DeleteUserForm();
                form.UserTreeId = parentNodeItem.Id;
                form.loadForm();
                form.ShowDialog();
                if (form.IsUserTreeNodeDeleted)
                {
                    parentNode.Remove();
                }
            }
        }

        private void mnuRefferTOAnotherUser_Click(object sender, EventArgs e)
        {
            TreeNode parentNode = (TreeNode)contextMenuStrip.Tag;
            NodeItem parentNodeItem = (NodeItem)parentNode.Tag;

            RefferToAnotherUserForm form = new RefferToAnotherUserForm();
            form.UserTreeId = parentNodeItem.Id;
            form.loadForm();
            form.ShowDialog();
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }
    }

    public class NodeItem
    {
        public NodeItem()
        {

        }

        public NodeItem(int id, int userId, int parentId, string userPath)
        {
            this.Id = id;
            this.UserId = userId;
            this.ParentId = parentId;
            this.UserPath = UserPath;
        }
        public static NodeItem ToNodeItem(UserTreeEntity entity)
        {
            return ToNodeItem(entity, 0);
        }

        public static NodeItem ToNodeItem(UserTreeEntity entity, int index)
        {
            NodeItem item = new NodeItem();
            item.Id = int.Parse(entity.get(index, UserTreeEntity.FIELD_ID).ToString());
            item.UserId = int.Parse(entity.get(index, UserTreeEntity.FIELD_USER_ID).ToString());

            if (entity.get(index, UserTreeEntity.FIELD_PARENT_ID).ToString().Length > 0)
                item.ParentId = int.Parse(entity.get(index, UserTreeEntity.FIELD_PARENT_ID).ToString());
            item.UserPath= entity.get(index, UserTreeEntity.FIELD_USER_PATH).ToString();
            return item;
        }
        #region properties 
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        private int _parentId;

        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }
        private string _userPath;

        public string UserPath
        {
            get { return _userPath; }
            set { _userPath = value; }
        }

        #endregion
    }
}
