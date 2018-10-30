using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    class TransferredItemsBLL : BaseBLL
    {
        public DataTable GetFARNListbyUser(Guid UserID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetFARNByReceiverID", UserID);
        }
    }
}
