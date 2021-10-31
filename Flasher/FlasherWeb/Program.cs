using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using FlasherWeb.Services;
using FlasherWeb.Services.Interfaces;

//TODO: add flashcard number to FlashCard
//TODO: add notes feature to FlashCard back
//TODO: add edit/create Subset form
//TODO: add edit/create Set form
//TODO: add edit/create FlashCard
//TODO: add feature to reset all FlashCards to AnsweredCorrectly = false
//TODO: add feature to turn "View AnsweredCorrectly" on and off (currently it is always off)
//TODO: add feature to choose question Superset
//TODO: add feature to filter by question Set
//TODO: add optional image to FlashCard Front
//TODO: change Superset to Group and superset to group
//TODO: change Set to Subgroup and set to subgroup
//TODO: change FlashCard to Flashcard and flashCard to flashcard
//TODO: add timer feature with pause capability
//TODO: add add feature of rich text box to FlashCard front and back
//TODO: add Test object to track practice tests and correct answers, move answered correctly from FlashCard to this new object
//TODO: add feature to review previous tests


namespace FlasherWeb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
           
            builder.Services.AddScoped(api => new HttpClient { BaseAddress = new Uri(builder.Configuration["api_base_url"]) });
            builder.Services.AddHttpClient<IFlashCardService, FlashCardService>(fcs => fcs.BaseAddress = new Uri(builder.Configuration["api_base_url"]));
            builder.Services.AddHttpClient<ISupersetService, SupersetService>(sss => sss.BaseAddress = new Uri(builder.Configuration["api_base_url"]));
            builder.Services.AddHttpClient<ISetService, SetService>(ss => ss.BaseAddress = new Uri(builder.Configuration["api_base_url"]));

            await builder.Build().RunAsync();
        }
    }
}
