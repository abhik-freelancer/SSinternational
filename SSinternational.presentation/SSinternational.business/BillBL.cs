using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.viewmodel;
using SSinternational.service;

namespace SSinternational.business
{
   public class BillBL
    {
       public decimal getStockBags(string garden, string invoice, string grade, decimal nett, int company)
       {
           BillSL _billSL = new BillSL();
           return _billSL.getStockBags(garden, invoice, grade, nett, company);
       }

       public int getStockLedgerId(string garden, string invoice, string grade, decimal nett, int company) {
           BillSL _billSL = new BillSL();
           return _billSL.getStockLedgerId(garden,invoice,grade,nett,company);
       }

       public int getArrivalInvoiceId(string garden, string invoice, string grade, decimal nett, int company) {
           BillSL _billSL = new BillSL();
           return _billSL.getArrivalInvoiceId(garden, invoice, grade, nett, company); 
       }

     

       public int InsertBill(BillVM _vm)
       {
           BillSL _billSL = new BillSL();

           return _billSL.InsertBill(_vm);
       }

       public int updateBuyerBill(BillVM _vm)
       {
           BillSL _billSL = new BillSL();

           return _billSL.updateBuyerBill(_vm);
       }


       public IEnumerable<BillVM> getBuyerBillList(int company) {
           BillSL _billSL = new BillSL();
           return _billSL.getBuyerBillList(company);
       }
       /// <summary>
       /// Get Bill Master Data Based on Id
       /// </summary>
       /// <param name="billMasterId"></param>
       /// <returns></returns>
       public BillVM getBuyerBillMasterDataById(int billMasterId) {
           BillSL _billSL = new BillSL();
           return _billSL.getBuyerBillMasterDataById(billMasterId);
       }
       /// <summary>
       /// Get Bill details by id
       /// </summary>
       /// <param name="billMasterId"></param>
       /// <returns></returns>
       public IEnumerable<BillDetailsVM> getBillDetailsByBillMasterId(int billMasterId) {
           BillSL _billSL = new BillSL();
           return _billSL.getBillDetailsByBillMasterId(billMasterId);
       
       }
       /// <summary>
       /// rate master data for buyer bill
       /// </summary>
       /// <param name="company"></param>
       /// <param name="year"></param>
       /// <returns></returns>
       public ratemasterVM getRateMasterData(int company, int year) {
           BillSL _billSL = new BillSL();
           return _billSL.getRateMasterData(company, year);
       }

    }
}
