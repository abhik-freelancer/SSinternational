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
    public class UnloadingDtlSL
    {
        public IEnumerable<UnloadingDtlListVM> getListOfUnloadingInvoices(int unloadingmasterId) {
            UnloadingDetails _unldDtlPOCO = new UnloadingDetails();
            IEnumerable<UnloadingDtlListVM> _lstVM = Mapper.Map<IEnumerable<UnloadingDetails>, IEnumerable<UnloadingDtlListVM>>(_unldDtlPOCO.getListOfUnloadingInvoices(unloadingmasterId));
            return _lstVM;
        
        }
    }
}
