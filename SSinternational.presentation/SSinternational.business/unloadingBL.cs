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

        public int UnloadedInvoiceInsert(UnloadingDtlAddEditVM VM) {
            UnloadingDtlSL _SL = new UnloadingDtlSL();
            return _SL.UnloadedInvoiceInsert(VM);
        }

        public UnloadingDtlAddEditVM GetUnloadingDtlById(int unloadingmasterId, int unloadingdetailId) {
            UnloadingDtlSL _SL = new UnloadingDtlSL();
            return _SL.GetUnloadingDtlById(unloadingmasterId, unloadingdetailId);
        
        }
        public IEnumerable<DamageBagDtlsVM> GetDamageBagDetailById(int unloadingDtlId) {
            UnloadingDtlSL _SL = new UnloadingDtlSL();
            return _SL.GetDamageBagDetailById(unloadingDtlId);
        }

        public IEnumerable<ShortBagDtlsVM> GetShoertBagDtlById(int unloadingDtlId) { 
            UnloadingDtlSL _SL = new UnloadingDtlSL();
            return _SL.GetShoertBagDtlById(unloadingDtlId);
        }

        public int UpadateunloadingInvoices(UnloadingDtlAddEditVM _VM) {
            UnloadingDtlSL _SL = new UnloadingDtlSL();
            return _SL.UpadateunloadingInvoices(_VM);
        }
        public int checkInvoiceFormatId(int unloadingmasterId) {
            UnloadingDtlSL _SL = new UnloadingDtlSL();
            return _SL.checkInvoiceFormatId(unloadingmasterId);
        }

        public string getGardenCode(int unloadingmasterId)
        {
            UnloadingDtlSL _SL = new UnloadingDtlSL();
            return _SL.getGardenCode(unloadingmasterId);
        }

        public Boolean gereneratearrival(string unloadingMasterId, string arrivalNumber, string arrivalDate) {
            UnloadingDtlSL _SL = new UnloadingDtlSL();
            return _SL.gereneratearrival(unloadingMasterId, arrivalNumber, arrivalDate);
        }
    }
}
