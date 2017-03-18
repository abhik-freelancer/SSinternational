using SSinternational.service;
using SSinternational.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.business
{
   public class BrokersBL
    {
       public int InsertBroker(BrokersVM _broker)
        {
            BrokersSL _SL = new BrokersSL();

            return _SL.InsertBroker(_broker);


        }

       public int UpdateBroker(BrokersVM _broker)
        {
            BrokersSL _SL = new BrokersSL();

            return _SL.UpdateBroker(_broker);

        }
       public Boolean DeleteByBrokerId(int BrokerId)
        {
            BrokersSL _SL = new BrokersSL();

            return _SL.DeleteByBrokerId(BrokerId);

        }

       public BrokersVM GetBrokerById(int BrokerId)
        {
            BrokersSL _SL = new BrokersSL();

            return _SL.GetBrokerById(BrokerId);


        }

       public IEnumerable<BrokersVM> GetAllBrokers()
        {
            BrokersSL _SL = new BrokersSL();
            return _SL.GetAllBrokers();

        }
    }
}
