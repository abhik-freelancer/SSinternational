using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.viewmodel
{
    public class ratemasterVM
    {
        public decimal rate_id { get; set; }
        public decimal slab_rate1 { get; set; }
        public decimal slab_rate2 { get; set; }
        public decimal slab_rate3 { get; set; }
        public decimal slab_rate4 { get; set; }
        public decimal StrRemRate { get; set; }
        public decimal ChkWghRate { get; set; }
        public decimal SamplingRate { get; set; }
        public decimal AdditionalRate { get; set; }
        public int yearId { get; set; }
        public int companyId { get; set; }
    }
}
