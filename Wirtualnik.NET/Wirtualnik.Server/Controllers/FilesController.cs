using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Server.Controllers
{

    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFilesService _filesService;
        public FilesController(IFilesService productService, IMapper mapper)
        {
            _filesService = productService;
            _mapper = mapper;
        }

        [DisableRequestSizeLimit]
        [HttpPost("{publicId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(string publicId, [FromForm] List<IFormFile> images)
        {
            await _filesService.SaveImages(images.ToList(), publicId);
            return CreatedAtAction(nameof(ProductController.Fetch), "product", new { publicId = publicId }, new DetailsModel());
        }
    }
}