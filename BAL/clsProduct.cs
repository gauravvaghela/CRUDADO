using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class clsProduct
    {
        private DBConnection DbCon = null;
        public bool AddProduct(int pid,string ProductName,int Price,string Model,string Color,int Cid)
        {
            DbCon = new DBConnection();
            try
            {
                if(DbCon.AddProduct(pid,ProductName, Price, Model, Color,Cid))
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

        public List<MainProduct> ProductList()
        {
            DbCon = new DBConnection();
            try
            {
                List<MainProduct> ProductList = new List<MainProduct>();
                DataTable dtTemp = new DataTable();
                dtTemp = DbCon.GetProductList();
                foreach (DataRow dr in dtTemp.Rows)
                {
                    ProductList.Add(
                        new MainProduct
                        {
                            Pid = Convert.ToInt32(dr["pid"]),
                            Cid = Convert.ToInt32(dr["cid"]),
                            ProductName = Convert.ToString(dr["ProductName"]),
                            Price = Convert.ToInt32(dr["Price"]),
                            Model = Convert.ToString(dr["Model"]),
                            Color = Convert.ToString(dr["Color"])
                        });
                }
                return ProductList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteProduct(int id)
        {
            DbCon = new DBConnection();
            try
            {
                if (DbCon.DeleteProduct(id))
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
