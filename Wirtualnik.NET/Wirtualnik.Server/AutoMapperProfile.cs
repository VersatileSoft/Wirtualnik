using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wirtualnik.Data.Models;
using Wirtualnik.Shared.Models.Processor;

namespace Wirtualnik.Shared.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateModel, Data.Models.Processor>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();

            CreateMap<ListItemModel, Data.Models.Processor>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();

            CreateMap<DetailsModel, Data.Models.Processor>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();

            CreateMap<ShopModel, Shop>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Products, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();
        }
    }
}
