using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllAsync();
        Task CreateAsync(CreateCouponDto createCouponDto);
        Task UpdateAsync(UpdateCouponDto createCouponDto);
        Task DeleteAsync(int id);
        Task<GetByIdCouponDto> GetByIdAsync(int id);
    }
}
