using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Server.Interfaces;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Processor;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/processor")]
    public class ProcessorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProcessorService _processorService;
        public ProcessorController(IProcessorService processorService, IMapper mapper)
        {
            _processorService = processorService;
            _mapper = mapper;
        }


        [HttpGet("search")]
        public async Task<ActionResult<Pagination<Resource<ListItemModel>>>> Search()
        {
            var list = _mapper.Map<List<ListItemModel>>(await _processorService.GetProcessorsAsync()).ConvertAll(p => TResource.FromT(p));

            return TPagination.FromT(list, 20);
        }

        [HttpGet]
        public async Task<ActionResult<Resource<DetailsModel>>> Fetch(long id)
        {
            var processor = await _processorService.FindAsync<Processor>(id);
            return TResource.FromT(_mapper.Map<DetailsModel>(processor));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateModel model)
        {
            var contract = await _processorService.CreateAsync(model);
            return CreatedAtAction(nameof(ProcessorController.Fetch), "Processor", new { Id = contract.Id }, _mapper.Map<DetailsModel>(contract));
        }
    }
}