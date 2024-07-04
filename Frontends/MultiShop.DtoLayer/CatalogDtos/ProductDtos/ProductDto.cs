namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; } = 0;
        public string CategoryId { get; set; }
    }
}
