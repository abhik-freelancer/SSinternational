using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.viewmodel
{
    public class BillDetailsVM
    {
        public int BillDetailid { get; set; }
        public int billmasterid { get; set; }
        public int stockid { get; set; }
        public int invoiceId { get; set; }
        public string invoice { get; set; }
        public int numberofbags { get; set; }
        public string saleno { get; set; }
        public string lotnumber { get; set; }
        public Nullable<DateTime> doLodgDate { get; set; }
        public Nullable<DateTime> promptdate { get; set; }
        public Nullable<DateTime> extdDate { get; set; }
        public Decimal weeksdue { get; set; }
        public int addtionalRentBgas { get; set; }
        public decimal addtionalRentRate { get; set; }
        public decimal addtionalRentAmount { get; set; }
        public int streetRmvBags { get; set; }
        public decimal streetRmvRent { get; set; }
        public decimal streetRmvAmount { get; set; }
        public int chkWghBags { get; set; }
        public decimal chkWghRate { get; set; }
        public decimal chkWghAmount { get; set; }
        public int samplingWghBag { get; set; }
        public decimal samplingRate { get; set; }
        public decimal samplingAmount { get; set; }
        public decimal totalAmount { get; set; }
    }
}
