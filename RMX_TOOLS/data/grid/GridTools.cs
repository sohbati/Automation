using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using RMX_TOOLS.common;
using RMX_TOOLS.hasti.tools;

namespace RMX_TOOLS.data.grid
{
  
    

    public class GridTools
    {
        public delegate void changingRow(DataGridView grid, int rowIndex, Hashtable hash);

        public GridTools() 
        {
        }

        public object getValueByRowIndex(DataGridView grid,int rowIndex, string col)
        {
            DataGridViewRow row = grid.Rows[rowIndex];
            return row.Cells[col].Value;
        }

        public object getCurrentRowValue(DataGridView grid, string col)
        {
            if (grid.CurrentRow != null)
            {
                DataGridViewRow row = grid.CurrentRow;
                return row.Cells[col].Value;
            }
            return null;
        }

        public void setValue(DataGridView grid, Control control, string fieldName)
        {
            object obj = getCurrentRowValue(grid, fieldName);
            if (obj != null)
                control.Text = obj.ToString().Trim();
        }

        public void setValue(DataGridView grid, ComboBox cmb, string fieldName) 
        { 
            setValue(grid, cmb, fieldName, "index");
        }
        
        public void setComboBoxItemValue(DataGridView grid, ComboBox cmb, string fieldName)
        {
            object value = getCurrentRowValue(grid, fieldName);
            cmb.SelectedIndex = -1;
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                if (value != null && ((ComboBoxItem)cmb.Items[i]).Value.Equals(value.ToString()))
                {
                    cmb.SelectedIndex = i;
                    break;
                }
            }
           
        }
        
        public void setValue(DataGridView grid, ComboBox cmb, string fieldName, string type)
        {
            object obj = getCurrentRowValue(grid, fieldName);
            if (type.Equals("index")) 
            {
                if (obj != null)
                    cmb.SelectedIndex = (int.Parse(obj.ToString().Trim()) -1);

            }else if (type.Equals("text"))
            {
                if (obj != null)
                    cmb.Text = obj.ToString().Trim();
            }

        }

        public void bindDataToGrid(DataGridView grid , AbstractCommonData entity , changingRow chageRow, Hashtable hash)
        {
             grid.Rows.Clear();
            
           int columns = grid.ColumnCount;
           DataTable table = entity.Tables[entity.FilledTableName];
            if (table ==  null)
                throw new Exception("نا م جدول در دیتا ست یافت نشد");
            
            string field;
            string colName = "";
            object value= "";
            
            int currentRowIndex;
            for (int tableIndex = 0; tableIndex < table.Rows.Count; tableIndex++) 
            {
                currentRowIndex = grid.Rows.Add();
                for (int gridIndex = 0; gridIndex < grid.Columns.Count; gridIndex++) 
                {
                    field = grid.Columns[gridIndex].DataPropertyName;
                    if (field != null && field.Length > 0)
                    {
                        colName = grid.Columns[gridIndex].Name;
                        try
                        {
                            value = getAsString(table.Rows[tableIndex][field]);
                        }
                        catch (Exception ex)
                        {
                            value = "";
                        }
                        //cell = new DataGridViewCell();
                        //cell.Value = value;
                        if (colName.Equals("USERTYPE"))
                        {
                            if (grid.Rows[currentRowIndex].Cells[colName] is DataGridViewComboBoxCell)
                            {
                                ((DataGridViewComboBoxCell)grid.Rows[currentRowIndex].Cells[colName]).Value = value;
                            }
                        }else 
                            grid.Rows[currentRowIndex].Cells[colName].Value = value;
                    }
                }
                if (chageRow != null)
                    chageRow(grid, currentRowIndex, hash);
            }
        }

        private object getAsString(object obj)
        {
            if (obj is DateTime)
               return RMX_TOOLS.date.DateXFormer.gregorianToPersianString((DateTime)obj).Trim();
            else
               return obj;
        }
        public void changeColor(DataGridView grid, int rowIndex, Hashtable hash)
        {
            if (hash["colorField"] != null)
            {
                string colorField = hash["colorField"].ToString();

                Color defColor = Color.White;
                Color color = Color.White; ;

                string colorStr = null;
                //  grid.currentrow = rowIndex;

                colorStr = getValueByRowIndex(grid, rowIndex, colorField).ToString().Trim();

                if (colorStr == null || colorStr.Length <= 0)
                    color = defColor;
                else
                    color = ColorTranslator.FromHtml(colorStr);

                for (int i = 0; i < grid.Rows[rowIndex].Cells.Count; i++)
                    grid.Rows[rowIndex].Cells[i].Style.BackColor = color;
            }
        }

        public void selectRow(DataGridView grid, string indexFieldName, int indexFieldValue)
        {
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                int d = int.Parse(grid.Rows[i].Cells[indexFieldName].Value.ToString());
                if (d == indexFieldValue)
                {
                    for (int j = 0; j < grid.Rows[i].Cells.Count; j++)
                    {
                        if (grid.Rows[i].Cells[j].Visible)
                        grid.CurrentCell = grid.Rows[i].Cells[j];
                        return;
                    }
                }
            }
        }
    }

    


}
