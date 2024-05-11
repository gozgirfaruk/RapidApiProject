using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using RapidApiProject.Models;

namespace RapidApiProject.Controllers
{
    public class SeachLocationIdController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if(!string.IsNullOrEmpty(cityName))
            {
                List<HotelLocationSearchViewModel> model = new List<HotelLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "aaf2747c06msh50dc49eb860f1a6p16982ajsn820f8f1bba91" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<HotelLocationSearchViewModel>>(body);
                    return View(model.Take(1).ToList());
                }
               
            }
            else
            {
                List<HotelLocationSearchViewModel> model = new List<HotelLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=Berlin&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "aaf2747c06msh50dc49eb860f1a6p16982ajsn820f8f1bba91" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<HotelLocationSearchViewModel>>(body);
                    return View(model.Take(1).ToList());
                }
            }
         
           
        }
    }
}
