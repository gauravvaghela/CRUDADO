using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnection
    {
        private SqlConnection con = null;
        private SqlCommand cmd = null;
        private SqlDataAdapter da = null;
        public void connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["CompanyPractice"].ToString();
            con = new SqlConnection(conString);
        }

        public DataTable GetCategeory()
        {
            connection();
            cmd = new SqlCommand("spCategory",con);           
            cmd.CommandType = CommandType.StoredProcedure;                    
            DataTable dtTemp = new DataTable();
            cmd.Parameters.AddWithValue("@Action", "GetCategory");
            con.Open();
            da = new SqlDataAdapter(cmd);
            da.Fill(dtTemp);
            con.Close();
            return dtTemp;
        }

        public bool AddProduct(int pid,string ProductName,int Price,string Model,string Color,int Cid)
        {
            try
            {
                int affectRow;
                connection();
                cmd = new SqlCommand("spProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@ProductName", ProductName);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@Model", Model);
                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Cid", Cid);
                cmd.Parameters.AddWithValue("@Action", "Add");
                con.Open();
                affectRow = cmd.ExecuteNonQuery();
                con.Close();
                if (affectRow > 0)
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

        public DataTable GetProductList()
        {
            connection();
            cmd = new SqlCommand("spProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dtTemp = new DataTable();
            cmd.Parameters.AddWithValue("@Action", "GetProduct");
            con.Open();
            da = new SqlDataAdapter(cmd);
            da.Fill(dtTemp);
            con.Close();
            return dtTemp;
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                int affectRow;
                connection();
                cmd = new SqlCommand("spProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@pid", id);                
                cmd.Parameters.AddWithValue("@Action", "Delete");
                con.Open();
                affectRow = cmd.ExecuteNonQuery();
                con.Close();
                if (affectRow > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Shaligram Practicle
        //public List<User> GetAllUser()
        public DataTable GetAllUser()
        {
            connection();
            SqlCommand cmd = new SqlCommand("spUserItem", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "User");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //List<User> UserList = new List<User>();
            con.Open();
            da.Fill(dt);
            con.Close();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    UserList.Add(
            //        new User
            //        {
            //            UserID = Convert.ToInt32(dr["UserId"]),
            //            UserName = Convert.ToString(dr["UserName"])
            //        });
            //}
            return dt;
        }

        //public List<Item> GetAllItem()
        public DataTable GetAllItem()
        {
            connection();
            SqlCommand cmd = new SqlCommand("spUserItem", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Item");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //List<Item> ItemList = new List<Item>();
            con.Open();
            da.Fill(dt);
            con.Close();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ItemList.Add(
            //        new Item
            //        {
            //            ItemId = Convert.ToInt32(dr["ItemId"]),
            //            ItemName = Convert.ToString(dr["ItemName"])
            //        });
            //}
            return dt;
        }
        public bool AddItem(string ItemName)
        {
            connection();
            SqlCommand cmd = new SqlCommand("spItemInsertUpdate", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ItemName", ItemName);
            cmd.Parameters.AddWithValue("@Action", "InsertUpdate");
            con.Open();
            int a = cmd.ExecuteNonQuery();
            con.Close();
            if (a >= 1)
                return true;
            else
                return false;
        }


        //public List<ItemCore> GetItem()
        public DataTable GetItem()
        {
            connection();
            SqlCommand cmd = new SqlCommand("spItemInsertUpdate", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //List<ItemCore> ItemList = new List<ItemCore>();
            con.Open();
            da.Fill(dt);
            con.Close();
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        ItemList.Add(
            //            new ItemCore
            //            {
            //                ItemId = Convert.ToInt32(dr["Id"]),
            //                ItemName = Convert.ToString(dr["ItemName"]),
            //                Price = Convert.ToInt32(dr["Price"]),
            //                Qty = Convert.ToInt32(dr["Qty"]),
            //                Total = Convert.ToInt32(dr["Total"])
            //            });
            //    }
            //}
            return dt;
        }


        public bool PlaceOrder(int UserId, int TotalAmmount, int WithGST, string Coupon)
        {
            connection();
            SqlCommand cmd = new SqlCommand("spOrder", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@Ammount", TotalAmmount);
            cmd.Parameters.AddWithValue("@AmmountWithGST", WithGST);
            cmd.Parameters.AddWithValue("@Coupon", Coupon);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            con.Close();
            if (a >= 1)
                return true;
            else
                return false;
        }

        public bool IsValidCoupon(string txtCoupon, int TotalAmmount)
        {
            string isValid = string.Empty;
            connection();
            SqlCommand cmd = new SqlCommand("spISCouponValid", con);
            cmd.
            CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Coupon", txtCoupon);
            cmd.Parameters.AddWithValue("@TotalAmmount", TotalAmmount);
            cmd.Parameters.Add("@IsValid", SqlDbType.Char, 500);
            cmd.Parameters["@IsValid"].Direction = ParameterDirection.Output;
            con.Open();
            int a = cmd.ExecuteNonQuery();
            isValid = ((string)cmd.Parameters["@IsValid"].Value).Trim();
            con.Close();
            if (isValid == "True")
                return true;
            else
                return false;
        }
    }
}