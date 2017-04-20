using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SSinternational.dataaccess.POCO
{
    public class UnloadingmasterPOCO
    {
        public int id { get; set; }
        public string unloadingnumber { get; set; }
        public DateTime receiptdate { get; set; }
        public string lotnumber { get; set; }
        public int gardenid { get; set; }
        public string carrier { get; set; }
        public string lorrynum { get; set; }
        public int brokerid { get; set; }
        public int warehouseid { get; set; }
        public string cnno { get; set; }
        public DateTime cndate { get; set; }
        public string gpno { get; set; }
        public string wbno { get; set; }
        public int companyId { get; set; }
        public int yearId { get; set; }

        public IEnumerable<UnloadingmasterPOCO> getUnloadingMasterList(int companyId, int yearId) {

            UnloadingDAL _unloadingDAL = new UnloadingDAL();
            DataTable dt = _unloadingDAL.getUnloadingMasterList(companyId, yearId);
            List<UnloadingmasterPOCO> _lstUnloadingMaster = new List<UnloadingmasterPOCO>();

            if(dt.Rows.Count>0){
                foreach (DataRow rows in dt.Rows) {
                    UnloadingmasterPOCO _unldmst = new UnloadingmasterPOCO();
                    _unldmst.id = Convert.ToInt32(rows["id"].ToString());
                    _unldmst.unloadingnumber = rows["unloadingnumber"].ToString();
                    _unldmst.receiptdate =Convert.ToDateTime(rows["receiptdate"].ToString());
                    _unldmst.lotnumber = rows["lotnumber"].ToString();
                    _unldmst.gardenid = Convert.ToInt32(rows["gardenid"].ToString());
                    _unldmst.carrier = rows["carrier"].ToString();
                    _unldmst.lorrynum = rows["lorrynum"].ToString();
                    _unldmst.brokerid = Convert.ToInt32(rows["brokerid"].ToString());
                    _unldmst.warehouseid = Convert.ToInt32(rows["warehouseid"].ToString());
                    _unldmst.cnno = rows["cnno"].ToString();
                    _unldmst.cndate = Convert.ToDateTime(rows["cndate"].ToString());
                    _unldmst.gpno = rows["gpno"].ToString();
                    _unldmst.wbno = rows["wbno"].ToString();
                    _lstUnloadingMaster.Add(_unldmst);

                }
            }
            return _lstUnloadingMaster;
        }

        public int insertUnloadingMaster(UnloadingmasterPOCO unloadingMaster) {

            UnloadingDAL _unloadingDAL = new UnloadingDAL();
            return _unloadingDAL.insertUnloadingMaster(unloadingMaster);
        }

        public int updateUnloadingMaster(UnloadingmasterPOCO unloadingMaster) {
            UnloadingDAL _unloadingDAL = new UnloadingDAL();
            return _unloadingDAL.updateUnloadingMaster(unloadingMaster);
        }

        public UnloadingmasterPOCO getUnloadingmasterById(int unloadMasterId) {
            UnloadingDAL _unloadingDAL = new UnloadingDAL();
            DataTable dt = _unloadingDAL.getUnloadingmasterById(unloadMasterId);
            UnloadingmasterPOCO _unldmst = new UnloadingmasterPOCO();
            if (dt.Rows.Count > 0) {
                DataRow rows = dt.Rows[0];
                _unldmst.id = Convert.ToInt32(rows["id"].ToString());
                _unldmst.unloadingnumber = rows["unloadingnumber"].ToString();
                _unldmst.receiptdate = Convert.ToDateTime(rows["receiptdate"].ToString());
                _unldmst.lotnumber = rows["lotnumber"].ToString();
                _unldmst.gardenid = Convert.ToInt32(rows["gardenid"].ToString());
                _unldmst.carrier = rows["carrier"].ToString();
                _unldmst.lorrynum = rows["lorrynum"].ToString();
                _unldmst.brokerid = Convert.ToInt32(rows["brokerid"].ToString());
                _unldmst.warehouseid = Convert.ToInt32(rows["warehouseid"].ToString());
                _unldmst.cnno = rows["cnno"].ToString();
                _unldmst.cndate = Convert.ToDateTime(rows["cndate"].ToString());
                _unldmst.gpno = rows["gpno"].ToString();
                _unldmst.wbno = rows["wbno"].ToString();
            
            }
            return _unldmst;
        
        }
    
    
    
    /*********************************************************************/
    }

}
