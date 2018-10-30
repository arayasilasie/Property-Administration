using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class StoreRequestBLL:BaseBLL
    {
        #region Properties and Methods

        public Guid ID { get; set; }       
        public string SRNo { get; set; }
        public Guid WorkUnitID { get; set; }
        public Guid ItemID { get; set; }
        public Guid RequestTypeID { get; set; }
        public float Quantity { get; set; }
        public string Purpose { get; set; }
        public string Remark { get; set; }
        public string StorekeeperAction { get; set; }
        public int Status { get; set; }
        public Guid RequestedBy { get; set; }
        public DateTime RequestedDate { get; set; }
        public Guid ReviewedBy { get; set; }
        public DateTime ReviewedDate { get; set; }
        public Guid ApprovedBy { get; set; }
        public int ApprovedStatus { get; set; }
        public DateTime ApprovedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public string RequesterName { get; set; }
        public string ApproverName { get; set; }
        public string ReviewerName { get; set; }

        public int Type { get; set; }
        public Guid FARNGRNID { get; set; }

        #endregion


        public StoreRequestBLL()
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


            Guid? reviewerGuid = EmployeeBLL.ResolveEmployeeName(this.ReviewerName);
            if (reviewerGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.ReviewedBy = reviewerGuid.Value;
        }

        public void InsertStoreRequest()
        {
            ResolveName();
            //SQLHelper.ExecuteSP(ConnectionString, "AddStoreRequest", SRNo, WorkUnitID, ItemID, RequestTypeID, Quantity, Purpose, Remark, 
            //    StorekeeperAction, Status, RequestedBy, RequestedDate, ReviewedBy, ReviewedDate, ApprovedBy, ApprovedDate, CreatedBy, CreatedDate);

            SQLHelper.SaveAndReturn(ConnectionString, "AddStoreRequest", this);


        }

        public void UpdateStoreRequest()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "UpdateStoreRequest", ID,Type, WorkUnitID, ItemID, RequestTypeID, Quantity, Purpose, Remark,
                StorekeeperAction, Status, RequestedBy, RequestedDate, ReviewedBy, ReviewedDate, ApprovedBy, ApprovedDate, LastModifiedBy, LastModifiedDate);
       }

        public void CancelStoreRequest(Guid  ID, Guid LastModifiedBy, DateTime LastModifiedDate)
        {
            SQLHelper.ExecuteSP(ConnectionString, "CancelStoreRequest", ID, LastModifiedBy, LastModifiedDate);
        }

        public DataTable GetStoreRequestList(Guid WorkUnit, Guid ItemID, Guid RequestType, DateTime RequestedDate, DateTime RequestedDate2, DateTime ApprovedDate, DateTime ApprovedDate2)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetStoreRequests", WorkUnit, ItemID, RequestType, RequestedDate, RequestedDate2, ApprovedDate, ApprovedDate2);
        }

        public DataRow GetStoreRequest(Guid ID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetStoreRequestByID", ID);
        }

        public DataRow GetStoreRequestByGRNID(Guid GRNID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetStoreRequestByGRNID", GRNID);
        }

        public DataRow GetStoreRequestByFARNID(Guid FARNID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetStoreRequestByFARNID", FARNID);
        }
        public DataTable GetStoreRequests()
        {
            return SQLHelper.getDataTable(ConnectionString, "GetAllStoreRequests");
        }

        public DataTable GetApprovedStoreRequests()
        {
            return SQLHelper.getDataTable(ConnectionString, "GetApprovedStoreRequests");
        }

        public DataTable getunapprovedSRs(Guid UserId)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetUnapprovedStoreRequests", UserId);
        }

        public void ApproveSR()
        {
            //ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "UpdateSRApprove", ID, Status,ApprovedDate, ApprovedStatus );
  
        }
        
    }
}
