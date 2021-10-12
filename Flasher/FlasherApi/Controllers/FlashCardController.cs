using Flasher.Server.Data.Repositories.Interfaces;
using FlasherApi.Data.Dtos;
using FlasherApi.Data.Models;
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
            FlashCard flashCard = _flashCardRepository.Get(id).Result;
            return Ok(flashCard);
        }

        [HttpGet]
        public ActionResult<IEnumerable<FlashCard>> GetAll()
        {
            List<FlashCard> flashCards = _flashCardRepository.GetAll().Result.ToList();
            return Ok(flashCards);
        }

        [HttpPost]
        public ActionResult<FlashCardDto> Create(FlashCardDto flashCardDto)
        {            
            try
            {
                FlashCard newFlashCard = new FlashCard()
                {
                    Title = flashCardDto.Title,
                    Front = flashCardDto.Front,
                    Back = flashCardDto.Back,
                    AnsweredCorrectly = false
                };
                _flashCardRepository.Add(newFlashCard);
                return Ok(flashCardDto);
            }
            catch (Exception e)
            {                
                throw new Exception("Flash card was not created: ", e);
            }
        }

        [HttpPost]
        public ActionResult<FlashCardDto> Update(int flashCardId, FlashCardDto flashCardDto)
        {
            if (_flashCardRepository.Exists(flashCardId).Result)
            {
                try
                {
                    FlashCard newFlashCard = new FlashCard()
                    {
                        Id = flashCardId,
                        Title = flashCardDto.Title,
                        Front = flashCardDto.Front,
                        Back = flashCardDto.Back,
                        AnsweredCorrectly = false
                    };
                    FlashCard updatedFlashCard = _flashCardRepository.Update(newFlashCard).Result;
                    return Ok(updatedFlashCard);                    
                }
                catch (Exception e)
                {
                    throw new Exception("Flash card was not updated: ", e);
                }
            }            
            else return NotFound($"Flash card {flashCardId} not found.");
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
