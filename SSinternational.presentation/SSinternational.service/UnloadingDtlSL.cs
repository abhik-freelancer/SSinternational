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

        public int UnloadedInvoiceInsert(UnloadingDtlAddEditVM VM) {
            UnloadingDetails _unloadingPOCO = new UnloadingDetails();
            _unloadingPOCO= Mapper.Map<UnloadingDtlAddEditVM, UnloadingDetails>(VM);
            return _unloadingPOCO.UnloadedInvoiceInsert(_unloadingPOCO);
        }

        public UnloadingDtlAddEditVM GetUnloadingDtlById(int unloadingmasterId, int unloadingdetailId)
        {
            UnloadingDetails _unloadingPOCO = new UnloadingDetails();
            UnloadingDtlAddEditVM _VM = new UnloadingDtlAddEditVM();
            _VM = Mapper.Map<UnloadingDetails, UnloadingDtlAddEditVM>(_unloadingPOCO.GetUnloadingDtlById(unloadingmasterId, unloadingdetailId));
            return _VM;
        
        }

        public IEnumerable<DamageBagDtlsVM> GetDamageBagDetailById(int unloadingDtlId) {
            DamageBagDtl _damageBagDetails = new DamageBagDtl();
            IEnumerable<DamageBagDtlsVM> _dmgBagDtls = Mapper.Map<IEnumerable<DamageBagDtl>, IEnumerable<DamageBagDtlsVM>>(_damageBagDetails.GetDamageBagDetailById(unloadingDtlId));
            return _dmgBagDtls;
        
        }

        public IEnumerable<ShortBagDtlsVM> GetShoertBagDtlById(int unloadingDtlId)
        {
            ShortBagDtls _shrtBagDtls = new ShortBagDtls();
            IEnumerable<ShortBagDtlsVM> _shrtBagDtl = Mapper.Map<IEnumerable<ShortBagDtls>, IEnumerable<ShortBagDtlsVM>>(_shrtBagDtls.GetShoertBagDtlById(unloadingDtlId));
            return _shrtBagDtl;

        }

        public int UpadateunloadingInvoices(UnloadingDtlAddEditVM _VM) {
            UnloadingDetails _unloadingDetails = new UnloadingDetails();
            _unloadingDetails = Mapper.Map<UnloadingDtlAddEditVM, UnloadingDetails>(_VM);
            return _unloadingDetails.UpadateunloadingInvoices(_unloadingDetails);
        
        }

        public int checkInvoiceFormatId(int unloadingmasterId) {
            UnloadingDetails _unloadingDetails = new UnloadingDetails();
            return _unloadingDetails.checkInvoiceFormatId(unloadingmasterId);
        }

        public string getGardenCode(int unloadingmasterId) {
            UnloadingDetails _unloadingDetails = new UnloadingDetails();
            return _unloadingDetails.getGardenCode(unloadingmasterId);
        }


    }
}
