﻿using FlasherWeb.Services.Models;
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
    public class FlashCardService : IFlashCardService
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string ControllerSubdirectory { get; set; } = string.Empty;

        public FlashCardService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            ControllerSubdirectory = _configuration.GetValue<string>("api_flashcard_subdirectory");
        }

        public async Task<FlashCard> Get(int id)
        {
            try
            {
                FlashCard flashCard = await _httpClient.GetFromJsonAsync<FlashCard>(ControllerSubdirectory + "/Get");
                return flashCard;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve flash card {id}: ", e);
            }
        }

        public async Task<List<FlashCard>> GetAll()
        {
            try
            {                            
                List<FlashCard> flashCards = await _httpClient.GetFromJsonAsync<List<FlashCard>>(ControllerSubdirectory + "/GetAll");
                return flashCards;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve list of flash cards: ", e);
            }
        }

        public async Task<List<FlashCard>> GetAllFlashCardsInSuperset(int id)
        {
            try
            {
                List<FlashCard> flashCards = await _httpClient.GetFromJsonAsync<List<FlashCard>>(ControllerSubdirectory + "/GetAllFlashCardsInSuperset");
                return flashCards;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve list of flash cards in Superset {id}: ", e);
            }
        }

        public async Task<List<FlashCard>> GetAllFlashCardsInSet(int id)
        {
            try
            {
                List<FlashCard> flashCards = await _httpClient.GetFromJsonAsync<List<FlashCard>>(ControllerSubdirectory + "/GetAllFlashCardsInSet");
                return flashCards;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve list of flash cards in Set {id}: ", e);
            }
        }

        public async Task<string> Create(FlashCard flashCardToCreate)
        {
            try
            {
                string result = string.Empty;
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<FlashCard>(ControllerSubdirectory + "/Create", flashCardToCreate);
                //result = await response.Content.ReadFromJsonAsync<string>(); //TODO: fix this JSON formatting error to get response from api
                return result;
            }            
            catch(Exception e)
            {
                throw new Exception("Failed to create new flash card: ", e);
            }
    
        }


        public async Task<string> Update(FlashCard flashCardUpdate)
        {
            try
            {
                string content = string.Empty;
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<FlashCard>(ControllerSubdirectory + "/Update", flashCardUpdate);
                //content = await response.Content.ReadFromJsonAsync<string>(); //TODO: fix this JSON formatting error to get response from api
                return content;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to update flash card {flashCardUpdate.Id}: ", e);
            }

        }

        public async Task<string> Delete(FlashCard flashCardToDelete)
        {
            try
            {
                string result = string.Empty;
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<FlashCard>(ControllerSubdirectory + "/Delete", flashCardToDelete);
                //result = await response.Content.ReadFromJsonAsync<string>(); //TODO: fix this JSON formatting error to get response from api
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to delete flash card {flashCardToDelete.Id}: ", e);
            }

        }

    }
}
