using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.viewmodel
{
  public class EntryBillDtlVM
    {
        public int EntryBillDetailId { get; set; }
        public int entryBillMasterId { get; set; }
        public string arrivalnumber { get; set; }
        public int arrivalId { get; set; }
        public int invoiceid { get; set; }
        public int receiptbags { get; set; }
    }
}
