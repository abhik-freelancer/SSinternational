using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.dataaccess.POCO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data; 


namespace SSinternational.dataaccess
{
  public  class financialyearsDAL
    {
      public DataTable getFiscalList() {
        
          DataSet ds = new DataSet();

          using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
          {
              cnn.Open();
              using (SqlCommand cmd = new SqlCommand("usp_getFiscalList", cnn))
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
      public DataTable getFiscalYearById(int YearId)
      {

          DataSet ds = new DataSet();

          using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
          {
              cnn.Open();
              using (SqlCommand cmd = new SqlCommand("usp_getFiscalYearById", cnn))
              {
                  SqlDataAdapter da;
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@YearId", YearId);
                  da = new SqlDataAdapter(cmd);
                  da.Fill(ds);
              }
              cnn.Close();
          }

          return ds.Tables[0];

      }
    }
}
