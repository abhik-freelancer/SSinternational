using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;

namespace SSinternational.presentation.Controllers
{
    public class CustomerController : BaseController
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            if (this.LoggedUserId !=0)
            {
                int companyId = this.companyId;
                customerBL _customerBl = new customerBL();
                IEnumerable<CustomerVM> _custLstvm = _customerBl.getCustomerList(companyId).ToList();    

                return View(_custLstvm);
            }
            else {

                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult addEdit(int? customerId) {
            if (this.LoggedUserId != 0)
            {
                CustomerVM _customerEditVM = new CustomerVM();
                if (customerId != null)
                {
                    customerBL _customerBL = new customerBL();
                     _customerEditVM = _customerBL.getCustomerById(Convert.ToInt32(customerId));


                }
                return View(_customerEditVM);
            }
            else
            {

                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addEdit(CustomerVM customerVM) {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            ModelState.Remove("customerId");
            if (ModelState.IsValid)
            {
                try
                {
                    #region
                    int customerid = customerVM.customerId;
                    customerVM.companyid = this.companyId;
                    customerBL _customerBL = new customerBL();

                    if (customerid != 0)
                    {
                        _customerBL.upadateCustomer(customerVM);
                        return RedirectToAction("Index", "Customer");
                    }
                    else
                    {
                        _customerBL.insertCustomer(customerVM);
                        return RedirectToAction("Index", "Customer");
                    }
                    #endregion
                }
                catch (Exception ex) {

                    ModelState.AddModelError("", ex.Message);
                    return View(customerVM);
                }
             }
            else {
                return View(customerVM);
            }
            
        }

        [HttpPost]
        public ActionResult DeleteCustomer(string customerId)
        {
            var returnData = new object();
            if (this.LoggedUserId != 0)
            {
                customerBL _customerBL = new customerBL();
                Boolean deletionCustomer = _customerBL.deleteCustomer(Convert.ToInt32(customerId));

                if (deletionCustomer)
                {
                    returnData = new { msg_code = "1", msg_data = "<p>Customer has removed from your database</p>" };
                }
                else {
                    returnData = new { msg_code = "0", msg_data = "<p>Permission deny for deletion</p>" };
                }


            }
            else {

                return RedirectToAction("Index", "Login");    
            }


            return Json(returnData, JsonRequestBehavior.DenyGet);  
        }






    }
}
