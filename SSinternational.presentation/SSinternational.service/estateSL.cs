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
    public class estateSL
    {
        public IEnumerable<EsatetVM> getEstateList(int companyId)
        {
            estates _estatePOCO = new estates();
            IEnumerable<EsatetVM> _estateVM = Mapper.Map<IEnumerable<estates>, IEnumerable<EsatetVM>>(_estatePOCO.getEstateList(companyId));
            return _estateVM;

        }

        public int insertEstate(EsatetVM _estateVM)
        {
            estates _estatePOCO = new estates();
            _estatePOCO = Mapper.Map<EsatetVM, estates>(_estateVM);
            return _estatePOCO.insertEstate(_estatePOCO);

        }

        public EsatetVM getEstateById(int estateId)
        {

            estates _estatePOCO = new estates();
            EsatetVM _estateVM = Mapper.Map<estates, EsatetVM>(_estatePOCO.getEstateById(estateId));
            return _estateVM;

        }

        public void upadateEstate(EsatetVM _estateVM)
        {

            estates _estatesPOCO = new estates();
            _estatesPOCO = Mapper.Map<EsatetVM, estates>(_estateVM);
            _estatesPOCO.upadateEstate(_estatesPOCO);

        }

        public Boolean deleteEstate(int estateId)
        {
            estates _estatePOCO = new estates();
            return _estatePOCO.DeleteEstate(estateId);


        }
    }
}
