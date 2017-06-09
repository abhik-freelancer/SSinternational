using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SSinternational.dataaccess.POCO
{
    public class financialyears
    {

        public int fiscalid { get; set; }
        public DateTime fiscalstartdate { get; set; }
        public DateTime fiscalenddate { get; set; }
        public string fiscalyear { get; set; }


        public IEnumerable<financialyears> getfinancialyearsList()
        {

            financialyearsDAL _financialyearDAL = new financialyearsDAL();
            DataTable dt = _financialyearDAL.getFiscalList();
            List<financialyears> _lst = new List<financialyears>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    financialyears _objfinancial = new financialyears();
                    _objfinancial.fiscalid = Convert.ToInt32(row["fiscalid"].ToString());
                    _objfinancial.fiscalstartdate = Convert.ToDateTime(row["startdate"].ToString());
                    _objfinancial.fiscalenddate = Convert.ToDateTime(row["enddate"].ToString());
                    _objfinancial.fiscalyear = row["fiscalyear"].ToString();
                    _lst.Add(_objfinancial);
                }
            }
            return _lst;
        }

        public financialyears getFiscalYearById(int YearId)
        {

            financialyearsDAL _financialyearDAL = new financialyearsDAL();
            DataTable dt = _financialyearDAL.getFiscalYearById(YearId);

            financialyears _objfinancial = new financialyears();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];


                _objfinancial.fiscalid = Convert.ToInt32(row["fiscalid"].ToString());
                _objfinancial.fiscalstartdate = Convert.ToDateTime(row["startdate"].ToString());
                _objfinancial.fiscalenddate = Convert.ToDateTime(row["enddate"].ToString());
                _objfinancial.fiscalyear = row["fiscalyear"].ToString();


            }
            return _objfinancial;
        }
    }
}
