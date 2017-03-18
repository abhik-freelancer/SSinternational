using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;
namespace SSinternational.presentation.Controllers
{
    public class DamageController : BaseController
    {
        //
        // GET: /Damage/

        public ActionResult Index()
        {
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                int companyId = this.companyId;
                DamagetypesBL _damageBL = new DamagetypesBL();
                IEnumerable<DamagetypesVM> _damageVM = _damageBL.GetAllDamageTypes().ToList();
                return View(_damageVM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
        }
        //deletion
        [HttpPost]
        public ActionResult DeleteDamageType(string DamageId)
        {
            var returnData = new object();
            if (this.LoggedUserId != 0)
            {
                DamagetypesBL _damageBL = new DamagetypesBL();
                Boolean deletion = _damageBL.DeleteDeleteByDamageId(Convert.ToInt32(DamageId));

                if (deletion)
                {
                    returnData = new { msg_code = "1", msg_data = "<p>Damage has removed from your database</p>" };
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
        public ActionResult addEdit(int? DamageId)
        {

            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                DamagetypesVM _damageVM = new DamagetypesVM();
                if (DamageId != null)
                {
                    DamagetypesBL _damageBL = new DamagetypesBL();
                    _damageVM = _damageBL.GetDamageTypesByDamageId(Convert.ToInt32(DamageId));



                }
                return View(_damageVM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addEdit(DamagetypesVM damageTypeVM)
        {

            ModelState.Remove("DamageId");
            if (ModelState.IsValid)
            {
                try
                {
                    DamagetypesBL _damageTypeBL = new DamagetypesBL();
                    int damageTypeId = damageTypeVM.DamageId;
                    

                    if (damageTypeId!= 0)
                    {
                        _damageTypeBL.UpdateDamageType(damageTypeVM);
                        return RedirectToAction("Index", "Damage");
                    }
                    else
                    {
                        int lastInsrtId = _damageTypeBL.InsertDamageType(damageTypeVM);
                        return RedirectToAction("Index", "Damage");

                    }

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex.Message);
                    return View(damageTypeVM);
                }
            }
            else
            {

                return View(damageTypeVM);
            }


        }


    }
}
