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
    public class ArrivalDAL
    {

        /**
         * method getArrivalMasterList
         * param int companyId,int yearId
         * */
        public DataTable getArrivalMasterList(int companyId,int yearId) {

            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_arrivalMasterList",cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@companyId", companyId);
                    cmd.Parameters.AddWithValue("@yearid", yearId);
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds);
                }
                cnn.Close();
            
            }
            return ds.Tables[0];
        }

        /// <summary>
        /// arrival insertion
        /// </summary>
        /// <param name="_arrivalMaster"></param>
        /// <returns>int 2 =duplicate,1=insert success,0=insertion fail</returns>
        public int arrivalMasterInsertion(ArrivalMaster _arrivalMaster) {

            if (getDuplicateArrival(_arrivalMaster.companyid,_arrivalMaster.yearid,_arrivalMaster.arrivalNumber) > 0)
            {
                return 2;
            }
            else {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString)) {

                    cnn.Open();
                    SqlTransaction trans = cnn.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand("usp_arrivalMasterInsertion",cnn,trans)) {

                        try
                        {
                            #region
                            cmd.CommandType = CommandType.StoredProcedure;

                            if (_arrivalMaster.unloadingId != 0)
                            {
                                cmd.Parameters.AddWithValue("@unloadingId", _arrivalMaster.unloadingId);
                            }
                            else {
                                cmd.Parameters.AddWithValue("@unloadingId",DBNull.Value);
                                
                            }


                            cmd.Parameters.AddWithValue("@arrivalNumber", _arrivalMaster.arrivalNumber);
                            cmd.Parameters.AddWithValue("@dateofarrival", _arrivalMaster.dateofarrival);
                            cmd.Parameters.AddWithValue("@lotnumber", _arrivalMaster.lotnumber);
                            cmd.Parameters.AddWithValue("@gardenid", _arrivalMaster.gardenid);
                            cmd.Parameters.AddWithValue("@carrier", _arrivalMaster.carrier);
                            cmd.Parameters.AddWithValue("@lorrynum", _arrivalMaster.lorrynum);
                            cmd.Parameters.AddWithValue("@brokerid", _arrivalMaster.brokerid);
                            cmd.Parameters.AddWithValue("@warehouseid", _arrivalMaster.warehouseid);
                            cmd.Parameters.AddWithValue("@cnno", _arrivalMaster.cnno);
                            cmd.Parameters.AddWithValue("@cndate", _arrivalMaster.cndate);
                            cmd.Parameters.AddWithValue("@gpno", _arrivalMaster.gpno);
                            cmd.Parameters.AddWithValue("@wbno", _arrivalMaster.wbno);
                            cmd.Parameters.AddWithValue("@companyid", _arrivalMaster.companyid);
                            cmd.Parameters.AddWithValue("@yearid", _arrivalMaster.yearid);

                            //add output parameter to command object

                            SqlParameter outparameter = new SqlParameter();
                            outparameter.ParameterName = "@lastinsertId";
                            outparameter.SqlDbType = SqlDbType.Int;
                            outparameter.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(outparameter);

                            cmd.ExecuteNonQuery();

                            int lastinsrtId =Convert.ToInt32(outparameter.Value.ToString());

                            trans.Commit();
                            cnn.Close();
                            return 1;
                            #endregion

                        }
                        catch(SqlException sExp){
                            string errMsg = sExp.Message;
                            trans.Rollback();
                            cnn.Close();
                            return 0;
                        }
                    
                    
                    }
                    
                
                }

            }

        
        }

        ///<summary>
        ///check arrival number exist or not
        ///</summary>
        ///<parameter>
        ///companyid,yearid,arrivalno
        ///</parameter>
        
        public int getDuplicateArrival(int companyId, int yearId,String arrivalNumber) {
            int numberofRecords = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString)) { 
              cnn.Open();
              using (SqlCommand cmd = new SqlCommand("usp_arrivalDuplicateCheck", cnn))
              {
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@companyId", companyId);
                  cmd.Parameters.AddWithValue("@yearId", yearId);
                  cmd.Parameters.AddWithValue("@arrivalNumber", arrivalNumber);
                 

                  //add output parameter to command object
                  SqlParameter outParameter = new SqlParameter();
                  outParameter.ParameterName = "@numberofRecord";
                  outParameter.SqlDbType = SqlDbType.Int;
                  outParameter.Direction = ParameterDirection.Output;
                  cmd.Parameters.Add(outParameter);

                  cmd.ExecuteNonQuery();
                  numberofRecords = Convert.ToInt32(outParameter.Value.ToString());
                
              }
              cnn.Close();
           }

            return numberofRecords;
        }
        /// <summary>
        /// Upadet arrival master
        /// </summary>
        /// <param name="_arrivalMaster"></param>
        /// <returns>int</returns>


        public int arrivalMasterUpdate(ArrivalMaster _arrivalMaster)
        {
            int updateStatus = 0;

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {

                cnn.Open();
                SqlTransaction trans = cnn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand("usp_arrivalMasterUpdate", cnn, trans))
                {

                    try
                    {
                        #region
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@arrivalId", _arrivalMaster.arrivalId);
                        if (_arrivalMaster.unloadingId != 0)
                        {
                            cmd.Parameters.AddWithValue("@unloadingId", _arrivalMaster.unloadingId);
                        }
                        else {
                            cmd.Parameters.AddWithValue("@unloadingId", DBNull.Value);
                        }

                        cmd.Parameters.AddWithValue("@arrivalNumber", _arrivalMaster.arrivalNumber);
                        cmd.Parameters.AddWithValue("@dateofarrival", _arrivalMaster.dateofarrival);
                        cmd.Parameters.AddWithValue("@lotnumber", _arrivalMaster.lotnumber);
                        cmd.Parameters.AddWithValue("@gardenid", _arrivalMaster.gardenid);
                        cmd.Parameters.AddWithValue("@carrier", _arrivalMaster.carrier);
                        cmd.Parameters.AddWithValue("@lorrynum", _arrivalMaster.lorrynum);
                        cmd.Parameters.AddWithValue("@brokerid", _arrivalMaster.brokerid);
                        cmd.Parameters.AddWithValue("@warehouseid", _arrivalMaster.warehouseid);
                        cmd.Parameters.AddWithValue("@cnno", _arrivalMaster.cnno);
                        cmd.Parameters.AddWithValue("@cndate", _arrivalMaster.cndate);
                        cmd.Parameters.AddWithValue("@gpno", _arrivalMaster.gpno);
                        cmd.Parameters.AddWithValue("@wbno", _arrivalMaster.wbno);
                        

                        //add output parameter to command object
                        cmd.ExecuteNonQuery();

                        

                        trans.Commit();
                        cnn.Close();
                        updateStatus = 1;
                        return updateStatus;
                        #endregion

                    }
                    catch (SqlException sExp)
                    {
                        string errMsg = sExp.Message;
                        trans.Rollback();
                        cnn.Close();
                        updateStatus = 0;
                        return updateStatus;
                    }


                }


            }
        
        }

        /// <summary>
        /// getArrivalMasterById for edit
        /// </summary>
        /// <param name="arrivalmasterid"></param>
        /// <returns>data table</returns>

        public DataTable getArrivalMasterById(int arrivalmasterid) {
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_arrivalMasterGetById", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@arrivalId", arrivalmasterid);
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds);
                        
                }
                cnn.Close();
            
            
            }
            return ds.Tables[0];

        
        }


        /****************************************************************/
        /**********Arrival Invoices**************************************/
        /****************************************************************/


        public DataTable getArrivalInvoicesList(int arrivalId) {


            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_arrivalInvoiceList", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@arrivalMasterId",arrivalId);
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds);
                }
                cnn.Close();

            }
            return ds.Tables[0];
        
        }


        public int getNumberofInvoices(int arrivalId)
        {

            int numberofinvoices = 0;

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getNumberofArrivalInvoice", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@arrivalId", arrivalId);
                    cmd.Parameters.Add("@numberofinvoice", SqlDbType.Int);
                    cmd.Parameters["@numberofinvoice"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    numberofinvoices = Convert.ToInt32(cmd.Parameters["@numberofinvoice"].Value.ToString());

                }
                cnn.Close();

            }

            return numberofinvoices;
        
        }

       /// <summary>
        /// checkInvoiceFormatId for arrival
       /// </summary>
       /// <param name="unloadingmasterId"></param>
       /// <returns></returns>
        public int checkInvoiceFormatId(int arrivalId)
        {
            int invoiceId;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_checkArrivalInvoiceFormat", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@arrivalId", arrivalId);
                    cmd.Parameters.Add("@invoiceFormatId", SqlDbType.Int, 0);
                    cmd.Parameters["@invoiceFormatId"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    invoiceId = Convert.ToInt32(cmd.Parameters["@invoiceFormatId"].Value.ToString());
                }
                cnn.Close();

            }

            return invoiceId;

        }

        public string getGardenCode(int arrivalId)
        {
            string gardenCode;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getArrivalGardenCode", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@arrivalId", arrivalId);
                    cmd.Parameters.Add("@gardencode", SqlDbType.VarChar, 100);
                    cmd.Parameters["@gardencode"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    gardenCode = cmd.Parameters["@gardencode"].Value.ToString();
                }
                cnn.Close();

            }

            return gardenCode;
        }


        /******************************************ArrivalInvoiceInsertion*********************************************/



        public int arrivalInvoicesInsertion(ArrivalInvoices _arrivalInvoices)
        {

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                SqlTransaction trans = cnn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand("usp_arrivalDetailInsertion", cnn, trans))
                {
                    try
                    {
                        #region
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@arrivalId", _arrivalInvoices.arrivalId);

                        cmd.Parameters.AddWithValue("@invoice", _arrivalInvoices.invoice);
                        cmd.Parameters.AddWithValue("@grade", _arrivalInvoices.grade);
                        cmd.Parameters.AddWithValue("@package", _arrivalInvoices.package);
                        cmd.Parameters.AddWithValue("@yearofproduction", _arrivalInvoices.yearofproduction);
                        cmd.Parameters.AddWithValue("@pkgsrlfrm", _arrivalInvoices.pkgsrlfrm);
                        cmd.Parameters.AddWithValue("@pkgsrlto", _arrivalInvoices.pkgsrlto);
                        cmd.Parameters.AddWithValue("@invoicequantity", _arrivalInvoices.invoicequantity);
                        cmd.Parameters.AddWithValue("@receivequantity",_arrivalInvoices.receivequantity);
                        cmd.Parameters.AddWithValue("@gross", _arrivalInvoices.gross);
                        cmd.Parameters.AddWithValue("@tare", _arrivalInvoices.tare);
                        cmd.Parameters.AddWithValue("@net", _arrivalInvoices.net);
                        cmd.Parameters.AddWithValue("@floorId", _arrivalInvoices.floorId);
                        //cmd.Parameters.AddWithValue("@")
                        cmd.Parameters.Add("@lastInsertId", SqlDbType.Int, 0);
                        cmd.Parameters["@lastInsertId"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        int lastInsertId = Convert.ToInt32(cmd.Parameters["@lastInsertId"].Value.ToString());

                        foreach (var dmjBagDtl in _arrivalInvoices.damageBagDtls)
                        {

                            damageBagInsert(dmjBagDtl, lastInsertId, cnn, trans);
                        }
                        foreach (var shrtBagDtl in _arrivalInvoices.shortBagDtls)
                        {

                            shortBagInsert(shrtBagDtl, lastInsertId, cnn, trans);
                        }

                        StockInsertion(null, lastInsertId, _arrivalInvoices, cnn, trans);

                        trans.Commit();
                        cnn.Close();
                        return 1;


                        #endregion
                    }
                    catch (SqlException sExp)
                    {
                        trans.Rollback();
                        cnn.Close();
                        return 0;
                    }

                }


            }


        }


        private void damageBagInsert(DamageBagDtl damageBag, int arrivalDetailId, SqlConnection cnn, SqlTransaction trns)
        {

            using (SqlCommand cmd = new SqlCommand("usp_arrivalDamageBagDetailInsertion", cnn, trns))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@arrivalDtlId", arrivalDetailId);
                cmd.Parameters.AddWithValue("@damageTypeId", damageBag.damageTypeId);
                cmd.Parameters.AddWithValue("@net", damageBag.net);
                cmd.Parameters.AddWithValue("@serial", damageBag.serial);
                cmd.ExecuteNonQuery();
            }

        }

        private void shortBagInsert(ShortBagDtls shrtBag, int arrivalDetailId, SqlConnection cnn, SqlTransaction trans)
        {

            using (SqlCommand cmd = new SqlCommand("usp_arrivalShortBadDetailInsertion", cnn, trans))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@arrivalDtlId", arrivalDetailId);
                cmd.Parameters.AddWithValue("@shortTypeId", shrtBag.shortTypeId);
                cmd.Parameters.AddWithValue("@shortPkgNet", shrtBag.shortPkgNet);
                cmd.Parameters.AddWithValue("@serial", shrtBag.serial);
                cmd.ExecuteNonQuery();

            }

        }


        private void StockInsertion(int? stockId,int arrivalDetailId, ArrivalInvoices _invoices,SqlConnection cnn,SqlTransaction trans) { 
        //to do
            using (SqlCommand cmd = new SqlCommand("usp_arrivalStockInsertion",cnn,trans))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@arrivalId", _invoices.arrivalId);
                cmd.Parameters.AddWithValue("@arrivalInvoiceId", arrivalDetailId);
                cmd.Parameters.AddWithValue("@invoice", _invoices.invoice);
                cmd.Parameters.AddWithValue("@grade", _invoices.grade);
                cmd.Parameters.AddWithValue("@yearofproduction", _invoices.yearofproduction);
                cmd.Parameters.AddWithValue("@net", _invoices.net);
                cmd.Parameters.AddWithValue("@invoicequantity", _invoices.receivequantity);
                cmd.ExecuteNonQuery();
            }
        
        }

        public DataTable GetArrivalDtlById(int arrivalMasterId, int arrivalDetailId)
        {   //usp_GetUnloadingDtlById 
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getArrivalDetailById", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@arrivalMasterId", arrivalMasterId);
                    cmd.Parameters.AddWithValue("@arrivalDetailId", arrivalDetailId);


                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds);


                }
                cnn.Close();

            }
            return ds.Tables[0];


        }

        public DataTable GetDamageBagDetailById(int arrivalDetailId)
        {
            //usp_getDamageBagDetailById
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getArrivedDamageBagDetailById", cnn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@arrivalDetailId", arrivalDetailId);
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds);
                }
                cnn.Close();
            }
            return ds.Tables[0];
        }

        public DataTable GetShoertBagDtlById(int arrivalDetailId)
        {
            //usp_GetShoertBagDtlById
            DataSet ds = new DataSet();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_GetArrivedShortBagDtlById", cnn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@arrivalDetailId", arrivalDetailId);
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds);
                }
                cnn.Close();
            }
            return ds.Tables[0];
        }

        public int UpadateunloadingInvoices(ArrivalInvoices updtUnldInvc)
        {
            // 


            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                SqlTransaction trans = cnn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand("usp_arrivalDetailUpdate", cnn, trans))
                {
                    try
                    {
                        #region
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@arrivalDetailId", updtUnldInvc.arrivalDetailid);
                        cmd.Parameters.AddWithValue("@arrivalId", updtUnldInvc.arrivalId);
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
                        DeleteDamageBagDtl(updtUnldInvc.arrivalDetailid, cnn, trans);
                        DeleteShortBagDtl(updtUnldInvc.arrivalDetailid, cnn, trans);

                        foreach (var damageBag in updtUnldInvc.damageBagDtls)
                        {
                            damageBagInsert(damageBag, updtUnldInvc.arrivalDetailid, cnn, trans);
                        }
                        foreach (var shortBag in updtUnldInvc.shortBagDtls)
                        {
                            shortBagInsert(shortBag, updtUnldInvc.arrivalDetailid, cnn, trans);
                        }

                        /****************Stock update****************/
                        updateStock(updtUnldInvc, cnn, trans);

                        trans.Commit();
                        cnn.Close();
                        return 1;
                        #endregion
                    }
                    catch (SqlException sExp)
                    {
                        string errmessg = sExp.Message;
                        trans.Rollback();
                        cnn.Close();
                        return 0;

                    }


                }



            }


        }

        private void DeleteShortBagDtl(int unloadingDtlId, SqlConnection cnn, SqlTransaction trans)
        {

            using (SqlCommand cmd = new SqlCommand("usp_arrivalShortBagDetailDeleteById", cnn, trans))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@arrivalDetailId", unloadingDtlId);
                cmd.ExecuteNonQuery();

            }


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

        private void updateStock(ArrivalInvoices updtUnldInvc,SqlConnection cnn,SqlTransaction trans)
        {
            using (SqlCommand cmd = new SqlCommand("usp_arrivalStockUpdate",cnn,trans))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@arrivalId",updtUnldInvc.arrivalId);
                cmd.Parameters.AddWithValue("@arrivalInvoiceId", updtUnldInvc.arrivalDetailid);
                cmd.Parameters.AddWithValue("@invoice", updtUnldInvc.invoice);
                cmd.Parameters.AddWithValue("@grade", updtUnldInvc.grade);
                cmd.Parameters.AddWithValue("@yearofproduction", updtUnldInvc.yearofproduction);
                cmd.Parameters.AddWithValue("@net", updtUnldInvc.net);
                cmd.Parameters.AddWithValue("@invoicequantity", updtUnldInvc.receivequantity);
                cmd.ExecuteNonQuery();

            }
        }

/******************************************/
    }
}
