using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SSinternational.dataaccess.POCO
{
    public class floors
    {
        public int floorId{get;set;}
        public string floorName{get;set;}
        public int warehouseId{get;set;}

        public IEnumerable<floors> getFloorList() {
            floorsDAL _floorDAL = new floorsDAL();
            DataTable dt = _floorDAL.getFloorList();
            List<floors> _lstfloor = new List<floors>();
            if (dt.Rows.Count > 0) { 
                foreach(DataRow rows in dt.Rows){
                     floors _floor = new floors();
                    _floor.floorId = Convert.ToInt32(rows["floorId"].ToString());
                    _floor.floorName = rows["floorName"].ToString();
                    _floor.warehouseId = Convert.ToInt32(rows["warehouseId"].ToString());
                    _lstfloor.Add(_floor);
                }
            
            }
            return _lstfloor;
        }
    }
}
