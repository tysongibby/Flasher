using FlasherData.Repositories.Interfaces;
using FlasherApi.Data.Dtos;
using FlasherData.Models;
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
        public ActionResult<FlashCardDto> Get(int id)
        {
            FlashCard flashCard = _flashCardRepository.GetAsync(id).Result;
            FlashCardDto flashCardDto = new FlashCardDto();            
            if (flashCard is not null && flashCard.Id != 0)
            {            
                flashCardDto.Id = flashCard.Id;
                flashCardDto.Title = flashCard.Title;
                flashCardDto.Front = flashCard.Front;
                flashCardDto.Back = flashCard.Back;
                flashCardDto.AnsweredCorrectly = flashCard.AnsweredCorrectly;
                flashCardDto.SupersetId = flashCard.SupersetId;
                flashCardDto.SetId = flashCard.SetId;
                return StatusCode(StatusCodes.Status200OK, flashCardDto);
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }            
        }

        [HttpGet]
        public ActionResult<IEnumerable<FlashCardDto>> GetAll()
        {
            List<FlashCard> flashCards = _flashCardRepository.GetAllAsync().Result.ToList();
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

                return StatusCode(StatusCodes.Status200OK, flashCardDtos);
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
            if (flashCards is not null && flashCards.Count > 0)
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

                return StatusCode(StatusCodes.Status200OK, flashCardDtos);
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        [HttpGet]
        public ActionResult<List<FlashCardDto>> GetAllFlashCardsInSet(int setId)
        {
            List<FlashCardDto> flashCardDtos = new List<FlashCardDto>();
            List<FlashCard> flashCards = _flashCardRepository.GetAllFlashCardsInSet(setId).ToList();
            
            if (flashCards is not null && flashCards.Count > 0)
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

                return StatusCode(StatusCodes.Status200OK, flashCardDtos);
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        [HttpPost]
        public ActionResult<string> Create(FlashCardDto flashCardDto)
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
                _flashCardRepository.AddAsync(newFlashCard);
                return StatusCode(StatusCodes.Status201Created, "new flash card URL placeholder");  //TODO: add url for new FlashCard to return status
            }
            catch (Exception e)
            {                
                return StatusCode(StatusCodes.Status400BadRequest, e);
            }
        }

        [HttpPost]
        public ActionResult<string> Update(FlashCardDto flashCardDto)
        {
            try
            {
                    if (_flashCardRepository.ExistsAsync((int)flashCardDto.Id).Result)
                    {

                        FlashCard newFlashCard = new FlashCard()
                        {
                            Id = (int)flashCardDto.Id,
                            Title = flashCardDto.Title,
                            Front = flashCardDto.Front,
                            Back = flashCardDto.Back,
                            AnsweredCorrectly = flashCardDto.AnsweredCorrectly,
                            SupersetId = flashCardDto.SupersetId,
                            SetId = flashCardDto.SetId
                        };
                        int pk = _flashCardRepository.Update(newFlashCard);
                        return StatusCode(StatusCodes.Status200OK, ""); //TODO: replace update message with url for updated FlashCard

                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status204NoContent, $"Flash card {flashCardDto.Id} could not be found.");
                    }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                FlashCard flashCardToDelete = _flashCardRepository.Where(fc => fc.Id == id).FirstOrDefault();
                if (flashCardToDelete is not null)
                {
                    _flashCardRepository.Remove(flashCardToDelete);
                    return StatusCode(StatusCodes.Status200OK, $"Flash card {id} was deleted.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"Flash card {id} could not be found.");
                }
            }
            catch (Exception e)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }

}
