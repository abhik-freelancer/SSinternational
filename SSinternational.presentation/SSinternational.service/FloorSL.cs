using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SSinternational.viewmodel;
using SSinternational.dataaccess.POCO;


namespace SSinternational.service
{
    public class FloorSL
    {
        public IEnumerable<FloorVM> getFloorList() {
            floors _floorPOCO = new floors();
            IEnumerable<FloorVM> _VM = Mapper.Map<IEnumerable<floors>, IEnumerable<FloorVM>>(_floorPOCO.getFloorList());
            return _VM;
        
        }
    }
}
