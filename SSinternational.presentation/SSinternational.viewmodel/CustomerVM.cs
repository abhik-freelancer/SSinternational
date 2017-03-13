using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SSinternational.viewmodel
{
    public class CustomerVM
    {   
        [Key]       
        public int customerId { get; set; }

        [Required (ErrorMessage="Customer name is required")]
        [Display (Name="Customer")]
        public string customername { get; set; }

        [Required (ErrorMessage="Phone is required")]
        [Display (Name="Phone")]
        public string customerphone { get; set; }
        
        [Display (Name="Address")]
        public string customeraddress { get; set; }

        public int companyid { get; set; }


    }
}
