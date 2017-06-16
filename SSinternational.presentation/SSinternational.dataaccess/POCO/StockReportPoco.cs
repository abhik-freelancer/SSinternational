using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.dataaccess.POCO
{
   public class StockReportPoco
    {
      public int StockLedgerId{get;set;}
      public string TransactionNumber{get;set;}      
      public DateTime TransactionDate{get;set;}
      public string TransType{get;set;}
      public string Invoice{get;set;}
      public string Grade{get;set;}
      public string Garden{get;set;}
      public string CropYr{get;set;}
      public decimal net{get;set;}
      public decimal StockIn{get;set;}
      public decimal StockOut { get; set; }
      public decimal Balance { get; set; }
      public int Companyid { get; set; }
      public int YearId { get; set; }


      public IEnumerable<StockReportPoco> GetStock(DateTime Asondate, int CompanyId)
      {
          StockReportDAL _DAL = new StockReportDAL();
          DataTable dt = _DAL.StockReport(Asondate,CompanyId);

          List<StockReportPoco> _stockreportlist = new List<StockReportPoco>();

          for (int i = 0; i < dt.Rows.Count; i++)
          {
              StockReportPoco _poco = new StockReportPoco();
              _poco.StockLedgerId = Convert.ToInt32(dt.Rows[i]["StockLedgerId"].ToString());
              _poco.TransactionNumber = (dt.Rows[i]["TransactionNumber"].ToString());
              _poco.TransactionDate = Convert.ToDateTime(dt.Rows[i]["TransactionDate"].ToString());
              _poco.TransType = (dt.Rows[i]["TransType"].ToString());
              _poco.Invoice = (dt.Rows[i]["Invoice"].ToString());
              _poco.Grade = (dt.Rows[i]["Grade"].ToString());
              _poco.CropYr = (dt.Rows[i]["CropYr"].ToString());
              _poco.net = Convert.ToDecimal(dt.Rows[i]["net"].ToString());
              _poco.StockIn = Convert.ToDecimal(dt.Rows[i]["StockIn"].ToString());
              _poco.StockOut = Convert.ToDecimal(dt.Rows[i]["StockOut"].ToString());
              _poco.Balance = Convert.ToDecimal(dt.Rows[i]["Balance"].ToString());

              _stockreportlist.Add(_poco);
          }

          return _stockreportlist;
      }
    }
}
