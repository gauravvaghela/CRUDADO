using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BAL.ShaligramModel
{
    public class clsShaligram
    {
        private DBConnection DbCon = null;        
        public List<User> GetAllUser()
        {
            DbCon = new DBConnection();
            try
            {
                List<User> UserList = new List<User>();
                DataTable dtTemp = new DataTable();
                dtTemp = DbCon.GetAllUser();
                foreach (DataRow dr in dtTemp.Rows)
                {
                    UserList.Add(
                        new User
                        {
                            UserID = Convert.ToInt32(dr["UserId"]),
                            UserName = Convert.ToString(dr["UserName"])
                        });
                }
                return UserList;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                DbCon = null;
            }
        }
        public List<Item> GetAllItem()
        {
            DbCon = new DBConnection();
            try
            {
                List<Item> ItemList = new List<Item>();
                DataTable dtTemp = new DataTable();
                dtTemp = DbCon.GetAllItem();
                foreach (DataRow dr in dtTemp.Rows)
                {
                    ItemList.Add(
                        new Item
                        {
                            ItemId = Convert.ToInt32(dr["ItemId"]),
                            ItemName = Convert.ToString(dr["ItemName"])
                        });
                }
                return ItemList;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                DbCon = null;
            }
        }
        public List<ItemCore> GetItem()
        {
            DbCon = new DBConnection();
            try
            {
                List<ItemCore> ItemList = new List<ItemCore>();
                DataTable dtTemp = new DataTable();
                dtTemp = DbCon.GetItem();
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtTemp.Rows)
                    {
                        ItemList.Add(
                            new ItemCore
                            {
                                ItemId = Convert.ToInt32(dr["Id"]),
                                ItemName = Convert.ToString(dr["ItemName"]),
                                Price = Convert.ToInt32(dr["Price"]),
                                Qty = Convert.ToInt32(dr["Qty"]),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                    }                    
                }
                return ItemList;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                DbCon = null;
            }
        }
        public bool AddItem(string ItemName)
        {
            DbCon = new DBConnection();
            try
            {
                if (DbCon.AddItem(ItemName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool PlaceOrder(int UserId, int TotalAmmount, int WithGST, string Coupon)
        {
            DbCon = new DBConnection();
            try
            {
                if (DbCon.PlaceOrder(UserId,TotalAmmount, WithGST, Coupon))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool IsValidCoupon(string txtCoupon, int TotalAmmount)
        {
            DbCon = new DBConnection();
            try
            {
                if (DbCon.IsValidCoupon(txtCoupon,TotalAmmount))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
