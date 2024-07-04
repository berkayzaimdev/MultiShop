using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Areas.Admin.Attributes;
using MultiShop.WebUI.Helpers;
using System.Text.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [PopulateViewBag("Ürünler", "Ürün Listesi", "Ürün İşlemleri")]
    public class ProductController : AdminBaseController
    {
        private const string API_URL = "https://localhost:7070/api/Products";
        private const string CATEGORIES_API_URL = "https://localhost:7070/api/Categories";
        public ProductController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
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

                var values = JsonSerializer.Deserialize<IEnumerable<ResultProductDto>>(jsonData, options);

                return View(values);
            }
            return View();
        }

        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var responseMessage = await _client.GetAsync(CATEGORIES_API_URL);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var values = JsonSerializer.Deserialize<IEnumerable<CategoryDto>>(jsonData, options);

                IEnumerable<SelectListItem> categoryValues = (
                    from c in values
                    select new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Id
                    });

                ViewBag.CategoryValues = categoryValues;

                return View();
            }
            return View();
        }

        [Route("CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
        {
            var stringContent = HttpContentHelper.CreateJsonContent(productDto);

            var responseMessage = await _client.PostAsync(API_URL, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct()
        {
            var responseMessage = await _client.GetAsync(CATEGORIES_API_URL);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var values = JsonSerializer.Deserialize<IEnumerable<CategoryDto>>(jsonData, options);

                IEnumerable<SelectListItem> categoryValues = (
                    from c in values
                    select new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Id
                    });

                ViewBag.CategoryValues = categoryValues;

                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto productDto)
        {
            var stringContent = HttpContentHelper.CreateJsonContent(productDto);

            var responseMessage = await _client.PutAsync(API_URL, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var responseMessage = await _client.DeleteAsync($"{API_URL}/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
