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
            return View();
        }

    }
}
