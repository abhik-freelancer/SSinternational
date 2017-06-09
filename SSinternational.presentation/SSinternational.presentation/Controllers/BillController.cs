using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;

namespace SSinternational.presentation.Controllers
{
    public class BillController : BaseController
    {
        //
        // GET: /Bill/

        public ActionResult Index()
        {
            if (this.LoggedUserId != 0)
            {
                int companyId = this.companyId;
                BillBL _BL = new BillBL();
                IEnumerable<BillVM> _VM = _BL.getBuyerBillList(companyId);

                return View(_VM);
            }
            else {
                return RedirectToAction("Index", "Login");
            }
            
        }

        public ActionResult addEditBill(int? billmasterId) {
            if (this.LoggedUserId != 0)
            {
                BillVM _billVM = new BillVM();
                gardenBL _gardenBL = new gardenBL();
                BillBL _billBL = new BillBL();
                if (Convert.ToInt32(billmasterId) != 0)
                {
                    //_billVM.deliverydate = DateTime.Today;
                    //_billVM.doDate = DateTime.Today;
                    //_billVM.doLodgDate = DateTime.Today;
                    //_billVM.promptdate = DateTime.Today;
                    //_billVM.extdDate = DateTime.Today;
                   
                    _billVM = _billBL.getBuyerBillMasterDataById(Convert.ToInt32(billmasterId));
                    _billVM.BillDetails = _billBL.getBillDetailsByBillMasterId(Convert.ToInt32(billmasterId));

                 }
                else {

                    //_billVM = _billBL.getRateSlab(this.financialyearId, this.companyId);
                    _billVM.deliverydate = DateTime.Today;
                    _billVM.doDate = DateTime.Today;
                    _billVM.doLodgDate = DateTime.Today;
                    _billVM.promptdate = DateTime.Today;
                    _billVM.extdDate = DateTime.Today;
                    
                }
                _billVM.rateslab = _billBL.getRateMasterData(this.companyId, this.financialyearId);  
                _billVM.gardenList = _gardenBL.getGardenList(this.companyId);
                return View(_billVM);
            }
            else {
                return RedirectToAction("Index", "Login");
            
            }
        }
        /// <summary>
        /// Save Bill
        /// </summary>
        /// <param name="_billVM"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveBill(BillVM billsData) {

            if (this.LoggedUserId != 0)
            {
                if (ModelState.IsValid)
                {
                    BillBL _billBl = new BillBL();
                    int rslt = 0;
                    
                    billsData.companyId = this.companyId;
                    billsData.yearId = this.financialyearId;

                    if (billsData.billId != 0)
                    {
                        rslt = _billBl.updateBuyerBill(billsData);
                    }
                    else
                    {
                        rslt = _billBl.InsertBill(billsData);
                    }
                    if (rslt != 0)
                    {
                        return new JsonResult { Data = new { status = "1", msg = "Data successfully saved. " } };
                    }
                    else {
                        return new JsonResult { Data = new { status = "0", msg = "Problem in Data saving" } };
                    }
                }
                else { 
                    //fields are required
                    return new JsonResult { Data = new { status = "2", msg = "" } };
                }
            }
            else {

                return new JsonResult { Data = new { status = "3", msg = "" } };
            }

           
        }


        [HttpGet]
        public ActionResult getInvoiceByGarden(string garden) {
            if (this.LoggedUserId != 0)
            {
                dataaccess.BillDAL _invoiceList = new dataaccess.BillDAL();
                System.Data.DataTable dtInvoices = _invoiceList.getInvoiceListByGarden(garden,this.companyId);
                List<SelectListItem> li = new List<SelectListItem>();

                if (dtInvoices.Rows.Count>0)
                {
                    foreach(System.Data.DataRow rows in dtInvoices.Rows ){
                        li.Add(new SelectListItem { Text = rows["Invoice"].ToString(), Value = rows["Invoice"].ToString() });
                    }                
                }
                ViewData["invoicelst"] = li;
                return PartialView();
            }
            else {
                return RedirectToAction("Index", "Login");
            }

        }

        [HttpGet]
        public ActionResult getGradeByGardenAndInvoice(string garden,string invoice) { 
        
            if(this.LoggedUserId!=0){
                dataaccess.BillDAL _invoiceList = new dataaccess.BillDAL();
                System.Data.DataTable dtGrade = _invoiceList.getGradeByGardenAndInvoice(garden, invoice, this.companyId);
                List<SelectListItem> li = new List<SelectListItem>();
                if (dtGrade.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow rows in dtGrade.Rows)
                    {
                        li.Add(new SelectListItem { Text = rows["Grade"].ToString(), Value = rows["Grade"].ToString() });
                    }
                }
                ViewData["gradeList"] = li;
                return PartialView();

            }else{
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult getNettByGardenAndInvoiceAndGrade(string garden,string invoice,string grade) {
            if (this.LoggedUserId != 0)
            {
                dataaccess.BillDAL _DAL = new dataaccess.BillDAL();
                System.Data.DataTable dtGrade = _DAL.getNettByGardenAndInvoiceAndGrade(garden, invoice, grade, this.companyId);
                List<SelectListItem> li = new List<SelectListItem>();
                if (dtGrade.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow rows in dtGrade.Rows)
                    {
                        li.Add(new SelectListItem { Text = rows["net"].ToString(), Value = rows["net"].ToString() });
                    }
                }
                ViewData["nettList"] = li;
                return PartialView();

            }
            else {
                return RedirectToAction("Index", "Login");
            }

        
        }

        [HttpGet]
        public JsonResult getStockBags(string garden, string invoice, string grade,Decimal nett)
        {
            var result = new Object();
            if (this.LoggedUserId != 0)
            {
               
                BillBL _billBL = new BillBL();
                decimal StockBgas = _billBL.getStockBags(garden, invoice, grade, nett,this.companyId);
                result = new { Data = StockBgas };
                return Json(result, JsonRequestBehavior.AllowGet);
             
            }
            else {

                result = new { Data = "3" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult getStockLedgerId(string garden, string invoice, string grade, Decimal nett)
        {
            var result = new Object();
            if (this.LoggedUserId != 0)
            {

                BillBL _billBL = new BillBL();
                int stockLedgerId = _billBL.getStockLedgerId(garden, invoice, grade, nett, this.companyId);
                result = new { Data = stockLedgerId };
                return Json(result, JsonRequestBehavior.AllowGet);

            }
            else
            {

                result = new { Data = "LOGOUT" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        
        }


        [HttpGet]
        public JsonResult getArrivalInvoiceId(string garden, string invoice, string grade, Decimal nett)
        {
            var result = new Object();
            if (this.LoggedUserId != 0)
            {

                BillBL _billBL = new BillBL();
                int invoiceId = _billBL.getArrivalInvoiceId(garden, invoice, grade, nett, this.companyId);
                result = new { Data = invoiceId };
                return Json(result, JsonRequestBehavior.AllowGet);

            }
            else
            {

                result = new { Data = "3" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

    }
}
