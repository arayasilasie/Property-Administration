using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class UnitBLL:BaseBLL
    {
        #region Properties and Methods

        public Guid ID { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public Guid LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        #endregion


        public static DataTable GetUnit()
        {
            return SQLHelper.getDataTable(ConnectionString, "GetUnits");
        }
    }
}
