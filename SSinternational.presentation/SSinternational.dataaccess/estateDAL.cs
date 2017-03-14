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
    public class estateDAL
    {
        public DataTable getEstateList(int companyId)
        {

            DataSet ds = new DataSet();

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getListEstates", cnn))
                {
                    SqlDataAdapter da;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@companyid", companyId);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }

                cnn.Close();

            }



            return ds.Tables[0];
        }

        public int insertEstate(estates _estate)
        {
            int lastinsertId = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_estateInsertion", cnn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@estate",_estate.estate);
                    cmd.Parameters.AddWithValue("@estatecode", _estate.estatecode);
                    cmd.Parameters.AddWithValue("@companyid", _estate.companyid);
                    cmd.Parameters.Add("@lastInsertId",SqlDbType.Int);
                    cmd.Parameters["@lastInsertId"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    lastinsertId = Convert.ToInt32(cmd.Parameters["@lastInsertId"].Value);

                }
                cnn.Close();

            }

            return lastinsertId;
        }

        public DataTable getEstateById(int estateId)
        {

            DataSet ds = new DataSet();

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_estateById", cnn))
                {
                    SqlDataAdapter da;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@estateId", estateId);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }

                cnn.Close();

            }



            return ds.Tables[0];
        }


        public void upadateEstate(estates _estatePoco)
        {

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_estatetUpdate", cnn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@estateId", _estatePoco.estateId);
                    cmd.Parameters.AddWithValue("@estate", _estatePoco.estate);
                    cmd.Parameters.AddWithValue("@estatecode", _estatePoco.estatecode);
                    

                    cmd.ExecuteNonQuery();



                }
                cnn.Close();

            }


        }

        public Boolean estateDelete(int estateId)
        {
            try
            {

                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand("usp_estateDelete", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@estateId", SqlDbType.Int, 0, "estateId"));
                    cmd.Parameters["@estateId"].Value = estateId;
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
