using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SSinternational.viewmodel
{
    public class ArrivalMasterVM
    {
        [Key]
        public int arrivalId { get; set; }
        
        [Display (Name="Unloading No")]
        public Nullable<int> unloadingId { get; set; }
        
        [Display (Name="Arrival No.")]
        [Required (ErrorMessage="Arrival number is required")]
        public string arrivalNumber { get; set; }

        
        
        [Display(Name="Arrival Date")]
        [Required(ErrorMessage="Date is required")]
        public DateTime dateofarrival { get; set; }
        
        [Display(Name="Lot no.")]
        [Required(ErrorMessage="Lot No. is required")]
        public string lotnumber { get; set; }
        
        [Display(Name="Garden")]
        [Required(ErrorMessage="Please select garden")]
        public int gardenid { get; set; }
        public IEnumerable<GardenListVM> gardenList { get; set; }

        [Display(Name="Carrier")]
        public string carrier { get; set; }
        
        [Display(Name="Lorry no.")]
        public string lorrynum { get; set; }
        
        [Display(Name="Broker")]
        [Required(ErrorMessage="Broker is required")]
        public int brokerid { get; set; }
        public IEnumerable<BrokersVM> brokerList { get; set; }
        
        [Display(Name="Warehouse")]
        [Required(ErrorMessage="Warehouse is required")]
        public int warehouseid { get; set; }
        public IEnumerable<WarehousesVM> warehouseList { get; set; }

        [Display(Name="CN No")]
        public string cnno { get; set; }

        [Display(Name="CN Date")]
        public Nullable<DateTime> cndate { get; set; }

        [Display(Name="GP no")]
        public string gpno { get; set; }

        [Display(Name = "WB no")]
        public string wbno { get; set; }
        
        public int companyid { get; set; }
        public int yearid { get; set; }



        /*********************************************/
        public string BrokerName { get; set; }
        public string unloadingnumber { get; set; }

        [Display(Name="Unloading Date")]
        public string unloadingDate { get; set; }
        
        public int numberofinvoices { get; set; }
    }
}
