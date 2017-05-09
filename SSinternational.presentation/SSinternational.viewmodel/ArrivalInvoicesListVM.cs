using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SSinternational.viewmodel
{
    public class ArrivalInvoicesListVM
    {
        public int arrivalDetailid { get; set; }
        public int arrivalId { get; set; }

        public string invoice { get; set; }
        public string grade { get; set; }
        public decimal package { get; set; }
        public string yearofproduction { get; set; }
        public int pkgsrlfrm { get; set; }
        public int pkgsrlto { get; set; }
        public decimal invoicequantity { get; set; }
        public decimal receivequantity { get; set; }
        public decimal gross { get; set; }
        public decimal tare { get; set; }
        public decimal net { get; set; }
        public int floorId { get; set; }
        public string floorName { get; set; }


        public string arrivalNumber { get; set; }
        public string warehousename { get; set; }
        public DateTime dateofarrival { get; set; }
    }
}
