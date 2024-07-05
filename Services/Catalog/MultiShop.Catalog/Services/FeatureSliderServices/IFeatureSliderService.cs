using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos.Common;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<IEnumerable<FeatureSliderDto>> GetFeatureSlidersAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<FeatureSliderDto> GetByIdFeatureSliderAsync(string id);
        Task ChangeStatusAsync(string id, bool status);
    }
}
