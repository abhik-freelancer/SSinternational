using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SSinternational.dataaccess.POCO
{
   public class ArrivalMaster
    {
       public int arrivalId { get; set; }
       public int unloadingId { get; set; }
       public string arrivalNumber { get; set; }
       public DateTime dateofarrival { get; set; }
       public string lotnumber { get; set; }
       public int gardenid { get; set; }
       public string carrier { get; set; }
       public string lorrynum { get; set; }
       public int brokerid { get; set; }
       public int warehouseid { get; set; }
       public string cnno { get; set; }
       public Nullable<DateTime> cndate { get; set; }
       public string gpno { get; set; }
       public string wbno { get; set; }
       public int companyid { get; set; }
       public int yearid { get; set; }



       /*********************************************/
       public string BrokerName { get; set; }
       public string unloadingnumber { get; set; }
       public string unloadingDate { get; set; }
       public int numberofinvoices { get; set; }

       /// <summary>
       /// getArrivalMasterList
       /// </summary>
       /// <param name="companyId"></param>
       /// <param name="yearId"></param>
       /// <returns></returns>
       public IEnumerable<ArrivalMaster> getArrivalMasterList(int companyId, int yearId) {

           ArrivalDAL _arrivalMasterDAL = new ArrivalDAL();
           DataTable dt = _arrivalMasterDAL.getArrivalMasterList(companyId, yearId);
           List<ArrivalMaster> _lstarrv = new List<ArrivalMaster>();
           if (dt.Rows.Count > 0) { 
           
                foreach(DataRow rows in dt.Rows){
                    ArrivalMaster _objArrv = new ArrivalMaster();
                    _objArrv.arrivalId = Convert.ToInt32(rows["arrivalId"].ToString());
                    if (DBNull.Value != rows["unloadingId"])
                    {
                        _objArrv.unloadingId = Convert.ToInt32(rows["unloadingId"].ToString());
                    }
                    else {
                        _objArrv.unloadingId = 0;
                    }
                    _objArrv.arrivalNumber = rows["arrivalNumber"].ToString();
                    _objArrv.dateofarrival = Convert.ToDateTime(rows["dateofarrival"].ToString());
                    _objArrv.lotnumber = rows["lotnumber"].ToString();
                    _objArrv.gardenid =Convert.ToInt32(rows["gardenid"].ToString());
                    _objArrv.carrier = rows["carrier"].ToString();
                    _objArrv.lorrynum = rows["lorrynum"].ToString();
                    _objArrv.brokerid = Convert.ToInt32(rows["brokerid"].ToString());
                    _objArrv.warehouseid = Convert.ToInt32(rows["warehouseid"].ToString());
                    _objArrv.cnno = rows["cnno"].ToString();
                    if (DBNull.Value != rows["cndate"])
                    {
                        _objArrv.cndate = Convert.ToDateTime(rows["cndate"].ToString());
                    }
                    else {
                        _objArrv.cndate =null ;
                    }
                    _objArrv.gpno = rows["gpno"].ToString();
                    _objArrv.wbno = rows["wbno"].ToString();
                    _objArrv.BrokerName = rows["BrokerName"].ToString();
                    _objArrv.unloadingnumber = rows["unloadingnumber"].ToString();
                    _objArrv.numberofinvoices = Convert.ToInt32(rows["cnt"].ToString());
                    _lstarrv.Add(_objArrv);
                
                }
           }

           return _lstarrv;
       }

       /// <summary>
       /// Insertion of arrival master
       /// </summary>
       /// <param name="_arrivalMaster"></param>
       /// <returns>int</returns>
       public int arrivalMasterInsertion(ArrivalMaster _arrivalMaster) {
           ArrivalDAL _arrivalMasterDAL = new ArrivalDAL();
           return _arrivalMasterDAL.arrivalMasterInsertion(_arrivalMaster);

       }
       /// <summary>
       /// arrivalMasterUpdate
       /// </summary>
       /// <param name="_arrivalMaster"></param>
       /// <returns>int</returns>

       public int arrivalMasterUpdate(ArrivalMaster _arrivalMaster) {
           ArrivalDAL _arrivalMasterDAL = new ArrivalDAL();
           return _arrivalMasterDAL.arrivalMasterUpdate(_arrivalMaster);
       }

       /// <summary>
       /// Get arrival master by Id for edit data fetch
       /// </summary>
       /// <param name="arrivalmasterid"></param>
       /// <returns></returns>
       public ArrivalMaster getArrivalMasterById(int arrivalmasterid) {
           ArrivalDAL _arrivalMasterDAL = new ArrivalDAL();
           DataTable dt = _arrivalMasterDAL.getArrivalMasterById(arrivalmasterid);
           ArrivalMaster _objArrv = new ArrivalMaster();

           if(dt.Rows.Count>0){
               DataRow rows = dt.Rows[0];
               _objArrv.arrivalId = Convert.ToInt32(rows["arrivalId"].ToString());
               if (DBNull.Value != rows["unloadingId"])
               {
                   _objArrv.unloadingId = Convert.ToInt32(rows["unloadingId"].ToString());
               }
               else
               {
                   _objArrv.unloadingId = 0;
               }
               _objArrv.arrivalNumber = rows["arrivalNumber"].ToString();
               _objArrv.dateofarrival = Convert.ToDateTime(rows["dateofarrival"].ToString());
               _objArrv.lotnumber = rows["lotnumber"].ToString();
               _objArrv.gardenid = Convert.ToInt32(rows["gardenid"].ToString());
               _objArrv.carrier = rows["carrier"].ToString();
               _objArrv.lorrynum = rows["lorrynum"].ToString();
               _objArrv.brokerid = Convert.ToInt32(rows["brokerid"].ToString());
               _objArrv.warehouseid = Convert.ToInt32(rows["warehouseid"].ToString());
               _objArrv.cnno = rows["cnno"].ToString();
               if (DBNull.Value != rows["cndate"])
               {
                   _objArrv.cndate = Convert.ToDateTime(rows["cndate"].ToString());
               }
               else
               {
                   _objArrv.cndate = null;
               }
               _objArrv.gpno = rows["gpno"].ToString();
               _objArrv.wbno = rows["wbno"].ToString();
               _objArrv.unloadingnumber = rows["unloadingnumber"].ToString();
               _objArrv.unloadingDate = rows["receiptdate"].ToString();
           }

           return _objArrv;
       }


       public IEnumerable<ArrivalMaster> getArrivalList(DateTime from, DateTime to, int companyId, int gardenid, int brokerid) {
           ArrivalDAL _arrivalDAL = new ArrivalDAL();
           DataTable dt = _arrivalDAL.getArrivalList(from, to, companyId, gardenid, brokerid);
           List<ArrivalMaster> _lstArrival = new List<ArrivalMaster>();

           if (dt.Rows.Count > 0) { 
            
               foreach(DataRow rows in dt.Rows){
                   ArrivalMaster _objArrival = new ArrivalMaster();
                   _objArrival.arrivalId = Convert.ToInt32(rows["arrivalId"].ToString());
                   _objArrival.arrivalNumber = (rows["arrivalNumber"].ToString());
                   _objArrival.dateofarrival = Convert.ToDateTime(rows["dateofarrival"].ToString());
                   _lstArrival.Add(_objArrival);
               }
           
           
           }
           return _lstArrival;
       
       }

       /*******************************************/
    }
}
