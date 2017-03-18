using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SSinternational.dataaccess.POCO;
using SSinternational.viewmodel;

namespace SSinternational.common
{
    public class DomainToVMMapper:Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToVMMapper";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<users, UserVM>();
            Mapper.CreateMap<companies, CompanyVM>();
            Mapper.CreateMap<financialyears, financialVM>();
            Mapper.CreateMap<customers, CustomerVM>();
            Mapper.CreateMap<estates, EsatetVM>();
            Mapper.CreateMap<gardens, GardenAddEditVM>();
            Mapper.CreateMap<gardens, GardenListVM>();
            Mapper.CreateMap<Warehouses, WarehousesVM>();
            Mapper.CreateMap<Packages, PackagesVM>();
            Mapper.CreateMap<Shorttypes, ShorttypesVM>();
            Mapper.CreateMap<Damagetypes, DamagetypesVM>();
        }
    }
}
