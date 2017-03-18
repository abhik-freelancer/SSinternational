using SSinternational.dataaccess.POCO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.dataaccess
{
   internal class ShorttypesDAL
    {
        /**
    * Method:GetAllShortTypes
    * param:int CompanyId
    * return:  ShortType List 
    * date:17-03-2017 Shibu
    * */
        public DataTable GetAllShortTypes(int CompanyId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_ShortTypeGetAll", cnn))
                {
                    SqlDataAdapter da;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
                cnn.Close();

            }

            return ds.Tables[0];
        }
        /**
* Method:GetShortTypeByShortId
* param:int ShortId
* return:  ShortType 
         * * date:17-03-2017 Shibu
* */
        public DataTable GetShortTypeByShortId(int ShortId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_ShortTypeGetById", cnn))
                {
                    SqlDataAdapter da;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ShortId", ShortId);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
                cnn.Close();

            }

            return ds.Tables[0];
        }

        /**
        * Method:InsertShortType
        * param:Shorttypes _shorttype
        * return: (int) ShortId
        * date:17-03-2017 Shibu
        * */
        public int InsertShortType(Shorttypes _shorttype)
        {
            int ShortId = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_ShortTypeInsert", cnn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ShortCode", _shorttype.ShortCode);
                    cmd.Parameters.AddWithValue("@ShortName", _shorttype.ShortName);
                    cmd.Parameters.AddWithValue("@CompanyId", _shorttype.CompanyId);
                    cmd.Parameters.Add("@ShortId", SqlDbType.Int);
                    cmd.Parameters["@ShortId"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    ShortId = Convert.ToInt32(cmd.Parameters["@ShortId"].Value);

                }
                cnn.Close();

            }

            return ShortId;
        }

        /**
         * Method:UpdateShortType
         * param:Shorttypes _shorttype
         * return: (int) PackageId
         * date:17-03-2017 Shibu
         * */
        public int UpdateShortType(Shorttypes _shorttype)
        {
            int ShortId = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_ShortTypeUpdate", cnn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ShortCode", _shorttype.ShortCode);
                        cmd.Parameters.AddWithValue("@ShortName", _shorttype.ShortName);
                        cmd.Parameters.AddWithValue("@CompanyId", _shorttype.CompanyId);
                        cmd.Parameters.AddWithValue("@ShortId", _shorttype.ShortId);

                        cmd.ExecuteNonQuery();
                        ShortId = Convert.ToInt32(cmd.Parameters["@ShortId"].Value);

                    }
                    catch
                    {
                        ShortId = 0;
                    }
                }
                cnn.Close();

            }

            return ShortId;
        }

        public Boolean DeleteShortType(int ShortId)
        {

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                try
                {

                    using (SqlCommand cmd = new SqlCommand("Usp_ShortTypeDeleteById", cnn))
                    {
                        cnn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ShortId", ShortId);
                        cmd.ExecuteNonQuery();

                    }
                    cnn.Close();
                    return true;
                }

                catch
                {
                    cnn.Close();
                    return false;
                }

            }
        }
    }
}
