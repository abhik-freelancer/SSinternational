using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SSinternational.dataaccess.POCO
{
   public  class rateMasterPOCO
    {
        public decimal rate_id { get; set; }
        public decimal slab_rate1 { get; set; }
        public decimal slab_rate2 { get; set; }
        public decimal slab_rate3 { get; set; }
        public decimal slab_rate4 { get; set; }
        public decimal StrRemRate { get; set; }
        public decimal ChkWghRate { get; set; }
        public decimal SamplingRate { get; set; }
        public decimal AdditionalRate { get; set; }
        public int yearId { get; set; }
        public int companyId { get; set; }

       /// <summary>
       /// Get rate constant by companyid and yearid
       /// </summary>
       /// <param name="company"></param>
       /// <param name="year"></param>
       /// <returns></returns>
       public rateMasterPOCO getRateMasterData(int company,int year){
           rateMasterDAL _rateDAL = new rateMasterDAL();
           rateMasterPOCO _ratePOCO = new rateMasterPOCO();
           DataTable dt = _rateDAL.getRateSlab(company,year) ;

           if(dt.Rows.Count>0){

               DataRow rows = dt.Rows[0];
               _ratePOCO.rate_id = Convert.ToInt32(rows["rate_id"].ToString());
               _ratePOCO.slab_rate1 = Convert.ToDecimal(rows["slab_rate1"].ToString());
               _ratePOCO.slab_rate2 = Convert.ToDecimal(rows["slab_rate2"].ToString());
               _ratePOCO.slab_rate3 = Convert.ToDecimal(rows["slab_rate3"].ToString());
               _ratePOCO.slab_rate4 = Convert.ToDecimal(rows["slab_rate4"].ToString());

               _ratePOCO.StrRemRate = Convert.ToDecimal(rows["StrRemRate"].ToString()); // street removal rate
               _ratePOCO.ChkWghRate = Convert.ToDecimal(rows["ChkWghRate"].ToString()); // checkweghment rate
               _ratePOCO.AdditionalRate = Convert.ToDecimal(rows["AdditionalRate"].ToString()); //additional rate
               _ratePOCO.SamplingRate = Convert.ToDecimal(rows["SamplingRate"].ToString());//sampling rate

               _ratePOCO.yearId = Convert.ToInt32(rows["yearId"].ToString());
               _ratePOCO.companyId = Convert.ToInt32(rows["companyId"].ToString());

           }
           return _ratePOCO;
       }
    }
}
