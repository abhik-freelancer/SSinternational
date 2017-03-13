using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SSinternational.viewmodel
{
   public  class LoginVM
    {
       [Required (ErrorMessage="Login name is required.")]
       [Display (Name="Login")]
       public string login { get; set; }
       
       [Required (ErrorMessage="Password is required")]
       [Display (Name="Password")]
       public string password { get; set; }

       [Required(ErrorMessage = "Please select company")]
       [Display(Name = "Company")]
       public int selectedCompanyId { get; set; }
       public IEnumerable<CompanyVM> companylist { set; get; }

       [Required(ErrorMessage = "Please select year")]
       [Display(Name = "Year")]
       public int selectedYearId { get; set; }
       public IEnumerable<financialVM> yearlist { set; get; }
      
    }
}
