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
    }
}
