using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SSinternational.dataaccess.POCO
{
   
    public class BillPOCO
    {
       
        public int billId { get; set; }
        public string billnumber { get; set; }
        public DateTime deliverydate { get; set; }
        public string buyer { get; set; }
        public string sarkar { get; set; }
        public string doNumber { get; set; }
        public DateTime doDate { get; set; }
        public decimal grandtotalamount { get; set; }
        public int companyId { get; set; }
        public int yearId { get; set; }
        public int numberofbags { get; set; }
        public string saleno { get; set; }
        public string lotnumber { get; set; }
        public Nullable<DateTime> doLodgDate { get; set; }
        public Nullable<DateTime> promptdate { get; set; }
        public Nullable<DateTime> extdDate { get; set; }
        public decimal? weeksdue { get; set; }

        //public decimal additionalRent { get; set; }
        //public decimal streetRemovalRent { get; set; }
        //public decimal checkWeighmentRent { get; set; }
        //public decimal samplingRate { get; set; }


        //public decimal slab_rate1 { get; set; }
        //public decimal slab_rate2 { get; set; }
        //public decimal slab_rate3 { get; set; }
        //public decimal slab_rate4 { get; set; }
        
        public IEnumerable<BillDetails> BillDetails { get; set; }
        /// <summary>
        /// Get billing list based on companyId
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>

        public IEnumerable<BillPOCO> getBuyerBillList(int company) {
            BillDAL _DAL = new BillDAL();
            DataTable dt = _DAL.getBuyerBillList(company);
            List<BillPOCO> _lstBill = new List<BillPOCO>();

            if (dt.Rows.Count > 0) { 
                foreach(DataRow rows in dt.Rows){
                    BillPOCO _billObj = new BillPOCO();
                    _billObj.billId = Convert.ToInt32(rows["billId"].ToString());
                    _billObj.billnumber = rows["billnumber"].ToString();
                    _billObj.deliverydate = Convert.ToDateTime(rows["deliverydate"].ToString());
                    _billObj.buyer = rows["buyer"].ToString();
                    _billObj.sarkar = rows["sarkar"].ToString();
                    _billObj.doNumber = rows["doNumber"].ToString();
                    _billObj.doDate =Convert.ToDateTime(rows["doDate"].ToString());
                    _billObj.grandtotalamount = Convert.ToDecimal(rows["grandtotalamount"].ToString());

                    _lstBill.Add(_billObj);
                }
            }
            return _lstBill;
        }

        public decimal getStockBags(string garden, string invoice, string grade, decimal nett, int company)
        {
            BillDAL _DAL = new BillDAL();
            return _DAL.getStockBags(garden, invoice, grade, nett, company);
        }
        public int getStockLedgerId(string garden, string invoice, string grade, decimal nett, int company) {
            BillDAL _DAL = new BillDAL();
            return _DAL.getStockLedgerId(garden,invoice,grade,nett,company);
        }
        public int getArrivalInvoiceId(string garden, string invoice, string grade, decimal nett, int company)
        {
            BillDAL _DAL = new BillDAL();
            return _DAL.getArrivalInvoiceId(garden,invoice,grade,nett,company);
        
        }

        
        public int InsertBill(BillPOCO Bill) {
            BillDAL _DAL = new BillDAL();
            return _DAL.InsertBill(Bill);
        }

        public int updateBuyerBill(BillPOCO Bill) {
            BillDAL _DAL = new BillDAL();
            return _DAL.updateBuyerBill(Bill);
        }

        public BillPOCO getBuyerBillMasterDataById(int billMasterId) {
            BillDAL _DAL = new BillDAL();
            DataTable dt = _DAL.getBuyerBillMasterDataById(billMasterId);
            BillPOCO _billObj = new BillPOCO();
            if(dt.Rows.Count>0){
                DataRow rows = dt.Rows[0];
                _billObj.billId = Convert.ToInt32(rows["billId"].ToString());
                _billObj.billnumber = rows["billnumber"].ToString();
                _billObj.deliverydate = Convert.ToDateTime(rows["deliverydate"].ToString());
                _billObj.buyer = rows["buyer"].ToString();
                _billObj.sarkar = rows["sarkar"].ToString();
                _billObj.doNumber = rows["doNumber"].ToString();
                _billObj.doDate =Convert.ToDateTime(rows["doDate"].ToString());
                _billObj.grandtotalamount = Convert.ToDecimal(rows["grandtotalamount"].ToString());

            }
            return _billObj;
        }

    }
}
