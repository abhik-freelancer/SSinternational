using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.viewmodel
{
   public class WarehousesVM
    {
       [Key]
        public int WarehouseId { get; set; }

       [Required(ErrorMessage = "Warehouse name is required")]
       [Display(Name = "Warehouse")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
