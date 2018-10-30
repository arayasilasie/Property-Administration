using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class BorrowedFixedAssetBLL : BaseBLL
    {
        
        #region Properties and Methods

        public Guid ID { get; set; }
        public Guid ItemID { get; set; }
        public Guid RMID { get; set; }
        public string DispatchedFrom { get; set; }
        public string DispatchedTo { get; set; }
        public DateTime DispatchingDate { get; set; }
        public DateTime ReturningDate { get; set; }
        public string Reason { get; set; }
        public Guid PreparedBy { get; set; }
        public DateTime PreparedDate { get; set; }
        public Guid CheckedBy { get; set; }
        public DateTime CheckedDate { get; set; }
        public Guid ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }
        public Guid ReceivedBy { get; set; }
        public DateTime ReceivedDate { get; set; }
        public Guid ArrivalConfirmedBy { get; set; }
        public DateTime ArrivalConfirmedDate { get; set; }
        public int Status { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public string PreparerName { get; set; }
        public string CheckerName { get; set; }
        public string ApproverName { get; set; }
        public string ReceiverName { get; set; }
        public string ArrivalConfirmerName { get; set; } 
      
        public bool Returned { get; set; }
        
        #endregion
        
        public BorrowedFixedAssetBLL()
        {
        }

        public void ResolveName()
        {
            Guid? preparerGuid = EmployeeBLL.ResolveEmployeeName(this.PreparerName);
            if (preparerGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.PreparedBy = preparerGuid.Value;


            Guid? checkerGuid = EmployeeBLL.ResolveEmployeeName(this.CheckerName);
            if (checkerGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.CheckedBy = checkerGuid.Value;

            Guid? approverGuid = EmployeeBLL.ResolveEmployeeName(this.ApproverName);
            if (approverGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.ApprovedBy = approverGuid.Value;

            if (this.ReceiverName != "")
            {
                Guid? receiverGuid = EmployeeBLL.ResolveEmployeeName(this.ReceiverName);
                if (receiverGuid == null)
                    throw new Exception("No employee found with the specified name!");
                else
                    this.ReceivedBy = receiverGuid.Value;
            }

            if (this.ArrivalConfirmerName != "")
            {
                Guid? arrivalConfirmerGuid = EmployeeBLL.ResolveEmployeeName(this.ArrivalConfirmerName);
                if (arrivalConfirmerGuid == null)
                    throw new Exception("No employee found with the specified name!");
                else
                    this.ArrivalConfirmedBy = arrivalConfirmerGuid.Value;
            }
        }

        public void InsertBorrowedFixedAsset()
        {
            ResolveName();
            SQLHelper.SaveAndReturn(ConnectionString, "AddBorrowedFixedAsset", this);
                // FixedAssetID, DispatchedFrom, DispatchedTo, DispatchingDate, ReturningDate, Reason, PreparedBy, 
                //PreparedDate, CheckedBy, CheckedDate, ApprovedBy, ApprovedDate, ReceivedBy, ReceivedDate, ArrivalConfirmedBy, ArrivalConfirmedDate, Status, CreatedBy, CreatedDate);

        }

        public void UpdateBorrowedFixedAsset()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "UpdateBorrowedFixedAsset",ID,RMID,ItemID,Returned, DispatchedFrom, DispatchedTo, DispatchingDate, ReturningDate, Reason, PreparedBy,
                PreparedDate, CheckedBy, CheckedDate, ApprovedBy, ApprovedDate, ReceivedBy, ReceivedDate, ArrivalConfirmedBy, ArrivalConfirmedDate, LastModifiedBy, LastModifiedDate);


        }

        public void CancelBorrowedFixedAsset(Guid ID, Guid LastModifiedBy, DateTime LastModifiedDate)
        {
            SQLHelper.ExecuteSP(ConnectionString, "CancelBorrowedFixedAsset", ID, LastModifiedBy, LastModifiedDate);
        }

        public DataTable GetBorrowedFixedAssetList(Guid ItemID, DateTime DispatchingDate, DateTime DispatchingDate2)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetBorrowedFixedAssets", ItemID, DispatchingDate, DispatchingDate2);
        }

        public DataRow GetBorrowedFixedAsset(Guid ID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetBorrowedFixedAssetByID", ID);
        }

        public DataRow GetGPass(Guid ID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetGPassForBorrow", ID);
        }
    }
}
