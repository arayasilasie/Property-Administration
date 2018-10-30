using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
   public class FAIVBLL:BaseBLL
    {
        #region Properties and Methods

        public Guid ID { get; set; }
        public Guid SRID { get; set; }    
        public Guid FARNID { get; set; }   
        public string FAIVNo { get; set; }
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

        #endregion


        public FAIVBLL()
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

        public void InsertFixedAssetIssueVoucher()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "AddFixedAssetIssueVoucher", SRID, FARNID, FAIVNo, WorkUnitID, ItemID, RequestedQuantity, IssuedQuantity, UnitPrice, Remark, Status, IssuedBy, IssuedDate, IssuedTo, ApprovedBy, ApprovedDate, CreatedBy, CreatedDate);

            //SQLHelper.ExecuteSP(ConnectionString, "AddStoreIssueVoucher", this);
        }

        public void UpdateFixedAssetIssueVoucher()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "UpdateFixedAssetIssueVoucher", ID, WorkUnitID, ItemID, RequestedQuantity, IssuedQuantity, UnitPrice, Remark, IssuedBy, IssuedDate, IssuedTo, ApprovedBy, ApprovedDate, LastModifiedBy, LastModifiedDate);
        }

        public void CancelFixedAssetIssueVoucher(Guid ID, Guid LastModifiedBy, DateTime LastModifiedDate)
        {
            SQLHelper.ExecuteSP(ConnectionString, "CancelFixedAssetIssueVoucher", ID, LastModifiedBy, LastModifiedDate);
        }

        public DataTable GeFixedAssetIssueVoucherList(Guid WorkUnit, Guid ItemID, string strIssuedTo, DateTime IssueDate, DateTime IssueDate2, DateTime ApprovedDate, DateTime ApprovedDate2)
        {
            Guid? IssuedTo = EmployeeBLL.ResolveEmployeeName(strIssuedTo);
            if (IssuedTo == null)
                IssuedTo = new Guid("00000000-0000-0000-0000-000000000000");


            return SQLHelper.getDataTable(ConnectionString, "GetFixedAssetIssueVouchers", WorkUnit, ItemID, IssuedTo, IssueDate, IssueDate2, ApprovedDate, ApprovedDate2);
        }

        public DataRow GetFixedAssetIssueVoucher(Guid ID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetFixedAssetIssueVoucherByID", ID);
        }

        public DataRow GetFixedAssetIssueVoucherBySRID(Guid SRID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetFixedAssetIssueVoucherBySRID", SRID);
        }

        public DataRow GetFixedAssetIssueVoucherByFARNID(Guid FARNID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetFixedAssetIssueVoucherByFARNID", FARNID);
        }

        public DataTable GetFixedAssetIssueVouchers()
        {
            return SQLHelper.getDataTable(ConnectionString, "GetFixedAssetIssueVoucher");
        }

        public DataTable getunapprovedFAIVs(Guid UserID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetUnApprovedFAIVs", UserID);
        }

        public void ApproveFAIVs()
        {
            SQLHelper.ExecuteSP(ConnectionString, "UpdateFAIVApprove", ID, ApprovedDate, Status, ApprovedStatus);
        }

    }
}
