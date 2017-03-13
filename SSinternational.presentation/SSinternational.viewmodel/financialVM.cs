using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SSinternational.viewmodel
{
    public class financialVM
    {
        public int fiscalid { get; set; }
        public DateTime fiscalstartdate { get; set; }
        public DateTime fiscalenddate { get; set; }
        public string fiscalyear { get; set; }
    }
}
