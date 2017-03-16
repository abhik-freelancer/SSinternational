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
    public class companySL
    {

        public IEnumerable<CompanyVM> getCompanyList() {
            companies _companiesPOCO = new companies();
            return Mapper.Map<IEnumerable<companies>, IEnumerable<CompanyVM>>(_companiesPOCO.getCompanyList());
           }

        public string getCompanyNameById(int companyId) {
            companies _companies = new companies();
            return _companies.getCompanyNameById(companyId);
        }
    }
}
