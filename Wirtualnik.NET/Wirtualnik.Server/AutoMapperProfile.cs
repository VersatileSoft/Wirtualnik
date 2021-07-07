using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wirtualnik.Data.Models;
using Wirtualnik.Shared.Models;

namespace Wirtualnik.Shared.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ProcessorMap();
            GraphicMap();
            HardDiskMap();
            MainboardMap();
            MemoryMap();
            SolidStateDriveMap();
        }

        private void ProcessorMap()
        {
            CreateMap<Processor.CreateModel, Data.Models.Processor>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();

            CreateMap<Processor.ListItemModel, Data.Models.Processor>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();

            CreateMap<Processor.DetailsModel, Data.Models.Processor>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();
        }

        private void GraphicMap()
        {
            CreateMap<Graphic.CreateModel, Data.Models.Graphic>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();

            CreateMap<Graphic.ListItemModel, Data.Models.Graphic>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();

            CreateMap<Graphic.DetailsModel, Data.Models.Graphic>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();
        }

        private void HardDiskMap()
        {
            CreateMap<HardDisk.CreateModel, Data.Models.HardDisk>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();

            CreateMap<HardDisk.ListItemModel, Data.Models.HardDisk>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();

            CreateMap<HardDisk.DetailsModel, Data.Models.HardDisk>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();
        }

        private void MainboardMap()
        {
            CreateMap<Mainboard.CreateModel, Data.Models.Mainboard>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();

            CreateMap<Mainboard.ListItemModel, Data.Models.Mainboard>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();

            CreateMap<Mainboard.DetailsModel, Data.Models.Mainboard>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();
        }

        private void MemoryMap()
        {
            CreateMap<Memory.CreateModel, Data.Models.Memory>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();

            CreateMap<Memory.ListItemModel, Data.Models.Memory>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();

            CreateMap<Memory.DetailsModel, Data.Models.Memory>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();
        }

        private void SolidStateDriveMap()
        {
            CreateMap<SolidStateDrive.CreateModel, Data.Models.SolidStateDrive>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();

            CreateMap<SolidStateDrive.ListItemModel, Data.Models.SolidStateDrive>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();

            CreateMap<SolidStateDrive.DetailsModel, Data.Models.SolidStateDrive>()
                .ForMember(o => o.Id, k => k.Ignore())
                .ForMember(o => o.ProductShops, k => k.Ignore())
                .ForMember(o => o.Shops, k => k.Ignore())
                .ForMember(o => o.CreateDate, k => k.Ignore())
                .ForMember(o => o.UpdateDate, k => k.Ignore())
                .ReverseMap();
        }
    }
}