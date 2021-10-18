using FlasherApi.Data.Repositories.Interfaces;
using FlasherApi.Data.Dtos;
using FlasherApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace FlasherApi.Controllers
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
            FlashCardDto flashCardDto = new FlashCardDto();            
            if (flashCard is not null)
            {            
                flashCardDto.Id = flashCard.Id;
                flashCardDto.Title = flashCard.Title;
                flashCardDto.Front = flashCard.Front;
                flashCardDto.Back = flashCard.Back;
                flashCardDto.AnsweredCorrectly = flashCard.AnsweredCorrectly;
                flashCardDto.SupersetId = flashCard.SupersetId;
                flashCardDto.SetId = flashCard.SetId;
                return Ok(flashCardDto);
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent, $"FlashCardDto id {id} not found.");
            }            
        }

        [HttpGet]
        public ActionResult<IEnumerable<FlashCardDto>> GetAll()
        {
            List<FlashCard> flashCards = _flashCardRepository.GetAll().Result.ToList();
            List<FlashCardDto> flashCardDtos = new List<FlashCardDto>();
            if (flashCards is not null)
            {


                foreach (FlashCard fc in flashCards)
                {
                    FlashCardDto flashCardDto = new FlashCardDto()
                    {
                        Id = fc.Id,
                        Title = fc.Title,
                        Front = fc.Front,
                        Back = fc.Back,
                        AnsweredCorrectly = fc.AnsweredCorrectly,
                        SupersetId = fc.SupersetId,
                        SetId = fc.SetId
                    };
                    flashCardDtos.Add(flashCardDto);
                }

                return Ok(flashCardDtos);
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent, "No flash cards have been created yet.");
            }
        }

        [HttpGet]
        public ActionResult<List<FlashCardDto>> GetAllFlashCardsInSuperset(int id)
        {
            List<FlashCardDto> flashCardDtos = new List<FlashCardDto>();
            List<FlashCard> flashCards = _flashCardRepository.GetAllFlashCardsInSuperset(id).ToList();            
            if (flashCards is not null)
            {
                foreach (FlashCard fc in flashCards)
                {                    
                    FlashCardDto flashCardDto = new FlashCardDto()
                    {
                        Id = fc.Id,
                        Title = fc.Title,
                        Front = fc.Front,
                        Back = fc.Back,
                        AnsweredCorrectly = fc.AnsweredCorrectly,
                        SupersetId = fc.SupersetId,
                        SetId = fc.SetId
                    };
                    flashCardDtos.Add(flashCardDto);
                }

                return flashCardDtos;
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent, $"Flash card superset {id} could not be found.");
            }
        }

        [HttpGet]
        public ActionResult<List<FlashCardDto>> GetAllFlashCardsInSet(int setId)
        {
            List<FlashCardDto> flashCardDtos = new List<FlashCardDto>();
            List<FlashCard> flashCards = _flashCardRepository.GetAllFlashCardsInSet(setId).ToList();
            
            if (flashCards is not null)
            {
                foreach (FlashCard fc in flashCards)
                {
                    FlashCardDto flashCardDto = new FlashCardDto()
                    {
                        Id = fc.Id,
                        Title = fc.Title,
                        Front = fc.Front,
                        Back = fc.Back,
                        AnsweredCorrectly = fc.AnsweredCorrectly,
                        SupersetId = fc.SupersetId,
                        SetId = fc.SetId
                    };
                    flashCardDtos.Add(flashCardDto);
                }

                return flashCardDtos;
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent, $"Flash card set {setId} could not be found.");
            }
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
                    AnsweredCorrectly = false,
                    SupersetId = flashCardDto.SupersetId,
                    SetId = flashCardDto.SetId
                };
                _flashCardRepository.Add(newFlashCard);
                return StatusCode(StatusCodes.Status201Created, flashCardDto);
            }
            catch (Exception e)
            {
                throw new Exception($"Flash card {flashCardDto.Title} was not created: ", e);
            }
        }

        [HttpPost]
        public ActionResult<FlashCardDto> Update(int Id, FlashCardDto flashCardDto)
        {
            if (_flashCardRepository.Exists(Id).Result)
            {
                try
                {
                    FlashCard newFlashCard = new FlashCard()
                    {
                        Id = Id,
                        Title = flashCardDto.Title,
                        Front = flashCardDto.Front,
                        Back = flashCardDto.Back,
                        AnsweredCorrectly = false,
                        SupersetId = flashCardDto.SupersetId,
                        SetId = flashCardDto.SetId
                    };
                    FlashCard updatedFlashCard = _flashCardRepository.Update(newFlashCard).Result;
                    return Ok(updatedFlashCard);
                }
                catch (Exception e)
                {
                    throw new Exception("Flash card was not updated: ", e);
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent, $"Flash card id {Id} could not be found.");
            }
        }

        [HttpPost]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                FlashCard flashCardToDelete = _flashCardRepository.Find(fc => fc.Id == id).FirstOrDefault();
                if (flashCardToDelete is not null)
                {
                    _flashCardRepository.Remove(flashCardToDelete);
                    return Ok($"Flash card {id} has been deleted.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"Flash card id {id} could not be found.");
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Flash card {id} was not deleted: ", e);
            }
        }

    }

}
