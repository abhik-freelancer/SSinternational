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

    }
}
