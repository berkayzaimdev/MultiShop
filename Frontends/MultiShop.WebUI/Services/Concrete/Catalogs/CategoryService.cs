using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.Abstract.Catalogs;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.Concrete.Catalogs
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", createCategoryDto);
        }
        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync("categories?id=" + id);
        }
        public async Task<CategoryDto> GetByIdCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("categories/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<CategoryDto>();
            return values;
        }
        public async Task<List<CategoryDto>> GetAllCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CategoryDto>>(jsonData);
            return values;
        }
        public async Task UpdateCategoryAsync(CategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync<CategoryDto>("categories", updateCategoryDto);
        }
    }
}
