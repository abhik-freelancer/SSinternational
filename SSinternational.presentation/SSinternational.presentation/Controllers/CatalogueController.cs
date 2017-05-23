using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;
namespace SSinternational.presentation.Controllers
{
    public class CatalogueController : BaseController
    {
        //
        // GET: /Catalogue/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult addCatalogue() {
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                int companyId = this.companyId;
                CatalogueVM _VM = new CatalogueVM();
                gardenBL _gardenBL = new gardenBL();
                _VM.gardenList = _gardenBL.getGardenList(companyId);
                return View(_VM);
            }
            else {
                return RedirectToAction("Index", "Login");
            }
            
        }


       [HttpGet]
        public ActionResult LisOfArrivalByGarden(int gardenId) {
            if (this.LoggedUserId != 0)
            {
                CatalogueBL _BL = new CatalogueBL();
                IEnumerable<CatalogueVM> _VM = _BL.getArrivalListByGardenId(gardenId);
                return PartialView(_VM);
            }else{
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
       public ActionResult CatalogEntry(int arrivalDtlId) {
           if (this.LoggedUserId != 0)
           {


               CatalogueBL _bl = new CatalogueBL();
               BrokersBL _Brokerbl = new BrokersBL();
               CatalogueVM _VM = new CatalogueVM();
               int[] serialRange = _bl.getChestSerialRangeByArrivalDtlId(arrivalDtlId);
               int serialStart = serialRange[0];
               int serialTo = serialRange[1];

               
               _VM = _bl.getArrivalInvoiceDetail(arrivalDtlId);

               List<SelectListItem> li = new List<SelectListItem>();
               for (int i = serialStart; i <= serialTo; i++)
               {
                   li.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
               }
               ViewData["serial"] = li;
               _VM.brokerList = _Brokerbl.GetAllBrokers();
               return PartialView(_VM);
           }
           else {
               return RedirectToAction("Index", "Login");
           
           }
       }

        [HttpPost]
        public ActionResult SaveCataLogue(CatalogueVM catalog) {
            if (this.LoggedUserId != 0)
            {
                var returnData = new object();
                CatalogueBL _BL = new CatalogueBL();
                catalog.companyId = this.companyId;
                catalog.yearId = this.financialyearId;
                int result = _BL.catalogueInsert(catalog);

                if (result == 1)
                {
                    returnData = new { msg_code = "1", msg_data = "Data successfully saved." };
                }
                else {
                    returnData = new { msg_code = "0", msg_data = "Error in saving." };
                }

                return Json(returnData, JsonRequestBehavior.DenyGet);
            }
            else {

                return RedirectToAction("Index", "Login");
            }
        
        
        
        }

        public ActionResult catalogList(int invoiceId)
        {
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                CatalogueBL _BL = new CatalogueBL();
                IEnumerable<CatalogueVM> _VM = _BL.getcatalogListByInvoiceId(invoiceId);
                
                return View(_VM);
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        
        }
        /// <summary>
        /// Catalog Edit by catalogueId and arrivalDetailId
        /// </summary>
        /// <param name="catalogId"></param>
        /// <param name="arrivalInvoiceId"></param>
        /// <returns></returns>
        public ActionResult catalogueEdit(int catalogId, int arrivalInvoiceId)
        {
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;

                CatalogueBL _bl = new CatalogueBL();
                BrokersBL _Brokerbl = new BrokersBL();
                CatalogueVM _VM = new CatalogueVM();
                int[] serialRange = _bl.getChestSerialRangeByArrivalDtlId(arrivalInvoiceId);
                int serialStart = serialRange[0];
                int serialTo = serialRange[1];


                _VM = _bl.getArrivalInvoiceDetail(arrivalInvoiceId);
              
                _VM = _bl.getCatalogueById(catalogId);

                List<SelectListItem> li = new List<SelectListItem>();
                for (int i = serialStart; i <= serialTo; i++)
                {
                    li.Add(new SelectListItem { Selected=(i==_VM.bagSerial), Text = i.ToString(), Value = i.ToString() });
                }
                ViewData["serialEdit"] = li;

                _VM.brokerList = _Brokerbl.GetAllBrokers();
               

                return View(_VM);
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        
        
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
       // public ActionResult updatecatalogue(CatalogueVM _VM) {
        public ActionResult catalogueEdit(CatalogueVM _VM)
        {
            if (this.LoggedUserId != 0)
            {
                ModelState.Remove("catalogId");
                ViewBag.companyName = this.LoggedCompanyName;

                CatalogueBL _bl = new CatalogueBL();
                BrokersBL _Brokerbl = new BrokersBL();
                
                int[] serialRange = _bl.getChestSerialRangeByArrivalDtlId(_VM.arrivalInvoiceId);
                int serialStart = serialRange[0];
                int serialTo = serialRange[1];

                if (ModelState.IsValid)
                {
                    _bl.update(_VM);

                        return RedirectToAction("catalogList", "Catalogue", new { @invoiceId = _VM.arrivalInvoiceId });
                   
                }
                else {

                    _VM = _bl.getCatalogueById(_VM.catalogId);

                    List<SelectListItem> li = new List<SelectListItem>();
                    for (int i = serialStart; i <= serialTo; i++)
                    {
                        li.Add(new SelectListItem { Selected = (i == _VM.bagSerial), Text = i.ToString(), Value = i.ToString() });
                    }
                    ViewData["serialEdit"] = li;

                    _VM.brokerList = _Brokerbl.GetAllBrokers();

                    return View(_VM);
                }

            }
            else {
                return RedirectToAction("Index", "Login");
            }
        
        }


    }
}
