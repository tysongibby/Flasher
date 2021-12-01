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
        public ActionResult<Flashcard> Get(int id)
        {
            FlashCardModel flashcard = _flashCardRepository.GetAsync(id).Result;
            Flashcard flashCardDto = new Flashcard();            
            if (flashcard is not null && flashcard.Id != 0)
            {            
                flashCardDto.Id = flashcard.Id;
                flashCardDto.Title = flashcard.Title;
                flashCardDto.Front = flashcard.Front;
                flashCardDto.Back = flashcard.Back;
                flashCardDto.AnsweredCorrectly = flashcard.AnsweredCorrectly;
                flashCardDto.SupersetId = flashcard.SupersetId;
                flashCardDto.SetId = flashcard.SetId;
                return StatusCode(StatusCodes.Status200OK, flashCardDto);
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }            
        }

        [HttpGet]
        public ActionResult<IEnumerable<Flashcard>> GetAll()
        {
            List<FlashCardModel> flashCards = _flashCardRepository.GetAllAsync().Result.ToList();
            List<Flashcard> flashCardDtos = new List<Flashcard>();
            if (flashCards is not null)
            {


                foreach (FlashCardModel fc in flashCards)
                {
                    Flashcard flashCardDto = new Flashcard()
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
        public ActionResult<List<Flashcard>> GetAllFlashCardsInSuperset(int id)
        {
            List<Flashcard> flashCardDtos = new List<Flashcard>();
            List<FlashCardModel> flashCards = _flashCardRepository.GetAllFlashCardsInSuperset(id).ToList();            
            if (flashCards is not null && flashCards.Count > 0)
            {
                foreach (FlashCardModel fc in flashCards)
                {                    
                    Flashcard flashCardDto = new Flashcard()
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
        public ActionResult<List<Flashcard>> GetAllFlashCardsInSet(int setId)
        {
            List<Flashcard> flashCardDtos = new List<Flashcard>();
            List<FlashCardModel> flashCards = _flashCardRepository.GetAllFlashCardsInSet(setId).ToList();
            
            if (flashCards is not null && flashCards.Count > 0)
            {
                foreach (FlashCardModel fc in flashCards)
                {
                    Flashcard flashCardDto = new Flashcard()
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
        public ActionResult<string> Create(Flashcard flashCardDto)
        {
            try
            {
                FlashCardModel newFlashCard = new FlashCardModel()
                {
                    Title = flashCardDto.Title,
                    Front = flashCardDto.Front,
                    Back = flashCardDto.Back,
                    AnsweredCorrectly = false,
                    SupersetId = flashCardDto.SupersetId,
                    SetId = flashCardDto.SetId
                };
                _flashCardRepository.AddAsync(newFlashCard);
                return StatusCode(StatusCodes.Status201Created, "new flash card URL placeholder");  //TODO: add url for new Flashcard to return status
            }
            catch (Exception e)
            {                
                return StatusCode(StatusCodes.Status400BadRequest, e);
            }
        }

        [HttpPost]
        public ActionResult<string> Update(Flashcard flashCardDto)
        {
            try
            {
                    if (_flashCardRepository.ExistsAsync((int)flashCardDto.Id).Result)
                    {

                        FlashCardModel newFlashCard = new FlashCardModel()
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
                        return StatusCode(StatusCodes.Status200OK, ""); //TODO: replace update message with url for updated Flashcard

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
                FlashCardModel flashCardToDelete = _flashCardRepository.Where(fc => fc.Id == id).FirstOrDefault();
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
