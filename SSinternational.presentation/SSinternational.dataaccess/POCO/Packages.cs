using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.dataaccess.POCO
{
   public class Packages
    {
       public int PackageId{get;set;}
       public string Code{get;set;}
       public string Description { get; set; }
       public bool IsActive{get;set;}
       public int CompanyId{get;set;}


       public int InsertPackege(Packages _Packages)
       {
           PackagesDAL _DAL = new PackagesDAL();
           return _DAL.InsertPackege(_Packages);

       }

       public int UpdatePackage(Packages _Packages)
       {
           PackagesDAL _DAL = new PackagesDAL();
           return _DAL.UpdatePackage(_Packages);

       }
       public Boolean DeletePackage(int PackageId)
       {
           PackagesDAL _DAL = new PackagesDAL();
          return _DAL.DeletePackage(PackageId);

       }

       public void UpdatePackageIsActiveState(int PackageId)
       {
           PackagesDAL _DAL = new PackagesDAL();
           _DAL.UpdatePackageIsActiveState(PackageId);

       }

       public Packages GetById(int PackageId)
       {
           PackagesDAL _DAL = new PackagesDAL();

           DataTable dt = _DAL.GetById(PackageId);

           Packages _Package = new Packages();
           if (dt.Rows.Count > 0)
           {
               _Package.PackageId = Convert.ToInt32(dt.Rows[0]["PackageId"].ToString());
               _Package.Code = (dt.Rows[0]["Code"].ToString());
               _Package.Description = (dt.Rows[0]["Description"].ToString());
               _Package.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
               _Package.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"].ToString());
           }
           return _Package;
       }

       public IEnumerable<Packages> GetAllPackages(int CompanyId)
       {
           PackagesDAL _DAL = new PackagesDAL();
           List<Packages> _PackagesList = new List<Packages>();
           DataTable dt = _DAL.GetAllPackages(CompanyId);


           if (dt.Rows.Count > 0)
           {
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   Packages _Package = new Packages();
                   _Package.PackageId = Convert.ToInt32(dt.Rows[i]["PackageId"].ToString());
                   _Package.Code = (dt.Rows[i]["Code"].ToString());
                   _Package.Description = (dt.Rows[i]["Description"].ToString());
                   _Package.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"].ToString());
                   _Package.CompanyId = Convert.ToInt32(dt.Rows[i]["CompanyId"].ToString());
                   _PackagesList.Add(_Package);
               }
           }
           return _PackagesList;
       }

       public IEnumerable<Packages> GetAllActivePackages(int CompanyId)
       {
           PackagesDAL _DAL = new PackagesDAL();
           List<Packages> _PackagesList = new List<Packages>();
           DataTable dt = _DAL.GetAllActivePackages(CompanyId);


           if (dt.Rows.Count > 0)
           {
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   Packages _Package = new Packages();
                   _Package.PackageId = Convert.ToInt32(dt.Rows[i]["PackageId"].ToString());
                   _Package.Code = (dt.Rows[i]["Code"].ToString());
                   _Package.Description = (dt.Rows[i]["Description"].ToString());
                   _Package.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"].ToString());
                   _Package.CompanyId = Convert.ToInt32(dt.Rows[i]["CompanyId"].ToString());
                   _PackagesList.Add(_Package);
               }
           }
           return _PackagesList;
       }
    }
}
