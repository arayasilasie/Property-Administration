using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class FixedAssetBLL:BaseBLL
    {
       
        #region Properties and Methods

        public Guid ID { get; set; }
        public Guid FARNID { get; set; }  
        public Guid FAIVID { get; set; }  
        public Guid ItemID { get; set; } 
        public decimal Cost { get; set; }
        public string SNo { get; set; }
        public string TagNo { get; set; }
        public string RecievedFrom { get; set; }
        public DateTime RecievedDate { get; set; }         
        public string Location { get; set; }
        public string Remark { get; set; }
        public string Model { get; set; }
        public int Status { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
     
        #endregion

        public FixedAssetBLL()
        {
        }

        public void InsertFixedAsset()
        {
            SQLHelper.ExecuteSP(ConnectionString, "AddFixedAsset", FARNID, FAIVID, ItemID, SNo, TagNo, RecievedFrom, RecievedDate, Cost, Remark, Location, Status, CreatedBy, CreatedDate,Model);
         }

        public void UpdateFixedAsset()
        {
            SQLHelper.ExecuteSP(ConnectionString, "UpdateFixedAsset", ID, ItemID, SNo, TagNo, RecievedFrom, RecievedDate, Cost, Remark, Location, LastModifiedBy, LastModifiedDate,Model);
        }

        public void CancelFixedAsset(Guid ID, Guid LastModifiedBy, DateTime LastModifiedDate)
        {
            SQLHelper.ExecuteSP(ConnectionString, "CancelFixedAsset", ID, LastModifiedBy, LastModifiedDate);
        }

        public DataTable GetFixedAssetList(Guid ItemID, DateTime RecievedDate, DateTime RecievedDate2)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetFixedAssets", ItemID, RecievedDate, RecievedDate2);
        }

        public DataTable GetFixedAssetList(Guid ItemID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetFixedAssets", ItemID);
        }

        public DataTable GetFixedAssetList()
        {
            return SQLHelper.getDataTable(ConnectionString, "GetFixedAssets");
        }

        public DataRow GetFixedAsset(Guid ID)
        {
            return SQLHelper.getDataRow(ConnectionString, "GetFixedAssetByID", ID);
        }
               
        public static DataTable GetItmTags(Guid ItemID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetItemTags", ItemID);
        }


        public static List<FixedAssetBLL> GetFAList(Guid ItemID)
        {
            DataTable dt = GetItmTags(ItemID);

            List<FixedAssetBLL> faList = new List<FixedAssetBLL>();
            foreach (DataRow dr in dt.Rows)
            {
                FixedAssetBLL fa = new FixedAssetBLL();

                fa.ID = new Guid(dr["ID"].ToString());
                fa.SNo = dr["SNo"].ToString();
                fa.TagNo = dr["TagNo"].ToString();

                faList.Add(fa);
            }
            return faList;
        }

        public static List<string> GetFATags(Guid ItemID, string tag)
        {
            List<string> listitm = (from list in GetFAList(ItemID) where list.TagNo.StartsWith(tag, StringComparison.CurrentCultureIgnoreCase) select list.TagNo).ToList();
            return listitm;
        }

        public DataTable GetUnRegisterFixedAsset()
        {
            return SQLHelper.getDataTable(ConnectionString, "GetUnRegisterFixedAsset");
        }

        public DataTable GetFixedAssetByFAIVFARNID()
        {
            return SQLHelper.getDataTable(ConnectionString, "GetFixedAssetByFAIV_FARNID");
        }
    }
}
