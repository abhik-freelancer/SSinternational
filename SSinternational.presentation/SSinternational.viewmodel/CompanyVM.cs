using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SSinternational.viewmodel
{
    public class CompanyVM
    {
        public int companyid { get; set; }
        public string company { get; set; }
        public string companyaddress { get; set; }
        public string companystate { get; set; }
        public string companypin { get; set; }
        public string companytin { get; set; }
        public string companypan { get; set; }
        public string companytan { get; set; }

    }
}
