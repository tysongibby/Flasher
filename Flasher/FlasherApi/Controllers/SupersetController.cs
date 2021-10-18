using FlasherApi.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SupersetController : ControllerBase
    {
        private readonly ILogger<SupersetController> _logger;
        private readonly ISupersetRepository _superSetRepository;

        public SupersetController(ILogger<SupersetController> logger, ISupersetRepository superSetRepository)
        {
            _logger = logger;
            _superSetRepository = superSetRepository;
        }
    }
}
