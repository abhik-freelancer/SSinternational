using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.dataaccess.POCO
{
   public class Damagetypes
   {
       #region
       public int DamageId{get;set;}
       public string DamageCode{get;set;}
       public string Description{get;set;}
    
       #endregion

       public int InsertDamageType(Damagetypes _damage)
       {
           DamagetypesDAL _DAL = new DamagetypesDAL();
           return _DAL.InsertDamageType(_damage);

       }

       public int UpdateDamageType(Damagetypes _damage)
       {
           DamagetypesDAL _DAL = new DamagetypesDAL();
           return _DAL.UpdateDamageType(_damage);

       }
       public Boolean DeleteDeleteByDamageId(int DamageId)
       {
           DamagetypesDAL _DAL = new DamagetypesDAL();
           return _DAL.DeleteDeleteByDamageId(DamageId);

       }

       public Damagetypes GetDamageTypesByDamageId(int DamageId)
       {
           DamagetypesDAL _DAL = new DamagetypesDAL();
           DataTable dt = _DAL.GetDamageTypesByDamageId(DamageId);
           Damagetypes _damage = new Damagetypes();
           if (dt.Rows.Count > 0)
           {
               _damage.DamageId = Convert.ToInt32(dt.Rows[0]["DamageId"].ToString());
               _damage.DamageCode = (dt.Rows[0]["DamageCode"].ToString());
               _damage.Description = (dt.Rows[0]["Description"].ToString());             
           }
           return _damage;
       }

       public IEnumerable<Damagetypes> GetAllDamageTypes()
       {
           DamagetypesDAL _DAL = new DamagetypesDAL();
           List<Damagetypes> _damageList = new List<Damagetypes>();
           DataTable dt = _DAL.GetAllDamageTypes();


           if (dt.Rows.Count > 0)
           {
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   Damagetypes _damage = new Damagetypes();
                   _damage.DamageId = Convert.ToInt32(dt.Rows[i]["DamageId"].ToString());
                   _damage.DamageCode = (dt.Rows[i]["DamageCode"].ToString());
                   _damage.Description = (dt.Rows[i]["Description"].ToString());
                   _damageList.Add(_damage);
               }
           }
           return _damageList;
       }
   }
}
