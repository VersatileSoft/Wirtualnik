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

namespace Wirtualnik.Service.Services
{
    public class FilesService : ServiceBase, IFilesService
    {
        private readonly IHostingEnvironment _environment;
        private HttpContext? _context;
        public FilesService(WirtualnikDbContext context, IMapper mapper, IHostingEnvironment environment, IHttpContextAccessor accessor) : base(context, mapper)
        {
            _environment = environment;
            _context = accessor.HttpContext;
        }

        public async Task<IEnumerable<Image>> SaveImages(List<IFormFile> images)
        {
            var result = new List<Image>();

            foreach (var formFile in images)
            {
                var name = formFile.FileName;
                var nameAndExt = name.Split(".");
                name = nameAndExt[0];

                if (formFile.Length > 0)
                {
                    var (width, height) = formFile.GetImageSizeFromFile();

                    var fileName = $"{Guid.NewGuid()}.{nameAndExt[1]}";
                    var filePath = Path.Combine(_environment.WebRootPath, "static", "img", fileName);

                    var dir = Path.GetDirectoryName(filePath);
                    if (dir is null) throw new Exception();
                    Directory.CreateDirectory(dir);

                    result.Add(await CreateAsync(new Data.Models.Image
                    {
                        FileName = fileName,
                        Width = width,
                        Height = height,
                        Main = formFile.FileName.Trim().Contains("main", StringComparison.OrdinalIgnoreCase)
                    }));

                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(fileStream);
                    }
                }
            }
            return result;
        }

        public async Task<IEnumerable<Image>> GetImages(List<int> images)
        {
            return await Context.Images.Where(i => images.Contains(i.Id)).ToListAsync();
        }
        public async Task<Image> GetImage(int imageId)
        {
            return await Context.Images.Where(i => i.Id == imageId).FirstOrDefaultAsync();
        }

        public string GetImageLink(string fileName)
        {
            return _context?.Request?.Scheme + "://" + Path.Combine(_context?.Request?.Host.Value ?? "", "static", "img", fileName);
        }

        public async Task<string> GetImageLink(int imageId)
        {
            return GetImageLink((await GetImage(imageId)).FileName);
        }
    }
}