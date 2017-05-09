using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.viewmodel;
using SSinternational.service;

namespace SSinternational.business
{
    public class ArrivalBL
    {

         /// <summary>
       /// Getting list of arrival master
       /// </summary>
       /// <param name="companyId"></param>
       /// <param name="yearId"></param>
       /// <returns></returns>
        public IEnumerable<ArrivalMasterVM> getArrivalMasterList(int companyId, int yearId) {
            ArrivalSL _SL = new ArrivalSL();
            return _SL.getArrivalMasterList(companyId, yearId);
        }

       /// <summary>
       /// Insertion of arrival master
       /// </summary>
       /// <param name="_arrivalMaster"></param>
       /// <returns>int</returns>
        public int arrivalMasterInsertion(ArrivalMasterVM _VM) {
            ArrivalSL _SL = new ArrivalSL();
            return _SL.arrivalMasterInsertion(_VM);
        
        }


       /// <summary>
       /// arrivalMasterUpdate
       /// </summary>
       /// <param name="_arrivalMaster"></param>
       /// <returns>int</returns>

        public int arrivalMasterUpdate(ArrivalMasterVM _VM)
        {
            ArrivalSL _SL = new ArrivalSL();
            return _SL.arrivalMasterUpdate(_VM);
        
        }

        /// <summary>
        /// Get arrival master by Id for edit data fetch
        /// </summary>
        /// <param name="arrivalmasterid"></param>
        /// <returns></returns>
        public ArrivalMasterVM getArrivalMasterById(int arrivalmasterid)
        {
            ArrivalSL _SL = new ArrivalSL();
            return _SL.getArrivalMasterById(arrivalmasterid);
        }

        /// <summary>
        /// getArrivalInvoicesList
        /// </summary>
        /// <param name="arrivalId"></param>
        /// <returns></returns>
        public IEnumerable<ArrivalInvoicesListVM> getArrivalInvoicesList(int arrivalId) {
            ArrivalSL _SL = new ArrivalSL();
            return _SL.getArrivalInvoicesList(arrivalId);
        }



        public int getNumberofInvoices(int arrivalId)
        {

            ArrivalSL _SL = new ArrivalSL();
            return _SL.getNumberofInvoices(arrivalId);
        }

        public int checkInvoiceFormatId(int arrivalId)
        {
            ArrivalSL _SL = new ArrivalSL();
            return _SL.checkInvoiceFormatId(arrivalId);
        }

        public string getGardenCode(int arrivalId)
        {
            ArrivalSL _SL = new ArrivalSL();
            return _SL.getGardenCode(arrivalId);
        }

        public int arrivalInvoicesInsertion(ArrivalDtlAddEditVM _VM)
        {
            ArrivalSL _SL = new ArrivalSL();
            return _SL.arrivalInvoicesInsertion(_VM);

        }


        public IEnumerable<DamageBagDtlsVM> GetDamageBagDetailById(int arrivalId)
        {
            ArrivalSL _SL = new ArrivalSL();
            return _SL.GetDamageBagDetailById(arrivalId);
        }

        public IEnumerable<ShortBagDtlsVM> GetShoertBagDtlById(int arrivalId)
        {
            ArrivalSL _SL = new ArrivalSL();
            return _SL.GetShoertBagDtlById(arrivalId);
        }

        public ArrivalDtlAddEditVM GetArrivalDtlById(int arrivalMasterId, int arrivalDetailId) {
            ArrivalSL _SL = new ArrivalSL();
            return _SL.GetArrivalDtlById(arrivalMasterId, arrivalDetailId);
        }

        public int UpadateunloadingInvoices(ArrivalDtlAddEditVM _VM)
        {
            ArrivalSL _SL = new ArrivalSL();
            return _SL.UpadateunloadingInvoices(_VM);
        }
    }
}
