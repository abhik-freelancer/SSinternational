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
    public class CatalogueSL
    {
        public IEnumerable<CatalogueVM> getArrivalListByGardenId(int gardenId) {

            Catalogue _catlgPOCO = new Catalogue();
            IEnumerable<CatalogueVM> _VM = Mapper.Map<IEnumerable<Catalogue>, IEnumerable<CatalogueVM>>(_catlgPOCO.getArrivalListByGardenId(gardenId));
            return _VM;
        }

        public int[] getChestSerialRangeByArrivalDtlId(int arrivalInvoiceId) {
            Catalogue _catlgPOCO = new Catalogue();
            return _catlgPOCO.getChestSerialRangeByArrivalDtlId(arrivalInvoiceId);
        
        }

        public int catalogueInsert(CatalogueVM _VM)
        {
            Catalogue _catlgPOCO = new Catalogue();
            _catlgPOCO = Mapper.Map<CatalogueVM,Catalogue>(_VM);
            return _catlgPOCO.catalogueInsert(_catlgPOCO);
        }

        public CatalogueVM getArrivalInvoiceDetail(int invoiceId) {
            CatalogueVM _VM = new CatalogueVM();
            Catalogue _catlgPOCO = new Catalogue();
            _VM = Mapper.Map<Catalogue, CatalogueVM>(_catlgPOCO.getArrivalInvoiceDetail(invoiceId));
            return _VM;
        
        }

        public IEnumerable<CatalogueVM> getcatalogListByInvoiceId(int invoiceDetailsId)
        {
            Catalogue _catlgPOCO = new Catalogue();
            IEnumerable<CatalogueVM> _VM = Mapper.Map<IEnumerable<Catalogue>, IEnumerable<CatalogueVM>>(_catlgPOCO.getcatalogListByInvoiceId(invoiceDetailsId));
            return _VM;
        }

        public CatalogueVM getCatalogueById(int ctlgId)
        {
            Catalogue _catlgPOCO = new Catalogue();
            CatalogueVM _VM = Mapper.Map<Catalogue, CatalogueVM>(_catlgPOCO.getCatalogueById(ctlgId));
            return _VM;
        }

        public void update(CatalogueVM _VM) {
            Catalogue _catlgPOCO = new Catalogue();
            _catlgPOCO = Mapper.Map<CatalogueVM, Catalogue>(_VM);
            _catlgPOCO.update(_catlgPOCO);
        }
    }
}
