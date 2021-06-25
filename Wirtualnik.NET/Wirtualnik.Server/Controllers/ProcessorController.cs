using Microsoft.AspNetCore.Mvc;
using Wirtualnik.Server.Controllers.Base;
using Wirtualnik.Server.Interfaces;
using Wirtualnik.Shared;
using Wirtualnik.Shared.Models;
using System.Threading.Tasks;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/processor")]
    public class ProcessorController : AbstractControllerBase<ProcessorModel>
    {
        private readonly IProcessorService _processorService;
        public ProcessorController(IProcessorService processorService) : base(processorService)
        {
            _processorService = processorService;
        }

        [HttpGet("Test")]
        public Task<string> Test()
        {
            return Task.FromResult("Siemanko");
        }
    }
}