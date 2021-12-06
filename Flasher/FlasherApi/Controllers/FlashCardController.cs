using FlasherData.Repositories.Interfaces;
using FlasherApi.Data.Dtos;
using FlasherData.DataModels;
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
        private readonly IFlashCardDmRepository _flashCardRepository;

        public FlashCardController(ILogger<FlashCardController> logger, IFlashCardDmRepository flashCardRepository)
        {
            _logger = logger;
            _flashCardRepository = flashCardRepository;
        }

        [HttpGet]
        public ActionResult<Flashcard> Get(int id)
        {
            FlashCardDm flashcardDm = _flashCardRepository.GetAsync(id).Result;
            Flashcard flashCardDto = new Flashcard();            
            if (flashcardDm is not null && flashcardDm.Id != 0)
            {            
                flashCardDto.Id = flashcardDm.Id;
                flashCardDto.Title = flashcardDm.Title;
                flashCardDto.Front = flashcardDm.Front;
                flashCardDto.Back = flashcardDm.Back;
                flashCardDto.AnsweredCorrectly = flashcardDm.AnsweredCorrectly;
                flashCardDto.SubjectId = flashcardDm.SubjectDmId;
                flashCardDto.CategoryId = flashcardDm.CategoryDmId;
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
            List<FlashCardDm> flashCardDms = _flashCardRepository.GetAllAsync().Result.ToList();
            List<Flashcard> flashCardDtos = new List<Flashcard>();
            if (flashCardDms is not null)
            {


                foreach (FlashCardDm fc in flashCardDms)
                {
                    Flashcard flashCardDto = new Flashcard()
                    {
                        Id = fc.Id,
                        Title = fc.Title,
                        Front = fc.Front,
                        Back = fc.Back,
                        AnsweredCorrectly = fc.AnsweredCorrectly,
                        SubjectId = fc.SubjectDmId,
                        CategoryId = fc.CategoryDmId
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
        public ActionResult<List<Flashcard>> GetAllFlashCardsForSubject(int id)
        {
            List<Flashcard> flashCardDtos = new List<Flashcard>();
            List<FlashCardDm> flashCards = _flashCardRepository.GetAllFlashCardsForSubjectDm(id).ToList();            
            if (flashCards is not null && flashCards.Count > 0)
            {
                foreach (FlashCardDm fc in flashCards)
                {                    
                    Flashcard flashCardDto = new Flashcard()
                    {
                        Id = fc.Id,
                        Title = fc.Title,
                        Front = fc.Front,
                        Back = fc.Back,
                        AnsweredCorrectly = fc.AnsweredCorrectly,
                        SubjectId = fc.SubjectDmId,
                        CategoryId = fc.CategoryDmId
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
        public ActionResult<List<Flashcard>> GetAllFlashCardsInCategory(int categoryId)
        {
            List<Flashcard> flashCardDtos = new List<Flashcard>();
            List<FlashCardDm> flashCardDms = _flashCardRepository.GetAllFlashCardsForCategoryDm(categoryId).ToList();
            
            if (flashCardDms is not null && flashCardDms.Count > 0)
            {
                foreach (FlashCardDm fc in flashCardDms)
                {
                    Flashcard flashCardDto = new Flashcard()
                    {
                        Id = fc.Id,
                        Title = fc.Title,
                        Front = fc.Front,
                        Back = fc.Back,
                        AnsweredCorrectly = fc.AnsweredCorrectly,
                        SubjectId = fc.SubjectDmId,
                        CategoryId = fc.CategoryDmId
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
                FlashCardDm newFlashCardDm = new FlashCardDm()
                {
                    Title = flashCardDto.Title,
                    Front = flashCardDto.Front,
                    Back = flashCardDto.Back,
                    AnsweredCorrectly = false,
                    SubjectDmId = flashCardDto.SubjectId,
                    CategoryDmId = flashCardDto.CategoryId
                };
                _flashCardRepository.AddAsync(newFlashCardDm);
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

                        FlashCardDm newFlashCardDm = new FlashCardDm()
                        {
                            Id = (int)flashCardDto.Id,
                            Title = flashCardDto.Title,
                            Front = flashCardDto.Front,
                            Back = flashCardDto.Back,
                            AnsweredCorrectly = flashCardDto.AnsweredCorrectly,
                            SubjectDmId = flashCardDto.SubjectId,
                            CategoryDmId = flashCardDto.CategoryId
                        };
                        int pk = _flashCardRepository.Update(newFlashCardDm);
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
                FlashCardDm flashCardDmToDelete = _flashCardRepository.Where(fc => fc.Id == id).FirstOrDefault();
                if (flashCardDmToDelete is not null)
                {
                    _flashCardRepository.Remove(flashCardDmToDelete);
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
