using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Interfaces;
using Wirtualnik.Shared.Models.Processor;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/processor")]
    public class ProcessorController : ProductController<Processor, FilterModel, ListItemModel, DetailsModel, CreateModel>
    {
        public ProcessorController(IProcessorService productService, IMapper mapper) : base(productService, mapper)
        {
        }
    }
}