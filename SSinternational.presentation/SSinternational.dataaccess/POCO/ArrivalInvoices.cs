using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SSinternational.dataaccess.POCO
{
    public class ArrivalInvoices
    {

        public int arrivalDetailid { get; set; }
        public int arrivalId { get; set; }

        public string invoice { get; set; }
        public string grade { get; set; }
        public decimal package { get; set; }
        public string yearofproduction { get; set; }
        public int pkgsrlfrm { get; set; }
        public int pkgsrlto { get; set; }
        public decimal invoicequantity { get; set; }
        public decimal receivequantity { get; set; }
        public decimal gross { get; set; }
        public decimal tare { get; set; }
        public decimal net { get; set; }
        public int floorId { get; set; }
        public string floorName { get; set; }


        public string arrivalNumber { get; set; }
        public string warehousename { get; set; }
        public DateTime dateofarrival { get; set; }


        public IEnumerable<ShortBagDtls> shortBagDtls { get; set; }
        public IEnumerable<DamageBagDtl> damageBagDtls { get; set; }
        /************************************/
        public int invoiceformatId { get; set; }
        public string gardenCode { get; set; }


        /// <summary>
        /// Get list of invoices against
        /// arrival master id
        /// </summary>
        /// <param name="arrivalId"></param>
        /// <returns>List<ArrivalInvoices></returns>
        public IEnumerable<ArrivalInvoices> getArrivalInvoicesList(int arrivalId)
        {

            ArrivalDAL _arrvlDAL = new ArrivalDAL();
            DataTable dt = _arrvlDAL.getArrivalInvoicesList(arrivalId);
            List<ArrivalInvoices> _lstOfArrvlInvoices = new List<ArrivalInvoices>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rows in dt.Rows)
                {
                    ArrivalInvoices _objArrival = new ArrivalInvoices();

                    _objArrival.arrivalDetailid = Convert.ToInt32(rows["id"].ToString());
                    _objArrival.arrivalId = Convert.ToInt32(rows["arrivalId"].ToString());
                    _objArrival.dateofarrival = Convert.ToDateTime(rows["dateofarrival"].ToString());
                    _objArrival.invoice = rows["invoice"].ToString();
                    _objArrival.grade = rows["grade"].ToString();
                    _objArrival.package = Convert.ToDecimal(rows["package"].ToString());
                    _objArrival.yearofproduction = rows["yearofproduction"].ToString();
                    _objArrival.pkgsrlfrm = Convert.ToInt32(rows["pkgsrlfrm"].ToString());
                    _objArrival.pkgsrlto = Convert.ToInt32(rows["pkgsrlfrm"].ToString());
                    _objArrival.invoicequantity = Convert.ToDecimal(rows["invoicequantity"].ToString());
                    _objArrival.receivequantity = Convert.ToDecimal(rows["receivequantity"].ToString());
                    _objArrival.gross = Convert.ToDecimal(rows["gross"].ToString());
                    _objArrival.tare = Convert.ToDecimal(rows["tare"].ToString());
                    _objArrival.net = Convert.ToDecimal(rows["net"].ToString());
                    if (DBNull.Value != rows["floorId"])
                    {
                        _objArrival.floorId = Convert.ToInt32(rows["floorId"].ToString());

                        _objArrival.floorName = (rows["floorName"].ToString());
                    }
                    else
                    {
                        _objArrival.floorId = 0;
                        _objArrival.floorName = null;
                    }
                    _objArrival.arrivalNumber = rows["arrivalNumber"].ToString();
                    _objArrival.warehousename = rows["Name"].ToString();

                    _lstOfArrvlInvoices.Add(_objArrival);

                }
            }
            return _lstOfArrvlInvoices;
        }



        public int getNumberofInvoices(int arrivalId)
        {
            ArrivalDAL _arrvlDAL = new ArrivalDAL();
            return _arrvlDAL.getNumberofInvoices(arrivalId);
        
        }

        public int checkInvoiceFormatId(int arrivalId) {
            ArrivalDAL _arrvlDAL = new ArrivalDAL();
            return _arrvlDAL.checkInvoiceFormatId(arrivalId);
        }

        public string getGardenCode(int arrivalId)
        {
            ArrivalDAL _arrvlDAL = new ArrivalDAL();
            return _arrvlDAL.getGardenCode(arrivalId);
        }


        public int arrivalInvoicesInsertion(ArrivalInvoices _arrivalInvoices)
        {
            ArrivalDAL _arrvlDAL = new ArrivalDAL();
            return _arrvlDAL.arrivalInvoicesInsertion(_arrivalInvoices);
        }


        public ArrivalInvoices GetArrivalDtlById(int arrivalMasterId, int arrivalDetailId){

            ArrivalDAL _arrvlDAL = new ArrivalDAL();
            DataTable dt = _arrvlDAL.GetArrivalDtlById(arrivalMasterId, arrivalDetailId);
            ArrivalInvoices _objArrivalInvoice = new ArrivalInvoices();
            if (dt.Rows.Count > 0)
            {

                DataRow rows = dt.Rows[0];
                _objArrivalInvoice.arrivalDetailid = Convert.ToInt32(rows["id"].ToString());
                _objArrivalInvoice.arrivalId = Convert.ToInt32(rows["arrivalId"].ToString());
                _objArrivalInvoice.invoice = rows["invoice"].ToString();
                _objArrivalInvoice.grade = rows["grade"].ToString();

                if (DBNull.Value != rows["package"])
                {
                    _objArrivalInvoice.package = Convert.ToDecimal(rows["package"].ToString());
                }
                else
                {
                    _objArrivalInvoice.package = 0;

                }

                _objArrivalInvoice.yearofproduction = rows["yearofproduction"].ToString();
                _objArrivalInvoice.pkgsrlfrm = Convert.ToInt32(rows["pkgsrlfrm"].ToString());
                _objArrivalInvoice.pkgsrlto = Convert.ToInt32(rows["pkgsrlto"].ToString());
                _objArrivalInvoice.invoicequantity = Convert.ToDecimal(rows["invoicequantity"].ToString());
                _objArrivalInvoice.receivequantity = Convert.ToDecimal(rows["receivequantity"].ToString());
                _objArrivalInvoice.gross = Convert.ToDecimal(rows["gross"].ToString());

                if (DBNull.Value != rows["tare"])
                {
                    _objArrivalInvoice.tare = Convert.ToDecimal(rows["tare"].ToString());
                }
                else
                {
                    _objArrivalInvoice.tare = 0;

                }

                _objArrivalInvoice.net = Convert.ToDecimal(rows["net"].ToString());
                if (DBNull.Value != rows["floorId"])
                {
                    _objArrivalInvoice.floorId = Convert.ToInt32(rows["floorId"].ToString());
                }
                else
                {

                    _objArrivalInvoice.floorId = 0;
                }

            }

            return _objArrivalInvoice;
         
        }

        public int UpadateunloadingInvoices(ArrivalInvoices _arrivalInvoices)
        {

            ArrivalDAL _arrvlDAL = new ArrivalDAL();
            return _arrvlDAL.UpadateunloadingInvoices(_arrivalInvoices);
        }


/****End of class*****/
    }

}
