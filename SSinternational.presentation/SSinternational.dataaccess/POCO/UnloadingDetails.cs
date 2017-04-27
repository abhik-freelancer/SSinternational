using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SSinternational.dataaccess.POCO
{
    public class UnloadingDetails
    {
        public int unloadingDetailId { get; set; }
        public int unloadingmasterid { get; set; }
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
        public string unloadingnumber {get;set;}
        public DateTime receiptdate { get; set; }

        public IEnumerable<DamageBagDtl> unloadingDamageBagDtl { get; set; }
        public IEnumerable<ShortBagDtls> unloadingShortBagDtl { get; set; }


        public IEnumerable<UnloadingDetails> getListOfUnloadingInvoices(int unloadingmasterId) {

            UnloadingDAL _unldDtlDAL = new UnloadingDAL();
            DataTable dt = _unldDtlDAL.getListOfUnloadingInvoices(unloadingmasterId);
            List<UnloadingDetails> _lstUnloadingDtl = new List<UnloadingDetails>();

            if(dt.Rows.Count > 0){
                foreach(DataRow rows in dt.Rows){
                    UnloadingDetails _unldDtl = new UnloadingDetails();
                    _unldDtl.unloadingDetailId =Convert.ToInt32(rows["id"].ToString());
                    _unldDtl.unloadingmasterid = Convert.ToInt32(rows["unloadingmasterid"].ToString());
                    _unldDtl.invoice = rows["invoice"].ToString();
                    _unldDtl.grade = rows["grade"].ToString();
                    _unldDtl.package = Convert.ToDecimal(rows["package"].ToString());
                    _unldDtl.yearofproduction = rows["yearofproduction"].ToString();
                    _unldDtl.pkgsrlfrm = Convert.ToInt32(rows["pkgsrlfrm"].ToString());
                    _unldDtl.pkgsrlto = Convert.ToInt32(rows["pkgsrlfrm"].ToString());
                    _unldDtl.invoicequantity = Convert.ToDecimal(rows["invoicequantity"].ToString());
                    _unldDtl.receivequantity = Convert.ToDecimal(rows["receivequantity"].ToString());
                    _unldDtl.gross = Convert.ToDecimal(rows["gross"].ToString());
                    _unldDtl.tare = Convert.ToDecimal(rows["tare"].ToString());
                    _unldDtl.net = Convert.ToDecimal(rows["net"].ToString());
                    if (DBNull.Value != rows["floorId"])
                    {
                        _unldDtl.floorId = Convert.ToInt32(rows["floorId"].ToString());

                        _unldDtl.floorName = (rows["floorName"].ToString());
                    }
                    else {
                        _unldDtl.floorId = 0;
                        _unldDtl.floorName = null;
                    }
                    _unldDtl.unloadingnumber = rows["unloadingnumber"].ToString();
                    _unldDtl.receiptdate = Convert.ToDateTime(rows["receiptdate"].ToString());

                    _lstUnloadingDtl.Add(_unldDtl);

                }
            }
            return _lstUnloadingDtl;
        }





        /*****************************************************/

    }
}
