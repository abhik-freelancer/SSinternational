using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.dataaccess.POCO
{
    public class Brokers
    {
      #region Propertices
        public int BrokerId{get;set;}
        public string BrokerCode{get;set;}
        public string BrokerName{get;set;}
        public int EstateId{get;set;}
        public string EstateName{get;set;}

     #endregion

        public int InsertBroker(Brokers _broker)
        {
            BrokersDAL _DAL = new BrokersDAL();
            return _DAL.InsertBroker(_broker);

        }

        public int UpdateBroker(Brokers _broker)
        {
            BrokersDAL _DAL = new BrokersDAL();
            return _DAL.UpdateBroker(_broker);

        }
        public Boolean DeleteByBrokerId(int BrokerId)
        {
            BrokersDAL _DAL = new BrokersDAL();
            return _DAL.DeleteByBrokerId(BrokerId);

        }

        public Brokers GetBrokerById(int BrokerId)
        {
            BrokersDAL _DAL = new BrokersDAL();
            DataTable dt = _DAL.GetBrokerById(BrokerId);
            Brokers _broker = new Brokers();
            if (dt.Rows.Count > 0)
            {
                _broker.BrokerId = Convert.ToInt32(dt.Rows[0]["BrokerId"].ToString());
                _broker.BrokerCode = (dt.Rows[0]["BrokerCode"].ToString());
                _broker.BrokerName = (dt.Rows[0]["BrokerName"].ToString());
                _broker.EstateId = dt.Rows[0]["EstateId"]==DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["EstateId"].ToString());
                _broker.EstateName = (dt.Rows[0]["EstateName"].ToString());
            }
            return _broker;
        }

        public IEnumerable<Brokers> GetAllBrokers()
        {
            BrokersDAL _DAL = new BrokersDAL();
            DataTable dt = _DAL.GetAllBrokers();
            List<Brokers> _brokerList = new List<Brokers>();
          


            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Brokers _broker = new Brokers();
                    _broker.BrokerId = Convert.ToInt32(dt.Rows[i]["BrokerId"].ToString());
                    _broker.BrokerCode = (dt.Rows[i]["BrokerCode"].ToString());
                    _broker.BrokerName = (dt.Rows[i]["BrokerName"].ToString());
                    _broker.EstateId = dt.Rows[i]["EstateId"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["EstateId"].ToString());
                    _broker.EstateName = (dt.Rows[i]["EstateName"].ToString());
                    _brokerList.Add(_broker);
                }
            }
            return _brokerList;
        }
    }
}
