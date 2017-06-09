using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SSinternational.dataaccess.POCO
{
   public class BillDetails
    {
       public int BillDetailid {get;set;}
       public int billmasterid { get; set; }
       public int stockid { get; set; }
       public int invoiceId { get; set; }
       public string invoice { get; set; }
       public int numberofbags { get; set; }
       public string saleno { get; set; }
       public string lotnumber { get; set; }
       public Nullable<DateTime> doLodgDate { get; set; }
       public Nullable<DateTime> promptdate { get; set; }
       public Nullable<DateTime> extdDate { get; set; }
       public decimal weeksdue { get; set; }
       public int addtionalRentBgas { get; set; }
       public decimal addtionalRentRate { get; set; }
       public decimal addtionalRentAmount { get; set; }
       public int streetRmvBags { get; set; }
       public decimal streetRmvRent { get; set; }
       public decimal streetRmvAmount { get; set; }
       public int chkWghBags { get; set; }
       public decimal chkWghRate { get; set; }
       public decimal chkWghAmount { get; set; }
       public int samplingWghBag { get; set; }
       public decimal samplingRate { get; set; }
       public decimal samplingAmount { get; set; }
       public decimal totalAmount { get; set; }

       public IEnumerable<BillDetails> getBillDetailsByBillMasterId(int billMasterId) {

           BillDAL _BillsDAL = new BillDAL();
           DataTable dt = _BillsDAL.getBillDetailsByBillMasterId(billMasterId);
           List<BillDetails> _lstBillDtls = new List<BillDetails>();

           if (dt.Rows.Count > 0) { 
                foreach(DataRow rows in dt.Rows){
                    BillDetails _obj = new BillDetails();
                    _obj.BillDetailid = Convert.ToInt32(rows["id"].ToString());
                    _obj.billmasterid = Convert.ToInt32(rows["billmasterid"].ToString());
                    _obj.stockid = Convert.ToInt32(rows["stockid"].ToString());
                    _obj.invoiceId = Convert.ToInt32(rows["invoiceId"].ToString());
                    _obj.invoice = rows["invoice"].ToString();
                    _obj.numberofbags =Convert.ToInt32(rows["numberofbags"].ToString());
                    _obj.saleno = rows["saleno"].ToString();
                    _obj.lotnumber = rows["lotnumber"].ToString();
                    if (rows["doLodgDate"] != DBNull.Value)
                    {
                        _obj.doLodgDate = Convert.ToDateTime(rows["doLodgDate"].ToString());

                    }
                    else {
                        _obj.doLodgDate = null;
                    }
                    _obj.promptdate = Convert.ToDateTime(rows["promptdate"].ToString());
                    _obj.extdDate = Convert.ToDateTime(rows["extdDate"].ToString());
                    _obj.weeksdue = Convert.ToDecimal(rows["weeksdue"].ToString());
                    _obj.addtionalRentBgas = Convert.ToInt32(rows["addtionalRentBgas"].ToString());
                    _obj.addtionalRentRate = Convert.ToDecimal(rows["addtionalRentRate"].ToString());
                    _obj.addtionalRentAmount = Convert.ToDecimal(rows["addtionalRentAmount"].ToString());
                    _obj.streetRmvBags = Convert.ToInt32(rows["streetRmvBags"].ToString());
                    _obj.streetRmvRent = Convert.ToDecimal(rows["streetRmvRent"].ToString());
                    _obj.streetRmvAmount = Convert.ToDecimal(rows["streetRmvAmount"].ToString());
                    _obj.chkWghBags = Convert.ToInt32(rows["chkWghBags"].ToString());
                    _obj.chkWghRate = Convert.ToDecimal(rows["chkWghRate"].ToString());
                    _obj.chkWghAmount = Convert.ToDecimal(rows["chkWghAmount"].ToString());

                    _obj.samplingWghBag = Convert.ToInt32(rows["samplingWghBag"].ToString());
                    _obj.samplingRate = Convert.ToDecimal(rows["samplingRate"].ToString());
                    _obj.samplingAmount = Convert.ToDecimal(rows["samplingAmount"].ToString());
                    _obj.totalAmount = Convert.ToDecimal(rows["totalAmount"].ToString());

                    _lstBillDtls.Add(_obj);
                }
           
           }
           return _lstBillDtls;
       }
    }
}
