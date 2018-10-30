using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class GRNBLL:BaseBLL
    {
         #region Properties and Methods
        
        public Guid ID { get; set; }
        public string GRNNo { get; set; }
        public Guid ItemID { get; set; }
        public Guid SupplyCategoryID { get; set; } 
        public Guid PRID { get; set; }
        public string SuppliedBy { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierEmail { get; set; }
        public string InvoiceNo { get; set; }
        public string Location { get; set; }
        public float Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public Guid ReceivedBy { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string DeliveredBy { get; set; }
        public DateTime DeliveredDate { get; set; }
        public int VerifiedStatus { get; set; }
        public Guid VerifiedBy { get; set; }
        public DateTime VerifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RefNo { get; set; }
        public DateTime RefDate { get; set; }

        public Guid LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public string ReceiverName { get; set; }
        public string DelivererName { get; set; }
        public string VerifierName { get; set; }

        #endregion


        public GRNBLL()
        {
        }

        public void ResolveName()
        {
            Guid? receiverGuid = EmployeeBLL.ResolveEmployeeName(this.ReceiverName);
            if (receiverGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.ReceivedBy = receiverGuid.Value;


            //Guid? delivererGuid = EmployeeBLL.ResolveEmployeeName(this.DelivererName);
            //if (delivererGuid == null)
            //    throw new Exception("No employee found with the specified name!");
            //else
            //    this.DeliveredBy = delivererGuid.Value;


            Guid? verifierGuid = EmployeeBLL.ResolveEmployeeName(this.VerifierName);
            if (verifierGuid == null)
                throw new Exception("No employee found with the specified name!");
            else
                this.VerifiedBy = verifierGuid.Value;
        }

        public void InsertGRN()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "AddGRN", GRNNo, ItemID, SupplyCategoryID, PRID, SuppliedBy, SupplierPhone, SupplierEmail, InvoiceNo, Location, Quantity, UnitPrice, Remark, Status,
                ReceivedBy, ReceivedDate, DeliveredBy, DeliveredDate, VerifiedBy, VerifiedDate, CreatedBy, CreatedDate, RefNo, RefDate); 

        }

        public void UpdateGRN()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "UpdateGRN", ID, ItemID, SupplyCategoryID, SuppliedBy, SupplierPhone, SupplierEmail, InvoiceNo, Location, Quantity, UnitPrice, Remark,
                ReceivedBy, ReceivedDate, DeliveredBy, DeliveredDate, VerifiedBy, VerifiedDate, RefNo, RefDate, LastModifiedBy, LastModifiedDate);
        }

        public void CancelGRN(Guid ID, Guid LastModifiedBy, DateTime LastModifiedDate)
        {
            SQLHelper.ExecuteSP(ConnectionString, "CancelGRN", ID,  LastModifiedBy, LastModifiedDate);
        }

        public DataTable GetGRNList(Guid ItemID, DateTime ReceivedDate, DateTime ReceivedDate2)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetGRNs",ItemID, ReceivedDate, ReceivedDate2);
        }

        public DataTable GetGRNList()
        {
            return SQLHelper.getDataTable(ConnectionString, "GetGRNs");
        }

        //public DataTable GetGRNList(Guid ItemId)
        //{
        //    return SQLHelper.getDataTable(ConnectionString, "GetGRNs",ItemId);
        //}

        public DataTable GetGRNList(Guid ItemID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetGRNs", ItemID);
        }

        public DataTable GetGRNList(DateTime ReceivedDate, DateTime ReceivedDate2)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetGRNs", ReceivedDate, ReceivedDate2);
        }

        public DataRow GetGRN(Guid ID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetGRNByID", ID);
        }

        public DataRow GetGRNByPRID(Guid PRID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetGRNByPRID", PRID);
        }
        public DataTable getunverifiedGRNs(Guid UserID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetUnverifiedGRNs", UserID);
        }

        public void VerifyGRNs()
        {
            SQLHelper.ExecuteSP(ConnectionString, "UpdateGRNApprove", ID, VerifiedDate, VerifiedStatus, Status);
        }
    }
}
