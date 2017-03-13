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
    class userDAL
    {
        public int checkLogin(string login,string password) {
            int userid = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                using(SqlCommand cmd=new SqlCommand("usp_checkuser",cnn)){
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.Add("@userid", SqlDbType.Int);
                    cmd.Parameters["@userid"].Direction = ParameterDirection.Output;
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    userid =Convert.ToInt32(cmd.Parameters["@userid"].Value);
                }
            }
            return userid;
        }

        public DataTable getUserDataById(int userId) {

           
            DataSet ds =new DataSet();
            
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_getUserDataById", cnn))
                    {
                        SqlDataAdapter da;


                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userid", userId);
                        
                        da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                    }

                    cnn.Close();

                }
           


            return ds.Tables[0];
        
        
        
        }

        public void getUpdateUserLoginTime(int userId) {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_updateuserlogintime", cnn)) {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                
                }
                cnn.Close();
            
            }
        
        }
        
    }
}
