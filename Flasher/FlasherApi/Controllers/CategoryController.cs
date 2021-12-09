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
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryDmRepository _categoryDmRepository;

        public CategoryController(ILogger<CategoryController> logger, ICategoryDmRepository categoryRepository)
        {
            _logger = logger;
            _categoryDmRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult<Category> Get(int id)
        {
            try
            {
                CategoryDm categoryDm = _categoryDmRepository.GetAsync(id).Result;
                if (categoryDm is not null)
                {
                    Category categoryDto = new Category()
                    {
                        Id = categoryDm.Id,
                        Title = categoryDm.Name,
                        SubjectId = categoryDm.SubjectId
                    };
                    return StatusCode(StatusCodes.Status200OK, categoryDto);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"Category {id} could not be found");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public ActionResult<Category> GetSubject(int id)
        {
            try
            {
                SubjectDm subjectDm = _categoryDmRepository.GetSubjectDm(id).Result;
                if (subjectDm is not null)
                {
                    Subject subjectDto = new Subject()
                    {
                        Id = subjectDm.Id,
                        Title = subjectDm.Name                        
                    };
                    return StatusCode(StatusCodes.Status200OK, subjectDto);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"Category {id} could not be found");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAll()
        {
            try
            {
                List<Category> categoryDtos = new List<Category>();
                List<CategoryDm> categoryDms = _categoryDmRepository.GetAllAsync().Result.ToList();
                if (categoryDms.Count > 0)
                {
                    foreach (CategoryDm s in categoryDms)
                    {
                        Category categoryDto = new Category()
                        {
                            Id = s.Id,
                            Title = s.Name,
                            SubjectId = s.SubjectId
                        };
                        categoryDtos.Add(categoryDto);
                    }
                    return StatusCode(StatusCodes.Status200OK, categoryDtos);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"No categories have been created yet.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<string> Create(Category newCategoryDto)
        {
            try
            {
                CategoryDm newCategoryDm = new CategoryDm()
                {
                    Name = newCategoryDto.Title,
                    SubjectId = newCategoryDto.SubjectId
                };
                _categoryDmRepository.AddAsync(newCategoryDm);
                return StatusCode(StatusCodes.Status201Created); //TODO: add url for new CategoryDm to return status            
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }   
        
        [HttpPost]
        public ActionResult<string> Update(int id, Category categoryDtoUpdate)
        {
            try
            {
                if (id == categoryDtoUpdate.Id)
                {
                    if (_categoryDmRepository.ExistsAsync(id).Result)
                    {
                        CategoryDm categoryDmUpdate = new CategoryDm()
                        {
                            Id = (int)categoryDtoUpdate.Id,
                            Name = categoryDtoUpdate.Title,
                            SubjectId = categoryDtoUpdate.SubjectId
                        };
                        _categoryDmRepository.Update(categoryDmUpdate);
                        return StatusCode(StatusCodes.Status200OK); //TODO: add url for updated CategoryDm to return status 
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status204NoContent, $"Category {categoryDtoUpdate.Id} could not be found.");
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, $"id {id} and categoryDtoUpdate.Id {categoryDtoUpdate.Id} must be the same");
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
                CategoryDm categoryDmToDelete = _categoryDmRepository.Where(fc => fc.Id == id).FirstOrDefault();
                if (categoryDmToDelete is not null)
                {
                    _categoryDmRepository.Remove(categoryDmToDelete);
                    return StatusCode(StatusCodes.Status200OK, $"Category {id} has been deleted.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, $"Category {id} could not be found.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }
}
