using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SSinternational.dataaccess.POCO
{
   public class DamageBagDtl
    {
       public int id { get; set; }
       public int damageTypeId { get; set; }
       public string damageType { get; set; }
       public decimal noofpackage { get; set; }
       public decimal net { get; set; }
       public int unloadingDtlId { get; set; }


    }
}
