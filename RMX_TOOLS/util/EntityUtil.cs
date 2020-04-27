using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RMX_TOOLS.util
{
    public class EntityUtil
    {
        public static void joinEntities(RMX_TOOLS.common.AbstractCommonData destinationEntity,
                                RMX_TOOLS.common.AbstractCommonData fromEntity, string destTableName, string fromTableName)
        {
            DataRowCollection rowColl = fromEntity.Tables[fromTableName].Rows;
            foreach (DataRow dr in rowColl)
                destinationEntity.Tables[destTableName].ImportRow(dr);
        }

        public static void joinRow(RMX_TOOLS.common.AbstractCommonData destinationEntity,
                                RMX_TOOLS.common.AbstractCommonData fromEntity, string destTableName, string fromTableName,
                                int rowid)
        {
            DataRow dr = fromEntity.Tables[fromTableName].Rows[rowid];
            destinationEntity.Tables[destTableName].ImportRow(dr);
        }
    }
}
