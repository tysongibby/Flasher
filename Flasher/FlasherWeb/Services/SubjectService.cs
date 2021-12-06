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
    public class SubjectService : ISubjectService
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string ControllerSubdirectory { get; set; } = string.Empty;

        public SubjectService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            ControllerSubdirectory = _configuration.GetValue<string>("api_subject_subdirectory");            
        }

        public async Task<Subject> Get(int id)
        {
            try
            {
                Subject subject = await _httpClient.GetFromJsonAsync<Subject>(ControllerSubdirectory + "Get");
                return subject;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve flashcard subject {id}: ", e);
            }
        }

        public async Task<List<Subject>> GetAll()
        {
            try
            {
                string actionSubdirectory = ControllerSubdirectory + "/GetAll";
                List<Subject> subjects = await _httpClient.GetFromJsonAsync<List<Subject>>(actionSubdirectory);
                return subjects;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve list of flashcard subjects: ", e);
            }
        }

        public async Task<Subject> Create(Subject subjectToCreate)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Subject>(ControllerSubdirectory + "/Create", subjectToCreate);
                Subject newSubject = await response.Content.ReadFromJsonAsync<Subject>();
                return newSubject;
            }
            catch (Exception e)
            {
                throw new Exception("Failed to create new flashcard subject: ", e);
            }
        }

        public async Task<Subject> Update(Subject subjectUpdate)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Subject>(ControllerSubdirectory + "/Update", subjectUpdate);
                Subject updatedSubject = await response.Content.ReadFromJsonAsync<Subject>();
                return updatedSubject;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to update flashcard subject {subjectUpdate.Id}: ", e);
            }
        }
        public async Task<string> Delete(Subject subjectToDelete)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Subject>(ControllerSubdirectory + "/Delete", subjectToDelete);
                string result = await response.Content.ReadFromJsonAsync<string>();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to delete flashcard subject {subjectToDelete.Id}: ", e);
            }
        }
    }
}
