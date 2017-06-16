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
   public  class StockReportDAL
    {
       public DataTable StockReport(DateTime  AsonDate, int companyId)
       {
           DataTable dt = new DataTable();
           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
              
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand("Usp_StockReport", cnn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@AsonDate", AsonDate);
                   cmd.Parameters.AddWithValue("@companyId", companyId);
                   using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                   {
                       da.Fill(dt);
                   }
               }
               cnn.Close();
           }

           return dt;

       }
    }
}
