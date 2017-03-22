using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SSinternational.viewmodel;
using SSinternational.dataaccess.POCO;

namespace SSinternational.service
{
    public class invoiceformatSL
    {
        public IEnumerable<InvoiceformatVM> getInvoiceFormat() {
            invoiceformat _invoiceformatPOCO = new invoiceformat();
            IEnumerable<InvoiceformatVM> _invcfrmtVM = Mapper.Map <IEnumerable<invoiceformat> ,IEnumerable<InvoiceformatVM>>(_invoiceformatPOCO.getInvoiceFormatList());
            return _invcfrmtVM;
        
        }
    }
}
