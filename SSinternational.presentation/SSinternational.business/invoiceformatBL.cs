using SSinternational.service;
using SSinternational.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.business
{
   public class invoiceformatBL
    {
       public IEnumerable<InvoiceformatVM> getListOfInvoiceFormat() {

           invoiceformatSL _invoicefrmtSL = new invoiceformatSL();
           return _invoicefrmtSL.getInvoiceFormat();
       
       }
       
    }
}
