using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Shared.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ProductMap();
        }

        private void ProductMap()
        {
            CreateMap<CreateModel, Data.Models.Product>()
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.ProductType, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore());

            CreateMap<Data.Models.Product, DetailsModel>()
                .ForMember(o => o.ProductTypeName, k => k.MapFrom(m => m.ProductType.Name));

            CreateMap<Data.Models.Product, ListItemModel>()
               .ForMember(o => o.ProductTypeName, k => k.MapFrom(m => m.ProductType.Name));

            CreateMap<KeyValuePair<int, string>, Data.Models.Property>()
                .ForMember(o => o.PropertyTypeId, k => k.MapFrom(m => m.Key))
                .ForMember(o => o.Value, k => k.MapFrom(m => m.Value))
                .ForMember(o => o.ProductId, k => k.Ignore())
                .ForMember(o => o.Product, k => k.Ignore())
                .ForMember(o => o.PropertyType, k => k.Ignore())
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore());

            CreateMap<Data.Models.Property, KeyValuePair<string, string>>()
                .ConstructUsing(kvp => new KeyValuePair<string, string>(kvp.PropertyType.Name, kvp.Value));
        }
    }
}