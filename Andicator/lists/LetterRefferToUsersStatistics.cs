using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using AndicatorCommon;
using AndicatorBLL;
using RMX_TOOLS.global;

namespace Andicator.lists
{
    public partial class LetterRefferToUsersStatistics : Form
    {
        ReferLetterBL reffer = new ReferLetterBL();
        public LetterRefferToUsersStatistics()
        {
            InitializeComponent();
            txtToDate.Text = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(DateTime.Now);
            DateTime dt = DateTime.Now;
            dt = dt.AddMonths(-1);
            txtFromDate.Text = RMX_TOOLS.date.DateXFormer.gregorianToPersianString(dt);

        }

        private void loadList(DateTime fromdate, DateTime todate)
        {
            while(flowLayoutPanel1.Controls.Count > 0)
                flowLayoutPanel1.Controls.RemoveAt(0);

            ArrayList list = getReffers(fromdate, todate);
            for (int i = 0; i < list.Count; i++)
            {
                string name = ((object[])list[i])[0].ToString();
                string from = ((object[])list[i])[1].ToString();
                string to = ((object[])list[i])[2].ToString();
                FlowLayoutPanel panel = new FlowLayoutPanel();
                //panel.BorderStyle = flowLayoutPanel1.BorderStyle;
                panel.Width = flowLayoutPanel1.Width - 50;
                panel.Height = 21;
                //name
                Label lbl = new Label();
                lbl.Width = l1.Width;
                lbl.Height = 20;
                lbl.BorderStyle = l1.BorderStyle;
                lbl.Text = name;
                panel.Controls.Add(lbl);
                //from
                lbl = new Label();
                lbl.Width = l2.Width;
                lbl.Height = 20;
                lbl.BorderStyle = l2.BorderStyle;
                lbl.Text = from;
                panel.Controls.Add(lbl);
                //to
                lbl = new Label();
                lbl.Width = l3.Width;
                lbl.Height = 20;
                lbl.BorderStyle = l3.BorderStyle;
                lbl.Text = to;
                panel.Controls.Add(lbl);

                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private ArrayList getReffers(DateTime fromDate, DateTime toDate)
        {
            ArrayList list = new ArrayList();
            
            UsersEntity usersEntity = new UsersBS().get("");
            for (int i = 0; i < usersEntity.RowCount(); i++)
            {
                object[] arr = new object[3];
                arr[0] = usersEntity.ToString(i);
                arr[1] = getRefferFromCount(int.Parse(usersEntity.get(i, UsersEntity.FIELD_ID).ToString()), fromDate, toDate);
                arr[2] = getRefferToCount(int.Parse(usersEntity.get(i, UsersEntity.FIELD_ID).ToString()), fromDate, toDate);
                list.Add(arr);
            }
            return list;
        }

        private int getRefferFromCount(int userid, DateTime fromDate, DateTime toDate)
        {
            ReferLetterEntity entity = reffer.getByUserFromId(userid, fromDate, toDate);
            return entity.RowCount();
        }
        
        private int getRefferToCount(int userid, DateTime fromDate, DateTime toDate)
        {
            ReferLetterEntity entity = reffer.getByUserToId(userid, fromDate, toDate);
            return entity.RowCount();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            bool b = FormChecker.CheckDate(txtFromDate, lblFromDate);
            b &= FormChecker.CheckDate(txtToDate, lblToDate);

            if (!b)
            {
                MessageBox.Show("خطا در تاریخ های وارده شده");
                return;
            }
            loadList(RMX_TOOLS.date.DateXFormer.persianToGreGorian(txtFromDate.Text),
                RMX_TOOLS.date.DateXFormer.persianToGreGorian(txtToDate.Text));
        }

        private void LetterRefferToUsersStatistics_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

        }
    }
}
