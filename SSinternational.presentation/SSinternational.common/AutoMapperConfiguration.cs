using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace SSinternational.common
{
    public static class AutoMapperConfiguration
    {
        public static void Configure() { 
            Mapper.Initialize(x=>
            {
                x.AddProfile<DomainToVMMapper>();
                x.AddProfile<VMToDomainMapper>();                    
            });
        }
    }
}
