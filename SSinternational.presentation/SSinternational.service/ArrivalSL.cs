using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.dataaccess.POCO;
using SSinternational.viewmodel;
using AutoMapper;

namespace SSinternational.service
{
   public class ArrivalSL
    {
       /// <summary>
       /// Getting list of arrival master
       /// </summary>
       /// <param name="companyId"></param>
       /// <param name="yearId"></param>
       /// <returns></returns>
       public IEnumerable<ArrivalMasterVM> getArrivalMasterList(int companyId, int yearId) {
           ArrivalMaster _arrivalMasterPOCO = new ArrivalMaster();
           IEnumerable<ArrivalMasterVM> _VM = Mapper.Map<IEnumerable<ArrivalMaster>, IEnumerable<ArrivalMasterVM>>(_arrivalMasterPOCO.getArrivalMasterList(companyId, yearId));
           return _VM;
       }


        /// <summary>
       /// Insertion of arrival master
       /// </summary>
       /// <param name="_arrivalMaster"></param>
       /// <returns>int</returns>
       public int arrivalMasterInsertion(ArrivalMasterVM _VM) {
           int lastinsrtid = 0;
           ArrivalMaster _arrivalMasterPOCO = new ArrivalMaster();
           _arrivalMasterPOCO = Mapper.Map<ArrivalMasterVM, ArrivalMaster>(_VM);
           lastinsrtid = _arrivalMasterPOCO.arrivalMasterInsertion(_arrivalMasterPOCO);
           return lastinsrtid;
       
       
       }

       /// <summary>
       /// arrivalMasterUpdate
       /// </summary>
       /// <param name="_arrivalMaster"></param>
       /// <returns>int</returns>

       public int arrivalMasterUpdate(ArrivalMasterVM _VM)
       {

           int updt = 0;
           ArrivalMaster _arrivalMasterPOCO = new ArrivalMaster();
           _arrivalMasterPOCO = Mapper.Map<ArrivalMasterVM, ArrivalMaster>(_VM);
           updt = _arrivalMasterPOCO.arrivalMasterUpdate(_arrivalMasterPOCO);
           return updt;
       }

        /// <summary>
       /// Get arrival master by Id for edit data fetch
       /// </summary>
       /// <param name="arrivalmasterid"></param>
       /// <returns></returns>
       public ArrivalMasterVM getArrivalMasterById(int arrivalmasterid) {
           ArrivalMasterVM _VM = new ArrivalMasterVM();
           ArrivalMaster _arrivalMasterPOCO = new ArrivalMaster();
           _VM = Mapper.Map<ArrivalMaster, ArrivalMasterVM>(_arrivalMasterPOCO.getArrivalMasterById(arrivalmasterid));
           return _VM;
       
       }

       /// <summary>
       /// getArrivalInvoicesList
       /// </summary>
       /// <param name="arrivalId"></param>
       /// <returns></returns>

       public IEnumerable<ArrivalInvoicesListVM> getArrivalInvoicesList(int arrivalId) {
           ArrivalInvoices _arrivalInvoicesPOCO = new ArrivalInvoices();
           IEnumerable<ArrivalInvoicesListVM> _VM = Mapper.Map<IEnumerable<ArrivalInvoices>, IEnumerable<ArrivalInvoicesListVM>>(_arrivalInvoicesPOCO.getArrivalInvoicesList(arrivalId));
           return _VM; 
       }

       public int getNumberofInvoices(int arrivalId) {

           ArrivalInvoices _arrivalInvoicesPOCO = new ArrivalInvoices();
           return _arrivalInvoicesPOCO.getNumberofInvoices(arrivalId);
       }


       public int checkInvoiceFormatId(int arrivalId)
       {
           ArrivalInvoices _arrivalInvoicesPOCO = new ArrivalInvoices();
           return _arrivalInvoicesPOCO.checkInvoiceFormatId(arrivalId);
       }

       public string getGardenCode(int arrivalId)
       {
           ArrivalInvoices _arrivalInvoicesPOCO = new ArrivalInvoices();
           return _arrivalInvoicesPOCO.getGardenCode(arrivalId);
       }
       /// <summary>
       /// arrival invoices save
       /// </summary>
       /// <param name="_VM"></param>
       /// <returns></returns>

       public int arrivalInvoicesInsertion(ArrivalDtlAddEditVM _VM) {
           ArrivalInvoices _arrivalInvoicesPOCO = new ArrivalInvoices();
           _arrivalInvoicesPOCO = Mapper.Map<ArrivalDtlAddEditVM, ArrivalInvoices>(_VM);
           return _arrivalInvoicesPOCO.arrivalInvoicesInsertion(_arrivalInvoicesPOCO);
       
       }


       public IEnumerable<DamageBagDtlsVM> GetDamageBagDetailById(int arrivalDtlId)
       {
           DamageBagDtl _damageBagDetails = new DamageBagDtl();
           IEnumerable<DamageBagDtlsVM> _dmgBagDtls = Mapper.Map<IEnumerable<DamageBagDtl>, IEnumerable<DamageBagDtlsVM>>(_damageBagDetails.GetArrivedDamageBagDetailById(arrivalDtlId));
           return _dmgBagDtls;

       }

       public IEnumerable<ShortBagDtlsVM> GetShoertBagDtlById(int arrivalDtlId)
       {
           ShortBagDtls _shrtBagDtls = new ShortBagDtls();
           IEnumerable<ShortBagDtlsVM> _shrtBagDtl = Mapper.Map<IEnumerable<ShortBagDtls>, IEnumerable<ShortBagDtlsVM>>(_shrtBagDtls.GetArrivedShortBagDtlById(arrivalDtlId));
           return _shrtBagDtl;

       }


       public ArrivalDtlAddEditVM GetArrivalDtlById(int arrivalMasterId, int arrivalDetailId) {
           ArrivalInvoices _arrivalInvoicesPOCO = new ArrivalInvoices();
           ArrivalDtlAddEditVM _VM = Mapper.Map<ArrivalInvoices, ArrivalDtlAddEditVM>(_arrivalInvoicesPOCO.GetArrivalDtlById(arrivalMasterId, arrivalDetailId));
           return _VM;
       
       }


       public int UpadateunloadingInvoices(ArrivalDtlAddEditVM _VM)
       {
           ArrivalInvoices _arrivalInvoicesPOCO = new ArrivalInvoices();
           _arrivalInvoicesPOCO = Mapper.Map<ArrivalDtlAddEditVM, ArrivalInvoices>(_VM);
           return _arrivalInvoicesPOCO.UpadateunloadingInvoices(_arrivalInvoicesPOCO);

       }

    }
}
