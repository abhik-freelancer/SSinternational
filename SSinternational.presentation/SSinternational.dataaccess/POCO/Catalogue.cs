using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SSinternational.dataaccess.POCO
{
   public class Catalogue
    {
        public int catalogId { get; set; }
        public string catalognumber { get; set; }
        public DateTime? catalougedate { get; set; }
        public int arrivalInvoiceId { get; set; }
        public string saleNumber { get; set; }
        public string lotNumber { get; set; }

        
        public int brokerId { get; set; }
        

        public int bagSerial { get; set; }
       
        public decimal sampleqty { get; set; }

        public int gardenId { get; set; }

        public int companyId { get; set; }
        public int yearId { get; set; }

        public string invoices { get; set; }
        public string grade { get; set; }
        public decimal net { get; set; }
        public string arrivalNumber { get; set; }
        public decimal receiveQty { get; set; }
        public string arrivalDate { get; set; }

       /**********************/
        public string yearofproduction { get; set; }
        public int pkgsrlfrm { get; set; }
        public int pkgsrlto { get; set; }


        public IEnumerable<Catalogue> getArrivalListByGardenId(int gardenId) {
            catalogueDAL _catlgDAL = new catalogueDAL();
            DataTable dt = _catlgDAL.getArrivalListByGardenId(gardenId);
            List<Catalogue> _lstCatg = new List<Catalogue>();
            if(dt.Rows.Count>0){

                foreach (DataRow row in dt.Rows) {
                    Catalogue _obj = new Catalogue();
                    _obj.arrivalInvoiceId = Convert.ToInt32(row["id"].ToString());
                    _obj.invoices = row["invoice"].ToString();
                    _obj.arrivalDate = row["dateofarrival"].ToString();
                    _obj.grade = row["grade"].ToString();
                    _obj.net = Convert.ToDecimal(row["net"].ToString());
                    _obj.arrivalNumber = row["arrivalNumber"].ToString();
                    _obj.receiveQty = Convert.ToDecimal(row["receivequantity"].ToString());
                    _lstCatg.Add(_obj);
                
                }
            
            }

            return _lstCatg;
        }

        public int[] getChestSerialRangeByArrivalDtlId(int arrivalInvoiceId) {
            catalogueDAL _ctglDAL = new catalogueDAL();
            DataTable dt = _ctglDAL.getChestSerialRangeByArrivalDtlId(arrivalInvoiceId);
            int[] chstArray = new int[2];
            if(dt.Rows.Count>0){
                DataRow rows = dt.Rows[0]; 
                //rows = dt.Rows[0];
                chstArray[0] = Convert.ToInt32(rows["pkgsrlfrm"].ToString());
                chstArray[1] = Convert.ToInt32(rows["pkgsrlto"].ToString());
            }

            return chstArray;
        
        }
       /// <summary>
       /// Catalogue insertion
       /// </summary>
       /// <param name="_catalogue"></param>
       /// <returns>int</returns>

        public int catalogueInsert(Catalogue _catalogue) {
            catalogueDAL _DAL = new catalogueDAL();
            return _DAL.catalogueInsert(_catalogue);
        }

        public void update(Catalogue _catalogue) {

            catalogueDAL _DAL = new catalogueDAL();
            _DAL.update(_catalogue);
        }

       /// <summary>
        /// getArrivalInvoiceDetail for showing in catalogue entry.
       /// </summary>
       /// <param name="invoiceId"></param>
       /// <returns></returns>
        public Catalogue getArrivalInvoiceDetail(int invoiceId) {
            catalogueDAL _DAL = new catalogueDAL();
            DataTable dt = _DAL.getArrivalInvoiceDetail(invoiceId);
            Catalogue _objCatlg = new Catalogue();
            if (dt.Rows.Count > 0) {

                DataRow rows = dt.Rows[0];
                    _objCatlg.invoices = rows["invoice"].ToString();
                    _objCatlg.arrivalNumber = rows["arrivalNumber"].ToString();
                    _objCatlg.grade = rows["grade"].ToString();
                    _objCatlg.yearofproduction = rows["yearofproduction"].ToString();
                    _objCatlg.pkgsrlfrm =Convert.ToInt32(rows["pkgsrlfrm"].ToString());
                    _objCatlg.pkgsrlto = Convert.ToInt32(rows["pkgsrlto"].ToString());
                    _objCatlg.arrivalDate = rows["dateofarrival"].ToString();
                    _objCatlg.receiveQty =Convert.ToDecimal(rows["receivequantity"].ToString());
                    _objCatlg.net = Convert.ToDecimal(rows["net"].ToString());
            }
            return _objCatlg;
        }

        public IEnumerable<Catalogue> getcatalogListByInvoiceId(int invoiceDetailsId) {
            catalogueDAL _DAL = new catalogueDAL();
            DataTable dt = _DAL.getcatalogListByInvoiceId(invoiceDetailsId);
            List<Catalogue> _lstCatalogue = new List<Catalogue>();

            if (dt.Rows.Count > 0) {

                foreach (DataRow rows in dt.Rows) {
                    Catalogue _objCtlg = new Catalogue();
                    _objCtlg.catalognumber = rows["catalognumber"].ToString();
                    _objCtlg.catalougedate = Convert.ToDateTime(rows["catalougedate"].ToString());
                    _objCtlg.catalogId = Convert.ToInt32(rows["catalogId"].ToString());
                    _objCtlg.arrivalInvoiceId = Convert.ToInt32(rows["arrivalInvoiceId"].ToString());
                    _objCtlg.bagSerial =Convert.ToInt32(rows["bagSerial"].ToString());
                    _objCtlg.saleNumber = (rows["saleNumber"].ToString());
                    _objCtlg.lotNumber = rows["lotNumber"].ToString();
                    _lstCatalogue.Add(_objCtlg);
                
                }
            
            }
            return _lstCatalogue;
        
        }


        public Catalogue getCatalogueById(int ctlgId) {
            catalogueDAL _DAL = new catalogueDAL();
            DataTable dt = _DAL.getCatalogueById(ctlgId);
            Catalogue _objCtlg = new Catalogue();
            if (dt.Rows.Count > 0) {

                DataRow rows = dt.Rows[0];
                _objCtlg.catalognumber = rows["catalognumber"].ToString();
                _objCtlg.catalougedate = Convert.ToDateTime(rows["catalougedate"].ToString());
                _objCtlg.catalogId = Convert.ToInt32(rows["catalogId"].ToString());
                _objCtlg.brokerId = Convert.ToInt32(rows["brokerId"].ToString());
                _objCtlg.arrivalInvoiceId = Convert.ToInt32(rows["arrivalInvoiceId"].ToString());
                _objCtlg.bagSerial = Convert.ToInt32(rows["bagSerial"].ToString());
                _objCtlg.saleNumber = (rows["saleNumber"].ToString());
                _objCtlg.lotNumber = rows["lotNumber"].ToString();

            
            }
            return _objCtlg;
        
        }



    }
}
