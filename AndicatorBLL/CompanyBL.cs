using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using System.Windows.Forms;
using RMX_TOOLS.hasti.tools;

namespace AndicatorBLL
{
    public class CompanyBL : RMX_TOOLS.BLL.AbstractBL
    {
        public CompanyBL()
        {
            _abstractDA = new CompanyDA(); 
        }

        public CompanyEntity get()
        {
            return ((CompanyDA)_abstractDA).get();
        }
        
        public CompanyEntity get(int id)
        {
            return ((CompanyDA)_abstractDA).get(id);
        }

        public CompanyEntity getOnlyActives(string cond)
        {
            return ((CompanyDA)_abstractDA).getOnlyActives(cond);
        }


        public CompanyEntity get(string cond)
        {
            return ((CompanyDA)_abstractDA).get(cond);
        }

        public int add(CompanyEntity entity)
        {
            return ((CompanyDA)_abstractDA).add(entity);
        }

        public int update(CompanyEntity entity)
        {
            return ((CompanyDA)_abstractDA).update(entity);
        }

        public int delete(int id)
        {
            return ((CompanyDA)_abstractDA).delete(id);
        }

        public static string getCompanyName(int id)
        {
            CompanyDA cda = new CompanyDA();
            return cda.getCompanyName(id);
        }
        /*
        public static void fillComboBox(ComboBox cmb, int defaultItem) 
        {
            cmb.DataSource = null;
            cmb.Items.Clear();
            CompanyBL bl = new CompanyBL();
            
            CompanyEntity entity = bl.get();
            var dataSource = new List<ComboBoxItem>();

            BasicInfoUtil.AddUnKnown(dataSource);

            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                string id = entity.Tables[entity.FilledTableName].Rows[i][CompanyEntity.FIELD_ID].ToString();
                string desc = entity.Tables[entity.FilledTableName].Rows[i][CompanyEntity.FIELD_COMPANY_NAME].ToString();

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
        */

    }
}
