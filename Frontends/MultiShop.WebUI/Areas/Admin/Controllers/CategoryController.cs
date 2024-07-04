using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Areas.Admin.Attributes;
using MultiShop.WebUI.Helpers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [PopulateViewBag("Kategoriler","Kategori Listesi","Kategori İşlemleri")]
    public class CategoryController : AdminBaseController
    {
        private const string CATEGORY_API_URL = "https://localhost:7070/api/Categories";
        public CategoryController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var responseMessage = await _client.GetAsync(CATEGORY_API_URL);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // JSON'u Deserialize etme
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var values = JsonSerializer.Deserialize<IEnumerable<CategoryDto>>(jsonData, options);

                return View(values);
            }
            return View();
        }

        [Route("Create")]
        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
        {
            var stringContent = HttpContentHelper.CreateJsonContent(categoryDto);

            var responseMessage = await _client.PostAsync(CATEGORY_API_URL, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(); 
        }

        [Route("UpdateCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryDto categoryDto)
        {
            var stringContent = HttpContentHelper.CreateJsonContent(categoryDto);

            var responseMessage = await _client.PutAsync(CATEGORY_API_URL, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var responseMessage = await _client.DeleteAsync($"{CATEGORY_API_URL}/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }
    }
}
