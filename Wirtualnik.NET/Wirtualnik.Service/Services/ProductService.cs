using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Extensions;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Service.Services.Base;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Service.Services
{
    public class ProductService : ServiceBase, IProductService
    {
        private readonly IHostingEnvironment _environment;
        public ProductService(WirtualnikDbContext context, IMapper mapper, IHostingEnvironment environment) : base(context, mapper)
        {
            _environment = environment;
        }

        public Task<Product> Fetch(string publicId)
        {
            return Context.Products
                .Include(p => p.Properties).ThenInclude(p => p.PropertyType)
                .Include(p => p.ProductType)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.PublicId == publicId);
        }

        public async Task<List<ProductTypeModel>> GetAllProductTypes()
        {
            return await Context.ProductTypes.Include(t => t.ProductProperties).Select(p => new ProductTypeModel
            {
                Id = p.Id,
                Name = p.Name,
                PropertyTypes = p.ProductProperties.Select(t => new KeyValuePair<int, string>(t.Id, t.Name)).ToList()
            }).ToListAsync();
        }

        public async Task<IEnumerable<ListItemModel>> GetProductsAsync(Pager pager, Dictionary<string, string> filter)
        {
            var query = Context.Products
                .Include(p => p.Properties).ThenInclude(p => p.PropertyType)
                .Include(p => p.ProductType)
                .Include(p => p.Images)
                .AsQueryable();

            if (filter.TryGetValue("ProductTypeId", out string stringValue) && int.TryParse(stringValue, out int value))
                query = query.Where(p => p.ProductTypeId == value);

            foreach (var property in filter)
            {
                query = query.Where(product => product.Properties.Any(prop => prop.PropertyType.Name == property.Key) ?
                product.Properties.Single(prop => prop.PropertyType.Name == property.Key).Value == property.Value : true);
            }

            return Mapper.Map<List<ListItemModel>>(await query.Paginate(pager).ToListAsync());

        }

        public async Task SaveImages(List<IFormFile> images, int id)
        {
            foreach (var formFile in images)
            {
                var name = formFile.FileName;
                var nameAndExt = name.Split(".");
                name = nameAndExt[0];

                if (formFile.Length > 0)
                {
                    var (width, height) = formFile.GetImageSizeFromFile();

                    var fileName = $"{Guid.NewGuid()}.{nameAndExt[1]}";
                    var filePath = Path.Combine(_environment.WebRootPath, "static", "img", "p", fileName);

                    var dir = Path.GetDirectoryName(filePath);
                    if (dir is null) throw new Exception();
                    Directory.CreateDirectory(dir);

                    await CreateAsync(new Data.Models.Image
                    {
                        FileName = fileName,
                        ProductId = id,
                        Width = width,
                        Height = height,
                        Main = formFile.FileName.Trim().ToLower().Contains("main")
                    });

                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(fileStream);
                    }
                }
            }
        }

        public Task<bool> UpdateAsync(CreateModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
