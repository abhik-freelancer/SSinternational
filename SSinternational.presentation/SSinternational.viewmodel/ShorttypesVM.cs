using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.viewmodel
{
   public class ShorttypesVM
   {
       [Key]
        public int ShortId { get; set; }
        [Display(Name = "Code")]
        public string ShortCode { get; set; }

        [Required(ErrorMessage = "Shorttype name is required")]
        [Display(Name = "Name")]
        public string ShortName { get; set; }
        public int CompanyId { get; set; }
    }
}
