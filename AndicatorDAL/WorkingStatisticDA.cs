using System;
using System.Collections.Generic;
using System.Text;
using RMX_TOOLS.data;
using RMX_TOOLS.DAL;
using RMX_TOOLS.common;
using AndicatorCommon;
using System.Collections;
using System.Data;

namespace AndicatorDAL
{
    public class WorkingStatisticDA : AbstractDAL
    {
        public WorkingStatisticEntity get()
        {
            WorkingStatisticEntity entity = new WorkingStatisticEntity();

            provider.loadToDataSet(entity);

            WorkingStatisticEntity newEntity = new WorkingStatisticEntity();
            ArrayList blackList = new ArrayList();
            int userid = -1;
            for (int i = 0; i < entity.Tables[entity.FilledTableName].Rows.Count; i++)
            {
                userid = int.Parse(entity.get(i, WorkingStatisticEntity.VIEW_FIELD_USER_ID).ToString());
                if(blackList.Contains(userid))
                    continue;
                ArrayList useridList = new ArrayList();
                for (int j = i + 1; j < entity.Tables[entity.FilledTableName].Rows.Count; j++)
                {
                    int  secondUserid = int.Parse(entity.get(j, WorkingStatisticEntity.VIEW_FIELD_USER_ID).ToString());
                    if (secondUserid == userid)
                    {
                        blackList.Add(secondUserid);
                        useridList.Add(j);
                    }
                }
                if (useridList.Count > 0)
                {
                    useridList.Add(i);
                }
                joinSameUsers(i, entity, newEntity, useridList);
            }
            
            // remove users with no letter -- users with zero item assined to him/her
            WorkingStatisticEntity newEntity2 = new WorkingStatisticEntity();
            for (int i = 0; i < newEntity.Tables[1].Rows.Count; i++)
            {
                if (!isZero(newEntity, i))
                {
                    DataRow dr = newEntity2.Tables[1].NewRow();
                    dr[WorkingStatisticEntity.VIEW_FIELD_CHEQUE_HAS_REMAINDER] = newEntity.Tables[1].Rows[i][WorkingStatisticEntity.VIEW_FIELD_CHEQUE_HAS_REMAINDER];
                    dr[WorkingStatisticEntity.VIEW_FIELD_CHEQUE_WHITHOUT_ANS] = newEntity.Tables[1].Rows[i][ WorkingStatisticEntity.VIEW_FIELD_CHEQUE_WHITHOUT_ANS];
                    dr[WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_ALL] = newEntity.Tables[1].Rows[i][WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_ALL];
                    dr[WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_MARKED] = newEntity.Tables[1].Rows[i][ WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_MARKED];
                    dr[WorkingStatisticEntity.VIEW_FIELD_ID] = newEntity.Tables[1].Rows[i][ WorkingStatisticEntity.VIEW_FIELD_ID];
                    dr[WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ALL] = newEntity.Tables[1].Rows[i][ WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ALL];
                    dr[WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_MARKED] = newEntity.Tables[1].Rows[i][ WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_MARKED];
                    dr[WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_ALL] = newEntity.Tables[1].Rows[i][ WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_ALL];
                    dr[WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_MARKED] = newEntity.Tables[1].Rows[i][ WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_MARKED];
                    dr[WorkingStatisticEntity.VIEW_FIELD_USER_ID] = newEntity.Tables[1].Rows[i][ WorkingStatisticEntity.VIEW_FIELD_USER_ID];
                    dr[WorkingStatisticEntity.VIEW_FIELD_USERNAME] = newEntity.Tables[1].Rows[i][ WorkingStatisticEntity.VIEW_FIELD_USERNAME];
                    newEntity2.Tables[1].Rows.Add(dr);
                }
                    
            }
            return newEntity2;
        }

        private void joinSameUsers(int i, WorkingStatisticEntity entity,WorkingStatisticEntity newEntity, ArrayList useridList)
        {
            if (useridList.Count == 0)
                copyEntity(i, entity, newEntity);
            else
            {
                int newi =  copyEntity(i, entity, newEntity);
                for (int j = 0; j < useridList.Count; j++)
                {
                    if (i != (int)useridList[j])
                    {
                        newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_CHEQUE_HAS_REMAINDER] =
                            int.Parse(newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_CHEQUE_HAS_REMAINDER].ToString()) +
                            int.Parse(entity.get((int)useridList[j], WorkingStatisticEntity.VIEW_FIELD_CHEQUE_HAS_REMAINDER).ToString());

                        newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_CHEQUE_WHITHOUT_ANS] =
                            int.Parse( newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_CHEQUE_WHITHOUT_ANS].ToString()) +
                            int.Parse(entity.get((int)useridList[j], WorkingStatisticEntity.VIEW_FIELD_CHEQUE_WHITHOUT_ANS).ToString());

                        newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_ALL] =
                            int.Parse(newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_ALL].ToString())+
                            int.Parse(entity.get((int)useridList[j], WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_ALL).ToString());

                        newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_MARKED] =
                            int.Parse(newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_MARKED].ToString()) + 
                            int.Parse(entity.get((int)useridList[j], WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_MARKED).ToString());

                        newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ALL] =
                            int.Parse(newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ALL].ToString()) + 
                            int.Parse(entity.get((int)useridList[j], WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ALL).ToString());

                        newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_MARKED] =
                            int.Parse(newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_MARKED].ToString()) + 
                            int.Parse(entity.get((int)useridList[j], WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_MARKED).ToString());

                        newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_ALL] =
                            int.Parse(newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_ALL].ToString()) + 
                            int.Parse(entity.get((int)useridList[j], WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_ALL).ToString());

                        newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_MARKED] =
                            int.Parse(newEntity.Tables[1].Rows[newi][WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_MARKED].ToString()) +
                            int.Parse(entity.get((int)useridList[j], WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_MARKED).ToString());
                    }
                }

            }


        }
       
        private int copyEntity(int i, WorkingStatisticEntity source, WorkingStatisticEntity dest)
        {
            DataRow dr =  dest.Tables[1].NewRow();
            dr[WorkingStatisticEntity.VIEW_FIELD_CHEQUE_HAS_REMAINDER] = source.get(i, WorkingStatisticEntity.VIEW_FIELD_CHEQUE_HAS_REMAINDER);
            dr[WorkingStatisticEntity.VIEW_FIELD_CHEQUE_WHITHOUT_ANS] = source.get(i, WorkingStatisticEntity.VIEW_FIELD_CHEQUE_WHITHOUT_ANS);
            dr[WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_ALL] = source.get(i, WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_ALL);
            dr[WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_MARKED] = source.get(i, WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_MARKED);
            dr[WorkingStatisticEntity.VIEW_FIELD_ID] = source.get(i, WorkingStatisticEntity.VIEW_FIELD_ID);
            dr[WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ALL] = source.get(i, WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ALL);
            dr[WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_MARKED] = source.get(i, WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_MARKED);
            dr[WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_ALL] = source.get(i, WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_ALL);
            dr[WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_MARKED] = source.get(i, WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_MARKED);
            dr[WorkingStatisticEntity.VIEW_FIELD_USER_ID] = source.get(i, WorkingStatisticEntity.VIEW_FIELD_USER_ID);
            dr[WorkingStatisticEntity.VIEW_FIELD_USERNAME] = source.get(i, WorkingStatisticEntity.VIEW_FIELD_USERNAME);
            dest.Tables[1].Rows.Add(dr);
            
            return dest.Tables[1].Rows.Count - 1; // new row index
        }

        private bool isZero(WorkingStatisticEntity newEntity, int index)
        {
            int s = 
             int.Parse(newEntity.Tables[1].Rows[index][WorkingStatisticEntity.VIEW_FIELD_CHEQUE_HAS_REMAINDER].ToString()) +
             int.Parse(newEntity.Tables[1].Rows[index][WorkingStatisticEntity.VIEW_FIELD_CHEQUE_WHITHOUT_ANS].ToString()) +
             int.Parse(newEntity.Tables[1].Rows[index][WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_ALL].ToString()) +
             int.Parse(newEntity.Tables[1].Rows[index][WorkingStatisticEntity.VIEW_FIELD_CUR_LETTER_MARKED].ToString()) +
             int.Parse(newEntity.Tables[1].Rows[index][WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ALL].ToString()) +
             int.Parse(newEntity.Tables[1].Rows[index][WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_MARKED].ToString()) +
             int.Parse(newEntity.Tables[1].Rows[index][WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_ALL].ToString()) +
             int.Parse(newEntity.Tables[1].Rows[index][WorkingStatisticEntity.VIEW_FIELD_RATE_DEC_ORAL_MARKED].ToString());
            return s == 0;
        }
    }
}
