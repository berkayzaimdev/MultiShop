using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Helpers;
using System.Text.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class SpecialOfferController : AdminBaseController
    {
        private const string API_URL = "https://localhost:7070/api/SpecialOffers";
        public SpecialOfferController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var responseMessage = await _client.GetAsync(API_URL);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // JSON'u Deserialize etme
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var values = JsonSerializer.Deserialize<IEnumerable<ResultSpecialOfferDto>>(jsonData, options);

                return View(values);
            }
            return View();
        }

        [Route("CreateSpecialOffer")]
        [HttpGet]
        public async Task<IActionResult> CreateSpecialOffer()
        {
            return View();
        }

        [Route("CreateSpecialOffer")]
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto specialOfferDto)
        {
            var stringContent = HttpContentHelper.CreateJsonContent(specialOfferDto);

            var responseMessage = await _client.PostAsync(API_URL, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("UpdateSpecialOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto specialOfferDto)
        {
            var stringContent = HttpContentHelper.CreateJsonContent(specialOfferDto);

            var responseMessage = await _client.PutAsync(API_URL, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var responseMessage = await _client.DeleteAsync($"{API_URL}/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View();
        }
    }
}
