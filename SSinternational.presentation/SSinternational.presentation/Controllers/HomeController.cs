using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSinternational.presentation.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.companyName = this.LoggedCompanyName;
            
            return View();
        }

    }
}
