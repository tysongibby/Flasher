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
        private readonly IFlashcardRepository _flashcardRepository;

        public FlashcardController(ILogger<FlashcardController> logger, IFlashcardRepository flashcardRepository)
        {
            _logger = logger;
            _flashcardRepository = flashcardRepository;
        }

        [HttpGet]
        public ActionResult<Data.Dtos.FlashcardDto> Get(int id)
        {
            FlasherData.DataModels.Flashcard flashcard = _flashcardRepository.GetAsync(id).Result;
            Data.Dtos.FlashcardDto flashcardDto = new Data.Dtos.FlashcardDto();            
            if (flashcard is not null && flashcard.Id != 0)
            {            
                flashcardDto.Id = flashcard.Id;
                flashcardDto.Name = flashcard.Name;
                flashcardDto.Front = flashcard.Front;
                flashcardDto.Back = flashcard.Back;
                flashcardDto.AnsweredCorrectly = flashcard.AnsweredCorrectly;                
                flashcardDto.CategoryId = flashcard.CategoryId;
                return StatusCode(StatusCodes.Status200OK, flashcardDto);
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }            
        }

        [HttpGet]
        public ActionResult<IEnumerable<Data.Dtos.FlashcardDto>> GetAll()
        {
            List<FlasherData.DataModels.Flashcard> flashcards = _flashcardRepository.GetAllAsync().Result.ToList();
            List<Data.Dtos.FlashcardDto> flashcardDtos = new List<Data.Dtos.FlashcardDto>();
            if (flashcards is not null)
            {


                foreach (FlasherData.DataModels.Flashcard fc in flashcards)
                {
                    Data.Dtos.FlashcardDto flashcardDto = new Data.Dtos.FlashcardDto()
                    {
                        Id = fc.Id,
                        Name = fc.Name,
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
        public ActionResult<List<Data.Dtos.FlashcardDto>> GetAllFlashcardsForSubject(int id)
        {
            List<Data.Dtos.FlashcardDto> flashcardDtos = new List<Data.Dtos.FlashcardDto>();
            List<FlasherData.DataModels.Flashcard> flashcards = _flashcardRepository.GetAllFlashcardsForSubject(id).ToList();            
            if (flashcards is not null && flashcards.Count > 0)
            {
                foreach (FlasherData.DataModels.Flashcard fc in flashcards)
                {
                    Data.Dtos.FlashcardDto flashcardDto = new Data.Dtos.FlashcardDto()
                    {
                        Id = fc.Id,
                        Name = fc.Name,
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
        public ActionResult<List<Data.Dtos.FlashcardDto>> GetAllFlashcardsInCategory(int categoryId)
        {
            List<Data.Dtos.FlashcardDto> flashcardDtos = new List<Data.Dtos.FlashcardDto>();
            List<FlasherData.DataModels.Flashcard> flashcards = _flashcardRepository.GetAllFlashcardsForCategory(categoryId).ToList();
            
            if (flashcards is not null && flashcards.Count > 0)
            {
                foreach (FlasherData.DataModels.Flashcard fc in flashcards)
                {
                    Data.Dtos.FlashcardDto flashcardDto = new Data.Dtos.FlashcardDto()
                    {
                        Id = fc.Id,
                        Name = fc.Name,
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
        public ActionResult<string> Create(Data.Dtos.FlashcardDto flashcardDto)
        {
            try
            {
                FlasherData.DataModels.Flashcard newFlashcard = new FlasherData.DataModels.Flashcard()
                {
                    Name = flashcardDto.Name,
                    Front = flashcardDto.Front,
                    Back = flashcardDto.Back,
                    AnsweredCorrectly = false,
                    CategoryId = flashcardDto.CategoryId
                };
                _flashcardRepository.AddAsync(newFlashcard);
                return StatusCode(StatusCodes.Status201Created, "new flashcard URL placeholder");  //TODO: add url for new Flashcard to return status
            }
            catch (Exception e)
            {                
                return StatusCode(StatusCodes.Status400BadRequest, e);
            }
        }

        [HttpPost]
        public ActionResult<string> Update(Data.Dtos.FlashcardDto flashcardDto)
        {
            try
            {
                    if (_flashcardRepository.ExistsAsync((int)flashcardDto.Id).Result)
                    {

                    FlasherData.DataModels.Flashcard newFlashcard = new FlasherData.DataModels.Flashcard()
                        {
                            Id = (int)flashcardDto.Id,
                            Name = flashcardDto.Name,
                            Front = flashcardDto.Front,
                            Back = flashcardDto.Back,
                            AnsweredCorrectly = flashcardDto.AnsweredCorrectly,
                            CategoryId = flashcardDto.CategoryId
                        };
                        int pk = _flashcardRepository.Update(newFlashcard);
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
                FlasherData.DataModels.Flashcard flashcardToDelete = _flashcardRepository.Where(fc => fc.Id == id).FirstOrDefault();
                if (flashcardToDelete is not null)
                {
                    _flashcardRepository.Remove(flashcardToDelete);
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
