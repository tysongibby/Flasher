using FlasherWeb.Services.Models;
using FlasherWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace FlasherWeb.Services
{
    public class FlashcardService : IFlashcardService
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string ControllerSubdirectory { get; set; } = string.Empty;

        public FlashcardService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            ControllerSubdirectory = _configuration.GetValue<string>("api_flashcard_subdirectory");
        }

        public async Task<Flashcard> Get(int id)
        {
            try
            {
                Flashcard flashcard = await _httpClient.GetFromJsonAsync<Flashcard>(ControllerSubdirectory + "/Get");
                return flashcard;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve flashcard {id}: ", e);
            }
        }

        public async Task<List<Flashcard>> GetAll()
        {
            try
            {                            
                List<Flashcard> flashcards = await _httpClient.GetFromJsonAsync<List<Flashcard>>(ControllerSubdirectory + "/GetAll");
                return flashcards;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve list of flashcards: ", e);
            }
        }

        public async Task<List<Flashcard>> GetAllFlashcardsForSubject(int id)
        {
            try
            {
                List<Flashcard> flashcards = await _httpClient.GetFromJsonAsync<List<Flashcard>>(ControllerSubdirectory + "/GetAllFlashcardsInSubject");
                return flashcards;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve list of flashcards in Subject {id}: ", e);
            }
        }

        public async Task<List<Flashcard>> GetAllFlashcardsForCategory(int id)
        {
            try
            {
                List<Flashcard> flashcards = await _httpClient.GetFromJsonAsync<List<Flashcard>>(ControllerSubdirectory + "/GetAllFlashcardsForCategory");
                return flashcards;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve list of flashcards in Category {id}: ", e);
            }
        }

        public async Task<string> Create(Flashcard flashcardToCreate)
        {
            try
            {
                string result = string.Empty;
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Flashcard>(ControllerSubdirectory + "/Create", flashcardToCreate);
                //result = await response.Content.ReadFromJsonAsync<string>(); //TODO: fix this JSON formatting error to get response from api
                return result;
            }            
            catch(Exception e)
            {
                throw new Exception("Failed to create new flashcard: ", e);
            }
    
        }


        public async Task<string> Update(Flashcard flashcardUpdate)
        {
            try
            {
                string content = string.Empty;
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Flashcard>(ControllerSubdirectory + "/Update", flashcardUpdate);
                //content = await response.Content.ReadFromJsonAsync<string>(); //TODO: fix this JSON formatting error to get response from api
                return content;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to update flashcard {flashcardUpdate.Id}: ", e);
            }

        }

        public async Task<string> Delete(Flashcard flashcardToDelete)
        {
            try
            {
                string result = string.Empty;
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Flashcard>(ControllerSubdirectory + "/Delete", flashcardToDelete);
                //result = await response.Content.ReadFromJsonAsync<string>(); //TODO: fix this JSON formatting error to get response from api
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to delete flashcard {flashcardToDelete.Id}: ", e);
            }

        }

    }
}
