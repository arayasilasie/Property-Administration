using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class BINCardBLL:BaseBLL
    {
        #region Properties and Methods

        public Guid ID { get; set; }       
        public Guid ItemID { get; set; }
        public float BeginingQuantity { get; set; }
        public float MinOrderQuantity { get; set; }
        public float CurrentQuantity { get; set; }
        public string Location { get; set; }
        public string ShelfNo { get; set; }
        public string RankNo { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        #endregion
                       
        public BINCardBLL()
        {
        }

        public void InsertBINCard()
        {
            SQLHelper.ExecuteSP(ConnectionString, "AddBINCard", ItemID, BeginingQuantity, MinOrderQuantity, CurrentQuantity, Location, ShelfNo, RankNo, Remark, Status, CreatedBy, CreatedDate);
        }

        public void UpdateBINCard()
        {
            SQLHelper.ExecuteSP(ConnectionString, "UpdateBINCard",ID,  ItemID, BeginingQuantity, MinOrderQuantity, CurrentQuantity, Location, ShelfNo, RankNo, Remark, Status, LastModifiedBy, LastModifiedDate);
        }

        public void CancelBINCard(Guid ID, Guid LastModifiedBy, DateTime LastModifiedDate)
        {
            SQLHelper.ExecuteSP(ConnectionString, "CancelBINCard", ID,  LastModifiedBy, LastModifiedDate);
        }

        public DataTable GetBINCardList(Guid ItemID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetBINCards", ItemID);
        }

        public DataRow GetBINCard(Guid ID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetBINCardByID", ID);
        }

    }
}
