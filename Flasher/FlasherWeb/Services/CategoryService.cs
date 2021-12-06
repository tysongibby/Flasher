using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FlasherWeb.Services.Interfaces;
using FlasherWeb.Services.Models;
using Microsoft.Extensions.Configuration;

namespace FlasherWeb.Services
{
    public class CategoryService : ICategoryService
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string ControllerSubdirectory { get; set; } = string.Empty;

        public CategoryService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            ControllerSubdirectory = _configuration.GetValue<string>("api_category_subdirectory");
        }

        public async Task<Category> Get(int id)
        {
            try
            {
                Category category = await _httpClient.GetFromJsonAsync<Category>(ControllerSubdirectory + "/Get");
                return category;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve flashcard category {id}: ", e);
            }
        }

        public async Task<List<Category>> GetAll()
        {
            try
            {
                List<Category> categories = await _httpClient.GetFromJsonAsync<List<Category>>(ControllerSubdirectory + "/GetAll");
                return categories;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve list of flash card categories: ", e);
            }
        }

        public async Task<Category> Create(Category categoryToCreate)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Category>(ControllerSubdirectory + "/Create", categoryToCreate);
                Category newCategory = await response.Content.ReadFromJsonAsync<Category>();
                return newCategory;
            }
            catch (Exception e)
            {
                throw new Exception("Failed to create new flashcard category: ", e);
            }
        }

        public async Task<Category> Update(Category categoryUpdate)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Category>(ControllerSubdirectory + "/Update", categoryUpdate);
                Category updatedCategory = await response.Content.ReadFromJsonAsync<Category>();
                return updatedCategory;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to update flash card category {categoryUpdate.Id}: ", e);
            }
        }
        public async Task<string> Delete(Category categoryToDelete)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Category>(ControllerSubdirectory + "/Delete", categoryToDelete);
                string result = await response.Content.ReadFromJsonAsync<string>();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to delete flash card category {categoryToDelete.Id}: ", e);
            }
        }
    }
}
