using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Files;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/files")]
    [Authorize(Roles = "Admin")]
    public class FilesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFilesService _filesService;
        public FilesController(IFilesService productService, IMapper mapper)
        {
            _filesService = productService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> Fetch(int id)
        {
            var result = await _filesService.FindAsync<Image>(id);

            if (result == null)
                return NotFound();

            return Ok(_mapper.Map<ImageModel>(result));
        }

        [HttpGet("{ids}")]
        public async Task<ActionResult<Image>> FetchMany(List<int> ids)
        {
            var result = new List<Image>();

            foreach (var id in ids)
            {
                var image = await _filesService.FindAsync<Image>(id);
                if (image == null)
                    return NotFound(id);

                result.Add(image);
            }

            return Ok(_mapper.Map<List<ImageModel>>(result));
        }

        [DisableRequestSizeLimit]
        [HttpPost]
        public async Task<ActionResult> Create([FromForm] List<IFormFile> images)
        {
            var result = await _filesService.SaveImages(images.ToList());
            return CreatedAtAction(nameof(FilesController.FetchMany), "files", new { ids = result.Select(i => i.Id).ToList() }, _mapper.Map<List<ImageModel>>(result));
        }
    }
}