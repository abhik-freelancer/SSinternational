using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;
using Microsoft.Reporting.WebForms;
using System.IO;



namespace SSinternational.presentation.Controllers
{
    public class ArrivalInvoicesController : BaseController
    {
        //
        // GET: /ArrivalInvoices/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listofInvoices(int arrivalId)
        {
            //unloadMasterId=@unldDtl.unloadingmasterid ,unloadingdetailId = @unldDtl.unloadingDetailId
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                ViewBag.arrivalMasterId = arrivalId;
                ArrivalBL _BL = new ArrivalBL();
                IEnumerable<ArrivalInvoicesListVM> _VM = _BL.getArrivalInvoicesList(arrivalId);
                return View(_VM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
        }


       


        public ActionResult addEditArrivalDetail(int arrivalId)
        {

            if (this.LoggedUserId != 0)
            {
                //return View();    
                ArrivalBL _BL = new ArrivalBL();
                int numberofinvoices = _BL.getNumberofInvoices(arrivalId);

                if (numberofinvoices == 0)
                {
                    //add
                    return RedirectToAction("addInvoice", new { arrivalMasterId = arrivalId });
                }
                else
                {
                    // listofInvoices(unloadingmasterId);
                    return RedirectToAction("listofInvoices", new { arrivalId = arrivalId });
                }


            }
            else
            {

                return RedirectToAction("Index", "Login");
            }

        }



        public ActionResult addInvoice(int arrivalMasterId, int? arrivalDetailId)
        {

            if (this.LoggedUserId != 0)
            {
                if (arrivalMasterId != 0)
                {
                    ViewBag.companyName = this.LoggedCompanyName;
                    int companyId = this.companyId;
                    ArrivalDtlAddEditVM _VM = new ArrivalDtlAddEditVM();
                    ArrivalBL _BL = new ArrivalBL();
                    FloorsBL _floorList = new FloorsBL();
                    DamagetypesBL _damageList = new DamagetypesBL();
                    ShorttypesBL _shortList = new ShorttypesBL();
                    PackagesBL _packageBL = new PackagesBL();

                    if (arrivalDetailId != 0)
                    {
                        _VM = _BL.GetArrivalDtlById(arrivalMasterId, Convert.ToInt32(arrivalDetailId));
                        _VM.damageBagDtls = _BL.GetDamageBagDetailById(Convert.ToInt32(arrivalDetailId));
                        _VM.shortBagDtls = _BL.GetShoertBagDtlById(Convert.ToInt32(arrivalDetailId));
                    }


                    _VM.floorList = _floorList.getFloorList();
                    _VM.damageSelectList = _damageList.GetAllDamageTypes();
                    _VM.shorttypeSelectList = _shortList.GetAllShortTypes();
                    _VM.packageList = _packageBL.GetAllPackages(companyId);
                    _VM.arrivalId = arrivalMasterId;

                    _VM.invoiceformatId = _BL.checkInvoiceFormatId(arrivalMasterId);
                    _VM.gardenCode = _BL.getGardenCode(arrivalMasterId);

                    return View(_VM);

                }
                else
                {
                    return RedirectToAction("Index", "Arrivalmaster");

                }


            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }


        /**
         * Saving unloading invoice
         * 29/04/2017
         * 
         * */
        [HttpPost]
        public JsonResult SaveArrivaldetail(ArrivalDtlAddEditVM arrivalInvoice)
        {
            if (this.LoggedUserId != 0)
            {
                ModelState.Remove("arrivalDetailid");
                ArrivalBL _BL = new ArrivalBL();




                if (ModelState.IsValid)
                {
                    int rslt=0;
                    int arrivalDtlId = arrivalInvoice.arrivalDetailid;

                    if (arrivalDtlId != 0)
                    {

                        rslt = _BL.UpadateunloadingInvoices(arrivalInvoice);
                    }
                    else
                    {
                       
                       rslt = _BL.arrivalInvoicesInsertion(arrivalInvoice);
                    }
                    if (rslt == 1)
                    {
                        //return RedirectToAction("Index", "Login");
                        return new JsonResult { Data = new { status = "1", msg = "Data successfully saved. " } };

                        //return RedirectToAction("listofInvoices", new { masterid = unloadingInvoice.unloadingmasterid });
                    }
                    else
                    {

                        //ModelState.AddModelError("", "Save fail due to internal data base error");
                        //return View(unloadingInvoice);
                        return new JsonResult { Data = new { status = "0", msg = "Data save unsucessfull." } };

                    }


                }
                else
                {
                    //model satate fail
                    return new JsonResult { Data = new { status = "3", msg = "Field validation fail" } };

                    // return View(unloadingInvoice);
                }


            }
            else
            {
                // return RedirectToAction("Index", "Login");
                return new JsonResult { Data = new { status = "2", msg = "" } };
            }



        }

        [ChildActionOnly]
        public ActionResult arrivalPartialList(int arrivalId)
        {
            ArrivalBL _BL = new ArrivalBL();
            IEnumerable<ArrivalInvoicesListVM> _VM = _BL.getArrivalInvoicesList(arrivalId);
            return PartialView(_VM); 
        }
        /// <summary>
        /// Print arrival 
        /// weblogs.asp.net/rajbk/Contents/Item/Display/331
        /// </summary>
        /// <param name="arrivalId"></param>
        /// <returns></returns>

        [HttpGet]
         public ActionResult PrintArrival(int arrivalId) {

             LocalReport lr = new LocalReport();

             string path = Path.Combine(Server.MapPath("~/Content/Reports"), "rdlArrival.rdlc");
             if (System.IO.File.Exists(path))
             {
                 lr.ReportPath = path;
             }
             else
             {
                 return View("Index");
             }


             SSinternational.dataaccess.ArrivalDAL _dal = new SSinternational.dataaccess.ArrivalDAL();
             System.Data.DataTable _arrivalMaster = _dal.getRptArrivalMaster(arrivalId);
             ReportDataSource arrivalMaster = new ReportDataSource("ArrivalMaster", _arrivalMaster);
             lr.DataSources.Add(arrivalMaster);


             System.Data.DataTable arrivalDtl = _dal.getRptArrivalDetail(arrivalId);
             ReportDataSource arrivalDtlDs = new ReportDataSource("ArrivalDetail", arrivalDtl);
             lr.DataSources.Add(arrivalDtlDs);

            

             SSinternational.dataaccess.companyDAL _cpmDAL = new SSinternational.dataaccess.companyDAL();
             System.Data.DataTable Cmpdt = _cpmDAL.getCompanyHeader(this.companyId);
             ReportDataSource cmp = new ReportDataSource("CompanyHeader", Cmpdt);
             lr.DataSources.Add(cmp);

             
            // lr.SetParameters(new ReportParameter[] { Sdesc });

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
