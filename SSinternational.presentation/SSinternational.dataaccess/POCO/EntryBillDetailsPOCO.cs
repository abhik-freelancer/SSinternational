using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SSinternational.dataaccess.POCO
{
    public class EntryBillDetailsPOCO
    {
        public int EntryBillDetailId { get; set; }
        public int entryBillMasterId { get; set; }
        public string arrivalnumber { get; set; }

        public int arrivalId { get; set; }
        public int invoiceid { get; set; }
        public string invoice { get; set; }
        public decimal receiptbags { get; set; }
        public string grade { get; set; }
        public decimal nett { get; set; }

        public IEnumerable<EntryBillDetailsPOCO> getArrivalInvoices(int arrivalId) {
            EntryBillDAL _dal = new EntryBillDAL();
            DataTable dt = _dal.getArrivalInvoices(arrivalId);
            List<EntryBillDetailsPOCO> _lstData = new List<EntryBillDetailsPOCO>();
            if(dt.Rows.Count>0){

                foreach (DataRow rows in dt.Rows) {
                    EntryBillDetailsPOCO _objEntryBillDtl = new EntryBillDetailsPOCO();

                    _objEntryBillDtl.arrivalId = Convert.ToInt32(rows["arrivalId"].ToString());
                    _objEntryBillDtl.invoiceid = Convert.ToInt32(rows["id"].ToString());
                    _objEntryBillDtl.invoice = rows["invoice"].ToString();
                    _objEntryBillDtl.receiptbags = Convert.ToDecimal(rows["receivequantity"].ToString());
                    _objEntryBillDtl.grade = rows["grade"].ToString();
                    _objEntryBillDtl.nett = Convert.ToDecimal(rows["net"].ToString());

                    _lstData.Add(_objEntryBillDtl);
                }
            }
            return _lstData;
        }
    }
}
