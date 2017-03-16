using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.service;
using SSinternational.viewmodel;
namespace SSinternational.business
{
    public class estateBL
    {
        public IEnumerable<EsatetVM> getEstateList(int companyId)
        {
            estateSL _estateSL = new estateSL();
            return _estateSL.getEstateList(companyId);
        }


        public int insertEstate(EsatetVM _estateVM)
        {
            int insertion = 0;
            estateSL _estateSL = new estateSL();
            insertion = _estateSL.insertEstate(_estateVM);
            return insertion;
        }

        public EsatetVM getEstateById(int estateId)
        {
            estateSL _estateSL = new estateSL();
            return _estateSL.getEstateById(estateId);

        }

        public void upadateEstate(EsatetVM _estateVM)
        {
            estateSL _estateForEdit = new estateSL();
            _estateForEdit.upadateEstate(_estateVM);

        }

        public Boolean deleteEstate(int estateId)
        {
            estateSL _estateSL = new estateSL();
            return _estateSL.deleteEstate(estateId);

        }
    }
}
