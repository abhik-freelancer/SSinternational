using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;

namespace SSinternational.presentation.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            ViewBag.Title = "WMSPro";
            loginBL _loginBL = new loginBL();
            LoginVM _loginViewModel = new LoginVM();
            _loginViewModel.companylist = _loginBL.getCompanyList();
            _loginViewModel.yearlist = _loginBL.getFinancialList();

            return View(_loginViewModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(LoginVM _loginVM)
        {
            ViewBag.Title = "WMSPro";
            loginBL _loginBL = new loginBL();
            companyBL _companyBL = new companyBL(); 
            if (ModelState.IsValid)
            {
                try
                {
                    string login = _loginVM.login;
                    string password = _loginVM.password;
                   
                    int verifieduserId = 0;
                    UserVM _userVM = new UserVM();

                    verifieduserId = _loginBL.checkLogin(login, password);

                    if (verifieduserId != 0)
                    {
                        _userVM = _loginBL.getUserDataById(verifieduserId);

                        Session["userId"] = _userVM.userid;
                        Session["userlogin"] = _userVM.login;
                        Session["username"] = _userVM.firstname + " " + _userVM.lastname;
                        Session["companyid"] = _loginVM.selectedCompanyId;
                        Session["yearid"] = _loginVM.selectedYearId;
                        Session["companyname"] = _companyBL.getCompanyNameById(_loginVM.selectedCompanyId);

                        _loginBL.getUpdateUserLoginTime(_userVM.userid);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {

                        ModelState.AddModelError(string.Empty, "The user name or password for SSinternation is incorrect");

                    }


                }
                catch (Exception error)
                {
                    ModelState.AddModelError(string.Empty, error.Message);
                    _loginVM.companylist = _loginBL.getCompanyList();
                    _loginVM.yearlist = _loginBL.getFinancialList();

                }
                //to do
            }
            else {

                _loginVM.companylist = _loginBL.getCompanyList();
                _loginVM.yearlist = _loginBL.getFinancialList();
            }
           
            return View(_loginVM);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult logout()
        {
            Session.Abandon();
            Session.Clear();
            Session["userId"] = null;
            return RedirectToAction("Index", "Login");
        }

    }
    
}
