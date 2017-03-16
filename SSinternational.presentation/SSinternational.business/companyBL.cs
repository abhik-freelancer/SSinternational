using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.service;
using SSinternational.viewmodel;
namespace SSinternational.business
{
   public class companyBL
    {
       public string getCompanyNameById(int companyId) {

           companySL _companySL = new companySL();

           return _companySL.getCompanyNameById(companyId);
       
       }
    }
}
