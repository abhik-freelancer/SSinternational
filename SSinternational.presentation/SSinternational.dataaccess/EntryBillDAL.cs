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
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_getEntryBillList",cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@companyId", company);
                    cmd.Parameters.AddWithValue("@yearId", year);
                    using (SqlDataAdapter dr = new SqlDataAdapter(cmd)) {
                        dr.Fill(dt);
                    
                    }
                }
                cnn.Close();
            
            }
            return dt;
        }

        public DataTable getArrivalInvoices(int arrivalId) {
            DataTable dt = new DataTable();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_arrivalInvoicesNotinEntryBill",cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@arrivalId", arrivalId);
                    using(SqlDataAdapter dr = new SqlDataAdapter(cmd)){
                        dr.Fill(dt);
                    }
                }
                cnn.Close();
            
            }
            return dt;
        }







    }
}
