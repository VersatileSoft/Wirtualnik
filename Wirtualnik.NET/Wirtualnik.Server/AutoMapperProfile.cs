using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wirtualnik.Data.Models;

namespace Wirtualnik.Shared.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProcessorModel, Processor>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ReverseMap();
        }
    }
}
