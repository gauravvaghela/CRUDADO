using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class clsCategory
    {
        private DBConnection DbCon = null;
        public List<Item> ListCatagory()
        {
            DbCon = new DBConnection();
            try
            {
                List<Item> Category = new List<Item>();
                DataTable dtTemp = new DataTable();
                dtTemp = DbCon.GetCategeory();
                foreach (DataRow dr in dtTemp.Rows)
                {
                    Category.Add(
                        new Item
                        {
                            cid = Convert.ToInt32(dr["cid"]),
                            CategoryName = Convert.ToString(dr["CategoryName"])
                        });
                }
                return Category;
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
    }
}
