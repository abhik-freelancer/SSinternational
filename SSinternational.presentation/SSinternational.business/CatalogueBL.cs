using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.viewmodel;
using SSinternational.service;


namespace SSinternational.business
{
    public class CatalogueBL
    {
        public IEnumerable<CatalogueVM> getArrivalListByGardenId(int gardenId) {

            CatalogueSL _catlgSL = new CatalogueSL();
            return _catlgSL.getArrivalListByGardenId(gardenId);
        }

        public int[] getChestSerialRangeByArrivalDtlId(int arrivalInvoiceId) {
            CatalogueSL _catlgSL = new CatalogueSL();
            return _catlgSL.getChestSerialRangeByArrivalDtlId(arrivalInvoiceId);
        }

        public int catalogueInsert(CatalogueVM _VM){
            CatalogueSL _catlgSL = new CatalogueSL();
            return _catlgSL.catalogueInsert(_VM);    
        }

        public CatalogueVM getArrivalInvoiceDetail(int invoiceId) {
            CatalogueSL _catlgSL = new CatalogueSL();
            return _catlgSL.getArrivalInvoiceDetail(invoiceId);
        }

        public IEnumerable<CatalogueVM> getcatalogListByInvoiceId(int invoiceDetailsId)
        {
            CatalogueSL _catlgSL = new CatalogueSL();
            return _catlgSL.getcatalogListByInvoiceId(invoiceDetailsId);
        }

        public CatalogueVM getCatalogueById(int ctlgId) {
            CatalogueSL _catlgSL = new CatalogueSL();
            return _catlgSL.getCatalogueById(ctlgId);
        
        }
        public void update(CatalogueVM _VM){
            CatalogueSL _catlgSL = new CatalogueSL();
            _catlgSL.update(_VM);
        }
    }
}
