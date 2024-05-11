using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using RapidApiProject.Models;

namespace RapidApiProject.Controllers
{
    public class HotelMyCityController : Controller
    {
        public async Task<IActionResult> Index(string cityID)
        {
            if (!string.IsNullOrEmpty(cityID))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?locale=en-gb&filter_by_currency=EUR&checkin_date=2024-05-15&dest_type=city&dest_id=-{cityID}&adults_number=2&checkout_date=2024-05-21&order_by=popularity&room_number=1&units=metric&children_number=2&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&include_adjacency=true&page_number=0"),
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
                    var values = JsonConvert.DeserializeObject<HotelApiViewModel>(body);
                    return View(values.results.ToList());
                }
                
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?locale=en-gb&filter_by_currency=EUR&checkin_date=2024-05-15&dest_type=city&dest_id=-{cityID}&adults_number=2&checkout_date=2024-05-21&order_by=popularity&room_number=1&units=metric&children_number=2&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&include_adjacency=true&page_number=0"),
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
                    var values = JsonConvert.DeserializeObject<HotelApiViewModel>(body);
                    return View(values.results.ToList());
                }
            }

        }
    }
}
