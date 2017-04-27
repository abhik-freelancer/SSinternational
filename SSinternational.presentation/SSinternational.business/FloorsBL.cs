using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSinternational.service;
using SSinternational.viewmodel;

namespace SSinternational.business
{
    public class FloorsBL
    {
        public IEnumerable<FloorVM> getFloorList() {
            FloorSL _SL = new FloorSL();
            return _SL.getFloorList();

        
        }
    }
}
