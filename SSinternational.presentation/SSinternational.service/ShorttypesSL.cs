using AutoMapper;
using SSinternational.dataaccess.POCO;
using SSinternational.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.service
{
   public class ShorttypesSL
    {
        public int InsertShortType(ShorttypesVM _shorttypeWM)
        {
            Shorttypes _ShorttypesPoco = new Shorttypes();
            _ShorttypesPoco = Mapper.Map<ShorttypesVM, Shorttypes>(_shorttypeWM);
            return _ShorttypesPoco.InsertShortType(_ShorttypesPoco);
          

        }

        public int UpdateShortType(ShorttypesVM _shorttypeWM)
        {
            Shorttypes _ShorttypesPoco = new Shorttypes();
            _ShorttypesPoco = Mapper.Map<ShorttypesVM, Shorttypes>(_shorttypeWM);
            return _ShorttypesPoco.UpdateShortType(_ShorttypesPoco);

        }
        public Boolean DeleteShortType(int ShortId)
        {
            Shorttypes _ShorttypesPoco = new Shorttypes();
            return _ShorttypesPoco.DeleteShortType(ShortId);

        }

        public ShorttypesVM GetShortTypeByShortId(int ShortId)
        {
            Shorttypes _ShorttypesPoco = new Shorttypes();
            return Mapper.Map<Shorttypes, ShorttypesVM>(_ShorttypesPoco.GetShortTypeByShortId(ShortId));
           
        }

        public IEnumerable<ShorttypesVM> GetAllShortTypes()
        {
            Shorttypes _ShorttypesPoco = new Shorttypes();
            return Mapper.Map<IEnumerable<Shorttypes>, IEnumerable<ShorttypesVM>>(_ShorttypesPoco.GetAllShortTypes());
          
        }
    }
}
