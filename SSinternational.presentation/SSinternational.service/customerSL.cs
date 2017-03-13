using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SSinternational.viewmodel;
using SSinternational.dataaccess.POCO;

namespace SSinternational.service
{
    public class customerSL
    {
        public IEnumerable<CustomerVM> getCustomerList(int companyId)
        {
            customers _customerPOCO = new customers();
            IEnumerable<CustomerVM> _customerVM = Mapper.Map<IEnumerable<customers>, IEnumerable<CustomerVM>>(_customerPOCO.getCustomerList(companyId));
            return _customerVM;

        }

        public int insertCustomer(CustomerVM _customerVM) {
            customers _customerPOCO = new customers();
            _customerPOCO = Mapper.Map<CustomerVM, customers>(_customerVM);
            return _customerPOCO.insertCustomer(_customerPOCO);
        
        }

        public CustomerVM getCustomerById(int customerId) {

            customers _customerPOCO = new customers();
            CustomerVM _customerVM = Mapper.Map<customers, CustomerVM>(_customerPOCO.getCustomerById(customerId));
            return _customerVM;
        
        }

        public void upadateCustomer(CustomerVM _customerVM) {

            customers _customerPOCO = new customers();
            _customerPOCO = Mapper.Map<CustomerVM, customers>(_customerVM);
            _customerPOCO.upadateCustomer(_customerPOCO);
        
        }

        public Boolean deleteCustomer(int customerId) {
            customers _customerPOCO = new customers();
            return _customerPOCO.DeleteCustomer(customerId);
        
        
        }
    }
}
