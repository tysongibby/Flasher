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
    public class FlashcardController : ControllerBase
    {
        private readonly ILogger<FlashcardController> _logger;
        private readonly IFlashcardDmRepository _flashcardRepository;

        public FlashcardController(ILogger<FlashcardController> logger, IFlashcardDmRepository flashcardRepository)
        {
            _logger = logger;
            _flashcardRepository = flashcardRepository;
        }

        [HttpGet]
        public ActionResult<Flashcard> Get(int id)
        {
            FlashcardDm flashcardDm = _flashcardRepository.GetAsync(id).Result;
            Flashcard flashcardDto = new Flashcard();            
            if (flashcardDm is not null && flashcardDm.Id != 0)
            {            
                flashcardDto.Id = flashcardDm.Id;
                flashcardDto.Title = flashcardDm.Name;
                flashcardDto.Front = flashcardDm.Front;
                flashcardDto.Back = flashcardDm.Back;
                flashcardDto.AnsweredCorrectly = flashcardDm.AnsweredCorrectly;                
                flashcardDto.CategoryId = flashcardDm.CategoryId;
                return StatusCode(StatusCodes.Status200OK, flashcardDto);
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }            
        }

        [HttpGet]
        public ActionResult<IEnumerable<Flashcard>> GetAll()
        {
            List<FlashcardDm> flashcardDms = _flashcardRepository.GetAllAsync().Result.ToList();
            List<Flashcard> flashcardDtos = new List<Flashcard>();
            if (flashcardDms is not null)
            {


                foreach (FlashcardDm fc in flashcardDms)
                {
                    Flashcard flashcardDto = new Flashcard()
                    {
                        Id = fc.Id,
                        Title = fc.Name,
                        Front = fc.Front,
                        Back = fc.Back,
                        AnsweredCorrectly = fc.AnsweredCorrectly,                        
                        CategoryId = fc.CategoryId
                    };
                    flashcardDtos.Add(flashcardDto);
                }

                return StatusCode(StatusCodes.Status200OK, flashcardDtos);
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent, "No flashcards have been created yet.");
            }
        }

        [HttpGet]
        public ActionResult<List<Flashcard>> GetAllFlashcardsForSubject(int id)
        {
            List<Flashcard> flashcardDtos = new List<Flashcard>();
            List<FlashcardDm> flashcards = _flashcardRepository.GetAllFlashcardsForSubjectDm(id).ToList();            
            if (flashcards is not null && flashcards.Count > 0)
            {
                foreach (FlashcardDm fc in flashcards)
                {                    
                    Flashcard flashcardDto = new Flashcard()
                    {
                        Id = fc.Id,
                        Title = fc.Name,
                        Front = fc.Front,
                        Back = fc.Back,
                        AnsweredCorrectly = fc.AnsweredCorrectly,                        
                        CategoryId = fc.CategoryId
                    };
                    flashcardDtos.Add(flashcardDto);
                }

                return StatusCode(StatusCodes.Status200OK, flashcardDtos);
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        [HttpGet]
        public ActionResult<List<Flashcard>> GetAllFlashcardsInCategory(int categoryId)
        {
            List<Flashcard> flashcardDtos = new List<Flashcard>();
            List<FlashcardDm> flashcardDms = _flashcardRepository.GetAllFlashcardsForCategoryDm(categoryId).ToList();
            
            if (flashcardDms is not null && flashcardDms.Count > 0)
            {
                foreach (FlashcardDm fc in flashcardDms)
                {
                    Flashcard flashcardDto = new Flashcard()
                    {
                        Id = fc.Id,
                        Title = fc.Name,
                        Front = fc.Front,
                        Back = fc.Back,
                        AnsweredCorrectly = fc.AnsweredCorrectly,
                        CategoryId = fc.CategoryId
                    };
                    flashcardDtos.Add(flashcardDto);
                }

                return StatusCode(StatusCodes.Status200OK, flashcardDtos);
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        [HttpPost]
        public ActionResult<string> Create(Flashcard flashcardDto)
        {
            try
            {
                FlashcardDm newFlashcardDm = new FlashcardDm()
                {
                    Name = flashcardDto.Title,
                    Front = flashcardDto.Front,
                    Back = flashcardDto.Back,
                    AnsweredCorrectly = false,
                    CategoryId = flashcardDto.CategoryId
                };
                _flashcardRepository.AddAsync(newFlashcardDm);
                return StatusCode(StatusCodes.Status201Created, "new flashcard URL placeholder");  //TODO: add url for new Flashcard to return status
            }
            catch (Exception e)
            {                
                return StatusCode(StatusCodes.Status400BadRequest, e);
            }
        }

        [HttpPost]
        public ActionResult<string> Update(Flashcard flashcardDto)
        {
            try
            {
                    if (_flashcardRepository.ExistsAsync((int)flashcardDto.Id).Result)
                    {

                        FlashcardDm newFlashcardDm = new FlashcardDm()
                        {
                            Id = (int)flashcardDto.Id,
                            Name = flashcardDto.Title,
                            Front = flashcardDto.Front,
                            Back = flashcardDto.Back,
                            AnsweredCorrectly = flashcardDto.AnsweredCorrectly,
                            CategoryId = flashcardDto.CategoryId
                        };
                        int pk = _flashcardRepository.Update(newFlashcardDm);
                        return StatusCode(StatusCodes.Status200OK, ""); //TODO: replace update message with url for updated Flashcard

                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status204NoContent, $"Flashcard {flashcardDto.Id} could not be found.");
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
                FlashcardDm flashcardDmToDelete = _flashcardRepository.Where(fc => fc.Id == id).FirstOrDefault();
                if (flashcardDmToDelete is not null)
                {
                    _flashcardRepository.Remove(flashcardDmToDelete);
                    return StatusCode(StatusCodes.Status200OK, $"Flashcard {id} was deleted.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"Flashcard {id} could not be found.");
                }
            }
            catch (Exception e)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }

}
