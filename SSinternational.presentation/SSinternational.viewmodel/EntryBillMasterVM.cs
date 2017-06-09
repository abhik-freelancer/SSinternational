using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SSinternational.viewmodel
{
    public class EntryBillMasterVM
    {
        public int EntryBillId { get; set; }
        public string EntryBillNumber { get; set; }
        public DateTime EntrybillDate { get; set; }
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public int Garden { get; set; }
        public string gardencode { get; set; }
        public int BrokerId { get; set; }
        public string BrokerName { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public int companyId { get; set; }
        public int yearId { get; set; }
        public decimal totalBillAmount { get; set; }
        public decimal Rate { get; set; }
        public int totalBags { get; set; }
    }
}
