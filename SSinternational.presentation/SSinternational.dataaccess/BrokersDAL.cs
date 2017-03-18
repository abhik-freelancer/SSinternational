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
  internal  class BrokersDAL
    {

      public DataTable GetAllBrokers()
      {
          DataSet ds = new DataSet();
          using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
          {
              cnn.Open();
              using (SqlCommand cmd = new SqlCommand("Usp_BrokerGetAll", cnn))
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

      public DataTable GetBrokerById(int BrokerId)
      {
          DataSet ds = new DataSet();
          using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
          {
              cnn.Open();
              using (SqlCommand cmd = new SqlCommand("Usp_BrokerGetById", cnn))
              {
                  SqlDataAdapter da;
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@BrokerId", BrokerId);
                  da = new SqlDataAdapter(cmd);
                  da.Fill(ds);
              }
              cnn.Close();

          }

          return ds.Tables[0];
      }

        /**
        * Method:InsertBroker
        * param:Brokers _broker
        * return: (int) BrokerId
        * date:17-03-2017 Shibu
        * */
        public int InsertBroker(Brokers _broker)
        {
            int BrokerId = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_BrokerInsert", cnn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BrokerCode", _broker.BrokerCode);
                    cmd.Parameters.AddWithValue("@BrokerName", _broker.BrokerName);
                    if (_broker.EstateId == 0)
                    {
                        cmd.Parameters.AddWithValue("@EstateId", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@EstateId", _broker.EstateId);
                    }
                  
                    cmd.Parameters.Add("@BrokerId", SqlDbType.Int);
                    cmd.Parameters["@BrokerId"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    BrokerId = Convert.ToInt32(cmd.Parameters["@BrokerId"].Value);

                }
                cnn.Close();

            }

            return BrokerId;
        }

        /**
         * Method:UpdateBroker
         * param:Brokers _broker
         * return: (int) BrokerId
         * date:17-03-2017 Shibu
         * */
        public int UpdateBroker(Brokers _broker)
        {
            int BrokerId = 0;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Usp_BrokerUpdate", cnn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BrokerCode", _broker.BrokerCode);
                        cmd.Parameters.AddWithValue("@BrokerName", _broker.BrokerName);
                        if (_broker.EstateId == 0)
                        {
                            cmd.Parameters.AddWithValue("@EstateId", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@EstateId", _broker.EstateId);
                        }
                        cmd.Parameters.AddWithValue("@BrokerId", _broker.BrokerId);
                        cmd.ExecuteNonQuery();
                        BrokerId = Convert.ToInt32(cmd.Parameters["@BrokerId"].Value);
                    }
                    catch
                    {
                        BrokerId = 0;
                    }
                }
                cnn.Close();
            }
            return BrokerId;
        }

        public Boolean DeleteByBrokerId(int BrokerId)
        {

            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString))
            {
                try
                {

                    using (SqlCommand cmd = new SqlCommand("Usp_BrokerDeleteById", cnn))
                    {
                        cnn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BrokerId", BrokerId);
                        cmd.ExecuteNonQuery();

                    }
                    cnn.Close();
                    return true;
                }

                catch
                {
                    cnn.Close();
                    return false;
                }

            }
        }
    }
}
