using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.dataaccess.POCO
{
    public class invoiceformat
    {
        public int id { get; set; }
        public string invoiceformats { get; set; }


        public IEnumerable<invoiceformat> getInvoiceFormatList() {

            DataTable dt;

            invoicefromatDAL _invoiceDAL = new invoicefromatDAL();
            dt = _invoiceDAL.getInvoiceFormat();
            List<invoiceformat> _lst = new List<invoiceformat>();
            if (dt.Rows.Count > 0) {

                foreach (DataRow rows in dt.Rows) {

                    invoiceformat _invoicefrmt = new invoiceformat();
                    _invoicefrmt.id = Convert.ToInt32(rows["id"].ToString());
                    _invoicefrmt.invoiceformats = rows["invoiceformat"].ToString();
                    _lst.Add(_invoicefrmt);
                }
               }
            return _lst;
        
        }
    }
}
