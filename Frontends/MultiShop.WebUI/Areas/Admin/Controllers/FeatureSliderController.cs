using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Helpers;
using System.Text.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class FeatureSliderController : AdminBaseController
    {
        private const string FEATURE_SLIDER_API_URL = "https://localhost:7070/api/FeatureSliders";
        public FeatureSliderController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var responseMessage = await _client.GetAsync(FEATURE_SLIDER_API_URL);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // JSON'u Deserialize etme
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var values = JsonSerializer.Deserialize<IEnumerable<ResultFeatureSliderDto>>(jsonData, options);

                return View(values);
            }
            return View();
        }

        [Route("CreateFeatureSlider")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureSlider()
        {
            return View();
        }

        [Route("CreateFeatureSlider")]
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto featureSliderDto)
        {
            var stringContent = HttpContentHelper.CreateJsonContent(featureSliderDto);

            var responseMessage = await _client.PostAsync(FEATURE_SLIDER_API_URL, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("UpdateFeatureSlider/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(FeatureSliderDto categoryDto)
        {
            var stringContent = HttpContentHelper.CreateJsonContent(categoryDto);

            var responseMessage = await _client.PutAsync(FEATURE_SLIDER_API_URL, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var responseMessage = await _client.DeleteAsync($"{FEATURE_SLIDER_API_URL}/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }
    }
}
