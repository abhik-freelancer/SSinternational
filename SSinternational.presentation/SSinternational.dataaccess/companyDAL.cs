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
    public class companyDAL
    {

        public DataTable getCompanyList() {

           
            DataSet ds = new DataSet();

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getcompanylist", cnn))
                {
                    SqlDataAdapter da;
                    cmd.CommandType = CommandType.StoredProcedure;
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                 }

                cnn.Close();

            }



            return ds.Tables[0];
        
        }

        public string getCompanyNameById(int companyId) {
            string companyName = "";
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getCompanyNameById", cnn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@companyId", companyId);

                    cmd.Parameters.Add("@companyName", SqlDbType.VarChar, 100);
                    cmd.Parameters["@companyName"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    companyName = (cmd.Parameters["@companyName"].Value.ToString());

                }
                cnn.Close();

            }

            return companyName;
        
        }


    }
}
