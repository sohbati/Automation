using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Andicator.help
{
    public partial class ChangeLog : Form
    {
        public ChangeLog()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Close();
                return;
            }
        }

        private void ChangeLog_Load(object sender, EventArgs e)
        {
            string f = "ChangeLog.html";

            string curDir = Directory.GetCurrentDirectory();
            this.webBrowser1.Url = new Uri(String.Format("file:///{0}/" + f , curDir));
        }
    }
}
