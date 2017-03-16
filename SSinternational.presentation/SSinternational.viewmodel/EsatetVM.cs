using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SSinternational.viewmodel
{
   public class EsatetVM
    {
        [Key]
        public int estateId { get; set; }
       
        [Required (ErrorMessage="Estate name is required")]
        [Display (Name="Tea Estate")]
        public string estate { get; set; }
        
        [Display (Name="Code")]
        public string estatecode { get; set; }
        public int companyid { get; set; }

    }
}
