using Microsoft.AspNetCore.Mvc;
using Wirtualnik.Server.Controllers.Base;
using Wirtualnik.Server.Interfaces;
using Wirtualnik.Shared;
using Wirtualnik.Shared.Models;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route(ProcessorPaths.Name)]
    public class ProcessorController : AbstractControllerBase<ProcessorModel>
    {
        private readonly IProcessorService _processorService;
        public ProcessorController(IProcessorService processorService) : base(processorService)
        {
            _processorService = processorService;
        }
    }
}