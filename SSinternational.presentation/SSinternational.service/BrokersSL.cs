using AutoMapper;
using SSinternational.dataaccess.POCO;
using SSinternational.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.service
{
   public  class BrokersSL
    {
       public int InsertBroker(BrokersVM _broker)
        {
            Brokers _brokerpoco = new Brokers();
            _brokerpoco = Mapper.Map<BrokersVM, Brokers>(_broker);
            return _brokerpoco.InsertBroker(_brokerpoco);


        }

       public int UpdateBroker(BrokersVM _broker)
        {
            Brokers _brokerpoco = new Brokers();
            _brokerpoco = Mapper.Map<BrokersVM, Brokers>(_broker);
            return _brokerpoco.UpdateBroker(_brokerpoco);

        }
       public Boolean DeleteByBrokerId(int BrokerId)
        {
            Brokers _brokerpoco = new Brokers();
            return _brokerpoco.DeleteByBrokerId(BrokerId);

        }

       public BrokersVM GetBrokerById(int BrokerId)
        {
            Brokers _brokerpoco = new Brokers();
            return Mapper.Map<Brokers, BrokersVM>(_brokerpoco.GetBrokerById(BrokerId));

        }

       public IEnumerable<BrokersVM> GetAllBrokers()
        {
            Brokers _brokerpoco = new Brokers();
            return Mapper.Map<IEnumerable<Brokers>, IEnumerable<BrokersVM>>(_brokerpoco.GetAllBrokers());

        }
    }
}
