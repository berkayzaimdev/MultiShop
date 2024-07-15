using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Areas.Admin.Attributes;
using MultiShop.WebUI.Helpers;
using MultiShop.WebUI.Services.Abstract.Catalogs;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [PopulateViewBag("Kategoriler","Kategori Listesi","Kategori İşlemleri")]
    public class CategoryController : AdminBaseController
    {
        private const string CATEGORY_API_URL = "https://localhost:7070/api/Categories";
        private readonly ICategoryService _categoryService;
        public CategoryController(IHttpClientFactory httpClientFactory, ICategoryService categoryService) : base(httpClientFactory)
        {
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
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
            await _categoryService.CreateCategoryAsync(categoryDto);
            return RedirectToAction("Index");
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
            await _categoryService.UpdateCategoryAsync(categoryDto);
            return RedirectToAction("Index");
        }

        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}
