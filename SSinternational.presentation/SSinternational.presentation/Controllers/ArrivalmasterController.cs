using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;

namespace SSinternational.presentation.Controllers
{
    public class ArrivalmasterController : BaseController
    {
        //
        // GET: /Arrivalmaster/

        public ActionResult Index()
        {
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                int companyId = this.companyId;
                int yearId = this.financialyearId;
                ArrivalBL _arrivalBL = new ArrivalBL();
                IEnumerable<ArrivalMasterVM> _VM = _arrivalBL.getArrivalMasterList(companyId, yearId);

                return View(_VM);
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult addEdit(int? arrivalMasterId) {

            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                int companyId = this.companyId;
                int yearId = this.financialyearId;

                ArrivalBL _BL = new ArrivalBL();
                gardenBL _gardenBL = new gardenBL();
                BrokersBL _brokerBL = new BrokersBL();
                WarehousesBL _warehouseBL = new WarehousesBL();
                ArrivalMasterVM _VM = new ArrivalMasterVM();

                if (Convert.ToInt32(arrivalMasterId) != 0)
                {
                    _VM = _BL.getArrivalMasterById(Convert.ToInt32(arrivalMasterId));
                }
                else {
                    _VM.dateofarrival = DateTime.Today;
                }
                _VM.gardenList = _gardenBL.getGardenList(companyId);
                _VM.brokerList = _brokerBL.GetAllBrokers();
                _VM.warehouseList = _warehouseBL.GetAllWarehouse(companyId);

                return View(_VM);
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addEdit(ArrivalMasterVM _VM) {
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                ModelState.Remove("arrivalId");

                /*****************************/
                int companyid = this.companyId;
                int financialYearId = this.financialyearId;

                gardenBL _gardenBL = new gardenBL();
                BrokersBL _brokerBL = new BrokersBL();
                WarehousesBL _warehouseBL = new WarehousesBL();


                _VM.gardenList = _gardenBL.getGardenList(companyid);
                _VM.brokerList = _brokerBL.GetAllBrokers();
                _VM.warehouseList = _warehouseBL.GetAllWarehouse(companyid);


                if(ModelState.IsValid){

                    try
                    {
                        int arrivalMasterId = _VM.arrivalId;
                        _VM.companyid = companyid;
                        _VM.yearid = financialyearId;

                        ArrivalBL _arrivalBL = new ArrivalBL();
                        if (arrivalMasterId != 0)
                        {
                            //edit
                            int updtStattus = _arrivalBL.arrivalMasterUpdate(_VM);

                            if (updtStattus == 1)
                            {
                                return RedirectToAction("Index", "Arrivalmaster");
                            }
                            else {
                                throw new Exception("Sorry something going wrong..");
                            
                            }
                        }
                        else {

                            int rslt = _arrivalBL.arrivalMasterInsertion(_VM);
                                if(rslt==2){
                                    throw new Exception("Arrival number can't be deuplicate");
                                }else if(rslt==0){
                                    throw new Exception("Sorry something going wrong..");
                                }
                                else if(rslt==1){
                                    return RedirectToAction("Index","Arrivalmaster"); 
                                }

                        }
                        return RedirectToAction("Index", "Arrivalmaster"); 

                    }
                    catch (Exception exp) {

                        ModelState.AddModelError("", exp.Message);
                        return View(_VM);
                    }



                }else{
                    return View(_VM);
                }


                
            }
            else {

                return RedirectToAction("Index", "Login");
            }
        
        }

    }
}
