using FlasherApi.Data.Dtos;
using FlasherData.Models;
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
    public class SupersetController : ControllerBase
    {
        private readonly ILogger<SupersetController> _logger;
        private readonly ISupersetRepository _supersetRepository;

        public SupersetController(ILogger<SupersetController> logger, ISupersetRepository superSetRepository)
        {
            _logger = logger;
            _supersetRepository = superSetRepository;
        }

        [HttpGet]
        public ActionResult<SupersetDto> Get(int id)
        {
            try
            {
                Superset superset = _supersetRepository.GetAsync(id).Result;
                if (superset is not null)
                {
                    SupersetDto supersetDto = new SupersetDto()
                    {
                        Id = superset.Id,
                        Title = superset.Title
                    };
                    return StatusCode(StatusCodes.Status201Created, supersetDto);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"Superset {id} could not be found");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<SupersetDto>> GetAll()
        {
            try
            {
                List<SupersetDto> supersetDtos = new List<SupersetDto>();
                List<Superset> supersets = _supersetRepository.GetAllAsync().Result.ToList();
                if (supersets.Count > 0)
                {
                    foreach (Superset s in supersets)
                    {
                        SupersetDto supersetDto = new SupersetDto()
                        {
                            Id = s.Id,
                            Title = s.Title
                        };
                        supersetDtos.Add(supersetDto);
                    }
                    return StatusCode(StatusCodes.Status200OK, supersetDtos);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"No supersets have been created yet.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<string> Create(SupersetDto newSupersetDto)
        {
            try
            {
                Superset newSuperset = new Superset()
                {
                    Title = newSupersetDto.Title
                };
                _supersetRepository.AddAsync(newSuperset);
                return StatusCode(StatusCodes.Status201Created); //TODO: add url for new Superset to return status            
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }   
        
        [HttpPost]
        public ActionResult<string> Update(int id, SupersetDto supersetDtoUpdate)
        {
            try
            {
                if (id == supersetDtoUpdate.Id)
                {
                    if (_supersetRepository.ExistsAsync(id).Result)
                    {
                        Superset supersetUpdate = new Superset()
                        {
                            Id = (int)supersetDtoUpdate.Id,
                            Title = supersetDtoUpdate.Title
                        };
                        _supersetRepository.Update(supersetUpdate);
                        return StatusCode(StatusCodes.Status200OK); //TODO: add url for updated Superset to return status 
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status204NoContent, $"Superset {supersetDtoUpdate.Id} could not be found.");
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, $"id {id} and supersetDtoUpdate.Id {supersetDtoUpdate.Id} must be the same");
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
                Superset supersetToDelete = _supersetRepository.Where(fc => fc.Id == id).FirstOrDefault();
                if (supersetToDelete is not null)
                {
                    _supersetRepository.Remove(supersetToDelete);
                    return StatusCode(StatusCodes.Status200OK, $"Superset {id} has been deleted.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"Superset {id} could not be found.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }
}
