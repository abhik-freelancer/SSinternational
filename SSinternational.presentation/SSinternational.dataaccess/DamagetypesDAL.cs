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
    public class DamagetypesDAL
    {


        public DataTable GetAllDamageTypes()
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_DamageTypesGetAll", cnn))
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

        public DataTable GetDamageTypesByDamageId(int DamageId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_DamageTypesGetByDamageId", cnn))
                {
                    SqlDataAdapter da;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DamageId", DamageId);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
                cnn.Close();

            }

            return ds.Tables[0];
        }

        /**
       * Method:InsertDamageType
       * param:Damagetypes _damage
       * return: (int) DamageId
       * date:17-03-2017 Shibu
       * */
        public int InsertDamageType(Damagetypes _damage)
        {
            int DamageId = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_DamageTypeInsert", cnn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Description", _damage.Description);
                    cmd.Parameters.AddWithValue("@DamageCode", _damage.DamageCode);                   
                    cmd.Parameters.Add("@DamageId", SqlDbType.Int);
                    cmd.Parameters["@DamageId"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    DamageId = Convert.ToInt32(cmd.Parameters["@DamageId"].Value);

                }
                cnn.Close();

            }

            return DamageId;
        }

        /**
         * Method:UpdateDamageType
         * param:Damagetypes _damage
         * return: (int) PackageId
         * date:17-03-2017 Shibu
         * */
        public int UpdateDamageType(Damagetypes _damage)
        {
            int DamageId = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_DamageTypeUpdate", cnn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Description", _damage.Description);
                        cmd.Parameters.AddWithValue("@DamageCode", _damage.DamageCode);
                        cmd.Parameters.AddWithValue("@DamageId", _damage.DamageId);
                        cmd.ExecuteNonQuery();
                        DamageId = Convert.ToInt32(cmd.Parameters["@DamageId"].Value);
                    }
                    catch
                    {
                        DamageId = 0;
                    }
                }
                cnn.Close();
            }
            return DamageId;
        }

        public Boolean DeleteDeleteByDamageId(int DamageId)
        {

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                try
                {

                    using (SqlCommand cmd = new SqlCommand("Usp_DamageTypesDeleteByDamageId", cnn))
                    {
                        cnn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DamageId", DamageId);
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
