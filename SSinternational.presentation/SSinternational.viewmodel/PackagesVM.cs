using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.viewmodel
{
  public  class PackagesVM
    {
      [Key]
        public int PackageId { get; set; }

        public string Code { get; set; }

        [Required(ErrorMessage = "Package name is required")]
        [Display(Name = "Name")]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int CompanyId { get; set; }
    }
}
