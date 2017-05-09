using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SSinternational.viewmodel
{
    public class ArrivalDtlAddEditVM
    {
        [Key]
        public int arrivalDetailid { get; set; }
        
        public int arrivalId { get; set; }

        [Display(Name = "Invoice")]
        [Required(ErrorMessage = "Invoice is rquired")]
        public string invoice { get; set; }

        [Display(Name = "Grade")]
        public string grade { get; set; }

        [Display(Name = "Packages")]
        public decimal package { get; set; }

        [Display(Name = "Cropping Year")]
        public string yearofproduction { get; set; }

        [Display(Name = "From")]
        [Required(ErrorMessage = "From serial is required")]
        public int pkgsrlfrm { get; set; }

        [Display(Name = "To")]
        [Required(ErrorMessage = "To serial is required")]
        public int pkgsrlto { get; set; }


        [Display(Name = "Inv. Qty.")]
        [Required(ErrorMessage = "Invoice qty is required")]
        public decimal invoicequantity { get; set; }

        [Display(Name = "Recv.Qty.")]
        [Required(ErrorMessage = "Received is required")]
        public decimal receivequantity { get; set; }

        [Display(Name = "Gross")]
        [Required(ErrorMessage = "Gross is required")]
        public decimal gross { get; set; }

        [Display(Name = "Tare")]
        public decimal tare { get; set; }

        [Display(Name = "Net")]
        [Required(ErrorMessage = "Net is required")]
        public decimal net { get; set; }
        
        [Display(Name = "Floor")]
        [Required (ErrorMessage="Floor is required")]
        public int floorId { get; set; }
        public IEnumerable<FloorVM> floorList { get; set; }
        
        public string floorName { get; set; }
        public string arrivalNumber { get; set; }
        public string warehousename { get; set; }
        public DateTime dateofarrival { get; set; }


        public IEnumerable<DamagetypesVM> damageSelectList { get; set; }
        public IEnumerable<ShorttypesVM> shorttypeSelectList { get; set; }

        public IEnumerable<ShortBagDtlsVM> shortBagDtls { get; set; }
        public IEnumerable<DamageBagDtlsVM> damageBagDtls { get; set; }



        /*******************************/
        public int invoiceformatId { get; set; }
        public string gardenCode { get; set; }


    }
}
