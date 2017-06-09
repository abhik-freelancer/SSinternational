using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SSinternational.dataaccess.POCO
{
    public class EntryBillPOCO
    {
        public int EntryBillId { get; set; }
        public string EntryBillNumber { get; set; }
        public DateTime EntrybillDate { get; set; }
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public int Garden { get; set; }
        public string gardencode { get; set; }
        public int BrokerId { get; set; }
        public string BrokerName { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public int companyId { get; set; }
        public int yearId { get; set; }
        public decimal totalBillAmount { get; set; }
        public decimal Rate { get; set; }
        public int totalBags { get; set; }


        public IEnumerable<EntryBillPOCO> getEntryBillList(int company, int year) {
            EntryBillDAL _entryBillDAL = new EntryBillDAL();
            DataTable dt = _entryBillDAL.getEntryBillList(company, year);
            List<EntryBillPOCO> _lst = new List<EntryBillPOCO>();
            if (dt.Rows.Count > 0) { 
               foreach(DataRow rows in dt.Rows){
                   EntryBillPOCO _entryBill = new EntryBillPOCO();
                   _entryBill.EntryBillId = Convert.ToInt32(rows["EntryBillId"].ToString());
                   _entryBill.EntryBillNumber = rows["EntryBillNumber"].ToString();
                   _entryBill.EntrybillDate = Convert.ToDateTime(rows["EntrybillDate"].ToString());
                   _entryBill.Customer = rows["customername"].ToString();
                   _entryBill.gardencode = rows["gardencode"].ToString();
                   _entryBill.BrokerName = rows["BrokerName"].ToString();
                   _entryBill.totalBillAmount =Convert.ToDecimal(rows["totalBillAmount"].ToString());
                   _lst.Add(_entryBill);
               }
            
            }
            return _lst;
        }

    }
}
