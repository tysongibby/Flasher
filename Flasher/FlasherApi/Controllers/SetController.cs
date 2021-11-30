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
        public ActionResult<Set> Get(int id)
        {
            try
            {
                SetModel set = _setRepository.GetAsync(id).Result;
                if (set is not null)
                {
                    Set setDto = new Set()
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
        public ActionResult<Set> GetSuperset(int id)
        {
            try
            {
                SupersetModel superset = _setRepository.GetSuperset(id).Result;
                if (superset is not null)
                {
                    Superset supersetDto = new Superset()
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
        public ActionResult<List<Set>> GetAll()
        {
            try
            {
                List<Set> setDtos = new List<Set>();
                List<SetModel> sets = _setRepository.GetAllAsync().Result.ToList();
                if (sets.Count > 0)
                {
                    foreach (SetModel s in sets)
                    {
                        Set setDto = new Set()
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
        public ActionResult<string> Create(Set newSetDto)
        {
            try
            {
                SetModel newSet = new SetModel()
                {
                    Title = newSetDto.Title,
                    SupersetId = newSetDto.SupersetId
                };
                _setRepository.AddAsync(newSet);
                return StatusCode(StatusCodes.Status201Created); //TODO: add url for new Set to return status            
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }   
        
        [HttpPost]
        public ActionResult<string> Update(int id, Set setDtoUpdate)
        {
            try
            {
                if (id == setDtoUpdate.Id)
                {
                    if (_setRepository.ExistsAsync(id).Result)
                    {
                        SetModel setUpdate = new SetModel()
                        {
                            Id = (int)setDtoUpdate.Id,
                            Title = setDtoUpdate.Title,
                            SupersetId = setDtoUpdate.SupersetId
                        };
                        _setRepository.Update(setUpdate);
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
                SetModel setToDelete = _setRepository.Where(fc => fc.Id == id).FirstOrDefault();
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
