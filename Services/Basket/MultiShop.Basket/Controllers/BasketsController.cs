using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.Services.Abstract;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketDetailAsync()
        {
            var value = await _basketService.GetBasketAsync(_loginService.GetUserId);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasketAsync(basketTotalDto);
            return Ok("Değişiklikler başarıyla kaydedildi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasketAsync(BasketTotalDto basketTotalDto)
        {
            await _basketService.DeleteBasketAsync(_loginService.GetUserId);
            return Ok("Sepet silindi!");
        }
    }
}
