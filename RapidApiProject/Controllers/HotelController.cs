using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiProject.Models;

namespace RapidApiProject.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult HotelSearch()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> HotelSearch(HotelSearchViewModel model)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={model.City}"),
                Headers =
    {
        { "X-RapidAPI-Key", "c50d7081cbmsh561e08c9aca9a5dp1d4e53jsn340651195760" },
        { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
    },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<HotelDestinationViewModel>(body);
                var cityId = values.data[0].dest_id;
                var getSearch = new HotelSearchViewModel
                {
                    DestinationID = cityId,
                    City = model.City,
                    EntryDate = model.EntryDate,
                    ExitDate = model.ExitDate,
                    //PersonCount = model.PersonCount,
                    //RoomCount = model.RoomCount
                };
                return RedirectToAction("GetHotelList", getSearch);
            }
        }

        public async Task<IActionResult> GetHotelList(HotelSearchViewModel model)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id={model.DestinationID}&search_type=CITY&arrival_date={model.EntryDate.ToString("yyyy-MM-dd")}&departure_date={model.ExitDate.ToString("yyyy-MM-dd")}&adults=2&room_qty=1&page_number=1&languagecode=en-us&currency_code=EUR"),
                Headers =
    {
        { "X-RapidAPI-Key", "c50d7081cbmsh561e08c9aca9a5dp1d4e53jsn340651195760" },
        { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<HotelListViewModel>(body);
                TempData["Photo"] = values.data.hotels[0].property.photoUrls[0].Replace("square60", "square480");
                return View(values.data.hotels.ToList());
            }
        }

        public IActionResult HotelDetail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> HotelDetail(string hotelId, string EntryDate, string ExitDate)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/getHotelDetails?hotel_id=" + hotelId + "&arrival_date=" + EntryDate + "&departure_date=" + ExitDate + "&languagecode=en-us&currency_code=EUR"),
                Headers =
                {
                        {
                        "X-RapidAPI-Key",
                       "c50d7081cbmsh561e08c9aca9a5dp1d4e53jsn340651195760"
                        },
                        {
                        "X-RapidAPI-Host",
                        "booking-com15.p.rapidapi.com"
                        },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<HotelDetailViewModel>(body);
                if (values.data != null)
                {
                    return View(values.data);
                }
            }
            return View();
        }

    }
}

