using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiProject.Models;
using System.Text.Json.Serialization;

namespace RapidApiProject.Controllers
{
    public class ImdbTopMovieController : Controller
    {
        public async Task<IActionResult> Index()
        { 
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "40a677b018msh0b31180528e9fa5p1d8a4djsn1287d501ddd8" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
              var values = JsonConvert.DeserializeObject<List<MovieViewModel>>(body);
                return View(values);
            }
          
        }
    }
}
