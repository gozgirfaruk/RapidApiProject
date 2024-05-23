using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiProject.Models;

namespace RapidApiProject.Controllers
{
    public class AdvisorListController : Controller
    {
        public async Task<IActionResult> AdvisorList()
        {
            List<AdvisorListViewModel> model=   new List<AdvisorListViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tripadvisor16.p.rapidapi.com/api/v1/hotels/searchHotels?geoId=187147&checkIn=2024-05-12&checkOut=2024-05-15&pageNumber=1&currencyCode=USD"),
                Headers =
    {
        { "X-RapidAPI-Key", "aaf2747c06msh50dc49eb860f1a6p16982ajsn820f8f1bba91" },
        { "X-RapidAPI-Host", "tripadvisor16.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<List<AdvisorListViewModel>>(body);
                return View(model);
            }
           
        }
    }
}
