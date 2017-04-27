using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.service;
using SSinternational.viewmodel;

namespace SSinternational.business
{
    public class unloadingBL
    {
        public int insertUnloadingMaster(UnloadingmasterVM _VM) {
            unloadingMasterSL _unldmst = new unloadingMasterSL();
            return _unldmst.insertUnloadingMaster(_VM);
        }

        public IEnumerable<UnloadingmasterVM> getUnloadingMasterList(int companyId, int yearId)
        {
            unloadingMasterSL _sl = new unloadingMasterSL();
            IEnumerable<UnloadingmasterVM> _unldVM = _sl.getUnloadingMasterList(companyId, yearId);
            return _unldVM;
        }

        public Boolean deleteUnloadingMaster(int unloadmasterId) {
            unloadingMasterSL _sl = new unloadingMasterSL();
            return _sl.deleteUnloadingMaster(unloadmasterId);
        
        }
        public void updateUnloadMaster(UnloadingmasterVM _VM) {
            unloadingMasterSL _SL = new unloadingMasterSL();
            _SL.updateUnloadMaster(_VM);
        }

        public UnloadingmasterVM getUnldMasterDataById(int unloadmstId){
            unloadingMasterSL _SL = new unloadingMasterSL();
            return _SL.getUnldMasterDataById(unloadmstId);
        }

        public int getNumberofInvoices(int unloadingmasterId){
            unloadingMasterSL _SL = new unloadingMasterSL();
            return _SL.getNumberofInvoices(unloadingmasterId);
        
        }

        public IEnumerable<UnloadingDtlListVM> getListOfUnloadingInvoices(int unloadingmasterId) {
            UnloadingDtlSL _SL = new UnloadingDtlSL();
            return _SL.getListOfUnloadingInvoices(unloadingmasterId);
        }

    }
}
