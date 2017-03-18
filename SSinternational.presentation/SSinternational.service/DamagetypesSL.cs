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
  public  class DamagetypesSL
    {
      public int InsertDamageType(DamagetypesVM _damage)
        {
            Damagetypes _damagesPoco = new Damagetypes();
            _damagesPoco = Mapper.Map<DamagetypesVM, Damagetypes>(_damage);
            return _damagesPoco.InsertDamageType(_damagesPoco);


        }

      public int UpdateDamageType(DamagetypesVM _damage)
        {
            Damagetypes _damagesPoco = new Damagetypes();
            _damagesPoco = Mapper.Map<DamagetypesVM, Damagetypes>(_damage);
            return _damagesPoco.UpdateDamageType(_damagesPoco);

        }
      public Boolean DeleteDeleteByDamageId(int DamageId)
        {
            Damagetypes _damagesPoco = new Damagetypes();
            return _damagesPoco.DeleteDeleteByDamageId(DamageId);

        }

      public DamagetypesVM GetDamageTypesByDamageId(int DamageId)
        {
            Damagetypes _damagesPoco = new Damagetypes();
            return Mapper.Map<Damagetypes, DamagetypesVM>(_damagesPoco.GetDamageTypesByDamageId(DamageId));

        }

      public IEnumerable<DamagetypesVM> GetAllDamageTypes()
        {
            Damagetypes _damagesPoco = new Damagetypes();
            return Mapper.Map<IEnumerable<Damagetypes>, IEnumerable<DamagetypesVM>>(_damagesPoco.GetAllDamageTypes());

        }
    }
}
