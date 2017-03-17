using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;
namespace SSinternational.presentation.Controllers
{
    public class WarehouseController : BaseController
    {
        //
        // GET: /Warehouse/

        public ActionResult Index()
        {
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;

                int companyId = this.companyId;
                WarehousesBL _warehouseBL = new WarehousesBL();

                IEnumerable<WarehousesVM> _warehouseVM = _warehouseBL.GetAllActiveWarehouse(companyId).ToList();

                return View(_warehouseVM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult addEdit(int? WarehouseId)
        {


            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;

                WarehousesVM _warehouseEditVM = new WarehousesVM();
                if (WarehouseId != null)
                {
                    WarehousesBL _warehouseBL = new WarehousesBL();
                    _warehouseEditVM = _warehouseBL.GetById(Convert.ToInt32(WarehouseId));


                }
                return View(_warehouseEditVM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addEdit(WarehousesVM warehouseVM)
        {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            ModelState.Remove("WarehouseId");
            if (ModelState.IsValid)
            {
                try
                {
                    #region
                    int WarehouseId = warehouseVM.WarehouseId;
                    warehouseVM.CompanyId = this.companyId;
                    WarehousesBL _warehouseBL = new WarehousesBL();

                    if (WarehouseId != 0)
                    {
                        _warehouseBL.UpdateWarehouse(warehouseVM);
                        return RedirectToAction("Index", "Warehouse");
                    }
                    else
                    {
                        _warehouseBL.InsertWarehouse(warehouseVM);
                        return RedirectToAction("Index", "Warehouse");
                    }
                    #endregion
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex.Message);
                    return View(warehouseVM);
                }
            }
            else
            {
                return View(warehouseVM);
            }

        }



        [HttpPost]
        public ActionResult DeleteWarehouse(string warehouseId)
        {
            var returnData = new object();
            if (this.LoggedUserId != 0)
            {
                WarehousesBL _warehouseBL = new WarehousesBL();
                Boolean deletion = _warehouseBL.DeleteWarehouse(Convert.ToInt32(warehouseId));

                if (deletion)
                {
                    returnData = new { msg_code = "1", msg_data = "<p>Warehouse has removed from your database</p>" };
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
