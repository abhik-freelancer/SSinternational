using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;

namespace SSinternational.presentation.Controllers
{
    public class ShorttypeController : BaseController
    {
        //
        // GET: /Shorttype/

        public ActionResult Index()
        {
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                int companyId = this.companyId;
                ShorttypesBL _shortTypeBL = new ShorttypesBL();

                IEnumerable<ShorttypesVM> _shortTypeVM = _shortTypeBL.GetAllShortTypes().ToList();

                return View(_shortTypeVM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult DeleteShort(string shortId)
        {
            var returnData = new object();
            if (this.LoggedUserId != 0)
            {
                ShorttypesBL _shortTypeBL = new ShorttypesBL();
                Boolean deletionShort = _shortTypeBL.DeleteShortType(Convert.ToInt32(shortId));

                if (deletionShort)
                {
                    returnData = new { msg_code = "1", msg_data = "<p>Shorttype has removed from your database</p>" };
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

        [HttpGet]
        public ActionResult addEdit(int? ShortId)
        {

            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                ShorttypesVM _shortTypeVM = new ShorttypesVM();
                if (ShortId != null)
                {
                    ShorttypesBL _shortBL = new ShorttypesBL();
                    _shortTypeVM = _shortBL.GetShortTypeByShortId(Convert.ToInt32(ShortId));



                }
                return View(_shortTypeVM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addEdit(ShorttypesVM shortVM)
        {

            ModelState.Remove("ShortId");
            if (ModelState.IsValid)
            {
                try
                {
                    ShorttypesBL _shortTypeBL = new ShorttypesBL();
                    int shortId = shortVM.ShortId;
                    shortVM.CompanyId = this.companyId;

                    if (shortId != 0)
                    {
                        _shortTypeBL.UpdateShortType(shortVM);
                        return RedirectToAction("Index", "Shorttype");
                    }
                    else
                    {
                      int shortInsrt=  _shortTypeBL.InsertShortType(shortVM);
                      return RedirectToAction("Index", "Shorttype");

                    }

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex.Message);
                    return View(shortVM);
                }
            }
            else
            {

                return View(shortVM);
            }


        }

    }
}
