using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class StoreIssueVoucherBLL:BaseBLL
    {
        #region Properties and Methods

        public Guid ID { get; set; }
        public Guid SRID { get; set; }    
        public Guid GRNID { get; set; }   
        public string SIVNo { get; set; }
        public Guid WorkUnitID { get; set; }
        public Guid ItemID { get; set; }
        public float RequestedQuantity { get; set; }
        public float IssuedQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public Guid IssuedBy { get; set; }
        public DateTime IssuedDate { get; set; }       
        public Guid IssuedTo { get; set; }
        public int ApprovedStatus { get; set; }
        public Guid ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public string IssuerName { get; set; }
        public string IssuedToName { get; set; }
        public string ApproverName { get; set; }

       // public int Type { get; set; } 

        #endregion


        public StoreIssueVoucherBLL()
        {
        }

        public void ResolveName()
        {
            Guid? issuerGuid = EmployeeBLL.ResolveEmployeeName(this.IssuerName);
            if (issuerGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.IssuedBy = issuerGuid.Value;

            Guid? issuedToGuid = EmployeeBLL.ResolveEmployeeName(this.IssuedToName);
            if (issuedToGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.IssuedTo = issuedToGuid.Value;


            Guid? approverGuid = EmployeeBLL.ResolveEmployeeName(this.ApproverName);
            if (approverGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.ApprovedBy = approverGuid.Value;
        }

        public void InsertStoreIssueVoucher()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "AddStoreIssueVoucher", SRID, GRNID, SIVNo, WorkUnitID, ItemID, RequestedQuantity, IssuedQuantity, UnitPrice, Remark, Status, IssuedBy, IssuedDate, IssuedTo, ApprovedBy , ApprovedDate, CreatedBy, CreatedDate);

            //SQLHelper.ExecuteSP(ConnectionString, "AddStoreIssueVoucher", this);
        }

        public void UpdateStoreIssueVoucher()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "UpdateStoreIssueVoucher", ID, WorkUnitID, ItemID, RequestedQuantity, IssuedQuantity, UnitPrice, Remark, IssuedBy, IssuedDate, IssuedTo, ApprovedBy, ApprovedDate, LastModifiedBy, LastModifiedDate);
        }

        public void CancelStoreIssueVoucher(Guid ID, Guid LastModifiedBy, DateTime LastModifiedDate)
        {
            SQLHelper.ExecuteSP(ConnectionString, "CancelStoreIssueVoucher", ID,LastModifiedBy, LastModifiedDate);
        }

        public DataTable GeStoreIssueVoucherList(Guid WorkUnit, Guid ItemID, string strIssuedTo, DateTime IssueDate, DateTime IssueDate2, DateTime ApprovedDate, DateTime ApprovedDate2)
        {
            Guid? IssuedTo = EmployeeBLL.ResolveEmployeeName(strIssuedTo);
            if (IssuedTo == null)
                IssuedTo = new Guid("00000000-0000-0000-0000-000000000000");


            return SQLHelper.getDataTable(ConnectionString, "GetStoreIssueVouchers", WorkUnit, ItemID,IssuedTo, IssueDate, IssueDate2, ApprovedDate, ApprovedDate2);
        }

        public DataRow GetStoreIssueVoucher(Guid ID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetStoreIssueVoucherByID", ID);
        }

        public DataRow GetStoreIssueVoucherByGRNID(Guid GRNID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetStoreIssueVoucherByGRNID", GRNID);
        }

        public DataRow GetStoreIssueVoucherBySRID(Guid SRID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetStoreIssueVoucherBySRID", SRID);
        }

        public DataTable getunapprovedsivs(Guid UserID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetUnapprovedSIVs", UserID);
        }

        public void ApproveRM()
        {
            SQLHelper.ExecuteSP(ConnectionString, "UpdateSIVApprove", ID, ApprovedDate, Status, ApprovedStatus);
        }
    }
}
