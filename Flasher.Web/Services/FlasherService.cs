using Flasher.Shared.Data.Models;
using Flasher.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Flasher.Web.Services
{
    public class FlasherService : IFlasherService
    {
        private HttpClient _httpClient;

        public FlasherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FlashCard> Get(int id)
        {
            try
            {
                FlashCard flashCard = await _httpClient.GetFromJsonAsync<FlashCard>("Get");
                return flashCard;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve flash card: ", e);
            }
        }

        public async Task<List<FlashCard>> GetAll()
        {
            try
            {
                List<FlashCard> flashCards = await _httpClient.GetFromJsonAsync<List<FlashCard>>("GetAll");
                return flashCards;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to retrieve list of flash cards: ", e);
            }
        }

        public async Task<FlashCard> Create(FlashCard flashCardToCreate)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<FlashCard>("Create", flashCardToCreate);
                FlashCard newFlashCard = await response.Content.ReadFromJsonAsync<FlashCard>();
                return newFlashCard;
            }            
            catch(Exception e)
            {
                throw new Exception("Failed to retrieve new flash card: ", e);
            }
    
        }


        public async Task<FlashCard> Update(FlashCard flashCardUpdate)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<FlashCard>("Update", flashCardUpdate);
                FlashCard updatedFlashCard = await response.Content.ReadFromJsonAsync<FlashCard>();
                return updatedFlashCard;
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
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<FlashCard>("Delete", flashCardToDelete);
                string result = await response.Content.ReadFromJsonAsync<string>();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to delete flash card {flashCardToDelete.Id}: ", e);
            }

        }

    }
}
