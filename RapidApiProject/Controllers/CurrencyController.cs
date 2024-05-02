using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiProject.Models;

namespace RapidApiProject.Controllers
{
    public class CurrencyController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
                Headers =
    {
        { "X-RapidAPI-Key", "40a677b018msh0b31180528e9fa5p1d8a4djsn1287d501ddd8" },
        { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                return View(values.data.exchange_rates.ToList());
            }
            
        }
    }
}
