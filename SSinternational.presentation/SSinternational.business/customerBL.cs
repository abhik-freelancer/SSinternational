using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.service;
using SSinternational.viewmodel;

namespace SSinternational.business
{
   public class customerBL
    {
       public IEnumerable<CustomerVM> getCustomerList(int companyId)
       {
           customerSL _customerSL = new customerSL();
           return _customerSL.getCustomerList(companyId); 
       }


       public int insertCustomer(CustomerVM _custVM) {
           int insertion = 0;
           customerSL _customerSL = new customerSL();
           insertion = _customerSL.insertCustomer(_custVM);
           return insertion;
       }

       public CustomerVM getCustomerById(int customerId) {
           customerSL _customerSL = new customerSL();
           return _customerSL.getCustomerById(customerId);
       
       }

       public void upadateCustomer(CustomerVM _custVM) {
           customerSL _customerEditSL = new customerSL();
           _customerEditSL.upadateCustomer(_custVM);
       
       }

       public Boolean deleteCustomer(int customerId) {

           customerSL _customerSL = new customerSL();
           return _customerSL.deleteCustomer(customerId);
       
       }
    }
}
