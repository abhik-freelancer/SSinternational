using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace SSinternational.presentation.Controllers
{
    public class EntrybillController : BaseController
    {
        //
        // GET: /Entrybill/

        public ActionResult Index()
        {
            if (this.LoggedUserId != 0)
            {
                EntryBillBL _BL = new EntryBillBL();
                IEnumerable<EntryBillMasterVM> _VM = _BL.getEntryBillList(this.companyId, this.financialyearId);

                return View(_VM);
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult addEditBillEntry(int? entryBillId) {
            if (this.LoggedUserId != 0)
            {
                EntryBillMasterVM _entryBillVm = new EntryBillMasterVM();
                customerBL customerBL = new customerBL();
                BrokersBL brokerBl = new BrokersBL();
                gardenBL _gardenBl = new gardenBL();
                EntryBillBL _entryBillBL = new EntryBillBL();
                int companyId = this.companyId;
                int yearId = this.financialyearId;
                if (Convert.ToInt32(entryBillId) != 0)
                {

                    //edit mode
                }
                else { 
                    //add mode
                    _entryBillVm.entryRent = _entryBillBL.getEntryRentRate(companyId, yearId);
                
                }
                _entryBillVm.customerList = customerBL.getCustomerList(companyId);
                _entryBillVm.gardenList = _gardenBl.getGardenList(companyId);
                _entryBillVm.brokerList = brokerBl.GetAllBrokers();


                return View(_entryBillVm);

            }else{
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult getGardenByCustomer(int customerId) {

            if (this.LoggedUserId != 0)
            {
                gardenBL _gardenBl = new gardenBL();
                EntryBillMasterVM _VM = new EntryBillMasterVM();
                _VM.gardenList = _gardenBl.getGardenByCustomer(customerId);

                return PartialView(_VM);
                
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult getArrivalList(string from, string to, int gardenid, int brokerid) {
            if (this.LoggedUserId != 0)
            {
                ArrivalBL _arrivalBL = new ArrivalBL();
                EntryBillMasterVM _VM = new EntryBillMasterVM();
                int companyId = this.companyId;
                DateTime fromDate = Convert.ToDateTime(from);
                DateTime toDate = Convert.ToDateTime(to);
                _VM.arrivalLists = _arrivalBL.getArrivalList(fromDate, toDate, companyId, gardenid, brokerid);
                return PartialView(_VM);
            }
            else {
                return RedirectToAction("Index", "Login");
            }
        
        }

        [HttpGet]
        public ActionResult getArrivalInvoices(int arrivalId) {

            if (this.LoggedUserId != 0)
            {
                EntryBillBL _entryBillBL = new EntryBillBL();
                IEnumerable<EntryBillDtlVM> _VM = _entryBillBL.getArrivalInvoices(arrivalId);

                return PartialView(_VM);

            }
            else {
                return RedirectToAction("Index", "Login");
                
            }
        
        }

    }
}
