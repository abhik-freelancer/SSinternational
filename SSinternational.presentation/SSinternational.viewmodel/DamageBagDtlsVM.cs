using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.viewmodel
{
   public class DamageBagDtlsVM
    {
        public int id { get; set; }
        public int damageTypeId { get; set; }
        public string damageType { get; set; }
        public decimal noofpackage { get; set; }
        public decimal net { get; set; }
        public int unloadingDtlId { get; set; }
        public int serial { get; set; }
    }
}
