using Flasher.Server.Data.Repositories.Interfaces;
using FlasherShared;
using FlasherShared.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flasher.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
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
        public ActionResult<FlashCard> Get(int id = 1)
        {
            FlashCard flashCardItem = _flashCardRepository.Get(id).Result;
            return Ok(flashCardItem);
        }

        [HttpGet]
        public ActionResult<IEnumerable<FlashCard>> GetAll()
        {
            List<FlashCard> flashCardItems = _flashCardRepository.GetAll().Result.ToList();
            return Ok(flashCardItems);
        }

        [HttpPost]
        public ActionResult<FlashCard> Create(FlashCard flashCardToCreate)
        {            
            try
            {
                _flashCardRepository.Add(flashCardToCreate);
                return Ok(flashCardToCreate);
            }
            catch (Exception e)
            {
                throw new Exception("Flash card was not created: ", e);
            }
        }

        [HttpPost]
        public ActionResult<FlashCard> Update(FlashCard flashCardToUpdate)
        {            
            try
            {         
                FlashCard updatedFlashCard = _flashCardRepository.Update(flashCardToUpdate).Result;
                return Ok(updatedFlashCard);
            }
            catch (Exception e)
            {
                throw new Exception("Flash card was not updated: ", e);
            }
        }

        [HttpPost]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                FlashCard flashCardToDelete = _flashCardRepository.Find(fc => fc.Id == id).FirstOrDefault();                
                if (flashCardToDelete != null)
                {
                    _flashCardRepository.Remove(flashCardToDelete);
                    return Ok($"Flash card {id} has been deleted.");
                }
                else return NotFound($"Flash card {id} was not found so could not be deleted.");
            }
            catch (Exception e)
            {
                throw new Exception($"Flash card {id} was not deleted: ", e);
            }
        }


    }

}
