using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.viewmodel
{
    public class BrokersVM
    {
        [Key]
        public int BrokerId { get; set; }
        
        [Display(Name = "Code")]
        public string BrokerCode { get; set; }

        [Required(ErrorMessage = "Broker name is required")]
        [Display(Name = "Name")]
        public string BrokerName { get; set; }

        public string EstateName { get; set; }

        [Display(Name = "Estate")]
        public int EstateId { get; set; }
        public IEnumerable<EsatetVM> estateList { get; set; }


    }
}
