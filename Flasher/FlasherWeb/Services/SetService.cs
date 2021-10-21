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
    public class SetService : ISetService
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string ControllerSubdirectory { get; set; } = string.Empty;

        public SetService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            ControllerSubdirectory = _configuration.GetValue<string>("api_set_subdirectory");
        }

        public async Task<Set> Get(int id)
        {
            try
            {
                Set set = await _httpClient.GetFromJsonAsync<Set>(ControllerSubdirectory + "/Get");
                return set;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve flash card set {id}: ", e);
            }
        }

        public async Task<List<Set>> GetAll()
        {
            try
            {
                List<Set> sets = await _httpClient.GetFromJsonAsync<List<Set>>(ControllerSubdirectory + "/GetAll");
                return sets;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve list of flash card sets: ", e);
            }
        }

        public async Task<Set> Create(Set setToCreate)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Set>(ControllerSubdirectory + "/Create", setToCreate);
                Set newSet = await response.Content.ReadFromJsonAsync<Set>();
                return newSet;
            }
            catch (Exception e)
            {
                throw new Exception("Failed to create new flash card set: ", e);
            }
        }

        public async Task<Set> Update(Set setUpdate)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Set>(ControllerSubdirectory + "/Update", setUpdate);
                Set updatedSet = await response.Content.ReadFromJsonAsync<Set>();
                return updatedSet;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to update flash card set {setUpdate.Id}: ", e);
            }
        }
        public async Task<string> Delete(Set setToDelete)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Set>(ControllerSubdirectory + "/Delete", setToDelete);
                string result = await response.Content.ReadFromJsonAsync<string>();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to delete flash card set {setToDelete.Id}: ", e);
            }
        }
    }
}
