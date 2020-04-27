using System;
using System.Collections.Generic;
using System.Text;
using AndicatorDAL;
using AndicatorCommon;
using RMX_TOOLS.date;
using AndicatorBLL;

namespace AndicatorBLL
{
    public class LetterNumberPatternBL : RMX_TOOLS.BLL.AbstractBL
    {
        #region constants
        public const int RESET_BY_DAY = 1;
        public const int RESET_BY_MONTH = 2;
        public const int RESET_BY_YEAR = 3;
        public const int RESET_BY_NONE = 4;
        #endregion

        public LetterNumberPatternBL()
        {
            _abstractDA = new LetterNumberPatternDA(); 
        }

        public LetterNumberPatternEntity get()
        {
            return ((LetterNumberPatternDA)_abstractDA).get();
        }

        public LetterNumberPatternEntity getById(int id)
        {
            return ((LetterNumberPatternDA)_abstractDA).getById(id);
        }

        public LetterNumberPatternEntity getOralPattern()
        {
            return ((LetterNumberPatternDA)_abstractDA).getOralPattern();
        }

        public int add(LetterNumberPatternEntity entity)
        {
            return ((LetterNumberPatternDA)_abstractDA).add(entity);
        }

        public int update(LetterNumberPatternEntity entity)
        {
            return ((LetterNumberPatternDA)_abstractDA).update(entity);
        }

        public int delete(int id)
        {
            return ((LetterNumberPatternDA)_abstractDA).delete(id);
        }
        
        public string[] GenerateOralRecieveLetterNumber()
        {
            LetterNumberPatternEntity entity = getOralPattern();
            if (entity.Tables[entity.FilledTableName].Rows.Count <= 0)
                throw new Exception("الگوی نامه شفاهی تعریف نشده است ، لطفا مسئول سیستم تماس بگیرید");

            String pattern = entity.get(LetterNumberPatternEntity.FIELD_RECIEVE_PATTERN).ToString();
            string lastNum = entity.get(LetterNumberPatternEntity.FIELD_LASTNUMBER_RECIEVE).ToString();
            DateTime registerDate = (DateTime)entity.get(LetterNumberPatternEntity.FIELD_REGISTER_DATE);
            int resetBy = (int)entity.get(LetterNumberPatternEntity.FIELD_RESETBY);

            return GenerateLetterNumber(pattern, lastNum, registerDate, resetBy);
        }

        public string[] GenerateOralSendLetterNumber()
        {
            LetterNumberPatternEntity entity = getOralPattern();
            if (entity.Tables[entity.FilledTableName].Rows.Count <= 0)
                throw new Exception("الگوی نامه شفاهی تعریف نشده است ، لطفا مسئول سیستم تماس بگیرید");

            String pattern = entity.get(LetterNumberPatternEntity.FIELD_SEND_PATTERN).ToString();
            string lastNum = entity.get(LetterNumberPatternEntity.FIELD_LASTNUMBER_SEND).ToString();
            DateTime registerDate = (DateTime)entity.get(LetterNumberPatternEntity.FIELD_REGISTER_DATE);
            int resetBy = (int)entity.get(LetterNumberPatternEntity.FIELD_RESETBY);

            return GenerateLetterNumber(pattern, lastNum, registerDate, resetBy);
        }


        public string[] GenerateNewRecieveLetterNumber()
        {
            string pId = UsersBS.loginedUser.get(UsersEntity.FIELD_LETTER_PATTERN_ID).ToString();
            if (pId == null || pId.Equals("") || pId.Length <= 0)
            {
                throw new Exception("برای این کاربر الگوی تولید شماره نامه تعیین نشده است");
            }
            LetterNumberPatternEntity entity = getById(int.Parse(pId));
            if(entity.Tables[entity.FilledTableName].Rows.Count <=0)
                throw new Exception("الگویی برای شماره نامه تعریف نشده است! \n بدون شماره نامه امکان ثبت نامه وجود ندارد");
            String pattern = entity.get(LetterNumberPatternEntity.FIELD_RECIEVE_PATTERN).ToString();
            string lastNum = entity.get(LetterNumberPatternEntity.FIELD_LASTNUMBER_RECIEVE).ToString();
            DateTime registerDate = (DateTime)entity.get(LetterNumberPatternEntity.FIELD_REGISTER_DATE);
            int resetBy = (int)entity.get(LetterNumberPatternEntity.FIELD_RESETBY);

            return GenerateLetterNumber(pattern, lastNum, registerDate, resetBy);
        }
        
        public string[] GenerateNewSendLetterNumber()
        {
            string pId = UsersBS.loginedUser.get(UsersEntity.FIELD_LETTER_PATTERN_ID).ToString();
            if (pId == null || pId.Equals("") || pId.Length <= 0)
            {
                throw new Exception("برای این کاربر الگوی تولید شماره نامه تعیین نشده است");
            }
            LetterNumberPatternEntity entity = getById(int.Parse(pId));
            if (entity.Tables[entity.FilledTableName].Rows.Count <= 0)
                throw new Exception("الگویی برای شماره نامه تعریف نشده است! \n بدون شماره نامه امکان ثبت نامه وجود ندارد");
            String pattern = entity.get(LetterNumberPatternEntity.FIELD_SEND_PATTERN).ToString();
            string lastNum = entity.get(LetterNumberPatternEntity.FIELD_LASTNUMBER_SEND).ToString();
            DateTime registerDate = (DateTime)entity.get(LetterNumberPatternEntity.FIELD_REGISTER_DATE);
            int resetBy = (int)entity.get(LetterNumberPatternEntity.FIELD_RESETBY);
            
            return GenerateLetterNumber(pattern, lastNum, registerDate, resetBy);
        }

        private string[] GenerateLetterNumber(string pattern, string lastNumber, DateTime registerDate, int resetBy)
        {
            string date = DateXFormer.gregorianToPersianString(DateTime.Now);

            string[] output = new string[2];
            for (int i = 0; i < pattern.Length; i++)
            {
                if ("Y".Equals(pattern[i].ToString()))
                    output[0] += getYear(pattern, ref i, date);
                else if ("M".Equals(pattern[i].ToString()))
                    output[0] += getMonth(pattern, ref i, date);
                else if ("D".Equals(pattern[i].ToString()))
                    output[0] += getDay(pattern, ref i, date);
                else if ("#".Equals(pattern[i].ToString()))
                {
                    lastNumber = takeEffectOfResetBy(lastNumber, resetBy, registerDate);
                    int c = getNumCount(pattern, i);
                    i += (c - 1);
                    output[1] = getNextNumber(lastNumber, c);
                    output[0] += output[1];
                }
                else
                {
                    output[0] += pattern[i];
                }
            }
            return output;
        }
        
        private string[] GenerateLetterNumberDep(string pattern, string lastNumber, DateTime registerDate, int resetBy)
        {
            string date = DateXFormer.gregorianToPersianString(DateTime.Now);
            
            string[] output = new string[2];
            for (int i = 0; i < pattern.Length; i++)
            {
                if ("Y".Equals(pattern[i].ToString()))
                    output[0] += getYear(pattern, ref i, date);
                else if ("M".Equals(pattern[i].ToString()))
                    output[0] += getMonth(pattern, ref i, date);
                else if ("D".Equals(pattern[i].ToString()))
                    output[0] += getDay(pattern, ref i, date);
                else if ("#".Equals(pattern[i].ToString()))
                {
                    lastNumber = takeEffectOfResetBy(lastNumber, resetBy, registerDate);
                    int c = getNumCount(pattern, i);
                    i += (c - 1);
                    output[1] =  getNextNumber(lastNumber, c);
                    output[0] += output[1];
                }
                else
                {
                    output[0] += pattern[i];
                }
            }
            return output;
        }

        private string takeEffectOfResetBy(string lastNumber, int resetBy, DateTime registerDate)
        {
            if (resetBy == RESET_BY_NONE)
                return lastNumber;
            bool reset = false;
            if (resetBy == RESET_BY_DAY && dateToDay(DateTime.Now) > dateToDay(registerDate))
                reset = true;
            //else if (resetBy == RESET_BY_MONTH && dateToDayOnlyYearAndMonth(DateTime.Now) > dateToDayOnlyYearAndMonth(registerDate))
            else if (resetBy == RESET_BY_MONTH && isMonthChanged(registerDate))
                reset = true;
            else if (resetBy == RESET_BY_YEAR && DateTime.Now.Year > registerDate.Year)
                reset = true;
            
            return reset ? "0" : lastNumber;
        }

        private string getYear(string pattern,ref int i, string shamsidate)
        {
            string year = DateXFormer.getShamsiYear(shamsidate);
            int count = getRepeatCount(pattern, "Y");
            i += (count==0 ?  0 : count -1);
            switch (count)
            {
              case 0 : return "";
              case 1: return year.Substring(year.Length - 1, 1);
              case 2: return year.Substring(year.Length - 2, 2);
              case 3: return year.Substring(year.Length - 3, 3);
              case 4: return year;
              case 5: throw new Exception("خطا در تعداد ارقام سال تعیین شده ، لطفا با برنامه نویس تماس بگیرید");
            }
            return "";
        }
        
        private string getMonth(string pattern,ref int i, string shamsidate)
        {
            string month = DateXFormer.getShamsiMonth(shamsidate);
            int count = getRepeatCount(pattern, "M");
            i += (count == 0 ? 0 : count - 1);
            switch (count)
            {
                case 0: return "";
                case 1: return month;
                case 2: return month;
                case 3: throw new Exception("خطا در تعداد ارقام ماه تعیین شده ، لطفا با برنامه نویس تماس بگیرید");
            }
            return "";
        }
        
        private string getDay(string pattern,ref int i, string shamsidate)
        {
            string day = DateXFormer.getShamsiDay(shamsidate);
            int count = getRepeatCount(pattern, "D");
            i += (count == 0 ? 0 : count - 1);

            switch (count)
            {
                case 0: return "";
                case 1: return day;
                case 2: return day;
                case 3: throw new Exception("خطا در تعداد ارقام روز تعیین شده ، لطفا با برنامه نویس تماس بگیرید");
            }
            return "";
        }

        private int getRepeatCount(string s, string letter)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].ToString().ToUpper().Equals(letter))
                    count++;
            }
            return count;
        }
        private string getNextNumber(string lastNum, int count)
        
        {
            string o = "";
            if (lastNum == null || lastNum.Equals("") || lastNum.Length <= 0)
                lastNum = "0";
            int n = int.Parse(lastNum);
            n++;
            o = n.ToString();
            int oLength = o.Length;
            for (int i = 0; i < (count - oLength); i++)
                o = "0" + o;
            return o;
        }

        private int getNumCount(string pattern, int index) 
        {
            int c = 0;
            for (int i = index; i < pattern.Length; i++)
            {
                if ("#".Equals(pattern[i].ToString()))
                    c++;
                else
                    break;
            }
            return c;
        }

        private int dateToDay(DateTime dt)
        {
            return dt.Year * (DateTime.IsLeapYear(dt.Year) ? 366 : 365) + getInDaysOfStartOfYear(dt.Year, dt.Month - 1) + dt.Day;
        }
        
        private int dateToDayOnlyYearAndMonth(DateTime dt)
        {
            return dt.Year * (DateTime.IsLeapYear(dt.Year) ? 366 : 365) + getInDaysOfStartOfYear(dt.Year, dt.Month - 1);
        }

        private int getInDaysOfStartOfYear(int year, int month)
        {
            int sum = 0;
            for (int i = 1; i < month; i++)
                sum += DateTime.DaysInMonth(year, i);
            return sum;
        }

        private bool isMonthChanged(DateTime dt)
        {
            string date = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(dt);
            string m1 = RMX_TOOLS.date.DateXFormer.getShamsiMonth(date);
            string y1 = RMX_TOOLS.date.DateXFormer.getShamsiYear(date);
            int m1_i = int.Parse(m1);
            
            date = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.Now);
            string m2 = RMX_TOOLS.date.DateXFormer.getShamsiMonth(date);
            string y2 = RMX_TOOLS.date.DateXFormer.getShamsiYear(date);
            int m2_i = int.Parse(m2);
            
            return m1_i != m2_i;
        }
    }
}
