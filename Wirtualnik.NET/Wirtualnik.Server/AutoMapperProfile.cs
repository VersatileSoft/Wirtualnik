using AutoMapper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wirtualnik.Shared.Models.Product;
using Wirtualnik.Shared.Models.ProductType;

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
                .ForMember(o => o.Images, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.ProductType, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore());

            CreateMap<Data.Models.Product, DetailsModel>()
                .ForMember(o => o.ProductTypeName, k => k.MapFrom(m => m.ProductType.Name))
                .ForMember(o => o.ProductShopDetails, k => k.MapFrom(m => m.ProductShops))
                .ForMember(o => o.Images, k => k.MapFrom<DetailsImagesResolver>());

            CreateMap<Data.Models.ProductShop, Shared.Models.Shop.ProductShopDetails>()
                .ForMember(o => o.Image, k => k.Ignore())
                .ForMember(o => o.Name, k => k.MapFrom(m => m.Shop.Name));

            CreateMap<Data.Models.ProductType, ProductTypeModel>()
                .ReverseMap();

            CreateMap<Data.Models.PropertyType, PropertyModel>()
                .ReverseMap();

            CreateMap<Data.Models.Product, ListItemModel>()
               .ForMember(o => o.ProductTypeName, k => k.MapFrom(m => m.ProductType.Name))
               .ForMember(o => o.ProductShopDetails, k => k.MapFrom(m => m.ProductShops))
               .ForMember(o => o.Image, k => k.MapFrom<ListImagesResolver>());

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

    public class DetailsImagesResolver : IValueResolver<Data.Models.Product, DetailsModel, List<string>>
    {
        public List<string> Resolve(Data.Models.Product source, DetailsModel destination, List<string> destMember, ResolutionContext context)
        {
            return source.Images
                .Where(i => i.Width == 200 && i.Height == 200)
                .OrderByDescending(i => i.Main)
                .Select(i => Path.Combine("static", "img", "p", i.FileName))
                .ToList();
        }
    }

    public class ListImagesResolver : IValueResolver<Data.Models.Product, ListItemModel, string?>
    {
        public string? Resolve(Data.Models.Product source, ListItemModel destination, string? destMember, ResolutionContext context)
        {
            return source.Images
                .Where(i => i.Width == 200 && i.Height == 200 && i.Main)
                .Select(i => Path.Combine("static", "img", "p", i.FileName))
                .FirstOrDefault();
        }
    }
}