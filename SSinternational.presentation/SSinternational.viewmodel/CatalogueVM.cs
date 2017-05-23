using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SSinternational.viewmodel
{
    public class CatalogueVM
    {
        [Key]
        public int catalogId { get; set; }
        public string catalognumber { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public DateTime? catalougedate { get; set; }
        public int arrivalInvoiceId { get; set; }
        [Required(ErrorMessage="Sale no is required")]
        public string saleNumber { get; set; }
        [Required(ErrorMessage="Lot no is required")]
        public string lotNumber { get; set; }
        
        [Display(Name="Broker")]
        [Required(ErrorMessage="Broker is required")]
        public int brokerId { get; set; }
        public IEnumerable<BrokersVM> brokerList { get; set; }

        [Required(ErrorMessage="Serial is required")]
        public int bagSerial { get; set; }
        
        public decimal sampleqty { get; set; }

        public int gardenId { get; set; }
        public IEnumerable<GardenListVM> gardenList { get; set; }

        public int companyId { get; set; }
        public int yearId { get; set; }

        public string invoices { get; set; }
        public string grade { get; set; }
        public decimal net { get; set; }
        public string arrivalNumber { get; set; }
        public decimal receiveQty{get;set;}
        public string arrivalDate { get; set; }

        /**********************/
        public string yearofproduction { get; set; }
        public int pkgsrlfrm { get; set; }
        public int pkgsrlto { get; set; }



    }
}
