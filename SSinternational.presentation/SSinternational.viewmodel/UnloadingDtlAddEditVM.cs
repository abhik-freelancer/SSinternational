using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SSinternational.viewmodel
{
   public class UnloadingDtlAddEditVM
   {
       [Key]
       public int unloadingDetailId { get; set; }
       
       
       public int unloadingmasterid { get; set; }
       [Display(Name="Invoice")]
       public string invoice { get; set; }
       
       [Display(Name="Grade")]
       public string grade { get; set; }
       
       [Display(Name="Packages")]
       public decimal package { get; set; }
       
       [Display(Name="Cropping Year")]
       public string yearofproduction { get; set; }
       
       [Display(Name="From")]
       public int pkgsrlfrm { get; set; }
       [Display(Name = "To")]
       public int pkgsrlto { get; set; }
       [Display(Name = "Inv. Qty.")]
       public decimal invoicequantity { get; set; }

       [Display(Name = "Recv.Qty.")]
       public decimal receivequantity { get; set; }

       [Display(Name = "Gross")]
       public decimal gross { get; set; }
       [Display(Name = "Tare")]
       public decimal tare { get; set; }
       [Display(Name = "Net")]
       public decimal net { get; set; }

       [Display(Name = "Floor")]
       public int floorId { get; set; }
       public IEnumerable<FloorVM> floorList { get; set; }

       public string floorName { get; set; }
       public string unloadingnumber { get; set; }
       public DateTime receiptdate { get; set; }

       public IEnumerable<ShortBagDtlsVM> shortBagDtls { get; set; }
       public IEnumerable<DamageBagDtlsVM> damageBagDtls { get; set; }

       public IEnumerable<DamagetypesVM> damageSelectList { get; set; }
       public IEnumerable<ShorttypesVM> shorttypeSelectList { get; set; }


    }
}
