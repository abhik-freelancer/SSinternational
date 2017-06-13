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
    public class gardenDAL
    {
        public DataTable getGardenList(int companyId)
        {

            DataSet ds = new DataSet();

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getGardenList", cnn))
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

        public int insertGarden(gardens _gardensPOCO)
        {
            int lastinsertId = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_gardenInsertion", cnn))
                {
                    try
                    {
                        #region
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@gardenname", _gardensPOCO.gardenname);
                        cmd.Parameters.AddWithValue("@gardencode", _gardensPOCO.gardencode);
                        cmd.Parameters.AddWithValue("@customerid", _gardensPOCO.customerid);
                        cmd.Parameters.AddWithValue("@companyid", _gardensPOCO.companyid);
                        cmd.Parameters.AddWithValue("@gardenalias", _gardensPOCO.gardenalias);
                        cmd.Parameters.AddWithValue("@invoiceformatid", _gardensPOCO.invoiceformatid);

                        cmd.Parameters.Add("@lastInsertId", SqlDbType.Int);
                        cmd.Parameters["@lastInsertId"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        lastinsertId = Convert.ToInt32(cmd.Parameters["@lastInsertId"].Value);
                        #endregion
                    }
                    catch (SqlException sExp) {
                        lastinsertId = sExp.ErrorCode;
                    
                    }
                }
                cnn.Close();

            }

            return lastinsertId;
        }


        public DataTable getGardenById(int gardenId)
        {

            DataSet ds = new DataSet();

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_gardenById", cnn))
                {
                    SqlDataAdapter da;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@gardenId", gardenId);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }

                cnn.Close();

            }



            return ds.Tables[0];
        }

        public int upadateGarden(gardens _gardenPOCO)
        {
            int updation = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_gardenUpdate", cnn))
                {
                    try
                    {
                        #region
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@gardenId", _gardenPOCO.gardenId);
                        cmd.Parameters.AddWithValue("@gardenname", _gardenPOCO.gardenname);
                        cmd.Parameters.AddWithValue("@gardencode", _gardenPOCO.gardencode);
                        cmd.Parameters.AddWithValue("@customerid", _gardenPOCO.customerid);
                        cmd.Parameters.AddWithValue("@companyid", _gardenPOCO.companyid);
                        cmd.Parameters.AddWithValue("@gardenalias", _gardenPOCO.gardenalias);
                        cmd.Parameters.AddWithValue("@invoiceformatid", _gardenPOCO.invoiceformatid);

                        cmd.ExecuteNonQuery();
                        #endregion
                    }catch(SqlException sExp){

                        updation = sExp.ErrorCode;
                    
                    }

                }
                cnn.Close();

            }
            return updation;


        }

        public Boolean gardenDelete(int gardenId)
        {
            try
            {

                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand("usp_gardenDelete", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@gardenId", SqlDbType.Int, 0, "gardenId"));
                    cmd.Parameters["@gardenId"].Value = gardenId;
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

        public DataTable getGardenByCustomer(int customerid) {
            DataTable dt = new DataTable();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {

                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getGardenByCustomer",cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customerid", customerid);
                    using (SqlDataAdapter dr = new SqlDataAdapter(cmd)) {

                        dr.Fill(dt);
                    }
                
                }
                cnn.Close();

            }
            return dt;
        
        }
    //
    }
}
