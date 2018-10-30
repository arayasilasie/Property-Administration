using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class PurchaseRequestBLL:BaseBLL
    {
         #region Properties and Methods

        public Guid ID { get; set; }
        public Guid SRID { get; set; }    
        public string PRNo { get; set; }
        public Guid WorkUnitID { get; set; }
        public Guid ItemID { get; set; }
        public Guid RequestTypeID { get; set; }
        public float Quantity { get; set; }
        public string Purpose { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public Guid RequestedBy { get; set; }
        public DateTime RequestedDate { get; set; }       
        public Guid ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }
        public int ApprovedStatus { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public string RequesterName { get; set; }
        public string ApproverName { get; set; }
        public string ReviewerName { get; set; }
     
        #endregion


        public PurchaseRequestBLL()
        {
        }

        public void ResolveName()
        {
            Guid? requesterGuid = EmployeeBLL.ResolveEmployeeName(this.RequesterName);
            if (requesterGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.RequestedBy = requesterGuid.Value;


            Guid? approverGuid = EmployeeBLL.ResolveEmployeeName(this.ApproverName);
            if (approverGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.ApprovedBy = approverGuid.Value;
        }

        public void InsertPurchaseRequest()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "AddPurchaseRequest", PRNo,SRID, WorkUnitID, ItemID,  Quantity, Purpose, Remark , Status, 
                RequestedBy, RequestedDate, ApprovedBy, ApprovedDate, CreatedBy, CreatedDate,RequestTypeID);
            //SQLHelper.ExecuteSP(ConnectionString, "AddPurchaseRequest", this);
        }
        
        public  void UpdatePurchaseRequest()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "UpdatePurchaseRequest", ID, Quantity, Purpose, Remark, RequestedBy, RequestedDate, ApprovedBy, ApprovedDate, LastModifiedBy, LastModifiedDate);
        }
  
        public  void CancelPurchaseRequest(Guid ID,Guid LastModifiedBy, DateTime LastModifiedDate)
        {
            SQLHelper.ExecuteSP(ConnectionString, "CancelPurchaseRequest", ID,LastModifiedBy, LastModifiedDate);
        }
        public  DataTable GePurchaseRequestList(Guid WorkUnit, Guid ItemID, Guid RequestType, DateTime RequestedDate, DateTime RequestedDate2, DateTime ApprovedDate, DateTime ApprovedDate2)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetPurchaseRequests", WorkUnit, ItemID, RequestType, RequestedDate, RequestedDate2, ApprovedDate, ApprovedDate2);
        }

        public DataRow GetPurchaseRequest(Guid ID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetPurchaseRequestByID", ID);
        }
        public DataRow GetPurchaseRequestBySRID(Guid SRID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetPurchaseRequestBySRID", SRID);
        }

        public DataTable getunapprovedPRs(Guid UserID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetUnapprovedPRs", UserID);
        }

        public void approvePRs()
        {
            SQLHelper.ExecuteSP(ConnectionString, "UpdatePRApprove", ID, Status, ApprovedDate, ApprovedStatus);
        }
    }
}
