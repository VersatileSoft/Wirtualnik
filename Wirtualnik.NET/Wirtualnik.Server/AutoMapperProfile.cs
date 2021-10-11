using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Service.Services;
using Wirtualnik.Shared.Models.Category;
using Wirtualnik.Shared.Models.Files;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Shared.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ProductMap();
            CartMap();
        }

        private void CartMap()
        {
            CreateMap<Data.Models.Cart, Shared.Models.Cart.DetailsModel>()
                .ForMember(c => c.Quantity, o => o.MapFrom(d => d.Products.Count));


            CreateMap<Data.Models.CartValidator, Shared.Models.Cart.WarningModel>()
                .ForMember(c => c.Image, o => o.Ignore());

            CreateMap<Data.Models.CartValidator, Shared.Models.CartValidator.CartValidatorModel>()
                .ReverseMap();
        }

        private void ProductMap()
        {
            CreateMap<CreateModel, Data.Models.Product>()
                .ForMember(o => o.ProductProperties, k => k.MapFrom(m => m.Properties))
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.Images, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.Category, k => k.Ignore())
                .ForMember(o => o.CartProducts, k => k.Ignore())
                .ForMember(o => o.Carts, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore());

            CreateMap<Data.Models.Product, DetailsModel>()
                .ForMember(o => o.Properties, k => k.MapFrom(m => m.ProductProperties))
                .ForMember(o => o.ProductTypeName, k => k.MapFrom(m => m.Category.Name))
                .ForMember(o => o.ProductShopDetails, k => k.Ignore())
                .ForMember(o => o.Images, k => k.Ignore())
                .ForMember(o => o.IsInCart, k => k.Ignore());

            CreateMap<Data.Models.Category, CategoryModel>()
                .ReverseMap();

            CreateMap<Data.Models.CategoryProperty, CategoryPropertyModel>()
                .ReverseMap();

            CreateMap<Data.Models.Product, ListItemModel>()
               .ForMember(o => o.Properties, k => k.MapFrom(m => m.ProductProperties))
               .ForMember(o => o.ProductTypeName, k => k.MapFrom(m => m.Category.Name))
               .ForMember(o => o.ProductShopDetails, k => k.Ignore())
               .ForMember(o => o.Image, k => k.Ignore())
               .ForMember(o => o.IsInCart, k => k.Ignore())
               .ForMember(o => o.IsInComparison, k => k.Ignore());

            CreateMap<KeyValuePair<int, string>, Data.Models.ProductProperty>()
                .ForMember(o => o.CategoryPropertyId, k => k.MapFrom(m => m.Key))
                .ForMember(o => o.Value, k => k.MapFrom(m => m.Value))
                .ForMember(o => o.ProductId, k => k.Ignore())
                .ForMember(o => o.Product, k => k.Ignore())
                .ForMember(o => o.CategoryProperty, k => k.Ignore())
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore());

            CreateMap<Data.Models.ProductProperty, KeyValuePair<string, string>>()
                .ConstructUsing(kvp => new KeyValuePair<string, string>(kvp.CategoryProperty.Name, kvp.Value));

            CreateMap<Data.Models.ProductProperty, ProductPropertyModel>()
                .ForMember(o => o.Name, k => k.MapFrom(m => m.CategoryProperty.Name))
                .ForMember(o => o.Description, k => k.MapFrom(m => m.CategoryProperty.Description))
                .ForMember(o => o.Value, k => k.MapFrom(m => m.Value));

            CreateMap<Data.Models.Image, ImageModel>();
        }
    }
}