using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SSinternational.dataaccess.POCO
{
    public class ShortBagDtls
    {
        public int id { get; set; }
        public int shortTypeId { get; set; }
        public string ShortName { get; set; }
        public decimal shortpackage { get; set; }
        public decimal shortPkgNet{get;set;}
        public int unloadingDetailId { get; set; }


    }
}
