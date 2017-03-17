using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;

namespace SSinternational.presentation.Controllers
{
    public class GardenController : BaseController
    {
        //
        // GET: /Garden/

        public ActionResult Index()
        {
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;

                int companyId = this.companyId;
                gardenBL _gardenBL = new gardenBL();
                IEnumerable<GardenListVM> _gardenLstVM = _gardenBL.getGardenList(companyId).ToList();

                return View(_gardenLstVM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult addEdit(int? gardenId)
        {


            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;

                int companyId = this.companyId;
                GardenAddEditVM _gardenAddEditVM = new GardenAddEditVM();
                customerBL _customerBL = new customerBL();
                gardenBL _gardenBL = new gardenBL();

                if (gardenId != null)
                {

                    _gardenAddEditVM = _gardenBL.getGardenById(Convert.ToInt32(gardenId));


                }
                _gardenAddEditVM.customerList = _customerBL.getCustomerList(companyId);
                return View(_gardenAddEditVM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addEdit(GardenAddEditVM _gardenVM)
        {
            ModelState.Remove("gardenId");
            customerBL _customerBL = new customerBL();
            _gardenVM.customerList = _customerBL.getCustomerList(this.companyId);

            if (ModelState.IsValid)
            {
                try {

                    int gardenId = _gardenVM.gardenId;
                    _gardenVM.companyid = this.companyId;
                    gardenBL _gardenBL = new gardenBL();
                    if (gardenId != 0)
                    {
                        _gardenBL.upadateGarden(_gardenVM);
                        return RedirectToAction("Index", "Garden");
                    }
                    else {

                       int lastinsertId= _gardenBL.insertGarden(_gardenVM);
                       return RedirectToAction("Index", "Garden");
                    }


                }catch(Exception ex){
                    ModelState.AddModelError("", ex.Message);
                    return View(_gardenVM);
                }

            }
            else {

                return View(_gardenVM);
            }

        }
    
    
    
    

        //delete
        [HttpPost]
        public ActionResult DeleteGarden(string gardenId)
        {
            var returnData = new object();
            if (this.LoggedUserId != 0)
            {
                gardenBL _gardenBL = new gardenBL();
                Boolean deletion = _gardenBL.deleteGarden(Convert.ToInt32(gardenId));

                if (deletion)
                {
                    returnData = new { msg_code = "1", msg_data = "<p>Garden has removed from your database</p>" };
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
