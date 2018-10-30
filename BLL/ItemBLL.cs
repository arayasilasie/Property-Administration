using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class ItemBLL:BaseBLL
    {
        #region Properties and Methods

        public Guid ID { get; set; }
        public Guid ItemTypeID { get; set; }
        public Guid UnitID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public Guid LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        #endregion

        public static DataTable GetItem(Guid ItemTypeID)
        {
            return SQLHelper.getDataTable(ConnectionString, "GetItems", ItemTypeID);
        }


        public static List<ItemBLL> GetItemList(Guid ItemTypeID)
        {
            DataTable dt = GetItem(ItemTypeID);

            List<ItemBLL> itmList = new List<ItemBLL>();
            foreach (DataRow dr in dt.Rows)
            {
                ItemBLL itm = new ItemBLL();

                itm.ID = new Guid(dr["ID"].ToString());
                itm.Code = dr["Code"].ToString();
                itm.Description = dr["Description"].ToString();
                itm.Status = int.Parse(dr["Status"].ToString());

                itmList.Add(itm);
            }
            return itmList;
        }

        public static List<string> GetItemCodes(Guid ItemTypeID, string code)
        {
            List<string> listitm = (from list in GetItemList(ItemTypeID) where list.Code.StartsWith(code, StringComparison.CurrentCultureIgnoreCase) select list.Code).ToList();
            return listitm;
        }
    }
}
