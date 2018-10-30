using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class FixedAssetCardBLL:BaseBLL
    {
        #region Properties and Methods

        public Guid ID { get; set; }       
        public Guid ItemID { get; set; }
        public float BeginingQuantity { get; set; }
        public float CurrentQuantity { get; set; }
        public string Location { get; set; }     
        public string Remark { get; set; }
        public int Status { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        #endregion

        public FixedAssetCardBLL()
        {
        }

        public void InsertFixedAssetCard()
        {
            SQLHelper.ExecuteSP(ConnectionString, "AddFixedAssetCard", ItemID, BeginingQuantity, CurrentQuantity, Location, Remark, Status, CreatedBy, CreatedDate);
        }

        public void UpdateFixedAssetCard()
        {
            SQLHelper.ExecuteSP(ConnectionString, "UpdateFixedAssetCard",ID,  ItemID, BeginingQuantity,  CurrentQuantity, Location,  Remark, Status, LastModifiedBy, LastModifiedDate);
        }

        public void CancelFixedAssetCard(Guid ID, Guid LastModifiedBy, DateTime LastModifiedDate)
        {
            SQLHelper.ExecuteSP(ConnectionString, "CancelFixedAssetCard", ID,  LastModifiedBy, LastModifiedDate);
        }

        public DataTable GetFixedAssetCardList(Guid ItemID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetFixedAssetCards", ItemID);
        }

        public DataRow GetFixedAssetCard(Guid ID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetFixedAssetCardByID", ID);
        }

    }
}
