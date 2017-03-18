using SSinternational.service;
using SSinternational.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.business
{
    public class ShorttypesBL
    {
        public int InsertShortType(ShorttypesVM _shorttypeWM)
        {
            ShorttypesSL _SL = new ShorttypesSL();
           
            return _SL.InsertShortType(_shorttypeWM);


        }

        public int UpdateShortType(ShorttypesVM _shorttypeWM)
        {
            ShorttypesSL _SL = new ShorttypesSL();
            return _SL.UpdateShortType(_shorttypeWM);

        }
        public Boolean DeleteShortType(int ShortId)
        {
            ShorttypesSL _SL = new ShorttypesSL();
            return _SL.DeleteShortType(ShortId);

        }

        public ShorttypesVM GetShortTypeByShortId(int ShortId)
        {
            ShorttypesSL _SL = new ShorttypesSL();
            return _SL.GetShortTypeByShortId(ShortId);
         

        }

        public IEnumerable<ShorttypesVM> GetAllShortTypes(int CompanyId)
        {
            ShorttypesSL _SL = new ShorttypesSL();
            return _SL.GetAllShortTypes(CompanyId);

        }
    }
}
