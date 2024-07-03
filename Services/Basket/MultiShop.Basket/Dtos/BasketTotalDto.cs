namespace MultiShop.Basket.Dtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int DiscounRate { get; set; }
        public ICollection<BasketItemDto> BasketItems { get; set; } = [];
        public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }
    }
}
