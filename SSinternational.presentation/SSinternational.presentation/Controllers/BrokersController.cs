using SSinternational.business;
using SSinternational.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSinternational.presentation.Controllers
{
    public class BrokersController : BaseController
    {
        //
        // GET: /Brokers/

        public ActionResult Index()
        {
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;

                int companyId = this.companyId;
                BrokersBL _brokerBL = new BrokersBL();

                IEnumerable<BrokersVM> _BrokersLstVM = _brokerBL.GetAllBrokers();

                return View(_BrokersLstVM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
           
        }

        //delete
        [HttpPost]
        public ActionResult DeleteBroker(string BrokerId)
        {
            var returnData = new object();
            if (this.LoggedUserId != 0)
            {
                BrokersBL _brokerBL = new BrokersBL();
                Boolean deletion = _brokerBL.DeleteByBrokerId(Convert.ToInt32(BrokerId));

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



        [HttpGet]
        public ActionResult addEdit(int? brokerId) {

            if (this.LoggedUserId != 0)
            {
                BrokersVM _brokerVM = new BrokersVM();
                estateBL _estateBL = new estateBL();
                BrokersBL _brokerBL = new BrokersBL();
                int companyId = this.companyId;
               
                if (brokerId != 0)
                {
                    _brokerVM = _brokerBL.GetBrokerById(Convert.ToInt32(brokerId));

                }
                
                _brokerVM.estateList = _estateBL.getEstateList(companyId);
                return View(_brokerVM);
            }
            else {
                return RedirectToAction("Index", "Login");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addEdit(BrokersVM _brokerVM) {
            ModelState.Remove("BrokerId");
            ModelState.Remove("EstateId");
            if (this.LoggedUserId != 0)
            {
               
                estateBL _estateBL = new estateBL();
                int companyId = this.companyId;
                BrokersBL _brokerBL = new BrokersBL();
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                _brokerVM.estateList = _estateBL.getEstateList(companyId);
 
                if (ModelState.IsValid)
                {
                    int brokerId = _brokerVM.BrokerId;
                  
                    try {
                        if (brokerId != 0)
                        {
                            _brokerBL.UpdateBroker(_brokerVM);
                            return RedirectToAction("Index", "Brokers");
                        }
                        else {

                            int insertion = _brokerBL.InsertBroker(_brokerVM);
                            return RedirectToAction("Index", "Brokers");
                        }
                            
                    
                    }catch(Exception ex){
                        ModelState.AddModelError("", ex.Message);
                        return View(_brokerVM);
                    }

                }
                else {

                    return View(_brokerVM);
                
                }


                

            }
            else {

                return RedirectToAction("Index", "Login");
            
            }
            
            
            
            
        
        }
    }
}
