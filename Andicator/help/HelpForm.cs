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
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            
            string s = "";
            
            System.IO.StreamReader str = new StreamReader("help.htm");
            s = str.ReadToEnd();
            
            this.webBrowser1.DocumentText= s; 
        }

        private void HelpForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Close();
                return;
            }
        }
    }
}
