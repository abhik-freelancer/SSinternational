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

    }
}
