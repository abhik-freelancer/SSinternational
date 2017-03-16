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
       public string gardencode { get; set; }
       
       [Required (ErrorMessage="Please select customer")]
       [Display (Name="Customer")]
       public int customerid { get; set; }
       public IEnumerable<CustomerVM> customerList { get; set; }
       
       

    }
}
