using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.viewmodel
{
   public class StockReportVM
    {
        public int StockLedgerId { get; set; }
        public string TransactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransType { get; set; }
        public string Invoice { get; set; }
        public string Grade { get; set; }
        public string Garden { get; set; }
        public string CropYr { get; set; }
        public decimal net { get; set; }
        public decimal StockIn { get; set; }
        public decimal StockOut { get; set; }
        public decimal Balance { get; set; }
        public int Companyid { get; set; }
        public int YearId { get; set; }
    }
}
