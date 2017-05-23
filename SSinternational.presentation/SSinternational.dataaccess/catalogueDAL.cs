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
   public  class catalogueDAL
    {
       public DataTable getArrivalListByGardenId(int gardenId) {

           DataSet ds = new DataSet();
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand("usp_getArrivalByGardenId",cnn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@gardenId", gardenId);
                   SqlDataAdapter dr = new SqlDataAdapter(cmd);
                   dr.Fill(ds);
               
               }
               cnn.Close();
           }
           return ds.Tables[0];
       }

       public DataTable getChestSerialRangeByArrivalDtlId(int arvlDtlId) {

           DataTable dt = new DataTable();
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               string sql ="SELECT arrivalDetail.pkgsrlfrm,arrivalDetail.pkgsrlto FROM arrivalDetail WHERE arrivalDetail.id ="+arvlDtlId ;
               cnn.Open();
               using(SqlCommand cmd =  new SqlCommand(sql,cnn)){
                using(SqlDataAdapter adapter = new SqlDataAdapter(cmd)){
                        adapter.Fill(dt);
                
                }
               }
               cnn.Close();
           }
           return dt;
       }

       public int catalogueInsert(Catalogue _catalogue) {

           int insertion = 0;
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString)) {

               cnn.Open();
               SqlTransaction sqlTrans = cnn.BeginTransaction();
               using (SqlCommand cmd = new SqlCommand("usp_catalogueInsert", cnn, sqlTrans))
               {
                   
                   try
                   {
                       #region
                       string catalogueNumber = getAutoNumber(_catalogue.companyId, _catalogue.yearId, "CATALOGUE");
                       cmd.CommandType = CommandType.StoredProcedure;
                       cmd.Parameters.AddWithValue("@catalognumber", catalogueNumber);
                       cmd.Parameters.AddWithValue("@catalougedate", _catalogue.catalougedate);
                       cmd.Parameters.AddWithValue("@arrivalInvoiceId", _catalogue.arrivalInvoiceId);
                       cmd.Parameters.AddWithValue("@saleNumber", _catalogue.saleNumber);
                       cmd.Parameters.AddWithValue("@lotNumber", _catalogue.lotNumber);
                       cmd.Parameters.AddWithValue("@brokerId", _catalogue.brokerId);
                       cmd.Parameters.AddWithValue("@bagSerial", _catalogue.bagSerial);
                       cmd.Parameters.AddWithValue("@net", DBNull.Value);
                       cmd.Parameters.AddWithValue("@sampleqty", DBNull.Value);
                       cmd.Parameters.AddWithValue("@companyId", _catalogue.companyId);
                       cmd.Parameters.AddWithValue("@yearId", _catalogue.yearId);
                       cmd.ExecuteNonQuery();

                       sqlTrans.Commit();
                       cnn.Close();
                       insertion = 1;

                       #endregion
                   }
                   catch (SqlException sExp) {
                       sqlTrans.Rollback();
                       cnn.Close();
                        
                   }
               }
               cnn.Close();
           
           }
           return insertion;
       
       
       }

       public void update(Catalogue _catalogue) {

           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {

               cnn.Open();
               SqlTransaction sqlTrans = cnn.BeginTransaction();
               using (SqlCommand cmd = new SqlCommand("usp_catalogueUpdate", cnn, sqlTrans))
               {

                   try
                   {
                       #region
                       
                       cmd.CommandType = CommandType.StoredProcedure;


                       cmd.Parameters.AddWithValue("@catalogId", _catalogue.catalogId);
                       cmd.Parameters.AddWithValue("@catalougedate", _catalogue.catalougedate);
                       cmd.Parameters.AddWithValue("@saleNumber", _catalogue.saleNumber);
                       cmd.Parameters.AddWithValue("@lotNumber", _catalogue.lotNumber);
                       cmd.Parameters.AddWithValue("@brokerId", _catalogue.brokerId);
                       cmd.Parameters.AddWithValue("@bagSerial", _catalogue.bagSerial);
                      
                       
                       cmd.ExecuteNonQuery();

                       sqlTrans.Commit();
                       cnn.Close();
                       

                       #endregion
                   }
                   catch (SqlException sExp)
                   {
                       sqlTrans.Rollback();
                       cnn.Close();

                   }
               }
               cnn.Close();

           }
       
       
       }
       private string getAutoNumber(int companyId, int yearId, string module)
       {
           string catalogueNo = "";
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
                   catalogueNo = cmd.Parameters["@autonumber"].Value.ToString();
               }
               cnn.Close();
           }
           return catalogueNo;
       }


       public DataTable getArrivalInvoiceDetail(int invoiceId) {

           DataTable dt = new DataTable();
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString)) 
           {
               string sql = "SELECT [arrivalDetail].[id]" +
                             ",[arrivalDetail].[arrivalId]" +
                             ",[arrivalDetail].[invoice]" +
                             ",[arrivalDetail].[grade]" +
                             ",[arrivalDetail].[yearofproduction]" +
                             ",[arrivalDetail].[pkgsrlfrm]" +
                             ",[arrivalDetail].[pkgsrlto]" +
                             ",[arrivalDetail].[receivequantity]" +
                             ",[arrivalDetail].[net]" +
                             ",[arrivalMaster].arrivalNumber,CONVERT(varchar(10),[arrivalMaster].[dateofarrival],105)as dateofarrival" +
                       " FROM [arrivalDetail] INNER JOIN  arrivalMaster ON [arrivalDetail].arrivalId = arrivalMaster.arrivalId WHERE [arrivalDetail].id="+invoiceId;
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


       public DataTable getcatalogListByInvoiceId(int invoiceDetailsId) {
           DataSet ds = new DataSet();
           //CustomersTableAdapter.Fill(CustomersDataTable)
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand("usp_catalogListByInvoiceId", cnn)) 
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@arrivalInvoiceId", invoiceDetailsId);
                   cmd.ExecuteNonQuery();
                   SqlDataAdapter dr = new SqlDataAdapter(cmd);
                   dr.Fill(ds);
               }
               cnn.Close();
           
           
           }
           return ds.Tables[0];
       
       }

       public DataTable getCatalogueById(int ctlgId) {

           DataSet ds = new DataSet();
           //CustomersTableAdapter.Fill(CustomersDataTable)
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand("usp_getCatalogueById", cnn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@catalogId", ctlgId);
                   cmd.ExecuteNonQuery();
                   SqlDataAdapter dr = new SqlDataAdapter(cmd);
                   dr.Fill(ds);
               }
               cnn.Close();


           }
           return ds.Tables[0];
       
       }

       /***********************************/
    }

}
