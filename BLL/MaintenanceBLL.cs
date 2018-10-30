using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class MaintenanceBLL : BaseBLL
    {

        #region Properties and Methods

        public Guid ID { get; set; }
        public Guid FixedAssetID { get; set; }
        public Guid CustodianID { get; set; }
        public string MaintainedBy { get; set; }
        public DateTime MaintainanceDate { get; set; }
        public string Problem { get; set; }
        public decimal ServiceCost { get; set; }
        public decimal SpareCost { get; set; }       
        public int Status { get; set; }  
        public string Remark { get; set; }           
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        #endregion
          public MaintenanceBLL()
        {
        }

        public void InsertMaintenance()
        {
            SQLHelper.ExecuteSP(ConnectionString, "AddMaintenance", FixedAssetID, CustodianID, MaintainedBy, MaintainanceDate, Problem, ServiceCost, SpareCost, Status, Remark, CreatedBy, CreatedDate);
        }

        public void UpdateMaintenance()
        {
            SQLHelper.ExecuteSP(ConnectionString, "UpdateMaintenance", ID, CustodianID, MaintainedBy, MaintainanceDate, Problem, ServiceCost, SpareCost, Remark, LastModifiedBy, LastModifiedDate);
        }

        public void CancelMaintenance(Guid ID, Guid LastModifiedBy, DateTime LastModifiedDate)
        {
            SQLHelper.ExecuteSP(ConnectionString, "CancelMaintenance", ID,  LastModifiedBy, LastModifiedDate);
        }

        public DataTable GetMaintenanceList(string TagNo, DateTime MaintainanceDate, DateTime MaintainanceDate2)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetMaintenances", TagNo, MaintainanceDate, MaintainanceDate2);
        }

        public DataRow GetMaintenance(Guid ID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetMaintenanceByID", ID);
        }

    }
}
