using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class WorkUnitBLL:BaseBLL
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

        public static DataTable GetWorkUnit(Guid divisionID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetWorkUnits", divisionID);
        }

        public static DataTable GetDivision()
        {
            return SQLHelper.getDataTable(ConnectionString, "GetDivisions");
        }

        public static DataTable Getallworkunits()
        {
            return SQLHelper.getDataTable(ConnectionString, "GetAllWorkUnits");
        }
    }
}
