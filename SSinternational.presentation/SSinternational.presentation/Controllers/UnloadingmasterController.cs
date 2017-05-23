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
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                unloadingBL _unloadingBL = new unloadingBL();
                int companyId = this.companyId;
                int yearId = this.financialyearId;
                IEnumerable<UnloadingmasterVM> _lstVM = _unloadingBL.getUnloadingMasterList(companyId,yearId);
                return View(_lstVM);
            }
            else {
                return RedirectToAction("Index", "Login");
            }
           
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
                unloadingBL _unlndBL = new unloadingBL();
                int unloadingMasterId = Convert.ToInt32(unloadmstId);


                if (unloadingMasterId != 0)
                {
                    //to do
                    _unloadmstVM = _unlndBL.getUnldMasterDataById(Convert.ToInt32(unloadmstId));

                }
                else {
                    _unloadmstVM.receiptdate = DateTime.Today;
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
                ViewBag.companyName = this.LoggedCompanyName;
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

                           _unldmst.updateUnloadMaster(_VM);

                            //edit
                            
                        }
                        else {
                            int insrt = _unldmst.insertUnloadingMaster(_VM);
                         
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

        public ActionResult DeleteUnloadMaster(string unloadmasterId) {
            var returnData = new object();
            if (this.LoggedUserId != 0)
            {
                unloadingBL _unloadingBl = new unloadingBL();
                Boolean deletionUnloadingMaster = _unloadingBl.deleteUnloadingMaster(Convert.ToInt32(unloadmasterId));

                if (deletionUnloadingMaster)
                {
                    returnData = new { msg_code = "1", msg_data = "<p>Transaction has removed from your database</p>" };
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

        public ActionResult generateArrival(string unloadingMasterId, string arrivalNumber, string arrivalDate) {

            var returnData = new object();
            if (this.LoggedUserId != 0)
            {
                unloadingBL _unloadingBl = new unloadingBL();
                
                

                if (arrivalNumber != "" && arrivalDate != "")
                {
                    Boolean gereneratearrival = _unloadingBl.gereneratearrival(unloadingMasterId, arrivalNumber, arrivalDate);

                    if (gereneratearrival)
                    {
                        returnData = new { msg_code = "1", msg_data = "<p>Arrival has been generated successfully.</p>" };
                    }
                    else
                    {
                        returnData = new { msg_code = "0", msg_data = "<p>Internal error occured.</p>" };
                    }
                }
                else {

                    returnData = new { msg_code = "2", msg_data = "<p>Arrival number and date are mandatory for generating arrival.</p>" };
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
