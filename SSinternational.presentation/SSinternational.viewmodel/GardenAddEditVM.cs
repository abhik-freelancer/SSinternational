using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SSinternational.viewmodel
{
   public class GardenAddEditVM
    {
       [Key]
        public int gardenId { get; set; }
       [Required (ErrorMessage="Garden name is required")]
       [Display (Name="Garden")]
       public string gardenname { get; set; }
       
       [Display (Name="Code")]
       [Required (ErrorMessage="Code is required")]
       public string gardencode { get; set; }
       
       [Required (ErrorMessage="Please select customer")]
       [Display (Name="Customer")]
       public int customerid { get; set; }
       public IEnumerable<CustomerVM> customerList { get; set; }


       [Display(Name = "Invoice Format")]
       public int invoiceformatid { get; set; }
       public IEnumerable<InvoiceformatVM> invoiceFormatList { get; set; }

       [Display(Name = "Alias")]
       public string gardenalias { get; set; }

       public int companyid { get; set; }
       
       

    }
}
