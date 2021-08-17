using Flasher.Server.Data.Repositories.Interfaces;
using Flasher.Shared;
using Flasher.Shared.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flasher.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlashCardController : ControllerBase
    {
        private readonly ILogger<FlashCardController> _logger;
        private readonly IFlashCardRepository _flashCardRepository;

        public FlashCardController(ILogger<FlashCardController> logger, IFlashCardRepository flashCardRepository)
        {
            _logger = logger;
            _flashCardRepository = flashCardRepository;
        }

        [HttpGet]
        public ActionResult<FlashCard> Get(int id)
        {
            var flashCardItem = _flashCardRepository.Get(id);
            return Ok(flashCardItem);
        }

        [HttpGet]
        public ActionResult<IEnumerable<FlashCard>> GetAll()
        {
            var flashCardItems = _flashCardRepository.GetAll();
            return Ok(flashCardItems);
        }



    }

}
