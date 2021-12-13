using FlasherApi.Data.Dtos;
using FlasherData.DataModels;
using FlasherData.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlasherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SubjectController : ControllerBase
    {
        private readonly ILogger<SubjectController> _logger;
        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(ILogger<SubjectController> logger, ISubjectRepository subjectRepository)
        {
            _logger = logger;
            _subjectRepository = subjectRepository;
        }

        [HttpGet]
        public ActionResult<Data.Dtos.SubjectDto> Get(int id)
        {
            try
            {
                FlasherData.DataModels.Subject subject = _subjectRepository.GetAsync(id).Result;
                if (subject is not null)
                {
                    Data.Dtos.SubjectDto subjectDto = new Data.Dtos.SubjectDto()
                    {
                        Id = subject.Id,
                        Title = subject.Name
                    };
                    return StatusCode(StatusCodes.Status201Created, subjectDto);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"Subject {id} could not be found");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Data.Dtos.SubjectDto>> GetAll()
        {
            try
            {
                List<Data.Dtos.SubjectDto> subjectDtos = new List<Data.Dtos.SubjectDto>();
                List<FlasherData.DataModels.Subject> subjects = _subjectRepository.GetAllAsync().Result.ToList();
                if (subjects.Count > 0)
                {
                    foreach (FlasherData.DataModels.Subject s in subjects)
                    {
                        Data.Dtos.SubjectDto subjectDto = new Data.Dtos.SubjectDto()
                        {
                            Id = s.Id,
                            Title = s.Name
                        };
                        subjectDtos.Add(subjectDto);
                    }
                    return StatusCode(StatusCodes.Status200OK, subjectDtos);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"No subjects have been created yet.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<string> Create(Data.Dtos.SubjectDto newSubjectDto)
        {
            try
            {
                FlasherData.DataModels.Subject newSubject = new FlasherData.DataModels.Subject()
                {
                    Name = newSubjectDto.Title
                };
                _subjectRepository.AddAsync(newSubject);
                return StatusCode(StatusCodes.Status201Created); //TODO: add url for new Subject to return status            
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }   
        
        [HttpPost]
        public ActionResult<string> Update(int id, Data.Dtos.SubjectDto subjectDtoUpdate)
        {
            try
            {
                if (id == subjectDtoUpdate.Id)
                {
                    if (_subjectRepository.ExistsAsync(id).Result)
                    {
                        FlasherData.DataModels.Subject subjectUpdate = new FlasherData.DataModels.Subject()
                        {
                            Id = (int)subjectDtoUpdate.Id,
                            Name = subjectDtoUpdate.Title
                        };
                        _subjectRepository.Update(subjectUpdate);
                        return StatusCode(StatusCodes.Status200OK); //TODO: add url for updated Subject to return status 
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status204NoContent, $"Subject {subjectDtoUpdate.Id} could not be found.");
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, $"id {id} and subjectDtoUpdate.Id {subjectDtoUpdate.Id} must be the same");
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
                FlasherData.DataModels.Subject subjectToDelete = _subjectRepository.Where(fc => fc.Id == id).FirstOrDefault();
                if (subjectToDelete is not null)
                {
                    _subjectRepository.Remove(subjectToDelete);
                    return StatusCode(StatusCodes.Status200OK, $"Subject {id} has been deleted.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"Subject {id} could not be found.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }
}
