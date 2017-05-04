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

        public int UnloadedInvoiceInsert(UnloadingDetails _unloadingDetails) {

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                SqlTransaction trans = cnn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand("usp_unloadDetailInsert",cnn,trans))
                {
                    try
                    {
                        #region
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@unloadingmasterid", _unloadingDetails.unloadingmasterid);
                        cmd.Parameters.AddWithValue("@invoice", _unloadingDetails.invoice);
                        cmd.Parameters.AddWithValue("@grade", _unloadingDetails.grade);
                        cmd.Parameters.AddWithValue("@package", _unloadingDetails.package);
                        cmd.Parameters.AddWithValue("@yearofproduction",_unloadingDetails.yearofproduction);
                        cmd.Parameters.AddWithValue("@pkgsrlfrm", _unloadingDetails.pkgsrlfrm);
                        cmd.Parameters.AddWithValue("@pkgsrlto", _unloadingDetails.pkgsrlto);
                        cmd.Parameters.AddWithValue("@invoicequantity", _unloadingDetails.invoicequantity);
                        cmd.Parameters.AddWithValue("@receivequantity", _unloadingDetails.receivequantity);
                        cmd.Parameters.AddWithValue("@gross", _unloadingDetails.gross);
                        cmd.Parameters.AddWithValue("@tare", _unloadingDetails.tare);
                        cmd.Parameters.AddWithValue("@net", _unloadingDetails.net);
                        cmd.Parameters.AddWithValue("@floorId", _unloadingDetails.floorId);
                        //cmd.Parameters.AddWithValue("@")
                        cmd.Parameters.Add("@lastInsertId", SqlDbType.Int, 0);
                        cmd.Parameters["@lastInsertId"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        int lastInsertId = Convert.ToInt32(cmd.Parameters["@lastInsertId"].Value.ToString());

                        foreach (var dmjBagDtl in _unloadingDetails.damageBagDtls) {

                            damageBagInsert(dmjBagDtl, lastInsertId, cnn,trans);  
                        }
                        foreach (var shrtBagDtl in _unloadingDetails.shortBagDtls) {

                            shortBagInsert(shrtBagDtl, lastInsertId, cnn, trans);
                        }

                        trans.Commit();
                        cnn.Close();
                        return 1;


                        #endregion
                    }
                    catch (SqlException sExp) {
                        trans.Rollback();
                        cnn.Close();
                        return 0;
                    }

                }
                
            
            }
            
        
        }


        private void damageBagInsert(DamageBagDtl damageBag,int unldDtlId,SqlConnection cnn,SqlTransaction trns) {

            using (SqlCommand cmd = new SqlCommand("usp_UnloadingDamageBagDtlInser",cnn,trns))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@unloadingDtlId", unldDtlId);
                cmd.Parameters.AddWithValue("@damageTypeId", damageBag.damageTypeId);
                cmd.Parameters.AddWithValue("@net", damageBag.net);
                cmd.Parameters.AddWithValue("@serial", damageBag.serial);
                cmd.ExecuteNonQuery();
            }
           
        }

        private void shortBagInsert(ShortBagDtls shrtBag, int unldDtlId,SqlConnection cnn,SqlTransaction trans) {

            using (SqlCommand cmd = new SqlCommand("usp_UnloadingShortBagDtlInsert",cnn,trans))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@unloadingDetailId", unldDtlId);
                cmd.Parameters.AddWithValue("@shortTypeId", shrtBag.shortTypeId);
                cmd.Parameters.AddWithValue("@shortPkgNet", shrtBag.shortPkgNet);
                cmd.Parameters.AddWithValue("@serial", shrtBag.serial);
                cmd.ExecuteNonQuery();
            
            }
        
        }
        /*************************************Unloading Detail Edit***********************************/

        public DataTable GetUnloadingDtlById(int unloadingmasterId, int unloadingdetailId)
        {   //usp_GetUnloadingDtlById 
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_GetUnloadingDtlById",cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@unloadingmasterId", unloadingmasterId);
                    cmd.Parameters.AddWithValue("@unloadingdetailId", unloadingdetailId);
                   

                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds);

                
                }
                cnn.Close();
            
            }
            return ds.Tables[0];
        
            
        }

        public DataTable GetDamageBagDetailById(int unloadingDtlId)
        {
            //usp_getDamageBagDetailById
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString)) {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getDamageBagDetailById",cnn)) {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@unloadingDtlId", unloadingDtlId);
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds);
                }
                cnn.Close();
            }
            return ds.Tables[0];
        }

        public DataTable GetShoertBagDtlById(int unloadingDtlId)
        {
            //usp_GetShoertBagDtlById
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_GetShoertBagDtlById",cnn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@unloadingDtlId", unloadingDtlId);
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds);
                }
                cnn.Close();
            }
            return ds.Tables[0];
        }

        public int UpadateunloadingInvoices(UnloadingDetails updtUnldInvc) {
            // 
          
            
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString)) {
                cnn.Open();
                SqlTransaction trans = cnn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand("usp_unloadingInvoiceUpdate",cnn,trans))
                {
                    try
                    {
                        #region
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@unloadingdetailId", updtUnldInvc.unloadingDetailId);
                        cmd.Parameters.AddWithValue("@unloadingmasterid", updtUnldInvc.unloadingmasterid);
                        cmd.Parameters.AddWithValue("@invoice", updtUnldInvc.invoice);
                        cmd.Parameters.AddWithValue("@grade", updtUnldInvc.grade);
                        cmd.Parameters.AddWithValue("@package", updtUnldInvc.package);
                        cmd.Parameters.AddWithValue("@yearofproduction", updtUnldInvc.yearofproduction);
                        cmd.Parameters.AddWithValue("@pkgsrlfrm", updtUnldInvc.pkgsrlfrm);
                        cmd.Parameters.AddWithValue("@pkgsrlto", updtUnldInvc.pkgsrlto);
                        cmd.Parameters.AddWithValue("@invoicequantity", updtUnldInvc.invoicequantity);
                        cmd.Parameters.AddWithValue("@receivequantity", updtUnldInvc.receivequantity);
                        cmd.Parameters.AddWithValue("@gross", updtUnldInvc.gross);
                        cmd.Parameters.AddWithValue("@tare", updtUnldInvc.tare);
                        cmd.Parameters.AddWithValue("@net", updtUnldInvc.net);
                        cmd.Parameters.AddWithValue("@floorId", updtUnldInvc.floorId);
                        cmd.ExecuteNonQuery();
                        //delete first
                        DeleteDamageBagDtl(updtUnldInvc.unloadingDetailId, cnn, trans);
                        DeleteShortBagDtl(updtUnldInvc.unloadingDetailId, cnn, trans);

                        foreach (var damageBag in updtUnldInvc.damageBagDtls) {
                            damageBagInsert(damageBag, updtUnldInvc.unloadingDetailId, cnn, trans);
                        }
                        foreach (var shortBag in updtUnldInvc.shortBagDtls)
                        {
                            shortBagInsert(shortBag, updtUnldInvc.unloadingDetailId, cnn, trans);
                        }


                        trans.Commit();
                        cnn.Close();
                        return 1;
                        #endregion
                    }
                    catch (SqlException sExp) {
                        string errmessg = sExp.Message;
                        trans.Rollback();
                        cnn.Close();
                        return 0;
                    
                    }

                
                }
                
            
            
            }
        
        
        }

        private void DeleteShortBagDtl(int unloadingDtlId, SqlConnection cnn, SqlTransaction trans) {

            using (SqlCommand cmd = new SqlCommand("usp_unldShrtBagDelete",cnn,trans)) {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@unloadingDtlId", unloadingDtlId);
                cmd.ExecuteNonQuery();
            
            }
        
        
        }

        private void DeleteDamageBagDtl(int unloadingDtlId, SqlConnection cnn, SqlTransaction trans)
        {
            using (SqlCommand cmd = new SqlCommand("usp_unldDmgBagDelete", cnn, trans))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@unloadingDtlId", unloadingDtlId);
                cmd.ExecuteNonQuery();

            }
        
        
        }

        /**
         * checkInvoiceFormatId
         * 
         * */
        public int checkInvoiceFormatId(int unloadingmasterId) 
        {
            int invoiceId;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_checkInvoiceFormat", cnn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@unloadingmasterId", unloadingmasterId);
                    cmd.Parameters.Add("@invoiceFormatId", SqlDbType.Int, 0);
                    cmd.Parameters["@invoiceFormatId"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    invoiceId = Convert.ToInt32(cmd.Parameters["@invoiceFormatId"].Value.ToString());
                }
                cnn.Close();
        
            }

            return invoiceId;
        
        }

        public string getGardenCode(int unloadingmasterId)
        {
            string gardenCode;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getGardenCode", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@unloadMasterId", unloadingmasterId);
                    cmd.Parameters.Add("@gardencode", SqlDbType.VarChar, 100);
                    cmd.Parameters["@gardencode"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    gardenCode = cmd.Parameters["@gardencode"].Value.ToString();
                }
                cnn.Close();

            }

            return gardenCode;
        }



        /**********/
    }

}
