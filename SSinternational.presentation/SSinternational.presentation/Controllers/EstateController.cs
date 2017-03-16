using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;

namespace SSinternational.presentation.Controllers
{
    public class EstateController : BaseController
    {
        //
        // GET: /Estate/

        public ActionResult Index()
        {
            
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                int companyId = this.companyId;
                estateBL _estateBL = new estateBL();
                IEnumerable<EsatetVM> _estateVM = _estateBL.getEstateList(companyId).ToList();

                return View(_estateVM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult addEdit(int? estateId) {

            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                EsatetVM _estateEditVM = new EsatetVM();
                if (estateId != null)
                {
                    estateBL _estateBL = new estateBL();
                    _estateEditVM=_estateBL.getEstateById(Convert.ToInt32(estateId));
                    


                }
                return View(_estateEditVM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addEdit(EsatetVM _estateVM) {

            ModelState.Remove("estateId");
            if (ModelState.IsValid)
            {
                try
                {
                    estateBL _estateBL = new estateBL();
                    int estateId = _estateVM.estateId;
                    _estateVM.companyid = this.companyId;

                    if (estateId != 0)
                    {
                        _estateBL.upadateEstate(_estateVM);
                        return RedirectToAction("Index", "Estate");
                    }
                    else {
                        _estateBL.insertEstate(_estateVM);
                        return RedirectToAction("Index", "Estate");
                    
                    }

                }
                catch (Exception ex) {

                    ModelState.AddModelError("", ex.Message);
                    return View(_estateVM);
                }
            }
            else {

                return View(_estateVM);
            }
        
        
        }

        [HttpPost]
        public ActionResult DeleteEstate(string estateId)
        {
            var returnData = new object();
            if (this.LoggedUserId != 0)
            {
                estateBL _estateBL = new estateBL();
                Boolean deletionEstate = _estateBL.deleteEstate(Convert.ToInt32(estateId));

                if (deletionEstate)
                {
                    returnData = new { msg_code = "1", msg_data = "<p>Estate has removed from your database</p>" };
                }
                else
                {
                    returnData = new { msg_code = "0", msg_data = "<p>Permission deny for deletion</p>" };
                }


            }
            else
            {

                return RedirectToAction("Index", "Login");
            }


            return Json(returnData, JsonRequestBehavior.DenyGet);
        }

    }
}
