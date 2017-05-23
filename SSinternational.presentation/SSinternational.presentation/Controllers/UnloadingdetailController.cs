using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSinternational.viewmodel;
using SSinternational.business;

namespace SSinternational.presentation.Controllers
{
    public class UnloadingdetailController : BaseController
    {
        //
        // GET: /Unloadingdetail/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult addEditUnloadingDetail(int unloadingmasterId) {

            if (this.LoggedUserId != 0)
            {
                //return View();    
                unloadingBL _BL = new unloadingBL();
                int numberofinvoices = _BL.getNumberofInvoices(unloadingmasterId);

                if (numberofinvoices==0)
                {
                    //add
                    return RedirectToAction("addInvoice", new { unloadMasterId = unloadingmasterId });
                }else{
                   // listofInvoices(unloadingmasterId);
                   return RedirectToAction("listofInvoices", new { masterid = unloadingmasterId });
                }

               
            }
            else {

                return RedirectToAction("Index", "Login");
            }
            
        }

        public ActionResult listofInvoices(int masterid) {
            //unloadMasterId=@unldDtl.unloadingmasterid ,unloadingdetailId = @unldDtl.unloadingDetailId
            if (this.LoggedUserId != 0)
            {
                ViewBag.companyName = this.LoggedCompanyName;
                ViewBag.unloadMasterId = masterid;
                unloadingBL _BL = new unloadingBL();
                IEnumerable<UnloadingDtlListVM> _VM = _BL.getListOfUnloadingInvoices(masterid);
                return View(_VM);
            }
            else {

                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult addInvoice(int unloadMasterId, int? unloadingdetailId)
        {

            if (this.LoggedUserId != 0)
            {
                if (unloadMasterId != 0)
                {
                    ViewBag.companyName = this.LoggedCompanyName;
                    int companyId = this.companyId;
                    UnloadingDtlAddEditVM _VM = new UnloadingDtlAddEditVM();
                    unloadingBL _BL = new unloadingBL();

                    PackagesBL _packageList = new PackagesBL();
                    FloorsBL _floorList = new FloorsBL();
                    DamagetypesBL _damageList = new DamagetypesBL();
                    ShorttypesBL _shortList = new ShorttypesBL();

                    if (unloadingdetailId != 0) {
                        _VM = _BL.GetUnloadingDtlById(unloadMasterId,Convert.ToInt32(unloadingdetailId));
                        _VM.damageBagDtls = _BL.GetDamageBagDetailById(Convert.ToInt32(unloadingdetailId));
                        _VM.shortBagDtls = _BL.GetShoertBagDtlById(Convert.ToInt32(unloadingdetailId));
                    }

                    _VM.packageList = _packageList.GetAllPackages(companyId);
                    _VM.floorList = _floorList.getFloorList();
                    _VM.damageSelectList = _damageList.GetAllDamageTypes();
                    _VM.shorttypeSelectList = _shortList.GetAllShortTypes();
                    _VM.unloadingmasterid = unloadMasterId;

                    _VM.invoiceformatId = _BL.checkInvoiceFormatId(unloadMasterId);
                    _VM.gardenCode = _BL.getGardenCode(unloadMasterId);
                    
                    return View(_VM);

                }
                else {
                    return RedirectToAction("Index", "Unloadingmaster");
                
                }
            

            }else{
             return RedirectToAction("Index", "Login");
            }
        
        }
        /**
         * Saving unloading invoice
         * 29/04/2017
         * 
         * */
        [HttpPost]
        public JsonResult Saveunloadingdetail(UnloadingDtlAddEditVM unloadingInvoice)
        {
            if (this.LoggedUserId != 0)
            {
                ModelState.Remove("unloadingDetailId");
                unloadingBL _BL = new unloadingBL();

             


                if (ModelState.IsValid)
                {
                    int rslt;
                    int unldDtlId = unloadingInvoice.unloadingDetailId;

                    if (unldDtlId!= 0)
                    {
                        //rslt = 0;
                        rslt =_BL.UpadateunloadingInvoices(unloadingInvoice);
                    }
                    else
                    {
                         rslt = _BL.UnloadedInvoiceInsert(unloadingInvoice);
                    }
                    if (rslt == 1)
                    {
                        //return RedirectToAction("Index", "Login");
                        return new JsonResult { Data = new { status = "1", msg="Data successfully saved. " } };

                        //return RedirectToAction("listofInvoices", new { masterid = unloadingInvoice.unloadingmasterid });
                    }
                    else {

                        //ModelState.AddModelError("", "Save fail due to internal data base error");
                        //return View(unloadingInvoice);
                        return new JsonResult { Data = new { status = "0", msg = "Data save unsucessfull." } };
                    
                    }

                    
                }
                else {
                    //model satate fail
                   return new JsonResult { Data = new { status = "3", msg="Field validation fail" } };

                   // return View(unloadingInvoice);
                }

                
            }
            else {
               // return RedirectToAction("Index", "Login");
                return new JsonResult { Data = new { status = "2", msg = "" } };
            }


            
        }
		
        [ChildActionOnly]
        public ActionResult partialListInadd(int unloadMasterId) {

            unloadingBL _BL = new unloadingBL();
            IEnumerable<UnloadingDtlListVM> _VM = _BL.getListOfUnloadingInvoices(unloadMasterId);
            return PartialView(_VM); 
        
        }

        



    }
}
