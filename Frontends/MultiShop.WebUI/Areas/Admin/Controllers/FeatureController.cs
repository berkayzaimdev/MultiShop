using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Helpers;
using System.Text.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class FeatureController : AdminBaseController
    {
        private const string API_URL = "https://localhost:7070/api/Features";
        public FeatureController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
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

                var values = JsonSerializer.Deserialize<IEnumerable<ResultFeatureDto>>(jsonData, options);

                return View(values);
            }
            return View();
        }

        [Route("CreateFeature")]
        [HttpGet]
        public async Task<IActionResult> CreateFeature()
        {
            return View();
        }

        [Route("CreateFeature")]
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto specialOfferDto)
        {
            var stringContent = HttpContentHelper.CreateJsonContent(specialOfferDto);

            var responseMessage = await _client.PostAsync(API_URL, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("UpdateFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto specialOfferDto)
        {
            var stringContent = HttpContentHelper.CreateJsonContent(specialOfferDto);

            var responseMessage = await _client.PutAsync(API_URL, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            var responseMessage = await _client.DeleteAsync($"{API_URL}/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }
    }
}
