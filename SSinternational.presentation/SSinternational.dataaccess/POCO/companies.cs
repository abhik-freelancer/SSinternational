using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SSinternational.dataaccess.POCO
{
   public class companies
    {
       public int companyid { get; set; }
       public string company { get; set; }
       public string companyaddress { get; set; }
       public string companystate { get; set; }
       public string companypin { get; set; }
       public string companytin { get; set; }
       public string companypan { get; set; }
       public string companytan { get; set; }



       public IEnumerable<companies> getCompanyList() {

           companyDAL _companyDAL = new companyDAL();
           DataTable dt = _companyDAL.getCompanyList();
           List<companies> _lstCompanies = new List<companies>();
          
           if (dt.Rows.Count > 0) { 
           
            foreach(DataRow row in dt.Rows ){
                companies _objCompany = new companies();
                _objCompany.companyid = Convert.ToInt32(row["companyid"].ToString());
                _objCompany.company = (row["companyname"].ToString());
                _objCompany.companyaddress = (row["companyaddress"].ToString());
                _objCompany.companystate = (row["companystate"].ToString());
                _objCompany.companypin = (row["companypin"].ToString());
                _objCompany.companytin = (row["companytin"].ToString());
                _objCompany.companytan = (row["companytan"].ToString());
                _objCompany.companypan = (row["companypanypan"].ToString());

                _lstCompanies.Add(_objCompany);

            }
           
           }

           return _lstCompanies;

       
       }
   
   
   
   }
}
