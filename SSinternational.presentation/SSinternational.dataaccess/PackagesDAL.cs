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
   public class PackagesDAL
    {
        /**
          * Method:GetById
          * param:int PackageId
          * return: Datatable Package Row
          * date:17-03-2017 Shibu
          * */
        public DataTable GetById(int PackageId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_PackageGetById", cnn))
                {
                    SqlDataAdapter da;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PackageId", PackageId);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }
                cnn.Close();

            }

            return ds.Tables[0];
        }

   

         /**
        * Method:GetAllPackages
        * param:int CompanyId
        * return:  Packages List 
        * date:17-03-2017 Shibu
        * */
        public DataTable GetAllPackages(int CompanyId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_PackageGetAllByComapnyId", cnn))
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
       * Method:GetAllActivePackages
       * param:int CompanyId
       * return:  Packages List 
       * date:17-03-2017 Shibu
       * */
        public DataTable GetAllActivePackages(int CompanyId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_PackageGetActiveByComapnyId", cnn))
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
         * Method:InsertPackege
         * param:Packages _package
         * return: (int) PackageId
         * date:17-03-2017 Shibu
         * */
        public int InsertPackege(Packages _package)
        {
            int PackageId = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_PackegeInsert", cnn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Code", _package.Code);
                    cmd.Parameters.AddWithValue("@Description", _package.Description);
                    cmd.Parameters.AddWithValue("@ComapnyId", _package.CompanyId);
                    cmd.Parameters.Add("@PackageId", SqlDbType.Int);
                    cmd.Parameters["@PackageId"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    PackageId = Convert.ToInt32(cmd.Parameters["@PackageId"].Value);

                }
                cnn.Close();

            }

            return PackageId;
        }

        /**
         * Method:PackageUpdate
         * param:Packages _package
         * return: (int) PackageId
         * date:17-03-2017 Shibu
         * */
        public int UpdatePackage(Packages _package)
        {
            int PackageId = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_PackageUpdate", cnn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Code", _package.Code);
                        cmd.Parameters.AddWithValue("@Description", _package.Description);
                        cmd.Parameters.AddWithValue("@ComapnyId", _package.CompanyId);
                        cmd.Parameters.AddWithValue("@PackageId", _package.PackageId);
                        
                        cmd.ExecuteNonQuery();
                        PackageId = Convert.ToInt32(cmd.Parameters["@PackageId"].Value);

                    }
                    catch
                    {
                        PackageId = 0;
                    }
                }
                cnn.Close();

            }

            return PackageId;
        }
        /**
            * Method: Update Package IsActive State
            * param:int PackageId
            * return: void 
            * date:17-03-2017 Shibu
            * */
        public void UpdatePackageIsActiveState(int PackageId)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_PackageUpdateIsActive", cnn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PackageId", PackageId);
                    cmd.ExecuteNonQuery();
                }
                cnn.Close();

            }
        }
        public Boolean DeletePackage(int PackageId)
        {

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                try
                {

                    using (SqlCommand cmd = new SqlCommand("Usp_PackageDelete", cnn))
                    {
                        cnn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PackageId", PackageId);
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
