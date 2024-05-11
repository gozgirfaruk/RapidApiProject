using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiProject.Models;

namespace RapidApiProject.Controllers
{
    public class HotelDetailController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/details?currency=USD&locale=en-gb&checkout_date=2024-09-15&hotel_id=241016&checkin_date=2024-09-14"),
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
                var values = JsonConvert.DeserializeObject<HotelDetailViewModel>(body);
                return View(values);
            }
            
        }
    }
}
