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
    public class SupersetService : ISupersetService
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string ControllerSubdirectory { get; set; } = string.Empty;

        public SupersetService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            ControllerSubdirectory = _configuration.GetValue<string>("api_superset_subdirectory");            
        }

        public async Task<Superset> Get(int id)
        {
            try
            {
                Superset superset = await _httpClient.GetFromJsonAsync<Superset>(ControllerSubdirectory + "Get");
                return superset;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve flash card superset {id}: ", e);
            }
        }

        public async Task<List<Superset>> GetAll()
        {
            try
            {
                string actionSubdirectory = ControllerSubdirectory + "/GetAll";
                //Console.WriteLine($"***Supersets API Base URL {_httpClient.BaseAddress}");
                //Console.WriteLine($"***Supersets API Controller subdirectory {ControllerSubdirectory}");
                //Console.WriteLine($"***Supersets API GetAll Subdirectory URL {actionSubdirectory}");
                List<Superset> supersets = await _httpClient.GetFromJsonAsync<List<Superset>>(actionSubdirectory);
                return supersets;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve list of flash card supersets: ", e);
            }
        }

        public async Task<Superset> Create(Superset supersetToCreate)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Superset>(ControllerSubdirectory + "/Create", supersetToCreate);
                Superset newSuperset = await response.Content.ReadFromJsonAsync<Superset>();
                return newSuperset;
            }
            catch (Exception e)
            {
                throw new Exception("Failed to create new flash card superset: ", e);
            }
        }

        public async Task<Superset> Update(Superset supersetUpdate)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Superset>(ControllerSubdirectory + "/Update", supersetUpdate);
                Superset updatedSuperset = await response.Content.ReadFromJsonAsync<Superset>();
                return updatedSuperset;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to update flash card superset {supersetUpdate.Id}: ", e);
            }
        }
        public async Task<string> Delete(Superset supersetToDelete)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Superset>(ControllerSubdirectory + "/Delete", supersetToDelete);
                string result = await response.Content.ReadFromJsonAsync<string>();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to delete flash card superset {supersetToDelete.Id}: ", e);
            }
        }
    }
}
