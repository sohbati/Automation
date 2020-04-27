using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RMX_TOOLS.hasti.bll;
using RMX_TOOLS.hasti.entity;

namespace RMX_TOOLS.hasti.tools
{

    public class ComboBoxItem
    {
        public ComboBoxItem() { }

        public ComboBoxItem(string text, string value)
        {
            Text = text;
            Value = value;
        }
        
        public ComboBoxItem(string text, string value, string customData)
        {
            Text = text;
            Value = value;
            CustomData = customData;
        }

        public override string ToString()
        {
            return Text;
        }

        public string Text { get; set; }
        public string Value { get; set; }
        public string CustomData { get; set; }
    }

    public static class BasicInfoUtil
    {
        private static BasicInfoBL _basicInfoBL = new BasicInfoBL();

        public static void fillComboBox(ComboBox cmb, string englishName, int defaultItemId)
        {
            BasicInfoEntity entity = _basicInfoBL.getByEnglishName(englishName);
            fillComboBox(cmb, int.Parse(entity.get(BasicInfoEntity.FIELD_ID).ToString()), defaultItemId);
             
        }
        
        public static void fillCheckBoxList(CheckedListBox cmb, string englishName, int defaultItemId)
        {
            BasicInfoEntity entity = _basicInfoBL.getByEnglishName(englishName);
            fillCheckBoxList(cmb, int.Parse(entity.get(BasicInfoEntity.FIELD_ID).ToString()), defaultItemId);

        }

        public static int getId(string englishName)
        {
            BasicInfoEntity entity = _basicInfoBL.getByEnglishName(englishName);
            return int.Parse(entity.Tables[entity.FilledTableName].Rows[0][BasicInfoEntity.FIELD_ID].ToString());
        }
        public static string getCustomData(int id)
        {
            return _basicInfoBL.getCustomData(id);
        }

        public static string getCustomData(string engName)
        {
            return _basicInfoBL.getCustomData(engName);
        }

        public static void fillComboBox(ComboBox cmb, int parentId, int defaultItemId)
        {

            BasicInfoEntity parentEntity = _basicInfoBL.get(parentId);
            Boolean containsUnknown = false;
            string c = parentEntity.get(BasicInfoEntity.FIELD_CONTAINUNKNOWN).ToString();
            if ( c != null && c.Trim().Length > 0)
                containsUnknown = Boolean.Parse(c);

            BasicInfoEntity entity = _basicInfoBL.getByParentId(parentId);
            var dataSource = new List<ComboBoxItem>();
            try
            {
                cmb.Items.Clear();
            }
            catch (Exception ex) { }
            if (containsUnknown == true)
                AddUnKnown(dataSource);
   
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                string id = entity.Tables[entity.FilledTableName].Rows[i][BasicInfoEntity.FIELD_ID].ToString();
                string desc = entity.Tables[entity.FilledTableName].Rows[i][BasicInfoEntity.FIELD_DESCRIPTION].ToString();
                string customData = "";
                if(entity.Tables[entity.FilledTableName].Rows[i][BasicInfoEntity.FIELD_CUSTOMFIELD] != null)
                   customData = entity.Tables[entity.FilledTableName].Rows[i][BasicInfoEntity.FIELD_CUSTOMFIELD].ToString();
                
                dataSource.Add(new ComboBoxItem(desc, id, customData));
            }

            // is inActive? or not
            BasicInfoEntity niEntity = _basicInfoBL.get(defaultItemId);
            if (niEntity.Tables[niEntity.FilledTableName].Rows.Count > 0)
            {
                bool isActive = bool.Parse(niEntity.Tables[niEntity.FilledTableName].Rows[0][BasicInfoEntity.FIELD_ACTIVE].ToString()); ;
                if (isActive == false)
                {
                    string id = niEntity.Tables[niEntity.FilledTableName].Rows[0][BasicInfoEntity.FIELD_ID].ToString();
                    string desc = niEntity.Tables[niEntity.FilledTableName].Rows[0][BasicInfoEntity.FIELD_DESCRIPTION].ToString();
                    string customData = "";
                    if (niEntity.Tables[niEntity.FilledTableName].Rows[0][BasicInfoEntity.FIELD_CUSTOMFIELD] != null)
                        customData = niEntity.Tables[entity.FilledTableName].Rows[0][BasicInfoEntity.FIELD_CUSTOMFIELD].ToString();

                    dataSource.Add(new ComboBoxItem(desc, id, customData));
                }

            }
            cmb.DataSource = dataSource;
            cmb.DisplayMember = "Text";
            cmb.ValueMember = "Value";

            for (int i = 0; i < cmb.Items.Count; i++)
            {
                if (((ComboBoxItem)cmb.Items[i]).Value.Equals(defaultItemId.ToString()))
                {
                    cmb.SelectedIndex = i;
                    break;
                }
            }
        }
        
        public static void fillCheckBoxList(CheckedListBox cmb, int parentId, int defaultItemId)
        {

            BasicInfoEntity parentEntity = _basicInfoBL.get(parentId);
            Boolean containsUnknown = false;
            string c = parentEntity.get(BasicInfoEntity.FIELD_CONTAINUNKNOWN).ToString();
            if (c != null && c.Trim().Length > 0)
                containsUnknown = Boolean.Parse(c);

            BasicInfoEntity entity = _basicInfoBL.getByParentId(parentId);
            var dataSource = new List<ComboBoxItem>();
            try
            {
                cmb.Items.Clear();
            }
            catch (Exception ex) { }
            if (containsUnknown == true)
                AddUnKnown(dataSource);

            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                string id = entity.Tables[entity.FilledTableName].Rows[i][BasicInfoEntity.FIELD_ID].ToString();
                string desc = entity.Tables[entity.FilledTableName].Rows[i][BasicInfoEntity.FIELD_DESCRIPTION].ToString();
                string customData = "";
                if (entity.Tables[entity.FilledTableName].Rows[i][BasicInfoEntity.FIELD_CUSTOMFIELD] != null)
                    customData = entity.Tables[entity.FilledTableName].Rows[i][BasicInfoEntity.FIELD_CUSTOMFIELD].ToString();

                dataSource.Add(new ComboBoxItem(desc, id, customData));
            }


            // is inActive? or not
            BasicInfoEntity niEntity = _basicInfoBL.get(defaultItemId);
            if (niEntity.Tables[niEntity.FilledTableName].Rows.Count > 0)
            {
                bool isActive = bool.Parse(niEntity.Tables[niEntity.FilledTableName].Rows[0][BasicInfoEntity.FIELD_ACTIVE].ToString()); ;
                if (isActive == false)
                {
                    string id = niEntity.Tables[niEntity.FilledTableName].Rows[0][BasicInfoEntity.FIELD_ID].ToString();
                    string desc = niEntity.Tables[niEntity.FilledTableName].Rows[0][BasicInfoEntity.FIELD_DESCRIPTION].ToString();
                    string customData = "";
                    if (niEntity.Tables[niEntity.FilledTableName].Rows[0][BasicInfoEntity.FIELD_CUSTOMFIELD] != null)
                        customData = niEntity.Tables[entity.FilledTableName].Rows[0][BasicInfoEntity.FIELD_CUSTOMFIELD].ToString();

                    dataSource.Add(new ComboBoxItem(desc, id, customData));
                }
                    
            }
            cmb.DataSource = dataSource;
            cmb.DisplayMember = "Text";
            cmb.ValueMember = "Value";

            for (int i = 0; i < cmb.Items.Count; i++)
            {
                if (((ComboBoxItem)cmb.Items[i]).Value.Equals(defaultItemId.ToString()))
                {
                    cmb.SelectedIndex = i;
                    break;
                }
            }

        }

        public static void AddUnKnown( List<ComboBoxItem> list)
        {
            string desc = "نامشخص";
            string id = "-1";
            list.Add(new ComboBoxItem(desc, id));
        }
    }
}
