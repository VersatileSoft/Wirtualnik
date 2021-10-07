using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Service.Services.Base;

namespace Wirtualnik.Service.Services
{
    public class ImportService : ServiceBase, IImportService
    {
        public ImportService(WirtualnikDbContext context, IMapper mapper) : base(context, mapper)
        { }

        public async Task XlsxImport(IFormFile file, string productTypeId)
        {
            using (var fileStream = file.OpenReadStream())
            {
                var hssfwb = new XSSFWorkbook(fileStream);
                var sheet = hssfwb.GetSheetAt(0);
                var headers = GetXlsxHeaders(sheet);
                var productType = await Context.Categories
                    .Include(t => t.CategoryProperties)
                    .FirstOrDefaultAsync(t => t.PublicId == productTypeId) ??
                    await CreateCategory(productTypeId, headers); // Creating categories from excel only for tests
                
                ValidateHeaders(headers, productType);

                var prodType = typeof(Product);

                for (int rowNum = 1; rowNum <= sheet.LastRowNum; rowNum++)
                {
                    var row = sheet.GetRow(rowNum);
                    Product product = new Product();
                    product.ProductProperties = new List<ProductProperty>();

                    foreach (var header in headers)
                    {
                        if (row.GetCell(header.Item1) is null)
                        {
                            break;
                        }

                        var prodMainProp = prodType.GetProperties().FirstOrDefault(p => p.Name == header.Item2);

                        if (prodMainProp == null)
                        {
                            var propType = productType.CategoryProperties.Single(p => p.Name == header.Item2 && p.Description == header.Item3);

                            product.ProductProperties.Add(new ProductProperty
                            {
                                CreateDate = DateTime.Now,
                                CategoryProperty = propType,
                                Value = row.GetCell(header.Item1).GetStringValue()
                            });
                        }
                        else
                        {
                            prodMainProp.SetValue(product, row.GetCell(header.Item1).GetStringValue());
                        }
                    }

                    product.Archived = false;
                    product.Category = productType;

                    if (!string.IsNullOrEmpty(product.PublicId) && !(await Context.Products.AnyAsync(p => p.PublicId == product.PublicId)))
                    {
                        await CreateAsync(product);
                    }
                }
            }
        }

        private void ValidateHeaders(List<(int, string, string)> headers, Category productType)
        {
            foreach (var header in headers)
            {
                var match = productType.CategoryProperties.Any(p => p.Name == header.Item2);
                if (!match)
                {
                    match = typeof(Product).GetProperties().Any(p => p.Name == header.Item2);
                    if (!match)
                        throw new ValidationException($"Unknown property: {header}");
                }
            }
        }

        private List<(int, string, string)> GetXlsxHeaders(ISheet sheet)
        {
            var result = new List<(int, string, string)>();

            var headerRow = sheet.GetRow(0);
            var descriptionRow = sheet.GetRow(1);

            foreach (var headerCell in headerRow.Cells)
            {
                result.Add((headerCell.ColumnIndex, headerCell.StringCellValue, descriptionRow.GetCell(headerCell.ColumnIndex)?.GetStringValue() ?? ""));
            }

            return result;
        }

        public async Task<Category> CreateCategory(string productTypeId, List<(int, string, string)> headers)
        {
            var newProps = headers.Where(h => !typeof(Product).GetProperties().Any(p => p.Name == h.Item2)).Select(h => new CategoryProperty
            {
                CreateDate = DateTime.Now,
                Name = h.Item2,
                Description = h.Item3,
                ShowInCart = true,
                ShowInCell = h.Item1 < 11,
                ShowInFilter = true
            }).ToList();

            Category productType = new Category
            {
                CreateDate = DateTime.Now,
                Name = productTypeId,
                PublicId = productTypeId,
                CategoryProperties = newProps
            };

            return await CreateAsync(productType);
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
                _ => "",
            };
        }
    }
}
