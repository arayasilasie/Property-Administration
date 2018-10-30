using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class ReturnedMaterialBLL:BaseBLL
    {
        
        #region Properties and Methods

        public Guid ID { get; set; }
        public Guid ItemID { get; set; }
        public Guid FAIVID { get; set; }
        public Guid RMTNID { get; set; }    
        public Guid ConditionID { get; set; }  
        public float Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public string PIN { get; set; }
        public string Reason { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public Guid ReturnedBy { get; set; }        
        public Guid RecievedBy { get; set; }
        public DateTime RecievedDate { get; set; } 
        public Guid ApprovedBy { get; set; }
        public int ApprovedStatus { get; set; }
        public DateTime ApprovedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public string ReturnerName { get; set; }
        public string RecieverName { get; set; }
        public string ApproverName { get; set; }

        public string RMRNNo { get; set; }
        #endregion


        public ReturnedMaterialBLL()
        {
        }

        public void ResolveName()
        {
            Guid? returnerGuid = EmployeeBLL.ResolveEmployeeName(this.ReturnerName);
            if (returnerGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.ReturnedBy = returnerGuid.Value;

            Guid? recieverGuid = EmployeeBLL.ResolveEmployeeName(this.RecieverName);
            if (recieverGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.RecievedBy = recieverGuid.Value;


            Guid? approverGuid = EmployeeBLL.ResolveEmployeeName(this.ApproverName);
            if (approverGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.ApprovedBy = approverGuid.Value;
        }

        public void InsertReturnedMaterial()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "AddReturnedMaterial", FAIVID, ItemID, RMTNID, Quantity, ConditionID, UnitCost, PIN, Reason, Remark, Status, ReturnedBy, RecievedBy, RecievedDate, ApprovedBy, ApprovedDate, CreatedBy, CreatedDate, RMRNNo);
        }

        public void UpdateReturnedMaterial()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "UpdateReturnedMaterial", ID, Quantity, ConditionID, UnitCost, PIN, Reason, Remark, ReturnedBy, RecievedBy, RecievedDate, ApprovedBy, ApprovedDate, LastModifiedBy, LastModifiedDate);
        }

        public void CancelReturnedMaterial(Guid ID, Guid LastModifiedBy, DateTime LastModifiedDate)
        {
            SQLHelper.ExecuteSP(ConnectionString, "CancelReturnedMaterial", ID, LastModifiedBy, LastModifiedDate);
        }

        public DataTable GetReturnedMaterialList(Guid ItemID, Guid ConditionID,  DateTime RecievedDate , DateTime RecievedDate2)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetReturnedMaterials", ItemID, ConditionID, RecievedDate , RecievedDate2);
        }

        public DataRow GetReturnedMaterial(Guid ID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetReturnedMaterialByID", ID);
        }

        public DataRow GetReturnedMaterialByFAIVID(Guid FAIVID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetReturnedMaterialByFAIVID", FAIVID);
        }

        public DataRow GetReturnedMaterialByRMTNID(Guid RMTNID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetReturnedMaterialByRMTNID", RMTNID);
        }

        public DataTable getunapprovedRM(Guid UserID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetUnapprovedRM", UserID);
        }

        public void ApproveRM()
        {
            SQLHelper.ExecuteSP(ConnectionString, "UpdateReturnedMaterialApprove", ID,ApprovedDate , Status, ApprovedStatus);
        }
    }
}

