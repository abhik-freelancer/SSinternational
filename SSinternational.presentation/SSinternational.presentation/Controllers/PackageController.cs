using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;

namespace SSinternational.presentation.Controllers
{
    public class PackageController : BaseController
    {
        //
        // GET: /Package/

        public ActionResult Index()
        {
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;

                int companyId = this.companyId;
                PackagesBL _packageBL = new PackagesBL();
                IEnumerable<PackagesVM> _packageVM = _packageBL.GetAllPackages(companyId).ToList();

                return View(_packageVM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
        }

    }
}
