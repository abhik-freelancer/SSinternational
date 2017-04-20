using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SSinternational.viewmodel
{
   public class UnloadingmasterVM
    {   
        [Key]
        public int id { get; set; }
        [Display(Name="Unloading No.") ]
        public string unloadingnumber { get; set; }
        
       [Display (Name="Receipt Date")]
       [Required (ErrorMessage="Receipt date cannot be blank")]
        public Nullable<DateTime> receiptdate { get; set; }
       
       [Display (Name="Lot No.")]
       [Required (ErrorMessage="Lot number is required")]
       public string lotnumber { get; set; }
       
       [Display (Name="Garden")]
       [Required(ErrorMessage="Garden is required")]
       public int gardenid { get; set; }
       public IEnumerable<GardenListVM> gardenList { get; set; }

       [Display (Name="Carrier")]
       public string carrier { get; set; }
       [Display (Name="Lorry No.")]
       public string lorrynum { get; set; }
       
       [Display (Name="Broker")]
       [Required (ErrorMessage="Broker is required")]
       public int brokerid { get; set; }
       public IEnumerable<BrokersVM> brokerList { get; set; }
       
       [Display (Name="Warehouse")]
       [Required(ErrorMessage="Warehouse is required")]
       public int warehouseid { get; set; }
       public IEnumerable<WarehousesVM> warehouselist { get; set; }

       [Display (Name="Cnn No")]
       public string cnno { get; set; }
       
       [Display (Name="Cnn Date")]
       public Nullable<DateTime> cndate { get; set; }
       
       [Display (Name="Gp No.")]
       public string gpno { get; set; }
       
       [Display (Name="Wb No.")]
       public string wbno { get; set; }

       public int companyId { get; set; }
       public int yearId { get; set; }
    }
}
