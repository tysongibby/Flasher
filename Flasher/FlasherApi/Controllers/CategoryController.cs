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
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ILogger<CategoryController> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult<Data.Dtos.CategoryDto> Get(int id)
        {
            try
            {
                FlasherData.DataModels.Category category = _categoryRepository.GetAsync(id).Result;
                if (category is not null)
                {
                    Data.Dtos.CategoryDto categoryDto = new Data.Dtos.CategoryDto()
                    {
                        Id = category.Id,
                        Title = category.Name,
                        SubjectId = category.SubjectId
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
        public ActionResult<Data.Dtos.CategoryDto> GetSubject(int id)
        {
            try
            {
                FlasherData.DataModels.Subject subject = _categoryRepository.GetSubject(id).Result;
                if (subject is not null)
                {
                    Data.Dtos.SubjectDto subjectDto = new Data.Dtos.SubjectDto()
                    {
                        Id = subject.Id,
                        Title = subject.Name                        
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
        public ActionResult<List<Data.Dtos.CategoryDto>> GetAll()
        {
            try
            {
                List<Data.Dtos.CategoryDto> categoryDtos = new List<Data.Dtos.CategoryDto>();
                List<FlasherData.DataModels.Category> category = _categoryRepository.GetAllAsync().Result.ToList();
                if (category.Count > 0)
                {
                    foreach (FlasherData.DataModels.Category s in category)
                    {
                        Data.Dtos.CategoryDto categoryDto = new Data.Dtos.CategoryDto()
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
        public ActionResult<string> Create(Data.Dtos.CategoryDto newCategoryDto)
        {
            try
            {
                FlasherData.DataModels.Category newCategory = new FlasherData.DataModels.Category()
                {
                    Name = newCategoryDto.Title,
                    SubjectId = newCategoryDto.SubjectId
                };
                _categoryRepository.AddAsync(newCategory);
                return StatusCode(StatusCodes.Status201Created); //TODO: add url for new Category to return status            
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }   
        
        [HttpPost]
        public ActionResult<string> Update(int id, Data.Dtos.CategoryDto categoryDtoUpdate)
        {
            try
            {
                if (id == categoryDtoUpdate.Id)
                {
                    if (_categoryRepository.ExistsAsync(id).Result)
                    {
                        FlasherData.DataModels.Category categoryUpdate = new FlasherData.DataModels.Category()
                        {
                            Id = (int)categoryDtoUpdate.Id,
                            Name = categoryDtoUpdate.Title,
                            SubjectId = categoryDtoUpdate.SubjectId
                        };
                        _categoryRepository.Update(categoryUpdate);
                        return StatusCode(StatusCodes.Status200OK); //TODO: add url for updated Category to return status 
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
                FlasherData.DataModels.Category categoryToDelete = _categoryRepository.Where(fc => fc.Id == id).FirstOrDefault();
                if (categoryToDelete is not null)
                {
                    _categoryRepository.Remove(categoryToDelete);
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
