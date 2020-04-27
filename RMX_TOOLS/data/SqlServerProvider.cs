using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RMX_TOOLS.common;
using System.Collections;

namespace RMX_TOOLS.data 
{
    public class SqlServerProvider : IDataProvider
    {
        public SqlServerProvider()
        {
             
        } 
           
        private Boolean setPrimitiveData()
        {
            DataSet entity = new DataSet();
            try
            {
                entity.ReadXmlSchema(fileName);
                entity.ReadXml(fileName);
                serverName = entity.Tables[0].Rows[0][0].ToString();
                userName = entity.Tables[0].Rows[0][1].ToString();
                password = entity.Tables[0].Rows[0][2].ToString();
                databaseName = entity.Tables[0].Rows[0][3].ToString();
        }
        catch (Exception e)
        {
            connectionStatus = false;
            return false;

        }
        return true;
      }

        public override Boolean  connect()
        {
            try {
                if (!setPrimitiveData())
                    return false;
                //string str = "Data Source=anishtain;Initial Catalog=insurance;User ID=sa;Password=;";
                string str = "Data Source=" + serverName +
                    ";User ID=" + userName + ";Password=" + password + ";Initial Catalog=" + databaseName + ";";
                dbCon = new SqlConnection(str);

                dbCon.Open();
                sqlda = new SqlDataAdapter();
                sqlda.TableMappings.Add("Table", "insurancetype");
                connectionStatus = true;
                connectionString = str;
            }catch(Exception e)
            {
                connectionStatus = false;
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public override void close()
        {

        }

        public override void loadToDataSet(AbstractCommonData entity )
        {
            loadToDataSet(entity, "", "");
        }

        public override void loadToDataSet(AbstractCommonData entity, string condition)
        {
            loadToDataSet(entity, condition, "");
        }

        public override void loadToDataSet(AbstractCommonData entity, string condition, string orderby)
        {
            loadToDataSet(entity, condition, orderby, "");
        }

        public override void loadToDataSet(AbstractCommonData entity, string condition, string orderby, string filledTableName)
        {
            string query = "";
            if (filledTableName != null && filledTableName.Length > 0)
                entity.FilledTableName = filledTableName;
            else
                entity.FilledTableName = entity.VIEW_QUALIFIRE + entity.TableName;

            if (condition != null && condition.Length > 0)
                query = "SELECT * FROM " + entity.FilledTableName + " WHERE " + condition;
            else
                query = "SELECT * FROM " + entity.FilledTableName;
            if (orderby != null && orderby.Length > 0)
                query += " ORDER BY " + orderby;
            SqlCommand cmd = new SqlCommand(query, dbCon);
            if (sqlda != null)
            {
                sqlda.SelectCommand = cmd;
                sqlda.SelectCommand.CommandTimeout = 20 * 60; 
                sqlda.Fill(entity, entity.FilledTableName);
                fillRadif(entity);
            }
        }

        /*
         * ردیف اضافه می کنیم
         * 
         */
        private void fillRadif(AbstractCommonData entity)
        {
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                entity.Tables[entity.FilledTableName].Rows[i][AbstractCommonData.FIELD_RADIF] = i + 1;

            }
        }

        public override void executeSelect(string query,AbstractCommonData entity)
        {
            SqlCommand cmd = new SqlCommand(query, dbCon);
            sqlda.SelectCommand = cmd;
            sqlda.SelectCommand.CommandTimeout = 20 * 60;
            sqlda.Fill(entity, entity.TableName);
            entity.FilledTableName = entity.TableName;
            fillRadif(entity);

        }

        public override void executeSelect(string query, AbstractCommonData entity, string filledTableName)
        {
            SqlCommand cmd = new SqlCommand(query, dbCon);
            sqlda.SelectCommand = cmd;
            sqlda.SelectCommand.CommandTimeout = 20 * 60;
            sqlda.Fill(entity, filledTableName);
            entity.FilledTableName = filledTableName;
            fillRadif(entity);
        }

        public override DataSet executeSelect(string query)
        {
            SqlCommand cmd = new SqlCommand(query, dbCon);
            sqlda.SelectCommand = cmd;
            sqlda.SelectCommand.CommandTimeout = 20 * 60;
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            return ds;

        }  
        public override int add(AbstractCommonData entity)
        {
           // sqlda.
            SqlCommand cmd = new SqlCommand(entity.insertCommand, dbCon);
             
            sqlda.InsertCommand = cmd;
            sqlda.SelectCommand.CommandTimeout = 20 * 60;
            SqlParameterCollection sqlParams = cmd.Parameters;
            for (int i = 0; i < entity.Tables[entity.TableName].Columns.Count; i++)
            {


                string p = entity.Tables[entity.TableName].Columns[i].Caption;
                System.Type type = entity.Tables[entity.TableName].Columns[i].GetType();
                object value = entity.Tables[entity.TableName].Rows[0][p];
                if (value != null)
                {
                    sqlParams.Add(new SqlParameter("@" + p, type));
                    sqlParams["@" + p].Value = value;
                }
            }
            cmd.ExecuteScalar();

            return getNewId();
        }

        private int getNewId()
        {
            AbstractCommonData entity = new AbstractCommonData();
            string sql = "SELECT NEWID = @@IDENTITY";
            sqlda.SelectCommand = new SqlCommand(sql, dbCon);
            sqlda.SelectCommand.CommandTimeout = 20 * 60;
            sqlda.Fill(entity);
            int id = int.Parse(entity.Tables[0].Rows[0][0].ToString());
            return id;
        }

        public override int executeNonQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, dbCon);
            return cmd.ExecuteNonQuery();
                        
        }

        public override int update(AbstractCommonData entity)
        {
            
            SqlCommand cmd = new SqlCommand(entity.updatecmdWithIndexedWhereCluse, dbCon);
            sqlda.InsertCommand = cmd;
            sqlda.SelectCommand.CommandTimeout = 20 * 60;
            try
            {
                entity.Tables[entity.FilledTableName].Columns.Remove("RADIF");
            }
            catch (Exception ex) { }

            SqlParameterCollection sqlParams = cmd.Parameters;
            if (entity.FilledTableName == "")
                entity.FilledTableName = entity.TableName;
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Columns.Count; i++)
            {
                string p = entity.Tables[entity.FilledTableName].Columns[i].Caption;
                System.Type type = entity.Tables[entity.FilledTableName].Columns[i].GetType();
                object value = entity.Tables[entity.FilledTableName].Rows[0][p];
                if (value != null   )
                {
                    sqlParams.Add(new SqlParameter("@" + p, type));
                    sqlParams["@" + p].Value = value;
                }
            }
             
            return cmd.ExecuteNonQuery(); 
            //cmd.Parameters.Add(
            //return sqlda.Update(dataSet);
            
        }

        public override int delete(AbstractCommonData entity)
        {
            SqlCommand cmd = new SqlCommand(entity.deleteCmdWithIndexedWhereCluse, dbCon);

            sqlda.DeleteCommand = cmd;
            sqlda.SelectCommand.CommandTimeout = 20 * 60;
            SqlParameterCollection sqlParams = cmd.Parameters;
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Columns.Count; i++)
            {
                string p = entity.Tables[entity.FilledTableName].Columns[i].Caption;
                System.Type type = entity.Tables[entity.FilledTableName].Columns[i].GetType();
                object value = entity.Tables[entity.FilledTableName].Rows[0][p];
                if (value != null)
                {
                    sqlParams.Add(new SqlParameter("@" + p, type));
                    sqlParams["@" + p].Value = value;
                }
            }
            cmd.ExecuteNonQuery();
            sqlda.Update(entity);
            return 0;
            
        }

        public override int delete(string query)
        {
            int n =1;//   if n become zero so we couldn't delete any records
            try
            {
                SqlCommand cmd = new SqlCommand(query, dbCon);
                 n = cmd.ExecuteNonQuery();
            }
            catch (SqlException es)
            {
                n = 0;
            }
            return n;
        }

        public int runExec(string query){
            SqlCommand cmd = new SqlCommand(query,dbCon);
            int i = cmd.ExecuteNonQuery();
            return i;
        }

        public int RunStoredProcedure(string procedureName)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(procedureName, dbCon);
                sqlda.SelectCommand.CommandTimeout = 20 * 60;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // do nothing 
            }
            return i;
        }

        public int RunStoredProcedure(string procedureName, ArrayList paramList)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(procedureName, dbCon);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.CommandTimeout = 20 * 60;
               
                for(int j = 0; j < paramList.Count; j++)
                    cmd.Parameters.Add((SqlParameter)paramList[j]);
                
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // do nothing 
            }
            return i;
        }

        public override void select(AbstractCommonData entity, string cond)
        {
            entity.FilledTableName = entity.VIEW_QUALIFIRE + entity.TableName;
            string query = "SELECT * FROM " + entity.FilledTableName;
            
            if (cond != null && cond.Trim().Length > 0)
                query += " WHERE " + cond;
 
            SqlCommand cmd = new SqlCommand(query, dbCon);
            sqlda.SelectCommand = cmd;
            sqlda.SelectCommand.CommandTimeout = 20 * 60;
            sqlda.Fill(entity, entity.FilledTableName);
        }

        public override string getAsSqlDate(string fld, DateTime date)
        {
            DateTime date2 = date.Date;
            return getBetweenDate(fld, date, date, null);
        }
        
        public override string getBetweenDate(string fld, DateTime betw1, DateTime betw2, string daysBeforExp)
        {
            string d1 = betw1.Year + "-" + betw1.Month + "-" + betw1.Day + " " + RMX_TOOLS.date.DateConstants.BEGIN_OF_DAY;
            string d2 = betw2.Year + "-" + betw2.Month + "-" + betw2.Day + " " + RMX_TOOLS.date.DateConstants.END_OF_DAY;
            string result;

            result = fld + " between CAST('" + d1 + "' AS DATETime) and ";
            if (daysBeforExp != null)
                result += " cast('" + d2 + "' AS DATETime) + daysBeforExp";
            else
                result += "cast('" + d2 + "' AS DATETime)";
            return result;
        }

        public override string getSQLString(object value)
        {
            if (value == null)
                return "";
            if (value is bool || value is Boolean)
                return ((Boolean)value==true ? "1" : "0");
            if(value is int)
                return value.ToString();

            return "'" + value.ToString() + "'";
        }
    }
}
