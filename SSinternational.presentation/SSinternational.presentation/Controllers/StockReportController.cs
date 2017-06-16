using Microsoft.Reporting.WebForms;
using SSinternational.business;
using SSinternational.viewmodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSinternational.presentation.Controllers
{
    public class StockReportController : BaseController
    {
        //
        // GET: /StockReport/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Stockreport(string AsonDate)
        {
            StockReportBL _bl = new StockReportBL();
            IEnumerable<StockReportVM> _vmlist = _bl.GetStock(Convert.ToDateTime(AsonDate),this.companyId);
            return PartialView(_vmlist);
        }

        public ActionResult PrintStockreport(string AsonDate)
        {

            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Content/Reports"), "stockreport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }


            SSinternational.dataaccess.StockReportDAL _dal = new SSinternational.dataaccess.StockReportDAL();
            System.Data.DataTable stockdt = _dal.StockReport(Convert.ToDateTime(AsonDate), this.companyId);
            ReportDataSource stock = new ReportDataSource("Stockdetails", stockdt);
            lr.DataSources.Add(stock);



            SSinternational.dataaccess.companyDAL _cpmDAL = new SSinternational.dataaccess.companyDAL();
            System.Data.DataTable Cmpdt = _cpmDAL.getCompanyHeader(this.companyId);
            ReportDataSource cmp = new ReportDataSource("CompanyHeader", Cmpdt);
            lr.DataSources.Add(cmp);

            ReportParameter p1 = new ReportParameter("AsonDate", AsonDate);
            lr.SetParameters(new ReportParameter[] { p1 });

            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + "PDF" + "</OutputFormat>" +
            "  <PageWidth>8.27in</PageWidth>" +
            "  <PageHeight>11.69in</PageHeight>" +
            "  <MarginTop>0in</MarginTop>" +
            "  <MarginLeft>0in</MarginLeft>" +
            "  <MarginRight>0in</MarginRight>" +
            "  <MarginBottom>0in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);



            return File(renderedBytes, mimeType);

        }
    }
}
