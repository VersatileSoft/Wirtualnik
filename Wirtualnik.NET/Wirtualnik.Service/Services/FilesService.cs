using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Service.Extensions;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Service.Services.Base;

namespace Wirtualnik.Service.Services
{
    public class FilesService : ServiceBase, IFilesService
    {
        private readonly IHostingEnvironment _environment;
        public FilesService(WirtualnikDbContext context, IMapper mapper, IHostingEnvironment environment) : base(context, mapper)
        {
            _environment = environment;
        }

        public async Task SaveImages(List<IFormFile> images, string publicId)
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

                    var product = Context.Products.Where(p => p.PublicId == publicId).FirstOrDefault();

                    var id = product.Id;

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
    }
}
