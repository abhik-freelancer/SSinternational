using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SSinternational.presentation.Controllers
{
    public class BaseController : Controller
    {
        
        public int LoggedUserId {
            get {
                if (Session["userId"] != null)
                {
                    return Convert.ToInt32(Session["userId"].ToString());
                }
                else {
                    return 0;
                }
            
            }
            
        }
        public string LoggedLogin {

            get {
                return Session["userlogin"].ToString();
            }
        }

        public string LoggedUserName {

            get {

                return Session["username"].ToString();
            }
        
        }
        public int companyId {
            get {

                return Convert.ToInt32(Session["companyid"].ToString());
            }
        
        }
        public int financialyearId {
            get {
                return Convert.ToInt32(Session["yearid"].ToString());
            }
        }

        public string LoggedCompanyName {
            get {
                    return Session["companyname"].ToString();
                }
        
        }

       /***************************/
        public string financialyearDescription
        {
            get
            {
                return (Session["YearDesc"].ToString());
            }
        }

        public string fiscalStartDate
        {
            get
            {
                return (Session["fiscalStartDate"].ToString());
            }
        }
        public string fiscalEndDate
        {
            get
            {
                return (Session["fiscalEndDate"].ToString());
            }
        }

       



    }
}
