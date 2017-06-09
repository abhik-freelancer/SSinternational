using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SSinternational.viewmodel
{
    public class BillVM
    {
        [Key]
        public int billId { get; set; }
        
        [Display (Name="Bill")]
        public string billnumber { get; set; }

        [Display(Name = "Delivery Date")]
        [Required]
        public DateTime deliverydate { get; set; }

        [Display(Name = "Buyer")]
        public string buyer { get; set; }

        [Display(Name = "Sarkar")]
        public string sarkar { get; set; }

        [Display(Name = "DO. No.")]
        [Required]
        public string doNumber { get; set; }
        [Display(Name = "DO Date")]
        public DateTime doDate { get; set; }
        
        public decimal grandtotalamount { get; set; }
        public int companyId { get; set; }
        public int yearId { get; set; }

        [Display (Name="Gardens")]
        public int gardenId { get; set; }
        public IEnumerable<GardenListVM> gardenList { get; set; }

        //[Display (Name="Bags")]
        //public int numberofbags { get; set; }

        [Display(Name="Sale No.")]
        public string saleno { get; set; }

        [Display(Name="Lot No.")]
        public string lotnumber { get; set; }

        [Display(Name="DO.Ldg Date")]
        public Nullable<DateTime> doLodgDate { get; set; }

        [Display(Name="Prompt Date")]
        public Nullable<DateTime> promptdate { get; set; }

        [Display(Name="Extd. Date")]
        public Nullable<DateTime> extdDate { get; set; }

        [Display(Name = "Week Due")]
        public decimal? weeksdue { get; set; }

        //public decimal additionalRent { get; set; }
        //public decimal streetRemovalRent { get; set; }
        //public decimal checkWeighmentRent { get; set; }
        //public decimal samplingRate { get; set; }

        //public decimal slab_rate1 { get; set; }
        //public decimal slab_rate2 { get; set; }
        //public decimal slab_rate3 { get; set; }
        //public decimal slab_rate4 { get; set; }

        public ratemasterVM rateslab { get; set; }
        public IEnumerable<BillDetailsVM> BillDetails { get; set; }


    }
}
