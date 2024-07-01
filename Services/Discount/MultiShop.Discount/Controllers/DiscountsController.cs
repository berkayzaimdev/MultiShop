using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var values = await _discountService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var value = await _discountService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateAsync(createCouponDto);
            return Ok("");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateAsync(updateCouponDto);
            return Ok("");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _discountService.DeleteAsync(id);
            return Ok("");
        }
    }
}
