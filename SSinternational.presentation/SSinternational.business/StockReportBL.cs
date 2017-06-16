using SSinternational.service;
using SSinternational.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.business
{
   public class StockReportBL
    {
       public IEnumerable<StockReportVM> GetStock(DateTime Asondate, int CompanyId)
       {
           StockReportSL _sl = new StockReportSL();
           return _sl.GetStock(Asondate, CompanyId);
       }
    }
}
