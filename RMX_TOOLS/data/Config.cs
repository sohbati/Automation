using System;
using System.Collections.Generic;
using System.Text;

namespace RMX_TOOLS.data
{
    public class Config
    {
        public static Config configuration;
        public static IDataProvider provider;

        public const int SQL_SERVER_TYPE = 0;
        public const int MySQL_TYPE = 1;
        public const int ORACLE_TYPE = 2;

        /*
         *this property set in program in order to determen Server Type
         * default is SQL_SERVER_TYPE
         */
        public static int serverType = SQL_SERVER_TYPE;

         public Config() {
             
             setServer(serverType);
             provider.connect();
        }

        private static void setServer(int serverTYpe)
        {
            switch (serverTYpe)
            {
                case SQL_SERVER_TYPE:
                    provider = new SqlServerProvider();
                    break;
                case MySQL_TYPE:
                    break;
                case ORACLE_TYPE:
                    break;
            }

        }
    }
}
 