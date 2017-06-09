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
    public class EntryBillDAL
    {
        /// <summary>
        /// Get Entry Bill List
        /// </summary>
        /// <param name="company"></param>
        /// <param name="year"></param>
        /// <returns>Data Table</returns>

        public DataTable getEntryBillList(int company,int year) {
            DataTable dt = new DataTable();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString)) {
                using (SqlCommand cmd = new SqlCommand("usp_getEntryBillList",cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter dr = new SqlDataAdapter(cmd)) {
                        dr.Fill(dt);
                    
                    }
                }
            
            }
            return dt;
        }






    }
}
