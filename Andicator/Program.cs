using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RMX_TOOLS.common;
using System.Windows.Forms;
using RMX_TOOLS.data;

namespace Andicator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Config.serverType = Config.SQL_SERVER_TYPE;
            Config.configuration = new Config();

            Application.Run(new MainForm());
        }
    }
}
