using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace RMX_TOOLS.date
{

    public partial class DatePicker : Form
    {
        PersianCalendar _persianCalendar;
        GregorianCalendar _gregorianCalendar;
        Color fgColor = Color.Blue;
        Color BkColor = Color.LimeGreen;
        Color SelectedFgColor = Color.White;
        Color SelectedBkColor = Color.Blue;
        private string[] _title = {"ش","ی","د","س","چ","پ","ج" };
        private static int[] YEAR_BOUNDARY= {1380,1400 };
        private int[] _persian_monthes ={31,31,31,31,31,31,
                                       30,30,30,30,30,29};
        private int[] _gregorian_monthes ={30,29,31,30,31,30,
                                           31,31,30,31,30,31};
        public int _selectedMonth;
        public int _selectedDay;
        public int _selectedYear;
        public Boolean _selected = false;
        public DateTime today;

        public DatePicker()
        {
            InitializeComponent();
        }

        public void showDialog(string strDate)
        {
            int y = 0;
            int m = 0;
            int d = 0;
            if (CheckDate.checkDate(strDate, ref y, ref m, ref d))
            {
                init(y, m, d);
            }
            else
                init(0, 0, 0);
            this.ShowDialog();
        }

        private void DaePicker_Load(object sender, EventArgs e)
        {  
        }

        public void init(int y, int m,int d)
        {
            _selected = false;
            _persianCalendar = new PersianCalendar();
            _gregorianCalendar = new GregorianCalendar();
            cmbYear.Items.Clear();

            for (int i = YEAR_BOUNDARY[0]; i <= YEAR_BOUNDARY[1]; i++)
                cmbYear.Items.Add(i);
            cmbMonth.Items.Clear();
            for (int i = 1; i <= 12; i++)
                cmbMonth.Items.Add(i);

            //set persian day to today
            if (CheckDate.checkDate(y + "/" + m + "/" + d)){
                _selectedYear = y;
                _selectedMonth = m;
                _selectedDay = d;
            }else{
                DateTime greDateTime = DateTime.Now;
                
                string date = DateXFormer.gregorianToPersianString(greDateTime);
                string[] dateArr = date.Split('/');
                _selectedYear = int.Parse(dateArr[0].ToString());
                _selectedMonth = int.Parse(dateArr[1].ToString());
                _selectedDay = int.Parse(dateArr[2].ToString());
            }

            cmbMonth.SelectedItem = _selectedMonth;
            cmbYear.SelectedItem = _selectedYear;
            paintPanel();
            lblSelectedDate.Text = generalizeDate(_selectedYear + "/" + _selectedMonth + "/" + _selectedDay);
            // today date
            string todayStr = DateXFormer.gregorianToPersianString(DateTime.Now);
            lblToday.Text = todayStr;
        }

        private void paintPanel()
        {
            // create and show labels
            int x = 0; 
            int y = 0;
            int width = 25;
            int height = 25;
            mainPanel.Controls.Clear();
            panelTitle.Controls.Clear();
            DateTime pDateTime = new DateTime(_selectedYear, _selectedMonth, 1, new PersianCalendar());
            
            DayOfWeek d = pDateTime.DayOfWeek;//DateXFormer.gregorianToPersian(pDateTime).DayOfWeek;
            d = new PersianCalendar().GetDayOfWeek(pDateTime);
            if (new PersianCalendar().IsLeapYear(_selectedYear))
                _persian_monthes[11] = 30;
            else
                _persian_monthes[11] = 29;
            x = getIndexOfDay(d);
            for (int i = 0; i < 7; i++)
            {
                Label lbl = new Label();
                lbl.Visible = true;
                lbl.Text = _title[i];
                panelTitle.Controls.Add(lbl);
                lbl.SetBounds(i * width + 1,  0 + 1, width - 1, height - 1);
                lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lbl.ForeColor = SelectedFgColor;
                lbl.BackColor = SelectedBkColor;
            }


            for (int i = 1; i <= _persian_monthes[_selectedMonth -1]; i++)
            {
                Label lbl = new Label();
                lbl.Text = i + "";
                mainPanel.Controls.Add(lbl);

                lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lbl.Visible = true;
                lbl.SetBounds(x * width + 1, y * height + 1, width - 1, height - 1);
                lbl.ForeColor = fgColor;
                lbl.BackColor = BkColor; ;
                lbl.Click += new System.EventHandler(this.lbl_Click);
                lbl.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
                if (i == _selectedDay)
                {
                    lbl.ForeColor = SelectedFgColor;
                    lbl.BackColor = SelectedBkColor;
                }
                x++;
                if (x == 7)
                {
                    x = 0;
                    y++;
                }

            }
        }

        private void ShowPanelData(int oldDay,int newDay)
        {

            Label lbl =(Label) mainPanel.Controls[oldDay - 1];
            lbl.ForeColor = fgColor;
            lbl.BackColor = BkColor;
            lbl = (Label)mainPanel.Controls[newDay - 1];
            lbl.ForeColor =SelectedFgColor;
            lbl.BackColor = SelectedBkColor;
            _selectedDay = newDay;
            lblSelectedDate.Text = generalizeDate(_selectedYear + "/" + _selectedMonth + "/" + _selectedDay);
            
        }

        private void lbl_Click(object sender, EventArgs e)
        {
            
            Label lbl = (Label)sender;
            int newDay = int.Parse(lbl.Text);
            ShowPanelData(_selectedDay, newDay);

        }

        private void lbl_DoubleClick(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            int newDay = int.Parse(lbl.Text);
            ShowPanelData(_selectedDay, newDay);
            _selected = true;
            this.Hide();

        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonth.SelectedItem == null)
                return;
            int month = (int)cmbMonth.SelectedItem;
            _selectedMonth = month;
            paintPanel();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYear.SelectedItem == null)
                return;
            int year = (int)cmbYear.SelectedItem;
            _selectedYear = year;
            paintPanel();
        }

        private int getIndexOfDay(DayOfWeek d)
        {
            if (d == DayOfWeek.Saturday)
                return 0;
            if (d == DayOfWeek.Sunday)
                return 1;
            if (d == DayOfWeek.Monday)
                return 2;
            if (d == DayOfWeek.Tuesday)
                return 3;
            if (d == DayOfWeek.Wednesday)
                return 4;
            if (d == DayOfWeek.Thursday)
                return 5;
            if (d == DayOfWeek.Friday)
                return 6;
            return 0;
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            _selectedYear = today.Year;
            _selectedMonth = today.Month;
            _selectedDay = today.Day;
            _selected = true;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _selected = false;
            this.Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _selected = true;
            this.Hide();
        }

        private void DatePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                    this.Close();
        }

        private string generalizeDate(string date)
        {
            string ret = "";
            string[] m = date.Split('/');
            ret = m[0];
            ret += "/";
            if (m[1].Length < 2)
                ret += "0" + m[1];
            else
                ret += m[1];
            ret += "/";
            if (m[2].Length < 2)
                ret += "0" + m[2];
            else
                ret += m[2];
            return ret;
        }
    }
}