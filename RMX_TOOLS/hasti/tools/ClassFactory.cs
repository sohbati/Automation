using System;
using System.Collections.Generic;
using System.Text;

namespace RMX_TOOLS.hasti.tools
{
    public static class ClassFactory
    {
        
        #region project costants
        private const string BLL = "AndicatorBLL";
        private const string DAL = "AndicatorDAL";

        private const string TOOLS_BLL = "RMX_TOOLS.hasti.bll";
        private const string TOOLS_DAL = "RMX_TOOLS.hasti.dal";

        #endregion

        public static object createBLL(string className)
        {
            try
            {
                return Activator.CreateInstance(Type.GetType(BLL + "." + className + "BL"));
            }
            catch (Exception ex)
            {
                return Activator.CreateInstance(Type.GetType(TOOLS_BLL + "." + className + "BL"));
            }
        }

        public static object createDAL(string className)
        {
            try {
                return Activator.CreateInstance(Type.GetType(DAL + "." + className + "DA"));
            }
            catch (Exception ex)
            {
                return Activator.CreateInstance(Type.GetType(TOOLS_DAL + "." + className + "DA"));
            }
        }
    }
}
