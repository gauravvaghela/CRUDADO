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
        public List<MainCategory> ListCatagory()
        {
            DbCon = new DBConnection();
            try
            {
                List<MainCategory> Category = new List<MainCategory>();
                DataTable dtTemp = new DataTable();
                dtTemp = DbCon.GetCategeory();
                foreach (DataRow dr in dtTemp.Rows)
                {
                    Category.Add(
                        new MainCategory
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
