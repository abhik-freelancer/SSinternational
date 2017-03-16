using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SSinternational.dataaccess.POCO
{
   public class estates
    {
       public int estateId { get; set; }
       public string estate { get; set; }
       public string estatecode { get; set; }
       public int companyid { get; set; }



       public IEnumerable<estates> getEstateList(int companyId)
       {
           estateDAL _estateDAL = new estateDAL();
           DataTable dt = _estateDAL.getEstateList(companyId);
           List<estates> _estatelst = new List<estates>();

           if (dt.Rows.Count > 0)
           {
               foreach (DataRow row in dt.Rows)
               {

                   estates _estate = new estates();
                   _estate.estateId = Convert.ToInt32(row["estateId"].ToString());
                   _estate.estate = (row["estate"].ToString());

                   if (DBNull.Value == (row["estatecode"]))
                   {
                       _estate.estatecode = null;
                   }
                   else
                   {
                       _estate.estatecode = (row["estatecode"].ToString());
                   }
                   _estate.companyid = Convert.ToInt32(row["companyid"].ToString());

                   _estatelst.Add(_estate);
               }

           }
           return _estatelst;
       }

       public int insertEstate(estates estate)
       {
           estateDAL _estateDAL = new estateDAL();
           return _estateDAL.insertEstate(estate);

       }


       public estates getEstateById(int estateId)
       {

           estateDAL _estateDAL = new estateDAL();
           DataTable dt = _estateDAL.getEstateById(estateId);
           estates _estate = new estates();

           if (dt.Rows.Count > 0)
           {
               DataRow row = dt.Rows[0];

               _estate.estateId = Convert.ToInt32(row["estateId"].ToString());
               _estate.estate = (row["estate"].ToString());

               if (DBNull.Value == (row["estatecode"]))
               {
                   _estate.estatecode = null;
               }
               else
               {
                   _estate.estatecode = (row["estatecode"].ToString());
               }
              
           }

           return _estate;
       }

       public void upadateEstate(estates _estate)
       {
           estateDAL _estateDAL = new estateDAL();
           _estateDAL.upadateEstate(_estate);

       }

       public Boolean DeleteEstate(int estateId)
       {
           estateDAL _estateDAL = new estateDAL();

           return _estateDAL.estateDelete(estateId);

       }


    }
}
