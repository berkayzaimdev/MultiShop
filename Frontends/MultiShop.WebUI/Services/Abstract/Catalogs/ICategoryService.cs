using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.Abstract.Catalogs
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(CategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<CategoryDto> GetByIdCategoryAsync(string id);
    }
}
