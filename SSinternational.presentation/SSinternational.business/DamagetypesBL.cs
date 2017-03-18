using SSinternational.service;
using SSinternational.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.business
{
   public class DamagetypesBL
    {
       public int InsertDamageType(DamagetypesVM _damage)
        {
            DamagetypesSL _SL = new DamagetypesSL();

            return _SL.InsertDamageType(_damage);


        }

       public int UpdateDamageType(DamagetypesVM _damage)
        {
            DamagetypesSL _SL = new DamagetypesSL();

            return _SL.UpdateDamageType(_damage);

        }
       public Boolean DeleteDeleteByDamageId(int DamageId)
        {
            DamagetypesSL _SL = new DamagetypesSL();

            return _SL.DeleteDeleteByDamageId(DamageId);

        }

       public DamagetypesVM GetDamageTypesByDamageId(int DamageId)
        {
            DamagetypesSL _SL = new DamagetypesSL();

            return _SL.GetDamageTypesByDamageId(DamageId);


        }

       public IEnumerable<DamagetypesVM> GetAllDamageTypes()
        {
            DamagetypesSL _SL = new DamagetypesSL();
            return _SL.GetAllDamageTypes();

        }
    }
}
