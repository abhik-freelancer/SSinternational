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
        }
    }
}
