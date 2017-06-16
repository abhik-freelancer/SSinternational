using SSinternational.service;
using SSinternational.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.business
{
   public class EntryBillBL
    {
       public IEnumerable<EntryBillMasterVM> getEntryBillList(int company, int year) {
           EntryBillSL _SL = new EntryBillSL();
           return _SL.getEntryBillList(company, year);
       }


       public IEnumerable<EntryBillDtlVM> getArrivalInvoices(int arrivalId) {
           EntryBillSL _SL = new EntryBillSL();
           return _SL.getArrivalInvoices(arrivalId);
       
       
       }

       public ratemasterVM getEntryRentRate(int companyId, int yearId) {
           EntryBillSL _SL = new EntryBillSL();
           ratemasterVM _vm = _SL.getEntryRentRate(companyId, yearId);
           return _vm;
       
       }

    }
}
