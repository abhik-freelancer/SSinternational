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
    public class UnloadingDAL
    {
        public DataTable getUnloadingMasterList(int companyId, int yearId) {
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getUnloadingMasterList",cnn))
                {
                    SqlDataAdapter da;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@companyId", companyId);
                    cmd.Parameters.AddWithValue("@yearId", yearId);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                
                }
                cnn.Close();
            
            }
            return ds.Tables[0];
        
        }

        public int insertUnloadingMaster(UnloadingmasterPOCO _unloadingmst) {
            int unloadingMasterId = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                SqlTransaction sqlTrans = cnn.BeginTransaction();

                using(SqlCommand cmd = new SqlCommand("usp_unloadmasterInsert",cnn,sqlTrans) )
                {
                    try
                    {
                        #region
                        _unloadingmst.unloadingnumber = getAutoNumber(_unloadingmst.companyId, _unloadingmst.yearId, "UNLOADING"); //auto number generation
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@unloadingnumber", _unloadingmst.unloadingnumber);
                        cmd.Parameters.AddWithValue("@receiptdate", _unloadingmst.receiptdate);
                        cmd.Parameters.AddWithValue("@lotnumber", _unloadingmst.lotnumber);
                        cmd.Parameters.AddWithValue("@gardenid", _unloadingmst.gardenid);
                        cmd.Parameters.AddWithValue("@carrier", _unloadingmst.carrier);
                        cmd.Parameters.AddWithValue("@lorrynum", _unloadingmst.lorrynum);
                        cmd.Parameters.AddWithValue("@brokerid", _unloadingmst.brokerid);
                        cmd.Parameters.AddWithValue("@warehouseid", _unloadingmst.warehouseid);
                        cmd.Parameters.AddWithValue("@cnno", _unloadingmst.cnno);
                        cmd.Parameters.AddWithValue("@cndate", _unloadingmst.cndate);
                        cmd.Parameters.AddWithValue("@gpno", _unloadingmst.gpno);
                        cmd.Parameters.AddWithValue("@wbno", _unloadingmst.wbno);
                        cmd.Parameters.AddWithValue("@companyid", _unloadingmst.companyId);
                        cmd.Parameters.AddWithValue("@yearid", _unloadingmst.yearId);

                        cmd.Parameters.Add("@lastInsertId", SqlDbType.Int);
                        cmd.Parameters["@lastInsertId"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        unloadingMasterId = Convert.ToInt32(cmd.Parameters["@lastInsertId"].Value);
                        #endregion
                        sqlTrans.Commit();
                    }catch(SqlException sExp){
                        sqlTrans.Rollback();
                    }
                }
                cnn.Close();
            }
            return unloadingMasterId;
            
        }

        private string getAutoNumber(int companyId,int yearId,string module) {
            string unloadingNumber = "";
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_autoNumberGeneration",cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@companyid", companyId);
                    cmd.Parameters.AddWithValue("@yearid", yearId);
                    cmd.Parameters.AddWithValue("@module",module);

                    cmd.Parameters.Add("@autonumber", SqlDbType.VarChar, 100);
                    cmd.Parameters["@autonumber"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    unloadingNumber = cmd.Parameters["@autonumber"].Value.ToString();
                }
                cnn.Close();
            }
            return unloadingNumber;
        }

        public int updateUnloadingMaster(UnloadingmasterPOCO _unloadingmst)
        {
            int updateStatus = 1;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                conn.Open();
                SqlTransaction sqlTrans = conn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand("usp_unloadingmasterUpdate", conn, sqlTrans))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", _unloadingmst.id);
                        cmd.Parameters.AddWithValue("@receiptdate", _unloadingmst.receiptdate);
                        cmd.Parameters.AddWithValue("@lotnumber", _unloadingmst.lotnumber);
                        cmd.Parameters.AddWithValue("@gardenid", _unloadingmst.gardenid);
                        cmd.Parameters.AddWithValue("@carrier", _unloadingmst.carrier);
                        cmd.Parameters.AddWithValue("@lorrynum", _unloadingmst.lorrynum);
                        cmd.Parameters.AddWithValue("@brokerid", _unloadingmst.brokerid);
                        cmd.Parameters.AddWithValue("@warehouseid", _unloadingmst.warehouseid);
                        cmd.Parameters.AddWithValue("@cnno", _unloadingmst.cnno);
                        cmd.Parameters.AddWithValue("@cndate", _unloadingmst.cndate);
                        cmd.Parameters.AddWithValue("@gpno", _unloadingmst.gpno);
                        cmd.Parameters.AddWithValue("@wbno", _unloadingmst.wbno);
                        

                       
                        cmd.ExecuteNonQuery();
                       

                        sqlTrans.Commit();
                    }
                    catch (SqlException sExp) {
                        updateStatus = 0;
                        sqlTrans.Rollback();
                    }
                    conn.Close();
                }

            }

            return updateStatus;
        }

        public DataTable getUnloadingmasterById(int unloadMasterId) {
            DataSet ds = new DataSet();

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_GetUnloadingmasterById",cnn))
                {
                    SqlDataAdapter da;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@unloadingmasterId", unloadMasterId);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                }
                cnn.Close();
            
            }
            return ds.Tables[0];

        }

        public Boolean deleteUnloadingMaster(int unloadmasterId)
        {
            try
            {

                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("usp_unloadingmasterDelete", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@unloadmasterId", SqlDbType.Int, 0, "unloadmasterId"));
                    cmd.Parameters["@unloadmasterId"].Value = unloadmasterId;
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

        public int getNumberofInvoices(int unldmstId) {

            int numberofinvoices = 0;

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getNumberofUnloadingInvoice", cnn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@unloadingmasterid", unldmstId);
                    cmd.Parameters.Add("@numberofinvoice", SqlDbType.Int);
                    cmd.Parameters["@numberofinvoice"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    numberofinvoices = Convert.ToInt32(cmd.Parameters["@numberofinvoice"].Value.ToString());
                
                }
                cnn.Close();
            
            }

            return numberofinvoices;
        }


        public DataTable getListOfUnloadingInvoices(int unloadingmasterId) {

            DataSet ds = new DataSet();

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getListofUnloadingInvoices",cnn))
                {
                    SqlDataAdapter da;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@unloadingMasterId", unloadingmasterId);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    
                }
                cnn.Close();
            
            
            }
            return ds.Tables[0];
        
        }


        /**********/
    }

}
