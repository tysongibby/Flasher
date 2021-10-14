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
        public ActionResult<FlashCardDto> Get(int id = 1)
        {
            FlashCard flashCard = _flashCardRepository.Get(id).Result;

            FlashCardSetDto flashCardSetDto = new FlashCardSetDto();
            if (flashCard.FlashCardSet is not null)
            {
                FlashCardSetDto superFlashCardSetDto = new FlashCardSetDto();
                if (flashCard.FlashCardSet.FlashCardSuperset is not null)
                {
                    superFlashCardSetDto.Id = flashCard.FlashCardSet.FlashCardSuperset.Id;
                    superFlashCardSetDto.Title = flashCard.FlashCardSet.FlashCardSuperset.Title;
                }
                flashCardSetDto.Id = flashCard.FlashCardSet.Id;
                flashCardSetDto.Title = flashCard.FlashCardSet.Title;
                flashCardSetDto.FlashCardSupersetDto = superFlashCardSetDto;
            }
            FlashCardDto flashCardDto = new FlashCardDto()
            {
                Id = flashCard.Id,
                Title = flashCard.Title,
                Front = flashCard.Front,
                Back = flashCard.Back,
                AnsweredCorrectly = flashCard.AnsweredCorrectly,
                FlashCardSetDto = flashCardSetDto
            };
            return Ok(flashCardDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<FlashCardDto>> GetAll()
        {
            List<FlashCard> flashCards = _flashCardRepository.GetAll().Result.ToList();
            
            List<FlashCardDto> flashCardDtos = new List<FlashCardDto>();
            foreach (FlashCard fc in flashCards) 
            {
                FlashCardSetDto flashCardSetDto = new FlashCardSetDto();
                if (fc.FlashCardSet is not null)
                {
                    FlashCardSetDto superFlashCardSetDto = new FlashCardSetDto();
                    if (fc.FlashCardSet.FlashCardSuperset is not null)
                    {
                        superFlashCardSetDto.Id = fc.FlashCardSet.FlashCardSuperset.Id;
                        superFlashCardSetDto.Title = fc.FlashCardSet.FlashCardSuperset.Title;                        
                    }
                    flashCardSetDto.Id = fc.FlashCardSet.Id;
                    flashCardSetDto.Title = fc.FlashCardSet.Title;
                    flashCardSetDto.FlashCardSupersetDto = superFlashCardSetDto;                    
                }
                FlashCardDto flashCardDto = new FlashCardDto()
                {
                    Id = fc.Id,
                    Title = fc.Title,
                    Front = fc.Front,
                    Back = fc.Back,
                    AnsweredCorrectly = fc.AnsweredCorrectly,
                    FlashCardSetDto = flashCardSetDto

                };
                flashCardDtos.Add(flashCardDto);
            }

            return Ok(flashCardDtos);
        }

        [HttpPost]
        public ActionResult<FlashCardDto> Create(FlashCardDto flashCardDto)
        {            
            try
            {
                FlashCardSet _flashCardSuperSet = new FlashCardSet();
                FlashCardSet _flashCardSet = new FlashCardSet();
                if (flashCardDto.FlashCardSetDto is not null)
                {
                    if (flashCardDto.FlashCardSetDto.FlashCardSupersetDto is not null)
                    {
                        _flashCardSuperSet.Id = (int)flashCardDto.FlashCardSetDto.FlashCardSupersetDto.Id;
                        _flashCardSuperSet.Title = flashCardDto.FlashCardSetDto.FlashCardSupersetDto.Title;
                    }
                    _flashCardSet.Id = (int)flashCardDto.Id;
                    _flashCardSet.Title = flashCardDto.FlashCardSetDto.Title;
                    _flashCardSet.FlashCardSuperset = _flashCardSuperSet;
                }
                FlashCard newFlashCard = new FlashCard()
                {
                    Title = flashCardDto.Title,
                    Front = flashCardDto.Front,
                    Back = flashCardDto.Back,
                    AnsweredCorrectly = false,
                    FlashCardSet = _flashCardSet
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
                    FlashCardSet _flashCardSuperSet = new FlashCardSet();
                    FlashCardSet _flashCardSet = new FlashCardSet();                    
                    if (flashCardDto.FlashCardSetDto is not null)
                    {
                        if (flashCardDto.FlashCardSetDto.FlashCardSupersetDto is not null)
                        {
                            _flashCardSuperSet.Id = (int)flashCardDto.FlashCardSetDto.FlashCardSupersetDto.Id;
                            _flashCardSuperSet.Title = flashCardDto.FlashCardSetDto.FlashCardSupersetDto.Title;
                        }
                        _flashCardSet.Id = (int)flashCardDto.Id;
                        _flashCardSet.Title = flashCardDto.FlashCardSetDto.Title;
                        _flashCardSet.FlashCardSuperset = _flashCardSuperSet;
                    }
                    FlashCard newFlashCard = new FlashCard()
                    {
                        Id = flashCardId,
                        Title = flashCardDto.Title,
                        Front = flashCardDto.Front,
                        Back = flashCardDto.Back,
                        AnsweredCorrectly = false,
                        FlashCardSet = _flashCardSet
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
