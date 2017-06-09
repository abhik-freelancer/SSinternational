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
    public class OkaybybrokerDAL
    {
        public DataTable OkaybybrokerMasterData(int arrivalDetailId) {
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            { 
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getOkaybybrokerMasterData",cnn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@arrivalDetailId",arrivalDetailId);
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds);
                
                
                }
                cnn.Close();

            
            }
            return ds.Tables[0];
        
        }

        public int UpdateOkayByBroker(OkaybybrokerPOCO _inspectionResult) {
            int rslt = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                
                cnn.Open();
                SqlTransaction trans = cnn.BeginTransaction();
                try
                {
                    DeleteDamageBagDtl(_inspectionResult.arrivalDetailId, cnn, trans);
                    foreach (var dmjBagDtl in _inspectionResult.damageBagDetails)
                    {

                        damageBagInsert(dmjBagDtl, _inspectionResult.arrivalDetailId, cnn, trans, _inspectionResult.brokerId);
                    }

                    trans.Commit();
                    rslt = 1;
                    cnn.Close();
                }
                catch (SqlException sExp) {
                    trans.Rollback();
                    rslt = 0;
                    cnn.Close();
                }
               
                
            
            }
            return rslt;
        
        }

        private void DeleteDamageBagDtl(int unloadingDtlId, SqlConnection cnn, SqlTransaction trans)
        {
            using (SqlCommand cmd = new SqlCommand("usp_arrivalDamgeBagDetailDeleteById", cnn, trans))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@arrivalDetailId", unloadingDtlId);
                cmd.ExecuteNonQuery();

            }


        }
        private void damageBagInsert(DamageBagDtl damageBag, int arrivalDetailId, SqlConnection cnn, SqlTransaction trns, int brokerId)
        {

            using (SqlCommand cmd = new SqlCommand("usp_arrivalDamageBagDetailInsertion", cnn, trns))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@arrivalDtlId", arrivalDetailId);
                cmd.Parameters.AddWithValue("@damageTypeId", damageBag.damageTypeId);
                cmd.Parameters.AddWithValue("@net", damageBag.net);
                cmd.Parameters.AddWithValue("@serial", damageBag.serial);
                cmd.Parameters.AddWithValue("@brokerId", brokerId);
                //@brokerId

                cmd.ExecuteNonQuery();
            }

        }




        

       
    }
}
