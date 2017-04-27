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
            ViewBag.companyName = this.LoggedCompanyName;
            unloadingBL _BL = new unloadingBL();
            IEnumerable<UnloadingDtlListVM> _VM = _BL.getListOfUnloadingInvoices(masterid);
            return View(_VM);
        }

        public ActionResult addInvoice(int unloadMasterId) {

            if (this.LoggedUserId != 0)
            {
                if (unloadMasterId != 0)
                {
                    ViewBag.companyName = this.LoggedCompanyName;

                    UnloadingDtlAddEditVM _VM = new UnloadingDtlAddEditVM();
                    FloorsBL _floorList = new FloorsBL();
                    DamagetypesBL _damageList = new DamagetypesBL();
                    ShorttypesBL _shortList = new ShorttypesBL();
                    _VM.floorList = _floorList.getFloorList();
                    _VM.damageSelectList = _damageList.GetAllDamageTypes();
                    _VM.shorttypeSelectList = _shortList.GetAllShortTypes();
                    return View(_VM);

                }
                else {
                    return RedirectToAction("Index", "Unloadingmaster");
                
                }
            

            }else{
             return RedirectToAction("Index", "Login");
            }
        
        }

    }
}
