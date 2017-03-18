using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.viewmodel
{
  public class DamagetypesVM
    {
        [Key]
        public int DamageId { get; set; }
        public string DamageCode { get; set; }

        [Required(ErrorMessage = "Damage Description is required")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
