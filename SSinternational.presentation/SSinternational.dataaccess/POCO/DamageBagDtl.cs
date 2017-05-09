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
        public int serial { get; set; }


        public IEnumerable<DamageBagDtl> GetDamageBagDetailById(int unloadingDtlId) {
            UnloadingDAL _unldDAL = new UnloadingDAL();
            DataTable dt = _unldDAL.GetDamageBagDetailById(unloadingDtlId);

            List<DamageBagDtl> _lst = new List<DamageBagDtl>();

            if (dt.Rows.Count > 0) {

                foreach (DataRow rows in dt.Rows) {
                    DamageBagDtl _obj = new DamageBagDtl();
                    _obj.id = Convert.ToInt32(rows["id"].ToString());
                    _obj.damageTypeId = Convert.ToInt32(rows["damageTypeId"].ToString());
                    _obj.damageType = rows["DamageCode"].ToString();
                    _obj.net = Convert.ToDecimal(rows["net"].ToString());
                    _obj.serial = Convert.ToInt32(rows["serial"].ToString());
                    _lst.Add(_obj);
                }
            
            
            }
            return _lst;
        
        }

        public IEnumerable<DamageBagDtl> GetArrivedDamageBagDetailById(int arrivalDtlId)
        {
            ArrivalDAL _arrivalDAL = new ArrivalDAL();
            DataTable dt = _arrivalDAL.GetDamageBagDetailById(arrivalDtlId);

            List<DamageBagDtl> _lst = new List<DamageBagDtl>();

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow rows in dt.Rows)
                {
                    DamageBagDtl _obj = new DamageBagDtl();
                    _obj.id = Convert.ToInt32(rows["id"].ToString());
                    _obj.damageTypeId = Convert.ToInt32(rows["damageTypeId"].ToString());
                    _obj.damageType = rows["DamageCode"].ToString();
                    _obj.net = Convert.ToDecimal(rows["net"].ToString());
                    _obj.serial = Convert.ToInt32(rows["serial"].ToString());
                    _lst.Add(_obj);
                }


            }
            return _lst;

        }



    }
}
