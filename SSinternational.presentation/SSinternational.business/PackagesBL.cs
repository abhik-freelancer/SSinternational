using SSinternational.service;
using SSinternational.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSinternational.business
{
   public class PackagesBL
    {
       public int InsertPackege(PackagesVM _Packages)
        {
            PackagesSL _SL = new PackagesSL();

            return _SL.InsertPackege(_Packages);
        }

       public int UpdatePackage(PackagesVM _Package)
        {
            PackagesSL _SL = new PackagesSL();


            return _SL.UpdatePackage(_Package);

        }

       public void DeletePackage(int PackageId)
        {
            PackagesSL _SL = new PackagesSL();
            _SL.DeletePackage(PackageId);

        }

       public void UpdatePackageIsActiveState(int PackageId)
        {
            PackagesSL _SL = new PackagesSL();
            _SL.UpdatePackageIsActiveState(PackageId);

        }

       public PackagesVM GetByPackageId(int PackageId)
        {
            PackagesSL _SL = new PackagesSL();
            return _SL.GetByPackageId(PackageId);
        }

       public IEnumerable<PackagesVM> GetAllPackages(int CompanyId)
        {
            PackagesSL _SL = new PackagesSL();
            return _SL.GetAllPackages(CompanyId);
        }
       public IEnumerable<PackagesVM> GetAllActiveWarehouse(int CompanyId)
        {
            PackagesSL _SL = new PackagesSL();
            return _SL.GetAllActivePackages(CompanyId);
        }
    }
}
