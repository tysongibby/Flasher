using FlasherApi.Data.Dtos;
using FlasherApi.Data.Models;
using FlasherApi.Data.Repositories.Interfaces;
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
    public class SetController : ControllerBase
    {
        private readonly ILogger<SetController> _logger;
        private readonly ISetRepository _setRepository;

        public SetController(ILogger<SetController> logger, ISetRepository setRepository)
        {
            _logger = logger;
            _setRepository = setRepository;
        }

        [HttpGet]
        public ActionResult<SetDto> Get(int id)
        {
            try
            {
                Set set = _setRepository.Get(id).Result;
                if (set is not null)
                {
                    SetDto setDto = new SetDto()
                    {
                        Id = set.Id,
                        Title = set.Title,
                        SupersetId = set.SupersetId
                    };
                    return StatusCode(StatusCodes.Status200OK, setDto);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"Set {id} could not be found");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public ActionResult<SetDto> GetSuperset(int id)
        {
            try
            {
                Superset superset = _setRepository.GetSuperset(id).Result;
                if (superset is not null)
                {
                    SupersetDto supersetDto = new SupersetDto()
                    {
                        Id = superset.Id,
                        Title = superset.Title                        
                    };
                    return StatusCode(StatusCodes.Status200OK, supersetDto);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"Set {id} could not be found");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<SetDto>> GetAll()
        {
            try
            {
                List<SetDto> setDtos = new List<SetDto>();
                List<Set> sets = _setRepository.GetAll().Result.ToList();
                if (sets.Count > 0)
                {
                    foreach (Set s in sets)
                    {
                        SetDto setDto = new SetDto()
                        {
                            Id = s.Id,
                            Title = s.Title,
                            SupersetId = s.SupersetId
                        };
                        setDtos.Add(setDto);
                    }
                    return StatusCode(StatusCodes.Status200OK, setDtos);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"No sets have been created yet.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<string> Create(SetDto newSetDto)
        {
            try
            {
                Set newSet = new Set()
                {
                    Title = newSetDto.Title,
                    SupersetId = newSetDto.SupersetId
                };
                _setRepository.Add(newSet);
                return StatusCode(StatusCodes.Status201Created); //TODO: add url for new Set to return status            
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }   
        
        [HttpPost]
        public ActionResult<string> Update(int id, SetDto setDtoUpdate)
        {
            try
            {
                if (id == setDtoUpdate.Id)
                {
                    if (_setRepository.Exists(id).Result)
                    {
                        Set setUpdate = new Set()
                        {
                            Id = (int)setDtoUpdate.Id,
                            Title = setDtoUpdate.Title,
                            SupersetId = setDtoUpdate.SupersetId
                        };
                        var updatedSet =_setRepository.Update(setUpdate).Result;
                        return StatusCode(StatusCodes.Status200OK); //TODO: add url for updated Set to return status 
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status204NoContent, $"Set {setDtoUpdate.Id} could not be found.");
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, $"id {id} and setDtoUpdate.Id {setDtoUpdate.Id} must be the same");
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
                Set setToDelete = _setRepository.Find(fc => fc.Id == id).FirstOrDefault();
                if (setToDelete is not null)
                {
                    _setRepository.Remove(setToDelete);
                    return StatusCode(StatusCodes.Status200OK, $"Set {id} has been deleted.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"Set {id} could not be found.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }
}
