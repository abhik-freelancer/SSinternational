using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;

namespace SSinternational.presentation.Controllers
{
    public class UnloadingmasterController : BaseController
    {
        //
        // GET: /Unloadingmaster/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult addEdit(int? unloadmstId) {

            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                int companyId = this.companyId;
                int yearId = this.financialyearId;

                UnloadingmasterVM _unloadmstVM = new UnloadingmasterVM();
                gardenBL _gardenBL = new gardenBL();
                BrokersBL _brokerBL = new BrokersBL();
                WarehousesBL _warehouseBL = new WarehousesBL();

                
                if (unloadmstId != 0) { 
                    //to do
                }
                _unloadmstVM.gardenList = _gardenBL.getGardenList(companyId);
                _unloadmstVM.brokerList = _brokerBL.GetAllBrokers();
                _unloadmstVM.warehouselist = _warehouseBL.GetAllWarehouse(companyId);

                return View(_unloadmstVM);


            }
            else {

                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addEdit(UnloadingmasterVM _VM) {
            if (this.LoggedUserId != 0)
            {
                ModelState.Remove("id");
                int companyid = this.companyId;
                int financialYearId = this.financialyearId;
                gardenBL _gardenBL = new gardenBL();
                BrokersBL _brokerBL = new BrokersBL();
                WarehousesBL _warehouseBL = new WarehousesBL();


                _VM.gardenList = _gardenBL.getGardenList(companyid);
                _VM.brokerList = _brokerBL.GetAllBrokers();
                _VM.warehouselist = _warehouseBL.GetAllWarehouse(companyid);

                if (ModelState.IsValid)
                {
                    try {

                        
                        int unloadingMasterId = _VM.id;
                        _VM.companyId = companyid;
                        _VM.yearId = financialYearId;
                        unloadingBL _unldmst = new unloadingBL();
                        if (unloadingMasterId != 0)
                        {

                            //edit
                        }
                        else {
                            int insrt = _unldmst.insertUnloadingMaster(_VM);
                            //insert
                           // return View(_VM);//for test
                        }
                        return RedirectToAction("Index", "Unloadingmaster");
                         
                    }catch(Exception ex){
                        ModelState.AddModelError("", ex.Message);
                        return View(_VM);
                    }
                        
                }
                else {
                        //model state fail
                        return View(_VM);
                }
            }
            else {

                return RedirectToAction("Index", "Login");
            }
        }

    }
}
