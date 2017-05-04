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
        public decimal shortPkgNet { get; set; }
        public int unloadingDetailId { get; set; }
        public int serial { get; set; }



        public IEnumerable<ShortBagDtls> GetShoertBagDtlById(int unloadingDtlId) {
            UnloadingDAL _unloadDAL = new UnloadingDAL();
            DataTable dt = _unloadDAL.GetShoertBagDtlById(unloadingDtlId);
            List<ShortBagDtls> _lstShortBagDtl = new List<ShortBagDtls>();

            if(dt.Rows.Count>0){
                foreach (DataRow rows in dt.Rows) {
                    ShortBagDtls _objShrt = new ShortBagDtls();
                    _objShrt.id = Convert.ToInt32(rows["id"].ToString());
                    _objShrt.shortTypeId = Convert.ToInt32(rows["shortTypeId"].ToString());
                    _objShrt.ShortName = rows["ShortCode"].ToString();
                    _objShrt.shortPkgNet = Convert.ToDecimal(rows["shortPkgNet"].ToString());
                    _objShrt.serial = Convert.ToInt32(rows["serial"].ToString());

                    _lstShortBagDtl.Add(_objShrt);
                }
            
            }

            return _lstShortBagDtl;
        }
    }
}
