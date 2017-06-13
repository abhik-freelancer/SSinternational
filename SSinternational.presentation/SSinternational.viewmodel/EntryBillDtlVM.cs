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
        public string invoice { get; set; }
        public decimal receiptbags { get; set; }
        public string grade { get; set; }
        public decimal nett { get; set; }
    }
}
