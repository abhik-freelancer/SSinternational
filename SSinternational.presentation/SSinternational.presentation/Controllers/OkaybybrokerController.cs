using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;

namespace SSinternational.presentation.Controllers
{
    public class OkaybybrokerController : BaseController
    {
        //
        // GET: /Okaybybroker/

        public ActionResult Index()
        {
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                int companyId = this.companyId;
                int yearId = this.financialyearId;
                ArrivalBL _arrivalBL = new ArrivalBL();
                OkaybybrokerVM _VM = new OkaybybrokerVM();
                _VM.arrivalList = _arrivalBL.getArrivalMasterList(companyId, yearId);
                return View(_VM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
        }

        //usp_arrivalInvoiceList
        public ActionResult ArrivalInvoicesList(int arrivalId)
        {

            if (this.LoggedUserId != 0)
            {
                ArrivalBL _BL = new ArrivalBL();
                IEnumerable<ArrivalInvoicesListVM> _VM = _BL.getArrivalInvoicesList(arrivalId);
                return PartialView(_VM);

            }
            else
            {
                return Content("3");
            }


        }


        public ActionResult EditdamageBag(int invoiceId)
        {
            if (this.LoggedUserId != 0)
            {
                OkaybybrokerVM _oakybybrokerVM = new OkaybybrokerVM();
                OkaybybrokerBL _okaybybrokerBL = new OkaybybrokerBL();
                BrokersBL _brokerBL = new BrokersBL();
                ArrivalBL _arrivalBL = new ArrivalBL();
                DamagetypesBL _damageTypeBL = new DamagetypesBL();

                _oakybybrokerVM = _okaybybrokerBL.OkaybybrokerMasterData(invoiceId);
                _oakybybrokerVM.brokersList = _brokerBL.GetAllBrokers();
                _oakybybrokerVM.damageBagDetails = _arrivalBL.GetDamageBagDetailById(invoiceId);
                _oakybybrokerVM.damageDropDownList = _damageTypeBL.GetAllDamageTypes();

                return View(_oakybybrokerVM);

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public JsonResult EditdamageBag(OkaybybrokerVM inspectionResult)
        {
            if (this.LoggedUserId != 0)
            {
                if (ModelState.IsValid)
                {
                    OkaybybrokerBL _BL = new OkaybybrokerBL();
                    int insrtRslt = _BL.UpdateOkayByBroker(inspectionResult);
                    if (insrtRslt == 1)
                    {
                        return new JsonResult { Data = new { status = "1", msg = "" } };
                    }
                    else
                    {
                        return new JsonResult { Data = new { status = "0", msg = "" } };
                    }
                }
                else
                {

                    return new JsonResult { Data = new { status = "3", msg = "" } };
                }


            }
            else
            {
                return new JsonResult { Data = new { status = "2", msg = "" } };
            }
        }
    
    
    
    /*****************************/
    }
}
