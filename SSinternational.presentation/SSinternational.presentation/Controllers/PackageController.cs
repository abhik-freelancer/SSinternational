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

        [HttpPost]
        public ActionResult DeletePackage(string packageId)
        {
            var returnData = new object();
            if (this.LoggedUserId != 0)
            {
                PackagesBL _packageBL = new PackagesBL();
                Boolean deletionPackage = _packageBL.DeletePackage(Convert.ToInt32(packageId));

                if (deletionPackage)
                {
                    returnData = new { msg_code = "1", msg_data = "<p>Package has removed from your database</p>" };
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
        public ActionResult addEdit(int? packageId)
        {

            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                PackagesVM _packageVM = new PackagesVM();
                if (packageId != null)
                {
                    PackagesBL _packageBL = new PackagesBL();
                    _packageVM = _packageBL.GetByPackageId(Convert.ToInt32(packageId));



                }
                return View(_packageVM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addEdit(PackagesVM packageVM)
        {

            ModelState.Remove("PackageId");
            if (ModelState.IsValid)
            {
                try
                {
                    PackagesBL _packageBL =new  PackagesBL();
                    int PackageId = packageVM.PackageId;
                    packageVM.CompanyId = this.companyId;

                    if (PackageId != 0)
                    {
                        _packageBL.UpdatePackage(packageVM);
                        return RedirectToAction("Index", "Package");
                    }
                    else
                    {
                        _packageBL.InsertPackege(packageVM);
                        return RedirectToAction("Index", "Package");

                    }

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex.Message);
                    return View(packageVM);
                }
            }
            else
            {

                return View(packageVM);
            }


        }
    
    
    
    
    }
}
