using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.dataaccess.POCO;
using SSinternational.viewmodel;
using AutoMapper;

namespace SSinternational.service
{
    public class BillSL
    {
        public decimal getStockBags(string garden, string invoice, string grade, decimal nett, int company)
        {
            BillPOCO _billPOCO = new BillPOCO();
            return _billPOCO.getStockBags(garden, invoice, grade, nett, company);
        }

        public int getStockLedgerId(string garden, string invoice, string grade, decimal nett, int company) {
            BillPOCO _billPOCO = new BillPOCO();
            return _billPOCO.getStockLedgerId(garden,invoice,grade,nett,company);
        
        }

        public int getArrivalInvoiceId(string garden, string invoice, string grade, decimal nett, int company)
        {
            BillPOCO _billPOCO = new BillPOCO();
            return _billPOCO.getArrivalInvoiceId(garden, invoice, grade, nett, company);
        }

       

       
        public int InsertBill(BillVM _vm) {
            BillPOCO _billPOCO = new BillPOCO();
            _billPOCO = Mapper.Map<BillVM, BillPOCO>(_vm);
            return _billPOCO.InsertBill(_billPOCO);
        }

        public int updateBuyerBill(BillVM _vm)
        {
            BillPOCO _billPOCO = new BillPOCO();
            _billPOCO = Mapper.Map<BillVM, BillPOCO>(_vm);
            return _billPOCO.updateBuyerBill(_billPOCO);
        }
        public IEnumerable<BillVM> getBuyerBillList(int company) {
            BillPOCO _billPOCO = new BillPOCO();
            IEnumerable<BillVM> _vm = Mapper.Map<IEnumerable<BillPOCO>, IEnumerable<BillVM>>(_billPOCO.getBuyerBillList(company));
            return _vm;
        }

        public BillVM getBuyerBillMasterDataById(int billMasterId) {
            BillPOCO _billPOCO = new BillPOCO();
            BillVM _vm = Mapper.Map<BillPOCO, BillVM>(_billPOCO.getBuyerBillMasterDataById(billMasterId));
            return _vm;
        }

        public IEnumerable<BillDetailsVM> getBillDetailsByBillMasterId(int billMasterId) {
            BillDetails _BillDtlsPOCO = new BillDetails();
            IEnumerable<BillDetailsVM> _vmDtls = Mapper.Map<IEnumerable<BillDetails>, IEnumerable<BillDetailsVM>>(_BillDtlsPOCO.getBillDetailsByBillMasterId(billMasterId));
            return _vmDtls;
        }

        public ratemasterVM getRateMasterData(int company, int year) {
            rateMasterPOCO ratemaster = new rateMasterPOCO();
            ratemasterVM _vm =Mapper.Map<rateMasterPOCO,ratemasterVM>(ratemaster.getRateMasterData(company,year));
            return _vm;
         }
        
    }
}
