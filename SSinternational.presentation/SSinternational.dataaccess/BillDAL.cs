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
   public class BillDAL
    {
       public DataTable getBuyerBillList(int company) {

           DataTable dt = new DataTable();
           using(SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString)){
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand("usp_BuyerBillList",cnn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@company",company);
                   using(SqlDataAdapter da = new SqlDataAdapter(cmd)){
                       da.Fill(dt);
                   }

               }
               cnn.Close();

           }
           return dt;
       }


       public DataTable getInvoiceListByGarden(string garden,int companyId) {

           DataTable dt = new DataTable();
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               string sql = "SELECT Invoice FROM [StockLedger] WHERE [StockLedger].[Garden] ='" + garden.Trim() + "' AND StockLedger.TransType='AR' AND StockLedger.companyId=" + companyId;
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand(sql, cnn))
               {
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {

                       da.Fill(dt);
                   }

               }
               cnn.Close();
           
           }
           return dt;
       }

       public DataTable getGradeByGardenAndInvoice(string garden, string invoice, int companyId)
       {

           DataTable dt = new DataTable();
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               string sql = "SELECT Grade FROM [StockLedger] WHERE [StockLedger].[Garden] ='" + garden.Trim() + "' AND [StockLedger].Invoice='" + invoice.Trim() + "' AND StockLedger.TransType='AR' AND StockLedger.companyId=" + companyId;
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand(sql, cnn))
               {
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {

                       da.Fill(dt);
                   }

               }
               cnn.Close();

           }
           return dt;
       }


       public DataTable getNettByGardenAndInvoiceAndGrade(string garden, string invoice, string grade, int companyId)
       {
           DataTable dt = new DataTable();
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           { 
               string sql = "SELECT StockLedger.net FROM StockLedger "+
                            " WHERE StockLedger.Garden='" + garden + "' AND StockLedger.Invoice='" + invoice + "' AND StockLedger.Grade='" + grade + "' AND StockLedger.TransType='AR' AND StockLedger.companyId=" + companyId; 
               cnn.Open();
               using(SqlCommand cmd = new SqlCommand(sql,cnn)){
               
                    using(SqlDataAdapter da = new SqlDataAdapter(cmd)){
                        da.Fill(dt);
                    }
               }
               cnn.Close();

           }
           return dt;
       }

       public decimal getStockBags(string garden, string invoice, string grade,decimal nett, int companyId)
       {
           decimal stockBags = 0;
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand("usp_getCurrentStock",cnn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@garden", garden);
                   cmd.Parameters.AddWithValue("@invoice", invoice);
                   cmd.Parameters.AddWithValue("@grade", grade);
                   cmd.Parameters.AddWithValue("@nett", nett);
                   cmd.Parameters.AddWithValue("@companyId", companyId);

                   //out put parameter
                   SqlParameter outputparameter = new SqlParameter();
                   outputparameter.ParameterName = "@balance";
                   outputparameter.SqlDbType = SqlDbType.Decimal;
                   outputparameter.Direction = ParameterDirection.Output;
                   cmd.Parameters.Add(outputparameter);

                   cmd.ExecuteNonQuery();

                   stockBags = Convert.ToDecimal(outputparameter.Value.ToString());

               }
               cnn.Close();
           }
           return stockBags;
       }
       /// <summary>
       /// Getting stock ledger id
       /// </summary>
       /// <param name="garden"></param>
       /// <param name="invoice"></param>
       /// <param name="grade"></param>
       /// <param name="nett"></param>
       /// <param name="companyId"></param>
       /// <returns></returns>
       public int getStockLedgerId(string garden, string invoice, string grade, decimal nett, int companyId)
       {
           int stockLedgerId;
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand("usp_getStockLedgerId",cnn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@garden", garden);
                   cmd.Parameters.AddWithValue("@invoice", invoice);
                   cmd.Parameters.AddWithValue("@grade", grade);
                   cmd.Parameters.AddWithValue("@nett", nett);
                   cmd.Parameters.AddWithValue("@companyId", companyId);

                   //out put parameter
                   SqlParameter outputparameter = new SqlParameter();
                   outputparameter.ParameterName = "@stockLedgerId";
                   outputparameter.SqlDbType = SqlDbType.Decimal;
                   outputparameter.Direction = ParameterDirection.Output;
                   cmd.Parameters.Add(outputparameter);

                   cmd.ExecuteNonQuery();
                   stockLedgerId = Convert.ToInt32(outputparameter.Value.ToString());
               }
               cnn.Close();
           }
           return stockLedgerId;
       
       }

        /// <summary>
        /// Getting arrival invoice id
        /// </summary>
        /// <param name="garden"></param>
        /// <param name="invoice"></param>
        /// <param name="grade"></param>
        /// <param name="nett"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>

       public int getArrivalInvoiceId(string garden, string invoice, string grade, decimal nett, int companyId)
       {
           int transactionId;
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand("usp_getArrivalInvoiceId", cnn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@garden", garden);
                   cmd.Parameters.AddWithValue("@invoice", invoice);
                   cmd.Parameters.AddWithValue("@grade", grade);
                   cmd.Parameters.AddWithValue("@nett", nett);
                   cmd.Parameters.AddWithValue("@companyId", companyId);

                   //out put parameter
                   SqlParameter outputparameter = new SqlParameter();
                   outputparameter.ParameterName = "@transactionId";
                   outputparameter.SqlDbType = SqlDbType.Decimal;
                   outputparameter.Direction = ParameterDirection.Output;
                   cmd.Parameters.Add(outputparameter);

                   cmd.ExecuteNonQuery();
                   transactionId = Convert.ToInt32(outputparameter.Value.ToString());
               }
               cnn.Close();
           }
           return transactionId;

       }

    public DataTable getRenFortheYear(int yearId,int companyId) {
           DataTable dt = new DataTable();
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               string sql = "SELECT [StrRemRate],[ChkWghRate],[SamplingRate],[AdditionalRate] FROM [RateTable] WHERE [yearId]=" + yearId + " AND [companyId]="+companyId;
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand(sql, cnn))
               {

                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dt);
                   }
               }
               cnn.Close();
           }

           return dt;
       
       }

       public DataTable getRateSlab(int year,int company) {

           DataTable dt = new DataTable();
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand("usp_RateSlab",cnn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@compnayId",company);
                   cmd.Parameters.AddWithValue("@yearId", year);

                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                      

                       da.Fill(dt);
                   }
                   
               }
               cnn.Close();
           
           }
           return dt;
       
       
       }

       public int InsertBill(BillPOCO Bill) {
           
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               cnn.Open();
               SqlTransaction trn = cnn.BeginTransaction();
               using (SqlCommand cmd = new SqlCommand("usp_insertBillMaster",cnn,trn))
               {

                   try {
                        string BillNumber = getAutoNumber(Bill.companyId,Bill.yearId,"BILL");
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@billnumber", BillNumber);
                        cmd.Parameters.AddWithValue("@deliverydate", Bill.deliverydate);
                        cmd.Parameters.AddWithValue("@buyer", Bill.buyer);
                        cmd.Parameters.AddWithValue("@sarkar", Bill.sarkar);
                        cmd.Parameters.AddWithValue("@doNumber", Bill.doNumber);
                        cmd.Parameters.AddWithValue("@doDate", Bill.doDate);
                        cmd.Parameters.AddWithValue("@grandtotalamount", Bill.grandtotalamount);
                        cmd.Parameters.AddWithValue("@companyId", Bill.companyId);
                        cmd.Parameters.AddWithValue("@yearId", Bill.yearId);
                       
                        //output paramater
                        SqlParameter output = new SqlParameter();
                        output.ParameterName = "@lastInsertId";
                        output.SqlDbType = SqlDbType.Int;
                        output.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(output);

                        cmd.ExecuteNonQuery();
                        int lastInsertId = Convert.ToInt32(output.Value.ToString());

                        foreach (var BillDts in Bill.BillDetails) {

                            insertBillDetails(BillDts, lastInsertId, trn, cnn);
                            insertBillInStockLedger(BillDts.stockid, BillDts.invoiceId, BillNumber, Bill.deliverydate, Bill.companyId, Bill.yearId, BillDts.numberofbags, cnn, trn);
                        }


                        trn.Commit();
                        cnn.Close();
                        return 1;
                        


                   
                   }catch(SqlException sExp){
                       trn.Rollback();
                       cnn.Close();
                       return 0;
                   }
               
               }
              
           }
       
       }
       private string getAutoNumber(int companyId, int yearId, string module)
       {
           string billno = "";
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand("usp_autoNumberGeneration", cnn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@companyid", companyId);
                   cmd.Parameters.AddWithValue("@yearid", yearId);
                   cmd.Parameters.AddWithValue("@module", module);

                   cmd.Parameters.Add("@autonumber", SqlDbType.VarChar, 100);
                   cmd.Parameters["@autonumber"].Direction = ParameterDirection.Output;
                   cmd.ExecuteNonQuery();
                   billno = cmd.Parameters["@autonumber"].Value.ToString();
               }
               cnn.Close();
           }
           return billno;
       }

       private void insertBillDetails(BillDetails bDtls,int BillMasterId,SqlTransaction trn,SqlConnection cnn) {

           using (SqlCommand cmd = new SqlCommand("usp_BillDtlInsertion",cnn,trn))
           {
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@billmasterid", BillMasterId);
               cmd.Parameters.AddWithValue("@stockid", bDtls.stockid);
               cmd.Parameters.AddWithValue("@invoiceId", bDtls.invoiceId);
               cmd.Parameters.AddWithValue("@numberofbags", bDtls.numberofbags);
               cmd.Parameters.AddWithValue("@saleno", bDtls.saleno);
               cmd.Parameters.AddWithValue("@lotnumber", bDtls.lotnumber);
               cmd.Parameters.AddWithValue("@doLodgDate", bDtls.doLodgDate);
               cmd.Parameters.AddWithValue("@promptdate", bDtls.promptdate);
               cmd.Parameters.AddWithValue("@extdDate", bDtls.extdDate);
               cmd.Parameters.AddWithValue("@weeksdue", bDtls.weeksdue);
               cmd.Parameters.AddWithValue("@addtionalRentBgas", bDtls.addtionalRentBgas);
               cmd.Parameters.AddWithValue("@addtionalRentRate", bDtls.addtionalRentRate);
               cmd.Parameters.AddWithValue("@addtionalRentAmount", bDtls.addtionalRentAmount);
               cmd.Parameters.AddWithValue("@streetRmvBags", bDtls.streetRmvBags);
               cmd.Parameters.AddWithValue("@streetRmvRent", bDtls.streetRmvRent);
               cmd.Parameters.AddWithValue("@streetRmvAmount", bDtls.streetRmvAmount);
               cmd.Parameters.AddWithValue("@chkWghBags", bDtls.chkWghBags);
               cmd.Parameters.AddWithValue("@chkWghRate", bDtls.chkWghRate);
               cmd.Parameters.AddWithValue("@chkWghAmount", bDtls.chkWghAmount);
               cmd.Parameters.AddWithValue("@samplingWghBag", bDtls.samplingWghBag);
               cmd.Parameters.AddWithValue("@samplingRate", bDtls.samplingRate);
               cmd.Parameters.AddWithValue("@samplingAmount", bDtls.samplingAmount);
               cmd.Parameters.AddWithValue("@totalAmount", bDtls.totalAmount);

               cmd.ExecuteNonQuery();


           
           }
            

       }

       private void insertBillInStockLedger(int stockId,int invoiceId,string BillNumber,DateTime deliverydate,int companyId,int yearid,decimal numberofbag,SqlConnection cnn,SqlTransaction trn) { 
       
           using (SqlCommand cmd = new SqlCommand("usp_insertBillInStockLedger", cnn, trn)) {
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@stockId", stockId);
               cmd.Parameters.AddWithValue("@invoiceId", invoiceId);
               cmd.Parameters.AddWithValue("@billNumber", BillNumber);
               cmd.Parameters.AddWithValue("@deliveryDate", deliverydate);
               cmd.Parameters.AddWithValue("@companyId", companyId);
               cmd.Parameters.AddWithValue("@yearId", yearid);
               cmd.Parameters.AddWithValue("@numberofBags", numberofbag);
               cmd.ExecuteNonQuery();

           }
            
       }

       public int updateBuyerBill(BillPOCO Bill)
       {
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               cnn.Open();
               SqlTransaction trn = cnn.BeginTransaction();
               using (SqlCommand cmd = new SqlCommand("usp_updateBillMaster", cnn, trn))
               {

                   try
                   {
                      
                       cmd.CommandType = CommandType.StoredProcedure;

                       cmd.Parameters.AddWithValue("@billId", Bill.billId);
                       cmd.Parameters.AddWithValue("@deliverydate", Bill.deliverydate);
                       cmd.Parameters.AddWithValue("@buyer", Bill.buyer);
                       cmd.Parameters.AddWithValue("@sarkar", Bill.sarkar);
                       cmd.Parameters.AddWithValue("@doNumber", Bill.doNumber);
                       cmd.Parameters.AddWithValue("@doDate", Bill.doDate);
                       cmd.Parameters.AddWithValue("@grandtotalamount", Bill.grandtotalamount);
                       //output paramater
                       cmd.ExecuteNonQuery();

                       deleteBillDetails(Bill.billId, cnn, trn);
                       deleteStockBill(Bill.billnumber, cnn, trn);

                       foreach (var BillDts in Bill.BillDetails)
                       {

                           insertBillDetails(BillDts, Bill.billId, trn, cnn);
                           insertBillInStockLedger(BillDts.stockid, BillDts.invoiceId, Bill.billnumber, Bill.deliverydate, Bill.companyId, Bill.yearId, BillDts.numberofbags, cnn, trn);
                       }


                       trn.Commit();
                       cnn.Close();
                       return 1;




                   }
                   catch (SqlException sExp)
                   {
                       trn.Rollback();
                       cnn.Close();
                       return 0;
                   }

               }

           }
       }

       private void deleteBillDetails(int billMasterId,SqlConnection cnn,SqlTransaction trans) {
           using (SqlCommand cmd = new SqlCommand("usp_deleteBillDetails",cnn,trans))
           {
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@billId", @billMasterId);
               cmd.ExecuteNonQuery();
           
           }
       }
       private void deleteStockBill(string billNumber, SqlConnection cnn, SqlTransaction trans)
       {
           using (SqlCommand cmd = new SqlCommand("usp_BillStockDelete", cnn, trans))
           {
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@billNumber", billNumber);
               cmd.ExecuteNonQuery();

           }
       
       }




       /// <summary>
       /// Get Bill master data based on Id
       /// </summary>
       /// <param name="billMasterId"></param>
       /// <returns>DataTable</returns>
       public DataTable getBuyerBillMasterDataById(int billMasterId) {
           DataTable dt = new DataTable();
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand("usp_getBuyerBillMasterDataById",cnn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@billId",billMasterId);
                   using (SqlDataAdapter dr = new SqlDataAdapter(cmd)) {
                       dr.Fill(dt);
                   }
               
               }
               cnn.Close();

           }
           return dt;
       
       }
       /// <summary>
       /// Get Bill Details based on bill masterId
       /// </summary>
       /// <param name="billMasterId"></param>
       /// <returns></returns>

       public DataTable getBillDetailsByBillMasterId(int billMasterId) {
           DataTable dt = new DataTable();
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand("usp_getBillDetailsByBillMasterId", cnn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@billMasterId", billMasterId);
                   using (SqlDataAdapter dr = new SqlDataAdapter(cmd))
                   {
                       dr.Fill(dt);
                   }

               }
               cnn.Close();

           }
           return dt;
       }



   /********************************/
   }
}
