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
   public class floorsDAL
    {
       public DataTable getFloorList() {
           DataSet ds = new DataSet();

           using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
           {
           
               cnn.Open();
               using (SqlCommand cmd = new SqlCommand("usp_getFloorList",cnn))
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
    }
}
