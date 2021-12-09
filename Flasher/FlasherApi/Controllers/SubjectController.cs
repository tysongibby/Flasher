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
        private readonly ISubjectDmRepository _subjectDmRepository;

        public SubjectController(ILogger<SubjectController> logger, ISubjectDmRepository subjectRepository)
        {
            _logger = logger;
            _subjectDmRepository = subjectRepository;
        }

        [HttpGet]
        public ActionResult<Subject> Get(int id)
        {
            try
            {
                SubjectDm subjectDm = _subjectDmRepository.GetAsync(id).Result;
                if (subjectDm is not null)
                {
                    Subject subjectDto = new Subject()
                    {
                        Id = subjectDm.Id,
                        Title = subjectDm.Name
                    };
                    return StatusCode(StatusCodes.Status201Created, subjectDto);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"SubjectDm {id} could not be found");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Subject>> GetAll()
        {
            try
            {
                List<Subject> subjectDtos = new List<Subject>();
                List<SubjectDm> subjectDms = _subjectDmRepository.GetAllAsync().Result.ToList();
                if (subjectDms.Count > 0)
                {
                    foreach (SubjectDm s in subjectDms)
                    {
                        Subject subjectDto = new Subject()
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
        public ActionResult<string> Create(Subject newSubjectDto)
        {
            try
            {
                SubjectDm newSubjectDm = new SubjectDm()
                {
                    Name = newSubjectDto.Title
                };
                _subjectDmRepository.AddAsync(newSubjectDm);
                return StatusCode(StatusCodes.Status201Created); //TODO: add url for new Subject to return status            
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }   
        
        [HttpPost]
        public ActionResult<string> Update(int id, Subject subjectDtoUpdate)
        {
            try
            {
                if (id == subjectDtoUpdate.Id)
                {
                    if (_subjectDmRepository.ExistsAsync(id).Result)
                    {
                        SubjectDm subjectDmUpdate = new SubjectDm()
                        {
                            Id = (int)subjectDtoUpdate.Id,
                            Name = subjectDtoUpdate.Title
                        };
                        _subjectDmRepository.Update(subjectDmUpdate);
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
                SubjectDm subjectDmToDelete = _subjectDmRepository.Where(fc => fc.Id == id).FirstOrDefault();
                if (subjectDmToDelete is not null)
                {
                    _subjectDmRepository.Remove(subjectDmToDelete);
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
