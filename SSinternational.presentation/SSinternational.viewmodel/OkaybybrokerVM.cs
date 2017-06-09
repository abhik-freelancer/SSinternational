using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SSinternational.viewmodel
{
   public class OkaybybrokerVM
    {
       [Key]
       public int arrivalDetailId { get; set; }
       [Display(Name="Garden")] 
       public string garden { get; set; }
       [Display(Name="Crop year") ]
       public string yearofproduction { get; set; }
       [Display(Name="Grade")] 
       public string grade { get; set; }
       
       [Display (Name="Net (Kgs)")]
       public decimal net { get; set; }
       [Display (Name="Invoice")] 
       public string invoices { get; set; }

       [Display(Name = "Arrival")] 
       public string arrivalNumber { get; set; }

       public int arrivalId { get; set; }
       public IEnumerable<ArrivalMasterVM> arrivalList { get; set; }
      
       [Display (Name="Broker")]
       public int brokerId { get; set; }
       public IEnumerable<BrokersVM> brokersList { get; set; }


       public IEnumerable<DamagetypesVM> damageDropDownList { get; set; }


       public IEnumerable<DamageBagDtlsVM> damageBagDetails { get; set; }
        
    }
}
