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
   public class PackagesSL
    {
       public int InsertPackege(PackagesVM _Packages)
        {
            Packages _PackagesPoco = new Packages();
            _PackagesPoco = Mapper.Map<PackagesVM, Packages>(_Packages);
            return _PackagesPoco.InsertPackege(_PackagesPoco);
        }
       public int UpdatePackage(PackagesVM _Package)
        {
            Packages _PackagesPoco = new Packages();
            _PackagesPoco = Mapper.Map<PackagesVM, Packages>(_Package);
            return _PackagesPoco.UpdatePackage(_PackagesPoco);

        }

       public Boolean DeletePackage(int PackageId)
        {
            Packages _PackagesPoco = new Packages();
            return _PackagesPoco.DeletePackage(PackageId);

        }

       public void UpdatePackageIsActiveState(int PackageId)
        {
            Packages _PackagesPoco = new Packages();
            _PackagesPoco.UpdatePackageIsActiveState(PackageId);

        }

        public PackagesVM GetByPackageId(int PackageId)
        {
            Packages _PackagesPoco = new Packages();
            return Mapper.Map<Packages, PackagesVM>(_PackagesPoco.GetById(PackageId));
        }

        public IEnumerable<PackagesVM> GetAllPackages(int CompanyId)
        {
            Packages _PackagesPoco = new Packages();
            return Mapper.Map<IEnumerable<Packages>, IEnumerable<PackagesVM>>(_PackagesPoco.GetAllPackages(CompanyId));
        }
        public IEnumerable<PackagesVM> GetAllActivePackages(int CompanyId)
        {
            Packages _PackagesPoco = new Packages();
            return Mapper.Map<IEnumerable<Packages>, IEnumerable<PackagesVM>>(_PackagesPoco.GetAllActivePackages(CompanyId));
        }
    }
}
