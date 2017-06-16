using SSinternational.dataaccess.POCO;
using SSinternational.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.service
{
    public class StockReportSL
    {
        public IEnumerable<StockReportVM> GetStock(DateTime Asondate, int CompanyId)
        {
            StockReportPoco _poco = new StockReportPoco();
            return AutoMapper.Mapper.Map<IEnumerable<StockReportPoco>,IEnumerable<StockReportVM>>(_poco.GetStock(Asondate,CompanyId));
        }
    }
}
