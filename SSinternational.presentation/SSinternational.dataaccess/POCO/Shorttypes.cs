using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.dataaccess.POCO
{
   public class Shorttypes
   {
       #region Properties
       public int ShortId{get;set;}
       public string ShortCode{get;set;}
       public string ShortName{get;set;}
       public int CompanyId{get;set; }
       #endregion


       public int InsertShortType(Shorttypes _shorttype)
       {
           ShorttypesDAL _DAL = new ShorttypesDAL();
           return _DAL.InsertShortType(_shorttype);

       }

       public int UpdateShortType(Shorttypes _shorttype)
       {
           ShorttypesDAL _DAL = new ShorttypesDAL();
           return _DAL.UpdateShortType(_shorttype);

       }
       public Boolean DeleteShortType(int ShortId)
       {
           ShorttypesDAL _DAL = new ShorttypesDAL();
           return _DAL.DeleteShortType(ShortId);

       }

       public Shorttypes GetShortTypeByShortId(int ShortId)
       {
           ShorttypesDAL _DAL = new ShorttypesDAL();

           DataTable dt = _DAL.GetShortTypeByShortId(ShortId);

           Shorttypes _shorttype = new Shorttypes();
           if (dt.Rows.Count > 0)
           {
               _shorttype.ShortId = Convert.ToInt32(dt.Rows[0]["ShortId"].ToString());
               _shorttype.ShortCode = (dt.Rows[0]["ShortCode"].ToString());
               _shorttype.ShortName = (dt.Rows[0]["ShortName"].ToString());
               _shorttype.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"].ToString());
           }
           return _shorttype;
       }

       public IEnumerable<Shorttypes> GetAllShortTypes(int CompanyId)
       {
           ShorttypesDAL _DAL = new ShorttypesDAL();
           List<Shorttypes> _ShorttypeList = new List<Shorttypes>();
           DataTable dt = _DAL.GetAllShortTypes(CompanyId);

          
           if (dt.Rows.Count > 0)
           {
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   Shorttypes _shorttype = new Shorttypes();
                   _shorttype.ShortId = Convert.ToInt32(dt.Rows[i]["ShortId"].ToString());
                   _shorttype.ShortCode = (dt.Rows[i]["ShortCode"].ToString());
                   _shorttype.ShortName = (dt.Rows[i]["ShortName"].ToString());
                   _shorttype.CompanyId = Convert.ToInt32(dt.Rows[i]["CompanyId"].ToString());
                   _ShorttypeList.Add(_shorttype);
               }
           }
           return _ShorttypeList;
       }
   }
}
