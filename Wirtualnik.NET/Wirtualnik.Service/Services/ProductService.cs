using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Service.Services.Base;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Service.Services
{
    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(WirtualnikDbContext context, IMapper mapper) : base(context, mapper)
        { }

        public Task<Product> FetchAsync(string publicId)
        {
            return Context.Products
                .Include(p => p.Properties).ThenInclude(p => p.PropertyType)
                .Include(p => p.ProductType)
                .Include(p => p.Images)
                .Include(p => p.ProductShops).ThenInclude(p => p.Shop)
                .FirstOrDefaultAsync(p => p.PublicId == publicId);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(Pager pager, FilterModel filter, Dictionary<string, string> dynamicFilter)
        {
            var query = Context.Products
                .Include(p => p.Properties.Where(p => p.PropertyType.ShowInCell))
                .ThenInclude(p => p.PropertyType)
                .Include(p => p.ProductType)
                .Include(p => p.Images)
                .Include(p => p.ProductShops).ThenInclude(p => p.Shop)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.ProductType))
                query = query.Where(p => p.ProductType.PublicId == filter.ProductType);

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(p => p.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(filter.Manufacturer))
                query = query.Where(p => p.Manufacturer.Contains(filter.Manufacturer, StringComparison.OrdinalIgnoreCase));

            foreach (var property in dynamicFilter)
            {
                query = query.Where(product => !product.Properties.Any(prop => prop.PropertyType.Name == property.Key) ||
                product.Properties.Single(prop => prop.PropertyType.Name == property.Key).Value == property.Value);
            }

            return await query.Paginate(pager).ToListAsync();
        }

        public async Task XlsxImport(IFormFile file, string productTypeId)
        {
            using (var fileStream = file.OpenReadStream())
            {
                var hssfwb = new XSSFWorkbook(fileStream);
                var sheet = hssfwb.GetSheetAt(0);
                var headers = GetXlsxHeaders(sheet);
                var productType = await Context.ProductTypes.Include(t => t.PropertyTypes).FirstOrDefaultAsync(t => t.PublicId == productTypeId);

                if (productType == null)
                {
                    productType = await CreateProductType(productTypeId, headers);
                }

                ValidateHeaders(headers, productType);

                var prodType = typeof(Product);

                for (int rowNum = 1; rowNum <= sheet.LastRowNum; rowNum++)
                {
                    var row = sheet.GetRow(rowNum);
                    Product product = new Product();
                    product.Properties = new List<Property>();

                    foreach (var header in headers)
                    {
                        if (row.GetCell(header.Key) is null)
                        {
                            break;
                        }

                        var prodMainProp = prodType.GetProperties().FirstOrDefault(p => p.Name == header.Value);

                        if (prodMainProp == null)
                        {
                            var propType = productType.PropertyTypes.Single(p => p.Name == header.Value);

                            product.Properties.Add(new Property
                            {
                                CreateDate = DateTime.Now,
                                PropertyType = propType,
                                Value = row.GetCell(header.Key).GetStringValue()
                            });
                        }
                        else
                        {
                            prodMainProp.SetValue(product, row.GetCell(header.Key).GetStringValue());
                        }
                    }

                    product.Archived = false;
                    product.ProductType = productType;

                    if(!string.IsNullOrEmpty(product.PublicId) && !(await Context.Products.AnyAsync(p => p.PublicId == product.PublicId)))
                    {
                        await CreateAsync(product);
                    }
                }
            }
        }

        private async Task<ProductType> CreateProductType(string productTypeId, Dictionary<int, string> headers)
        {
            var newProps = headers.Where(h => !typeof(Product).GetProperties().Any(p => p.Name == h.Value)).Select(h => new PropertyType
            {
                CreateDate = DateTime.Now,
                Name = h.Value,
                ShowInCart = true,
                ShowInCell = h.Key < 11,
                ShowInFilter = true
            }).ToList();

            ProductType productType = new ProductType
            {
                CreateDate = DateTime.Now,
                Name = "Test",
                PublicId = productTypeId,
                PropertyTypes = newProps
            };

            return await CreateAsync(productType);
        }

        private void ValidateHeaders(Dictionary<int, string> headers, ProductType productType)
        {
            foreach (var header in headers)
            {
                var match = productType.PropertyTypes.Any(p => p.Name == header.Value);
                if (!match)
                {
                    match = typeof(Product).GetProperties().Any(p => p.Name == header.Value);
                    if (!match)
                        throw new ValidationException($"Unknown property: {header}");
                }
            }
        }

        private Dictionary<int, string> GetXlsxHeaders(ISheet sheet)
        {
            var result = new Dictionary<int, string>();

            var headerRow = sheet.GetRow(0);

            foreach (var headerCell in headerRow.Cells)
            {
                result.Add(headerCell.ColumnIndex, headerCell.StringCellValue);
            }

            return result;
        }
    }


    public static class Extensions
    {
        public static string GetStringValue(this ICell cell)
        {
            return cell.CellType switch
            {
                CellType.Numeric => cell.NumericCellValue.ToString(),
                CellType.String => cell.StringCellValue,
                CellType.Formula => cell.CellFormula,
                CellType.Boolean => cell.BooleanCellValue ? "PRAWDA" : "FAŁSZ",
                _ => cell.NumericCellValue.ToString(),
            };
        }
    }
}