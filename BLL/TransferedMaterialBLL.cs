using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class TransferedMaterialBLL:BaseBLL
    {
    #region Properties and Methods

        public Guid ID { get; set; }
        public Guid ItemID { get; set; }
        public Guid RMRNID { get; set; }
        public Guid FAIVID { get; set; }
        public Guid ConditionID { get; set; }  
        public float Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public string PIN { get; set; }
        public string Reason { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public Guid TransferredBy { get; set; }
        public DateTime TransferredDate { get; set; }
        public Guid TransferedTo { get; set; }
        public DateTime RecievedDate { get; set; } 
        public Guid ApprovedBy { get; set; }
        public int ApprovedStatus { get; set; }
        public DateTime ApprovedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public string TransferrName { get; set; }
        public string RecieverName { get; set; }
        public string ApproverName { get; set; }

        public string RMTNNo { get; set; }
        #endregion


        public TransferedMaterialBLL()
        {
        }

        public void ResolveName()
        {
            Guid? transferrGuid = EmployeeBLL.ResolveEmployeeName(this.TransferrName);
            if (transferrGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.TransferredBy = transferrGuid.Value;

            Guid? recieverGuid = EmployeeBLL.ResolveEmployeeName(this.RecieverName);
            if (recieverGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.TransferedTo = recieverGuid.Value;


            Guid? approverGuid = EmployeeBLL.ResolveEmployeeName(this.ApproverName);
            if (approverGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.ApprovedBy = approverGuid.Value;
        }

        public void InsertTransferedMaterial()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "AddTransferedMaterial", RMRNID,FAIVID, ItemID, RMTNNo, Quantity, ConditionID, UnitCost, Reason, Remark, TransferredBy,
                TransferredDate, TransferedTo, RecievedDate, ApprovedBy, ApprovedDate, Status, CreatedBy, CreatedDate);
            
        }

        public void UpdateTransferedMaterial()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "UpdateTransferedMaterial", ID, Quantity, ConditionID, UnitCost, Reason, Remark, TransferredBy,
                TransferredDate, TransferedTo, RecievedDate, ApprovedBy, ApprovedDate, LastModifiedBy, LastModifiedDate);
        }

        public void CancelTransferedMaterial(Guid ID, Guid LastModifiedBy, DateTime LastModifiedDate)
        {
            SQLHelper.ExecuteSP(ConnectionString, "CancelTransferedMaterial", ID, LastModifiedBy, LastModifiedDate);
        }

        public DataTable GetTransferedMaterialList(Guid ItemID, Guid ConditionID, DateTime TransferredDate, DateTime TransferredDate2)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetTransferedMaterials", ItemID, ConditionID, TransferredDate, TransferredDate2);
        }

        public DataTable GetTransferedMaterialListbyUID(Guid ReceiverID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetTransferedMaterialByUID", ReceiverID);
        }

        public DataRow GetTransferedMaterial(Guid ID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetTransferedMaterialByID", ID);
        }

        public DataRow GetTransferedMaterialByRMID(Guid RMID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetTransferedMaterialByRMID", RMID);
        }

        public DataTable getUnapprovedTMs(Guid UserID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetUnapprovedTMs", UserID);

        }
        public void ApproveTM()
        {
            SQLHelper.ExecuteSP(ConnectionString, "UpdateTransferedMaterialApprove", ID, ApprovedDate, Status, ApprovedStatus);
            //SQLHelper.ExecuteSP(ConnectionString, "UpdateTransferedMaterialApprove", ID, Status, ApprovedDate, ApprovedStatus);
        }
  
    }
}
