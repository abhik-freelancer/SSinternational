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
                return View();

            }else{
                return RedirectToAction("Index", "Login");
            }
        }

    }
}
