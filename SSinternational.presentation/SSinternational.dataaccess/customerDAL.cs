using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.dataaccess.POCO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data; 
namespace SSinternational.dataaccess
{
    public class customerDAL
    {
        public DataTable getCustomerList(int companyId)
        {

            DataSet ds = new DataSet();

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getCustomerList", cnn))
                {
                    SqlDataAdapter da;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@companyId", companyId);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }

                cnn.Close();

            }



            return ds.Tables[0];
        }

        public int insertCustomer(customers _customerPoco) {
            int lastinsertId = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_customerInsert", cnn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customername", _customerPoco.customername);
                    cmd.Parameters.AddWithValue("@customerphone", _customerPoco.customerphone);
                    cmd.Parameters.AddWithValue("@customeraddress", _customerPoco.customeraddress);
                    cmd.Parameters.AddWithValue("@companyid", _customerPoco.companyid);
                    cmd.Parameters.Add("@lastInsertId", SqlDbType.Int);
                    cmd.Parameters["@lastInsertId"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    lastinsertId = Convert.ToInt32(cmd.Parameters["@lastInsertId"].Value);

                }
                cnn.Close();

            }

            return lastinsertId;
        }

        public DataTable getCustomerById(int customerId) {

            DataSet ds = new DataSet();

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_customerById", cnn))
                {
                    SqlDataAdapter da;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", customerId);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }

                cnn.Close();

            }



            return ds.Tables[0];
         }


        public void upadateCustomer(customers _customerPoco)
        {
            
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_customerUpdate", cnn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", _customerPoco.customerId);
                    cmd.Parameters.AddWithValue("@customername", _customerPoco.customername);
                    cmd.Parameters.AddWithValue("@customerphone", _customerPoco.customerphone);
                    cmd.Parameters.AddWithValue("@customeraddress", _customerPoco.customeraddress);
                    
                    cmd.ExecuteNonQuery();

                    

                }
                cnn.Close();

            }

            
        }

        public Boolean customerDelete(int customerId) {
            try
            {

                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand("usp_customerDelet", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@customerId", SqlDbType.Int, 0, "id"));
                    cmd.Parameters["@customerId"].Value = customerId;
                    cmd.ExecuteNonQuery();

                    cnn.Close();
                }


                return true;
            }
            catch (SqlException ex)
            {

                return false;
            }
            
            
        
        
        
        }
        
    }
}
