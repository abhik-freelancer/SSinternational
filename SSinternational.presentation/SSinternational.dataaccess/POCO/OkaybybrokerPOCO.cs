using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SSinternational.dataaccess.POCO
{
    public class OkaybybrokerPOCO
    {
        public int arrivalDetailId { get; set; }
        public string garden { get; set; }
        public string yearofproduction { get; set; }
        public string grade { get; set; }
        public decimal net { get; set; }
        public int brokerId { get; set; }
        public string invoices { get; set; }
        public string arrivalNumber { get; set; }
        public int arrivalId { get; set; }

        public IEnumerable<DamageBagDtl> damageBagDetails { get; set; }



        public OkaybybrokerPOCO OkaybybrokerMasterData(int arrivalDetailId) {
            OkaybybrokerDAL _DAL = new OkaybybrokerDAL();
            DataTable dt = _DAL.OkaybybrokerMasterData(arrivalDetailId);
            OkaybybrokerPOCO _objOkbrk = new OkaybybrokerPOCO();

            if (dt.Rows.Count > 0) {
                DataRow rows = dt.Rows[0];

                _objOkbrk.garden = rows["gardenname"].ToString();
                _objOkbrk.yearofproduction = rows["yearofproduction"].ToString();
                _objOkbrk.grade = rows["grade"].ToString();
                _objOkbrk.net =Convert.ToDecimal(rows["net"].ToString());
                _objOkbrk.brokerId = Convert.ToInt32(rows["brokerid"].ToString());
                _objOkbrk.invoices = rows["invoice"].ToString();
                _objOkbrk.arrivalDetailId = Convert.ToInt32(rows["id"].ToString());
                _objOkbrk.arrivalNumber = rows["arrivalNumber"].ToString();
                _objOkbrk.arrivalId = Convert.ToInt32(rows["arrivalId"].ToString());

            }
            return _objOkbrk;
        
        }

        public int UpdateOkayByBroker(OkaybybrokerPOCO _inspectionResult) {
            OkaybybrokerDAL _DAL = new OkaybybrokerDAL();
            return _DAL.UpdateOkayByBroker(_inspectionResult);
        
        }

    }
}
