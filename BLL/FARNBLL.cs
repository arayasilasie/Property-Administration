using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class FARNBLL:BaseBLL
    {
        #region Properties and Methods
        
        public Guid ID { get; set; }
        public string FARNNo { get; set; }
        public Guid ItemID { get; set; }
        //public Guid SRID { get; set; } 
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
        public int VerifiedStatus { get; set; }
        public DateTime DeliveredDate { get; set; }
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

        public string Model { get; set; }
        #endregion

        
        public FARNBLL()
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

        public void InsertFARN()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "AddFARN", FARNNo, ItemID, PRID, SuppliedBy,SupplierPhone,SupplierEmail, InvoiceNo, Location, Quantity, UnitPrice, Remark, Status,
                ReceivedBy, ReceivedDate, DeliveredBy, DeliveredDate, VerifiedBy, VerifiedDate, CreatedBy, CreatedDate, RefNo, RefDate, Model); 

            //SQLHelper.ExecuteSP(ConnectionString, "AddFARN", this);

        }

        public void UpdateFARN()
        {
            ResolveName();
            SQLHelper.ExecuteSP(ConnectionString, "UpdateFARN", ID, ItemID, SuppliedBy, SupplierPhone, SupplierEmail, InvoiceNo, Location, Quantity, UnitPrice, Remark,
                ReceivedBy, ReceivedDate, DeliveredBy, DeliveredDate, VerifiedBy, VerifiedDate, RefNo, RefDate, LastModifiedBy, LastModifiedDate, Model);
        }

        public void CancelFARN(Guid ID, Guid LastModifiedBy, DateTime LastModifiedDate)
        {
            SQLHelper.ExecuteSP(ConnectionString, "CancelFARN", ID,  LastModifiedBy, LastModifiedDate);
        }


        public DataTable GetFARNList(Guid ItemID, DateTime ReceivedDate, DateTime ReceivedDate2)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetFARNs",ItemID, ReceivedDate, ReceivedDate2);
        }

        public DataRow GetFARN(Guid ID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetFARNByID", ID);
        }

        public DataTable GetallFARN()
        {
            return SQLHelper.getDataTable(ConnectionString, "GetallFARN");
        }

        public DataRow GetFARNByPRID(Guid PRID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetFARNByPRID", PRID);
        }

        public DataTable GetFARNListbyUser(Guid UserID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetFARNByReceiverID", UserID);
        }

        public DataTable getunverifiedFARN(Guid UserID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetUnapprovedFARNs", UserID);
        }

        public void VerifyFARN()
        {
            SQLHelper.ExecuteSP(ConnectionString, "UpdateFARNApprove", ID, VerifiedDate, Status, VerifiedStatus);
        }
    }
}
