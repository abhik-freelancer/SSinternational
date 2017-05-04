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
  public class VMToDomainMapper:Profile
    {
      public override string ProfileName
      {
          get
          {
              return "VMToDomainMapper";
          }
      }

      protected override void Configure()
      {
          Mapper.CreateMap<CustomerVM, customers>();
          Mapper.CreateMap<EsatetVM, estates>();
          Mapper.CreateMap<GardenAddEditVM, gardens>();
          Mapper.CreateMap<WarehousesVM, Warehouses>();
          Mapper.CreateMap<PackagesVM, Packages>();
          Mapper.CreateMap<ShorttypesVM, Shorttypes>();
          Mapper.CreateMap<DamagetypesVM, Damagetypes>();
          Mapper.CreateMap<BrokersVM, Brokers>();
          Mapper.CreateMap<UnloadingmasterVM,UnloadingmasterPOCO>();
          Mapper.CreateMap<UnloadingDtlAddEditVM,UnloadingDetails>();
          Mapper.CreateMap<ShortBagDtlsVM, ShortBagDtls>();
          Mapper.CreateMap<DamageBagDtlsVM, DamageBagDtl>();
          
        }
    }
}
