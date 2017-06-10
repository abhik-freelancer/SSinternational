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

    }
}
