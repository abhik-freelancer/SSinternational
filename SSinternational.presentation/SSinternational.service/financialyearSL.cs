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
   public class financialyearSL
    {
       public IEnumerable<financialVM> getfinancialyearsList() {
           financialyears _financialPOCO = new financialyears();
           IEnumerable<financialVM> _financialVM = Mapper.Map<IEnumerable<financialyears>,IEnumerable<financialVM>>(_financialPOCO.getfinancialyearsList());
           return _financialVM;
       }
    }
}
