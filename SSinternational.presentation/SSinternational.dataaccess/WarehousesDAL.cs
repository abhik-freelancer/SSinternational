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
   public class WarehousesDAL
    {
        /**
          * Method:GetById
          * param:int WarehouseId
          * return: Datatable Warehouse Row
          * date:17-03-2017 Shibu
          * */
        public DataTable GetById(int WarehouseId)
       {
           DataSet ds = new DataSet();
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand("Usp_WarehouseGetById", cnn))
               {
                   SqlDataAdapter da;
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@WarehouseId", WarehouseId);
                   da = new SqlDataAdapter(cmd);
                   da.Fill(ds);
               }
               cnn.Close();

           }

           return ds.Tables[0];
       }

        /**
           * Method:GetAllActiveWarehouse
           * param:int CompanyId
           * return:  Warehouse List 
           * date:17-03-2017 Shibu
           * */
        public DataTable GetAllActiveWarehouse(int CompanyId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_WarehouseGetActiveByCompanyId", cnn))
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
            * Method:GetAllWarehouse
            * param:int CompanyId
            * return:  Warehouse List 
            * date:17-03-2017 Shibu
            * */
        public DataTable GetAllWarehouse(int CompanyId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_WarehouseGetAllByCompanyId", cnn))
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
         * Method:InsertWarehouse
         * param:Warehouses _warehouse
         * return: (int) WarehouseId
         * date:17-03-2017 Shibu
         * */
        public int InsertWarehouse(Warehouses _warehouse)
       {
           int WarehouseId = 0;
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand("Usp_WarehousesInsert", cnn))
               {

                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@Name", _warehouse.Name);
                   cmd.Parameters.AddWithValue("@Description", _warehouse.Description);
                   cmd.Parameters.AddWithValue("@CompanyId", _warehouse.CompanyId);
                   cmd.Parameters.Add("@WarehouseId", SqlDbType.Int);
                   cmd.Parameters["@WarehouseId"].Direction = ParameterDirection.Output;
                   cmd.ExecuteNonQuery();
                   WarehouseId = Convert.ToInt32(cmd.Parameters["@WarehouseId"].Value);

               }
               cnn.Close();

           }

           return WarehouseId;
       }

        /**
          * Method:UpdateWarehouse
          * param:Warehouses _warehouse
          * return: int 
          * date:17-03-2017 Shibu
          * */
        public int UpdateWarehouse(Warehouses _warehouse)
        {
            int WarehouseId = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_WarehouseUpdate", cnn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", _warehouse.Name);
                        cmd.Parameters.AddWithValue("@Description", _warehouse.Description);
                        cmd.Parameters.AddWithValue("@CompanyId", _warehouse.CompanyId);
                        cmd.Parameters.AddWithValue("@WarehouseId", _warehouse.WarehouseId);

                        cmd.ExecuteNonQuery();
                        WarehouseId = Convert.ToInt32(cmd.Parameters["@WarehouseId"].Value);
                    }
                    catch
                    {
                        WarehouseId = 0;
                    }
                }
                cnn.Close();

            }

            return WarehouseId;
        }

        /**
           * Method: Update Warehouse IsActive State
           * param:int WarehouseId
           * return: void 
           * date:17-03-2017 Shibu
           * */
        public void UpdateWarehouseIsActiveState(int WarehouseId)
        {
           
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_WarehouseUpdateIsActive", cnn))
                {
                    
                        cmd.CommandType = CommandType.StoredProcedure;
                       
                        cmd.Parameters.AddWithValue("@WarehouseId", WarehouseId);

                        cmd.ExecuteNonQuery();
                  
                }
                cnn.Close();

            }       
        }

        public Boolean DeleteWarehouse(int WarehouseId)
        {
            try
            {

                #region
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("Usp_WarehouseDelete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@WarehouseId", WarehouseId);
                        cmd.ExecuteNonQuery();

                    }
                    cnn.Close();

                }
                #endregion
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
    }
}
